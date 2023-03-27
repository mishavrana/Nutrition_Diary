using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NutritionDiary.Models
{
    public class Week
    {
        public string Id => $"{StartDate.ToString("d")}-{EndDate.Date.ToString("d")}: {Product!}";
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CurrentDate { get; set; }   
        public IDictionary<DateTime, Reaction> DaysAndReactions { get; set; }
        public Reaction Reaction { get; set; }
        public string Product { get; set; }

        public Week(DateTime startDate, DateTime endDate, string product, string? reaction = null)
        {
            StartDate = startDate;
            EndDate = endDate;
            CurrentDate = DateTime.Now;
            Product = product;

            switch(reaction)
            {
                case "Good": Reaction = Reaction.Good; break;
                case "Bad": Reaction = Reaction.Bad; break;
                default: Reaction = Reaction.Undifined; break;
            }
            DaysAndReactions = new Dictionary<DateTime, Reaction>();
        }
    }
}
