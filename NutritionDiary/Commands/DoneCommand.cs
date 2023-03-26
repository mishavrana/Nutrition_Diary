using NutritionDiary.Models;
using NutritionDiary.Stores;
using NutritionDiary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NutritionDiary.Commands
{
    class DoneCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Diary _diary;

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = new NutritionDiaryViewModel(_navigationStore, _diary);
        }

        public DoneCommand(NavigationStore navigationStore, Diary diary)
        {
            _navigationStore = navigationStore;
            _diary = diary;
        }
    }
}
