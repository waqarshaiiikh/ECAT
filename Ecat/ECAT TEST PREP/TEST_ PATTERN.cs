using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECAT_TEST_PREP
{
    public partial class TEST__PATTERN : Form
    {
        int mov;
        int movX;
        int movY;
        public TEST__PATTERN()
        {
            InitializeComponent();
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            Visible = false;
            PERSONAL_INFO i = new PERSONAL_INFO();
            i.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DATAS.Ned_status = 1;
            this.WindowState = FormWindowState.Minimized;
            ECAT E = new ECAT();
            E.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            DESIGN_PATTERN dg = new DESIGN_PATTERN();
            dg.Show();
        }

        private void nust_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DATAS.Nust_status = 1;
            this.WindowState = FormWindowState.Minimized;
            ECAT_1_ E = new ECAT_1_();
            E.Show();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            CHAPTERS ch = new CHAPTERS();
            ch.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) { DATAS.Ned_time_status = 1; }
            else { DATAS.Ned_time_status = 1; }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox5.Checked == true) { DATAS.Nust_time_status = 1; }
            else { DATAS.Nust_time_status = 0; }

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked == true) { DATAS.design_pattern_time_status = 1; }
            else { DATAS.design_pattern_time_status = 0; }

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) { DATAS.chapter_time_status = 1; }
            else { DATAS.chapter_time_status = 0; }
        }

       
        private void TEST__PATTERN_Load(object sender, EventArgs e)
        {
            //this.Location = Screen.AllScreens[1].WorkingArea.Location;
        }

      
        private void label16_Click_1(object sender, EventArgs e)
        {
           Application.Exit();
        }

        private void label15_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuGradientPanel2_MouseDown_1(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void bunifuGradientPanel2_MouseUp_1(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void bunifuGradientPanel2_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }
    }

}
