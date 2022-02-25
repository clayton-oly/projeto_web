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
    public partial class frmGridUsuarios : Form
    {
        public frmGridUsuarios()
        {
            InitializeComponent();
        }
        public DataGridViewCellEventArgs celulaClicada { get; set; }

        private void frmGridUsuarios_Load(object sender, EventArgs e)
        {
            txtValor.Focus();
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

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbNome.Checked)
                {
                    CURSOEntitiesCasa banco = new CURSOEntitiesCasa();

                    //define no grid os dados que serão exibidos
                    dgvUsuarios.DataSource = (from x in banco.Usuarios
                                              where x.Nome.Contains(txtValor.Text)
                                              select new
                                              {
                                                  Id = x.ID_Usuario,
                                                  Nome = x.Nome,
                                                  Login = x.Login,
                                                  Telefone = x.Telefone,
                                                  CPF = x.CPF,
                                                  Função = x.Funcao
                                              }).ToList();

                    //esconder coluna para não aparecer na tela
                    dgvUsuarios.Columns["Id"].Visible = false;
                }
                else
                {
                    CURSOEntitiesCasa banco = new CURSOEntitiesCasa();

                    //define no grid os dados que serão exibidos
                    dgvUsuarios.DataSource = (from x in banco.Usuarios
                                              where x.Nome.Contains(txtValor.Text)
                                              select new
                                              {
                                                  Id = x.ID_Usuario,
                                                  Nome = x.Nome,
                                                  Login = x.Login,
                                                  Telefone = x.Telefone,
                                                  CPF = x.CPF,
                                                  Função = x.Funcao
                                              }).ToList();

                    //esconder coluna para não aparecer na tela
                    dgvUsuarios.Columns["Id"].Visible = false;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
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
            if (rbCPF.Checked)
            {
                solonumero(e);
                txtValor.MaxLength = 14;

                if (char.IsNumber(e.KeyChar) == true)


                    switch (txtValor.TextLength)
                    {

                        case 0:
                            txtValor.Text = "";
                            break;

                        case 3:
                            txtValor.Text = txtValor.Text + ".";
                            txtValor.SelectionStart = 5;
                            break;

                        case 7:
                            txtValor.Text = txtValor.Text + ".";
                            txtValor.SelectionStart = 9;
                            break;

                        case 11:
                            txtValor.Text = txtValor.Text + "-";
                            txtValor.SelectionStart = 12;
                            break;
                    }
            }
            else
            {
                txtValor.MaxLength = 100;
                sololetras(e);
            }
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                frmUsuarios hijo = new frmUsuarios();
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
                    textoID = dgvUsuarios.Rows[celulaClicada.RowIndex].Cells["id"].Value.ToString();

                    CURSOEntitiesCasa banco = new CURSOEntitiesCasa();

                    //Convertando para Id para Inteiro
                    //Antes de buscar no banco de dados

                    int Id = int.Parse(textoID);

                    //Busco a turma
                    Usuario usuario = banco.Usuarios.Find(Id);


                    frmUsuarios hijo = new frmUsuarios();
                    AddOwnedForm(hijo);
                    hijo.FormBorderStyle = FormBorderStyle.None;
                    hijo.TopLevel = false;
                    hijo.Dock = DockStyle.Fill;
                    this.Controls.Add(hijo);
                    this.Tag = hijo;
                    hijo.BringToFront();


                    //Preenche os dados de alteração nos campos
                    hijo.PreencherAlteracao(usuario);

                    //abre a janela
                    hijo.Show();

                    //Atualiza o DatagridView
                    btnConsultar_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Não tem nenhum usuário selecionado", "Alteração", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Alteração", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        textoID = dgvUsuarios.Rows[celulaClicada.RowIndex].Cells["id"].Value.ToString();

                        CURSOEntitiesCasa banco = new CURSOEntitiesCasa();

                        //Convertando para Id para Inteiro
                        //Antes de buscar no banco de dados

                        int Id = int.Parse(textoID);

                        //Busco a turma
                        Usuario usuario = banco.Usuarios.Find(Id);

                        //Removo turma
                        banco.Usuarios.Remove(usuario);

                        //Salvo as alterações
                        banco.SaveChanges();

                        //Apertando botão pesquisar
                        btnConsultar_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Não tem nenhum usuário selecionado", "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message , "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        

        private void dgvUsuarios_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            //Quando clicado sobre a linha
            celulaClicada = e;
        }
    }
}
