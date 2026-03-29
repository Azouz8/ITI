using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Manager.Entities
{
    [Table("reservation")]
    public class ReservationEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string first_name { get; set; }

        [Required]
        [StringLength(50)]
        public string last_name { get; set; }

        [Required]
        [StringLength(50)]
        public string birth_day { get; set; }

        [Required]
        [StringLength(50)]
        public string gender { get; set; }

        [Required]
        [StringLength(50)]
        public string phone_number { get; set; }

        [Required]
        public string email_address { get; set; }

        [Required]
        public int number_guest { get; set; }

        [Required]
        public string street_address { get; set; }

        [Required]
        [StringLength(50)]
        public string apt_suite { get; set; }

        [Required]
        public string city { get; set; }

        [Required]
        [StringLength(50)]
        public string state { get; set; }

        [Required]
        [StringLength(10)]
        public string zip_code { get; set; }

        [Required]
        [StringLength(10)]
        public string room_type { get; set; }

        [Required]
        [StringLength(10)]
        public string room_floor { get; set; }

        [Required]
        [StringLength(10)]
        public string room_number { get; set; }

        [Required]
        public double total_bill { get; set; }

        [Required]
        [StringLength(10)]
        public string payment_type { get; set; }

        [Required]
        [StringLength(10)]
        public string card_type { get; set; }

        [Required]
        [StringLength(50)]
        public string card_number { get; set; }

        [Required]
        [StringLength(50)]
        public string card_exp { get; set; }

        [Required]
        [StringLength(10)]
        public string card_cvc { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime arrival_time { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime leaving_time { get; set; }

        [Required]
        public bool check_in { get; set; }

        [Required]
        public int break_fast { get; set; }

        [Required]
        public int lunch { get; set; }

        [Required]
        public int dinner { get; set; }

        [Required]
        public bool cleaning { get; set; }

        [Required]
        public bool towel { get; set; }

        [Required]
        public bool s_surprise { get; set; }

        [Required]
        public bool supply_status { get; set; }

        [Required]
        public int food_bill { get; set; }
    }
}