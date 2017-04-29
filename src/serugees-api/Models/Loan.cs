using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace serugees_api.Models
{
    public class Loan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LoansId { get; set; }
        public int Amount { get; set; }
        public int DurationInMonths { get; set; }
        public string DateRequested { get; set; }
        public int MembersId{get;set;}
        public bool IsActive { get; set; }
    }
}