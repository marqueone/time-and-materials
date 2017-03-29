using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Marqueone.TimeAndMaterials.Api.Entities;

namespace Marqueone.TimeAndMaterials.Api.Models.ViewModels
{
    public class NewEmployeeViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public EmployeeType Type { get; set; }
        public IList<ContactMethod> Contacts { get; set; }
        public IList<Trade> Trades { get; set; }

    }

    public class UpdateEmployeeViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public EmployeeType Type { get; set; }
        public IList<ContactMethod> Contacts { get; set; }
        public IList<Trade> Trades { get; set; }
    }

    public class AddEmployeeTradeViewModel 
    {
        public int EmployeeId { get; set; }
        public int TradeId { get; set; }
    }

    public class RemoveEmployeeTradeViewModel 
    {
        public int EmployeeId { get; set; }
        public int TradeId { get; set; }
    }
}