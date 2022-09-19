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
    public partial class Produto : Form
    {
        bool tipoEdicao = false;
        int atualProduto = 0;
        public Produto()
        {
            InitializeComponent();
        }

        private void MostrarDadosProduto()
        {
            txtCodigo.Text = Principal.produto[atualProduto].codigo.ToString();
            txtDesc.Text = Principal.produto[atualProduto].desc;
            txtUnidade.Text = Principal.produto[atualProduto].unidade.ToString();
            txtQtEstoque.Text = Principal.produto[atualProduto].qtEstoque.ToString();
            txtPrecoCusto.Text = Principal.produto[atualProduto].precoCusto.ToString();
            txtPrecoVenda.Text = Principal.produto[atualProduto].precoVenda.ToString();
        }

        private void DesabilitaEdicao()
        {
            txtCodigo.Enabled = false;
            txtDesc.Enabled = false;
            txtUnidade.Enabled = false;
            txtQtEstoque.Enabled = false;
            txtPrecoCusto.Enabled = false;
            txtPrecoVenda.Enabled = false;
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
            txtDesc.Enabled = true;
            txtUnidade.Enabled = true;
            txtQtEstoque.Enabled = true;
            txtPrecoCusto.Enabled = true;
            txtPrecoVenda.Enabled = true;
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
        private void Produto_Load(object sender, EventArgs e)
        {
            DesabilitaEdicao();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DesabilitaEdicao();
            MostrarDadosProduto();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (tipoEdicao)
            {
                Principal.produto[Principal.contProduto].codigo = int.Parse(txtCodigo.Text);
                Principal.produto[Principal.contProduto].desc = txtDesc.Text;
                Principal.produto[Principal.contProduto].unidade = int.Parse(txtUnidade.Text);
                Principal.produto[Principal.contProduto].qtEstoque = int.Parse(txtQtEstoque.Text);
                Principal.produto[Principal.contProduto].precoCusto = float.Parse(txtPrecoCusto.Text);
                Principal.produto[Principal.contProduto].precoVenda = float.Parse(txtPrecoVenda.Text);
                atualProduto = Principal.contProduto++;
            }
            else
            {
                Principal.produto[atualProduto].codigo = int.Parse(txtCodigo.Text);
                Principal.produto[atualProduto].desc = txtDesc.Text;
                Principal.produto[atualProduto].unidade = int.Parse(txtUnidade.Text);
                Principal.produto[atualProduto].qtEstoque = int.Parse(txtQtEstoque.Text);
                Principal.produto[atualProduto].precoCusto = float.Parse(txtPrecoCusto.Text);
                Principal.produto[atualProduto].precoVenda = float.Parse(txtPrecoVenda.Text);
            }
            DesabilitaEdicao();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (Principal.contProduto < 10)
            {
                txtCodigo.Text = (Principal.contProduto + 1).ToString();
                txtDesc.Text = "";
                txtUnidade.Text = "";
                txtQtEstoque.Text = "";
                txtPrecoCusto.Text = "";
                txtPrecoVenda.Text = "";
                HabilitaEdicao();
                tipoEdicao = true;
            }
            else MessageBox.Show("Arquivo cheio");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (Principal.contProduto > 0)
            {
                HabilitaEdicao();
                tipoEdicao = false;
            }
            else MessageBox.Show("Arquivo vazio");
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (atualProduto > 0)
            {
                atualProduto--;
                MostrarDadosProduto();
            }
            else MessageBox.Show("Fim de arquivo!");
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            if (atualProduto < Principal.contProduto - 1)
            {
                atualProduto++;
                MostrarDadosProduto();
            }
            else MessageBox.Show("Fim de arquivo!");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (Principal.contProduto > 0)
            {
                Principal.produto[atualProduto].desc = "";
                Principal.produto[atualProduto].unidade = int.Parse("");
                Principal.produto[atualProduto].qtEstoque = int.Parse("");
                Principal.produto[atualProduto].precoVenda = float.Parse("");
                Principal.produto[atualProduto].precoCusto = float.Parse("");
                MostrarDadosProduto();
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

            for (i = 0; i < Principal.contProduto; i++)
            {
                if (Principal.produto[i].desc.IndexOf(txtPesquisa.Text) >= 0)
                {
                    atualProduto = i;
                    MostrarDadosProduto();
                    break;
                }
            }
            if (i >= Principal.contProduto)
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
            strDados += "Descrição: " + txtDesc.Text + (char)10;
            strDados += "Unidade: " + txtUnidade.Text + (char)10;
            strDados += "Quantidade em estoque: " + txtQtEstoque.Text + (char)10;
            strDados += "Preço de custo: " + txtPrecoCusto.Text + (char)10;
            strDados += "Preço de venda: " + txtPrecoVenda.Text;

            objImpressao.DrawString(strDados, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 50, 120);
            objImpressao.DrawLine(new Pen(Brushes.Black), 50, 80, 800, 80);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }
    }
}
