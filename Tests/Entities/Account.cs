using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Tests.Support;

namespace Tests.Entities
{
    public class Account : IEntity
    {
        [SetUI]
        [GetUI]
        [API]
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Account Name")]
        public string Name { get; set; }

        [SetUI]
        [GetUI]
        [API]
        [RegularExpression("Prospect|Customer - Direct")]
        public string Type { get; set; }

        [SetUI]
        [GetUI]
        [API]
        public string Description { get; set; }

        [SetUI]
        [GetUI]
        [API]
        public string Phone { get; set; }
    }
}
