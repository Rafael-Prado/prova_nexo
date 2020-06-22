using prova_nexo_domain.Domain;
using System.Data.Entity.ModelConfiguration;

namespace prova_nexo_infra.EntityConfig
{
    public class ProdutoConfig : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfig()
        {
            HasKey(p => p.Id);

            Property(p => p.Nome)
              .IsRequired()
              .HasMaxLength(150);

            Property(p => p.Valor)
                .IsRequired();

            Property(p => p.Disponivel)
                .IsRequired();

            // MAPEAMENTO DE UM PARA MUITOS
            HasRequired(p => p.Cliente)
                    .WithMany(p => p.ProdutoList)
                    .HasForeignKey(p => p.ClienteId);
        }
    }
}
