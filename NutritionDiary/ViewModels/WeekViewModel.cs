using NutritionDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionDiary.ViewModels
{
    public class WeekViewModel : ViewModelBase
    {
        private readonly Week _week;
        public string Product => _week.Product;
        public string Id => _week.Id;
        public DateTime StartDate => _week.StartDate;
        public DateTime EndDate => _week.EndDate;
        public string daysAndReactions { get; set; }  

        public WeekViewModel(Week week)
        {
            _week = week;
        }

    }
}
