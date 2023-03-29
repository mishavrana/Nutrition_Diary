using NutritionDiary.Models;
using NutritionDiary.Services.WeekCreators;
using NutritionDiary.Services.WeekProviders;
using NutritionDiary.Stores;
using NutritionDiary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NutritionDiary.Commands
{
    class DoneCommand : AsyncCommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Diary _diary;
        private readonly Week _week;

        public override async Task ExecuteAsync(object parameter)
        {
            await _diary.UpdateWeek(_week);
            _navigationStore.CurrentViewModel = NutritionDiaryViewModel.LoadViewModel(_navigationStore, _diary);
        }

        public DoneCommand(NavigationStore navigationStore, Diary diary, Week week)
        {
            _navigationStore = navigationStore;
            _diary = diary;
            _week = week;   
        }
    }
}
