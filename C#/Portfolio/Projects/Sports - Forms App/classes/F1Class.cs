using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Sports.UI
{
    public class F1Class:F1DB
    {
        
        //CurrentConstructors
        public int ConstructorID { get; set; }
        public string TeamName { get; set; }
        public string Principal { get; set; }
        public string Driver1 { get; set; }
        public int D1Num { get; set; }
        public string Driver2 { get; set; }
        public int D2Num { get; set; }
        public int Championships { get; set; }
        public string Base { get; set; }
        public string PowerUnit { get; set; }

        public F1Class (int constructorID, string teamName, string principal, string driver1, int d1Num, string driver2, int d2Num, int championships, string _base, string powerUnit)
        {
            ConstructorID = constructorID;
            TeamName = teamName;
            Principal = principal;
            Driver1 = driver1;
            D1Num = d1Num;
            Driver2 = driver2;
            D2Num = d2Num;
            Championships = championships;
            Base = _base;
            PowerUnit = powerUnit;
        }
    }
}
