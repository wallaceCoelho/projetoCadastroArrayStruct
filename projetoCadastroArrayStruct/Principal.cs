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

        static public Usua[] usuarios = new Usua[10];
        static public int contUsuario = 0;

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
    }
}
