using System.Collections.Generic;

namespace BusinessLayer.Models
{
    public class ActiveUsersChart : Chart
    {
        public ActiveUsersChart(Community community)
        {
            Community = community;
            DataPoints = new List<DataPoint>();
            ExportEnabled = true;
            AnimationEnabled = true;
            Title = "Active users";
            Type = "column";
            Theme = "light2";
        }

        public override void GenerateModel()
        {
            if (Community.PeapolisCollection != null) DataPoints.Add(new DataPoint("peapolis", Community.PeapolisCollection.FindAll(x => x.DeletedAt == null).Count));
            if (Community.FruitstarCollection != null) DataPoints.Add(new DataPoint("fruitstar", Community.FruitstarCollection.FindAll(x => x.DeletedAt == null).Count));
            if (Community.SeedsCollection != null) DataPoints.Add(new DataPoint("seeds", Community.SeedsCollection.FindAll(x => x.DeletedAt == null).Count));
        }
    }
}
