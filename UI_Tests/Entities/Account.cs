using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Tests.Entities
{
    class Account : IEntity
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [RegularExpression("Prospect|Customer - Direct")]
        public string Type { get; set; }

        public string Description { get; set; }
    }
}
