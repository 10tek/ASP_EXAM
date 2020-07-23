using Edu.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edu.Domain
{
    public class Application
    {
        public Guid Id { get; set; }
        public string IIN { get; set; }
        public int Score { get; set; }
        public Profile ProfileFirst { get; set; }
        public Profile ProfileSecond { get; set; }
        public College College { get; set; }
    }
}
