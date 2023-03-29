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

        private List<String> _allowedProducts;
        private List<String> _bannedProducts;

        private List<Week> _weeks;
        public List<Week> Weeks 
        { 
            get { return _weeks; } 
            set { _weeks = value; }
        }

        public IWeekCreator WeekCreator => _weekCreator;
        public IWeekProvider WeekProvider => _weekProvider;

        public Week CurrentWeek { get; set; }

        public Diary(IWeekProvider weekProvider, IWeekCreator weekCreator)
        {
            _weekProvider = weekProvider;
            _weekCreator = weekCreator;
        }


        //Get all Weeks with a provider
        public async Task<IEnumerable<Week>> GetAllWeeks()
        {
            return await _weekProvider.GetAllWeeks();
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

        // Adding banned product 
        public void AddBannedProduct(string product)
        {
            _bannedProducts.Add(product);
        }

        // Adding allowed product 
        public void AddAllowedProduct(string product)
        {
            _allowedProducts.Add(product);
        }

    }
}
