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
    public class CancelStartNewWeekCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Diary _diary;
        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = NutritionDiaryViewModel.LoadViewModel(_navigationStore, _diary);
        }

        public CancelStartNewWeekCommand(Diary diary, NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _diary = diary; 
        }
    }
}
