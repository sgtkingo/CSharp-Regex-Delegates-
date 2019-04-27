using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST2_priprava
{
    public class ALUErrorException : Exception //Vyjimkka pro ALU
    {
        public ALUErrorException()
        {
            Console.WriteLine("ALU Error Ocours!");
        }
    } 
}
