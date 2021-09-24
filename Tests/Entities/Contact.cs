using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Tests.Support;
using Tests.Support.CustomAttributes;

namespace Tests.Entities
{
    public class Contact : IEntity
    {
        [GetAPI]
        public string Id { get; set; }

        [PostAPI]
        [GetAPI]
        [SetFieldsUI]
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [PostAPI]
        [GetAPI]
        [SetFieldsUI]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [PostAPI]
        [GetAPI]
        [SetFieldsUI]
        [RegularExpression("Mr.|Ms.")]
        public string Salutation { get; set; } = null;

        [SetFieldsUI]
        [GetFieldsUI]
        [Display(Name = "Account Name")]
        public string AccountName { get; set; }

        [GetAPI]
        [GetFieldsUI]
        public string Name => $"{Salutation} {FirstName} {LastName}".Trim().Replace("  ", " ");

        [PostAPI]
        [GetAPI]
        [SetFieldsUI]
        [GetFieldsUI]
        public string Phone { get; set; }

        [PostAPI]
        [GetAPI]
        public string AccountId { get; set; }
    }
}
