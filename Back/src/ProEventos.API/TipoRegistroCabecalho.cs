using System;
using System.Collections.Generic;

#nullable disable

namespace ProEventos.API
{
    public partial class TipoRegistroCabecalho
    {
        public TipoRegistroCabecalho()
        {
            TipoRegistroBmfDetalhes = new HashSet<TipoRegistroBmfDetalhe>();
            TipoRegistroBmfResumos = new HashSet<TipoRegistroBmfResumo>();
            TipoRegistroBovespaDetalhes = new HashSet<TipoRegistroBovespaDetalhe>();
            TipoRegistroBovespaResumos = new HashSet<TipoRegistroBovespaResumo>();
            TipoRegistroCarteiras = new HashSet<TipoRegistroCarteira>();
            TipoRegistroExtratos = new HashSet<TipoRegistroExtrato>();
            TipoRegistroOpcaoFlexivelDetalhes = new HashSet<TipoRegistroOpcaoFlexivelDetalhe>();
            TipoRegistroOpcaoFlexivelResumos = new HashSet<TipoRegistroOpcaoFlexivelResumo>();
            TipoRegistroProventos = new HashSet<TipoRegistroProvento>();
        }

        public long TipoRegistroCabecalhoId { get; set; }
        public string CodigoCorretora { get; set; }
        public DateTime? DataGeracao { get; set; }
        public int? QuantidadeCliente { get; set; }
        public bool? Processado { get; set; }
        public DateTime? DataProcessamento { get; set; }
        public DateTime? DataCadastro { get; set; }

        public virtual ICollection<TipoRegistroBmfDetalhe> TipoRegistroBmfDetalhes { get; set; }
        public virtual ICollection<TipoRegistroBmfResumo> TipoRegistroBmfResumos { get; set; }
        public virtual ICollection<TipoRegistroBovespaDetalhe> TipoRegistroBovespaDetalhes { get; set; }
        public virtual ICollection<TipoRegistroBovespaResumo> TipoRegistroBovespaResumos { get; set; }
        public virtual ICollection<TipoRegistroCarteira> TipoRegistroCarteiras { get; set; }
        public virtual ICollection<TipoRegistroExtrato> TipoRegistroExtratos { get; set; }
        public virtual ICollection<TipoRegistroOpcaoFlexivelDetalhe> TipoRegistroOpcaoFlexivelDetalhes { get; set; }
        public virtual ICollection<TipoRegistroOpcaoFlexivelResumo> TipoRegistroOpcaoFlexivelResumos { get; set; }
        public virtual ICollection<TipoRegistroProvento> TipoRegistroProventos { get; set; }
    }
}
