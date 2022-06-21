using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Application.Dtos;
using ProEventos.Application.Contratos;
using System;
using System.Threading.Tasks;
using ProEventos.Domain;

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
        public async Task<IActionResult> Get(string tudo)
        {
            try
            {

                if (tudo == "1")
                {
                    var eventos = await _eventoService.GetAllEventosAsync(true);
                    if (eventos == null) return NoContent(); // return NotFound("Nenhum evento encontrado");
                    return Ok(eventos);
                }
                else
                {
                    var eventos = await _eventoService.GetAllEventosAsync2(true);
                    if (eventos == null) return NotFound("Nenhum evento encontrado");
                    return Ok(eventos);
                }

                //var eventoRetorno = new List<EventoDto>();

                //foreach (var evento in eventos)
                //{
                //    eventoRetorno.Add(new EventoDto() {
                //        Id = evento.Id,
                //        Local = evento.Local,
                //        DateEvento = evento.DateEvento.ToString(),
                //        Tema = evento.Tema,
                //        QtdPessoas = evento.QtdPessoas,
                //        ImagemURL = evento.ImagemURL,
                //        Telefone = evento.Telefone,
                //        Email = evento.Email
                //    });
                //}
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
                if (evento == null) return NoContent(); //NotFound("Evento por Id não encontrado");

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
        public async Task<ActionResult> Post(EventoDto model)
        {
            try
            {
                var _evento = await _eventoService.addEventos(model);
                if (_evento == null) return BadRequest("Erro ao tentar adicionar evento.");

                return Ok(new { Ok = true, evento = _evento, message = "Registro criado com sucesso" });
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentnar incluir eventos. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, EventoDto model)
        {
            try
            {
                var _evento = await _eventoService.UpdateEvento(id, model);
                if (_evento == null) return NoContent();  //return BadRequest("Erro ao tentar adicionar evento.");

                return Ok(new { Ok = true, evento = _evento, message = "Registro alterado com sucesso" });
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
                return (await _eventoService.DeleteEventos(id)) //Ok("Registro excluído com sucesso");
                    ? Ok(new {message = "Registro excluído com sucesso", ok = true}) 
                    : throw new Exception("ocorreu um erro ao tentar deletar o evento");
                    //return BadRequest("Registro não escluído");               
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                    $"Erro ao tentnar excluír eventos. Erro: {ex.Message}");
            }
        }
    }
}
