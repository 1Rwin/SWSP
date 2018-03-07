﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWSPapp.Models
{
    public class StatisticBasicModel
    {
        public int IdPlayer { get; set; }
        public DateTime Date { get; set; }
        public int Speed { get; set; }
        public int Attack { get; set; }
        public int Passing { get; set; }
        public int Dribble { get; set; }
        public int Deffence { get; set; }
        public int Strength { get; set; }

    }
}