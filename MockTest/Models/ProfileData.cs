using System;
using System.Collections.Generic;
using System.Text;

namespace MockTest.Models
{
    public class ProfileData
    {
        public string UserID { get; set; }
        public List<ScoreSheet> Data { get; set; }
    }
    public class ScoreSheet
    {
        public string SubName { get; set; }
        public string Score { get; set; }
    }
}
