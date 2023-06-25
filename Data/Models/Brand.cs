namespace Data.Models
{
#nullable disable
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Model> Models { get; set; }
    }
}
