namespace Data.Models
{
#nullable disable
    public class Vehicle
    {
        public int Id { get; set; }
        public string Vin { get; set; }
        public string RegistrationPlate { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public float CurrentMileage { get; set; }
        public float NextServiceMileage { get; set; } 

        public virtual List<PerformedService> PerformedServices { get; set; }

        public int OwnerId { get; set; }
        public virtual User Owner { get; set; }

        public int ModelId { get; set; }
        public virtual Model Model { get; set; }
    }
}
