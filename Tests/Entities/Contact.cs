using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Tests.Support.CustomAttributes;

namespace Tests.Entities
{
    public class Contact : IEntity
    {
        [PostAPI]
        [GetAPI]
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [PostAPI]
        [GetAPI]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [PostAPI]
        [GetAPI]
        [RegularExpression("Mr.|Ms.")]
        public string Salutation { get; set; } = null;

        [PostAPI]
        [GetAPI]
        [Display(Name = "Account Name")]
        public string AccountName { get; set; }

        [GetAPI]
        public string Name { get; set; }

        [PostAPI]
        [GetAPI]
        public string Phone { get; set; }
    }
}
