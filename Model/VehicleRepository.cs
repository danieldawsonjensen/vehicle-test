using MongoDB.Driver;
using System.Threading.Tasks;
using Model;

namespace Model
{
    public class VehicleRepository
    {
        private readonly IMongoCollection<Vehicle> _vehicles;

        public VehicleRepository()
        {
            var client = new MongoClient("mongodb://MyServiceUser:my_$ecure_pa$$word@localhost:27018/?authSource=admin"); // vores mongo conn string

            var database = client.GetDatabase("Vehicles"); // vores database
            _vehicles = database.GetCollection<Vehicle>("Vehicles");
        }


        public async Task<Vehicle> GetVehicleById(int id)
        {
            var filter = Builders<Vehicle>.Filter.Eq("id", id);
            return await _vehicles.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<List<Vehicle>> GetAllVehicles()
        {
            return await _vehicles.Aggregate().ToListAsync();
        }

        public async void AddVehicle(Vehicle vehicle)
        {
            _vehicles.InsertOne(vehicle);
        }

        public async void AddService(Service service, int id)
        {
            Vehicle serviceVehicle = await GetVehicleById(id);

            serviceVehicle.ServiceHistory.Add(service);
        }
    }
}
