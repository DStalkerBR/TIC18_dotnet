using Microsoft.AspNetCore.Mvc;
using TechMed.Core.Entities;
using TechMed.Infrastructure.Persistence.Interfaces;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class ExameController : ControllerBase
{
    private readonly IExameCollection _exames;
    public List<Exame> Exames => _exames.GetAll().ToList();
    public ExameController(ITechMedContext context) => _exames = context.ExameCollection;

    [HttpGet("exames")]
    public IActionResult Get()
    {
        return Ok(Exames);
    }

    [HttpGet("exame/{id}")]
    public IActionResult GetById(int id)
    {
        var exame = _exames.GetById(id);
        return Ok(exame);
    }

    [HttpPost("exame")]
    public IActionResult Post([FromBody] Exame exame)
    {
        _exames.Create(exame);
        return CreatedAtAction(nameof(Get), exame);
    }

    [HttpPut("exame/{id}")]
    public IActionResult Put(int id, [FromBody] Exame exame)
    {
        if (_exames.GetById(id) == null)
            return NoContent();
        _exames.Update(id, exame);
        return Ok(_exames.GetById(id));
    }

    [HttpDelete("exame/{id}")]
    public IActionResult Delete(int id)
    {
        if (_exames.GetById(id) == null)
            return NoContent();
        _exames.Delete(id);
        return Ok();
    }

}
