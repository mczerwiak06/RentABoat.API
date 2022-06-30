namespace RentABoat.Core.DTO;

public class BoatCreationRequestDto
{
    public string Type { get; set; }
    public int Length { get; set; }
    public int NumberOfBerths { get; set; }
    public int YearOfBuilt { get; set; }
    public string Model { get; set; }
    public string Harbour { get; set; }
    public bool IsAvailable { get; set; }

    public int? SailorAccountId { get; set; }
}
