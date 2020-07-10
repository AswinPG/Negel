using MockTest.Models;
using MockTest.Views;
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
        ListOfQuiz QuizTestData;
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
            TestData testData = new TestData() { Data = new ObservableCollection<Content>() { } };
            MainCollectionView.ItemsSource = testData.Data;
            MainIndicator.IsVisible = false;
            for (int i = 0; i < Test.Count; i++)
            {
                testData.Data.Add(new Models.Content()
                {
                    Heading = Test[i].Data["Heading"].ToString(),
                    Summary = Test[i].Data["Summary"].ToString()
                });
            }
            


            var QuizData = await CrossCloudFirestore.Current
                         .Instance
                         .GetCollection("Subjects")
                         .GetDocument("SEPM")
                         .GetCollection("Quiz")
                         .GetDocumentsAsync();
            var QuizTest = QuizData.Documents.ToList();
            QuizTestData = new ListOfQuiz() { Data = new List<MockTestItem>{ }  };
            for (int i = 0; i < QuizTest.Count; i++)
            {
                QuizTestData.Data.Add(new MockTestItem()
                {
                    Options = new List<string>()
                    {
                        QuizTest[i].Data["Opt1"].ToString(),QuizTest[i].Data["Opt2"].ToString(),QuizTest[i].Data["Opt3"].ToString(),QuizTest[i].Data["Opt4"].ToString()
                    },
                    Question = QuizTest[i].Data["Question"].ToString(),
                    Answer = QuizTest[i].Data["Ans"].ToString(),
                    Heading = QuizTest[i].Data["Heading"].ToString()
                });
            }

        }

        private void MainCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MainCollectionView.SelectedItem != null)
            {
                Content data = e.CurrentSelection[0] as Content;

                Navigation.PushAsync(new NotesPage(data,QuizTestData)); 
                MainCollectionView.SelectedItem = null;
            }
            else
            {

            }
        }

        private void TestClicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new InstructionsPage(QuizTestData,"General", App.Current.Properties["UserId"].ToString()));

        }
    }
}