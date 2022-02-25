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
    public partial class frmGridFornecedor : Form
    {
        public frmGridFornecedor()
        {
            InitializeComponent();
        }
        public DataGridViewCellEventArgs celulaClicada { get; set; }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;
            dialogResult = MessageBox.Show("Dejesa sair, podera perde dados não salvos?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbNome.Checked)
                {
                    CURSOEntitiesCasa banco = new CURSOEntitiesCasa();

                    //define no grid os dados que serão exibidos
                    dgvFornecedor.DataSource = (from x in banco.Fornecedores
                                                where x.Razao_Social.Contains(txtValor.Text)
                                                select new
                                                {
                                                    Id = x.ID_Fornecedor,
                                                    Nome = x.Razao_Social,
                                                    CNPJ = x.CNPJ,
                                                    Telefone = x.Telefone,
                                                    Lougradouro = x.Lougradouro,
                                                    CEP = x.CEP
                                                }).ToList();

                    //esconder coluna para não aparecer na tela
                    dgvFornecedor.Columns["Id"].Visible = false;
                }
                else
                {
                    CURSOEntitiesCasa banco = new CURSOEntitiesCasa();

                    //define no grid os dados que serão exibidos
                    dgvFornecedor.DataSource = (from x in banco.Fornecedores
                                                where x.CNPJ.Contains(txtValor.Text)
                                                select new
                                                {
                                                    Id = x.ID_Fornecedor,
                                                    Nome = x.Razao_Social,
                                                    CNPJ = x.CNPJ,
                                                    Telefone = x.Telefone,
                                                    Lougradouro = x.Lougradouro,
                                                    CEP = x.CEP
                                                }).ToList();

                    //esconder coluna para não aparecer na tela
                    dgvFornecedor.Columns["Id"].Visible = false;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }


        private void frmGridFornecedor_Load(object sender, EventArgs e)
        {
            txtValor.Focus();
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (rbCPF.Checked)
            {
                solonumero(e);
                txtValor.MaxLength = 18;

                if (char.IsNumber(e.KeyChar) == true)


                    switch (txtValor.TextLength)
                    {

                        case 0:
                            txtValor.Text = "";
                            break;

                        case 2:
                            txtValor.Text = txtValor.Text + ".";
                            txtValor.SelectionStart = 4;
                            break;

                        case 6:
                            txtValor.Text = txtValor.Text + ".";
                            txtValor.SelectionStart = 8;
                            break;

                        case 10:
                            txtValor.Text = txtValor.Text + "/";
                            txtValor.SelectionStart = 12;
                            break;

                        case 15:
                            txtValor.Text = txtValor.Text + "-";
                            txtValor.SelectionStart = 17;
                            break;

                    }
            }
            else
            {
                txtValor.MaxLength = 100;
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

        public void sololetras(KeyPressEventArgs e)
        {
            try
            {
                if (char.IsLetter(e.KeyChar))
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

        private void dgvFornecedor_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            //Quando clicado sobre a linha
            celulaClicada = e;
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFornecedor hijo = new frmFornecedor();
            AddOwnedForm(hijo);
            hijo.FormBorderStyle = FormBorderStyle.None;
            hijo.TopLevel = false;
            hijo.Dock = DockStyle.Fill;
            this.Controls.Add(hijo);
            this.Tag = hijo;
            hijo.BringToFront();
            hijo.Show();
        }

        private void alterarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string textoID;

                //só exclui se foi clicado em cima de uma célula
                if (celulaClicada != null)
                {
                    textoID = dgvFornecedor.Rows[celulaClicada.RowIndex].Cells["id"].Value.ToString();

                    CURSOEntitiesCasa banco = new CURSOEntitiesCasa();

                    //Convertando para Id para Inteiro
                    //Antes de buscar no banco de dados

                    int Id = int.Parse(textoID);

                    //Busco a turma
                    Fornecedore fornecedore = banco.Fornecedores.Find(Id);


                    frmFornecedor hijo = new frmFornecedor();
                    AddOwnedForm(hijo);
                    hijo.FormBorderStyle = FormBorderStyle.None;
                    hijo.TopLevel = false;
                    hijo.Dock = DockStyle.Fill;
                    this.Controls.Add(hijo);
                    this.Tag = hijo;
                    hijo.BringToFront();


                    //Preenche os dados de alteração nos campos
                    hijo.PreencherAlteracao(fornecedore);

                    //abre a janela
                    hijo.Show();

                    //Atualiza o DatagridView
                    btnConsultar_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Não tem nenhum fornecedor selecionado", "Alteração", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        textoID = dgvFornecedor.Rows[celulaClicada.RowIndex].Cells["id"].Value.ToString();

                        CURSOEntitiesCasa banco = new CURSOEntitiesCasa();

                        //Convertando para Id para Inteiro
                        //Antes de buscar no banco de dados

                        int Id = int.Parse(textoID);

                        //Busco a turma
                        Fornecedore fornecedore = banco.Fornecedores.Find(Id);

                        //Removo turma
                        banco.Fornecedores.Remove(fornecedore);

                        //Salvo as alterações
                        banco.SaveChanges();

                        //Apertando botão pesquisar
                        btnConsultar_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Não tem nenhum fornecedor selecionado", "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

