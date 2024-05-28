using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zero_touch_unraveled
{
    /// <summary>
    /// Wrapper class for my first node.
    /// </summary>
    public class MyFirstNode
    {
        // this hides the overall class as a node.
        private MyFirstNode() { }

        /// <summary>
        /// My first node that ouputs a string that says Hello World.
        /// </summary>
        /// <param name="extraMessage">Optional extra message</param>
        /// <returns name="helloWorldString">Our hello world node. </returns>
        public static string HelloWorld(string extraMessage="")
        {
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            // returns one output of hello world.     
            return $"Hello, {userName}. {extraMessage}";
        }
    }
}