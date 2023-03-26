using NutritionDiary.Models;
using NutritionDiary.Stores;
using NutritionDiary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NutritionDiary.Commands
{
    public class AddNewWeekCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Diary _diary;

        public override bool CanExecute(object? parameter)
        {
            return (_diary.Weeks.Count() > 0 && _diary.Weeks.Last()?.EndDate < DateTime.Now) ||
                _diary.Weeks.Count() == 0;
        }
        public override void Execute(object? parameter)
        {
            try
            {
                _navigationStore.CurrentViewModel = new AddWeekViewModel(_diary, _navigationStore);
            }
            catch
            {
                MessageBox.Show("Previous week is not finished!", "Error", MessageBoxButton.OK);
            }

        }

        public AddNewWeekCommand(NavigationStore navigationStore, Diary diary)
        {
            _navigationStore = navigationStore;
            _diary = diary;
        }
    }
}
