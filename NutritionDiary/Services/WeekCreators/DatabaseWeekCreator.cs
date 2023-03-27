using NutritionDiary.DbContexts;
using NutritionDiary.DTOs;
using NutritionDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NutritionDiary.Services.WeekCreators
{
    public class DatabaseWeekCreator : IWeekCreator
    {
        private readonly ToDiaryDbContextFactory _dbContextFactory;

        public DatabaseWeekCreator(ToDiaryDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task CreateWeek(Week week)
        {
            using (ToDiaryDbContext context = _dbContextFactory.CreateDbContext())
            {
                WeekDTO weekDTO = ToWeekDTO(week);
                context.Weeks.Add(weekDTO);
                await context.SaveChangesAsync();
            }
        }

        private WeekDTO ToWeekDTO(Week week)
        {
            return new WeekDTO()
            {
                Id = week.Id,
               StartDate = week.StartDate,
               EndDate = week.EndDate,
               Reaction = week.Reaction.ToString(),
               Product = week.Product,
            };
        }
    }
}
