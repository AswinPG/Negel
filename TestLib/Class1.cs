using System;
using System.Collections.Generic;
using System.IO;

namespace TestLib
{
    public class Class1
    {
        public TestData Test()
        {
            string path = @"C:\Users\Aswin\source\samp.json";
            
        }
    }
    public class Content
    {
        public string Heading { get; set; }
        public string Summary { get; set; }
    }
    public class TestData
    {
        public List<Content> Data { get; set; }
    }
}
