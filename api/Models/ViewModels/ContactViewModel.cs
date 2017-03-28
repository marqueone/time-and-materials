using System.ComponentModel.DataAnnotations;

namespace Marqueone.TimeAndMaterials.Api.Models.ViewModels
{
    public class NewEmployeeContactMethodViewModel
    {
        public int EmployeeId { get; set; }
        public ContactType Type { get; set; }
        public string Value { get; set; }
        public bool IsPrivate { get; set; }
    }

    public class UpdateEmployeeContactMethodViewModel
    {
        public int Id { get; set; }
        public ContactType Type { get; set; }
        public string Value { get; set; }
        public bool IsPrivate { get; set; }

    }
}