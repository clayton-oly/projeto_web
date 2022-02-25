using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using WindowsFormsApp1.Modelos;


namespace WindowsFormsApp1
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void frmLogin_Load(object sender, EventArgs e)
        {
            CURSOEntitiesCasa banco = new CURSOEntitiesCasa();

            //Cria banco caso não exista
            banco.Database.CreateIfNotExists();

            //Cria usuário caso não exista
            if (banco.Usuarios.Count() == 0)
            {
                Usuario usu = new Usuario();

                usu.Nome = "Administrador";
                usu.CPF = "111.111.111-11";
                usu.Login = "admin";
                usu.Senha = "123";

                banco.Usuarios.Add(usu);
                banco.SaveChanges();

            }

        }

        public bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show("Campo USUÁRIO é obrigatorio", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return false;
            }
            else
            if (string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                MessageBox.Show("Campo Senha é obrigatorio", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSenha.Focus();
                return false;
            }


            return true;
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "USUARIO")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LightGray;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }

        private void txtSenha_Enter(object sender, EventArgs e)
        {
            if (txtSenha.Text == "SENHA")
            {
                txtSenha.Text = "";
                txtSenha.ForeColor = Color.LightGray;
                txtSenha.UseSystemPasswordChar = true;
            }
        }

        private void txtSenha_Leave(object sender, EventArgs e)
        {
            if (txtSenha.Text == "")
            {
                txtSenha.Text = "SENHA";
                txtSenha.ForeColor = Color.DimGray;
                txtSenha.UseSystemPasswordChar = false;
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void frmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pnLogo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnEntrar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (Validar() == false)
                {
                    return;
                }

                Hide();
                frmInicio menu = new frmInicio();

                //Faz conexao com o banco
                CURSOEntitiesCasa banco = new CURSOEntitiesCasa();

                //Busca o usuario que tenha o login igual ao usuario digitado
                Usuario user = banco.Usuarios.FirstOrDefault(x => x.Login == txtUsuario.Text && x.Senha == txtSenha.Text);

                if (user != null)
                {
                    menu.IdUsuario = user.ID_Usuario;
                    frmTelaVenda.IdUsuarioV = user.ID_Usuario;
                    menu.ShowDialog();
                }

                else
                {
                    MessageBox.Show("Usuário e/ou senha está inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                Show();
            }

            catch (SqlException ex)
            {

                MessageBox.Show("Não foi possivel consultar o banco de dados", "Erro" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                // MessageBox.Show(ex.Message);

            }

            catch (Exception ex)
            {

                MessageBox.Show("Ocorreu um erro" + ex.Message);
               // MessageBox.Show(ex.Message);

            }
        }
    }

}


