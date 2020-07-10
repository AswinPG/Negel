using MockTest.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace MockTest.Loader
{
    public static class Loader
    {
        //public static readonly DashBoardView dBoard;
        public static MockTestPage MP { get; set; }
        public static string Heading { get; set; }
        public static string UserID { get; set; }

        public static void userID(string Uid)
        {
            UserID = Uid;
        }
        public static void SetMP(MockTestPage dBoard)
        {
            MP = dBoard;
        }
        public static void Load(int Q)
        {
            MP.Current = Q;
            MP.UpdateQuestions(Q);
            
        }
        public static void PopAll()
        {
             MP.Navigation.PopAsync();
             MP.Navigation.PopAsync();
             MP.Navigation.PopAsync();
            MP = null;
        }
        public static void PopOnBack()
        {
            MP.Navigation.PopAsync();
            MP.Navigation.PopAsync();
            MP = null;
        }

    }
}
