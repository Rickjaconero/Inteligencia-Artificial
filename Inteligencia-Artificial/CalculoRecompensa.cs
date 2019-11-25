using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteligencia_Artificial
{
    class CalculoRecompensa
    {

        Recompensas valorRecompensa;

        public CalculoRecompensa()
        {
            valorRecompensa = new Recompensas();
        }

        private double maximo(int a, int b)
        {
            String x = a.ToString(), y = b.ToString();
            List<double> recompensa = new List<double>();
            int escolhido;
            Recompensas valorRecompensa = new Recompensas();

            int movimento = Int32.Parse(x + y);
            if (movimento == 0 || movimento == 49 || movimento == 9 || movimento == 40)
            {

                if (movimento + 10 < 49)
                    recompensa.Add(valorRecompensa.matrizRecompensa[a, b, movimento + 10]);
                if (movimento - 10 > 0)
                    recompensa.Add(valorRecompensa.matrizRecompensa[a, b, movimento - 10]);
                if (movimento + 1 < 49)
                    recompensa.Add(valorRecompensa.matrizRecompensa[a, b, movimento + 1]);
                if (movimento - 1 > 0)
                    recompensa.Add(valorRecompensa.matrizRecompensa[a, b, movimento - 1]);

                if (recompensa[0] > recompensa[1])
                    escolhido = 0;
                else
                    escolhido = 1;

            }
            else if (b == 9)
            {

                recompensa.Add(valorRecompensa.matrizRecompensa[a, b, movimento + 10]);
                recompensa.Add(valorRecompensa.matrizRecompensa[a, b, movimento - 10]);
                recompensa.Add(valorRecompensa.matrizRecompensa[a, b, movimento - 1]);

                if (recompensa[0] >= recompensa[1])
                    escolhido = 0;
                else
                    escolhido = 1;
                if (recompensa[escolhido] <= recompensa[2])
                    escolhido = 2;

            }
            else if (b == 0)
            {
                recompensa.Add(valorRecompensa.matrizRecompensa[a, b, movimento + 10]);
                recompensa.Add(valorRecompensa.matrizRecompensa[a, b, movimento - 10]);
                recompensa.Add(valorRecompensa.matrizRecompensa[a, b, movimento - 1]);

                if (recompensa[0] >= recompensa[1])
                    escolhido = 0;
                else
                    escolhido = 1;
                if (recompensa[escolhido] <= recompensa[2])
                    escolhido = 2;
            }
            else if (a == 0)
            {
                recompensa.Add(valorRecompensa.matrizRecompensa[a, b, movimento + 10]);
                recompensa.Add(valorRecompensa.matrizRecompensa[a, b, movimento + 1]);
                recompensa.Add(valorRecompensa.matrizRecompensa[a, b, movimento - 1]);

                if (recompensa[0] >= recompensa[1])
                    escolhido = 0;
                else
                    escolhido = 1;
                if (recompensa[escolhido] <= recompensa[2])
                    escolhido = 2;

            }
            else if (a == 4)
            {
                recompensa.Add(valorRecompensa.matrizRecompensa[a, b, movimento + 1]);
                recompensa.Add(valorRecompensa.matrizRecompensa[a, b, movimento - 10]);
                recompensa.Add(valorRecompensa.matrizRecompensa[a, b, movimento - 1]);

                if (recompensa[0] >= recompensa[1])
                    escolhido = 0;
                else
                    escolhido = 1;
                if (recompensa[escolhido] <= recompensa[2])
                    escolhido = 2;
            }
            else
            {
                recompensa.Add(valorRecompensa.matrizRecompensa[a, b, movimento + 10]);
                recompensa.Add(valorRecompensa.matrizRecompensa[a, b, movimento - 10]);
                recompensa.Add(valorRecompensa.matrizRecompensa[a, b, movimento - 1]);
                recompensa.Add(valorRecompensa.matrizRecompensa[a, b, movimento + 10]);

                if (recompensa[0] >= recompensa[1])
                    escolhido = 0;
                else
                    escolhido = 1;
                if (recompensa[escolhido] <= recompensa[2])
                    escolhido = 2;
                if (recompensa[escolhido] <= recompensa[3])
                    escolhido = 3;

            }
            return recompensa[escolhido];
        }

        public String movimento(int a, int b)
        {
            String x = a.ToString(), y = b.ToString();
            List<double> recompensa = new List<double>();
            List<int> movimentoEscolhido = new List<int>();
            Random random = new Random();
            int escolhido, maior, posicaoA, posicaoB;
            Recompensas valorRecompensa = new Recompensas();

            int movimento = Int32.Parse(x + y);
            if (movimento == 0 || movimento == 49 || movimento == 9 || movimento == 40)
            {

                if (movimento + 10 < 49) 
                {
                    recompensa.Add(valorRecompensa.matrizRecompensa[a, b, movimento + 10]);
                    movimentoEscolhido.Add(movimento + 10);
                }
                if (movimento - 10 > 0)
                {
                    recompensa.Add(valorRecompensa.matrizRecompensa[a, b, movimento - 10]);
                    movimentoEscolhido.Add(movimento - 10);
                }
                if (movimento + 1 < 49) 
                {
                    recompensa.Add(valorRecompensa.matrizRecompensa[a, b, movimento + 1]);
                    movimentoEscolhido.Add(movimento + 1);
                }
                if (movimento - 1 > 0)
                {
                    recompensa.Add(valorRecompensa.matrizRecompensa[a, b, movimento - 1]);
                    movimentoEscolhido.Add(movimento - 1);
                }

                if(recompensa[0] == recompensa[1])
                    escolhido = random.Next(0, 1);
                else
                {
                    escolhido = random.Next(0, 10);
                    if (recompensa[0] > recompensa[1])
                        maior = 0;
                    else
                        maior = 1;
                    if (escolhido > 7)
                        escolhido = maior;
                    else
                        escolhido = random.Next(0, 1);
                }



            }
            else if(b == 9)
            {

                recompensa.Add(valorRecompensa.matrizRecompensa[a, b, movimento + 10]);
                movimentoEscolhido.Add(movimento + 10);

                recompensa.Add(valorRecompensa.matrizRecompensa[a, b, movimento - 10]);
                movimentoEscolhido.Add(movimento - 10);

                recompensa.Add(valorRecompensa.matrizRecompensa[a, b, movimento - 1]);
                movimentoEscolhido.Add(movimento - 1);

                if (recompensa[0] == recompensa[1] && recompensa[1] == recompensa[2])
                    escolhido = random.Next(0, 2);
                else
                {
                    escolhido = random.Next(0, 10);
                    if (recompensa[0] >= recompensa[1])
                        maior = 0;
                    else
                        maior = 1;
                    if (recompensa[maior] <= recompensa[2])
                        maior = 2;

                    if (escolhido > 7)
                        escolhido = maior;
                    else
                        escolhido = random.Next(0, 2);

                }

            }
            else if (b == 0)
            {
                recompensa.Add(valorRecompensa.matrizRecompensa[a, b, movimento + 10]);
                movimentoEscolhido.Add(movimento + 10);

                recompensa.Add(valorRecompensa.matrizRecompensa[a, b, movimento - 10]);
                movimentoEscolhido.Add(movimento - 10);

                recompensa.Add(valorRecompensa.matrizRecompensa[a, b, movimento + 1]);
                movimentoEscolhido.Add(movimento + 1);

                if (recompensa[0] == recompensa[1] && recompensa[1] == recompensa[2])
                    escolhido = random.Next(0, 2);
                else
                {
                    escolhido = random.Next(0, 10);
                    if (recompensa[0] >= recompensa[1])
                        maior = 0;
                    else
                        maior = 1;
                    if (recompensa[maior] <= recompensa[2])
                        maior = 2;

                    if (escolhido > 7)
                        escolhido = maior;
                    else
                        escolhido = random.Next(0, 2);

                }
            }
            else if (a == 0)
            {
                recompensa.Add(valorRecompensa.matrizRecompensa[a, b, movimento + 1]);
                movimentoEscolhido.Add(movimento + 10);

                recompensa.Add(valorRecompensa.matrizRecompensa[a, b, movimento + 10]);
                movimentoEscolhido.Add(movimento + 1);

                recompensa.Add(valorRecompensa.matrizRecompensa[a, b, movimento - 1]);
                movimentoEscolhido.Add(movimento - 1);

                if (recompensa[0] == recompensa[1] && recompensa[1] == recompensa[2])
                    escolhido = random.Next(0, 2);
                else
                {
                    escolhido = random.Next(0, 10);
                    if (recompensa[0] >= recompensa[1])
                        maior = 0;
                    else
                        maior = 1;
                    if (recompensa[maior] <= recompensa[2])
                        maior = 2;

                    if (escolhido > 7)
                        escolhido = maior;
                    else
                        escolhido = random.Next(0, 2);

                }
            }
            else if (a == 4)
            {
                recompensa.Add(valorRecompensa.matrizRecompensa[a, b, movimento - 10]);
                movimentoEscolhido.Add(movimento + 1);

                recompensa.Add(valorRecompensa.matrizRecompensa[a, b, movimento + 1]);
                movimentoEscolhido.Add(movimento - 10);

                recompensa.Add(valorRecompensa.matrizRecompensa[a, b, movimento - 1]);
                movimentoEscolhido.Add(movimento - 1);

                if (recompensa[0] == recompensa[1] && recompensa[1] == recompensa[2])
                    escolhido = random.Next(0, 2);
                else
                {
                    escolhido = random.Next(0, 10);

                    if (recompensa[0] >= recompensa[1])
                        maior = 0;
                    else
                        maior = 1;
                    if (recompensa[maior] <= recompensa[2])
                        maior = 2;

                    if (escolhido > 7)
                        escolhido = maior;
                    else
                        escolhido = random.Next(0, 2);

                }
            }
            else
            {
                recompensa.Add(valorRecompensa.matrizRecompensa[a, b, movimento + 10]);
                movimentoEscolhido.Add(movimento + 10);

                recompensa.Add(valorRecompensa.matrizRecompensa[a, b, movimento - 10]);
                movimentoEscolhido.Add(movimento - 10);

                recompensa.Add(valorRecompensa.matrizRecompensa[a, b, movimento - 1]);
                movimentoEscolhido.Add(movimento - 1);

                recompensa.Add(valorRecompensa.matrizRecompensa[a, b, movimento + 10]);
                movimentoEscolhido.Add(movimento + 1);

                if (recompensa[0] == recompensa[1] && recompensa[1] == recompensa[2] && recompensa[1] == recompensa[3])
                    escolhido = random.Next(0, 3);
                else
                {
                    escolhido = random.Next(0, 10);
                    if (recompensa[0] >= recompensa[1])
                        maior = 0;
                    else
                        maior = 1;
                    if (recompensa[maior] <= recompensa[2])
                        maior = 2;
                    if (recompensa[maior] <= recompensa[3])
                        maior = 3;

                    if (escolhido > 7)
                        escolhido = maior;
                    else
                        escolhido = random.Next(0, 3);

                }
            }

            if (movimento > 9)
            {
                posicaoA = Int32.Parse(movimento.ToString().Substring(0, 1));
                posicaoB = Int32.Parse(movimento.ToString().Substring(1, 1));
            }
            else
            {
                posicaoA = 0;
                posicaoB = movimento;
            }

            valorRecompensa.matrizRecompensa[a, b, movimentoEscolhido[escolhido]] += 0.5 * maximo(posicaoA, posicaoB);

            return movimentoEscolhido[escolhido].ToString();

        }
    }
}
