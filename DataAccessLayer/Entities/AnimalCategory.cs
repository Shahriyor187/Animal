namespace DataAccsesLayer.Entities;

public class AnimalCategory : BaseEntitiy
{
    public string Name { get; set; } = string.Empty;
    public List<Animal> Animals = new();
}
