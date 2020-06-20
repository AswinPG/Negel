using MockTest.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MockTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MockTestPage : ContentPage
    {
        string url = "https://us-central1-race2ias-8c17d.cloudfunctions.net/Quiz";
        public ListOfQuiz items;
        public ObservableCollection<FinalListData> finalListDatas;
        public int Current = 0;
        public int score = 0;
        public int wrong = 0;
        Stopwatch stopwatch;
        //string Did;
        public MockTestPage(ListOfQuiz QuizTestData)
        {
            InitializeComponent();
            //Did = Id;

            ActivityRunner.IsVisible = true;
            items = QuizTestData;
            finalListDatas = new ObservableCollection<FinalListData>() { };
            CallAPI();
            stopwatch = new Stopwatch();
            Loader.Loader.SetMP(this);

        }

        public async void CallAPI()
        {
            try
            {
                //Req sReq = new Req() {DocID = Did};
                //var responseMessage = await APIHelper.APIClient.PostAsJsonAsync("https://us-central1-estudo-af035.cloudfunctions.net/MockTestDisplay", sReq);
                //var s = await responseMessage.Content.ReadAsStringAsync();
                //items = await responseMessage.Content.ReadAsAsync<ListOfQuiz>();
                UpdateQuestions(Current);



                //Test
                for (int i = 0; i < items.Data.Count; i++)
                {
                    finalListDatas.Add(new FinalListData() { AttendedColour = Color.DarkGray, QNo = +(i + 1) });
                }




                NextButton.IsEnabled = true;
                QTotal.Text = " /" + items.Data.Count.ToString();

                MainView.IsVisible = true;
                ActivityRunner.IsVisible = false;

            }
            catch (Exception e)
            {
                await DisplayAlert("No Internet", "Cannot Reach Server. Check Your internet connection", "Ok");
                await Navigation.PopAsync();
            }
        }


        public void History(int i)
        {
            
            if (items.Data[i].Choosen == 0)
            {
            }
            else if (items.Data[i].Choosen == 1)
            {
                OptionALabel.TextColor = Color.White;
                OptionAFrame.BackgroundColor = Color.FromHex("#320EFF");

            }
            else if (items.Data[i].Choosen == 2)
            {
                OptionBLabel.TextColor = Color.White;
                OptionBFrame.BackgroundColor = Color.FromHex("#320EFF");

            }
            else if (items.Data[i].Choosen == 3)
            {
                OptionCLabel.TextColor = Color.White;
                OptionCFrame.BackgroundColor = Color.FromHex("#320EFF");

            }
            else if (items.Data[i].Choosen == 4)
            {
                OptionDLabel.TextColor = Color.White;
                OptionDFrame.BackgroundColor = Color.FromHex("#320EFF");

            }
        }

        public void ColourAllWhite()
        {
            OptionAFrame.BackgroundColor = Color.FromHex("#413CA0");
            OptionBFrame.BackgroundColor = Color.FromHex("#413CA0");
            OptionCFrame.BackgroundColor = Color.FromHex("#413CA0");
            OptionDFrame.BackgroundColor = Color.FromHex("#413CA0");
            OptionALabel.TextColor = Color.White;
            OptionBLabel.TextColor = Color.White;
            OptionCLabel.TextColor = Color.White;
            OptionDLabel.TextColor = Color.White;
        }

        public void Animate()
        {
            
            Device.BeginInvokeOnMainThread(async () =>
            {
                QuestionLabel.Scale = 0;
                OptionAFrame.Scale = 0;
                OptionBFrame.Scale = 0;
                OptionCFrame.Scale = 0;
                OptionDFrame.Scale = 0;
                await QuestionLabel.ScaleTo(1,160);
                await OptionAFrame.ScaleTo(1, 160);

                await OptionBFrame.ScaleTo(1, 160);

                await OptionCFrame.ScaleTo(1, 160); 

                await OptionDFrame.ScaleTo(1, 160); 
            });
            
        }


        public void UpdateQuestions(int i)
        {
            Animate();
            int x = i + 1;
            QNumLabel.Text = "Question" + " " + x;
            
            NextButton.Text = "Skip";
            //ImageLayout.Source = items.Data[i].ImgUrl;
            OptionAFrame.BackgroundColor = Color.Transparent;
            OptionBFrame.BackgroundColor = Color.Transparent;
            OptionCFrame.BackgroundColor = Color.Transparent;
            OptionDFrame.BackgroundColor = Color.Transparent;

            QuestionLabel.Text = items.Data[i].Question;
            OptionALabel.Text = items.Data[i].Options[0];
            OptionBLabel.Text = items.Data[i].Options[1];
            OptionCLabel.Text = items.Data[i].Options[2];
            OptionDLabel.Text = items.Data[i].Options[3];
            //ParaLabel.Text = items.Data[i].Paragraph;

            OptionAFrame.IsEnabled = true;
            OptionBFrame.IsEnabled = true;
            OptionCFrame.IsEnabled = true;
            OptionDFrame.IsEnabled = true;
            ColourAllWhite();

            History(i);
        }

        

        private void OptionATapped(object sender, EventArgs e)
        {
            finalListDatas[Current].AttendedColour = Color.FromHex("#320EFF");
            ColourAllWhite();
            NextButton.Text = "Next";
            OptionAFrame.BackgroundColor = Color.FromHex("#320EFF");
            OptionALabel.TextColor = Color.White;
            items.Data[Current].Choosen = 1;
            if (items.Data[Current].Answer == OptionALabel.Text)
            {
                score++;
                finalListDatas[Current].CorrectOrNot = 1;
            }
            else
            {
                wrong++;
                finalListDatas[Current].CorrectOrNot = 2;
            }

        }

        private void OptionBTapped(object sender, EventArgs e)
        {
            finalListDatas[Current].AttendedColour = Color.FromHex("#320EFF");
            ColourAllWhite();
            NextButton.Text = "Next";
            OptionBFrame.BackgroundColor = Color.FromHex("#320EFF");
            OptionBLabel.TextColor = Color.White;
            items.Data[Current].Choosen = 2;

            if (items.Data[Current].Answer == OptionBLabel.Text)
            {
                score++;
                finalListDatas[Current].CorrectOrNot = 1;
            }
            else
            {
                wrong++;
                finalListDatas[Current].CorrectOrNot = 2;
            }
        }

        private void OptionCTapped(object sender, EventArgs e)
        {
            finalListDatas[Current].AttendedColour = Color.FromHex("#320EFF");
            ColourAllWhite();
            NextButton.Text = "Next";
            OptionCFrame.BackgroundColor = Color.FromHex("#320EFF");
            OptionCLabel.TextColor = Color.White;
            items.Data[Current].Choosen = 3;

            if (items.Data[Current].Answer == OptionCLabel.Text)
            {
                score++;
                finalListDatas[Current].CorrectOrNot = 1;
            }
            else
            {
                wrong++;
                finalListDatas[Current].CorrectOrNot = 2;
            }
        }

        private void OptionDTapped(object sender, EventArgs e)
        {
            finalListDatas[Current].AttendedColour = Color.FromHex("#320EFF");
            ColourAllWhite();
            NextButton.Text = "Next";
            OptionDFrame.BackgroundColor = Color.FromHex("#320EFF");
            OptionDLabel.TextColor = Color.White;
            items.Data[Current].Choosen = 4;

            if (items.Data[Current].Answer == OptionDLabel.Text)
            {
                score++;
                finalListDatas[Current].CorrectOrNot = 1;
            }
            else
            {
                wrong++;
                finalListDatas[Current].CorrectOrNot = 2;
            }
        }

        private async void Complete_Tapped(object sender, EventArgs e)
        {
            bool del = await DisplayAlert("Are you sure ?", "Completing the quiz will save the current state of the score. Want to complete now ?", "Yes", "No");
            if (del)
            {

            }
        }

        private void PreviousButton_Clicked(object sender, EventArgs e)
        {
            if (Current >0)
            {
                UpdateQuestions(--Current);
            }
            else
            {
            }
        }
        private async void NextButton_Clicked(object sender, EventArgs e)
        {
            if (Current < items.Data.Count - 1)
            {
                UpdateQuestions(++Current);
            }
            else
            {


            }

        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FinalListPage(finalListDatas));
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            ParaLayout.IsVisible = false;
        }

        private void ShowParaTapped(object sender, EventArgs e)
        {
            ParaLayout.IsVisible = true;
            if(ParaLabel.Text == "" || ParaLabel.Text == null)
            {
                ParaLabel.Text = "This is not a paragraph based question";
            }
        }
    }
    public class ListOfQuiz
    {
        public List<MockTestItem> Data { get; set; }
    }
    public class Req
    {
        public string DocID { get; set; }
    }
}