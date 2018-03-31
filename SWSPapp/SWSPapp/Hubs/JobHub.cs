using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SWSPapp.Models;
using SWSPapp.Services;
using System.Collections.Generic;

namespace SWSPapp.Hubs
{
    [HubName("jobHub")]
    public class JobHub : Hub
    {
        private readonly StatisticsService _statsService;
        public JobHub() : this(StatisticsService.Instance) { }

        public JobHub(StatisticsService instance)
        {
            this._statsService = instance;
        }

        public List<StatisticBasicModel> GetReportForPlayer(int id)
        {
            return _statsService.GetReportForPlayerLineChartSignalR(id);
        }

    }
}