using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoffeeTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoffeeList : ContentPage
    {
        public CoffeeList()
        {
            InitializeComponent();
        }
    }
}