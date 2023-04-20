using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace Model;

public class Vehicle
{

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public int VehicleId { get; set; }

    [BsonElement("Mærke")]
    public string VehicleBrand { get; set; }

    [BsonElement("Model")]
    public string VehicleModel { get; set; }

    [BsonElement("Registreringsnummer")]
    public string VehicleRegNr { get; set; }

    [BsonElement("Kilometerstand")]
    public int MilesDriven { get; set; }

    [BsonElement("Servicehistorik")]
    public List<Service>? ServiceHistory { get; set; } = new List<Service>();

    [BsonElement("Billedhistorik")]
    public List<Image>? ImageHistory { get; set; } = new List<Image>();


    [BsonElement("Oprettelse")]
    public DateTime? Oprettelse { get; set; } = DateTime.Now.Date;

    [BsonElement("SidstAendræt")]
    public DateTime? SidstAendret { get; set; } = DateTime.Now.Date;


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
