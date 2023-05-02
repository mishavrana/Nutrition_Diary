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
            var lastNote = _diary.Weeks.LastOrDefault();
            var canExecuteIfReactionIsBad = lastNote?.Reaction == Reaction.Bad && lastNote.EndDate.AddDays(5) <= DateTime.Now;
            var canExecuteIfDiaryIsEmpty = _diary.Weeks.Count == 0;
            var canExecuteIfProductIsInTesting = lastNote?.EndDate <= DateTime.Now;

            return canExecuteIfProductIsInTesting || canExecuteIfDiaryIsEmpty;
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
