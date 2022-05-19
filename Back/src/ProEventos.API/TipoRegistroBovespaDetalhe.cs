using System;
using System.Collections.Generic;

#nullable disable

namespace ProEventos.API
{
    public partial class TipoRegistroBovespaDetalhe
    {
        public long TipoRegistroBovespaDetalheId { get; set; }
        public long TipoRegistroCabecalhoId { get; set; }
        public int? TipoRegistro { get; set; }
        public string CodigoCliente { get; set; }
        public string CodigoCorretora { get; set; }
        public string CodigoClienteCorretora { get; set; }
        public string NumeroNota { get; set; }
        public DateTime? DataPregao { get; set; }
        public bool? Compra { get; set; }
        public string Mercado { get; set; }
        public string CodigoNegociacaoPapel { get; set; }
        public string EspecificacaoPapel { get; set; }
        public string EspecificacaoPapelObjeto { get; set; }
        public string Prazo { get; set; }
        public int? Quantidade { get; set; }
        public decimal? Preco { get; set; }
        public decimal? ValorOperacao { get; set; }
        public string Observacao { get; set; }
        public char? TipoPessoa { get; set; }

        public virtual TipoRegistroCabecalho TipoRegistroCabecalho { get; set; }
    }
}
