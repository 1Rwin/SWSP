namespace SWSPapp.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("[players.history]")]
    public partial class players_history
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_history { get; set; }

        public int id_player { get; set; }

        public int id_club { get; set; }

        [Column(TypeName = "date")]
        public DateTime club_from { get; set; }

        [Column(TypeName = "date")]
        public DateTime club_to { get; set; }

        public int transfer_value { get; set; }

        public int id_currency { get; set; }

        public virtual dic_club dic_club { get; set; }

        public virtual dic_currency dic_currency { get; set; }

        public virtual player player { get; set; }
    }
}
