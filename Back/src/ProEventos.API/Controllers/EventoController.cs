using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Data;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly ILogger<EventoController> _logger;

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
        private readonly DataContext context;
        public EventoController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return context.Eventos;
        }



        [HttpGet("{id}")]
        public Evento Get(int id)
        {
            //return _evento.Where(x => x.EventoId == id);
            return context.Eventos.FirstOrDefault(x => x.EventoId == id);
        }

        [HttpPost]
        public string Post()
        {
            return "Evento de Post";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Evento de Put com id {id}";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"Evento de DELETE com id {id}";
        }


    }
}
