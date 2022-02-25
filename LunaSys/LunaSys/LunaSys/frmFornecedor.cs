using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Modelos;

namespace WindowsFormsApp1
{
    public partial class frmFornecedor : Form
    {
        public frmFornecedor()
        {
            InitializeComponent();
        }

        public int IdFornecedorAlteracao { get; set; }

        public void PreencherAlteracao(Fornecedore fornecedore)
        {
            try
            {
                txtCNPJ.Enabled = false;
                //Guarda o id do Fornecedor que está sendo alterada
                IdFornecedorAlteracao = fornecedore.ID_Fornecedor;

                //Preenche os dados na tela
                txtCNPJ.Text = fornecedore.CNPJ;
                txtNome.Text = fornecedore.Razao_Social;
                txtTelefone.Text = fornecedore.Telefone;
                txtCEP.Text = fornecedore.CEP;
                txtLougradouro.Text = fornecedore.Lougradouro;
                txtNum.Text = fornecedore.Numero;
                txtComplemento.Text = fornecedore.Complemento;
                txtBairro.Text = fornecedore.Bairro;
                txtCidade.Text = fornecedore.Cidade;
                txtEstado.Text = fornecedore.Estado;
                txtId.Text = fornecedore.ID_Fornecedor.ToString();
                btnSalvar.Text = "Alterar";
            }
            catch (Exception)
            {
                MessageBox.Show("Erro", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void txtCNPJ_KeyPress(object sender, KeyPressEventArgs e)
        {
            solonumero(e);

            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (txtCNPJ.TextLength)
                {

                    case 0:
                        txtCNPJ.Text = "";
                        break;

                    case 2:
                        txtCNPJ.Text = txtCNPJ.Text + ".";
                        txtCNPJ.SelectionStart = 4;
                        break;

                    case 6:
                        txtCNPJ.Text = txtCNPJ.Text + ".";
                        txtCNPJ.SelectionStart = 8;
                        break;

                    case 10:
                        txtCNPJ.Text = txtCNPJ.Text + "/";
                        txtCNPJ.SelectionStart = 12;
                        break;

                    case 15:
                        txtCNPJ.Text = txtCNPJ.Text + "-";
                        txtCNPJ.SelectionStart = 17;
                        break;

                }
            }
        }

        private void txtCNPJ_Validated(object sender, EventArgs e)
        {
            if (Validacao.IsCnpj(txtCNPJ.Text) == false)
            {
                lbCNPJINVALIDO.Visible = true;
            }
            else
            {
                lbCNPJINVALIDO.Visible = false;
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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar() == false)
                {
                    return;
                }
                else if (Validacao.IsCnpj(txtCNPJ.Text) == false)
                {

                    MessageBox.Show("Por favor insira um CNPJ válido", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCNPJ.Focus();
                    return;

                }

                if (IdFornecedorAlteracao == 0)
                {
                    verificarCNPJ();
                    Fornecedore ab = new Fornecedore();
                    ab.Razao_Social = txtNome.Text;
                    ab.CNPJ = txtCNPJ.Text;
                    ab.Telefone = txtTelefone.Text;
                    ab.CEP = txtCEP.Text;
                    ab.Lougradouro = txtLougradouro.Text;
                    ab.Numero = txtNum.Text;
                    ab.Complemento = txtComplemento.Text;
                    ab.Bairro = txtBairro.Text;
                    ab.Cidade = txtCidade.Text;
                    ab.Estado = txtEstado.Text;
                    ////Objeto para acessar o banco de dados
                    CURSOEntitiesCasa banco = new CURSOEntitiesCasa();

                    ////adiciona o cliente 
                    banco.Fornecedores.Add(ab);

                    ////Efetiva as alterações do banco de dados
                    banco.SaveChanges();

                    //Aparece a mensagem e fecha a janela
                    MessageBox.Show("Fornecedor cadastrado com sucesso", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    Fornecedore fornecedore;
                    CURSOEntitiesCasa banco = new CURSOEntitiesCasa();
                    fornecedore = banco.Fornecedores.Find(IdFornecedorAlteracao);

                    fornecedore.Razao_Social = txtNome.Text;
                    fornecedore.CNPJ = txtCNPJ.Text;
                    fornecedore.Telefone = txtTelefone.Text;
                    fornecedore.CEP = txtCEP.Text;
                    fornecedore.Lougradouro = txtLougradouro.Text;
                    fornecedore.Numero = txtNum.Text;
                    fornecedore.Complemento = txtComplemento.Text;
                    fornecedore.Bairro = txtBairro.Text;
                    fornecedore.Cidade = txtCidade.Text;
                    fornecedore.Estado = txtEstado.Text;

                    banco.SaveChanges();
                    MessageBox.Show("Alterado com sucesso", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Campo Razão Social é obrigatorio", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return false;
            }
            else
            if (string.IsNullOrWhiteSpace(txtCNPJ.Text))
            {
                MessageBox.Show("Campo CNPJ é obrigatorio", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCNPJ.Focus();
                return false;
            }
            else
            if (string.IsNullOrWhiteSpace(txtTelefone.Text))
            {
                MessageBox.Show("Campo Telefone é obrigatorio", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefone.Focus();
                return false;
            }

            return true;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;
            dialogResult = MessageBox.Show("Dejesa sair, podera perde dados não salvos?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }
        public void LimpaTela()
        {
            txtId.Clear();
            txtNome.Clear();
            txtCNPJ.Clear();
            txtTelefone.Clear();
            txtCidade.Clear();
            txtEstado.Clear();
            txtBairro.Clear();
            txtComplemento.Clear();
            txtLougradouro.Clear();
            txtNum.Clear();
            txtCEP.Clear();
            lbCNPJINVALIDO.Visible = false;

        }

        private void txtTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            solonumero(e);

            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (txtTelefone.TextLength)
                {

                    case 0:
                        txtTelefone.Text = "(";
                        txtTelefone.SelectionStart = 2;
                        break;

                    case 3:
                        txtTelefone.Text = txtTelefone.Text + ")";
                        txtTelefone.SelectionStart = 5;
                        break;

                    case 9:
                        txtTelefone.Text = txtTelefone.Text + "-";
                        txtTelefone.SelectionStart = 11;
                        break;
                }
            }
        }

        private void txtCEP_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                solonumero(e);


                if (char.IsNumber(e.KeyChar) == true)
                {
                    switch (txtCEP.TextLength)
                    {

                        case 0:
                            txtCEP.Text = "";
                            break;

                        case 5:
                            txtCEP.Text = txtCEP.Text + "-";
                            txtCEP.SelectionStart = 6;
                            break;
                    }


                }

            }
            catch (Exception)
            {

            }
        }
        public void WebCEP(string CEP)
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml("http://cep.republicavirtual.com.br/web_cep.php?cep=" +
                    CEP.Replace("-", "").Trim() + "&formato=xml");
                txtLougradouro.Text = ds.Tables[0].Rows[0]["tipo_logradouro"].ToString().Trim() +
                    " " + ds.Tables[0].Rows[0]["logradouro"].ToString().Trim();
                txtCidade.Text = ds.Tables[0].Rows[0]["cidade"].ToString().Trim();
                txtBairro.Text = ds.Tables[0].Rows[0]["bairro"].ToString().Trim();
                txtEstado.Text = ds.Tables[0].Rows[0]["uf"].ToString().Trim();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } 
        }
        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            try
            {
                WebCEP(txtCEP.Text);
                txtCEP.Focus();
            }
            catch (Exception)
            {

                MessageBox.Show("Erro ao consultar o CEP", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void verificarCNPJ()
        {
            CURSOEntitiesCasa banco = new CURSOEntitiesCasa();

            //Busca o usuario que tenha o login igual ao usuario digitado
            Fornecedore fornecedore = banco.Fornecedores.FirstOrDefault(x => x.CNPJ == txtCNPJ.Text);

            if (fornecedore != null)
            {
                MessageBox.Show("CNPJ Já Cadastrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCNPJ.Focus();
                return;
            }
        }

        private void frmFornecedor_Load(object sender, EventArgs e)
        {
            txtNome.Focus();
        }
    }
}




