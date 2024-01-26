using Microsoft.AspNetCore.Mvc;
using TechMed.Application.InputModels;
using TechMed.Application.Services.Interfaces;
using TechMed.Application.ViewModels;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class ExameController : ControllerBase
{
    private readonly IExameService _exameService;
    public List<ExameViewModel> Exames => _exameService.GetAll().ToList();
    public ExameController(IExameService service) => _exameService = service;

    [HttpGet("exames")]
    public IActionResult Get()
    {
        return Ok(Exames);
    }

    [HttpGet("exame/{id}")]
    public IActionResult GetById(int id)
    {
        var exame = _exameService.GetById(id);
        return Ok(exame);
    }

    [HttpPost("exame")]
    public IActionResult Post([FromBody] NewExameInputModel exame)
    {
        _exameService.Create(exame);
        return CreatedAtAction(nameof(Get), exame);
    }

/*     [HttpPut("exame/{id}")]
    public IActionResult Put(int id, [FromBody] Exame exame)
    {
        if (_exameService.GetById(id) == null)
            return NoContent();
        _exameService.Update(id, exame);
        return Ok(_exameService.GetById(id));
    } 

    [HttpDelete("exame/{id}")]
    public IActionResult Delete(int id)
    {
        if (_exameService.GetById(id) == null)
            return NoContent();
        _exameService.Delete(id);
        return Ok();
    }
    */

}
