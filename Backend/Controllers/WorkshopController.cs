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
    public class WorkshopController : ControllerBase
    {
        public static List<WorkshopModel> workshops = new List<WorkshopModel>();
        

        [HttpGet]
        public ActionResult<IEnumerable<WorkshopController>> Get()
        {
            return Ok(workshops);
        } 

        [HttpGet("{id}")]
        public ActionResult<WorkshopModel> GetById(int id)
        {
            var workshop = workshops.Find(w => w.Id == id);
            if (workshop == null)
                return NotFound();

            return Ok(workshop);

        }

        [HttpPost]
        public ActionResult<WorkshopModel> Post(WorkshopModel workshop)
        {
            workshops.Add(workshop);
            return CreatedAtAction(nameof(GetById), new {id = workshop.Id}, workshop);
        }
        
        [HttpPut("{id}")]
        public ActionResult Put(int id, WorkshopModel workshop)
        {
            var existingWorkshop = workshops.Find(w => w.Id == id);
            if (existingWorkshop == null)
                return NotFound();

            existingWorkshop.Nome = workshop.Nome;
            existingWorkshop.DataRealizacao = workshop.DataRealizacao;
            existingWorkshop.Descricao = workshop.Descricao;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var workshop = workshops.Find(w => w.Id == id);
            if (workshop == null)
                return NotFound();

            workshops.Remove(workshop);

            return NoContent();
        }

        [HttpPost("{workshopId}/presenca/{colaboradorId}")]
        public ActionResult MarcarPresenca(int workshopId, int colaboradorId)
        {
            var workshop = workshops.FirstOrDefault(w => w.Id == workshopId);
            if (workshop == null)
                return NotFound("Workshop não encontrado.");

            var colaborador = ColaboradorController.colaboradores.FirstOrDefault(c => c.Id == colaboradorId);
            if (colaborador == null)
                return NotFound("Colaborador não encontrado");
            
            if (workshop.Presencas.Any(p => p.ColaboradorId == colaboradorId))
                return BadRequest("Presença já registrada");

            workshop.Presencas.Add(new PresencaModel {WorkshopId = workshopId, ColaboradorId = colaboradorId, Presente = true});
            return Ok("Presença registrada com sucesso.");
           
        }

        [HttpGet("{workshopId}/presencas")]
        public ActionResult<IEnumerable<PresencaModel>> ObterPresencas(int workshopId)
        {
            var workshop = workshops.FirstOrDefault(w => w.Id == workshopId);
            if (workshop == null)
                return NotFound("Workshop não encontrado.");
            
            return Ok(workshop.Presencas);
        }
    }
}