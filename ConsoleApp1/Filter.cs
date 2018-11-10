using System;

namespace ConsoleApp1
{
    public abstract class Filter
    {
        public virtual void Apply(){
            string name = this.GetType().Name;
            Console.WriteLine(": Applied " + name);
        }
    }

    /*
     * If the logic of each filter depends only on the parameters passed to it (that is, the algorithm is always the same),
     * then it makes sense to bring all this logic to the parent class. If each filter has a completely unique algorithm,
     * then you must implement each method separately, as is done in the FilterD class.
     */
}