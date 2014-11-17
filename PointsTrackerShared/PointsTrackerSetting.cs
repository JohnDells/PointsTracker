using System;
using System.Collections.Generic;
using System.Text;

namespace PointsTracker
{
    public class PointsTrackerSetting
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }     
    }
}
