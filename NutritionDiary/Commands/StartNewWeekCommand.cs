using NutritionDiary.Models;
using NutritionDiary.Stores;
using NutritionDiary.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NutritionDiary.Commands
{
    public class StartNewWeekCommand : AsyncCommandBase
    {
        private readonly AddWeekViewModel _addWeekViewModel;
        private readonly Diary _diary;
        private readonly NavigationStore _navigationStore;

        public StartNewWeekCommand(AddWeekViewModel addWeekViewModel, Diary diary, NavigationStore navigationStore)
        {
            _diary = diary;
            _addWeekViewModel = addWeekViewModel;
            _navigationStore = navigationStore;
            _addWeekViewModel.PropertyChanged += OnViewModelPropertyChanged;

        }

        private void OnViewModelPropertyChanged(object sendet, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AddWeekViewModel.NewProduct))
            {
                OnCanExecutedChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_addWeekViewModel.NewProduct) && base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            Week week = new Week(_addWeekViewModel.StartDate, _addWeekViewModel.EndDate, _addWeekViewModel.NewProduct);
            try
            {
                await _diary.StartNewWeek(week);
                MessageBox.Show("Added new week!", "Error", MessageBoxButton.OK);
                _navigationStore.CurrentViewModel = NutritionDiaryViewModel.LoadViewModel(_navigationStore, _diary);

            }
            catch
            {
                MessageBox.Show("Product field is empty", "Error", MessageBoxButton.OK);
            }


        }
    }
}
