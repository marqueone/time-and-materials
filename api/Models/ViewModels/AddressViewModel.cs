using System.ComponentModel.DataAnnotations;

namespace Marqueone.TimeAndMaterials.Api.Models.ViewModels
{
    public class NewAddressViewModel 
    {
        [Required]
        [MaxLength(64)]
        public string AddressLine1 { get; set; }

        [Required]
        [MaxLength(64)]
        public string AddressLine2 { get; set; }

        [Required]
        [MaxLength(64)]
        public string AddressLine3 { get; set; }

        [Required]
        [MaxLength(64)]
        public string City { get; set; }

        [Required]
        [MaxLength(2)]
        public string Province { get; set; }

        [Required]
        [MaxLength(16)]
        public string PostalCode { get; set; }

        [Required]
        public int GMT { get; set; }

        [Required]
        public AddressType AddressType { get; set; }
    }

    public class UpdateAddressViewModel 
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(64)]
        public string AddressLine1 { get; set; }

        [Required]
        [MaxLength(64)]
        public string AddressLine2 { get; set; }

        [Required]
        [MaxLength(64)]
        public string AddressLine3 { get; set; }

        [Required]
        [MaxLength(64)]
        public string City { get; set; }

        [Required]
        [MaxLength(2)]
        public string Province { get; set; }

        [Required]
        [MaxLength(16)]
        public string PostalCode { get; set; }

        [Required]
        public int GMT { get; set; }

        [Required]
        public AddressType AddressType { get; set; }
    }
}