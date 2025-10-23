using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samplejobs
{
    class EmailRequest
    {
        public class Email
        {
            public string from { get; set; }
            public string to { get; set; }
            public string password { get; set; }
            public string subject { get; set; }
            public string Body { get; set; }
        }
    }
}
