using Plugin.FirebaseAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Negel.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        PhoneNumberVerificationResult verificationResult;
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void SentOTP(string Number)
        {
            //await LoginYummyButton.ScaleTo(.8);
            //LoginYummyButton.ScaleTo(1);
            verificationResult = await CrossFirebaseAuth.Current.PhoneAuthProvider.VerifyPhoneNumberAsync(CrossFirebaseAuth.Current.Instance, "+91" + Number);

        }
        private async void LoginWithOTP(object sender, EventArgs e)
        {
            try
            {
                await LoginYummyButton.ScaleTo(.95);
                LoginYummyButton.ScaleTo(1);
                var credential = CrossFirebaseAuth.Current.PhoneAuthProvider.GetCredential(CrossFirebaseAuth.Current.Instance, verificationResult.VerificationId, CodeEntry.Text);
                var result = await CrossFirebaseAuth.Current.Instance.SignInWithCredentialAsync(credential);
                string UserID = result.User.Uid;
                App.Current.Properties["UserId"] = UserID;
                await Navigation.PushAsync(new MainPage());
            }
            catch (Exception u)
            {

            }


        }

        private async void PlainEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (PlainEntryEntry.Text.Length == 10)
            {
                if (double.TryParse(PlainEntryEntry.Text, out _))
                {
                    SentOTP(PlainEntryEntry.Text);
                    await DisplayAlert("OTP Sent", "An otp has been sent to " + PlainEntryEntry.Text, "Ok");
                }
            }
        }

        //public async void Play1Async()
        //{
        //    var responseMessage = await APIHelper.APIClient.PostAsJsonAsync("https://us-central1-firestoretestapp-bf440.cloudfunctions.net/ActivePlayerAdd", new Player() { Category="Sports", amount = "10", UserID = "nm", Name = "Aswin", size = "2" });
        //    string docid = await responseMessage.Content.ReadAsStringAsync();
        //    CrossCloudFirestore.Current
        //           .Instance
        //           .GetCollection("Matches")
        //           .GetDocument(docid)
        //           .AddSnapshotListener((snapshot, error) =>
        //           {
        //               if (snapshot != null)
        //               {
        //                   foreach (var documentChange in snapshot.Data)
        //                   {
        //                       if ((bool)(snapshot.Data["sizefull"]))
        //                       {
        //                           DisplayAlert("1", "1", "Ok");
        //                       }
        //                   }
        //               }
        //           });
        //}
        //public async void Play2Async()
        //{
        //    var responseMessage = await APIHelper.APIClient.PostAsJsonAsync("https://us-central1-firestoretestapp-bf440.cloudfunctions.net/ActivePlayerAdd", new Player() { Category = "Sports", amount = "10", UserID = "nssssm", Name = "Aswin2", size = "2" });
        //    string docid = await responseMessage.Content.ReadAsStringAsync();
        //    CrossCloudFirestore.Current
        //           .Instance
        //           .GetCollection("Matches")
        //           .GetDocument(docid)
        //           .AddSnapshotListener((snapshot, error) =>
        //           {
        //               if (snapshot != null)
        //               {
        //                   foreach (var documentChange in snapshot.Data)
        //                   {
        //                       if ((bool)(snapshot.Data["sizefull"]))
        //                       {
        //                           DisplayAlert("2", "2", "Ok");
        //                       }
        //                   }
        //               }
        //           });
        //}

        //private void Button_Clicked(object sender, EventArgs e)
        //{
        //    Play1Async();
        //}

        //private void Button_Clicked_1(object sender, EventArgs e)
        //{
        //    Play2Async();
        //}
    }
}