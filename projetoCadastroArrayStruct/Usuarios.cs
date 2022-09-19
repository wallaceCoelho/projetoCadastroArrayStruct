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
        bool tipoEdicao = false;
        int atual = 0;

        private void MostrarDadosUsuario()
        {
            txtCodigo.Text = Principal.usuarios[atual].codigo.ToString();
            txtNome.Text = Principal.usuarios[atual].nome;
            txtNivel.Text = Principal.usuarios[atual].nivel;
            txtLogin.Text = Principal.usuarios[atual].login;
            txtSenha.Text = Principal.usuarios[atual].senha;
        }
        private void DesabilitaEdicao()
        {
            //Desabilita opções no cadastro
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
            //Habilita outras funções no cadastro
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
            if (tipoEdicao)
            {
                Principal.usuarios[Principal.contUsuario].codigo = int.Parse(txtCodigo.Text);
                Principal.usuarios[Principal.contUsuario].nome = txtNome.Text;
                Principal.usuarios[Principal.contUsuario].nivel = txtNivel.Text;
                Principal.usuarios[Principal.contUsuario].login = txtLogin.Text;
                Principal.usuarios[Principal.contUsuario].senha = txtSenha.Text;
                atual = Principal.contUsuario++;
            }
            else
            {
                Principal.usuarios[atual].nome = txtNome.Text;
                Principal.usuarios[atual].nivel = txtNivel.Text;
                Principal.usuarios[atual].login = txtLogin.Text;
                Principal.usuarios[atual].senha = txtSenha.Text;
            }
            DesabilitaEdicao();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DesabilitaEdicao();
            MostrarDadosUsuario();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (Principal.contUsuario < 10)
            {
                txtCodigo.Text = (Principal.contUsuario + 1).ToString();
                txtNome.Text = "";
                txtNivel.Text = "";
                txtLogin.Text = "";
                txtSenha.Text = "";
                HabilitaEdicao();
                tipoEdicao = true;
            }
            else MessageBox.Show("Arquivo cheio");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (Principal.contUsuario > 0)
            {
                HabilitaEdicao();
                tipoEdicao = false;
            }
            else MessageBox.Show("Arquivo vazio");
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (atual > 0)
            {
                atual--;
                MostrarDadosUsuario();
            }
            else MessageBox.Show("Início do arquivo!");
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            {
                if (atual < Principal.contUsuario - 1)
                {
                    atual++;
                    MostrarDadosUsuario();
                }
                else MessageBox.Show("Fim de arquivo!");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (Principal.contUsuario > 0)
            {
                Principal.usuarios[atual].nome = "";
                Principal.usuarios[atual].nivel = "";
                Principal.usuarios[atual].login = "";
                Principal.usuarios[atual].senha = "";
                MostrarDadosUsuario();
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

            for (i = 0; i < Principal.contUsuario; i++)
            {
                if (Principal.usuarios[i].nome.IndexOf(txtPesquisa.Text) >= 0)
                {
                    atual = i;
                    MostrarDadosUsuario();
                    break;
                }
            } 
            if (i >= Principal.contUsuario)
            {
                MessageBox.Show("Cadastro não encontrado ou não existente");
            }
            pnlPesquisa.Visible = false;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string strDados;
            Graphics objImpressao = e.Graphics;

            strDados = "FICHA DE USUÁRIO" +(char)10 + (char)10;
            objImpressao.DrawString(strDados, new Font("Arial", 20, FontStyle.Bold), Brushes.Red, 300, 50);

            strDados = "Código: " + txtCodigo.Text + (char)10;
            strDados += "Nome: " + txtNome.Text + (char)10;
            strDados += "Nível: " + txtNivel.Text + (char)10;
            strDados += "Login: " + txtLogin.Text;

            objImpressao.DrawString(strDados, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 50, 120);
            objImpressao.DrawLine(new Pen(Brushes.Black), 50, 80, 800, 80);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }
    }
}
