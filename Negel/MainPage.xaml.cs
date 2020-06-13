using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Negel
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            MainCollectionView.ItemsSource = new ObservableCollection<string>()
            {
                "SEPM",
                "PDD",
                "COA",
                "Maths",
                "OOP",
                "C#",
                "Java",
                "Python"


            };
        }
    }
}
