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
        bool tipoEdicao = false;
        int atualCliente = 0;
        public Cliente()
        {
            InitializeComponent();
        }

        private void MostrarDadosCliente()
        {
            txtCodigo.Text = Principal.clientes[atualCliente].codigo.ToString();
            txtNome.Text = Principal.clientes[atualCliente].nome;
            txtCpf.Text = Principal.clientes[atualCliente].cpf.ToString();
            txtRg.Text = Principal.clientes[atualCliente].rg.ToString();
            txtEndereco.Text = Principal.clientes[atualCliente].endereco;
            txtBairro.Text = Principal.clientes[atualCliente].bairro;
            txtCidade.Text = Principal.clientes[atualCliente].cidade;
            txtUf.Text = Principal.clientes[atualCliente].uf;
            txtCep.Text = Principal.clientes[atualCliente].cep.ToString();
            txtEmail.Text = Principal.clientes[atualCliente].email;
            txtTelefone.Text = Principal.clientes[atualCliente].tel.ToString();

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
            MostrarDadosCliente();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (tipoEdicao)
            {
                Principal.clientes[Principal.contCliente].codigo = int.Parse(txtCodigo.Text);
                Principal.clientes[Principal.contCliente].nome = txtNome.Text;
                Principal.clientes[Principal.contCliente].cpf = int.Parse(txtCpf.Text);
                Principal.clientes[Principal.contCliente].rg = int.Parse(txtRg.Text);
                Principal.clientes[Principal.contCliente].endereco = txtEndereco.Text;
                Principal.clientes[Principal.contCliente].bairro = txtBairro.Text;
                Principal.clientes[Principal.contCliente].cidade = txtCidade.Text;
                Principal.clientes[Principal.contCliente].uf = txtUf.Text;
                Principal.clientes[Principal.contCliente].cep = int.Parse(txtCep.Text);
                Principal.clientes[Principal.contCliente].email = txtEmail.Text;
                Principal.clientes[Principal.contCliente].tel = int.Parse(txtTelefone.Text);
                atualCliente = Principal.contCliente++;
            }
            else
            {
                Principal.clientes[atualCliente].nome = txtNome.Text;
                Principal.clientes[atualCliente].cpf = int.Parse(txtCpf.Text);
                Principal.clientes[atualCliente].rg = int.Parse(txtRg.Text);
                Principal.clientes[atualCliente].endereco = txtEndereco.Text;
                Principal.clientes[atualCliente].bairro = txtBairro.Text;
                Principal.clientes[atualCliente].cidade = txtCidade.Text;
                Principal.clientes[atualCliente].uf = txtUf.Text;
                Principal.clientes[atualCliente].cep = int.Parse(txtCep.Text);
                Principal.clientes[atualCliente].email = txtEmail.Text;
                Principal.clientes[atualCliente].tel = int.Parse(txtTelefone.Text);
            }
            DesabilitaEdicao();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (Principal.contCliente < 10)
            {
                txtCodigo.Text = (Principal.contCliente + 1).ToString();
                txtNome.Text = "";
                txtCpf.Text = "";
                txtRg.Text = "";
                txtEndereco.Text = "";
                txtBairro.Text = "";
                txtCidade.Text = "";
                txtUf.Text = "";
                txtCep.Text = "";
                txtEmail.Text = "";
                txtTelefone.Text = "";
                HabilitaEdicao();
                tipoEdicao = true;
            }
            else MessageBox.Show("Arquivo cheio");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (Principal.contCliente < 0)
            {
                HabilitaEdicao();
                tipoEdicao = false;
            }
            else MessageBox.Show("Arquivo vazio");
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (atualCliente < Principal.contCliente - 1)
            {
                atualCliente--;
                MostrarDadosCliente();
            }
            else MessageBox.Show("Fim de arquivo!");
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            if (atualCliente < Principal.contCliente - 1)
            {
                atualCliente++;
                MostrarDadosCliente();
            }
            else MessageBox.Show("Fim de arquivo!");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (Principal.contCliente > 0)
            {
                Principal.clientes[atualCliente].nome = "";
                Principal.clientes[atualCliente].cpf = int.Parse("");
                Principal.clientes[atualCliente].rg = int.Parse("");
                Principal.clientes[atualCliente].endereco = "";
                Principal.clientes[atualCliente].bairro = "";
                Principal.clientes[atualCliente].cidade = "";
                Principal.clientes[atualCliente].uf = "";
                Principal.clientes[atualCliente].cep = int.Parse("");
                Principal.clientes[atualCliente].email = "";
                Principal.clientes[atualCliente].tel = int.Parse("");
                MostrarDadosCliente();
            }
        }
    }
}
