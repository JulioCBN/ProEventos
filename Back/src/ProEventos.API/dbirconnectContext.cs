using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ProEventos.API
{
    public partial class dbirconnectContext : DbContext
    {
        public dbirconnectContext()
        {
        }

        public dbirconnectContext(DbContextOptions<dbirconnectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TipoRegistroBmfDetalhe> TipoRegistroBmfDetalhes { get; set; }
        public virtual DbSet<TipoRegistroBmfResumo> TipoRegistroBmfResumos { get; set; }
        public virtual DbSet<TipoRegistroBovespaDetalhe> TipoRegistroBovespaDetalhes { get; set; }
        public virtual DbSet<TipoRegistroBovespaResumo> TipoRegistroBovespaResumos { get; set; }
        public virtual DbSet<TipoRegistroCabecalho> TipoRegistroCabecalhos { get; set; }
        public virtual DbSet<TipoRegistroCarteira> TipoRegistroCarteiras { get; set; }
        public virtual DbSet<TipoRegistroExtrato> TipoRegistroExtratos { get; set; }
        public virtual DbSet<TipoRegistroOpcaoFlexivelDetalhe> TipoRegistroOpcaoFlexivelDetalhes { get; set; }
        public virtual DbSet<TipoRegistroOpcaoFlexivelResumo> TipoRegistroOpcaoFlexivelResumos { get; set; }
        public virtual DbSet<TipoRegistroProvento> TipoRegistroProventos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=192.168.1.128;Port=5432;User Id=postgres;Password=irtrade00;Database=dbirconnect");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "pt_BR.UTF-8");

            modelBuilder.Entity<TipoRegistroBmfDetalhe>(entity =>
            {
                entity.HasKey(e => new { e.TipoRegistroBmfDetalheId, e.TipoRegistroBmfResumoId })
                    .HasName("tipo_registro_bmf_detalhes_pkey");

                entity.ToTable("tipo_registro_bmf_detalhes");

                entity.HasIndex(e => e.CodigoCliente, "tipo_registro_bmf_detalhes_codigo_cliente");

                entity.HasIndex(e => e.CodigoClienteCorretora, "tipo_registro_bmf_detalhes_codigo_cliente_corretora");

                entity.HasIndex(e => e.CodigoCorretora, "tipo_registro_bmf_detalhes_codigo_corretora");

                entity.HasIndex(e => e.TipoRegistroBmfDetalheId, "tipo_registro_bmf_detalhes_tipo_registro_bmf_detalhe_id")
                    .IsUnique();

                entity.HasIndex(e => e.TipoRegistroBmfResumoId, "tipo_registro_bmf_detalhes_tipo_registro_bmf_resumo_id")
                    .IsUnique();

                entity.HasIndex(e => e.TipoRegistroCabecalhoId, "tipo_registro_bmf_detalhes_tipo_registro_cabecalho_id");

                entity.Property(e => e.TipoRegistroBmfDetalheId).HasColumnName("tipo_registro_bmf_detalhe_id");

                entity.Property(e => e.TipoRegistroBmfResumoId).HasColumnName("tipo_registro_bmf_resumo_id");

                entity.Property(e => e.AjusteDaytrade)
                    .HasPrecision(18, 2)
                    .HasColumnName("ajuste_daytrade");

                entity.Property(e => e.AjustePosicao)
                    .HasPrecision(18, 2)
                    .HasColumnName("ajuste_posicao");

                entity.Property(e => e.CodigoCliente)
                    .HasMaxLength(14)
                    .HasColumnName("codigo_cliente");

                entity.Property(e => e.CodigoClienteCorretora)
                    .HasMaxLength(15)
                    .HasColumnName("codigo_cliente_corretora");

                entity.Property(e => e.CodigoCorretora)
                    .HasMaxLength(5)
                    .HasColumnName("codigo_corretora");

                entity.Property(e => e.Compra).HasColumnName("compra");

                entity.Property(e => e.CompraDisponivel)
                    .HasPrecision(18, 2)
                    .HasColumnName("compra_disponivel");

                entity.Property(e => e.CompraOpcoes)
                    .HasPrecision(18, 2)
                    .HasColumnName("compra_opcoes");

                entity.Property(e => e.DataPregao).HasColumnName("data_pregao");

                entity.Property(e => e.Irrf)
                    .HasPrecision(18, 2)
                    .HasColumnName("irrf");

                entity.Property(e => e.IrrfCorretagem)
                    .HasPrecision(18, 2)
                    .HasColumnName("irrf_corretagem");

                entity.Property(e => e.IrrfDaytradeProjecao)
                    .HasPrecision(18, 2)
                    .HasColumnName("irrf_daytrade_projecao");

                entity.Property(e => e.Iss)
                    .HasPrecision(18, 2)
                    .HasColumnName("iss");

                entity.Property(e => e.Mercadoria)
                    .HasMaxLength(50)
                    .HasColumnName("mercadoria");

                entity.Property(e => e.NumeroNota)
                    .HasMaxLength(50)
                    .HasColumnName("numero_nota");

                entity.Property(e => e.Outros)
                    .HasPrecision(18, 2)
                    .HasColumnName("outros");

                entity.Property(e => e.OutrosCustos)
                    .HasPrecision(18, 2)
                    .HasColumnName("outros_custos");

                entity.Property(e => e.PrecoAjuste)
                    .HasPrecision(18, 2)
                    .HasColumnName("preco_ajuste");

                entity.Property(e => e.Quantidade).HasColumnName("quantidade");

                entity.Property(e => e.TaxaBmf)
                    .HasPrecision(18, 2)
                    .HasColumnName("taxa_bmf");

                entity.Property(e => e.TaxaOperacional)
                    .HasPrecision(18, 2)
                    .HasColumnName("taxa_operacional");

                entity.Property(e => e.TaxaRegistroBmf)
                    .HasPrecision(18, 2)
                    .HasColumnName("taxa_registro_bmf");

                entity.Property(e => e.TipoNegocio)
                    .HasMaxLength(15)
                    .HasColumnName("tipo_negocio");

                entity.Property(e => e.TipoOperacao)
                    .HasMaxLength(1)
                    .HasColumnName("tipo_operacao");

                entity.Property(e => e.TipoPessoa)
                    .HasMaxLength(1)
                    .HasColumnName("tipo_pessoa");

                entity.Property(e => e.TipoRegistro).HasColumnName("tipo_registro");

                entity.Property(e => e.TipoRegistroCabecalhoId).HasColumnName("tipo_registro_cabecalho_id");

                entity.Property(e => e.TipoRegistroCabecalhostipoRegistroCabecalhoId).HasColumnName("tipo_registro_cabecalhostipo_registro_cabecalho_id");

                entity.Property(e => e.TotalContaInvestimento)
                    .HasPrecision(18, 2)
                    .HasColumnName("total_conta_investimento");

                entity.Property(e => e.TotalContaNormal)
                    .HasPrecision(18, 2)
                    .HasColumnName("total_conta_normal");

                entity.Property(e => e.TotalDespesas)
                    .HasPrecision(18, 2)
                    .HasColumnName("total_despesas");

                entity.Property(e => e.TotalLiquido)
                    .HasPrecision(18, 2)
                    .HasColumnName("total_liquido");

                entity.Property(e => e.ValorNegocios)
                    .HasPrecision(18, 2)
                    .HasColumnName("valor_negocios");

                entity.Property(e => e.ValorOperacao)
                    .HasPrecision(18, 2)
                    .HasColumnName("valor_operacao");

                entity.Property(e => e.Vencimento).HasColumnName("vencimento");

                entity.Property(e => e.VendaDisponivel)
                    .HasPrecision(18, 2)
                    .HasColumnName("venda_disponivel");

                entity.Property(e => e.VendaOpcoes)
                    .HasPrecision(18, 2)
                    .HasColumnName("venda_opcoes");

                entity.HasOne(d => d.TipoRegistroCabecalho)
                    .WithMany(p => p.TipoRegistroBmfDetalhes)
                    .HasForeignKey(d => d.TipoRegistroCabecalhoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fktipo_regis165742");
            });

            modelBuilder.Entity<TipoRegistroBmfResumo>(entity =>
            {
                entity.ToTable("tipo_registro_bmf_resumos");

                entity.HasIndex(e => e.CodigoCliente, "tipo_registro_bmf_resumos_codigo_cliente");

                entity.HasIndex(e => e.CodigoClienteCorretora, "tipo_registro_bmf_resumos_codigo_cliente_corretora");

                entity.HasIndex(e => e.CodigoCorretora, "tipo_registro_bmf_resumos_codigo_corretora");

                entity.HasIndex(e => e.TipoRegistroBmfResumoId, "tipo_registro_bmf_resumos_tipo_registro_bmf_resumo_id")
                    .IsUnique();

                entity.HasIndex(e => e.TipoRegistroCabecalhoId, "tipo_registro_bmf_resumos_tipo_registro_cabecalho_id");

                entity.Property(e => e.TipoRegistroBmfResumoId).HasColumnName("tipo_registro_bmf_resumo_id");

                entity.Property(e => e.AjusteDaytrade)
                    .HasPrecision(18, 2)
                    .HasColumnName("ajuste_daytrade");

                entity.Property(e => e.AjustePosicao)
                    .HasPrecision(18, 2)
                    .HasColumnName("ajuste_posicao");

                entity.Property(e => e.CodigoCliente)
                    .HasMaxLength(14)
                    .HasColumnName("codigo_cliente");

                entity.Property(e => e.CodigoClienteCorretora)
                    .HasMaxLength(15)
                    .HasColumnName("codigo_cliente_corretora");

                entity.Property(e => e.CodigoCorretora)
                    .HasMaxLength(5)
                    .HasColumnName("codigo_corretora");

                entity.Property(e => e.CompraDisponivel)
                    .HasPrecision(18, 2)
                    .HasColumnName("compra_disponivel");

                entity.Property(e => e.CompraOpcoes)
                    .HasPrecision(18, 2)
                    .HasColumnName("compra_opcoes");

                entity.Property(e => e.DataPregao).HasColumnName("data_pregao");

                entity.Property(e => e.Irrf)
                    .HasPrecision(18, 2)
                    .HasColumnName("irrf");

                entity.Property(e => e.IrrfCorretagem)
                    .HasPrecision(18, 2)
                    .HasColumnName("irrf_corretagem");

                entity.Property(e => e.IrrfDaytradeProjecao)
                    .HasPrecision(18, 2)
                    .HasColumnName("irrf_daytrade_projecao");

                entity.Property(e => e.Iss)
                    .HasPrecision(18, 2)
                    .HasColumnName("iss");

                entity.Property(e => e.NumeroNota)
                    .HasMaxLength(50)
                    .HasColumnName("numero_nota");

                entity.Property(e => e.Outros)
                    .HasPrecision(18, 2)
                    .HasColumnName("outros");

                entity.Property(e => e.OutrosCustos)
                    .HasPrecision(18, 2)
                    .HasColumnName("outros_custos");

                entity.Property(e => e.TaxaBmf)
                    .HasPrecision(18, 2)
                    .HasColumnName("taxa_bmf");

                entity.Property(e => e.TaxaOperacional)
                    .HasPrecision(18, 2)
                    .HasColumnName("taxa_operacional");

                entity.Property(e => e.TaxaRegistroBmf)
                    .HasPrecision(18, 2)
                    .HasColumnName("taxa_registro_bmf");

                entity.Property(e => e.TipoPessoa)
                    .HasMaxLength(1)
                    .HasColumnName("tipo_pessoa");

                entity.Property(e => e.TipoRegistro).HasColumnName("tipo_registro");

                entity.Property(e => e.TipoRegistroCabecalhoId).HasColumnName("tipo_registro_cabecalho_id");

                entity.Property(e => e.TotalContaInvestimento)
                    .HasPrecision(18, 2)
                    .HasColumnName("total_conta_investimento");

                entity.Property(e => e.TotalContaNormal)
                    .HasPrecision(18, 2)
                    .HasColumnName("total_conta_normal");

                entity.Property(e => e.TotalDespesas)
                    .HasPrecision(18, 2)
                    .HasColumnName("total_despesas");

                entity.Property(e => e.TotalLiquido)
                    .HasPrecision(18, 2)
                    .HasColumnName("total_liquido");

                entity.Property(e => e.ValorNegocios)
                    .HasPrecision(18, 2)
                    .HasColumnName("valor_negocios");

                entity.Property(e => e.VendaDisponivel)
                    .HasPrecision(18, 2)
                    .HasColumnName("venda_disponivel");

                entity.Property(e => e.VendaOpcoes)
                    .HasPrecision(18, 2)
                    .HasColumnName("venda_opcoes");

                entity.HasOne(d => d.TipoRegistroCabecalho)
                    .WithMany(p => p.TipoRegistroBmfResumos)
                    .HasForeignKey(d => d.TipoRegistroCabecalhoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fktipo_regis529950");
            });

            modelBuilder.Entity<TipoRegistroBovespaDetalhe>(entity =>
            {
                entity.ToTable("tipo_registro_bovespa_detalhes");

                entity.HasIndex(e => e.CodigoCliente, "tipo_registro_bovespa_detalhes_codigo_cliente");

                entity.HasIndex(e => e.CodigoClienteCorretora, "tipo_registro_bovespa_detalhes_codigo_cliente_corretora");

                entity.HasIndex(e => e.CodigoCorretora, "tipo_registro_bovespa_detalhes_codigo_corretora");

                entity.HasIndex(e => e.TipoRegistroBovespaDetalheId, "tipo_registro_bovespa_detalhes_tipo_registro_bovespa_detalhe_id")
                    .IsUnique();

                entity.HasIndex(e => e.TipoRegistroCabecalhoId, "tipo_registro_bovespa_detalhes_tipo_registro_cabecalho_id");

                entity.Property(e => e.TipoRegistroBovespaDetalheId)
                    .HasColumnName("tipo_registro_bovespa_detalhe_id")
                    .HasDefaultValueSql("nextval('tipo_registro_bovespa_detalhe_tipo_registro_bovespa_detalhe_seq'::regclass)");

                entity.Property(e => e.CodigoCliente)
                    .HasMaxLength(14)
                    .HasColumnName("codigo_cliente");

                entity.Property(e => e.CodigoClienteCorretora)
                    .HasMaxLength(15)
                    .HasColumnName("codigo_cliente_corretora");

                entity.Property(e => e.CodigoCorretora)
                    .HasMaxLength(5)
                    .HasColumnName("codigo_corretora");

                entity.Property(e => e.CodigoNegociacaoPapel)
                    .HasMaxLength(10)
                    .HasColumnName("codigo_negociacao_papel");

                entity.Property(e => e.Compra).HasColumnName("compra");

                entity.Property(e => e.DataPregao).HasColumnName("data_pregao");

                entity.Property(e => e.EspecificacaoPapel)
                    .HasMaxLength(100)
                    .HasColumnName("especificacao_papel");

                entity.Property(e => e.EspecificacaoPapelObjeto)
                    .HasMaxLength(10)
                    .HasColumnName("especificacao_papel_objeto");

                entity.Property(e => e.Mercado)
                    .HasMaxLength(30)
                    .HasColumnName("mercado");

                entity.Property(e => e.NumeroNota)
                    .HasMaxLength(50)
                    .HasColumnName("numero_nota");

                entity.Property(e => e.Observacao)
                    .HasMaxLength(10)
                    .HasColumnName("observacao");

                entity.Property(e => e.Prazo)
                    .HasMaxLength(4)
                    .HasColumnName("prazo");

                entity.Property(e => e.Preco)
                    .HasPrecision(18, 2)
                    .HasColumnName("preco");

                entity.Property(e => e.Quantidade).HasColumnName("quantidade");

                entity.Property(e => e.TipoPessoa)
                    .HasMaxLength(1)
                    .HasColumnName("tipo_pessoa");

                entity.Property(e => e.TipoRegistro).HasColumnName("tipo_registro");

                entity.Property(e => e.TipoRegistroCabecalhoId).HasColumnName("tipo_registro_cabecalho_id");

                entity.Property(e => e.ValorOperacao)
                    .HasPrecision(18, 2)
                    .HasColumnName("valor_operacao");

                entity.HasOne(d => d.TipoRegistroCabecalho)
                    .WithMany(p => p.TipoRegistroBovespaDetalhes)
                    .HasForeignKey(d => d.TipoRegistroCabecalhoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fktipo_regis586081");
            });

            modelBuilder.Entity<TipoRegistroBovespaResumo>(entity =>
            {
                entity.ToTable("tipo_registro_bovespa_resumos");

                entity.HasIndex(e => e.CodigoCliente, "tipo_registro_bovespa_resumos_codigo_cliente");

                entity.HasIndex(e => e.CodigoClienteCorretora, "tipo_registro_bovespa_resumos_codigo_cliente_corretora");

                entity.HasIndex(e => e.CodigoCorretora, "tipo_registro_bovespa_resumos_codigo_corretora");

                entity.HasIndex(e => e.TipoRegistroBovespaResumoId, "tipo_registro_bovespa_resumos_tipo_registro_bovespa_resumo_id")
                    .IsUnique();

                entity.HasIndex(e => e.TipoRegistroCabecalhoId, "tipo_registro_bovespa_resumos_tipo_registro_cabecalho_id");

                entity.Property(e => e.TipoRegistroBovespaResumoId)
                    .HasColumnName("tipo_registro_bovespa_resumo_id")
                    .HasDefaultValueSql("nextval('tipo_registro_bovespa_resumos_tipo_registro_bovespa_resumo__seq'::regclass)");

                entity.Property(e => e.CodigoCliente)
                    .HasMaxLength(14)
                    .HasColumnName("codigo_cliente");

                entity.Property(e => e.CodigoClienteCorretora)
                    .HasMaxLength(15)
                    .HasColumnName("codigo_cliente_corretora");

                entity.Property(e => e.CodigoCorretora)
                    .HasMaxLength(5)
                    .HasColumnName("codigo_corretora");

                entity.Property(e => e.CompraFuturo)
                    .HasPrecision(18, 2)
                    .HasColumnName("compra_futuro");

                entity.Property(e => e.CompraVista)
                    .HasPrecision(18, 2)
                    .HasColumnName("compra_vista");

                entity.Property(e => e.DataPregao).HasColumnName("data_pregao");

                entity.Property(e => e.Debentures)
                    .HasPrecision(18, 2)
                    .HasColumnName("debentures");

                entity.Property(e => e.Irrf)
                    .HasPrecision(18, 2)
                    .HasColumnName("irrf");

                entity.Property(e => e.Iss)
                    .HasPrecision(18, 2)
                    .HasColumnName("iss");

                entity.Property(e => e.NumeroNota)
                    .HasMaxLength(50)
                    .HasColumnName("numero_nota");

                entity.Property(e => e.OpcaoCompra)
                    .HasPrecision(18, 2)
                    .HasColumnName("opcao_compra");

                entity.Property(e => e.OpcaoVenda)
                    .HasPrecision(18, 2)
                    .HasColumnName("opcao_venda");

                entity.Property(e => e.OperacaoTermo)
                    .HasPrecision(18, 2)
                    .HasColumnName("operacao_termo");

                entity.Property(e => e.TaxaAna)
                    .HasPrecision(18, 2)
                    .HasColumnName("taxa_ana");

                entity.Property(e => e.TaxaCorretagem)
                    .HasPrecision(18, 2)
                    .HasColumnName("taxa_corretagem");

                entity.Property(e => e.TaxaEmolumentos)
                    .HasPrecision(18, 2)
                    .HasColumnName("taxa_emolumentos");

                entity.Property(e => e.TaxaLiquidacao)
                    .HasPrecision(18, 2)
                    .HasColumnName("taxa_liquidacao");

                entity.Property(e => e.TaxaRegistro)
                    .HasPrecision(18, 2)
                    .HasColumnName("taxa_registro");

                entity.Property(e => e.TaxaTermo)
                    .HasPrecision(18, 2)
                    .HasColumnName("taxa_termo");

                entity.Property(e => e.TipoPessoa)
                    .HasMaxLength(1)
                    .HasColumnName("tipo_pessoa");

                entity.Property(e => e.TipoRegistro).HasColumnName("tipo_registro");

                entity.Property(e => e.TipoRegistroCabecalhoId).HasColumnName("tipo_registro_cabecalho_id");

                entity.Property(e => e.ValorCorretagemExecucao)
                    .HasPrecision(18, 2)
                    .HasColumnName("valor_corretagem_execucao");

                entity.Property(e => e.ValorCorretagemExecucaoCasa)
                    .HasPrecision(18, 2)
                    .HasColumnName("valor_corretagem_execucao_casa");

                entity.Property(e => e.ValorDaytrade)
                    .HasPrecision(18, 2)
                    .HasColumnName("valor_daytrade");

                entity.Property(e => e.ValorIrrfBase)
                    .HasPrecision(18, 2)
                    .HasColumnName("valor_irrf_base");

                entity.Property(e => e.ValorLiquidoNota)
                    .HasPrecision(18, 2)
                    .HasColumnName("valor_liquido_nota");

                entity.Property(e => e.ValorLiquidoOperacao)
                    .HasPrecision(18, 2)
                    .HasColumnName("valor_liquido_operacao");

                entity.Property(e => e.ValorOperacaoTituloPublico)
                    .HasPrecision(18, 2)
                    .HasColumnName("valor_operacao_titulo_publico");

                entity.Property(e => e.ValorProjecao)
                    .HasPrecision(18, 2)
                    .HasColumnName("valor_projecao");

                entity.Property(e => e.ValorTotalOperacao)
                    .HasPrecision(18, 2)
                    .HasColumnName("valor_total_operacao");

                entity.Property(e => e.VendaFuturo)
                    .HasPrecision(18, 2)
                    .HasColumnName("venda_futuro");

                entity.Property(e => e.VendaVista)
                    .HasPrecision(18, 2)
                    .HasColumnName("venda_vista");

                entity.HasOne(d => d.TipoRegistroCabecalho)
                    .WithMany(p => p.TipoRegistroBovespaResumos)
                    .HasForeignKey(d => d.TipoRegistroCabecalhoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fktipo_regis785111");
            });

            modelBuilder.Entity<TipoRegistroCabecalho>(entity =>
            {
                entity.ToTable("tipo_registro_cabecalhos");

                entity.HasIndex(e => e.CodigoCorretora, "tipo_registro_cabecalhos_codigo_corretora");

                entity.HasIndex(e => e.TipoRegistroCabecalhoId, "tipo_registro_cabecalhos_tipo_registro_cabecalho_id")
                    .IsUnique();

                entity.Property(e => e.TipoRegistroCabecalhoId).HasColumnName("tipo_registro_cabecalho_id");

                entity.Property(e => e.CodigoCorretora)
                    .HasMaxLength(10)
                    .HasColumnName("codigo_corretora");

                entity.Property(e => e.DataCadastro).HasColumnName("data_cadastro");

                entity.Property(e => e.DataGeracao).HasColumnName("data_geracao");

                entity.Property(e => e.DataProcessamento).HasColumnName("data_processamento");

                entity.Property(e => e.Processado).HasColumnName("processado");

                entity.Property(e => e.QuantidadeCliente).HasColumnName("quantidade_cliente");
            });

            modelBuilder.Entity<TipoRegistroCarteira>(entity =>
            {
                entity.ToTable("tipo_registro_carteiras");

                entity.HasIndex(e => e.CodigoCliente, "tipo_registro_carteiras_codigo_cliente");

                entity.HasIndex(e => e.CodigoClienteCorretora, "tipo_registro_carteiras_codigo_cliente_corretora");

                entity.HasIndex(e => e.CodigoCorretora, "tipo_registro_carteiras_codigo_corretora");

                entity.HasIndex(e => e.TipoRegistroCabecalhoId, "tipo_registro_carteiras_tipo_registro_cabecalho_id");

                entity.HasIndex(e => e.TipoRegistroCarteiraId, "tipo_registro_carteiras_tipo_registro_carteira_id")
                    .IsUnique();

                entity.Property(e => e.TipoRegistroCarteiraId).HasColumnName("tipo_registro_carteira_id");

                entity.Property(e => e.CodigoCliente)
                    .HasMaxLength(14)
                    .HasColumnName("codigo_cliente");

                entity.Property(e => e.CodigoClienteCorretora)
                    .HasMaxLength(15)
                    .HasColumnName("codigo_cliente_corretora");

                entity.Property(e => e.CodigoCorretora)
                    .HasMaxLength(5)
                    .HasColumnName("codigo_corretora");

                entity.Property(e => e.CodigoNegociacaoPapel)
                    .HasMaxLength(10)
                    .HasColumnName("codigo_negociacao_papel");

                entity.Property(e => e.CodigoTomadorDoador)
                    .HasMaxLength(10)
                    .HasColumnName("codigo_tomador_doador");

                entity.Property(e => e.DataCustodia).HasColumnName("data_custodia");

                entity.Property(e => e.Mercado)
                    .HasMaxLength(5)
                    .HasColumnName("mercado");

                entity.Property(e => e.Quantidade).HasColumnName("quantidade");

                entity.Property(e => e.TipoPessoa)
                    .HasMaxLength(1)
                    .HasColumnName("tipo_pessoa");

                entity.Property(e => e.TipoRegistro).HasColumnName("tipo_registro");

                entity.Property(e => e.TipoRegistroCabecalhoId).HasColumnName("tipo_registro_cabecalho_id");

                entity.HasOne(d => d.TipoRegistroCabecalho)
                    .WithMany(p => p.TipoRegistroCarteiras)
                    .HasForeignKey(d => d.TipoRegistroCabecalhoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fktipo_regis808210");
            });

            modelBuilder.Entity<TipoRegistroExtrato>(entity =>
            {
                entity.ToTable("tipo_registro_extratos");

                entity.HasIndex(e => e.CodigoCliente, "tipo_registro_extratos_codigo_cliente");

                entity.HasIndex(e => e.CodigoClienteCorretora, "tipo_registro_extratos_codigo_cliente_corretora");

                entity.HasIndex(e => e.CodigoCorretora, "tipo_registro_extratos_codigo_corretora");

                entity.HasIndex(e => e.TipoRegistroCabecalhoId, "tipo_registro_extratos_tipo_registro_cabecalho_id");

                entity.HasIndex(e => e.TipoRegistroExtratoId, "tipo_registro_extratos_tipo_registro_extrato_id")
                    .IsUnique();

                entity.Property(e => e.TipoRegistroExtratoId).HasColumnName("tipo_registro_extrato_id");

                entity.Property(e => e.CodigoCliente)
                    .HasMaxLength(14)
                    .HasColumnName("codigo_cliente");

                entity.Property(e => e.CodigoClienteCorretora)
                    .HasMaxLength(15)
                    .HasColumnName("codigo_cliente_corretora");

                entity.Property(e => e.CodigoCorretora)
                    .HasMaxLength(5)
                    .HasColumnName("codigo_corretora");

                entity.Property(e => e.CodigoHistorico)
                    .HasMaxLength(15)
                    .HasColumnName("codigo_historico");

                entity.Property(e => e.DataLancamento).HasColumnName("data_lancamento");

                entity.Property(e => e.DataReferencia).HasColumnName("data_referencia");

                entity.Property(e => e.DescricaoLancamento)
                    .HasMaxLength(100)
                    .HasColumnName("descricao_lancamento");

                entity.Property(e => e.TipoPessoa)
                    .HasMaxLength(1)
                    .HasColumnName("tipo_pessoa");

                entity.Property(e => e.TipoRegistro).HasColumnName("tipo_registro");

                entity.Property(e => e.TipoRegistroCabecalhoId).HasColumnName("tipo_registro_cabecalho_id");

                entity.Property(e => e.Valor)
                    .HasPrecision(18, 2)
                    .HasColumnName("valor");

                entity.HasOne(d => d.TipoRegistroCabecalho)
                    .WithMany(p => p.TipoRegistroExtratos)
                    .HasForeignKey(d => d.TipoRegistroCabecalhoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fktipo_regis351645");
            });

            modelBuilder.Entity<TipoRegistroOpcaoFlexivelDetalhe>(entity =>
            {
                entity.ToTable("tipo_registro_opcao_flexivel_detalhes");

                entity.HasIndex(e => e.CodigoCliente, "tipo_registro_opcao_flexivel_detalhes_codigo_cliente");

                entity.HasIndex(e => e.CodigoClienteCorretora, "tipo_registro_opcao_flexivel_detalhes_codigo_cliente_corretora");

                entity.HasIndex(e => e.CodigoCorretora, "tipo_registro_opcao_flexivel_detalhes_codigo_corretora");

                entity.HasIndex(e => e.TipoRegistroCabecalhoId, "tipo_registro_opcao_flexivel_detalhes_tipo_registro_cabecalho_i");

                entity.HasIndex(e => e.TipoRegistroOpcaoFlexivelDetalheId, "tipo_registro_opcao_flexivel_detalhes_tipo_registro_opcao_flexi")
                    .IsUnique();

                entity.Property(e => e.TipoRegistroOpcaoFlexivelDetalheId)
                    .HasColumnName("tipo_registro_opcao_flexivel_detalhe_id")
                    .HasDefaultValueSql("nextval('tipo_registro_opcao_flexivel__tipo_registro_opcao_flexivel__seq'::regclass)");

                entity.Property(e => e.AmericanaEuropeia)
                    .HasMaxLength(1)
                    .HasColumnName("americana_europeia");

                entity.Property(e => e.CodigoCliente)
                    .HasMaxLength(14)
                    .HasColumnName("codigo_cliente");

                entity.Property(e => e.CodigoClienteCorretora)
                    .HasMaxLength(15)
                    .HasColumnName("codigo_cliente_corretora");

                entity.Property(e => e.CodigoCorretora)
                    .HasMaxLength(5)
                    .HasColumnName("codigo_corretora");

                entity.Property(e => e.Contrato)
                    .HasMaxLength(50)
                    .HasColumnName("contrato");

                entity.Property(e => e.Corretagem)
                    .HasPrecision(18, 2)
                    .HasColumnName("corretagem");

                entity.Property(e => e.Cotacao)
                    .HasMaxLength(50)
                    .HasColumnName("cotacao");

                entity.Property(e => e.DataPagamentoPremio)
                    .HasPrecision(18, 2)
                    .HasColumnName("data_pagamento_premio");

                entity.Property(e => e.DataPregao).HasColumnName("data_pregao");

                entity.Property(e => e.Garantia)
                    .HasMaxLength(1)
                    .HasColumnName("garantia");

                entity.Property(e => e.KnockInAndDown)
                    .HasPrecision(18, 2)
                    .HasColumnName("knock_in_and_down");

                entity.Property(e => e.KnockInAndUp)
                    .HasPrecision(18, 2)
                    .HasColumnName("knock_in_and_up");

                entity.Property(e => e.KnockOutAndDown)
                    .HasPrecision(18, 2)
                    .HasColumnName("knock_out_and_down");

                entity.Property(e => e.Mercadoria)
                    .HasMaxLength(50)
                    .HasColumnName("mercadoria");

                entity.Property(e => e.NaturezaOperacaoCompraVenda)
                    .HasMaxLength(1)
                    .HasColumnName("natureza_operacao_compra_venda");

                entity.Property(e => e.NumeroNota)
                    .HasMaxLength(50)
                    .HasColumnName("numero_nota");

                entity.Property(e => e.PrecoBarreira)
                    .HasPrecision(18, 2)
                    .HasColumnName("preco_barreira");

                entity.Property(e => e.PrecoExercicio)
                    .HasPrecision(18, 2)
                    .HasColumnName("preco_exercicio");

                entity.Property(e => e.Quantidade).HasColumnName("quantidade");

                entity.Property(e => e.TaxaEmolumento)
                    .HasPrecision(18, 2)
                    .HasColumnName("taxa_emolumento");

                entity.Property(e => e.TaxaRegistro)
                    .HasPrecision(18, 2)
                    .HasColumnName("taxa_registro");

                entity.Property(e => e.TipoNegocio)
                    .HasMaxLength(20)
                    .HasColumnName("tipo_negocio");

                entity.Property(e => e.TipoRegistro).HasColumnName("tipo_registro");

                entity.Property(e => e.TipoRegistroCabecalhoId).HasColumnName("tipo_registro_cabecalho_id");

                entity.Property(e => e.ValorLiquidacao)
                    .HasPrecision(18, 2)
                    .HasColumnName("valor_liquidacao");

                entity.Property(e => e.ValorNegocio)
                    .HasPrecision(18, 2)
                    .HasColumnName("valor_negocio");

                entity.Property(e => e.Vencimento).HasColumnName("vencimento");

                entity.HasOne(d => d.TipoRegistroCabecalho)
                    .WithMany(p => p.TipoRegistroOpcaoFlexivelDetalhes)
                    .HasForeignKey(d => d.TipoRegistroCabecalhoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fktipo_regis246227");
            });

            modelBuilder.Entity<TipoRegistroOpcaoFlexivelResumo>(entity =>
            {
                entity.ToTable("tipo_registro_opcao_flexivel_resumos");

                entity.HasIndex(e => e.CodigoCliente, "tipo_registro_opcao_flexivel_resumos_codigo_cliente");

                entity.HasIndex(e => e.CodigoClienteCorretora, "tipo_registro_opcao_flexivel_resumos_codigo_cliente_corretora");

                entity.HasIndex(e => e.CodigoCorretora, "tipo_registro_opcao_flexivel_resumos_codigo_corretora");

                entity.HasIndex(e => e.TipoRegistroCabecalhoId, "tipo_registro_opcao_flexivel_resumos_tipo_registro_cabecalho_id");

                entity.HasIndex(e => e.TipoRegistroOpcaoFlexivelResumoId, "tipo_registro_opcao_flexivel_resumos_tipo_registro_opcao_flexiv")
                    .IsUnique();

                entity.Property(e => e.TipoRegistroOpcaoFlexivelResumoId)
                    .HasColumnName("tipo_registro_opcao_flexivel_resumo_id")
                    .HasDefaultValueSql("nextval('tipo_registro_opcao_flexivel__tipo_registro_opcao_flexivel_seq1'::regclass)");

                entity.Property(e => e.CodigoCliente)
                    .HasMaxLength(14)
                    .HasColumnName("codigo_cliente");

                entity.Property(e => e.CodigoClienteCorretora)
                    .HasMaxLength(15)
                    .HasColumnName("codigo_cliente_corretora");

                entity.Property(e => e.CodigoCorretora)
                    .HasMaxLength(5)
                    .HasColumnName("codigo_corretora");

                entity.Property(e => e.ContraParte)
                    .HasMaxLength(50)
                    .HasColumnName("contra_parte");

                entity.Property(e => e.DataPregao).HasColumnName("data_pregao");

                entity.Property(e => e.DescricaoTipoNota)
                    .HasMaxLength(50)
                    .HasColumnName("descricao_tipo_nota");

                entity.Property(e => e.Irrf)
                    .HasPrecision(18, 2)
                    .HasColumnName("irrf");

                entity.Property(e => e.IrrfCorretagem)
                    .HasPrecision(18, 2)
                    .HasColumnName("irrf_corretagem");

                entity.Property(e => e.IrrfDaytrade)
                    .HasPrecision(18, 2)
                    .HasColumnName("irrf_daytrade");

                entity.Property(e => e.Iss)
                    .HasPrecision(18, 2)
                    .HasColumnName("iss");

                entity.Property(e => e.NumeroNota)
                    .HasMaxLength(50)
                    .HasColumnName("numero_nota");

                entity.Property(e => e.Outros)
                    .HasPrecision(18, 2)
                    .HasColumnName("outros");

                entity.Property(e => e.OutrosCustos)
                    .HasPrecision(18, 2)
                    .HasColumnName("outros_custos");

                entity.Property(e => e.TaxaBmf).HasColumnName("taxa_bmf");

                entity.Property(e => e.TaxaOperacional)
                    .HasPrecision(18, 2)
                    .HasColumnName("taxa_operacional");

                entity.Property(e => e.TaxaRegistroBmf)
                    .HasPrecision(18, 2)
                    .HasColumnName("taxa_registro_bmf");

                entity.Property(e => e.TipoRegistro).HasColumnName("tipo_registro");

                entity.Property(e => e.TipoRegistroCabecalhoId).HasColumnName("tipo_registro_cabecalho_id");

                entity.Property(e => e.TotalContaInvestimento)
                    .HasPrecision(18, 2)
                    .HasColumnName("total_conta_investimento");

                entity.Property(e => e.TotalContaNormal)
                    .HasPrecision(18, 2)
                    .HasColumnName("total_conta_normal");

                entity.Property(e => e.TotalDespesas)
                    .HasPrecision(18, 2)
                    .HasColumnName("total_despesas");

                entity.Property(e => e.TotalLiquidacao)
                    .HasPrecision(18, 2)
                    .HasColumnName("total_liquidacao");

                entity.Property(e => e.TotalLiquidoNota)
                    .HasPrecision(18, 2)
                    .HasColumnName("total_liquido_nota");

                entity.Property(e => e.TotalNegocio)
                    .HasPrecision(18, 2)
                    .HasColumnName("total_negocio");

                entity.HasOne(d => d.TipoRegistroCabecalho)
                    .WithMany(p => p.TipoRegistroOpcaoFlexivelResumos)
                    .HasForeignKey(d => d.TipoRegistroCabecalhoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fktipo_regis969529");
            });

            modelBuilder.Entity<TipoRegistroProvento>(entity =>
            {
                entity.HasKey(e => e.TipoRegistroProventosId)
                    .HasName("tipo_registro_proventos_pkey");

                entity.ToTable("tipo_registro_proventos");

                entity.HasIndex(e => e.CodigoCliente, "tipo_registro_proventos_codigo_cliente");

                entity.HasIndex(e => e.CodigoClienteCorretora, "tipo_registro_proventos_codigo_cliente_corretora");

                entity.HasIndex(e => e.CodigoCorretora, "tipo_registro_proventos_codigo_corretora");

                entity.HasIndex(e => e.TipoRegistroCabecalhoId, "tipo_registro_proventos_tipo_registro_cabecalho_id");

                entity.HasIndex(e => e.TipoRegistroProventosId, "tipo_registro_proventos_tipo_registro_proventos_id")
                    .IsUnique();

                entity.Property(e => e.TipoRegistroProventosId).HasColumnName("tipo_registro_proventos_id");

                entity.Property(e => e.CodigoCarteira)
                    .HasMaxLength(10)
                    .HasColumnName("codigo_carteira");

                entity.Property(e => e.CodigoCliente)
                    .HasMaxLength(14)
                    .HasColumnName("codigo_cliente");

                entity.Property(e => e.CodigoClienteCorretora)
                    .HasMaxLength(15)
                    .HasColumnName("codigo_cliente_corretora");

                entity.Property(e => e.CodigoCorretora)
                    .HasMaxLength(5)
                    .HasColumnName("codigo_corretora");

                entity.Property(e => e.CodigoIsin)
                    .HasMaxLength(15)
                    .HasColumnName("codigo_isin");

                entity.Property(e => e.CodigoNegociacaoPapel)
                    .HasMaxLength(10)
                    .HasColumnName("codigo_negociacao_papel");

                entity.Property(e => e.DataLiquidacao).HasColumnName("data_liquidacao");

                entity.Property(e => e.DescricaoTipoProvento)
                    .HasMaxLength(50)
                    .HasColumnName("descricao_tipo_provento");

                entity.Property(e => e.NomeEmpresa)
                    .HasMaxLength(50)
                    .HasColumnName("nome_empresa");

                entity.Property(e => e.NumeroDistribuicao).HasColumnName("numero_distribuicao");

                entity.Property(e => e.QuantidadeAtivos).HasColumnName("quantidade_ativos");

                entity.Property(e => e.TipoRegistro).HasColumnName("tipo_registro");

                entity.Property(e => e.TipoRegistroCabecalhoId).HasColumnName("tipo_registro_cabecalho_id");

                entity.Property(e => e.ValorBruto)
                    .HasPrecision(18, 2)
                    .HasColumnName("valor_bruto");

                entity.Property(e => e.ValorIr)
                    .HasPrecision(18, 2)
                    .HasColumnName("valor_ir");

                entity.Property(e => e.ValorLiquido)
                    .HasPrecision(18, 2)
                    .HasColumnName("valor_liquido");

                entity.HasOne(d => d.TipoRegistroCabecalho)
                    .WithMany(p => p.TipoRegistroProventos)
                    .HasForeignKey(d => d.TipoRegistroCabecalhoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fktipo_regis10030");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
