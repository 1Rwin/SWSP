namespace SWSPapp.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("[players.statistics]")]
    public partial class players_statistics
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_stats { get; set; }

        public int id_player { get; set; }

        public int strength { get; set; }

        public int dexterity { get; set; }

        public int agility { get; set; }

        public int reflex { get; set; }

        public int speed { get; set; }

        public int endurance { get; set; }

        public int height { get; set; }

        public int weight { get; set; }

        [Required]
        [StringLength(5)]
        public string leg { get; set; }

        public int aggression { get; set; }

        public int stress_resist { get; set; }

        public int bravery { get; set; }

        public int hard_work { get; set; }

        public int defense { get; set; }

        public int tackle { get; set; }

        public int reception { get; set; }

        public int attack { get; set; }

        public int heading { get; set; }

        public int finishing { get; set; }

        public int free_kick { get; set; }

        public int penalty { get; set; }

        public int passing { get; set; }

        public int dribble { get; set; }

        public int game_with_ball { get; set; }

        public int game_without_ball { get; set; }

        public int goalkeeping { get; set; }

        public int penalty_save { get; set; }

        public virtual player player { get; set; }
    }
}
