using System.ComponentModel.DataAnnotations;

namespace DataAccsesLayer.Entities;

public class Animal : BaseEntitiy
{
    [Required, StringLength(50)]
    public string Name { get; set; } = string.Empty;
    public string Homeland { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public AnimalCategory AnimalCategory = new();
}
