using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerAuto.Model
{
    public class Computer
    {
        public string Name { get; set; }
        public DateTime? Introduced { get; set; }
        public DateTime? Discontinued { get; set; }
        public Company? Company { get; set; }
    }

    public class Company
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }
}
