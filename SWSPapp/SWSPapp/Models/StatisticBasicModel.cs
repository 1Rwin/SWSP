using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWSPapp.Models
{
    public class StatisticBasicModel
    {
        public int IdPlayer { get; set; }       
        public int Speed { get; set; }
        public int Attack { get; set; }
        public int Passing { get; set; }
        public int Dribble { get; set; }
        public int Deffence { get; set; }
        public int Strength { get; set; }
        public string Name { get;  set; }
        public int IsFavorite { get; set; }

        [NotMapped]
        public DateTime Date { get; set; }
    }
}