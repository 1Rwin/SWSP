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

            var list = new  List<StatisticBasicModel>()
            {
                new StatisticBasicModel()
                {
                    IdPlayer = 1,
                    Passing = 85,
                    Dribble = 90,
                    Speed = 85,
                    Attack = 89,
                    Deffence = 67,
                    Strength = 91
                },
                new StatisticBasicModel()
                {
                    IdPlayer = 2,
                    Passing = 77,
                    Dribble = 100,
                    Speed = 99,
                    Attack = 94,
                    Deffence = 64,
                    Strength = 88
                }
            };

            return list.Where(x => x.IdPlayer == idPlayer).ToList();

            //using (SWSPContext context = new SWSPContext())
            //{
            //    var data = context.player_statistic_changes.Where(x => x.id_player == idPlayer).ToList();
            //    return data.Select(x => new StatisticBasicModel
            //    {
            //        IdPlayer = x.id_player.Value,
            //        Passing = x.passing.Value,
            //        Dribble = x.dribble.Value,
            //        Speed = x.speed.Value,
            //        Attack = x.attack.Value,
            //        Date = x.date.Value

            //    }).ToList();
            //}
        }

    }
}