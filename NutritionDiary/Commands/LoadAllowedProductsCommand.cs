using NutritionDiary.Models;
using NutritionDiary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionDiary.Commands
{
    public class LoadAllowedProductsCommand: AsyncCommandBase
    {
        private NutritionDiaryViewModel _viewModel;
        private readonly Diary _diary;

        public LoadAllowedProductsCommand(NutritionDiaryViewModel viewModel, Diary diary)
        {
            _viewModel = viewModel;
            _diary = diary;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            IEnumerable<string> allowedProducts = await _diary.GetAllowedProducts();
            _viewModel.AllowedProducts = allowedProducts.ToList();
        }
    }
}
