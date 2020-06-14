using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Negel.Subject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubjectDetailPage : ContentPage
    {
        public SubjectDetailPage()
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