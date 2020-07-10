using MockTest.Models;
using Newtonsoft.Json;
using Plugin.CloudFirestore;
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
        public ProfileData profileData;
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


            profileData = new ProfileData()
            {
                UserID = Loader.Loader.UserID,
                Data = new List<ScoreSheet>()
                {
                    new ScoreSheet()
                    {
                        SubName = Loader.Loader.Heading,
                        Score = Score.ToString()
                    }
                }
            };

            UploadData();


            MainCollectionView.ItemsSource = items.Data;
            CorrectLabel.Text = Score.ToString();
            WrongLabel.Text = Wrong.ToString();
            UnAttendedLabel.Text =Unatteded.ToString();
        }

        public async void UploadData()
        {
            var query = await CrossCloudFirestore.Current
                                     .Instance
                                     .GetCollection("Users")
                                     .WhereEqualsTo("UserID",Loader.Loader.UserID)
                                     .GetDocumentsAsync();
            var c = query.Documents.ToList();
            
            try
            {
                string json = JsonConvert.SerializeObject(c[0].Data);
                ProfileData Data = (JsonConvert.DeserializeObject<ProfileData>(json));
                foreach (ScoreSheet i in Data.Data)
                {
                    profileData.Data.Add(i);
                }
               
                



                

            }
            catch(Exception h)
            {

            }


            await CrossCloudFirestore.Current
                                     .Instance
                                     .GetCollection("Users")
                                     .GetDocument(c[0].Id)
                                     .UpdateDataAsync(profileData);
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