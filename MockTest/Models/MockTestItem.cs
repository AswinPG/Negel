using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MockTest.Models
{
    public class MockTestItem   
    {
        public List<string> Options { get; set; }
        public string Answer { get; set; }
        public string Question { get; set; }
        public string ImgUrl { get; set; }
        public string Heading { get; set; }
        public string Paragraph { get; set; }
        public int Choosen { get; set; }
        public MockTestItem()
        {
            Choosen = 0;
        }
    }
}
    