using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppConsumeApi.Model
{
    public class DetailPerson
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public DateTime Date { get; } = DateTime.Now;
    }
}
