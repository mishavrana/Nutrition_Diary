﻿using NutritionDiary.Models;
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
        public override void Execute(object? parameter)
        {
            List<string> daysAndReactionsStringRepresentable = new List<string>();  
            _week.DaysAndReactions.Add(_week.CurrentDate, Reaction.Good);
            foreach(var note in _week.DaysAndReactions)
            {
                daysAndReactionsStringRepresentable.Add($"{note.Key}: {note.Value}");
            }
            _weekViewModel.DaysAndReactions = daysAndReactionsStringRepresentable;
        }

        public GoodReactionCommand(Week week, CurrentWeekViewModel currentWeekViewModel)
        {
            _week = week;
            _weekViewModel = currentWeekViewModel;  
        }   
    }
}