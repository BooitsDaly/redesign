using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project3_Daly
{
    class News
    {
        public List<Older> older { get; set; }
    }
    public class Older
    {
        public string date { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }
}
