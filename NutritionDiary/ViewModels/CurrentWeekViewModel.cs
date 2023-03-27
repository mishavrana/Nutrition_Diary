using NutritionDiary.Commands;
using NutritionDiary.Models;
using NutritionDiary.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NutritionDiary.ViewModels
{
    public class CurrentWeekViewModel : ViewModelBase
    {

        private List<string> _daysAndReactions;
        public List<string> DaysAndReactions
        {
            get
            {
                return _daysAndReactions;
            }
            set
            {
               _daysAndReactions = value;
               OnPropertyChanged(nameof(DaysAndReactions));
            }
        }

        private string _currentWeekNumber;
        public string CurrentWeekNumber
        {
            get { return _currentWeekNumber; }
            set
            {
                _currentWeekNumber = value;
                OnPropertyChanged(nameof(CurrentWeekNumber));
            }
        }

        private string _currentProduct;
        public string CurrentProduct
        {
            get { return _currentProduct; }
            set
            {
                _currentProduct = value;
                OnPropertyChanged(nameof(CurrentProduct));
            }
        }

        private DateTime _currentDate = DateTime.Now;
        public DateTime CurrentDate
        {
            get { return _currentDate; }
            set
            {
                _currentDate = value;
                OnPropertyChanged(nameof(CurrentDate));
            }
        }

        public ICommand GoodReaction { get; }
        public ICommand BadReaction { get; }
        public ICommand Done { get; }
        public CurrentWeekViewModel(NavigationStore navigationStore, Diary diary, Week week)
        {
            GoodReaction = new GoodReactionCommand(week, this);
            BadReaction = new BadReactionCommand(week, this);
            Done = new DoneCommand(navigationStore, diary);
 
            _currentWeekNumber = week.Id;
            _currentProduct = week.Product;

            _daysAndReactions = new List<string>();
            /*foreach (var note in week.DaysAndReactions)
            {
                _daysAndReactions.Add($"{note.Key}: {note.Value}");
            }*/
        }
    }
}
