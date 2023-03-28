using NutritionDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionDiary.Services.WeekCreators
{
    public interface IWeekCreator
    {
        Task CreateWeek(Week week);
        Task UpdateWeek(Week week); 
    }
}
