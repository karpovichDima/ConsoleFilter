using System;
using ConsoleApp1;

namespace Filters {
    public class FilterD : Filter {

        public override void Apply()
        {
            string name = this.GetType().Name;
            Console.WriteLine(": Applied " + name + " ||| unique logic |||");
        }
    }
}
