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
    public partial class DESIGN_PATTERN : Form
    {
        int mov;
        int movX;
        int movY;

        int x = 0; int x1 = 0; int x2 = 0; int x3 = 0;
        public DESIGN_PATTERN()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            if (DATAS.required_ENGLISH_MCQS == "0")
            {
                MessageBox.Show("You should select atleast one mcqs of each subject!");
            }

            else if (DATAS.required_CHEMISTRY_MCQS == "0")
            {
                MessageBox.Show("You should select atleast one mcqs of each subject!");
            }
            else if (DATAS.required_PHYSICS_MCQS == "0")
            {
                MessageBox.Show("You should select atleast one mcqs of each subject!");
            }
            else if (DATAS.required_MATH_MCQS == "0")
            {
                MessageBox.Show("You should select atleast one mcqs of each subject!");
            }
            
            else if (PHYSICS_TIME.Value.ToString() == "0")
            {
                MessageBox.Show("Invalid Time");
            }

            else if (CHEMISTRY_TIME.Value.ToString() == "0")
            {
                MessageBox.Show("Invalid Time");
            }
            else if (MATH_TIME.Value.ToString() == "0")
            {
                MessageBox.Show("Invalid Time");
            }
            else if (ENGLISH_TIME.Value.ToString() == "0")
            {
                MessageBox.Show("Invalid Time");
            }
            else
            {

                DATAS.Design_Pattern_status = 1;
                Visible = false;
                ECAT_2_ E = new ECAT_2_();
                E.Show();
            }

        }


        private void DESIGN_PATTERN_Load(object sender, EventArgs e)
        {
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void MATH_MIN_Click(object sender, EventArgs e)
        {}
        private void ENG_MIN_Click(object sender, EventArgs e)
        {
            DATAS.required_CHEMISTRY_TIME = CHEMISTRY_TIME.Value.ToString();
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            DATAS.required_CHEMISTRY_TIME = CHEMISTRY_TIME.Value.ToString();
        }

        private void MATH_TIMER_VALUE_ValueChanged(object sender, EventArgs e)
        {
            DATAS.required_ENGLISH_TIME = ENGLISH_TIME.Value.ToString();

        }

        private void ENG_TIMER_ValueChanged(object sender, EventArgs e)
        {
            DATAS.required_MATH_TIME = MATH_TIME.Value.ToString();

        }

        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {
            DATAS.required_PHYSICS_TIME = PHYSICS_TIME.Value.ToString();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void ENG_250_Click(object sender, EventArgs e)
        {
            ENG_250.Visible = false;
        }

        private void ENG_MCQS_ValueChanged(object sender, EventArgs e)
        {
            DATAS.required_ENGLISH_MCQS = ENG_MCQS.Value.ToString();
        }

        private void MATH_250_Click(object sender, EventArgs e)
        {
            MATH_250.Visible = false;
        }

        private void MATH_MCQS_ValueChanged(object sender, EventArgs e)
        {
            DATAS.required_MATH_MCQS = MATH_MCQS.Value.ToString();

        }

        private void label17_Click(object sender, EventArgs e)
        {
            label17.Visible = false;
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            DATAS.required_CHEMISTRY_MCQS = numericUpDown4.Value.ToString();

        }

        private void label19_Click(object sender, EventArgs e)
        {
            label19.Visible = false;
        }

        private void numericUpDown11_ValueChanged(object sender, EventArgs e)
        {
            // DATAS.required_PHYSICS_MCQS = numericUpDown11.Value.ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown10_ValueChanged(object sender, EventArgs e)
        {
            DATAS.whole_MCQS_TIME = numericUpDown10.Value.ToString();
        }

        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
        {
            DATAS.each_MCQS_TIME = numericUpDown9.Value.ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                DATAS.each_MCQS_TIME_status = 1;
                checkBox2.Checked = false;
            }
            else { DATAS.each_MCQS_TIME_status = 0; }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox2.Checked == true)
            {
                DATAS.whole_MCQS_TIME_status = 1;
                checkBox1.Checked = false;
            }
            else
            { DATAS.whole_MCQS_TIME_status = 0; }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (x == 0)
            {
                x++;
                label10.Visible = true;
               // label19.Visible = true;
                numericUpDown11.Visible = true;
                PHYSICS_TIME.Visible = true;
                label15.Visible = true;
            }
            else
            {
                x--;
                label10.Visible = false;
                //label19.Visible = false;
                numericUpDown11.Visible = false;
                PHYSICS_TIME.Visible = false;
                label15.Visible = false;

            }
        }


        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            if (x1 == 0)
            {
                x1++;
                label7.Visible = true;
                numericUpDown4.Visible = true;
                //label17.Visible = true;
                CHEMISTRY_TIME.Visible = true;
                label16.Visible = true;

            }
            else
            {
                x1--;

                label7.Visible = false;
                numericUpDown4.Visible = false;
                label17.Visible = false;
                CHEMISTRY_TIME.Visible = false;
                label16.Visible = false;

            }

        }

        private void numericUpDown11_ValueChanged_1(object sender, EventArgs e)
        {
            DATAS.required_PHYSICS_MCQS = numericUpDown11.Value.ToString();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (x2 == 0)
            {
                x2++;
                ENGLISH_TIME.Visible = true;
                ENG_MCQS.Visible = true;
                //ENG_250.Visible = true;
                label8.Visible = true;
                MATH_MIN.Visible = true;
            }
            else
            {
                x2--;
                ENGLISH_TIME.Visible = false;
                ENG_MCQS.Visible = false;
                ENG_250.Visible = false;
                MATH_MIN.Visible = false;
                label8.Visible = false;
            }

        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            if (x3 == 0)
            {

                x3++;
                ENG_MIN.Visible = true;
                MATH_TIME.Visible = true;
                MATH_MCQS.Visible = true;
                //MATH_250.Visible = true;
                label9.Visible = true;
            }
            else
            {
                x3--;

                ENG_MIN.Visible = false;
                MATH_250.Visible = false;
                MATH_TIME.Visible = false;
                MATH_MCQS.Visible = false;
                label9.Visible = false;
            }


        }

        private void bunifuGradientPanel2_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void bunifuGradientPanel2_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void bunifuGradientPanel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label3_Click_1(object sender, EventArgs e)
        {

            this.Visible = false;
        }
    }
}
