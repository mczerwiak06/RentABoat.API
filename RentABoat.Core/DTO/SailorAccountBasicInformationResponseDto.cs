namespace RentABoat.Core.DTO;

public class SailorAccountBasicInformationResponseDto
{
    public SailorAccountBasicInformationResponseDto(string firstName, string lastName, string email, string phoneNumber,
        string street, string city, string zipCode, int buildingNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        Street = street;
        City = city;
        ZipCode = zipCode;
        BuildingNumber = buildingNumber;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }
    public int BuildingNumber { get; set; }
}
