using System; //kjaer

namespace Model;

public class Vehicle
{
    public int VehicleId { get; set; }
    public string VehicleBrand { get; set; }
    public string VehicleRegNr { get; set; }
    public int MilesDriven { get; set; }

    public List<Image>? ImageHistory { get; set; } = new List<Image>();

    public List<Service>? ServiceHistory { get; set; } = new List<Service>();

    public Vehicle()
    {

    }

    public Vehicle(int vehicleId, string vehicleBrand, string vehicleRegNr, int milesDriven)
    {
        this.VehicleId = vehicleId;
        this.VehicleBrand = vehicleBrand;
        this.VehicleRegNr = vehicleRegNr;
        this.MilesDriven = milesDriven;
    }
}
