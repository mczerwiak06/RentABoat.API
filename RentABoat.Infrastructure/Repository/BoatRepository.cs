using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RentABoat.Infrastructure.Context;
using RentABoat.Infrastructure.Entities;
using RentABoat.Infrastructure.Exceptions;

namespace RentABoat.Infrastructure.Repository;

public class BoatRepository : IBoatRepository
{
    private readonly MainContext _mainContext;
    private readonly ILogger<IBoatRepository> _logger;

    public BoatRepository(MainContext mainContext, ILogger<IBoatRepository> logger)
    {
        _mainContext = mainContext;
        _logger = logger;
    }

    public async Task<IEnumerable<Boat>> GetAllAsync()
    {
        var boats = await _mainContext.Boat.ToListAsync();
        return boats;
    }

    public async Task<Boat> GetByIdAsync(int id)
    {
        var boat = await _mainContext.Boat.SingleOrDefaultAsync(x => x.Id == id);
        if (boat != null)
            return boat;
        _logger.LogError("Boat with provided id: {BoatId} doesn't exist", id);
        throw new EntityNotFoundException();
    }

    public async Task AddAsync(Boat entity)
    {
        entity.DateOfCreation = DateTime.UtcNow;
        await _mainContext.AddAsync(entity);
        await _mainContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Boat entity)
    {
        var boatToUpdate = await _mainContext.Boat.SingleOrDefaultAsync(x => x.Id == entity.Id);
        if (boatToUpdate != null)
        {
            boatToUpdate.Type = entity.Type;
            boatToUpdate.Length = entity.Length;
            boatToUpdate.NumberOfBerths = entity.NumberOfBerths;
            boatToUpdate.YearOfBuilt = entity.YearOfBuilt;
            boatToUpdate.Model = entity.Model;
            boatToUpdate.Harbour = entity.Harbour;
            boatToUpdate.IsAvailable = entity.IsAvailable;
            boatToUpdate.SailorAccountId = entity.SailorAccountId;
            boatToUpdate.DateOfUpdate = DateTime.UtcNow;

            await _mainContext.SaveChangesAsync();
        }

        throw new EntityNotFoundException();
    }

    public async Task DeleteByIdAsync(int id)
    {
        var boatToDelete = await _mainContext.Boat.SingleOrDefaultAsync(x => x.Id == id);
        if (boatToDelete != null)
        {
            _mainContext.Boat.Remove(boatToDelete);
            await _mainContext.SaveChangesAsync();
        }
        else
        {
            _logger.LogError("Boat with provided id: {BoatId} doesn't exist", id);
            throw new EntityNotFoundException();
        }

    }
}
