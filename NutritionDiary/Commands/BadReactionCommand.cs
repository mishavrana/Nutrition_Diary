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
    internal class BadReactionCommand : CommandBase
    {
        private readonly Week _week;
        private readonly CurrentWeekViewModel _weekViewModel;
        public override void Execute(object? parameter)
        {
            List<string> listsRepresendableDaysAndReactions = new List<string>();
            _week.Reaction = Reaction.Bad;
            _week.DaysAndReactions.Add(_week.CurrentDate.ToString(), _week.Reaction.ToString());
            /*foreach(var keyValuePair in _week.DaysAndReactions)
            {
                listsRepresendableDaysAndReactions.Add($"{keyValuePair.Key}: {keyValuePair.Value}");
            }
            _weekViewModel.DaysAndReactions = listsRepresendableDaysAndReactions;*/
        }

        public  BadReactionCommand(Week week, CurrentWeekViewModel currentWeekViewModel)
        {
            _week = week;
            _weekViewModel = currentWeekViewModel;
        }
    }
}
