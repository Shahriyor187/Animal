using DataAccsesLayer.Entities;

namespace Animals.Dtos
{
    public class AnimalDto
    {
        public int Id;
        public string Name { get; set; } = string.Empty;
        public string Homeland { get; set; } = string.Empty;
        public int CategoryId { get; set; }
    }
}
