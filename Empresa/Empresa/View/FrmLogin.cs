using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Empresa
{
    public partial class FrmLogin : Form
    {
        Usuario usuario;
        Conexao con;
        public FrmLogin()
        {
            InitializeComponent();
            usuario = new Usuario();
            con = new Conexao();
        }
        public void lerDados()
        {
            usuario.usuario = txtUsuario.Text.Trim();
            usuario.senha = txtSenha.Text.Trim();
           //String senhaCrypt = CrypHash.ComputeSha256Hash(usuario.senha);
            
            
        }
        

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            con.OpenConnection();
            lerDados();
            
            String senhaCrypt = CrypHash.ComputeSha256Hash(usuario.senha);
            
           
            String sql = $"SELECT * FROM tb_usuario WHERE usuario = '{usuario.usuario}' AND senha = '{senhaCrypt}'";
            MySqlDataReader reader;
            reader = con.executeQuery(sql);

            if (reader.HasRows)
            {
                this.Visible = false;
                    FrmPrincipal principal = new FrmPrincipal();
                    principal.Show();
                
            }
            else
            {
                MessageBox.Show("Não logou");
            }
           

           
        }
    }
}
