using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public static void main(String args[])
        {
            QLearning ql = new QLearning();

            ql.init();
            ql.calculateQ();
            ql.printQ();
            ql.printPolicy();
        }
    }
}
