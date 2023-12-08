using System.ComponentModel.DataAnnotations;

namespace DataAccsesLayer.Entities;

public class BaseEntitiy
{
    [Key, Required]
    public int Id { get; set; }
}
