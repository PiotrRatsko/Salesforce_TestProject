using System.ComponentModel.DataAnnotations;

namespace API_TestFrameWork.Entities
{
    class Account
    {
        [Required(AllowEmptyStrings = false)]
        public string AccountName { get; set; }
        [RegularExpression("Analyst|Customer|Investor")]
        public string Type { get; set; }
        public string Description { get; set; }
    }
}
