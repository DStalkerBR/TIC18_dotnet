using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TechMed.WebAPI.Model;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class AtendimentoController : ControllerBase
{
  IOptions <OpeningTime> _openingTime;

  public AtendimentoController(IOptions<OpeningTime> openingTime){
    _openingTime = openingTime;
  }

   [HttpGet("atendimentos")]
   public IActionResult Get()
   {
      if (DateTime.Now.TimeOfDay < _openingTime.Value.StartsAt || DateTime.Now.TimeOfDay > _openingTime.Value.EndsAt)
      {
        return StatusCode(403, "Forbidden");
      }
      var atendimento = Enumerable.Range(1, 5).Select(index => new Atendimento
        {
            AtendimentoId = index,
            DataHora = DateTime.Now,
            MedicoId = index,
            Medico = new Medico
            {
                MedicoId = index,
                Nome = $"Medico {index}"
            }
        })
        .ToArray();
      return Ok(atendimento);
   }



}
