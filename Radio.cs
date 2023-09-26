using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp53
{
    class Radio
    {
        public TimeSpan OraPerc { get; set; }
        public int AdasDb { get; set; }
        public string Nev { get; set; }
        public int AtszamolPercre { get; set; }

        public Radio(string beolvasottSor)
        {
            var darabok = beolvasottSor.Split(';');
            OraPerc = new TimeSpan(int.Parse(darabok[0]), int.Parse(darabok[1]), 0);
            AdasDb = int.Parse(darabok[2]);
            Nev = darabok[3];
            AtszamolPercre = Convert.ToInt32(OraPerc.TotalMinutes);
        }
    }
}
