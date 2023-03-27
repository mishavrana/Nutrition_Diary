using Microsoft.EntityFrameworkCore;
using NutritionDiary.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionDiary.DbContexts
{
    public class ToDiaryDbContext : DbContext
    {
        public ToDiaryDbContext(DbContextOptions options): base(options) 
        {
        }
        public DbSet<WeekDTO> Weeks { get; set; }
    }
}
