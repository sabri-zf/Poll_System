using ClsBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmPollMangement : Form
    {
        DataTable dt = ClsPolls.GetAllPolls();
        public FrmPollMangement()
        {
            InitializeComponent();
        }

        private void _loadPolls()
        {
            try
            {
            gridControl1.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmPollMangement_Load(object sender, EventArgs e)
        {
            _loadPolls();
        }
    }
}
