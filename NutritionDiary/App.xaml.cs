using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using NutritionDiary.DbContexts;
using NutritionDiary.Models;
using NutritionDiary.Services.WeekCreators;
using NutritionDiary.Services.WeekProviders;
using NutritionDiary.Stores;
using NutritionDiary.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace NutritionDiary
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string CONNECTION_STRING = "Data Source=todiary.db";

        private readonly Diary _diary;
        private readonly NavigationStore _navigationStore;
        private readonly ToDiaryDbContextFactory _toDiaryDbContextFactory; 

        public App()
        {
            _toDiaryDbContextFactory = new ToDiaryDbContextFactory(CONNECTION_STRING);
            IWeekProvider weekProvider = new DatabaseWeekProvider(_toDiaryDbContextFactory);
            IWeekCreator weekCreator = new DatabaseWeekCreator(_toDiaryDbContextFactory);
         
            _diary = new Diary(weekProvider, weekCreator);
            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            
            using (ToDiaryDbContext dbContext = _toDiaryDbContextFactory.CreateDbContext())
            {
                

                dbContext.Database.Migrate();
            }

            _navigationStore.CurrentViewModel = NutritionDiaryViewModel.LoadViewModel(_navigationStore, _diary);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
