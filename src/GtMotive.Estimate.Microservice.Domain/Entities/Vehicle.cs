using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Gets or sets Vehicles.
    /// </summary>
    public class Vehicle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle"/> class.
        /// </summary>
        /// <param name="id">Vehicle Id.</param>
        /// <param name="vin">Vehicle VIN.</param>
        /// <param name="plate">Vehicle Plate.</param>
        /// <param name="brand">Vehicle Brand.</param>
        /// <param name="model">Vehicle Model.</param>
        /// <param name="manufacturingDate">Manufacture Date.</param>
        /// <param name="rentedById">CustomerId who has rented the car.</param>
        public Vehicle(Guid id, string vin, string plate, string brand, string model, DateTime manufacturingDate, string rentedById)
        {
            if (manufacturingDate < DateTime.UtcNow.Date.AddYears(-5))
            {
                throw new ArgumentException("You cannot create a vehicle that is more than 5 years old.");
            }

            Id = id;
            VIN = vin;
            Plate = plate;
            Brand = brand;
            Model = model;
            ManufactureDate = manufacturingDate;
            RentedById = rentedById;
        }

        /// <summary>
        /// Gets or sets the Id of the Vehicle.
        /// </summary>
        ///
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the VIN of the Vehicle.
        /// </summary>
        public string VIN { get; set; }

        /// <summary>
        /// Gets or sets the Plate of the Vehicle.
        /// </summary>
        public string Plate { get; set; }

        /// <summary>
        /// Gets or sets the Brand of the Vehicle.
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Gets or sets the Model of the Vehicle.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the ManufactureDate of the Vehicle.
        /// </summary>
        public DateTime ManufactureDate { get; set; }

        /// <summary>
        /// Gets or sets Id of the customer who has rented the vehicle.
        /// </summary>
        public string RentedById { get; set; } = string.Empty;
    }
}
