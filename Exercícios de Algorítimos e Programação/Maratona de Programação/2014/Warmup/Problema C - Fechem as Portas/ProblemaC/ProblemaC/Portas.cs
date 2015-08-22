using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemaC
{
    class Portas
    {
        static void Main(string[] args)
        {
            List<int> portasAbertas = new List<int>();
            List<int> descendentesDentroMansao = new List<int>();
            int numDescendentes;
            string userInput;
                        
            userInput = Console.ReadLine();
            Int32.TryParse(userInput, out numDescendentes);
            if (numDescendentes < 1)
            {
                return;
            }
            
            
            Random random = new Random();
            while (descendentesDentroMansao.Count() != numDescendentes)
            {
                int descendente = 0;
                do
	            {
                    descendente = random.Next(1, numDescendentes + 1); // upper bound is excluse in Random.Next
	            } while(descendentesDentroMansao.Contains(descendente));
                
                descendentesDentroMansao.Add(descendente);

                var multiplicador = 1;
                var porta = descendente;
                do
                {

                    if (portasAbertas.Contains(porta))
                    {
                        portasAbertas.Remove(porta);
                    }
                    else
                    {
                        portasAbertas.Add(porta);
                    }

                    multiplicador++;
                    porta = descendente * multiplicador;

                } while (porta <= numDescendentes);

            }

            portasAbertas.Sort();

            Console.WriteLine(String.Join(" ", portasAbertas.Select(x => Convert.ToString(x))));
        }
    }

}