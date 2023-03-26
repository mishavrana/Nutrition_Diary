using NutritionDiary.Commands;
using NutritionDiary.Models;
using NutritionDiary.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NutritionDiary.ViewModels
{
    public class NutritionDiaryViewModel : ViewModelBase
    {
        private readonly ObservableCollection<WeekViewModel> _weeks;
        private readonly Diary _diary;
        public IEnumerable<String> Weeks
        {
            get
            {
                List<String> weeksInStringRrpresantable = new List<String>();
                foreach (var week in _weeks)
                {
                    weeksInStringRrpresantable.Add($"{week.StartDate.ToString("d")}-{week.EndDate.ToString("d")}: {week.Product}");
                }
                return weeksInStringRrpresantable;
            }
        }

        private List<string> _startAndEndDays = new List<string>();
        public List<string> StartAndEndDays
        {
            get { return _startAndEndDays; }
        }

        private List<string> _allowedProducts = new List<string>();
        public List<string> AllowedProducts
        {
            get { return _allowedProducts; }
        }

        private List<string> _bannedProducts = new List<string>();
        public List<string> BannedProducts
        {
            get { return _bannedProducts; }
        }

        private string _selectedItem { get; set; }
        public string SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
                SelectWeek.Execute(_selectedItem);

            }
        }

        public ICommand AddNewWeek { get; }
        public ICommand SelectWeek { get; }

        public NutritionDiaryViewModel(NavigationStore navigationStore, Diary diary)
        {
            _diary = diary;
            _weeks = new ObservableCollection<WeekViewModel>();
            AddNewWeek = new AddNewWeekCommand(navigationStore, diary);
            SelectWeek = new SelectWeekCommand(navigationStore, diary, _selectedItem);

            UpdateWeeks();
            UpdateProducts();   
        }

        private void UpdateWeeks()
        {
            _weeks.Clear();
            foreach (var week in _diary.Weeks)
            {
                WeekViewModel weekViewModel = new WeekViewModel(week);
                _weeks.Add(weekViewModel);
            }
        }

        private void UpdateProducts()
        {
            foreach(Week week in _diary.Weeks)
            {
                if (week.EndDate == DateTime.Now)
                {
                    if (week.Reaction == Reaction.Good)
                    {
                        _allowedProducts.Add(week.Product);
                    }
                    else if (week.Reaction == Reaction.Bad)
                    {
                        _bannedProducts.Add(week.Product);
                    }
                }
            }
        }

    }
}
