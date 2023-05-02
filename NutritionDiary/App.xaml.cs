using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using NutritionDiary.DbContexts;
using NutritionDiary.Models;
using NutritionDiary.Services.ProductsPorvidsers;
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
using System.Windows.Controls;

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
            IProductsProvider bannedProductsProvider = new DatabaseBannedProductsProvider(_toDiaryDbContextFactory);
            IProductsProvider allowedProductsProvider = new DatabaseAllowedProductsProvider(_toDiaryDbContextFactory);
         
            _diary = new Diary(weekProvider, weekCreator, bannedProductsProvider, allowedProductsProvider);
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
            MainWindow.Resources.Add(typeof(Button), new Style(typeof(Button))
            {
                Setters = {
                new Setter(Button.PaddingProperty, new Thickness(10, 5, 10, 5)),
                new Setter(Button.MarginProperty, new Thickness(0, 5, 0, 5))
                }
            });

            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
