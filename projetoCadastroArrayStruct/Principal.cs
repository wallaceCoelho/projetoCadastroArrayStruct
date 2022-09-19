using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projetoCadastroArrayStruct
{
    public partial class Principal : Form
    {
        public struct Usua
        {
            public int codigo;
            public string nome;
            public string nivel;
            public string login;
            public string senha;
        }

        public struct Client
        {
            public int codigo;
            public string nome;
            public string cpf;
            public string rg;
            public string endereco;
            public string bairro;
            public string cidade;
            public string uf;
            public string cep;
            public string tel;
            public string email;
        }

        public struct Prod
        {
            public int codigo;
            public string desc;
            public int unidade;
            public int qtEstoque;
            public float precoCusto;
            public float precoVenda;
        }

        static public Prod[] produto = new Prod[10];
        static public Client[] clientes = new Client[10];
        static public Usua[] usuarios = new Usua[10];
        static public int contUsuario = 0;
        static public int contCliente = 0;
        static public int contProduto = 0;

        public Principal()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuarios formUsuario = new Usuarios();
            formUsuario.ShowDialog();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cliente formCliente = new Cliente();
            formCliente.ShowDialog();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Produto formProduto = new Produto();
            formProduto.ShowDialog();
        }




        private void pdUsuario_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string strDados;
            Graphics objImpressao = e.Graphics;
            int page = 1, i = 0, linha = 0;
            bool cabecalho = true, item = true;

            while (cabecalho)
            {
                strDados = "                            RELATÓRIO DE USUÁRIOS" + (char)10;
                strDados += "Data: " + DateTime.Now.ToString("dd/MM/yyyy") + "                                                         Pág: " + page.ToString("00") + (char)10;
                strDados += "--------------------------------------------------------------------------------" + (char)10;
                strDados += "Código Nome                                         Nível Login" + (char)10;
                strDados += "--------------------------------------------------------------------------------" + (char)10;
                item = true;
                linha = 5;
                while (item)
                {
                    strDados += usuarios[i].codigo.ToString("000000") + " " + usuarios[i].nome.PadRight(40) + "     " + usuarios[i].nivel + "   " + usuarios[i].login + (char)10;
                    linha++;

                    if (linha >= 64)
                    {
                        item = false;
                        strDados += (char)12;
                    }
                    i++;
                    if (i >= contUsuario)
                    {
                        item = false;
                        cabecalho = false;
                    }
                }
                objImpressao.DrawString(strDados, new Font("Courier New", 10, FontStyle.Regular), Brushes.Black, 50, 50);
            }
        }



        private void usuáriosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ppdUsuario.ShowDialog();
        }


        private void pdProduto_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string strDados;
            Graphics objImpressao = e.Graphics;
            int page = 1, i = 0, linha = 0;
            bool cabecalho = true, item = true;

            while (cabecalho)
            {
                strDados = "                            RELATÓRIO DE PRODUTOS" + (char)10;
                strDados += "Data: " + DateTime.Now.ToString("dd/MM/yyyy") + "                                                         Pág: " + page.ToString("00") + (char)10;
                strDados += "--------------------------------------------------------------------------------" + (char)10;
                strDados += "Código Descrição                           Qt estoque   unidade" + (char)10;
                strDados += "--------------------------------------------------------------------------------" + (char)10;
                item = true;
                linha = 5;
                while (item)
                {
                    strDados += produto[i].codigo.ToString("000000") + " " + produto[i].desc.PadRight(40) + " " + produto[i].qtEstoque + "         " + produto[i].unidade + (char)10;
                    linha++;

                    if (linha >= 64)
                    {
                        item = false;
                        strDados += (char)12;
                    }
                    i++;
                    if (i >= contProduto)
                    {
                        item = false;
                        cabecalho = false;
                    }
                }
                objImpressao.DrawString(strDados, new Font("Courier New", 10, FontStyle.Regular), Brushes.Black, 50, 50);
            }
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void produtosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ppdProduto.ShowDialog();
        }

        private void pdCliente_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string strDados;
            Graphics objImpressao = e.Graphics;
            int page = 1, i = 0, linha = 0;
            bool cabecalho = true, item = true;

            while (cabecalho)
            {
                strDados = "                            RELATÓRIO DE CLIENTES" + (char)10;
                strDados += "Data: " + DateTime.Now.ToString("dd/MM/yyyy") + "                                                         Pág: " + page.ToString("00") + (char)10;
                strDados += "--------------------------------------------------------------------------------" + (char)10;
                strDados += "Código Nome                                        CPF        Telefone" + (char)10;
                strDados += "--------------------------------------------------------------------------------" + (char)10;
                item = true;
                linha = 5;
                while (item)
                {
                    strDados += clientes[i].codigo.ToString("000000") + " " + clientes[i].nome.PadRight(40) + clientes[i].cpf + "   " + clientes[i].tel + (char)10;
                    linha++;

                    if (linha >= 64)
                    {
                        item = false;
                        strDados += (char)12;
                    }
                    i++;
                    if (i >= contCliente)
                    {
                        item = false;
                        cabecalho = false;
                    }
                }
                objImpressao.DrawString(strDados, new Font("Courier New", 10, FontStyle.Regular), Brushes.Black, 50, 50);
            }
        }

        private void clientesToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            ppdCliente.ShowDialog();
        }
    }
}
