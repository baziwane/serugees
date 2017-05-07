using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Serugees.Apis.Models
{
    public class Loan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LoanId { get; set; }
        public int Amount { get; set; }
        public int DurationInMonths { get; set; }
        public System.DateTime DateRequested { get; set; }
        public int MemberId{get;set;}
        public bool IsActive { get; set; }
    }
}