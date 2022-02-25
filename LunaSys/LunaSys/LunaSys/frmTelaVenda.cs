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
    public partial class frmTelaVenda : Form
    {
        public frmTelaVenda()
        {
            InitializeComponent();
        }

        List<ItensPedido> lista = new List<ItensPedido>();

        public static int IdUsuarioV { get; set; }
        private int idCliente;

        private void txtIdPedido_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int idp;

                bool s = Int32.TryParse(txtCodigoProduto.Text, out idp);

                if (!s)
                {
                    MessageBox.Show("Digite uma Código do produto válido", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
                else
                {
                    CURSOEntitiesCasa banco = new CURSOEntitiesCasa();

                    Produto turma = banco.Produtos.FirstOrDefault(x => x.ID_Produto == idp);

                    if (turma != null)
                    {
                        //  txtCodigo.Text = turma.id.ToString();
                        txtProduto.Text = turma.Nome_Produto;
                        txtValorUnitario.Text = turma.Preco.ToString();
                        txtEstoque.Text = turma.Quantidade.ToString();

                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        private void GerarCodigoVenda()
        {
            try
            {

                CURSOEntitiesCasa banco = new CURSOEntitiesCasa();

                int pedido = 0;
                if (banco.Pedidos.Count() > 0)
                {
                    pedido = banco.Pedidos.Max(x => x.ID_Pedido);
                    int rar = +1;
                    pedido = pedido + rar;

                    lbCodigo.Text = pedido.ToString();
                }
                else
                {
                    lbCodigo.Text = "1";
                }

            }
            catch (Exception ex)
            {


                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        public void NomearGrid()
        {
            try
            {
                CURSOEntitiesCasa banco = new CURSOEntitiesCasa();
                List<Produto> produtos = banco.Produtos.ToList();
                dgvVendas.DataSource = (from x in lista
                                        join y in produtos on x.ID_ItensProduto equals y.ID_Produto
                                        select new
                                        {
                                            Código = y.ID_Produto,
                                            Nome = y.Nome_Produto,
                                            Valor = x.Valor_Total,
                                            Quantidade = x.Quantidade,
                                        }
                                        ).ToList();

                var soma = lista.Sum(item => item.Valor_Total);
                var cont = lista.Count();

                lbVenda.Text = soma.ToString();
                lbItens.Text = cont.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        private void frmTelaVenda_Load(object sender, EventArgs e)
        {
            try
            {
                NomearGrid();
                txtVendedor.Text = frmInicio.usuarioConectado;

                GerarCodigoVenda();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtQuant_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtCodigoProduto.Text != string.Empty)
                {
                    if (txtQuant.Text != string.Empty)
                    {
                        txtVlrTotal.Text = (double.Parse(txtValorUnitario.Text) * double.Parse(txtQuant.Text)).ToString();
                        string vrltotal = txtVlrTotal.Text;

                        double valorConvertido = double.Parse(vrltotal);
                        string Formato1 = String.Format("{0:C}", valorConvertido);
                        txtVlrTotal.Text = Formato1;
                        txtVlrTotal.Text = txtVlrTotal.Text.Replace("R$", "");
                    }
                }
                else
                {
                    MessageBox.Show("insira um produto", "produto não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCodigoProduto.Focus();
                    txtQuant.Clear();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;
            dialogResult = MessageBox.Show("Dejesa sair, podera perde dados não salvos?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                this.Close();


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

        private void txtCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                solonumero(e);


                if (char.IsNumber(e.KeyChar) == true)
                {
                    switch (txtCliente.TextLength)
                    {

                        case 0:
                            txtCliente.Text = "";
                            break;

                        case 3:
                            txtCliente.Text = txtCliente.Text + ".";
                            txtCliente.SelectionStart = 5;
                            break;

                        case 7:
                            txtCliente.Text = txtCliente.Text + ".";
                            txtCliente.SelectionStart = 9;
                            break;

                        case 11:
                            txtCliente.Text = txtCliente.Text + "-";
                            txtCliente.SelectionStart = 12;
                            break;

                    }
                }
            }

            catch (Exception)
            {
            }
        }


        private void txtCliente_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                CURSOEntitiesCasa banco = new CURSOEntitiesCasa();

                Cliente cliente = banco.Clientes.FirstOrDefault(x => x.CPF == txtCliente.Text);

                if (cliente != null)
                {
                    txtNomeCli.Text = cliente.Nome_Cliente;
                    idCliente = cliente.ID_Cliente;
                    txtCodigoProduto.Focus();
                }
                else
                {
                    MessageBox.Show("Cliente não encontrado", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtNomeCli.Clear();
                    txtCliente.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }


        private void txtProduto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CURSOEntitiesCasa banco = new CURSOEntitiesCasa();

                Produto produto = banco.Produtos.FirstOrDefault(x => x.Nome_Produto == txtProduto.Text);

                if (produto != null)
                {
                    var v = from custom in banco.Produtos
                            select custom.Nome_Produto;
                    AutoCompleteStringCollection source = new AutoCompleteStringCollection();
                    source.AddRange(v.ToArray());
                    txtProduto.AutoCompleteMode = AutoCompleteMode.Suggest;
                    txtProduto.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtProduto.AutoCompleteCustomSource = source;

                    txtCodigoProduto.Text = produto.ID_Produto.ToString();
                    txtValorUnitario.Text = produto.Preco.ToString();
                    txtEstoque.Text = produto.Quantidade.ToString();
                }

            }
            catch (Exception)
            {

            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar() == false)
                {
                    return;
                }
                else
                {
                    CURSOEntitiesCasa banco = new CURSOEntitiesCasa();
                    ItensPedido itensPedido = new ItensPedido();
                    itensPedido.ID_ItensProduto = Convert.ToInt32(txtCodigoProduto.Text);
                    itensPedido.Quantidade = Convert.ToInt32(txtQuant.Text);
                    itensPedido.Valor_Total = Convert.ToDecimal(txtVlrTotal.Text);
                    limparAdicionar();
                    lista.Add(itensPedido);
                    NomearGrid();

                    string vrltotal = lbVenda.Text;

                    double valorConvertido = double.Parse(vrltotal);
                    string Formato1 = String.Format("{0:C}", valorConvertido);
                    lbVenda.Text = Formato1;
                    //lbVenda.Text = lbVenda.Text.Replace("R$", "");

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Nenhum produto adicionado para fazer a venda", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCodigoProduto.Focus();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                lista.RemoveAt(dgvVendas.CurrentCell.RowIndex);
                NomearGrid();
            }
            catch (Exception)
            {

                MessageBox.Show("Não existe produto para ser removido", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtCodigoProduto.Text))
            {
                MessageBox.Show("Campo Código do produto é obrigatorio", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigoProduto.Focus();
                return false;
            }
            else
            if (string.IsNullOrWhiteSpace(txtQuant.Text))
            {
                MessageBox.Show("Campo quantidade é obrigatorio", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuant.Focus();
                return false;
            }

            return true;
        }


        private void btnVenda_Click(object sender, EventArgs e)
        {
            Pedido pedido = new Pedido();

            pedido.ItensPedidos = lista;

            //Objeto para acessar o banco de dados
            CURSOEntitiesCasa banco = new CURSOEntitiesCasa();
            try
            {
                if (dgvVendas.RowCount == 0)
                {
                    MessageBox.Show("Vazio");
                }
                else
                {
                    if (pedido.ID_PedidoCliente != null)
                    {

                        pedido.ID_PedidoCliente = idCliente;
                    }
                    pedido.ID_PedidoUsuario = IdUsuarioV;
                    pedido.Data = DateTime.Now;
                    //adiciona o pedido 
                    banco.Pedidos.Add(pedido);
                    //Efetiva as alterações do banco de dados
                    banco.SaveChanges();

                    //Aparece a mensagem e fecha a janela
                    MessageBox.Show("Venda Finalizada com sucesso", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    


        private void txtCodigoProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            solonumero(e);
        }

        private void txtQuant_KeyPress(object sender, KeyPressEventArgs e)
        {
            solonumero(e);
        }

        public void LimpaCampos()
        {
            dgvVendas.Rows.Clear();
            lbItens.Text = "0";
            lbVenda.Focus();
            txtCliente.Clear();
            txtNomeCli.Clear();
            txtCodigoProduto.Clear();
            txtProduto.Clear();
            txtQuant.Clear();
            txtValorUnitario.Clear();
            txtVlrTotal.Clear();
            txtEstoque.Clear();

        }

        public void limparAdicionar()
        {
            txtCodigoProduto.Clear();
            txtProduto.Clear();
            txtQuant.Clear();
            txtValorUnitario.Clear();
            txtVlrTotal.Clear();
            txtEstoque.Clear();

        }

    }
}

