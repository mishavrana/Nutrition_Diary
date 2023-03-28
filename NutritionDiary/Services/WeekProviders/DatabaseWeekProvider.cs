using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Newtonsoft.Json;
using NutritionDiary.DbContexts;
using NutritionDiary.DTOs;
using NutritionDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace NutritionDiary.Services.WeekProviders
{
    public class DatabaseWeekProvider : IWeekProvider
    {
        private readonly ToDiaryDbContextFactory _dbContextFactory;

        public DatabaseWeekProvider(ToDiaryDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<Week>> GetAllWeeks()
        {
            using (ToDiaryDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<WeekDTO> weekDTOs = await context.Weeks.ToListAsync();
                //IEnumerable<WeekDTO> weekDTOs = await context.Weeks.Include(w => w.DaysAndReactions).ToListAsync();
               

                IEnumerable<Week> weeks = weekDTOs.Select(x => ToWeek(x));
                
               
                //return weeks;
                return weekDTOs.Select(x => ToWeek(x));
            }
        }

        private static Week ToWeek(WeekDTO x)
        {
            Dictionary<string, string> daysAndReactions = JsonConvert.DeserializeObject<Dictionary<string, string>>(x.DaysAndReactionsJson)!;

            return new Week(x.StartDate, x.EndDate, x.Product, daysAndReactions, x.Reaction);
        }
    }
}
