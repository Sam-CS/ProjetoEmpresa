using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Empresa
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void btnSetores_Click(object sender, EventArgs e)
        {
            View.FrmSetor frmSetor = new View.FrmSetor();
            frmSetor.Show();
        }
    }
}
