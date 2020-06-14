using Negel.Models;
using Plugin.CloudFirestore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomQuiz.API;
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

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                var responseMessage = await APIHelper.APIClient.GetAsync("")
                TestData testData = Newtonsoft.Json.JsonConvert.DeserializeObject<TestData>(Jsondata);
                for (int i = 0; i < testData.Data.Count; i++)
                {
                    await CrossCloudFirestore.Current
                                 .Instance
                                 .GetCollection("Subjects")
                                 .GetDocument("SEPM")
                                 .GetCollection("Content")
                                 .AddDocumentAsync(testData.Data[i]);
                }
            }
                    
            catch(Exception h)
            {

            }
            
        }
    }
    public class TestData
    {
        public List<Content> Data { get; set; }
    }
}
