using NutritionDiary.Models;
using NutritionDiary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionDiary.Commands
{
    public class LoadBannedProductsCommand : AsyncCommandBase
    {
        private NutritionDiaryViewModel _viewModel;
        private readonly Diary _diary;

        public LoadBannedProductsCommand(NutritionDiaryViewModel viewModel, Diary diary)
        {
            _viewModel = viewModel;
            _diary = diary;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            IEnumerable<string> bannedProducts = await _diary.GetBannedProducts();
            _viewModel.BannedProducts = bannedProducts.ToList();
        }
    }
}
