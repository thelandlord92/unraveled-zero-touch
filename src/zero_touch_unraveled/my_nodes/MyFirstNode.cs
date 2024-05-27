using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zero_touch_unraveled
{
    public class MyFirstNode
    {
        // this hides the overall class as a node.
        private MyFirstNode() { }
        public static string HelloWorld()
        {
            // returns one output of hello world.
            return "Hello world " + DateTime.Now;
        }
    }

}

    
