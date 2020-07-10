using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MockTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InstructionsPage : ContentPage
    {
        ListOfQuiz QuizTestData;
        string Heading;
        public InstructionsPage(ListOfQuiz Data, string Head, string UserID)
        {
            InitializeComponent();
            Loader.Loader.userID(UserID);
            Heading = Head;
            QuizTestData = new ListOfQuiz() { Data = new List<Models.MockTestItem>() { } };
            Random random = new Random();
            int number;
            List<int> listNumbers = new List<int>() { };
            if (Data.Data.Count > 30)
            {
                for (int i = 0; i < 30; i++)
                {
                    do
                    {
                        number = random.Next(1, Data.Data.Count);
                    } while (listNumbers.Contains(number));
                    listNumbers.Add(number);
                    QuizTestData.Data.Add(Data.Data[number]);
                }
            }
            else
            {
                QuizTestData = Data;
            }
            
            //QuizTestData = Data;
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MockTestPage(QuizTestData, Heading));
        }
    }
}