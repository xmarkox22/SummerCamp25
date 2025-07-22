// Aplicación QuebrantaPrecios 


Console.WriteLine("QuebrantaPrecios App");

// Crear instancia de la clase District
var district = new District();


// Crear instancia de la clase Building para buildingNewGardens
var buildingNewGardens = new Building();

buildingNewGardens.Name = "Edificio Central New Gardens IV";
buildingNewGardens.Id = 1;
buildingNewGardens.FloorNumber = 10;
buildingNewGardens.HasLift = true;

// Crear instancia de la clase Building para buildingDreamTowers

var buildingDreamTowers = new Building() {
    Name = "Torre de los Sueños",
    Id = 2,
    FloorNumber = 20,
    HasLift = true
};


// Crear instancia de la clase Building para buildingSkyline

var buildingSkyline = new Building(floorNumber: 30, name: "Skyline Towers", id: 3 );


// Crear una lista de edificios
// Todas las listas Implementan IEnumerable<T> y son genéricas
var buildings = new List<Building>
{
    buildingNewGardens,
    buildingDreamTowers,
    buildingSkyline
};




// Mostrar información de los edificios
// Mostrar numero total de apartamentos por edificio
foreach (var building in buildings)
{
    Console.WriteLine(building);
}

