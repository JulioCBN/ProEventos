using System;
using System.Collections.Generic;

#nullable disable

namespace ProEventos.API
{
    public partial class TipoRegistroProvento
    {
        public long TipoRegistroProventosId { get; set; }
        public long TipoRegistroCabecalhoId { get; set; }
        public int? TipoRegistro { get; set; }
        public string CodigoCliente { get; set; }
        public string CodigoCorretora { get; set; }
        public string CodigoClienteCorretora { get; set; }
        public string CodigoIsin { get; set; }
        public int? NumeroDistribuicao { get; set; }
        public string CodigoNegociacaoPapel { get; set; }
        public string NomeEmpresa { get; set; }
        public string CodigoCarteira { get; set; }
        public string DescricaoTipoProvento { get; set; }
        public int? QuantidadeAtivos { get; set; }
        public decimal? ValorBruto { get; set; }
        public decimal? ValorLiquido { get; set; }
        public decimal? ValorIr { get; set; }
        public DateTime? DataLiquidacao { get; set; }

        public virtual TipoRegistroCabecalho TipoRegistroCabecalho { get; set; }
    }
}
