using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST2_priprava
{
    class ALU
    {
        public double Plus(double X, double Y) //Metoda PLUS pro delegata
        {
            Console.WriteLine("Call plus ALU method.."+"\t INPUT: "+X+" "+Y);
            return X + Y;
        }
        public double Minus(double X, double Y)//Metoda MINUS pro delegata
        {
            Console.WriteLine("Call minus ALU method.."+"\t INPUT: "+X+" "+Y);
            return X - Y;
        }
        public double Multiplication(double X, double Y)//Metoda MULTIPLY pro delegata
        {
            Console.WriteLine("Call multiply ALU method.."+"\t INPUT: "+X+" "+Y);
            return X * Y;
        }
        public static double Division(double X, double Y)//Metoda DIVISION pro delegata
        {
            Console.WriteLine("Call division ALU method.."+"\t INPUT: "+X+" "+Y);
            if (Y == 0)
            {
                throw new ALUErrorException();
            }
            else
            {
                return (X / Y);
            }
        }
    }
}
