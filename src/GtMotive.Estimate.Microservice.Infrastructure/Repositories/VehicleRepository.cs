using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly IMongoCollection<Vehicle> _vehicles;

        public VehicleRepository(IMongoClient mongoClient, IOptions<MongoDbSettings> settings)
        {
            var database = mongoClient?.GetDatabase(settings?.Value.MongoDbDatabaseName);
            _vehicles = database.GetCollection<Vehicle>("Vehicles");
        }

        public async Task AddAsync(Vehicle vehicle)
        {
            try
            {
                await _vehicles.InsertOneAsync(vehicle);
            }
            catch (MongoException ex)
            {
                Console.WriteLine(ex);
            }
        }

        public async Task<Vehicle> GetByVin(string vin)
        {
            var filter = Builders<Vehicle>.Filter.Eq(v => v.VIN, vin);
            return await _vehicles.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<Vehicle> GetByCustomer(string customerId)
        {
            var filter = Builders<Vehicle>.Filter.Eq(v => v.RentedById, customerId);
            return await _vehicles.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Vehicle>> GetAllAsync()
        {
            return await _vehicles.Find(_ => true).ToListAsync();
        }

        public async Task UpdateAsync(Vehicle vehicle)
        {
            if (vehicle == null)
            {
                throw new ArgumentNullException(nameof(vehicle), "Vehicle do not exist");
            }

            var filter = Builders<Vehicle>.Filter.Eq(v => v.Id, vehicle.Id);
            await _vehicles.ReplaceOneAsync(filter, vehicle);
        }
    }
}
