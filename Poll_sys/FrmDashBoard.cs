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
    public partial class FrmDashBoard : Form
    {
        public FrmDashBoard()
        {
            InitializeComponent();
        }

        private void _laodUserMangement()
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            FrmManegmentUser mamgementUser = new FrmManegmentUser();
            mamgementUser.ShowDialog();
        }

        private void btnMangePoll_Click(object sender, EventArgs e)
        {
            FrmPollMangement pollMangement = new FrmPollMangement();
            pollMangement.ShowDialog();
        }
    }
}
