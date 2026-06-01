using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoffeeTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPageCoffeeTrackerFlyout : ContentPage
    {
        public ListView ListView;

        public MasterDetailPageCoffeeTrackerFlyout()
        {
            InitializeComponent();

            BindingContext = new MasterDetailPageCoffeeTrackerFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class MasterDetailPageCoffeeTrackerFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterDetailPageCoffeeTrackerFlyoutMenuItem> MenuItems { get; set; }

            public MasterDetailPageCoffeeTrackerFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<MasterDetailPageCoffeeTrackerFlyoutMenuItem>(new[]
                {
                    new MasterDetailPageCoffeeTrackerFlyoutMenuItem { Id = 0, Title = "Coffee tracker", TargetType=typeof(MainPage)},
                    new MasterDetailPageCoffeeTrackerFlyoutMenuItem { Id = 1, Title = "Daily Intakes", TargetType=typeof(DailyIntakes)},
                    new MasterDetailPageCoffeeTrackerFlyoutMenuItem { Id = 2, Title = "Caffeine Information", TargetType=typeof(Information)},
                    new MasterDetailPageCoffeeTrackerFlyoutMenuItem { Id = 3, Title = "About", TargetType=typeof(About)},
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}