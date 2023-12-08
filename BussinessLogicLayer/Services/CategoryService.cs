using Animals.Dtos;
using AutoMapper;
using BusinessLogicLayer.Helpers;
using BussinessLogicLayer.Dtos.CategoryDto;
using BussinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccsesLayer.Entities;

public class CategoryService : ICategoryServeice
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    public async Task AddCategoryAsync(AddCategoryDto newCategory)
    {
        var category = _mapper.Map<AnimalCategory>(newCategory);
        await _unitOfWork.CategoryInterface.AddAsync(category);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteCategoryAsync(int id)
    {
        var category = await _unitOfWork.AnimalInterface.GetByIdAsync(id);
        if (category is null)
        {
            throw new ArgumentException($"Animal with Id {id} not found.");
        }
        await _unitOfWork.AnimalInterface.DeleteAsync(category);
        await _unitOfWork.SaveAsync();
    }

    public async Task<List<AnimalCategoryDto>> GetCategoriesAsync()
    {
        var animals = await _unitOfWork.AnimalInterface.GetAllAsync();
        return _mapper.Map<List<AnimalCategoryDto>>(animals);
    }

    public Task<List<AnimalCategoryDto>> GetCategoriesWithAnimalsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<AnimalCategoryDto> GetCategoryByIdAsync(int id)
    {
        var animalcategory = await _unitOfWork.AnimalInterface.GetByIdAsync(id);
        return _mapper.Map<AnimalCategoryDto>(animalcategory);
    }

    public Task<PagedList<AnimalCategoryDto>> GetPagedCategories(int pageSize, int pageNumber)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AnimalCategory>> SearchCategoriesAsync(string searchTerm)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateCategoryAsync(AnimalCategoryDto categoryDto)
    {
        var animal = _mapper.Map<Animal>(categoryDto);
        _unitOfWork.AnimalInterface.Update(animal);
        await _unitOfWork.SaveAsync();
    }
}
