using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST2_priprava
{
    public class Calculator
    {
        public delegate double Operant(double a, double b); //Delegat s signaturou pro matemaaticke operace z tridy ALU

        public Calculator()
        {
            Console.WriteLine("Calculator READY!");
        }

        public void DoOperate(double A, double B, Operant OP) //Metoda volajici delegata
        {
           Console.WriteLine("\t ( * ) Result IS: "+OP(A,B)+"\n");
        }

    }
}
