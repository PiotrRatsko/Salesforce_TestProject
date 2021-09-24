using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Tests.Support.CustomAttributes;

namespace Tests.Entities
{
    public class Account : IEntity
    {
        [GetAPI]
        public string Id { get; set; }

        [PatchAPI]
        [PostAPI]
        [GetAPI]
        [SetFieldsUI]
        [GetFieldsUI]
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Account Name")]
        public string Name { get; set; }

        [PostAPI]
        [GetAPI]
        [PatchAPI]
        [SetFieldsUI]
        [GetFieldsUI]
        [RegularExpression("Prospect|Customer - Direct")]
        public string Type { get; set; }

        [PatchAPI]
        [PostAPI]
        [GetAPI]
        [SetFieldsUI]
        [GetFieldsUI]
        public string Description { get; set; }

        [PatchAPI]
        [PostAPI]
        [GetAPI]
        [SetFieldsUI]
        [GetFieldsUI]
        public string Phone { get; set; }
    }
}
