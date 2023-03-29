using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionDiary.DTOs
{
    public class WeekDTO
    {
        [Key]
        public string Id {  get; set; } 
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; }
        public string Reaction { get; set; }    
        public string Product { get; set; }
        public string DaysAndReactionsJson { get; set; }
        public bool isFinished { get; set; }    
    }
}
