using System.Collections.Generic;

namespace BusinessLayer.Models
{
    public class PercentChart : Chart
    {
        public PercentChart(Community community)
        {
            Community = community;
            DataPoints = new List<DataPoint>();
            ExportEnabled = true;
            AnimationEnabled = true;
            Title = "Percentage of users";
            Type = "pie";
            Theme = "light2";
            ToolTipContent = "<b>{label}</b>: {y}%";
            IndexLabel = "{label} - {y}%";
        }

        public override void GenerateModel()
        {
            double communities = GetCommunitiesTotalMembers(Community);

            if (Community.PeapolisCollection != null) DataPoints.Add(new DataPoint("peapolis", CalculatePercentage(Community.PeapolisCollection.Count, communities)));
            if (Community.FruitstarCollection != null) DataPoints.Add(new DataPoint("fruitstar", CalculatePercentage(Community.FruitstarCollection.Count, communities)));
            if (Community.SeedsCollection != null) DataPoints.Add(new DataPoint("seeds", CalculatePercentage(Community.SeedsCollection.Count, communities)));
        }

        private static double GetCommunitiesTotalMembers(Community community)
        {
            double communities = 0;
            if (community.PeapolisCollection != null)
            {
                communities += community.PeapolisCollection.Count;
            }
            if (community.FruitstarCollection != null)
            {
                communities += community.FruitstarCollection.Count;
            }
            if (community.SeedsCollection != null)
            {
                communities += community.SeedsCollection.Count;
            }

            return communities;
        }

        private static double CalculatePercentage(double value, double totalValue)
        {
            var percent = (value / totalValue) * 100;
            return percent;
        }

        
    }
}
