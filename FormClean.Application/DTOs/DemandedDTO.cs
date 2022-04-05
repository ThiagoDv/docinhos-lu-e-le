using FormClean.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace FormClean.Application.DTOs
{
    public class DemandedDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [MaxLength(200)]
        [MinLength(3)]
        [Display(Name="Descrição")]
        public string Description { get; set; }

        [Required(ErrorMessage = "A data da entrega é obrigatória, juntamente com o horário.")]
        [Display(Name="Data da Entrega")]
        public DateTime DeliveryDate { get; set; }

        [Required(ErrorMessage = "O local da entrega é obrigatória")]
        [Display(Name = "Local da Entrega")]
        public string DeliveryLocation { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório, caso não saiba ainda o valor, informe o valor 1.")]
        [Display(Name="Preço")]
        public string Price { get; set; }

        [Required(ErrorMessage = "O status de pagamento é obrigatório")]
        [Display(Name = "Status De Pagamento")]
        public string PaymentStatus { get; set; }


        [Required(ErrorMessage = "O nome do cliente é obrigatório, caso não saiba ainda o valor, informe o valor 1.")]
        [Display(Name = "Nome Cliente")]
        public int ClientId { get; set; }

        [Display(Name="Cliente")]
        public Client Client { get; set; }

    }
}
