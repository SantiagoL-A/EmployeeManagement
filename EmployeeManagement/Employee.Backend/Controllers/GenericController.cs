using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Backend.UnitsOfWorks.Interfaces;

namespace EmployeeManagement.Backend.Controllers;

public class GenericController<T> : Controller where T : class
{
    private readonly IGenericUnitOfWorks<T> _unitOfWork;

    public GenericController(IGenericUnitOfWorks<T> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public virtual async Task<IActionResult> GetActionAsync()
    {
        var action = await _unitOfWork.GetAsync();
        if (action.WasSucces)
        {
            return Ok(action.Result);
        }
        return BadRequest(action.Message);
    }

    [HttpGet("{id}")]
    public virtual async Task<IActionResult> GetAsync(int id)
    {
        var action = await _unitOfWork.GetAsync(id);
        if (action.WasSucces)
        {
            return Ok(action.Result);
        }
        return NotFound();
    }

    [HttpGet("search/{text}")]
    public virtual async Task<IActionResult> SearchAsync(string text)
    {
        var action = await _unitOfWork.SerchAsync(text);
        if (action.WasSucces)
        {
            return Ok(action.Result);
        }
        return BadRequest(action.Message);
    }

    [HttpPost]
    public virtual async Task<IActionResult> PostAsync(T model)
    {
        var action = await _unitOfWork.AddAsync(model);
        if (action.WasSucces)
        {
            return Ok(action.Result);
        }
        return BadRequest(action.Message);
    }

    [HttpPut]
    public virtual async Task<IActionResult> PutAsync(T model)
    {
        var action = await _unitOfWork.UpdateAsync(model);
        if (action.WasSucces)
        {
            return Ok(action.Result);
        }
        return BadRequest(action.Message);
    }

    [HttpDelete("{id}")]
    public virtual async Task<IActionResult> DeleteAsync(int id)
    {
        var action = await _unitOfWork.DeleteAsync(id);
        if (action.WasSucces)
        {
            return NoContent();
        }
        return BadRequest(action.Message);
    }
}