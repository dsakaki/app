using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class version
    {
        string _version;
        DateTime _date;

        public string Version { get => _version; set => _version = value; }
        public DateTime Date { get => _date; set => _date = value; }

        public version() 
        {
            Version = "1.0";
            Date = DateTime.Now;        
        }

        public version(string version, DateTime date)
        {
            Version = version;
            Date = date;
        }


    }
}
