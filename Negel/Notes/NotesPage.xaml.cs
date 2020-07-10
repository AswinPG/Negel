using MockTest.Models;
using MockTest.Views;
using Negel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Negel.Notes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotesPage : ContentPage
    {
        ListOfQuiz ListOfQuiz;
        public NotesPage(Content content, ListOfQuiz QuizTest)
        {
            InitializeComponent();
            TitleLabel.Text = content.Heading;
            DetailLabel.Text = content.Summary;
            ListOfQuiz = new ListOfQuiz() { Data = new List<MockTestItem>() { } };
            var result = QuizTest.Data.FindAll(x => x.Heading == content.Heading);
            for(int i = 0; i < result.Count; i++)
            {
                ListOfQuiz.Data.Add(result[i]);
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InstructionsPage(ListOfQuiz,ListOfQuiz.Data[0].Heading, App.Current.Properties["UserId"].ToString()));
        }
    }
}