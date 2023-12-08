using BusinessLogicLayer.Helpers;
using BussinessLogicLayer.Dtos.CategoryDto;
using DataAccsesLayer.Entities;

namespace BussinessLogicLayer.Interfaces;

public interface ICategoryServeice
{
    Task<PagedList<AnimalCategoryDto>> GetPagedCategories(int pageSize, int pageNumber);
    Task<List<AnimalCategoryDto>> GetCategoriesAsync();
    Task<List<AnimalCategoryDto>> GetCategoriesWithAnimalsAsync();
    Task<AnimalCategoryDto> GetCategoryByIdAsync(int id);
    Task<IEnumerable<AnimalCategory>> SearchCategoriesAsync(string searchTerm);
    Task AddCategoryAsync(AddCategoryDto newCategory);
    Task UpdateCategoryAsync(AnimalCategoryDto categoryDto);
    Task DeleteCategoryAsync(int id);
}