using System;
using System.Collections.Generic;

using System.Text;
using Xamarin.Forms;

namespace MockTest.Models
{
    public class FinalListData
    {
        public int QNo { get; set; }
        public Color AttendedColour { get; set; }
        public int CorrectOrNot { get; set; }
        public FinalListData()
        {
            CorrectOrNot = 0;
        }
    }
}
