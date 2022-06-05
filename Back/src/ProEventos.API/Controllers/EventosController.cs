using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.Application;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        //private readonly ILogger<EventosController> _logger;

        // public IEnumerable<Evento> _evento = new Evento[] {
        //     new Evento(){
        //         EventoId = 1,
        //         Tema = "Angual 11",
        //         Local = "Belo Horizonte",
        //         Lote = "1 Lote",
        //         QtdPessoas = 250,
        //         DateEvento = DateTime.Now.AddDays(2).ToString(),
        //         ImagemURL = "foto.png"
        //     },
        //     new Evento(){
        //         EventoId = 2,
        //         Tema = "Angual 13",
        //         Local = "Salavador",
        //         Lote = "2 Lote",
        //         QtdPessoas = 158,
        //         DateEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
        //         ImagemURL = "cat.png"
        //     }
        // };
        private readonly IEventoService _eventoService;

        public EventosController(IEventoService eventoService)
        {
            this._eventoService = eventoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var eventos = await _eventoService.GetAllEventosAsync(true);
                if (eventos == null) return NotFound("Nenhum evento encontrado");

                return Ok(eventos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentnar recuperar eventos. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            //return _evento.Where(x => x.EventoId == id);
            //return context.Eventos.FirstOrDefault(x => x.Id == id);
            try
            {
                var evento = await _eventoService.GetEventosByIdAsync(id, true);
                if (evento == null) return NotFound("Evento por Id não encontrado");

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentnar recuperar eventos. Erro: {ex.Message}");
            }
        }

        [HttpGet("{tema}/tema")]
        public async Task<IActionResult> GetByTema(string tema)
        {
            //return _evento.Where(x => x.EventoId == id);
            //return context.Eventos.FirstOrDefault(x => x.Id == id);
            try
            {
                var evento = await _eventoService.GetAllEventosByTemaAsync(tema, true);
                if (evento == null) return NotFound("Eventos por terma não contrados");

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentnar recuperar eventos. Erro: {ex.Message}");
            }

        }

        [HttpPost]
        public async Task<ActionResult> Post(Evento model)
        {
            try
            {
                var evento = await _eventoService.addEventos(model);
                if (evento == null) return BadRequest("Erro ao tentar adicionar evento.");

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentnar incluir eventos. Erro: {ex.Message}");
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Evento model)
        {
            try
            {
                var evento = await _eventoService.UpdateEventos(id, model);
                if (evento == null) return BadRequest("Erro ao tentar adicionar evento.");

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentnar alterar eventos. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (await _eventoService.DeleteEventos(id))
                    return Ok("Registro excluído com sucesso");
                else
                    return BadRequest("Registro não escluído");               
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                    $"Erro ao tentnar excluír eventos. Erro: {ex.Message}");
            }
        }
    }
}
