using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using RentABoat.Core.Services;
using RentABoat.Infrastructure.Entities;
using RentABoat.Infrastructure.Repository;
using Xunit;

namespace RentABoat.Tests;

public class BoatServiceTests
{
    [Fact]
    public async Task GetBoatsAsync_ShouldReturnBoatOfGivenType()
    {
        var boats = new List<Boat>
        {
            new()
            {
                Type = "Motorboat",
                Length = 12,
                NumberOfBerths = 6,
                YearOfBuilt = 2019,
                Model = "SeaBreeze 550",
                Harbour = "Sydney",
                IsAvailable = true,
            },
            new()
            {
                Type = "Sailboat",
                Length = 14,
                NumberOfBerths = 8,
                YearOfBuilt = 2020,
                Model = "Bavaria 46 Cruiser",
                Harbour = "Biograd",
                IsAvailable = true,
            }
        };
        var boatRepositoryMock = new Moq.Mock<IBoatRepository>();
        boatRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(boats);

        var sut = new BoatService(boatRepositoryMock.Object, Mock.Of<ISailorAccountRepository>());
        var result = await sut.GetBoatsAsync("Sailboat");

        result.Should().NotBeNull();
        result.Where(x => x.Type == "Sailboat").Should().NotBeNull();
    }

    [Fact]
    public async Task GetAllBoatsBasicInformationAsync_ShouldNotBeNull()
    {
        var boats = new List<Boat>
        {
            new()
            {
                Type = "Motorboat",
                Length = 12,
                NumberOfBerths = 6,
                YearOfBuilt = 2019,
                Model = "SeaBreeze 550",
                Harbour = "Sydney",
                IsAvailable = true,
            },
            new()
            {
                Type = "Sailboat",
                Length = 14,
                NumberOfBerths = 8,
                YearOfBuilt = 2020,
                Model = "Bavaria 46 Cruiser",
                Harbour = "Biograd",
                IsAvailable = true,
            }
        };
        var boatRepositoryMock = new Moq.Mock<IBoatRepository>();
        boatRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(boats);

        var sut = new BoatService(boatRepositoryMock.Object, Mock.Of<ISailorAccountRepository>());
        var result = await sut.GetAllBoatsBasicInformationAsync();
        result.Should().NotBeNull();
        result.Count().Should().Be(2);
    }
}