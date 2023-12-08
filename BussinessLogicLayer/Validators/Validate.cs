using DataAccsesLayer.Entities;
using System.Runtime.CompilerServices;

namespace BusnisLogicLayer.Validators;

public static class Validate
{
    public static bool IsValid(this AnimalCategory dto)
        => !string.IsNullOrWhiteSpace(dto.Name);

    public static bool IsUnique(this AnimalCategory dto, IEnumerable<AnimalCategory> list)
        => !list.Any(c => c.Equals(dto));

    public static bool IsValid(this Animal dto)
    => !string.IsNullOrWhiteSpace(dto.Name) &&
       !string.IsNullOrWhiteSpace(dto.Homeland);

    public static bool IsUnique(this Animal dto, IEnumerable<Animal> list)
    => !list.Any(b => b.Equals(dto));

    public static bool Equlas(this Animal dto, Animal entity, AnimalCategory category, AnimalCategory animalCategory)
        => dto.Name == entity.Name &&
           dto.Homeland == entity.Homeland &&
           dto.Id == entity.Id &&
           category.Id == animalCategory.Id &&
           category.Name == animalCategory.Name;
}
