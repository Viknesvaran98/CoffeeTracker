using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace CoffeeTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Information : ContentPage
    {
        public Information()
        {
            InitializeComponent();
        }
        async void OnCoffeeClicked(object sender, EventArgs args)
        {

            await Browser.OpenAsync("https://www.medicalnewstoday.com/articles/324986", BrowserLaunchMode.SystemPreferred);

        }
    }
}