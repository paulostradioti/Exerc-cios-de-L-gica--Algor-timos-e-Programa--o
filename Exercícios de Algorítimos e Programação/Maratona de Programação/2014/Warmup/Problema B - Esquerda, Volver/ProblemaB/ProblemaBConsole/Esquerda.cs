using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemaBConsole
{
    class Esquerda
    {
        static void Main(string[] args)
        {

            //      N
            //      0  
            //
            //  O       L
            //  3       1
            //         
            //      S
            //      2
            int posAtual = 0; //  Norte
            
            string userInput;
            string[] direcoes = { "N", "L", "S", "O" };

            int numEntradas = 0;

            // Reads the numbers of Entries
            userInput = Console.ReadLine();
            Int32.TryParse(userInput, out numEntradas);

            //Reads the Commanders' Commands
            userInput = Console.ReadLine();


            for (int i = 0; i < numEntradas; i++)
            {
                var comando = userInput[i];

                if (comando == 'D')
                {
                    posAtual = (posAtual + 1) % 4;
                }
                else if (comando == 'E')
                {
                    posAtual = (posAtual - 1 + 4) % 4;
                }
            }

            Console.WriteLine(direcoes[posAtual]);
        }
    }
}
