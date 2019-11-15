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
        static void Main(String[] args)
        {
            QLearning ql = new QLearning();

            ql.init();
            Console.WriteLine("teste");
            ql.calculateQ();
            //ql.printQ();
            //ql.printPolicy();
        }
    }
}
