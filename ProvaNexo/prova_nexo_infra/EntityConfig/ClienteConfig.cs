using prova_nexo_domain.Domain;
using System.Data.Entity.ModelConfiguration;

namespace prova_nexo_infra.EntityConfig
{
    public class ClienteConfig : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfig()
        {
            HasKey(p => p.Id);

            Property(p => p.Nome)
              .IsRequired()
              .HasMaxLength(150);
            Property(p => p.SobreNome)
               .IsRequired()
               .HasMaxLength(150);
            Property(p => p.Email)
                  .IsRequired()
                  .HasMaxLength(150);

            Property(p => p.DataCadastro)
                .IsRequired();

            Property(p => p.Ativo)
                .IsRequired();

        }   
    }
}
