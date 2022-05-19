using System;
using System.Collections.Generic;

#nullable disable

namespace ProEventos.API
{
    public partial class TipoRegistroCarteira
    {
        public long TipoRegistroCarteiraId { get; set; }
        public long TipoRegistroCabecalhoId { get; set; }
        public int? TipoRegistro { get; set; }
        public string CodigoCliente { get; set; }
        public string CodigoCorretora { get; set; }
        public string CodigoClienteCorretora { get; set; }
        public DateTime? DataCustodia { get; set; }
        public string CodigoNegociacaoPapel { get; set; }
        public string Mercado { get; set; }
        public string CodigoTomadorDoador { get; set; }
        public int? Quantidade { get; set; }
        public char? TipoPessoa { get; set; }

        public virtual TipoRegistroCabecalho TipoRegistroCabecalho { get; set; }
    }
}
