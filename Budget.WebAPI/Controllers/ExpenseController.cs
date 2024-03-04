using Budget.DAL.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Budget.DAL.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Budget.WebAPI.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpenseController : ControllerBase
    {
        private readonly IRepository<Expense> _repository;
        private readonly IMapper _mapper;

        public ExpenseController(
            IRepository<Expense> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var expanse = await _repository.GetAsync(id);
            return Ok(_mapper.Map<ExpenseShowModel>(expanse));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(ExpenseInputModel expanseModel)
        {
            if (ModelState.IsValid)
            {
                
                await _repository.AddAsync(_mapper.Map<Expense>(expanseModel));

                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        //[HttpPut("{id}")]
        [HttpPut]
        public async Task<IActionResult> EditAsync(/*int id,*/ ExpenseInputModel expanseModel)
        {
            if (ModelState.IsValid)
            {
                var expanse = _mapper.Map<Expense>(expanseModel);
                //expanse.ID = id;
                await _repository.UpdateAsync(expanse);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            return Ok();
        }

    }
}
