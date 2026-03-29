using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Manager.Entities
{
    [Table("kitchen")]
    public class KitchenEntity
    {
        [Key]
        [StringLength(50)]
        public string user_name { get; set; }

        [StringLength(50)]
        public string pass_word { get; set; }
    }
}