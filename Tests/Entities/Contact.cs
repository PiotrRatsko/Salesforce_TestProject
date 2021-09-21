using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Tests.Support;

namespace Tests.Entities
{
    public class Contact : IEntity
    {
        [SetUI]
        [API]
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [SetUI]
        [API]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [SetUI]
        [API]
        [RegularExpression("Mr.|Ms.")]
        public string Salutation { get; set; } = null;

        [SetUI]
        [GetUI]
        [Display(Name = "Account Name")]
        public string AccountName { get; set; }

        [GetUI]
        public string Name { get; set; }

        [SetUI]
        [GetUI]
        [API]
        public string Phone { get; set; }
    }
}
