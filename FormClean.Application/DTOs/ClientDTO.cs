using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FormClean.Application.DTOs
{
    public class ClientDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O nome do cliente deve ter no máximo 100 caracteres.")]
        [MinLength(3, ErrorMessage = "O nome do cliente deve ter no mínimo 3 caracteres.")]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email é obrigatório.")]
        [MaxLength(50)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório.")]
        [MaxLength(20)]
        [Display(Name = "Whatsapp")]
        public string Phone { get; set; }

        [Required(ErrorMessage ="A rua é obrigatória.")]
        [MaxLength(100)]
        [Display(Name = "Rua")]
        public string Street { get; set; }

        [Required(ErrorMessage = "O bairro é obrigatório.")]
        [MaxLength(100)]
        [Display(Name = "Bairro")]
        public string District { get; set; }

        [Required(ErrorMessage = "O número do endereço é obrigatório.")]
        [MaxLength(100)]
        [Display(Name = "Número do Endereço")]
        public string NumberStreet { get; set; }


        [Display(Name ="Pedidos")]
        public ICollection<DemandedDTO> Demandeds { get; set; }
    }
}
