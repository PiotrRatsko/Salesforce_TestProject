using System.ComponentModel.DataAnnotations;

namespace UI_Tests.Entities
{
    class Account
    {
        [Display(Name = "Account Name")]
        [Required(AllowEmptyStrings = false)]
        public string AccountName { get; set; }

        [RegularExpression("Analyst|Customer|Investor")]
        public string Type { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
