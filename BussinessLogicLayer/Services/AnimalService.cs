using AutoMapper;
using BusnisLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccsesLayer;
using DataAccsesLayer.Entities;
using BussinessLogicLayer.Dtos;
using Animals.Dtos;

namespace BusnisLogicLayer.Services;

public class AnimalService(ApplicationDbContext dbContext, IUnitOfWork unitOfWork, IMapper mapper) : IAnimalService
{
    private readonly ApplicationDbContext _dbcontext = dbContext;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task AddAnimalAsync (AddAnimaldto newAnimal)
    {
        var animal = _mapper.Map<Animal>(newAnimal);
        animal.AnimalCategory = null;
        await _unitOfWork.AnimalInterface.AddAsync(animal);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteAnimalAsync(int id)
    { 
         var existingAnimal = await _unitOfWork.AnimalInterface.GetByIdAsync(id);
         if (existingAnimal is null)
         {
             throw new ArgumentException($"Animal with Id {id} not found.");
         }
        await _unitOfWork.AnimalInterface.DeleteAsync(existingAnimal);
        await _unitOfWork.SaveAsync();
    }

    public async Task<List<AnimalDto>> GetAnimalAsync()
    {
        var animals = await _unitOfWork.AnimalInterface.GetAllAsync();
        return _mapper.Map<List<AnimalDto>>(animals);
    }

    public async Task<AnimalDto> GetAnimalByIdAsync(int id)
    {
        var animal = await _unitOfWork.AnimalInterface.GetByIdAsync(id);
        return _mapper.Map<AnimalDto>(animal);
    }

    public async Task UpdateAnimalAsync(AnimalDto animalDto)
    {
        var animal = _mapper.Map<Animal>(animalDto);
        _unitOfWork.AnimalInterface.Update(animal);
        await _unitOfWork.SaveAsync();
    }
}
