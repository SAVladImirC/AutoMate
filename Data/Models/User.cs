using System.Text.Json.Serialization;

namespace Data.Models
{
#nullable disable
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Dob { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string PasswordHashed { get; set; }
        [JsonIgnore]
        public byte[] PasswordSalt { get; set; }

        public virtual Address Address { get; set; }

        public virtual List<Vehicle> Vehicles { get; set; }

        public virtual List<ServiceStation> ServiceStations { get; set; }

        public virtual List<Invoice> Invoices { get; set; }
    }
}