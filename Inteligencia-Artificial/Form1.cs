using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inteligencia_Artificial
{
    public partial class Form1 : Form
    {

        private int pausar;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            executaCaminho();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pausar = 1;
        }

        private void executaCaminho()
        {
            CalculoRecompensa calculoRecompensas = new CalculoRecompensa();
            int posicaoA = 4, posicaoB = 0;
            String posicao = "40";

            posicao40.Checked = true;
            pausar = 0;

            while (pausar == 0)
            {
                if (Int32.Parse(posicao) == 49)
                {
                    posicao40.Checked = true;
                    posicaoA = 4;
                    posicaoB = 0;
                    //MessageBox.Show("Chegou");
                }

                posicao = calculoRecompensas.movimento(posicaoA, posicaoB);
                if (Int32.Parse(posicao) > 9)
                {
                    posicaoA = Int32.Parse(posicao.Substring(0, 1));
                    posicaoB = Int32.Parse(posicao.Substring(1, 1));
                }
                else
                {
                    posicaoA = 0;
                    posicaoB = Int32.Parse(posicao);
                }

                switch (Int32.Parse(posicao))
                {
                    case 0:
                        posicao0.Checked = true;
                        break;
                    case 1:
                        posicao1.Checked = true;
                        break;
                    case 2:
                        posicao2.Checked = true;
                        break;
                    case 3:
                        posicao3.Checked = true;
                        break;
                    case 4:
                        posicao4.Checked = true;
                        break;
                    case 5:
                        posicao5.Checked = true;
                        break;
                    case 6:
                        posicao6.Checked = true;
                        break;
                    case 7:
                        posicao7.Checked = true;
                        break;
                    case 8:
                        posicao8.Checked = true;
                        break;
                    case 9:
                        posicao9.Checked = true;
                        break;
                    case 10:
                        posicao10.Checked = true;
                        break;
                    case 11:
                        posicao11.Checked = true;
                        break;
                    case 12:
                        posicao12.Checked = true;
                        break;
                    case 13:
                        posicao13.Checked = true;
                        break;
                    case 14:
                        posicao14.Checked = true;
                        break;
                    case 15:
                        posicao15.Checked = true;
                        break;
                    case 16:
                        posicao16.Checked = true;
                        break;
                    case 17:
                        posicao17.Checked = true;
                        break;
                    case 18:
                        posicao18.Checked = true;
                        break;
                    case 19:
                        posicao19.Checked = true;
                        break;
                    case 20:
                        posicao20.Checked = true;
                        break;
                    case 21:
                        posicao21.Checked = true;
                        break;
                    case 22:
                        posicao22.Checked = true;
                        break;
                    case 23:
                        posicao23.Checked = true;
                        break;
                    case 24:
                        posicao24.Checked = true;
                        break;
                    case 25:
                        posicao25.Checked = true;
                        break;
                    case 26:
                        posicao26.Checked = true;
                        break;
                    case 27:
                        posicao27.Checked = true;
                        break;
                    case 28:
                        posicao28.Checked = true;
                        break;
                    case 29:
                        posicao29.Checked = true;
                        break;
                    case 30:
                        posicao30.Checked = true;
                        break;
                    case 31:
                        posicao31.Checked = true;
                        break;
                    case 32:
                        posicao32.Checked = true;
                        break;
                    case 33:
                        posicao33.Checked = true;
                        break;
                    case 34:
                        posicao34.Checked = true;
                        break;
                    case 35:
                        posicao35.Checked = true;
                        break;
                    case 36:
                        posicao36.Checked = true;
                        break;
                    case 37:
                        posicao37.Checked = true;
                        break;
                    case 38:
                        posicao38.Checked = true;
                        break;
                    case 39:
                        posicao39.Checked = true;
                        break;
                    case 40:
                        posicao40.Checked = true;
                        break;
                    case 41:
                        posicao41.Checked = true;
                        break;
                    case 42:
                        posicao42.Checked = true;
                        break;
                    case 43:
                        posicao43.Checked = true;
                        break;
                    case 44:
                        posicao44.Checked = true;
                        break;
                    case 45:
                        posicao45.Checked = true;
                        break;
                    case 46:
                        posicao46.Checked = true;
                        break;
                    case 47:
                        posicao47.Checked = true;
                        break;
                    case 48:
                        posicao48.Checked = true;
                        break;
                    case 49:
                        posicao49.Checked = true;
                        break;
                }

                System.Threading.Thread.Sleep(100);
            }

        }

    }
}
