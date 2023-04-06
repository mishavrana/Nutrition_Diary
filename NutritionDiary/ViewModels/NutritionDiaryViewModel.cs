using NutritionDiary.Commands;
using NutritionDiary.Models;
using NutritionDiary.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NutritionDiary.ViewModels
{
    public class NutritionDiaryViewModel : ViewModelBase
    {
        private readonly ObservableCollection<WeekViewModel> _weeks;
        private readonly Diary _diary;
        public IEnumerable<String> Weeks
        {
            get
            {
                List<String> weeksInStringRrpresantable = new List<String>();
                foreach (var week in _weeks.Reverse())
                {
                    weeksInStringRrpresantable.Add($"{week.StartDate.ToString("d")}: {week.Product!}");
                }
                return weeksInStringRrpresantable;
            }
        }

        private List<string> _allowedProducts = new List<string>();
        public List<string> AllowedProducts
        {
            get { return _allowedProducts; }
            set {  _allowedProducts = value; }  
        }

        private List<string> _bannedProducts = new List<string>();
        public List<string> BannedProducts
        {
            get { return _bannedProducts; }
            set { _bannedProducts = value; }
        }

        private string _selectedItem { get; set; }
        public string SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
                SelectWeek.Execute(_selectedItem);

            }
        }

        public ICommand AddNewWeek { get; }
        public ICommand SelectWeek { get; }
        public ICommand LoadWeeksCommand { get; }
        public ICommand LoadBannedProducts { get; }
        public ICommand LoadAllowedProducts {  get; }   


        public NutritionDiaryViewModel(NavigationStore navigationStore, Diary diary)
        {
            _diary = diary;
            _weeks = new ObservableCollection<WeekViewModel>();
            AddNewWeek = new AddNewWeekCommand(navigationStore, diary);
            SelectWeek = new SelectWeekCommand(navigationStore, diary, _selectedItem);
            LoadWeeksCommand = new LoadWeeksCommand(this, diary);
            LoadBannedProducts = new LoadBannedProductsCommand(this, diary);
            LoadAllowedProducts = new LoadAllowedProductsCommand(this, diary);


            //UpdateProducts();   
        }

        public static NutritionDiaryViewModel LoadViewModel(NavigationStore navigationStore, Diary diary)
        {
            NutritionDiaryViewModel viewModel = new NutritionDiaryViewModel(navigationStore, diary);
            viewModel.LoadWeeksCommand.Execute(null);
            viewModel.LoadBannedProducts.Execute(null);
            viewModel.LoadAllowedProducts.Execute(null);    
            return viewModel;
        }

        public void UpdateWeeks(IEnumerable<Week> weeks)
        {
            _weeks.Clear();
            _diary.Weeks = weeks.ToList();
            foreach (var week in weeks)
            {
                WeekViewModel weekViewModel = new WeekViewModel(week);
                _weeks.Add(weekViewModel);
                
            }
        }

    }
}
