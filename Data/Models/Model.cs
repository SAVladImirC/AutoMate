namespace Data.Models
{
#nullable disable
    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }

        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}
