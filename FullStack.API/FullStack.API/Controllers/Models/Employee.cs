﻿namespace FullStack.API.Controllers.Models
{
    public class Employee
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public long salary { get; set; }
        public string department { get; set; }
    }
}
