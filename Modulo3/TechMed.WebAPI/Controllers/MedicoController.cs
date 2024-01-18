using Microsoft.AspNetCore.Mvc;
using TechMed.WebAPI.Model;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class MedicoController : ControllerBase
{
   private readonly ICollection<Medico> _medicos;
   private int _id = 1;

   public MedicoController(MedicoCollection medicoCollection)
   {
      _medicos = medicoCollection.Medicos;
      
   }

   [HttpGet("medicos")]
   public IActionResult Get()
   {
      return Ok(_medicos);
   }

   [HttpGet("medico/{id}")]
   public IActionResult GetById(int id)
   {
      var medico = _medicos.FirstOrDefault(m => m.MedicoId == id);
      return Ok(medico);
   }

   [HttpPost("medico")]
   public IActionResult Post([FromBody] Medico medico)
   {
      medico.MedicoId = _id++;
      _medicos.Add(medico);
      return Ok();
   }

   [HttpPut("medico/{id}")]
   public IActionResult Put(int id, [FromBody] Medico medico)
   {
      var medicoToUpdate = _medicos.FirstOrDefault(m => m.MedicoId == id);
      if (medicoToUpdate == null)
      {
         return NotFound();
      }
      medicoToUpdate.Nome = medico.Nome;
      return Ok(medicoToUpdate);
   }

   [HttpDelete("medico/{id}")]
   public IActionResult Delete(int id)
   {
      var medicoToDelete = _medicos.FirstOrDefault(m => m.MedicoId == id);
      if (medicoToDelete == null)
      {
         return NotFound();
      }
      return Ok(_medicos.Remove(medicoToDelete));
   }

   [HttpGet("medico/{id}/atendimentos")]
   public IActionResult GetAtendimentos(int id)
   {
      var atendimento = Enumerable.Range(1, 5).Select(index => new Atendimento
         {
            AtendimentoId = index,
            DataHora = DateTime.Now,
            MedicoId = id,
            Medico = new Medico
            {
               MedicoId = id,
               Nome = $"Medico {id}"
            }
         })
         .ToArray();
      return Ok(atendimento);
   }
}
