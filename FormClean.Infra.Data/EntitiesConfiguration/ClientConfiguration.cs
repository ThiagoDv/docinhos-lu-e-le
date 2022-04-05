using FormClean.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FormClean.Infra.Data.EntitiesConfiguration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(id => id.Id);

            builder.Property(name => name.Name)
                .HasColumnName("nome_cliente")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(email => email.Email)
                .HasColumnName("email")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(phone => phone.Phone)
                .HasColumnName("whatsapp")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(street => street.Street)
                .HasColumnName("rua_cliente")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(district => district.District)
                .HasColumnName("bairro_cliente")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(numberStreet => numberStreet.NumberStreet)
                .HasColumnName("numero_endereco_cliente")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
