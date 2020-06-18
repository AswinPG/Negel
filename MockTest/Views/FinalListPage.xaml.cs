using MockTest.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MockTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FinalListPage : ContentPage
    {
        public FinalListPage(ObservableCollection<FinalListData> finalListData)
        {
            InitializeComponent();
            MainCollectionView.ItemsSource = finalListData;
        }

        private void MainCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int current = ((FinalListData)e.CurrentSelection[0]).QNo - 1;
            Loader.Loader.Load(current);
            Navigation.PopAsync();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new ResultsPage());
        }
    }
}