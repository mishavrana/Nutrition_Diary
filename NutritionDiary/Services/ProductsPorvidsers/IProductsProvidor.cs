using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionDiary.Services.ProductsPorvidsers
{
    public interface IProductsProvider
    {
        Task<IEnumerable<string>> GetProducts();
    }
}
