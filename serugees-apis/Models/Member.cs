using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Serugees.Apis.Models
{
    public class Member
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LoginName { get; set; }
        public bool IsActive {get; set;}
        public System.DateTime JoinDate{get;set;}
    }
}