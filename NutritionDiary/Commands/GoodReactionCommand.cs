using NutritionDiary.Models;
using NutritionDiary.Services.WeekCreators;
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
    public class GoodReactionCommand : CommandBase
    {

        private readonly Week _week;
        private readonly CurrentWeekViewModel _weekViewModel;
        private IWeekCreator _weekCreator;
        public override void Execute(object? parameter)
        {

            List<string> listsRepresendableDaysAndReactions = new List<string>();
            _week.Reaction = Reaction.Good;
            _week.DaysAndReactions.Add(_week.CurrentDate.ToString(), _week.Reaction.ToString());
            foreach (var keyValuePair in _week.DaysAndReactions)
            {
                listsRepresendableDaysAndReactions.Add($"{keyValuePair.Key}: {keyValuePair.Value}");
            }
            _weekViewModel.DaysAndReactions = listsRepresendableDaysAndReactions;
        }

       /* public override Task ExecuteAsync(object parameter)
        {
            List<string> listsRepresendableDaysAndReactions = new List<string>();
            _week.Reaction = Reaction.Good;
            _week.DaysAndReactions.Add(_week.CurrentDate.ToString(), _week.Reaction.ToString());
            foreach (var keyValuePair in _week.DaysAndReactions)
            {
                listsRepresendableDaysAndReactions.Add($"{keyValuePair.Key}: {keyValuePair.Value}");
            }
            _weekViewModel.DaysAndReactions = listsRepresendableDaysAndReactions;
            await _weekCreator.CreateWeek(_week);
        }*/

        public GoodReactionCommand(Week week, CurrentWeekViewModel currentWeekViewModel, IWeekCreator weekCreator)
        {
            _week = week;
            _weekViewModel = currentWeekViewModel;  
            _weekCreator = weekCreator; 
        }   
    }
}
