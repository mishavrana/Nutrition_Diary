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
            _week.Reaction = Reaction.Bad;
            _week.EndDate = DateTime.Now;
            _week.IsFinished = true;

            // Check if the is a key for this day in dictionary
            var key = _week.CurrentDate.ToString("d");

            if (_week.DaysAndReactions.ContainsKey(key))
            {
                _week.DaysAndReactions[key] = _week.Reaction.ToString();
            }
            else
            {
                _week.DaysAndReactions.Add(_week.CurrentDate.ToString("d"), _week.Reaction.ToString());
            }

            // Representing DaysAndReactions in string for the view model
            List<string> listsRepresendableDaysAndReactions = new List<string>();
            foreach (var keyValuePair in _week.DaysAndReactions)
            {
                listsRepresendableDaysAndReactions.Add($"{keyValuePair.Key}: {keyValuePair.Value}");
            }
            _weekViewModel.DaysAndReactions = listsRepresendableDaysAndReactions;
        }

        public override bool CanExecute(object? parameter)
        {
            return _week.IsFinished != true;
        }

        public  BadReactionCommand(Week week, CurrentWeekViewModel currentWeekViewModel)
        {
            _week = week;
            _weekViewModel = currentWeekViewModel;
        }
    }
}
