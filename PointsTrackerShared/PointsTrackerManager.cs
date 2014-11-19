using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointsTracker
{
    public class PointsTrackerManager
    {
        private IPointsTrackerRepository _PointsTrackerRepository = null;

        public PointsTrackerManager()
        {
            _PointsTrackerRepository = SQLitePointsTrackerRepository.Instance;
        }

        public int GetMaxPoints()
        {
            return _PointsTrackerRepository.MaxPoints;
        }

        public void SetMaxPoints(int value)
        {
            _PointsTrackerRepository.MaxPoints = value;
        }

        public int GetPointsUsedToday()
        {
            return _PointsTrackerRepository.GetPointsUsedToday();
        }

        public int GetPointsLeftToday()
        {
			var maxPoints = GetMaxPoints ();
			var pointsUsedToday = GetPointsUsedToday ();
			return maxPoints - pointsUsedToday;
        }

        public void AddPoints(FoodEntry foodEntry)
        {
            _PointsTrackerRepository.AddFoodEntry(foodEntry);
        }

        public List<FoodEntry> GetFoodEntrySummary()
        {
            return _PointsTrackerRepository.GetFoodEntrySummary();
        }

        public List<FoodEntry> GetFoodEntries()
        {
            return _PointsTrackerRepository.GetFoodEntries();
        }

    }
}
