using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmGridVendas : Form
    {
        public frmGridVendas()
        {
            InitializeComponent();
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            try
            {
                //Creating iTextSharp Table from the DataTable data
                PdfPTable pdfTable = new PdfPTable(dgvVendas.ColumnCount);
                pdfTable.DefaultCell.Padding = 3;
                pdfTable.WidthPercentage = 30;
                pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfTable.DefaultCell.BorderWidth = 1;

                //Adding Header row
                foreach (DataGridViewColumn column in dgvVendas.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                    cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                    pdfTable.AddCell(cell);
                }

                //Adding DataRow
                foreach (DataGridViewRow row in dgvVendas.Rows)
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
                MessageBox.Show("Ocorreu um ao gerar o relatório. ","Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbNome.Checked)
                {
                    CURSOEntitiesCasa context = new CURSOEntitiesCasa();

                    IEnumerable<Pedido> lista = from p in context.Pedidos select p;
                    dgvVendas.Text = "Produtos: " + lista.Count();
                    dgvVendas.DataSource = lista.ToList();

                    context.Configuration.ProxyCreationEnabled = false;


                }
                else
                {
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
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
    }
}