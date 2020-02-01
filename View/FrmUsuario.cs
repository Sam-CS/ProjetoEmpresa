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

namespace Empresa.View
{
    public partial class FrmUsuario : Form
    {
        Usuario usuario;
        Conexao con;
        public FrmUsuario()
        {
            InitializeComponent();
            usuario = new Usuario();
            con = new Conexao();
        }

        public void lerDados()
        {
            usuario.id = int.Parse(txtId.ToString().Trim());
            usuario.nome = txtNome.Text;
            usuario.email = txtEmail.Text;
            usuario.senha = txtSenha.Text;
            usuario.usuario = txtUsuario.Text;
          
            usuario.idPerfil = int.Parse(cmbPerfil.SelectedValue.ToString());
            if (rbAtivo.Checked)
            {
                usuario.status = 1;
            }
            else
            {
                usuario.status = 0;
            }
        }

        public void bloquearBotoes()
        {
            btnNovo.Enabled = false;
            btnSair.Enabled = false;
        }

        public void desbloquearBotoes()
        {
            btnNovo.Enabled = true;
            btnSair.Enabled = true;
        }

       public void bloquearCampos()
       {
            txtId.ReadOnly = true;
            txtNome.ReadOnly = true;
            txtSenha.ReadOnly = true;
            txtSenha.ReadOnly = true;
            txtUsuario.ReadOnly = true;
            cmbPerfil.Enabled = false;
            rbAtivo.Enabled = false;
            rbDesativo.Enabled = false;
       }
        public void desbloquearCampos()
        {
            txtId.ReadOnly = false;
            txtNome.ReadOnly = false;
            txtSenha.ReadOnly = false;
            txtSenha.ReadOnly = false;
            txtUsuario.ReadOnly = false;
            cmbPerfil.Enabled = true;
            rbAtivo.Enabled = true;
            rbDesativo.Enabled = true;
        }

        public void atualizaGrid()
        {
            List<Usuario> listUsuario = new List<Usuario>();
            con.OpenConnection();
            MySqlDataReader reader;
            reader = con.executeQuery("select * from tb_usuario");

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Usuario objUsuario = new Usuario();
                    objUsuario.id = reader.GetInt32(0);
                    objUsuario.nome = reader.GetString(1);
                    objUsuario.email = reader.GetString(2);
                    objUsuario.senha = reader.GetString(3);
                    objUsuario.usuario = reader.GetString(4);
                    objUsuario.status = reader.GetValue(5).ToString() == "True" ? 1 : 0;
                    objUsuario.idPerfil = reader.GetInt32(6);

                    listUsuario.Add(objUsuario);

                }
                reader.Close();
            }
            
            else
            {
                Console.WriteLine("Não retornou dados!");
            }
            dgvUsuario.DataSource = null;
            dgvUsuario.DataSource = listUsuario;


        }

        public void popularCombo()
        {
            List<Perfil> listPerfil = new List<Perfil>();
            con.OpenConnection();
            MySqlDataReader reader;
            reader = con.executeQuery("SELECT * FROM tb_perfil ");
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Perfil perfil = new Perfil();
                    perfil.id = reader.GetInt32(0);
                    perfil.nome = reader.GetString(1);
                    perfil.cadUsuario = reader.GetInt32(2);
                    perfil.cadPerfil = reader.GetInt32(3);
                    perfil.cadSetor = reader.GetInt32(4);
                    perfil.cadFuncionario = reader.GetInt32(5);
                    perfil.relFuncionario = reader.GetInt32(6);
                    perfil.status = reader.GetInt32(7);

                    listPerfil.Add(perfil);
                }
                reader.Close();
            }
            else
            {
                Console.WriteLine("Não retornou dados!");
            }
            cmbPerfil.DataSource = null;
            cmbPerfil.DataSource = listPerfil;
            cmbPerfil.DisplayMember = "nome";
            cmbPerfil.ValueMember = "id";

        }





    }
}
