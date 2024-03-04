using AutoMapper;
using Budget.DAL.Abstractions;
using Budget.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Budget.WebAPI.DTO.Category;

namespace Budget.WebAPI.Controllers;

[Route("api/v1/[controller]")]
public class CategoryController : Controller
{
    private IRepository<Category> _repository;
    private IMapper _mapper;

    public CategoryController(IRepository<Category> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddCategory(CategoryInputModel input)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        else
        {
            var newCategory = _mapper.Map<Category>(input);
            var result = _repository.AddAsync(newCategory);
            return Ok(result);
        }
    }

    [HttpGet]
    public IActionResult GetCategories()
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        else
        {
            var result = _mapper.Map<List<CategoryShowModel>>(_repository.GetAllAsync());
            return Ok(result);
        }
    }
}
