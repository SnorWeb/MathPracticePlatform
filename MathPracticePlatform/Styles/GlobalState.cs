using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathPracticePlatform.Styles
{
    public class GlobalState
    {
        private static GlobalState instance;
        public static GlobalState Instance => instance ?? (instance = new GlobalState());
        
        public int TimeLimit { get; set; }
    }
}
