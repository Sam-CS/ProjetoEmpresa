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
    public partial class FrmSetor : Form
    {
        Setor setor;
        Conexao con;
        public FrmSetor()
        {
            InitializeComponent();
            setor = new Setor();
            con = new Conexao();
        }

        public void lerDados()
        {
            Setor objSetor = new Setor();
            objSetor.id = int.Parse(txtId.Text.ToString());
            objSetor.nome = txtNome.Text;
            if (rbAtivado.Checked)
            {
                objSetor.status = 1;
            }
            else
            {
                objSetor.status = 0;
            }

        }

        public void atualizarGrid()
        {
            List<Setor> listSetor = new List<Setor>();
            con.OpenConnection();
            MySqlDataReader reader;
            reader = con.executeQuery("SELECT * FROM tb_setor");

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Setor objSetor = new Setor();
                    objSetor.id = reader.GetInt32(0);
                    objSetor.nome = reader.GetString(1);
                    objSetor.status = reader.GetValue(3).ToString() == "True" ? 1 : 0;

                    listSetor.Add(objSetor);
                
                }
                reader.Close();
            }
            else
            {
                Console.WriteLine("Não retornou dados!");
            }

            

        }

        
       
    }
}
