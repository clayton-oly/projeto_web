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
    public partial class frmGridProdutos : Form
    {
        public frmGridProdutos()
        {
            InitializeComponent();
        }

        public DataGridViewCellEventArgs celulaClicada { get; set; }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbNome.Checked)
                {
                    CURSOEntitiesCasa banco = new CURSOEntitiesCasa();

                    //define no grid os dados que serão exibidos
                    dgvProdutos.DataSource = (from x in banco.Produtos
                                              where x.Nome_Produto.Contains(txtValor.Text)
                                              select new
                                              {
                                                  Id = x.ID_Produto,
                                                  Nome = x.Nome_Produto,
                                                  Quantidade = x.Quantidade,
                                                  Preço = x.Preco,
                                                  Fornecedor = x.Fornecedor
                                              }).ToList();

                    //esconder coluna para não aparecer na tela
                    dgvProdutos.Columns["Id"].Visible = false;
                }
                else
                {
                    CURSOEntitiesCasa banco = new CURSOEntitiesCasa();

                    //define no grid os dados que serão exibidos
                    dgvProdutos.DataSource = (from x in banco.Produtos
                                              where x.Marca.Contains(txtValor.Text)
                                              select new
                                              {
                                                  Id = x.ID_Produto,
                                                  Nome = x.Nome_Produto,
                                                  Quantidade = x.Quantidade,
                                                  Preço = x.Preco,
                                                  Fornecedor = x.Fornecedor
                                              }).ToList();

                    //esconder coluna para não aparecer na tela
                    dgvProdutos.Columns["Id"].Visible = false;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void frmGridProdutos_Load(object sender, EventArgs e)
        {
            txtValor.Focus();
        }


        private void btnFechar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult;
                dialogResult = MessageBox.Show("Dejesa sair, podera perde dados não salvos?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (rbMarca.Checked)
            {
                txtValor.MaxLength = 100;
            }
            else
            {
                txtValor.MaxLength = 100;
            }
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmProdutos hijo = new frmProdutos();
                AddOwnedForm(hijo);
                hijo.FormBorderStyle = FormBorderStyle.None;
                hijo.TopLevel = false;
                hijo.Dock = DockStyle.Fill;
                this.Controls.Add(hijo);
                this.Tag = hijo;
                hijo.BringToFront();
                hijo.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void alterarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string textoID;
                //só exclui se foi clicado em cima de uma célula
                if (celulaClicada != null)
                {
                    textoID = dgvProdutos.Rows[celulaClicada.RowIndex].Cells["id"].Value.ToString();

                    CURSOEntitiesCasa banco = new CURSOEntitiesCasa();

                    //Convertando para Id para Inteiro
                    //Antes de buscar no banco de dados

                    int Id = int.Parse(textoID);

                    //Busco a turma
                    Produto produto = banco.Produtos.Find(Id);


                    frmProdutos hijo = new frmProdutos();
                    AddOwnedForm(hijo);
                    hijo.FormBorderStyle = FormBorderStyle.None;
                    hijo.TopLevel = false;
                    hijo.Dock = DockStyle.Fill;
                    this.Controls.Add(hijo);
                    this.Tag = hijo;
                    hijo.BringToFront();


                    //Preenche os dados de alteração nos campos
                    hijo.PreencherAlteracao(produto);

                    //abre a janela
                    hijo.Show();

                    //Atualiza o DatagridView
                    btnConsultar_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Não tem nenhum produto selecionado", "Alteração", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message ,"Alteração", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult;
                dialogResult = MessageBox.Show("Você tem certeza que quer excluir este item?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    //Quando clicado no botão excluir

                    //crianção da variavel

                    string textoID;

                    //só exclui se foi clicado em cima de uma célula
                    if (celulaClicada != null)
                    {
                        textoID = dgvProdutos.Rows[celulaClicada.RowIndex].Cells["id"].Value.ToString();

                        CURSOEntitiesCasa banco = new CURSOEntitiesCasa();

                        //Convertando para Id para Inteiro
                        //Antes de buscar no banco de dados

                        int Id = int.Parse(textoID);

                        //Busco a turma
                        Produto produto = banco.Produtos.Find(Id);

                        //Removo turma
                        banco.Produtos.Remove(produto);

                        //Salvo as alterações
                        banco.SaveChanges();

                        //Apertando botão pesquisar
                        btnConsultar_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Não tem nenhum Produto selecionado", "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message ,"Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void dgvProdutos_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            //Quando clicado sobre a linha
            celulaClicada = e;
        }

        private void dgvProdutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DialogResult dialogResult;
                dialogResult = MessageBox.Show("Dejesa fazer alteração?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {


                    string textoID;
                    //só exclui se foi clicado em cima de uma célula
                    if (celulaClicada != null)
                    {
                        textoID = dgvProdutos.Rows[celulaClicada.RowIndex].Cells["id"].Value.ToString();

                        CURSOEntitiesCasa banco = new CURSOEntitiesCasa();

                        //Convertando para Id para Inteiro
                        //Antes de buscar no banco de dados

                        int Id = int.Parse(textoID);

                        //Busco a turma
                        Produto produto = banco.Produtos.Find(Id);


                        frmProdutos hijo = new frmProdutos();
                        AddOwnedForm(hijo);
                        hijo.FormBorderStyle = FormBorderStyle.None;
                        hijo.TopLevel = false;
                        hijo.Dock = DockStyle.Fill;
                        this.Controls.Add(hijo);
                        this.Tag = hijo;
                        hijo.BringToFront();


                        //Preenche os dados de alteração nos campos
                        hijo.PreencherAlteracao(produto);

                        //abre a janela
                        hijo.Show();

                        //Atualiza o DatagridView
                        btnConsultar_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Não tem nenhum produto selecionado", "Alteração", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        }
    }




