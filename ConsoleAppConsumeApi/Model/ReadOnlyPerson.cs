using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppConsumeApi.Model
{
    public class ReadOnlyPerson
    {
        public Person Person { get; set; }

        public DetailPerson DetailPerson { get; set; }
    }
}
