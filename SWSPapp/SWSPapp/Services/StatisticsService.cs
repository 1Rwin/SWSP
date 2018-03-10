using SWSPapp.Context;
using SWSPapp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace SWSPapp.Services
{
    public class StatisticsService
    {
        public StatisticBasicModel GetReportForPlayer(int idPlayer)
        {
            List<StatisticBasicModel> list = null;
            using (SWSPContext context = new SWSPContext())
            {
                list = context.Database.SqlQuery<StatisticBasicModel>("exec [dbo].[GetPlayersForUser] @userId", new SqlParameter("@userId", SessionPersister.User.Id)).ToList();              
            }

            return list.FirstOrDefault(x => x.IdPlayer == idPlayer);
        }

        public List<StatisticBasicModel> GetPlayersForUser()
        {
            using (SWSPContext context = new SWSPContext())
            {
                return context.Database.SqlQuery<StatisticBasicModel>("exec [dbo].[GetPlayersForUser] @userId", new SqlParameter("@userId", SessionPersister.User.Id)).Where(x=>x.IsFavorite == 1).ToList();
            }
        }

        internal void AddPlayerToFavorites(int idUser, int idPlayer)
        {
            using (SWSPContext context = new SWSPContext())
            {
                context.Database.ExecuteSqlCommand("exec [dbo].[AddPlayerToFavorite] @userId, @playerId", new SqlParameter("@userId", idUser), new SqlParameter("@playerId",idPlayer));
                
            }
        }

        internal void RemovePlayerFromFavorites(int idUser, int idPlayer)
        {
            using (SWSPContext context = new SWSPContext())
            {
                context.Database.ExecuteSqlCommand("exec [dbo].[RemovePlayerFromFavorite] @userId, @playerId", new SqlParameter("@userId", idUser), new SqlParameter("@playerId", idPlayer));
            }
        }

        public List<StatisticBasicModel> GetPlayersInfo(int id)
        {
            using (SWSPContext context = new SWSPContext())
            {
                var data = context.Database.SqlQuery<StatisticBasicModel>("exec [dbo].[GetPlayersForUser] @userId", new SqlParameter("@userId", id)).ToList();
                return data;
            }               
        }

        public List <StatisticBasicModel> GetReportForPlayerLineChart(int idPlayer)
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
                    Date = x.date.Value,
                    Attack = x.attack.Value,                  

                }).ToList();
            }
        }     
    }
}