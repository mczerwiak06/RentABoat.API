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

public class SailorAccountServiceTests
{
    [Fact]
    public async Task GetAllSailorsBasicInformationAsync_ShouldNotBeNull()
    {
        var sailors = new List<SailorAccount>
        {
            new()
            {
                FirstName = "Adam",
                LastName = "Nowak",
                Email = "nowak@mail.com",
                PhoneNumber = "555-555-555",
                Street = "Laskowa",
                City = "Gdynia",
                ZipCode = "81-103",
                BuildingNumber = 24
            },
            new()
            {
                FirstName = "Rafał",
                LastName = "Kata",
                Email = "katak@mail.com",
                PhoneNumber = "444-444-444",
                Street = "Polna",
                City = "Gdynia",
                ZipCode = "81-103",
                BuildingNumber = 28
            },
            new()
            {
                FirstName = "Ewa",
                LastName = "Równa",
                Email = "erownak@mail.com",
                PhoneNumber = "222-222-222",
                Street = "Kwiatowa",
                City = "Gdynia",
                ZipCode = "81-103",
                BuildingNumber = 212
            }
        };
        var sailorAccountRepositoryMock = new Mock<ISailorAccountRepository>();
        sailorAccountRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(sailors);

        var sut = new SailorAccountService(sailorAccountRepositoryMock.Object);

        var result = await sut.GetAllSailorsBasicInformationAsync();
        result.Should().NotBeNull();
        result.Count().Should().Be(3);
    }
}
