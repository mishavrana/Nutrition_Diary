using NutritionDiary.Models;
using NutritionDiary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionDiary.Commands
{
    public class LoadWeeksCommand : AsyncCommandBase
    {
        private NutritionDiaryViewModel _viewModel;
        private readonly Diary _diary;

        public LoadWeeksCommand(NutritionDiaryViewModel viewModel, Diary diary)
        {
            _viewModel = viewModel;
            _diary = diary;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            IEnumerable<Week> weeks = await _diary.GetAllWeeks();
            _viewModel.UpdateWeeks(weeks);
        }
    }
}
