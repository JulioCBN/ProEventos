using System;
using System.Collections.Generic;

#nullable disable

namespace ProEventos.API
{
    public partial class TipoRegistroExtrato
    {
        public long TipoRegistroExtratoId { get; set; }
        public long TipoRegistroCabecalhoId { get; set; }
        public int? TipoRegistro { get; set; }
        public string CodigoCliente { get; set; }
        public string CodigoCorretora { get; set; }
        public string CodigoClienteCorretora { get; set; }
        public DateTime? DataReferencia { get; set; }
        public string DescricaoLancamento { get; set; }
        public DateTime? DataLancamento { get; set; }
        public decimal? Valor { get; set; }
        public string CodigoHistorico { get; set; }
        public char? TipoPessoa { get; set; }

        public virtual TipoRegistroCabecalho TipoRegistroCabecalho { get; set; }
    }
}
