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
    public partial class Cliente : Form
    {
        public Cliente()
        {
            InitializeComponent();
        }
        private void DesabilitaEdicao()
        {
            //Desabilita opções no cadastro
            txtCodigo.Enabled = false;
            txtNome.Enabled = false;
            txtCpf.Enabled = false;
            txtRg.Enabled = false;
            txtEndereco.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            txtUf.Enabled = false;
            txtCep.Enabled = false;
            txtTelefone.Enabled = false;
            txtEmail.Enabled = false;
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
            //Habilita outras funções no cadastro
            txtCodigo.Enabled = false;
            txtNome.Enabled = true;
            txtCpf.Enabled = true;
            txtRg.Enabled = true;
            txtEndereco.Enabled = true;
            txtBairro.Enabled = true;
            txtCidade.Enabled = true;
            txtUf.Enabled = true;
            txtCep.Enabled = true;
            txtTelefone.Enabled = true;
            txtEmail.Enabled = true;
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

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            DesabilitaEdicao();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DesabilitaEdicao();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
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
