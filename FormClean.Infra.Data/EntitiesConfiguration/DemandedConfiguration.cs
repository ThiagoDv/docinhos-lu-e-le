using FormClean.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FormClean.Infra.Data.EntitiesConfiguration
{
    public class DemandedConfiguration : IEntityTypeConfiguration<Demanded>
    {
        public void Configure(EntityTypeBuilder<Demanded> builder)
        {
            builder.HasKey(id => id.Id);

            builder.Property(description => description.Description)
                .HasColumnName("descricao")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(price => price.Price)
                .HasColumnName("preco")
                .IsRequired();

            builder.Property(payment => payment.PaymentStatus)
                .HasColumnName("status_pagamento")
                .IsRequired();

            builder.Property(demandedStatus => demandedStatus.DemandedStatus)
                .HasColumnName("status_pedido")
                .IsRequired();

            builder.Property(deliveryDate => deliveryDate.DeliveryDate)
                .HasColumnName("data_entrega")
                .IsRequired();

            builder.Property(deliveryLocation => deliveryLocation.DeliveryLocation)
                .HasColumnName("endereco_entrega")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(client => client.Client)
                .WithMany(demandeds => demandeds.Demandeds)
                .HasForeignKey(clientId => clientId.ClientId);
        }
    }
}
