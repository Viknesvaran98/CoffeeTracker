using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace CoffeeTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DailyIntakes : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        // string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CoffeeRecord.txt");

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            displayRecord.ItemsSource = await firebaseHelper.GetAllBmiRecord();
        }

        public DailyIntakes()
        {
            InitializeComponent();
            //displayRecord.Text = File.ReadAllText(fileName);
        }
    }
}