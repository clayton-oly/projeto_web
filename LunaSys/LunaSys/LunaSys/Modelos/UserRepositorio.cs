using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace WindowsFormsApp1.Modelos
{
    class UserRepositorio
    {
        public bool VerificaLoginSenha(string login, string senha)
        {
            //Configura a string de conexão com o banco de dados
            SqlConnection cn = new SqlConnection("Server=localhost; DataBase=Curso; User ID=sa; Password = D@silva1996@");

            //Configura qual é o script que irá executar
            SqlCommand command = new SqlCommand("SELECT * FROM USUARIOS WHERE LOGIN = @login AND SENHA = @senha");

            //Coloca a conexão no comando
            command.Connection = cn;

            //define os parâmetros do script
            command.Parameters.AddWithValue("@login", login);
            command.Parameters.AddWithValue("@senha", senha);

            //Define o conjunto de comandos para buscar dados
            SqlDataAdapter da = new SqlDataAdapter(command);

            //Abre a conexão com o banco de dados
            cn.Open();

            //Preenche o dataset com valores
            //Retornados do banco de dados
            DataSet ds = new DataSet();

            try
            {
                da.Fill(ds);
            }
            finally
            {
                //feche conexão com banco de dados
                cn.Close();
            }


            //Verifica se no resultado que voltou, tem alguma linha,
            //Caso seja maior que 0, significa que existe usuario com login e senha informado
            bool existe = ds.Tables[0].Rows.Count > 0;

            return existe;
        }
    }
}
