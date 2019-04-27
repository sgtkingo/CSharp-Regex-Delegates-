using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TEST2_priprava
{
    public class CalculatorRegexDecoding
    {
        //private static string regex=@"\b(\d+\.?\d?)[+-*/]{1}(\d+\.?\d?)\b";
        private static string pattern = @"\b(\d+\,?\d*)(\+?\-?\*?\/?)(\d+\,?\d*)\b"; //regex který rozpoznává celá/desetinná čísla, ověří znaménko a existenci obou proměných- hlavní regex
        private static string numberPattern = @"(\d+\,?\d*)"; //rozpoznává čísla
        private static string[] operandsPattern={ @"\+",@"\-",@"\*",@"\/"}; //pole regexu pro každé znaménko zvlášť

        private char operant;

        enum operands //struktura enum, názvum lze přiřadit hodnoty
        {
            Plus='+',Minus='-',Multi='*',Div='/'
        }

        private Regex myNumberRegex; //Regex pro rozpoznání čísel

        private double A, B; //Zde si třída uloží proměné pokud bude rozpoznání výrazu úspěšné

        public CalculatorRegexDecoding()
        {
            myNumberRegex=new Regex(numberPattern); //myNumberRegex je nastaven na hledání čísel
            Console.WriteLine("Regex Decoder Ready!");
        }

        public bool getInput(string inputT)  //hlavní metoda, ověří zda vstupní řetezec (string) odpovídá matematickému výra ve formě např. X+Y
        { 
            if (Regex.IsMatch(inputT, pattern)) //statická metody IsMatch je základní metoud třídy Regex, dá se použít přímo
            {
                DecodeInputText(inputT); //pokud je ověření úspěšné text je poslán na rozpoznání
                return true;
            }
            return false;
        }

        private void DecodeInputText(string inputT) //Metoda na rozpoznání proměných
        {
            Console.WriteLine("\t//Regex Decoder output:");
            NumberFormatInfo nfi= CultureInfo.CurrentCulture.NumberFormat; //nastavení formátu čísla pro CZE(aktualni cultura)

            //Jeden ze způsobu je použít Split a jako oddělovač znaménko
            /*string[]valuesSplit=
            inputT.Split(new char[]{'+','-','*','/'});*/

            //Druhý je použít Match a Regex
            MatchCollection ParseNumbers = myNumberRegex.Matches(inputT); //myNumberRegex.Matches(inputT) vrací seznam objektu Match z níž každý obsahuje jeden substring se shodou
            //Např u výrazu 5.68+9 je jeden Match 5.68 a druhý 9, takže MatchCollection ParseNumbers bude obsahovat 2 položky typu Match

            if (ParseNumbers.Count == 0) //Pokud není nic ve shodě, není třeba pokračovat dále
            {
                Console.WriteLine("No numbers found...");
                return;
            }

            try
            {
                //VariableA = double.Parse(valuesSplit[0]);
                //Console.WriteLine("\t#A detected as: {0} [original text: {1}]",VariableA,valuesSplit[0]);
                

                //Parsování čísla double, ParseNumbers[0].Value vrací string takže je třeba ho převest na double, nfi se používá pro nastavení formátu čísla pro parsování
                VariableA =double.Parse(ParseNumbers[0].Value,nfi);
                Console.WriteLine("\t#A detected as: {0} [original text: {1}]",VariableA,ParseNumbers[0].Value);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e+" Matches:"+ParseNumbers[0].Value);
                throw;
            }

            try
            {
                //VariableB = double.Parse(valuesSplit[1]);
                //Console.WriteLine("\t#B detected as: {0} [original text: {1}]",VariableB,valuesSplit[1]);
               
                VariableB =double.Parse(ParseNumbers[1].Value,nfi);
                Console.WriteLine("\t#B detected as: {0} [original text: {1}]",VariableB,ParseNumbers[1].Value);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e+" Matches:"+ParseNumbers[1].Value);
                throw;
            }
            
            FindOperand(inputT); //Hledanání znaménka
        }

        private void FindOperand(string inputT)
        {
            foreach (string OP in operandsPattern) //Projde všechny regexy na znaménka a vždy testuje jeden
            {
                if (Regex.IsMatch(inputT, OP)) 
                {
                    //V případě shody už jen stačí z regex retězce vytáhnout samotné znaménko
                    Operand = OP[OP.Length-1]; //víme že je na konci regexu, šlo by i OP[1] protože známe délku
                    Console.WriteLine("\t#Find operand: "+OP+" -> "+Operand);
                    return;
                }
            }
        }

        public char Operand
        {
            get { return this.operant; }
            set { this.operant = value; }
        }

        public double VariableA {
            get { return this.A; }
            set { this.A = value; }
        }
        public double VariableB {
            get { return this.B; }
            set { this.B = value; }
        }
    }
}
