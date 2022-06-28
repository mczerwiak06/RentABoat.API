using System.ComponentModel.DataAnnotations;
using RentABoat.Core.DTO;
using RentABoat.Infrastructure.Entities;
using RentABoat.Infrastructure.Repository;

namespace RentABoat.Core.Services;

public class BoatService : IBoatService
{
    private readonly IBoatRepository _boatRepository;

    public BoatService(IBoatRepository boatRepository)
    {
        _boatRepository = boatRepository;
    }

    public async Task<IEnumerable<BoatBasicInformationResponseDto>> GetAllApartmentBasicInformationAsync()
    {
        var boats = await _boatRepository.GetAllAsync();

        return boats.Select(x => new BoatBasicInformationResponseDto(
            x.Type,
            x.Length,
            x.NumberOfBerths,
            x.YearOfBuilt,
            x.Model,
            x.Harbour,
            x.IsAvailable));
    }

    public async Task AddNewBoatAsync(BoatCreationRequestDto dto)
    {
        await _boatRepository.AddAsync(new Boat
        {
            Type = dto.Type,
            Length = dto.Length,
            NumberOfBerths = dto.NumberOfBerths,
            YearOfBuilt = dto.YearOfBuilt,
            Model = dto.Model,
            Harbour = dto.Harbour,
            IsAvailable = dto.IsAvailable,
            DateOfCreation = DateTime.UtcNow,
            DateOfUpdate = DateTime.UtcNow
        });
    }

    public async Task<BoatBasicInformationResponseDto> GetSailBoatsAsync()
    {
        throw new NotImplementedException();
        /*var boats = await _boatRepository.GetAllAsync();

        var motorboats = boats.Where(x => x.Type == "sailboat").ToList();

        if (motorboats is null) return null;
        return motorboats;
        /*return motorboats.Select(x => new BoatBasicInformationResponseDto(
            x.Type,
            x.Length,
            x.NumberOfBerths,
            x.YearOfBuilt,
            x.Model,
            x.Harbour,
            x.IsAvailable));#1#*/
    }
}