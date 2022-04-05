using FormClean.Domain.Validation;
using System.Collections.Generic;

namespace FormClean.Domain.Entities
{
    public class Client : EntityBase
    {
        public string Name { get; private set; }

        public string Email { get; private set; }

        public string Phone { get; private set; }

        public string Street { get; private set; }

        public string District { get; private set; }

        public string NumberStreet { get; private set; }

        public ICollection<Demanded> Demandeds { get; set; }

        public Client(string name, string email, string phone, string street, string district, string numberStreet)
        {
            ValidateDomain(name,email,phone, street, district, numberStreet);
        }

        public Client(int id, string name, string email, string phone, string street, string district, string numberStreet)
        {
            DomainExceptionValidate.When(id < 0,
                "Id inválido, não pode ser menor que 0.");
            Id = id;

            ValidateDomain(name, email, phone, street, district, numberStreet);
        }

        private void ValidateDomain(string name, string email, string phone, string street, string district, string numberStreet)
        {
            DomainExceptionValidate.When(string.IsNullOrEmpty(name),
                "Nome não pode ser vazio.");

            DomainExceptionValidate.When(string.IsNullOrEmpty(email),
                "Email inválido, email não pode ser vazio.");

            DomainExceptionValidate.When(string.IsNullOrEmpty(phone),
                "Telefone inválido, telefone não pode ser vazio.");

            DomainExceptionValidate.When(string.IsNullOrEmpty(street),
                "Rua inválida, rua não pode ser vazia.");

            DomainExceptionValidate.When(string.IsNullOrEmpty(district),
                "Bairro inválido, bairro não pode ser vazio.");

            DomainExceptionValidate.When(string.IsNullOrEmpty(numberStreet),
                "Número do endereço inválido, número do endereço não pode ser vazio.");


            Name = name;
            Email = email;
            Phone = phone;
            Street = street;
            District = district;
            NumberStreet = numberStreet;
        }
    }
}
