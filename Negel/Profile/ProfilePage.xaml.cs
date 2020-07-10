using MockTest.Models;
using Newtonsoft.Json;
using Plugin.CloudFirestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Negel.Profile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            GetData();
        }

        public async void GetData()
        {
            try
            {
                var query = await CrossCloudFirestore.Current
                                     .Instance
                                     .GetCollection("Users")
                                     .WhereEqualsTo("UserID", App.Current.Properties["UserId"].ToString())
                                     .GetDocumentsAsync();
                var c = query.Documents.ToList();


                string json = JsonConvert.SerializeObject(c[0].Data);
                ProfileData Data = (JsonConvert.DeserializeObject<ProfileData>(json));
                MainCollectionView.ItemsSource = Data.Data;
                MainIndicator.IsVisible = false;
            }
            catch (Exception j)
            {
                await DisplayAlert("No Data", "Start learning to see your scores", "Ok");
            }
        }
    }
}