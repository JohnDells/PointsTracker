using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointsTracker
{
    /// <summary>
    /// This singleton repository is only a mock and should not be used for production.
    /// </summary>
    public sealed class DummyPointsTrackerRepository : IPointsTrackerRepository
    {
        private static DummyPointsTrackerRepository _Instance = null;
        private static readonly object syncLock = new object();

        private DummyPointsTrackerRepository()
        {
        }

        public static DummyPointsTrackerRepository Instance
        {
            get
            {
                lock (syncLock)
                {
                    if (_Instance == null)
                    {
                        _Instance = new DummyPointsTrackerRepository();
                    }
                    return _Instance;
                }
            }
        }
        
        private int _MaxPoints = 32;

        public int MaxPoints
        {
            get { return _MaxPoints; }
            set { _MaxPoints = value; }
        }

        public int GetPointsUsedToday()
        {
            var now = DateTime.Now.Date;
            return _FoodEntries.Where(x => x.Added.Date == now).Sum(x => x.Points);
        }

        private List<FoodEntry> _FoodEntries = new List<FoodEntry>();

        public List<FoodEntry> GetFoodEntries()
        {
            return _FoodEntries;
        }

        public List<FoodEntry> GetFoodEntrySummary()
        {
            return _FoodEntries.GroupBy(x => x.Added.Date).Select(x => new FoodEntry() { Added = x.Key, Points = x.Sum(y => y.Points) }).ToList();
        }

        public void AddFoodEntry(FoodEntry foodEntry)
        {
            _FoodEntries.Add(foodEntry);
        }
    }
}
