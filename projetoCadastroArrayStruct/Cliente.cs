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
            txtCpf.Text = Principal.clientes[atualCliente].cpf;
            txtRg.Text = Principal.clientes[atualCliente].rg;
            txtEndereco.Text = Principal.clientes[atualCliente].endereco;
            txtBairro.Text = Principal.clientes[atualCliente].bairro;
            txtCidade.Text = Principal.clientes[atualCliente].cidade;
            txtUf.Text = Principal.clientes[atualCliente].uf;
            txtCep.Text = Principal.clientes[atualCliente].cep;
            txtEmail.Text = Principal.clientes[atualCliente].email;
            txtTelefone.Text = Principal.clientes[atualCliente].tel;

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
                Principal.clientes[Principal.contCliente].cpf = txtCpf.Text;
                Principal.clientes[Principal.contCliente].rg = txtRg.Text;
                Principal.clientes[Principal.contCliente].endereco = txtEndereco.Text;
                Principal.clientes[Principal.contCliente].bairro = txtBairro.Text;
                Principal.clientes[Principal.contCliente].cidade = txtCidade.Text;
                Principal.clientes[Principal.contCliente].uf = txtUf.Text;
                Principal.clientes[Principal.contCliente].cep = txtCep.Text;
                Principal.clientes[Principal.contCliente].email = txtEmail.Text;
                Principal.clientes[Principal.contCliente].tel = txtTelefone.Text;
                atualCliente = Principal.contCliente++;
            }
            else
            {
                Principal.clientes[atualCliente].nome = txtNome.Text;
                Principal.clientes[atualCliente].cpf = txtCpf.Text;
                Principal.clientes[atualCliente].rg = txtRg.Text;
                Principal.clientes[atualCliente].endereco = txtEndereco.Text;
                Principal.clientes[atualCliente].bairro = txtBairro.Text;
                Principal.clientes[atualCliente].cidade = txtCidade.Text;
                Principal.clientes[atualCliente].uf = txtUf.Text;
                Principal.clientes[atualCliente].cep = txtCep.Text;
                Principal.clientes[atualCliente].email = txtEmail.Text;
                Principal.clientes[atualCliente].tel = txtTelefone.Text;
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
            if (Principal.contCliente > 0)
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
                Principal.clientes[atualCliente].cpf = "";
                Principal.clientes[atualCliente].rg = "";
                Principal.clientes[atualCliente].endereco = "";
                Principal.clientes[atualCliente].bairro = "";
                Principal.clientes[atualCliente].cidade = "";
                Principal.clientes[atualCliente].uf = "";
                Principal.clientes[atualCliente].cep = "";
                Principal.clientes[atualCliente].email = "";
                Principal.clientes[atualCliente].tel = "";
                MostrarDadosCliente();
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            pnlPesquisa.Visible = true;
            txtPesquisa.Text = "";
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            int i;

            for (i = 0; i < Principal.contCliente; i++)
            {
                if (Principal.clientes[i].nome.IndexOf(txtPesquisa.Text) >= 0)
                {
                    atualCliente = i;
                    MostrarDadosCliente();
                    break;
                }
            }
            if (i >= Principal.contCliente)
            {
                MessageBox.Show("Cadastro não encontrado ou não existente");
            }
            pnlPesquisa.Visible = false;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string strDados;
            Graphics objImpressao = e.Graphics;

            strDados = "FICHA DE CLIENTES" + (char)10 + (char)10;
            objImpressao.DrawString(strDados, new Font("Arial", 20, FontStyle.Bold), Brushes.Red, 300, 50);

            strDados = "Código: " + txtCodigo.Text + (char)10;
            strDados += "Nome: " + txtNome.Text + (char)10;
            strDados += "CPF: " + txtCpf.Text + (char)10;
            strDados += "RG: " + txtRg.Text + (char)10;
            strDados += "Endereço: " + txtEndereco.Text + (char)10;
            strDados += "Bairro: " + txtBairro.Text + (char)10;
            strDados += "Cidade: " + txtCidade.Text + (char)10;
            strDados += "UF: " + txtUf.Text + (char)10;
            strDados += "CEP: " + txtCep.Text + (char)10;
            strDados += "Telefone: " + txtTelefone.Text + (char)10;
            strDados += "E-mail: " + txtEmail.Text;

            objImpressao.DrawString(strDados, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 50, 120);
            objImpressao.DrawLine(new Pen(Brushes.Black), 50, 80, 800, 80);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }
    }
}
