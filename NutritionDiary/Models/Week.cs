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
        public string Id => $"{StartDate.ToString("d")}: {Product!}";
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CurrentDate { get; set; }   
        public Dictionary<string, string> DaysAndReactions { get; set; }
        public Reaction Reaction { get; set; }
        public string Product { get; set; }
        public bool IsFinished { get; set; }

        public Week(DateTime startDate, string product, bool? isFinished, Dictionary<string, string>? daysAndReactions, string? reaction)
        {
            StartDate = startDate;
            EndDate = StartDate.AddDays(7);
            CurrentDate = DateTime.Now;
            Product = product;
            IsFinished = isFinished != null ? (bool)isFinished : false;

            switch(reaction)
            {
                case "Good": Reaction = Reaction.Good; break;
                case "Bad": Reaction = Reaction.Bad; break;
                default: Reaction = Reaction.Undifined; break;
            }
            DaysAndReactions = daysAndReactions == null ? new Dictionary<string, string>() : daysAndReactions;
        }
    }
}
