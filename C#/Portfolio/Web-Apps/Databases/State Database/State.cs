/** 
 * ADITYA PATEL
 * CPT - 206
 * STATE CLASS
 * **/

using System.Collections.Generic;

namespace APatel_Lab__3
{
    public class State
    {
        public string StateName { get; set; }
        public int Population { get; set; }
        public string FlagDescription { get; set; }
        public string StateFlower { get; set; }
        public string StateBird { get; set; }
        public string StateColors { get; set; }
        public string LargestCity1 { get; set; }
        public string LargestCity2 { get; set; }
        public string LargestCity3 { get; set; }
        public string StateCapital { get; set; }
        public double MedianIncome { get; set; }
        public double ComputerJobPercentage { get; set; }
    }

    public static class StateDataStore
    {
        public static List<State> States { get; set; } = new List<State>();
    }

}
