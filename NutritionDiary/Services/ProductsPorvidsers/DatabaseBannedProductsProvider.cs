using Microsoft.EntityFrameworkCore;
using NutritionDiary.DbContexts;
using NutritionDiary.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionDiary.Services.ProductsPorvidsers
{
    public class DatabaseBannedProductsProvider: IProductsProvider
    {
        private readonly ToDiaryDbContextFactory _dbContextFactory;

        public DatabaseBannedProductsProvider(ToDiaryDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<string>> GetProducts()
        {
            using (ToDiaryDbContext context = _dbContextFactory.CreateDbContext())
            {
                return context.Weeks
                                 .Where(row => row.Reaction == "Bad")
                                 .Select(row => row.Product).ToList();
            }
        }
    }
}
