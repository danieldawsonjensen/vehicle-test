using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace Model;

public class Vehicle
{

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? MongoId { get; set; }

    [BsonElement("VehicleId")]
    public int VehicleId { get; set; }

    [BsonElement("VehicleBrand")]
    public string VehicleBrand { get; set; }

    [BsonElement("VehicleModel")]
    public string VehicleModel { get; set; }

    [BsonElement("VehicleRegNr")]
    public string VehicleRegNr { get; set; }

    [BsonElement("MilesDriven")]
    public int MilesDriven { get; set; }

    [BsonElement("ServiceHistory")]
    public List<Service>? ServiceHistory { get; set; } = new List<Service>();

    [BsonElement("ImageHistory")]
    public List<Image>? ImageHistory { get; set; } = new List<Image>();


    [BsonElement("Oprettelse")]
    public DateTime? Oprettelse { get; set; } = DateTime.Now.Date;

    [BsonElement("SidstAendret")]
    public DateTime? SidstAendret { get; set; } = DateTime.Now.Date;


    public Vehicle()
    {

    }


    public Vehicle(int vehicleId, string vehicleBrand, string vehicleRegNr, int milesDriven, List<Service> serviceHistory, List<Image> imageHistory, DateTime? oprettelse, DateTime? sidstAendret)
    {
        this.VehicleId = vehicleId;
        this.VehicleBrand = vehicleBrand;
        this.VehicleRegNr = vehicleRegNr;
        this.MilesDriven = milesDriven;
        this.ServiceHistory = serviceHistory;
        this.ImageHistory = imageHistory;
        this.Oprettelse = oprettelse;
        this.SidstAendret = sidstAendret;
    }
}
