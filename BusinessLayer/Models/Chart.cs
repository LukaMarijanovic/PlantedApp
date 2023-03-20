using System.Collections.Generic;

namespace BusinessLayer.Models
{
    public abstract class Chart
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public string ToolTipContent { get; set; }
        public string IndexLabel { get; set; }
        public string Theme { get; set; }
        public List<DataPoint> DataPoints { get; set; }
        public bool ExportEnabled { get; set; }
        public bool AnimationEnabled { get; set; }
        public Community Community { get; set; }

        public abstract void GenerateModel();
    }
}
