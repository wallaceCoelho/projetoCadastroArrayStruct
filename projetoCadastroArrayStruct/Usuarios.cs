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
    public partial class Usuarios : Form
    {
        private void DesabilitaEdicao()
        {
            txtCodigo.Enabled = false;
            txtNome.Enabled = false;
            txtNivel.Enabled = false;
            txtLogin.Enabled = false;
            txtSenha.Enabled = false;
            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;
            btnAnterior.Enabled = true;
            btnProximo.Enabled = true;
            btnNovo.Enabled = true;
            btnPesquisar.Enabled = true;
            btnAlterar.Enabled = true;
            btnImprimir.Enabled = true;
            btnExcluir.Enabled = true;
            btnSair.Enabled = true;
        }
        private void HabilitaEdicao()
        {
            txtCodigo.Enabled = false;
            txtNome.Enabled = true;
            txtNivel.Enabled = true;
            txtLogin.Enabled = true;
            txtSenha.Enabled = true;
            btnSalvar.Enabled = true;
            btnCancelar.Enabled = true;
            btnAnterior.Enabled = false;
            btnProximo.Enabled = false;
            btnNovo.Enabled = false;
            btnPesquisar.Enabled = false;
            btnAlterar.Enabled = false;
            btnImprimir.Enabled = false;
            btnExcluir.Enabled = false;
            btnSair.Enabled = false;
        }
        public Usuarios()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            DesabilitaEdicao();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            DesabilitaEdicao();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DesabilitaEdicao();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            HabilitaEdicao();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            HabilitaEdicao();
        }
    }
}
