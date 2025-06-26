using System.ComponentModel.DataAnnotations.Schema;

namespace CQRSExample.Models
{
    [Table("tbl_Users")]
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
