namespace Garage_1._0.Garage
{
    internal interface IGarageHandler
    {
        void AddVehicle(string type);
        void AddVehicleMenu();
        void CreateGarage();
        void DisplayTypes();
        void DisplayVehicles();
        void MainMenu();
        void RemoveVehicle();
        void SearchFunction();
    }
}