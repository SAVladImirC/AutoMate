﻿namespace Data.Models
{
#nullable disable
    public class Address
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string PostalCode { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
