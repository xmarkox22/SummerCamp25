

namespace Business.RealState;

public class Building
{
    public Building(string name = "", int id = 0, int floorNumber = 0, bool hasLift = true)
    {
        Name = name;
        Id = id;
        FloorNumber = floorNumber;
        HasLift = hasLift;
        ApartmentsPerFloor = 4;
    }

    public string Name { get; set; }
    public int Id { get; set; }
    public int FloorNumber { get; set; }
    public bool HasLift { get; set; }
    public int ApartmentsPerFloor { get; set; }

    public District District { get; set; }

    public Building()
    {

    }

    private string ShowApartmentsNumber()
    {
        return $"Número total de apartamentos en {Name}: {FloorNumber * ApartmentsPerFloor}";
    }

    public override string ToString()
    {
        return $"Edificio: {Name}, ID: {Id}, Pisos: {FloorNumber}, Tiene Ascensor: {HasLift}, Apartamentos por piso: {ApartmentsPerFloor}, Total Apartamentos: {ShowApartmentsNumber()}";
    }
}
