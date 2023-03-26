using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionDiary.Models
{
    public class Diary
    {
        private List<Week> _weeks;
        private List<String> _allowedProducts;
        private List<String> _bannedProducts;

        public List<Week> Weeks { get { return _weeks; } }
        public Diary()
        {
            _weeks = new List<Week>();
            _allowedProducts = new List<String>();
            _bannedProducts = new List<String>();
        }

        // Adding a weeek
        public void StartNewWeek(Week week)
        {
            _weeks.Add(week);
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
