using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14253024IsletimSisHW2
{
    class Program
    {
       
        static void Main(string[] args)
        {
            ThreadOperations tho = new ThreadOperations();             
            tho.Start();
            Console.ReadKey();
        }
    }
}
