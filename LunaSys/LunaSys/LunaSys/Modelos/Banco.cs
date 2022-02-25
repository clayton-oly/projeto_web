using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Configuration;
using System.Collections.Specialized;

namespace WindowsFormsApp1
{
    public static class Banco
    {
        public static SqlConnection abrir()
        {
            try
            {
                //  string conexao = GetAppSettings().Get("MinhaConexao");

                //   SqlConnection cn = new SqlConnection(conexao);
                //SqlConnection cn = new SqlConnection("Server=localhost;;Initial Catalog=CURSO;Persist Security Info=True; User ID=sa; Password = senac@smp;");
                SqlConnection cn = new SqlConnection("Server=localhost;;Initial Catalog=CURSO;Persist Security Info=True; User ID=sa; Password = D@silva1996@;");
                cn.Open();
                  return cn;
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao conectar no banco de dados", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

        }

        //private static System.Collections.Specialized.NameValueCollection GetAppSettings()
        //{
        //    return System.Configuration.ConfigurationManager.AppSettings;
           
           

           
        //}
    }
}
