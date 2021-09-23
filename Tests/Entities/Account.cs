using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Tests.Support;
using Tests.Support.CustomAttributes;

namespace Tests.Entities
{
    public class Account : EntityHandler<Account>, IEntity
    {
        [GetAPI]
        public string Id { get; set; }

        [PatchAPI]
        [PostAPI]
        [GetAPI]
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Account Name")]
        public string Name { get; set; }

        [PatchAPI]
        [RegularExpression("Prospect|Customer - Direct")]
        public string Type { get; set; }

        [PatchAPI]
        [PostAPI]
        public string Description { get; set; }

        [PatchAPI]
        [PostAPI]
        [GetAPI]
        public string Phone { get; set; }
    }
}
