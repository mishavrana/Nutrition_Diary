using NutritionDiary.Services.ProductsPorvidsers;
using NutritionDiary.Services.WeekCreators;
using NutritionDiary.Services.WeekProviders;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NutritionDiary.Models
{
    public class Diary
    {
        //private List<Week> _weeks;

        private IWeekProvider _weekProvider;
        private IWeekCreator _weekCreator;
        
        private IProductsProvider _bannedProductsProvider;
        private IProductsProvider _allowedProductsProvider;

        private List<Week> _weeks;
        public List<Week> Weeks 
        { 
            get { return _weeks; } 
            set { _weeks = value; }
        }

        public Diary(IWeekProvider weekProvider, IWeekCreator weekCreator, IProductsProvider bannedProductsProvider, IProductsProvider allowedProductsProvider)
        {
            _weekProvider = weekProvider;
            _weekCreator = weekCreator;
            _bannedProductsProvider = bannedProductsProvider;
            _allowedProductsProvider = allowedProductsProvider;
        }

        //Get all Weeks with a provider
        public async Task<IEnumerable<Week>> GetAllWeeks()
        {
            return await _weekProvider.GetAllWeeks();
        }

        // Get banned Products
        public async Task<IEnumerable<string>> GetBannedProducts()
        {
            return await _bannedProductsProvider.GetProducts();
        }

        // Get allowed Products
        public async Task<IEnumerable<string>> GetAllowedProducts()
        {
            return await _allowedProductsProvider.GetProducts();
        }

        // Adding a weeek
        public async Task StartNewWeek(Week week)
        {
            await _weekCreator.CreateWeek(week);
        }

        // Updating a week
        public async Task UpdateWeek(Week week)
        {
            await _weekCreator.UpdateWeek(week);
        }
    }
}
