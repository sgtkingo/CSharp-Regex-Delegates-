using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST2_priprava
{
    class Program
    {
        static void Main(string[] args)
        {
            double A=0, B=0;
            char operand;

            /*Console.WriteLine("Zadej A operant:" ); //Nacteni vstupu A
            try
            {
                A=int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
            Console.WriteLine("Zadej B operant:" ); //Nacteni vstupu B
            try
            {
                B=int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }*/
            
            CalculatorRegexDecoding MyDecoder=new CalculatorRegexDecoding();
            ALU MyALU= new ALU(); //Vytvoreni ALU instance
            Calculator MyCalc= new Calculator(); //Vytvoreni Calculator instance

            Console.WriteLine("\tPlease write expression by this rules: ");
            Console.WriteLine("|operand A [double]|+-*/|operand A [double]|");
            Console.WriteLine("for example: 5,88+96");

            while (!MyDecoder.getInput(Console.ReadLine())) //Dokud getInput vrací false, budu opakovat načtení od uživatele
            {
                Console.WriteLine("Expression syntax error! Again:");
            }

            //Uložím si dekodované proměnné
            A = MyDecoder.VariableA;
            B = MyDecoder.VariableB;
            operand = MyDecoder.Operand;

            //Delegati se chovají jako objekty, je treba jim vytvořit instance a do kontruktoru dat metody ktere mají zastupovat
            //Vsichni se chovají jako STATIC podtřídy, lze k nim pristupovat přímo přes obecný název třídy 
            Calculator.Operant PlusOperand=new Calculator.Operant(MyALU.Plus);   //připřazení delegatovi metodu z třídy ALU, použijeme instanci MyALU (metody ALU nejsou statické)
            Calculator.Operant MinusOperand=new Calculator.Operant(MyALU.Minus);
            Calculator.Operant MultiplyOperand=new Calculator.Operant(MyALU.Multiplication);
            Calculator.Operant DivisionOperand=new Calculator.Operant(ALU.Division); //pokud je motoda STATIC, lze ji přiřadit přímo přes obecný název třídy

            //Vytvořené instance delegatu používáme jako "proměné", chovají se jako objekty
            //Použité znaménko pro switch
            switch (operand)
            {
                case '+':
                {
                    MyCalc.DoOperate(A,B,PlusOperand);
                    break;
                }
                case '-':
                {
                    MyCalc.DoOperate(A,B,MinusOperand);
                    break;
                }

                case '*':
                {
                    MyCalc.DoOperate(A,B,MultiplyOperand);
                    break;
                }
                case '/':
                {
                    MyCalc.DoOperate(A,B,DivisionOperand);
                    break;
                }
                default:
                {
                    Console.WriteLine("Unknown operand...");
                    break;
                }
                    
            }
            //MyCalc.DoOperate(A,0,DivisionOperand); //test vyjímky
        }
    }
}
