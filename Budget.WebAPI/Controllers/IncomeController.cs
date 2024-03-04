using AutoMapper;
using Budget.DAL.Abstractions;
using Budget.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Budget.WebAPI.DTO.Income;

namespace WebAPI.Controllers;

[Route("api/v1/[controller]")]
public class IncomeController : Controller
{
    private IRepository<Income> _repository;
    private IMapper _mapper;

    public IncomeController(IRepository<Income> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddCategory(IncomeInputModel input)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        else
        {
            var newIncome = _mapper.Map<Income>(input);
            var result = _repository.AddAsync(newIncome);
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
            var result = _mapper.Map<List<IncomeShowModel>>(_repository.GetAllAsync());
            return Ok(result);
        }
    }

    [HttpGet]
    [Route("{id:int}")]
    public IActionResult GetCategory(int categoryId)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        else
        {
            var result = _mapper.Map<IncomeShowModel>(_repository.GetAsync(categoryId));
            return Ok(result);
        }
    }

    [HttpPut]
    public IActionResult UpdateCategory(IncomeUpdateModel input)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        else
        {
            var newIncome = _mapper.Map<Income>(input);
            var result = _repository.UpdateAsync(newIncome);
            return Ok(result);
        }
    }

    [HttpDelete]
    public IActionResult DeleteCategory(int categoryId)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        else
        {
            var result = _repository.DeleteAsync(categoryId);
            return Ok(result);
        }
    }
}
