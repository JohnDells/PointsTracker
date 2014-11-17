using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointsTracker
{
    public class SQLitePointsTrackerRepository : IPointsTrackerRepository
    {
        private static string _FileName = "PointsTrackerDB.db3";

        private static SQLiteConnection _SQLiteConnection = null;

        private static SQLitePointsTrackerRepository _Instance = null;
        private static readonly object syncLock = new object();
        private static readonly object databaseLock = new object();

        private SQLitePointsTrackerRepository()
        {
            _SQLiteConnection = new SQLiteConnection(DatabaseFilePath);
            _SQLiteConnection.CreateTable<PointsTrackerSetting>();
            _SQLiteConnection.CreateTable<FoodEntry>();
        }

        public static SQLitePointsTrackerRepository Instance
        {
            get
            {
                lock (syncLock)
                {
                    if (_Instance == null)
                    {
                        _Instance = new SQLitePointsTrackerRepository();
                    }
                    return _Instance;
                }
            }
        }
               
        public int MaxPoints
        {
            get { return GetSetting("MaxPoints").ToSafeNullableInt() ?? 0; }
            set { SaveSetting("MaxPoints", value.ToString()); }
        }

        public int GetPointsUsedToday()
        {
            var startDate = DateTime.Now.Date;
            var endDate = startDate.AddDays(1);
            var result = 0;
            lock (databaseLock)
            {
                result = _SQLiteConnection.Table<FoodEntry>().Where(x => x.Added >= startDate && x.Added < endDate).Sum(x => x.Points);
            }
            return result;
        }

        public List<FoodEntry> GetFoodEntries()
        {
            List<FoodEntry> result = null;
            lock (databaseLock)
            {
                result = _SQLiteConnection.Table<FoodEntry>().ToList();
            }
            return result;
        }

        //  TODO:  The GroupBy is doing an enumerable, not a TableQuery.  :(
        public List<FoodEntry> GetFoodEntrySummary()
        {
            return GetFoodEntries().GroupBy(x => x.Added.Date).Select(x => new FoodEntry() { Added = x.Key, Points = x.Sum(y => y.Points) }).ToList();
        }

        public void AddFoodEntry(FoodEntry foodEntry)
        {
            lock (databaseLock)
            {
                var result = _SQLiteConnection.Insert(foodEntry);
            }
        }

        private string GetSetting(string name)
        {
            var result = "";
            lock (databaseLock)
            {
                result = _SQLiteConnection.Table<PointsTrackerSetting>().Where(x => x.Name == name).Select(x => x.Value).FirstOrDefault();
            }
            return result;
        }

        private void SaveSetting(string name, string value)
        {
            lock (databaseLock)
            {            
                var item = _SQLiteConnection.Table<PointsTrackerSetting>().Where(x => x.Name == name).FirstOrDefault();
                if (item == null)
                {
                    item = new PointsTrackerSetting() { Name = name, Value = value };
                    _SQLiteConnection.Insert(item);
                }
                else
                {
                    item.Value = value;
                    _SQLiteConnection.Update(item);
                }
            }
        }
        
        public static string DatabaseFilePath
        {
            get
            {

#if NETFX_CORE
                var path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, _FileName);
#else

#if SILVERLIGHT
                // Windows Phone expects a local path, not absolute
                var path = _FileName;
#else

#if __ANDROID__
				// Just use whatever directory SpecialFolder.Personal returns
	            string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); ;
#else
				// we need to put in /Library/ on iOS5.1 to meet Apple's iCloud terms
				// (they don't want non-user-generated data in Documents)
				string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
				string libraryPath = Path.Combine (documentsPath, "../Library/"); // Library folder
#endif
				var path = Path.Combine (libraryPath, _FileName);
#endif

#endif
                return path;
            }
        }
    }
}
