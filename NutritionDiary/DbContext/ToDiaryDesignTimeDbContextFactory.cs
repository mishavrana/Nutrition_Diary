using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using NutritionDiary.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionDiary.DbContexts
{
    public class ToDiaryDesignTimeDbContextFactory : IDesignTimeDbContextFactory<ToDiaryDbContext>
    {
        public ToDiaryDbContext CreateDbContext(string[] args)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite("Data Source=todiary.db").Options;
            return new ToDiaryDbContext(options);
        }
    }
}
