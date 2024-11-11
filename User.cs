using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStorage
{
    public class User
    {
        public string FullName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string PhotoPath { get; set; }
        public bool NeedsDorm { get; set; }
        public bool IsLeader { get; set; }
        public int Grade { get; set; }
    }
}
