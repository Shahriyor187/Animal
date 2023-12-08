using DataAccsesLayer.Entities;

namespace BussinessLogicLayer.Dtos
{
    public class AddAnimaldto
    {
        public string Name { get; set; } = string.Empty;
        public string Homeland { get; set; } = string.Empty;
        public int CategoryId { get; set; }
    }
}
