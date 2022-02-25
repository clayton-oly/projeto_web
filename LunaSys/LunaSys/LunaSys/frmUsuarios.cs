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
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            txtNome.Focus();
        }
        public int IdUsuarioAlteracao { get; set; }

        public void PreencherAlteracao(Usuario usuario)
        {
            try
            {
                txtCPF.Enabled = false;

                //Guarda o id do Cliente que está sendo alterada
                IdUsuarioAlteracao = usuario.ID_Usuario;

                //Preenche os dados na tela
                txtCPF.Text = usuario.CPF;
                txtNome.Text = usuario.Nome;
                txtSenha.Text = usuario.Senha;
                txtLogin.Text = usuario.Login;
                txtTelefone.Text = usuario.Telefone;
                txtFunção.Text = usuario.Funcao;
                try
                {
                    System.IO.MemoryStream stream =
                        new System.IO.MemoryStream(usuario.photo);
                    picFoto.Image = Bitmap.FromStream(stream);

                }
                catch (Exception)
                {


                }
                txtId.Text = usuario.ID_Usuario.ToString();
                btnSalvar.Text = "Alterar";
            }
            catch (Exception)
            {
                MessageBox.Show("Erro", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

            private byte[] ConverterFotoParaByteArray()
        {
            using (var stream = new System.IO.MemoryStream())
            {
                picFoto.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                stream.Seek(0, System.IO.SeekOrigin.Begin);
                byte[] bArray = new byte[stream.Length];
                stream.Read(bArray, 0, System.Convert.ToInt32(stream.Length));
                return bArray;
            }
        }


        private void btnFotoC_Click(object sender, EventArgs e)
        {
            
        }

        private void picFoto_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Arquivo de Imagen(*.PNG; *JPG; *.GIF)" +
        " | *.PNG; *.JPG; *.GIF";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                picFoto.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
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
            txtLogin.Clear();
            txtSenha.Clear();
            txtFunção.Clear();
            lbCPFINVALIDO.Visible = false;


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
            if (string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                MessageBox.Show("Campo Senha é obrigatorio", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSenha.Focus();
                return false;
            }
            else
            if (string.IsNullOrWhiteSpace(txtLogin.Text))
            {
                MessageBox.Show("Campo Login é obrigatorio", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLogin.Focus();
                return false;
            }
            else
            if (string.IsNullOrWhiteSpace(txtTelefone.Text))
            {
                MessageBox.Show("Campo telefone é obrigatorio", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefone.Focus();
                return false;
            }
            else if (txtConfirmeSenha.Text == string.Empty)
            {
                MessageBox.Show("Confirme a senha!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //txtNome.BackColor = Color.Red;
                txtConfirmeSenha.Focus();
                return false;
            }

            else if (txtSenha.Text != txtConfirmeSenha.Text)
            {
                MessageBox.Show("As senhas não conferem!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmeSenha.Focus();
                return false;
            }

            return true;
        }
        public void verificarCPF()
        {
            CURSOEntitiesCasa banco = new CURSOEntitiesCasa();

            //Busca o usuario que tenha o login igual ao usuario digitado
            Usuario usuario = banco.Usuarios.FirstOrDefault(x => x.CPF == txtCPF.Text);

            if (usuario != null)
            {
                MessageBox.Show("CPF Já Cadastrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCPF.Focus();
                return;
            }
        }

        private void btnSalvar_Click_1(object sender, EventArgs e)
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


                if (IdUsuarioAlteracao == 0)
                {
                    verificarCPF();

                    Usuario usuarios = new Usuario();
                    usuarios.Nome = txtNome.Text;
                    usuarios.CPF = txtCPF.Text;
                    usuarios.Funcao = txtFunção.Text;
                    usuarios.Login = txtLogin.Text;
                    usuarios.Nivel = ckbAdmin.Checked;
                    usuarios.Senha = txtSenha.Text;
                    usuarios.Telefone = txtTelefone.Text;
                    usuarios.photo = ConverterFotoParaByteArray();
                    ////Objeto para acessar o banco de dados
                    CURSOEntitiesCasa banco = new CURSOEntitiesCasa();

                    ////adiciona o cliente 
                    banco.Usuarios.Add(usuarios);

                    ////Efetiva as alterações do banco de dados
                    banco.SaveChanges();

                    //Aparece a mensagem e fecha a janela
                    MessageBox.Show("Usuario cadastrado com sucesso", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {

                    Usuario usuario;
                    CURSOEntitiesCasa banco = new CURSOEntitiesCasa();
                    usuario = banco.Usuarios.Find(IdUsuarioAlteracao);

                    usuario.Nome = txtNome.Text;
                    usuario.CPF = txtCPF.Text;
                    usuario.Funcao = txtFunção.Text;
                    usuario.Login = txtLogin.Text;
                    usuario.Nivel = ckbAdmin.Checked;
                    usuario.Senha = txtSenha.Text;
                    usuario.Telefone = txtTelefone.Text;
                    usuario.photo = ConverterFotoParaByteArray();

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
