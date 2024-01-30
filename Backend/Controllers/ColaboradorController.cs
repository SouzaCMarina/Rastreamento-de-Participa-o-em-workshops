using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Fast___Fullstack.Models;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_Fast___Fullstack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColaboradorController : ControllerBase
    {
      public static List<ColaboradorModel> colaboradores = new List<ColaboradorModel>();

      [HttpGet]
      public ActionResult<IEnumerable<ColaboradorModel>> Get()
      {
        return Ok(colaboradores);
      }

      [HttpGet("{id}")]
      public ActionResult<ColaboradorModel> GetById(int id)
      {
        var colaborador = colaboradores.Find(c => c.Id == id);
        if (colaborador == null)
            return NotFound();

        return Ok(colaborador);
      }

      [HttpPost]
      public ActionResult<ColaboradorModel> Post(ColaboradorModel colaborador)
      {
        colaboradores.Add(colaborador);
        return CreatedAtAction(nameof(GetById), new {id = colaborador.Id}, colaborador);
      }

      [HttpPut("{id}")]
      public ActionResult Put(int id, ColaboradorModel colaborador)
      {
        var existingColaborador = colaboradores.Find(c => c.Id == id);
        if (existingColaborador == null)
          return NotFound();

        existingColaborador.Nome = colaborador.Nome;

        return NoContent();
      }

      [HttpDelete("{id}")]
      public ActionResult Delete(int id)
      {
        var colaborador = colaboradores.Find(c => c.Id == id);
        if (colaborador == null)
          return NotFound();

        colaboradores.Remove(colaborador);

        return NoContent();
      }

      [HttpGet("{colaboradorId}/workshops")]
      public ActionResult<IEnumerable<WorkshopModel>> ObterWorkshopColaborador(int colaboradorId)
      {
        var colaborador = colaboradores.FirstOrDefault(c => c.Id == colaboradorId);
        if (colaborador == null)
            return NotFound("Colaborador não encontrado.");

        var workshopsDoColaborador = WorkshopController.workshops
            .Where(w => w.Presencas.Any(p => p.ColaboradorId == colaboradorId))
            .ToList();

        return Ok(workshopsDoColaborador);
      }
        
    }
}