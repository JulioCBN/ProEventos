using System;
using System.Collections.Generic;

#nullable disable

namespace ProEventos.API
{
    public partial class TipoRegistroBovespaResumo
    {
        public long TipoRegistroBovespaResumoId { get; set; }
        public long TipoRegistroCabecalhoId { get; set; }
        public int? TipoRegistro { get; set; }
        public string CodigoCliente { get; set; }
        public string CodigoCorretora { get; set; }
        public string CodigoClienteCorretora { get; set; }
        public string NumeroNota { get; set; }
        public DateTime? DataPregao { get; set; }
        public decimal? ValorTotalOperacao { get; set; }
        public decimal? ValorLiquidoNota { get; set; }
        public decimal? Debentures { get; set; }
        public decimal? VendaVista { get; set; }
        public decimal? CompraVista { get; set; }
        public decimal? OpcaoCompra { get; set; }
        public decimal? OpcaoVenda { get; set; }
        public decimal? OperacaoTermo { get; set; }
        public decimal? ValorOperacaoTituloPublico { get; set; }
        public decimal? CompraFuturo { get; set; }
        public decimal? VendaFuturo { get; set; }
        public decimal? TaxaLiquidacao { get; set; }
        public decimal? TaxaRegistro { get; set; }
        public decimal? TaxaEmolumentos { get; set; }
        public decimal? TaxaCorretagem { get; set; }
        public decimal? Iss { get; set; }
        public decimal? Irrf { get; set; }
        public decimal? TaxaAna { get; set; }
        public decimal? TaxaTermo { get; set; }
        public decimal? ValorDaytrade { get; set; }
        public decimal? ValorProjecao { get; set; }
        public decimal? ValorIrrfBase { get; set; }
        public char? TipoPessoa { get; set; }
        public decimal? ValorLiquidoOperacao { get; set; }
        public decimal? ValorCorretagemExecucao { get; set; }
        public decimal? ValorCorretagemExecucaoCasa { get; set; }

        public virtual TipoRegistroCabecalho TipoRegistroCabecalho { get; set; }
    }
}
