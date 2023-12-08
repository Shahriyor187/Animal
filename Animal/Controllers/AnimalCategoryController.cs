using Animals.Dtos;
using AutoMapper;
using BusnisLogicLayer.Helpers;
using BusnisLogicLayer.Services;
using BussinessLogicLayer.Dtos.CategoryDto;
using BussinessLogicLayer.Interfaces;
using DataAccsesLayer;
using DataAccsesLayer.Entities;
using DataAccsesLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AnimalAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnimalCategoryController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ICategoryServeice _animalcategoryService;
    private readonly IMapper _mapper;
    private readonly AnimalCategory category1 = new AnimalCategory();
    public AnimalCategoryController(ICategoryServeice animalcategoryService, IMapper mapper, ApplicationDbContext dbContext)
    {
        _animalcategoryService = animalcategoryService;
        _mapper = mapper;
        _dbContext = dbContext;
    }

    [HttpGet("GetAllAnimalCategories")]
    public async Task<IActionResult> GetAllAnimalCategories()
    {
        var categories = await _animalcategoryService.GetCategoriesAsync();
        return Ok(categories);
    }

    [HttpGet("GetAnimalCategoryById")]
    public async Task<IActionResult> GetAnimalCategoryById(int id)
    {
        var category = await _animalcategoryService.GetCategoryByIdAsync(id);
        if (category == null)
        {
            return NotFound();
        }

        return Ok(category);
    }

    [HttpPost("AddAnimalCategory")]
    public async Task<IActionResult> AddACategoryAsync(AddCategoryDto newcategory)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await _animalcategoryService.AddCategoryAsync(newcategory);
        return Ok("Animal category added successfully");
    }
    [HttpGet("SearchAnimalCategories")]
    public async Task<IActionResult> SearchAnimalCategories(string searchTerm)
    {
        try
        {
            var categories = await _dbContext.AnimalCategories
                .Where(c => c.Name.Contains(searchTerm)) 
                .ToListAsync();

            return Ok(categories);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal Server Error");
        }
    }
    [HttpPut("UpdateAnimalCategory")]

    public async Task<IActionResult> UpdateAnimalCategory(CategoryUpdateDto categorydto)
    {
        try
        {
            var categoryToUpdate = await _dbContext.AnimalCategories
                .FirstOrDefaultAsync(c => c.Id == category1.Id);

            if (categoryToUpdate == null)
            {
                return NotFound();
            }
            categoryToUpdate.Name = category1.Name;

            _dbContext.Entry(categoryToUpdate).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return Ok(categoryToUpdate);
        }
        catch (DbUpdateException ex)
        {
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpDelete("DeleteAnimalCategory")]
    public async Task<IActionResult> DeleteAnimalCategory(int id)
    {
        await _animalcategoryService.DeleteCategoryAsync(id);
        return Ok("Animal category deleted successfully");
    }
}