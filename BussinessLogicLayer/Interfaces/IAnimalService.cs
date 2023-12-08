using Animals.Dtos;
using BussinessLogicLayer.Dtos;

namespace BusnisLogicLayer.Interfaces;

public interface IAnimalService
{
    Task<List<AnimalDto>> GetAnimalAsync();
    Task<AnimalDto> GetAnimalByIdAsync(int id);
    Task AddAnimalAsync(AddAnimaldto newAnimal);
    Task UpdateAnimalAsync(AnimalDto animalDto);
    Task DeleteAnimalAsync(int id);
}
