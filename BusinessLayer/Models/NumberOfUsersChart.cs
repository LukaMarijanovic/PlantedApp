using System.Collections.Generic;

namespace BusinessLayer.Models
{
    public class NumberOfUsersChart : Chart
    {
        public NumberOfUsersChart(Community community)
        {
            ExportEnabled = true;
            AnimationEnabled = true;
            Title = "Number of users";
            Type = "column";
            Theme = "light2";
            DataPoints = new List<DataPoint>();
            Community = community;
        }

        public override void GenerateModel()
        {

            if (Community.PeapolisCollection != null) DataPoints.Add(new DataPoint("peapolis", Community.PeapolisCollection.Count));
            if (Community.FruitstarCollection != null) DataPoints.Add(new DataPoint("fruitstar", Community.FruitstarCollection.Count));
            if (Community.SeedsCollection != null) DataPoints.Add(new DataPoint("seeds", Community.SeedsCollection.Count));

        }
    }
}
