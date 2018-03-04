using SWSPapp.Context;
using SWSPapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SWSPapp.Services
{
    public class StatisticsService
    {
        public List<StatisticBasicModel> GetReportForPlayer(int idPlayer)
        {
            using (SWSPContext context = new SWSPContext())
            {
                var data = context.player_statistic_changes.Where(x => x.id_player == idPlayer).ToList();
                return data.Select(x => new StatisticBasicModel
                {
                    IdPlayer = x.id_player.Value,
                    Passing = x.passing.Value,
                    Dribble = x.dribble.Value,
                    Speed = x.speed.Value,
                    Attack = x.attack.Value,
                    Date = x.date.Value

                }).ToList();
            }
        }
    }
}