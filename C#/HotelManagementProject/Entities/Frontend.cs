using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Manager.Entities
{
    [Table("frontend")]
    public class FrontendEntity
    {
        [Key]
        [StringLength(50)]
        public string user_name { get; set; }

        [StringLength(50)]
        public string pass_word { get; set; }
    }
}