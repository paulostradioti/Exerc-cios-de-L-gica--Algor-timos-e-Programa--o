using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemaA
{
    class Mario
    {
        static void Main(string[] args)
        {
            int numArmariosPedCliente = 0; 
            int armariosDisponiveis = 0;
            

            var userInput = string.Empty;

            userInput = Console.ReadLine();
            var pedido = userInput.Split();

            if (pedido.Length != 2)
            {
                return;
            }

            Int32.TryParse(pedido[0], out numArmariosPedCliente);
            Int32.TryParse(pedido[1], out armariosDisponiveis);

            
            userInput = Console.ReadLine();
            var armarios = userInput.Split();
            var armariosLivres = armarios.Select((x, y) => Int32.TryParse(x, out y) ? y - 1 : 0).ToList().OrderBy(x => x); // -1 -> normaliza para zero based

            #region Encontra o indice final do array de armarios
            var armariosIndisponiveis = 0;
            for (int i = 0; i <= armariosLivres.Max(); i++)
            { 
                if (!armariosLivres.Contains(i))
                {
                    armariosIndisponiveis++;
                }
            }
            //Se o último armario estiver ocupado ele não será contado, mas não é um problema por que a alocação de espaço precisa ser contígua
            // Ex. [Vazio, Ocupado, Vazio, Ocupado, Vazio, Vazio, Ocupado, Vazio, Ocupado]
            var numTotalArmarios = Math.Max(armariosLivres.Max(), armariosLivres.Count() + armariosIndisponiveis);
            #endregion

            var numMinimoMovimentos = Int32.MaxValue;

            var inicioIntervalo = 0;
            var fimIntervalo = 0;

            for (int i = 0; i <= numTotalArmarios - numArmariosPedCliente; i++)
            {
                var numMovimentosInvervalo = 0;
                var numArmarioAtual = 0;

                for (int j = 0; j < numArmariosPedCliente; j++)
                {
                    numArmarioAtual = i + j;
                    if (!armariosLivres.Contains(numArmarioAtual))
                    {
                        numMovimentosInvervalo++;
                    }

                }

                if (numMovimentosInvervalo < numMinimoMovimentos)
                {
                    numMinimoMovimentos = numMovimentosInvervalo;
                    inicioIntervalo = i;
                    fimIntervalo = i + (numArmariosPedCliente - 1);
                }

            }

            Console.WriteLine(numMinimoMovimentos);
            Console.ReadLine();

        }
    }
}
