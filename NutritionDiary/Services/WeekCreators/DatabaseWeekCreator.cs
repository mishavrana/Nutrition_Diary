using Newtonsoft.Json;
using System.Text.Json;
using NutritionDiary.DbContexts;
using NutritionDiary.DTOs;
using NutritionDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using JsonSerializer = System.Text.Json.JsonSerializer;

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

               /* // create DaysAndReactionsDTO entities and add to DaysAndReactions table
                foreach (var dayAndReaction in week.DaysAndReactions)
                {
                    DaysAndReactionsDTO daysAndReactionsDTO = new DaysAndReactionsDTO
                    {
                        Id = weekDTO.Id,
                        Reaction = dayAndReaction.Value.ToString()
                    };
                    context.DaysAndReactions.Add(daysAndReactionsDTO);
                }
                await context.SaveChangesAsync();*/
            }
        }

        public async Task UpdateWeek(Week week)
        {
            using (ToDiaryDbContext context = _dbContextFactory.CreateDbContext())
            {
                WeekDTO weekDTO = ToWeekDTO(week);
                context.Weeks.Update(weekDTO);
                await context.SaveChangesAsync();
            }
        }

        private WeekDTO ToWeekDTO(Week week)
        {
            string daysAndReactionsJson = JsonConvert.SerializeObject(week.DaysAndReactions);

            return new WeekDTO()
            {
               Id = week.Id,
               StartDate = week.StartDate,
               EndDate = week.EndDate,
               Reaction = week.Reaction.ToString(),
               Product = week.Product,
               DaysAndReactionsJson = daysAndReactionsJson,
            };
        }
    }
}
