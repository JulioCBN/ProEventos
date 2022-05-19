using System;
using System.Collections.Generic;

#nullable disable

namespace ProEventos.API
{
    public partial class TipoRegistroOpcaoFlexivelResumo
    {
        public long TipoRegistroOpcaoFlexivelResumoId { get; set; }
        public long TipoRegistroCabecalhoId { get; set; }
        public int? TipoRegistro { get; set; }
        public string CodigoCliente { get; set; }
        public string CodigoCorretora { get; set; }
        public string CodigoClienteCorretora { get; set; }
        public string NumeroNota { get; set; }
        public DateTime? DataPregao { get; set; }
        public string DescricaoTipoNota { get; set; }
        public string ContraParte { get; set; }
        public decimal? Irrf { get; set; }
        public decimal? TotalLiquidacao { get; set; }
        public decimal? TaxaOperacional { get; set; }
        public decimal? TaxaRegistroBmf { get; set; }
        public int? TaxaBmf { get; set; }
        public decimal? IrrfDaytrade { get; set; }
        public decimal? OutrosCustos { get; set; }
        public decimal? Iss { get; set; }
        public decimal? TotalNegocio { get; set; }
        public decimal? TotalDespesas { get; set; }
        public decimal? Outros { get; set; }
        public decimal? IrrfCorretagem { get; set; }
        public decimal? TotalContaInvestimento { get; set; }
        public decimal? TotalContaNormal { get; set; }
        public decimal? TotalLiquidoNota { get; set; }

        public virtual TipoRegistroCabecalho TipoRegistroCabecalho { get; set; }
    }
}
