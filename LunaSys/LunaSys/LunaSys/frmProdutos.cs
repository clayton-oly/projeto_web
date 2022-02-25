using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmProdutos : Form
    {
        public frmProdutos()
        {
            InitializeComponent();
        }

        public int IdProdutoAlteracao { get; set; }

        public void PreencherAlteracao(Produto produto)
        {
            try
            {
                //Guarda o id do Cliente que está sendo alterada
                IdProdutoAlteracao = produto.ID_Produto;

                //Preenche os dados na tela
                txtNome.Text = produto.Nome_Produto;
                txtPreco.Text = produto.Preco.ToString();
                txtMarca.Text = produto.Marca;
                txtQuantidade.Text = produto.Quantidade.ToString();
                cboFornecedor.Text = produto.Fornecedor.ToString();
                txtDescricao.Text = produto.Descricao;
                txtId.Text = produto.ID_Produto.ToString();
                btnSalvar.Text = "Alterar";
            }
            catch (Exception)
            {
                MessageBox.Show("Erro", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar() == false)
                {
                    return;
                }

                if (IdProdutoAlteracao == 0)
                {
                    Produto produto = new Produto();
                    produto.Nome_Produto = txtNome.Text;
                    produto.Fornecedor = (cboFornecedor.Text);
                    produto.Preco = Convert.ToDecimal(txtPreco.Text);
                    produto.Marca = txtMarca.Text;
                    produto.Descricao = txtDescricao.Text;
                    produto.Quantidade = Convert.ToInt32(txtQuantidade.Text);


                    ////Objeto para acessar o banco de dados
                    CURSOEntitiesCasa banco = new CURSOEntitiesCasa();

                    ////adiciona o cliente 
                    banco.Produtos.Add(produto);

                    ////Efetiva as alterações do banco de dados
                    banco.SaveChanges();

                    //Aparece a mensagem e fecha a janela
                    MessageBox.Show("Produto cadastrado com sucesso", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    Produto produto;
                    CURSOEntitiesCasa banco = new CURSOEntitiesCasa();
                    produto = banco.Produtos.Find(IdProdutoAlteracao);

                    produto.Nome_Produto = txtNome.Text;
                    produto.Fornecedor = (cboFornecedor.Text);
                    produto.Preco = Convert.ToDecimal(txtPreco.Text);
                    produto.Marca = txtMarca.Text;
                    produto.Descricao = txtDescricao.Text;
                    produto.Quantidade = Convert.ToInt32(txtQuantidade.Text);
                    banco.SaveChanges();
                    MessageBox.Show("Alterado com sucesso", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Erro", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Campo Nome é obrigatorio", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return false;
            }
            else
            if (string.IsNullOrWhiteSpace(txtPreco.Text))
            {
                MessageBox.Show("Campo Preço é obrigatorio", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPreco.Focus();
                return false;
            }
            else
            if (string.IsNullOrWhiteSpace(cboFornecedor.Text))
            {
                MessageBox.Show("Campo Fornecedor é obrigatorio", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboFornecedor.Focus();
                return false;
            }

            return true;
        }
        private void frmProdutos_Load(object sender, EventArgs e)
        {
            try
            {
                //Objeto banco de dados
                CURSOEntitiesCasa entities = new CURSOEntitiesCasa();

                //Inserindo Turmas no combo
                cboFornecedor.DataSource = entities.Fornecedores.ToList();

                //Nome do campo que irá guardar o identificador
                cboFornecedor.ValueMember = "ID_Fornecedor";

                //Nome do campo que irá mostra na tela
                cboFornecedor.DisplayMember = "Razao_Social";
            }
            catch (Exception)
            {

                MessageBox.Show("Nenhum fornecedor cadastrado", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;
            dialogResult = MessageBox.Show("Dejesa sair, podera perde dados não salvos?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtPreco_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtPreco);
        }

        public static void Moeda(ref TextBox txt)
        {
            string n = string.Empty;
            double v = 0;
            try
            {
                n = txt.Text.Replace(",", "").Replace(".", "");
                if (n.Equals(""))
                    n = "";
                n = n.PadLeft(3, '0');
                if (n.Length > 3 && n.Substring(0, 1) == "0")
                    n = n.Substring(1, n.Length - 1);
                v = Convert.ToDouble(n) / 100;
                txt.Text = string.Format("{0:N}", v);
                txt.SelectionStart = txt.Text.Length;
            }
            catch (Exception)
            {

            }
        }
        public void solonumero(KeyPressEventArgs e)
        {
            try
            {
                if (char.IsNumber(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (char.IsSeparator(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            catch (Exception)
            {


            }

        }
        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            solonumero(e);
        }

        private void txtPreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            solonumero(e);
        }
    }
}
