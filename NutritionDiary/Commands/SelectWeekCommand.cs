using NutritionDiary.Models;
using NutritionDiary.Stores;
using NutritionDiary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionDiary.Commands
{
    public class SelectWeekCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Diary _diary;
        private string _weekId;

        public string WeekId
        {
            get { return _weekId; }
            set { _weekId = value; }
        }


        private Week week => _diary.Weeks.Where(week => week.Id == _weekId).FirstOrDefault();
        public override void Execute(object? parameter)
        {
            WeekId = parameter?.ToString();
            _diary.CurrentWeek = week;
            _navigationStore.CurrentViewModel = new CurrentWeekViewModel(_navigationStore, _diary, week);
        }

        public SelectWeekCommand(NavigationStore navigationStore, Diary diary, string weekId)
        {
            _navigationStore = navigationStore;
            _weekId = weekId;
            _diary = diary;
        }
    }
}
