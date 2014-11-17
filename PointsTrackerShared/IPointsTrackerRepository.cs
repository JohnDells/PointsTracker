using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointsTracker
{
    public interface IPointsTrackerRepository
    {
        int MaxPoints { get; set; }

        int GetPointsUsedToday();

        List<FoodEntry> GetFoodEntrySummary();

        List<FoodEntry> GetFoodEntries();

        void AddFoodEntry(FoodEntry foodEntry);
    }
}