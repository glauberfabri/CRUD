using Microsoft.Build.Framework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace DBFirst.Models
{
    public partial class Cadastro
    {

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage= "CNPJ Obrigatório")]
        public long Cnpj { get; set; }

        [StringLength(20, MinimumLength =4, ErrorMessage="Os dados estão incompletos")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Razão Social obrigatório")]
        [DisplayName("Razão Social")]
         public string? RazaoSocial { get; set; }
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Os dados estão incompletos")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Nome Fantasia obrigatório")]
        [DisplayName("Nome Fantasia")]
        public string? NomeFantasia { get; set; }



        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Razão Social obrigatório")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string? Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [DisplayName("Telefone")]
        public int? Telefone { get; set; }

        [DataType(DataType.PhoneNumber)]
        [DisplayName("Telefone Comercial")]
        public int? TelefoneComercial { get; set; }


        [DataType(DataType.PhoneNumber)]      
        public int? Celular { get; set; }


        [DisplayName("Logradouro")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Os dados estão incompletos")]
        public string? Logradouro { get; set; }

       [Range(1,5)]
       [DisplayName("Número")]
        public int? Numero { get; set; }


        [DisplayName("Complemento")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Os dados estão incompletos")]
        public string? Complemento { get; set; }


        [DisplayName("Bairro")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Os dados estão incompletos")]
        public string? Bairro { get; set; }

         [DisplayName("Cidade")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Os dados estão incompletos")]
        public string? Cidade { get; set; }


         [DisplayName("Estado")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Os dados estão incompletos")]
        public string? Estado { get; set; }


        
        [DisplayName("CEP")]
        [DataType(DataType.PostalCode)]
        public long? Cep { get; set; }

        [StringLength(20, MinimumLength = 4, ErrorMessage = "Os dados estão incompletos")]
        [DisplayName("Nome Contato")]
        public string? NomeContato { get; set; }
    }
}
