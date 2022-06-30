using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RentABoat.Infrastructure.Context;
using RentABoat.Infrastructure.Entities;
using RentABoat.Infrastructure.Exceptions;

namespace RentABoat.Infrastructure.Repository;

public class SailorAccountRepository : ISailorAccountRepository
{
    private readonly ILogger<ISailorAccountRepository> _logger;
    private readonly MainContext _mainContext;

    public SailorAccountRepository(MainContext mainContext, ILogger<SailorAccountRepository> logger)
    {
        _mainContext = mainContext;
        _logger = logger;
    }

    public async Task<IEnumerable<SailorAccount>> GetAllAsync()
    {
        var sailors = await _mainContext.SailorAccount.ToListAsync();
        return sailors;
    }

    public async Task<SailorAccount> GetByIdAsync(int id)
    {
        var sailor = await _mainContext.SailorAccount.SingleOrDefaultAsync(x => x.Id == id);
        if (sailor != null)
            return sailor;

        _logger.LogError("SailorAccount with provided id: {SailorAccountID} doesn't exist.", id);
        throw new EntityNotFoundException();
    }

    public async Task AddAsync(SailorAccount entity)
    {
        var sailorAccountToAdd = await _mainContext.SailorAccount.AnyAsync(x => x.Email == entity.Email);

        if (sailorAccountToAdd) throw new EntityAlreadyExistsException();
        entity.DateOfCreation = DateTime.UtcNow;
        await _mainContext.AddAsync(entity);
        await _mainContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(SailorAccount entity)
    {
        var sailorToUpdate = await _mainContext.SailorAccount.SingleOrDefaultAsync(x => x.Id == entity.Id);
        if (sailorToUpdate == null)
        {
            _logger.LogError("SailorAccount with provided id: {SailorAccountID} doesn't exist.", entity.Id);
            throw new EntityNotFoundException();
        }

        sailorToUpdate.FirstName = entity.FirstName;
        sailorToUpdate.LastName = entity.LastName;
        sailorToUpdate.Email = entity.Email;
        sailorToUpdate.PhoneNumber = entity.PhoneNumber;
        sailorToUpdate.Street = entity.Street;
        sailorToUpdate.City = entity.City;
        sailorToUpdate.ZipCode = entity.ZipCode;
        sailorToUpdate.BuildingNumber = entity.BuildingNumber;
        sailorToUpdate.BoatId = entity.BoatId;
        sailorToUpdate.DateOfUpdate = DateTime.UtcNow;

        sailorToUpdate.Boat.Type = entity.Boat.Type;
        sailorToUpdate.Boat.Length = entity.Boat.Length;
        sailorToUpdate.Boat.NumberOfBerths = entity.Boat.NumberOfBerths;
        sailorToUpdate.Boat.YearOfBuilt = entity.Boat.YearOfBuilt;
        sailorToUpdate.Boat.Model = entity.Boat.Model;
        sailorToUpdate.Boat.Harbour = entity.Boat.Harbour;
        sailorToUpdate.Boat.IsAvailable = entity.Boat.IsAvailable;
        sailorToUpdate.Boat.SailorAccount = entity.Boat.SailorAccount;

        await _mainContext.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        var sailorAccountToDelete = await _mainContext.SailorAccount.SingleOrDefaultAsync(x => x.Id == id);
        if (sailorAccountToDelete == null)
        {
            _logger.LogError("SailorAccount with provided id: {SailorAccountID} doesn't exist.", id);
            throw new EntityNotFoundException();
        }

        _mainContext.SailorAccount.Remove(sailorAccountToDelete);
        await _mainContext.SaveChangesAsync();
    }
}
