using BusinessLayer.Models;
using System;

namespace PlantedApp.Factory
{
    public class ChartFactory
    {
        public static Chart ChartBuilder(string chartType, Community community)
        {
            switch (chartType)
            {
                case "numberOfUsers":
                    return new NumberOfUsersChart(community); 
                case "usersPercentage":
                    return new PercentChart(community);
                case "activeUsers": 
                    return new ActiveUsersChart(community);
                default: 
                    throw new ArgumentOutOfRangeException(nameof(chartType));
            }
        }
    }
}