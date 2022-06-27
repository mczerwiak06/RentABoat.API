namespace RentABoat.Infrastructure.Entities;

public class SailorAccount : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }
    public int BuildingNumber { get; set; }

    public int? BoatId { get; set; }
    public Boat Boat { get; set; }
}