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
    public partial class ResultsPage : ContentPage
    {
        public ResultsPage()
        {
            InitializeComponent();
            int Score = 0;
            int Wrong = 0;
            int Unatteded = 0;
            ListOfQuiz items = Loader.Loader.MP.items;
            ObservableCollection<FinalListData> datas = Loader.Loader.MP.finalListDatas;
            for(int i = 0; i < datas.Count; i++)
            {
                if(datas[i].CorrectOrNot == 1)
                {
                    Score++;
                }
                else if(datas[i].CorrectOrNot == 2)
                {
                    Wrong++;
                }
                else
                {
                    Unatteded++;
                }
            }


            
            MainCollectionView.ItemsSource = items.Data;
            CorrectLabel.Text = Score.ToString();
            WrongLabel.Text = Wrong.ToString();
            UnAttendedLabel.Text =Unatteded.ToString();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Loader.Loader.PopAll();
        }
        protected override bool OnBackButtonPressed()
        {
            Loader.Loader.PopOnBack();
            return base.OnBackButtonPressed();
            
        }
    }
}