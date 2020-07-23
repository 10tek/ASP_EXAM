using Edu.Domain.Enums;
using System;

namespace Edu.DTOs
{
    public class ApplicationDTO
    {
        public string IIN { get; set; }
        public int Score { get; set; }
        public Profile FirstProfile { get; set; }
        public Profile SecondProfile { get; set; }
        public College College { get; set; }
    }
}
