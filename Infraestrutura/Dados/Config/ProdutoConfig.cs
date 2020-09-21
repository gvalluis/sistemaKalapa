using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestrutura.Dados.Config
{
    public class ProdutoConfig : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Descricao).IsRequired().HasMaxLength(180);
            builder.Property(p => p.Preco).HasColumnType("decimal(18,2)");
            builder.Property(p => p.UrlFoto).IsRequired();
            builder.HasOne(b => b.Categoria).WithMany().
                HasForeignKey(p => p.IdCategoriaProduto);
            builder.HasOne(t => t.TipoProduto).WithMany()
                .HasForeignKey(p => p.IdTipoDeProduto);
        
        }
    }
}