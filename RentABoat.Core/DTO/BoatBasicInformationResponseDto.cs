namespace RentABoat.Core.DTO;

public class BoatBasicInformationResponseDto
{
    public BoatBasicInformationResponseDto(string type, int length, int numberOfBerths, int yearOfBuilt, string model,
        string harbour, bool isAvailable)
    {
        Type = type;
        Length = length;
        NumberOfBerths = numberOfBerths;
        YearOfBuilt = yearOfBuilt;
        Model = model;
        Harbour = harbour;
        IsAvailable = isAvailable;
    }

    public string Type { get; set; }
    public int Length { get; set; }
    public int NumberOfBerths { get; set; }
    public int YearOfBuilt { get; set; }
    public string Model { get; set; }
    public string Harbour { get; set; }
    public bool IsAvailable { get; set; }
}
