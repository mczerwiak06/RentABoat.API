using Microsoft.EntityFrameworkCore;
using RentABoat.Infrastructure.Context;
using RentABoat.Infrastructure.Entities;
using RentABoat.Infrastructure.Exceptions;

namespace RentABoat.Infrastructure.Repository;

public class BoatRepository : IBoatRepository
{
    private readonly MainContext _mainContext;

    public BoatRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
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

        throw new EntityNotFoundException();
    }
}
