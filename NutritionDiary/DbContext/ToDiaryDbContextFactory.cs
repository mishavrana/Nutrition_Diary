using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionDiary.DbContexts
{
    public class ToDiaryDbContextFactory
    {
        private string _connectionString;

        public ToDiaryDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ToDiaryDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(_connectionString).Options;
            return new ToDiaryDbContext(options);
        }
    }
}
