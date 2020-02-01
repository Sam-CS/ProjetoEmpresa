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

        public void bloquearCampos()
        {
            txtId.ReadOnly = true;
            txtNome.ReadOnly = true;
            rbAtivado.Enabled = false;
            rbDesativado.Enabled = false;
        }

        public void desbloquearCampos()
        {
            txtId.ReadOnly = false;
            txtNome.ReadOnly = false;
            rbAtivado.Enabled = true;
            rbDesativado.Enabled = true;

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
                    objSetor.status = reader.GetValue(2).ToString() == "True" ? 1 : 0;

                    listSetor.Add(objSetor);
                
                }
                reader.Close();
            }
            else
            {
                Console.WriteLine("Não retornou dados!");
            }
            dgvSetor.DataSource = null;
            dgvSetor.DataSource = listSetor;
            
        }

        public void limparCampos()
        {
            txtId.Text = "";
            txtNome.Text = "";
            rbAtivado.Checked = false;
            rbDesativado.Checked = false;
        }


        private void btnSalvar_Click(object sender, EventArgs e)
        {
            lerDados();
            String sql = "INSERT INTO tb_setor VALUES ("+ setor.id+ ",'"+setor.nome +"',"+setor.status +")";
            if (con.execute(sql) == 1)
            {
                MessageBox.Show("Dados Salvos!","Salvar",MessageBoxButtons.OKCancel,MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Erro ao salvar!","Erro",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
            }
            bloquearCampos();
            atualizarGrid();

            
        }

        private void FrmSetor_Load(object sender, EventArgs e)
        {
            bloquearCampos();
            atualizarGrid();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            desbloquearCampos();
            limparCampos();
        }

        private void dgvSetor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgvSetor.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = dgvSetor.CurrentRow.Cells[1].Value.ToString();
            rbAtivado.Checked = dgvSetor.CurrentRow.Cells[2].Value.Equals(1) ? true : false;
            rbDesativado.Checked = dgvSetor.CurrentRow.Cells[2].Value.Equals(1) ? true : false;
        }
    }
}
