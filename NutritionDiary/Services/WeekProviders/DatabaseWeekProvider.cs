using Microsoft.EntityFrameworkCore;
using NutritionDiary.DbContexts;
using NutritionDiary.DTOs;
using NutritionDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                return weekDTOs.Select(x => ToWeek(x));
            }
        }

        private static Week ToWeek(WeekDTO x)
        {
            return new Week(x.StartDate, x.EndDate, x.Product, x.Reaction);
        }
    }
}
