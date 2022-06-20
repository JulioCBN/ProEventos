using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProEventos.Domain
{
    // [Table("Teste")] para nome de tabela difente no banco de dados
    public class Evento
    {
        //[Key] // para campo chave diferente de Id
        public int Id { get; set; }
        public string Local { get; set; }
        public DateTime? DateEvento { get; set; }
        [Required]
        [MaxLength(50)] // Para definir o tamanho na estrutura do banco
        public string Tema { get; set; }
        public int QtdPessoas { get; set; }


        [NotMapped] // Esse campo não será criado no banco de dados
        public int ContagemDias { get; set; }

        public string ImagemURL { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public IEnumerable<Lote> Lotes { get; set; }
        public IEnumerable<RedeSocial> RedeSociais { get; set; }
        public IEnumerable<PalestranteEvento> PalestrantesEventos { get; set; }

    }
}