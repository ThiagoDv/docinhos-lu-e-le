using FormClean.Domain.Validation;
using System;

namespace FormClean.Domain.Entities
{
    public class Demanded : EntityBase
    {
        public string Description { get; private set; }
        public DateTime DeliveryDate { get; private set; }
        public string Price { get; private set; }
        public string DeliveryLocation { get; private set; }
        public string PaymentStatus { get; private set; }
        public string DemandedStatus { get; private set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public Demanded(string description, DateTime deliveryDate, string deliveryLocation, string paymentStatus, string demandedStatus, string price, int clientId)
        {
            ValidateDomain(description, deliveryDate, deliveryLocation, paymentStatus, demandedStatus, price, clientId);
        }

        public Demanded(int id, string description, DateTime deliveryDate, string deliveryLocation, string paymentStatus, string demandedStatus, string price, int clientId)
        {
            DomainExceptionValidate.When(id < 0,
                "Id inválido. Não pode ser menor que 0.");
            Id = id;
            ValidateDomain(description, deliveryDate, deliveryLocation, paymentStatus, demandedStatus, price, clientId);
        }

        private void ValidateDomain(string description, DateTime deliveryDate, string deliveryLocation, string paymentStatus, string demandedStatus, string price, int clientId)
        {
            DomainExceptionValidate.When(string.IsNullOrEmpty(description),
                "Descrição não pode ser nulo.");

            DomainExceptionValidate.When(price.Length < 0,
                "Preço não pode ser menor que 0.");

            DomainExceptionValidate.When(string.IsNullOrEmpty(paymentStatus),
                "Status de pagamento não pode ser nulo.");

            DomainExceptionValidate.When(string.IsNullOrEmpty(demandedStatus),
                "Status do pedido não pode ser nulo.");

            DomainExceptionValidate.When(clientId < 0,
                "Id inválido, não pode ser menor que 0.");

            DomainExceptionValidate.When(string.IsNullOrEmpty(deliveryLocation),
                "Endereço de entrega não pode ser nulo.");

            Description = description;
            DeliveryDate = deliveryDate;
            DeliveryLocation = deliveryLocation;
            PaymentStatus = paymentStatus;
            DemandedStatus = demandedStatus;
            Price = price;
            ClientId = clientId;
        }
    }
}
