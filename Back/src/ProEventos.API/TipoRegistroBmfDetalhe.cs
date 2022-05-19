using System;
using System.Collections.Generic;

#nullable disable

namespace ProEventos.API
{
    public partial class TipoRegistroBmfDetalhe
    {
        public long TipoRegistroBmfDetalheId { get; set; }
        public long TipoRegistroCabecalhoId { get; set; }
        public int? TipoRegistro { get; set; }
        public string CodigoCliente { get; set; }
        public string CodigoCorretora { get; set; }
        public string CodigoClienteCorretora { get; set; }
        public string NumeroNota { get; set; }
        public DateTime? DataPregao { get; set; }
        public bool? Compra { get; set; }
        public string Mercadoria { get; set; }
        public DateTime? Vencimento { get; set; }
        public int? Quantidade { get; set; }
        public decimal? PrecoAjuste { get; set; }
        public string TipoNegocio { get; set; }
        public decimal? ValorOperacao { get; set; }
        public char? TipoOperacao { get; set; }
        public decimal? TaxaOperacional { get; set; }
        public char? TipoPessoa { get; set; }
        public long TipoRegistroCabecalhostipoRegistroCabecalhoId { get; set; }
        public long TipoRegistroBmfResumoId { get; set; }
        public decimal? VendaDisponivel { get; set; }
        public decimal? CompraDisponivel { get; set; }
        public decimal? VendaOpcoes { get; set; }
        public decimal? CompraOpcoes { get; set; }
        public decimal? ValorNegocios { get; set; }
        public decimal? Irrf { get; set; }
        public decimal? IrrfDaytradeProjecao { get; set; }
        public decimal? TaxaRegistroBmf { get; set; }
        public decimal? TaxaBmf { get; set; }
        public decimal? OutrosCustos { get; set; }
        public decimal? Iss { get; set; }
        public decimal? AjustePosicao { get; set; }
        public decimal? AjusteDaytrade { get; set; }
        public decimal? TotalDespesas { get; set; }
        public decimal? Outros { get; set; }
        public decimal? IrrfCorretagem { get; set; }
        public decimal? TotalContaInvestimento { get; set; }
        public decimal? TotalContaNormal { get; set; }
        public decimal? TotalLiquido { get; set; }

        public virtual TipoRegistroCabecalho TipoRegistroCabecalho { get; set; }
    }
}
