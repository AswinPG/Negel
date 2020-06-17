using Negel.Models;
using Negel.Notes;
using Plugin.CloudFirestore;
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
            GetData();
        }
        public async void GetData()
        {
            var Data = await CrossCloudFirestore.Current
                         .Instance
                         .GetCollection("Subjects")
                         .GetDocument("SEPM")
                         .GetCollection("Content")
                         .GetDocumentsAsync();
           var Test = Data.Documents.ToList();
            TestData testData = new TestData() { Data = new List<Models.Content>() { } };
            for(int i = 0; i < Test.Count; i++)
            {
                testData.Data.Add(new Models.Content()
                {
                    Heading = Test[i].Data["Heading"].ToString(),
                    Summary = Test[i].Data["Summary"].ToString()
                });
            }
            MainCollectionView.ItemsSource = testData.Data;
                         
        }

        private void MainCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MainCollectionView.SelectedItem != null)
            {
                Content data = e.CurrentSelection[0] as Content;
                Navigation.PushAsync(new NotesPage(data)); 
                MainCollectionView.SelectedItem = null;
            }
            else
            {

            }
        }
    }
}