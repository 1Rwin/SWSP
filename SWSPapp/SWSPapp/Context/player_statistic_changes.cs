namespace SWSPapp.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("[player.statistic.changes]")]
    public partial class player_statistic_changes
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int? id_player { get; set; }

        public DateTime? date { get; set; }

        public int? speed { get; set; }

        public int? attack { get; set; }

        public int? passing { get; set; }

        public int? dribble { get; set; }
    }
}
