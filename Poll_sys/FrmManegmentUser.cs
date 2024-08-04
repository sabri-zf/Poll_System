using ClsBusinessLayer;
using DevExpress.XtraBars.Docking2010.Views;
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
    public partial class FrmManegmentUser : Form
    {

        DataTable dt = clsUsers.GetAllUsers();
        public FrmManegmentUser()
        {
            InitializeComponent();
        }




        private void _loadUsers()
        {
            gridControl1.DataSource = dt;

            if (gridControl1 != null)
            {
                gridView1.Columns[0].Caption = "User ID";
                gridView1.Columns[0].Width = 150;
                gridView1.Columns[0].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None;

                gridView1.Columns[1].Width = 250;
                gridView1.Columns[1].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None;

                gridView1.Columns[2].Width = 250;
                gridView1.Columns[2].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None;
            }

            

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            _loadUsers();
        }
    }
}
