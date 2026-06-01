using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;

namespace CoffeeTracker
{
    public partial class MainPage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        //string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CoffeeRecord.txt");
        public MainPage()
        {
            InitializeComponent();
        }
        async void OnSaveRecord(object sender, EventArgs e)
        {
            /*var writerRecord = selectDate.Date.ToString("dd/MM/yyyy") +
                "\nSize of coffee: " + inputSize.Text + " OZ" +
                "\nCost: " + "RM " +inputCost.Text +
                "\nQuantity: " + inputQuantity.Text +
                "\nCaffein intake: " + outputIntake.Text + " mg" +
                "\nTotal Cost: " + "RM " + outputResult.Text +
                "\n";
            File.AppendAllText(fileName, writerRecord + Environment.NewLine);*/
            var selectdate = selectDate.Date.ToString("dd/MM/yyyy");
            var size = Double.Parse(inputSize.Text);
            var cost = Double.Parse(inputCost.Text);
            var quantity = Double.Parse(inputQuantity.Text);
            var intake = Double.Parse(outputIntake.Text);
            var total = Double.Parse(outputResult.Text);
            await firebaseHelper.AddRecord(selectdate, size, cost, quantity, intake, total);

            await DisplayAlert("Record Saved", "Caffeine Intake and Cost Spent has been saved", "OK");

        }


        void onDatePickerSelected(object sender, DateChangedEventArgs e)
        {
            var selectedDate = e.NewDate.ToString();
        }
        private async void OnInfoClicked(object sender, EventArgs args)
        {

             await Navigation.PushAsync(new CoffeeTracker.CoffeeList());

        }
        void OnCalculateCoffee(object sender, EventArgs e)
        {
            var label = 0.0;
            var size = 0.0;
            var cost = 0.0;
            var quantity = 0.0;
            var result = 0.0;
            var intake = 0.0;

            if ((Double.TryParse(inputLabel.Text, out label)) && (Double.TryParse(inputSize.Text, out size)) && (Double.TryParse(inputCost.Text, out cost)) && (Double.TryParse(inputQuantity.Text, out quantity)))
            {
                result = size * cost * quantity;
                outputResult.Text = string.Format("{0:##.00}", result);

                intake = label * size * quantity;
                outputIntake.Text = string.Format("{0:##.00}", intake);

            }
            else
            {
                outputResult.Text = "Please enter a valid value";
                outputIntake.Text = "Please enter a valid value";
            }

        }
        void OnReset(object sender, EventArgs e)
        {
            inputLabel.Text = null;
            inputSize.Text = null;
            inputCost.Text = null;
            inputQuantity.Text = null;
            outputResult.Text = "0.00";
            outputIntake.Text = "0.00";
        }


    }
}
