using NutritionDiary.Stores;
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
        public override void Execute(object? parameter)
        {
            // _navigationStore.CurrentViewModel = new NutritionDiaryViewModel(_navigationStore);
        }

        public CancelStartNewWeekCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }
    }
}
