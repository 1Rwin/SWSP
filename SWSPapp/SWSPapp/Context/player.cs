namespace SWSPapp.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class player
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public player()
        {
            players_history = new HashSet<players_history>();
            players_statistics = new HashSet<players_statistics>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_player { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [StringLength(50)]
        public string surname { get; set; }

        public int age { get; set; }

        [Column(TypeName = "date")]
        public DateTime birthdate { get; set; }

        public int id_country { get; set; }

        public int id_city { get; set; }

        [StringLength(50)]
        public string photo { get; set; }

        public int id_position { get; set; }

        public int attack { get; set; }

        public int dribble { get; set; }

        public int deffence { get; set; }

        public int speed { get; set; }

        public int strength { get; set; }

        public int passing { get; set; }

        public virtual dic_city dic_city { get; set; }

        public virtual dic_country dic_country { get; set; }

        public virtual dic_position dic_position { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<players_history> players_history { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<players_statistics> players_statistics { get; set; }
    }
}
