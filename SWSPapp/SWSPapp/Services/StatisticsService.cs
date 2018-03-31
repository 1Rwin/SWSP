using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SWSPapp.Context;
using SWSPapp.Hubs;
using SWSPapp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using TableDependency;
using TableDependency.SqlClient;
using TableDependency.EventArgs;
using TableDependency.Enums;

namespace SWSPapp.Services
{
    public class StatisticsService : IDisposable
    {
        private readonly static Lazy<StatisticsService> _instance =
        new Lazy<StatisticsService>(() => new StatisticsService(GlobalHost.ConnectionManager.GetHubContext<JobHub>().Clients));

        public static StatisticsService Instance => _instance.Value;

        private IHubConnectionContext<dynamic> _clients;

        private SqlTableDependency<StatisticBasicModel> SqlTableDependency { get; }

        public StatisticsService(IHubConnectionContext<dynamic> clients) : this()
        {
            this._clients = clients;

            // because our C# model has a property not matching database table name, 
            // an explicit mapping is required just for this property
            var mapper = new ModelToTableMapper<StatisticBasicModel>();
            //if the property is different than in DB
            //mapper.AddMapping(x => x.Availability, "SeatsAvailability");

            // because our C# model name differs from table name we must specify table name
            this.SqlTableDependency = new SqlTableDependency<StatisticBasicModel>
                (ConfigurationManager.ConnectionStrings["SWSPContext"].ConnectionString, "player_statistic_changes");

            this.SqlTableDependency.OnChanged += this.TableDependency_OnChanged;
            this.SqlTableDependency.Start();
        }

        public StatisticsService()
        {
        }

        private void TableDependency_OnChanged(object sender, RecordChangedEventArgs<StatisticBasicModel> e)
        {
            switch (e.ChangeType)
            {
                case ChangeType.Insert:
                case ChangeType.Update:
                    this._clients.All.changeEntity(e.Entity.IdPlayer);
                    break;
            }
        }

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
                return context.Database.SqlQuery<StatisticBasicModel>("exec [dbo].[GetPlayersForUser] @userId", new SqlParameter("@userId", SessionPersister.User.Id)).Where(x => x.IsFavorite == 1).ToList();
            }
        }

        internal void AddPlayerToFavorites(int idUser, int idPlayer)
        {
            using (SWSPContext context = new SWSPContext())
            {
                context.Database.ExecuteSqlCommand("exec [dbo].[AddPlayerToFavorite] @userId, @playerId", new SqlParameter("@userId", idUser), new SqlParameter("@playerId", idPlayer));

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

        public List<StatisticBasicModel> GetReportForPlayerLineChart(int idPlayer)
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

        public List<StatisticBasicModel> GetReportForPlayerLineChartSignalR(int idPlayer)
        {
            var list = new List<StatisticBasicModel>();
            using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SWSPContext"].ConnectionString))
            {
                sqlConnection.Open();
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = $"SELECT * FROM player_statistic_changes where IdPlayer = {idPlayer}";

                    using (var sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            list.Add(new StatisticBasicModel
                            {
                                IdPlayer = Convert.ToInt32(sqlDataReader["IdPlayer"]),
                                Date = Convert.ToDateTime(sqlDataReader["Date"]),
                                Speed =  Convert.ToInt32(sqlDataReader["Speed"]),
                                Passing = Convert.ToInt32(sqlDataReader["Passing"]),
                                Dribble = Convert.ToInt32(sqlDataReader["Dribble"]),  
                                Attack = Convert.ToInt32(sqlDataReader["Attack"])
                            });                            
                        }
                    }
                }
                return list;
            }
        }


        public void Dispose()
        {
            this.SqlTableDependency.Stop();
        }
    }
}