using System;
using System.Collections.Generic;

#nullable disable

namespace ProEventos.API
{
    public partial class TipoRegistroOpcaoFlexivelDetalhe
    {
        public long TipoRegistroOpcaoFlexivelDetalheId { get; set; }
        public long TipoRegistroCabecalhoId { get; set; }
        public int? TipoRegistro { get; set; }
        public string CodigoCliente { get; set; }
        public string CodigoCorretora { get; set; }
        public string CodigoClienteCorretora { get; set; }
        public string NumeroNota { get; set; }
        public DateTime? DataPregao { get; set; }
        public string Mercadoria { get; set; }
        public char? Garantia { get; set; }
        public char? NaturezaOperacaoCompraVenda { get; set; }
        public string Contrato { get; set; }
        public string TipoNegocio { get; set; }
        public DateTime? Vencimento { get; set; }
        public int? Quantidade { get; set; }
        public string Cotacao { get; set; }
        public char? AmericanaEuropeia { get; set; }
        public decimal? TaxaRegistro { get; set; }
        public decimal? TaxaEmolumento { get; set; }
        public decimal? ValorNegocio { get; set; }
        public decimal? ValorLiquidacao { get; set; }
        public decimal? DataPagamentoPremio { get; set; }
        public decimal? PrecoExercicio { get; set; }
        public decimal? PrecoBarreira { get; set; }
        public decimal? Corretagem { get; set; }
        public decimal? KnockInAndDown { get; set; }
        public decimal? KnockOutAndDown { get; set; }
        public decimal? KnockInAndUp { get; set; }

        public virtual TipoRegistroCabecalho TipoRegistroCabecalho { get; set; }
    }
}
