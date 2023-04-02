using NutritionDiary.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionDiary.Services.ProductsPorvidsers
{
    public class DatabaseAllowedProductsProvider: IProductsProvider
    {
        private readonly ToDiaryDbContextFactory _dbContextFactory;

        public DatabaseAllowedProductsProvider(ToDiaryDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<string>> GetProducts()
        {
            using (ToDiaryDbContext context = _dbContextFactory.CreateDbContext())
            {
                return context.Weeks
                                 .Where(row => row.Reaction == "Good")
                                 .Select(row => row.Product).ToList();
            }
        }
    }
}
