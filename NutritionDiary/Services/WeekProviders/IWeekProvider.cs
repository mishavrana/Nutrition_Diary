using NutritionDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionDiary.Services.WeekProviders
{
    public interface IWeekProvider
    {
        Task<IEnumerable<Week>> GetAllWeeks();
    }
}
