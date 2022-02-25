using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace WindowsFormsApp1
{
    public partial class frmGridClientes : Form
    {

        public frmGridClientes()
        {
            InitializeComponent();
        }
        public DataGridViewCellEventArgs celulaClicada { get; set; }

        private void frmGridClientes_Load(object sender, EventArgs e)
        {
            txtValor.Focus();
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

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbNome.Checked)
                {
                    CURSOEntitiesCasa banco = new CURSOEntitiesCasa();

                    //define no grid os dados que serão exibidos
                    dgvClientes.DataSource = (from x in banco.Clientes
                                              where x.Nome_Cliente.Contains(txtValor.Text)
                                              select new
                                              {
                                                  Id = x.ID_Cliente,
                                                  Nome = x.Nome_Cliente,
                                                  CPF = x.CPF,
                                                  Telefone = x.Telefone,
                                                  DATA_DE_NASCIMENTO = x.Data_Nasc,
                                              }).ToList();

                    //esconder coluna para não aparecer na tela
                    dgvClientes.Columns["Id"].Visible = false;
                }
                else
                {
                    CURSOEntitiesCasa banco = new CURSOEntitiesCasa();

                    //define no grid os dados que serão exibidos
                    dgvClientes.DataSource = (from x in banco.Clientes
                                              where x.CPF.Contains(txtValor.Text)
                                              select new
                                              {
                                                  Id = x.ID_Cliente,
                                                  Nome = x.Nome_Cliente,
                                                  CPF = x.CPF,
                                                  Telefone = x.Telefone,
                                                  DATA_DE_NASCIMENTO = x.Data_Nasc,
                                              }).ToList();

                    //esconder coluna para não aparecer na tela
                    dgvClientes.Columns["Id"].Visible = false;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void dgvClientes_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            //Quando clicado sobre a linha
            celulaClicada = e;
        }

        private void alterarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string textoID;


                //só exclui se foi clicado em cima de uma célula
                if (celulaClicada != null)
                {
                    textoID = dgvClientes.Rows[celulaClicada.RowIndex].Cells["id"].Value.ToString();

                    CURSOEntitiesCasa banco = new CURSOEntitiesCasa();

                    //Convertando para Id para Inteiro
                    //Antes de buscar no banco de dados

                    int Id = int.Parse(textoID);

                    //Busco a turma
                    Cliente cliente = banco.Clientes.Find(Id);


                    frmClientes hijo = new frmClientes();
                    AddOwnedForm(hijo);
                    hijo.FormBorderStyle = FormBorderStyle.None;
                    hijo.TopLevel = false;
                    hijo.Dock = DockStyle.Fill;
                    this.Controls.Add(hijo);
                    this.Tag = hijo;
                    hijo.BringToFront();


                    //Preenche os dados de alteração nos campos
                    hijo.PreencherAlteracao(cliente);

                    //abre a janela
                    hijo.Show();

                    //Atualiza o DatagridView
                    btnConsultar_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Não tem nenhum Cliente selecionado", "Alteração", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alteração", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        textoID = dgvClientes.Rows[celulaClicada.RowIndex].Cells["id"].Value.ToString();

                        CURSOEntitiesCasa banco = new CURSOEntitiesCasa();

                        //Convertando para Id para Inteiro
                        //Antes de buscar no banco de dados

                        int Id = int.Parse(textoID);

                        //Busco a turma
                        Cliente cliente = banco.Clientes.Find(Id);

                        //Removo turma
                        banco.Clientes.Remove(cliente);

                        //Salvo as alterações
                        banco.SaveChanges();

                        //Apertando botão pesquisar
                        btnConsultar_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Não tem nenhum Cliente selecionado", "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }


        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClientes hijo = new frmClientes();
            AddOwnedForm(hijo);
            hijo.FormBorderStyle = FormBorderStyle.None;
            hijo.TopLevel = false;
            hijo.Dock = DockStyle.Fill;
            this.Controls.Add(hijo);
            this.Tag = hijo;
            hijo.BringToFront();
            hijo.Show();
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

        private void btnGerar_Click(object sender, EventArgs e)
        {
            try
            {
                //Creating iTextSharp Table from the DataTable data
                PdfPTable pdfTable = new PdfPTable(dgvClientes.ColumnCount);
                pdfTable.DefaultCell.Padding = 3;
                pdfTable.WidthPercentage = 30;
                pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfTable.DefaultCell.BorderWidth = 1;

                //Adding Header row
                foreach (DataGridViewColumn column in dgvClientes.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                    cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                    pdfTable.AddCell(cell);
            
                }

                //Adding DataRow
                foreach (DataGridViewRow row in dgvClientes.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        pdfTable.AddCell(cell.Value.ToString());

                    }
                }
                //Exporting to PDF
                string folderPath = "C:\\PDFs\\";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                using (FileStream stream = new FileStream(folderPath + "Relatorio.pdf", FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(pdfTable);
                    pdfDoc.Close();
                    stream.Close();
                }
                MessageBox.Show("Relatório gerado com sucesso");
            }

            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um ao gerar o relatório. " + ex.Message);
            }


        }

    }
}


