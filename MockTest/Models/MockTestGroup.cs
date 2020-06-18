using System;
using System.Collections.Generic;
using System.Text;

namespace MockTest.Models
{
    public class MockTestGroup
    {
        public string Name { get; set; }
        public int Index { get; set; }
        public List<MockTestDetail> Mocktest { get; set; }
    }
}
