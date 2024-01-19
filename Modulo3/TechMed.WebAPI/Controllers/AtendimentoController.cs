using Microsoft.AspNetCore.Mvc;
using TechMed.WebAPI.Infra.Data.Interfaces;
using TechMed.WebAPI.Model;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class AtendimentoController : ControllerBase
{
    private readonly IAtendimentoCollection _atendimentos;
    public List<Atendimento> Atendimentos => _atendimentos.GetAll().ToList();
    public AtendimentoController(IDatabaseFake dbFake) => _atendimentos = dbFake.AtendimentoCollection;
    [HttpGet("atendimentos")]
    public IActionResult Get()
    {
        return Ok(Atendimentos);
    }

    [HttpGet("atendimento/{id}")]
    public IActionResult GetById(int id)
    {
        var atendimento = _atendimentos.GetById(id);
        return Ok(atendimento);
    }

    [HttpPost("atendimento")]
    public IActionResult Post([FromBody] Atendimento atendimento)
    {
        
        _atendimentos.Create(atendimento);
        return CreatedAtAction(nameof(Get), atendimento);
    }

    [HttpPut("atendimento/{id}")]
    public IActionResult Put(int id, [FromBody] Atendimento atendimento)
    {
        if (_atendimentos.GetById(id) == null)
            return NoContent();
        _atendimentos.Update(id, atendimento);
        return Ok(_atendimentos.GetById(id));
    }

    [HttpDelete("atendimento/{id}")]
    public IActionResult Delete(int id)
    {
        if (_atendimentos.GetById(id) == null)
            return NoContent();
        _atendimentos.Delete(id);
        return Ok();
    }
    

}
