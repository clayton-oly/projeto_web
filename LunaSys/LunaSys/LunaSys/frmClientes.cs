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
using System.Runtime.InteropServices;

namespace WindowsFormsApp1
{
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }
        public int IdClienteAlteracao { get; set; }

        public void PreencherAlteracao(Cliente cliente)
        {
            try
            {
                txtCPF.Enabled = false;

                //Guarda o id do Cliente que está sendo alterada
                IdClienteAlteracao = cliente.ID_Cliente;

                //Preenche os dados na tela
                txtCPF.Text = cliente.CPF;
                txtNome.Text = cliente.Nome_Cliente;
                dtNascimento.Text = cliente.Data_Nasc.ToString();
                txtTelefone.Text = cliente.Telefone;
                txtCEP.Text = cliente.CEP;
                txtLougradouro.Text = cliente.Lougradouro;
                txtNum.Text = cliente.Numero;
                txtComplemento.Text = cliente.Complemento;
                txtBairro.Text = cliente.Bairro;
                txtCidade.Text = cliente.Cidade;
                txtEstado.Text = cliente.Estado;
                txtId.Text = cliente.ID_Cliente.ToString();
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
                else if (Validacao.Cpf(txtCPF.Text) == false)
                {

                    MessageBox.Show("Por favor insira um CPF válido", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCPF.Focus();
                    return;
                }


                if (IdClienteAlteracao == 0)
                {
                    verificarCPF();

                    Cliente ab = new Cliente();
                    ab.Nome_Cliente = txtNome.Text;
                    ab.CPF = txtCPF.Text;
                    ab.Data_Nasc = Convert.ToDateTime(dtNascimento.Text);
                    ab.Telefone = txtTelefone.Text;
                    ab.CEP = txtCEP.Text;
                    ab.Lougradouro = txtLougradouro.Text;
                    ab.Numero = txtNum.Text;
                    ab.Complemento = txtComplemento.Text;
                    ab.Bairro = txtBairro.Text;
                    ab.Cidade = txtCidade.Text;
                    ab.Estado = txtEstado.Text;
                    if (rbSexoM.Checked)
                    {
                        ab.SEXO = "MASCULINO";
                    }
                    else if (rbSexoF.Checked)
                    {
                        ab.SEXO = "FEMININO";

                    }
                    ////Objeto para acessar o banco de dados
                    CURSOEntitiesCasa banco = new CURSOEntitiesCasa();

                    ////adiciona o cliente 
                    banco.Clientes.Add(ab);

                    ////Efetiva as alterações do banco de dados
                    banco.SaveChanges();

                    //Aparece a mensagem e fecha a janela
                    MessageBox.Show("Cliente cadastrado com sucesso", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {

                    Cliente cliente;
                    CURSOEntitiesCasa banco = new CURSOEntitiesCasa();
                    cliente = banco.Clientes.Find(IdClienteAlteracao);

                    cliente.Nome_Cliente = txtNome.Text;
                    cliente.CPF = txtCPF.Text;
                    cliente.Data_Nasc = Convert.ToDateTime(dtNascimento.Text);
                    cliente.Telefone = txtTelefone.Text;
                    cliente.CEP = txtCEP.Text;
                    cliente.Lougradouro = txtLougradouro.Text;
                    cliente.Numero = txtNum.Text;
                    cliente.Complemento = txtComplemento.Text;
                    cliente.Bairro = txtBairro.Text;
                    cliente.Cidade = txtCidade.Text;
                    cliente.Estado = txtEstado.Text;
                    if (rbSexoM.Checked)
                    {
                        cliente.SEXO = "MASCULINO";
                    }
                    else if (rbSexoF.Checked)
                    {
                        cliente.SEXO = "FEMININO";

                    }
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

        private void frmClientes_Load(object sender, EventArgs e)
        {
            txtNome.Focus();
            Sexo();

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
        public bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Campo Nome é obrigatorio", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return false;
            }
            else
            if (string.IsNullOrWhiteSpace(txtCPF.Text))
            {
                MessageBox.Show("Campo CPF é obrigatorio", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCPF.Focus();
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
                LimpaTela();
            }
        }
        public void LimpaTela()
        {
            txtId.Clear();
            txtNome.Clear();
            txtCPF.Clear();
            txtTelefone.Clear();
            txtCidade.Clear();
            txtEstado.Clear();
            txtBairro.Clear();
            txtComplemento.Clear();
            txtLougradouro.Clear();
            txtNum.Clear();
            txtCEP.Clear();
            lbCPFINVALIDO.Visible = false;


        }

        public void Sexo()
        {

            CURSOEntitiesCasa banco = new CURSOEntitiesCasa();

            //Busca o usuario que tenha o login igual ao usuario digitado
            Cliente cliente = banco.Clientes.Find(IdClienteAlteracao);

            if (cliente != null)
            {
                if (cliente.SEXO == "MASCULINO")
                {
                    rbSexoM.Checked = true;
                }
                else if (cliente.SEXO == "FEMININO")
                {
                    rbSexoF.Checked = true;
                }

            }
        }

        private void txtCPF_Validated(object sender, EventArgs e)
        {
            if (Validacao.Cpf(txtCPF.Text) == false)
            {
                lbCPFINVALIDO.Visible = true;
            }
            else
            {
                lbCPFINVALIDO.Visible = false;
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
        public void verificarCPF()
        {
            CURSOEntitiesCasa banco = new CURSOEntitiesCasa();

            //Busca o usuario que tenha o login igual ao usuario digitado
            Cliente cliente = banco.Clientes.FirstOrDefault(x => x.CPF == txtCPF.Text);

            if (cliente != null)
            {
                MessageBox.Show("CPF Já Cadastrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCPF.Focus();
                return;
            }
        }

        private void txtTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
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
            catch (Exception)
            {

            }

        }



        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                solonumero(e);


                if (char.IsNumber(e.KeyChar) == true)
                {
                    switch (txtCPF.TextLength)
                    {

                        case 0:
                            txtCPF.Text = "";
                            break;

                        case 3:
                            txtCPF.Text = txtCPF.Text + ".";
                            txtCPF.SelectionStart = 5;
                            break;

                        case 7:
                            txtCPF.Text = txtCPF.Text + ".";
                            txtCPF.SelectionStart = 9;
                            break;

                        case 11:
                            txtCPF.Text = txtCPF.Text + "-";
                            txtCPF.SelectionStart = 12;
                            break;

                    }


                }

            }
            catch (Exception)
            {

            }
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            sololetras(e);
        }

        private void txtEstado_KeyPress(object sender, KeyPressEventArgs e)
        {
            sololetras(e);
        }
    }
}