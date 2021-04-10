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
    public partial class SCORE : Form
    {
        public SCORE()
        {
            InitializeComponent();
            label5.Text = DATAS.cadidates_name;
            FATHR_NAME.Text = DATAS.father_name;
            label4.Text = DATAS.perparation;
            if (DATAS.Ned_status == 1)
            {
                total.Text = (DATAS.Ned_default_chemistry_mcqs + DATAS.Ned_default_english_mcqs + DATAS.Ned_default_math_mcqs + DATAS.Ned_default_physics_mcqs).ToString();
                total_obt.Text = DATAS.score.ToString();
                physic_total.Text = DATAS.Ned_default_physics_mcqs.ToString();
                chemistry_total.Text = DATAS.Ned_default_chemistry_mcqs.ToString();

                math_total.Text = DATAS.Ned_default_math_mcqs.ToString();
                english_total.Text = DATAS.Ned_default_english_mcqs.ToString();

                eng_obt.Text = DATAS.english_score.ToString();
                math_obt.Text = DATAS.math_score.ToString();
                chem_obt.Text = DATAS.chemistry_score.ToString();
                physic_obt.Text = DATAS.physic_score.ToString();

                physics_bar.MaximumValue = DATAS.Ned_default_physics_mcqs;
                chemistry_bar.MaximumValue = DATAS.Ned_default_chemistry_mcqs;

                math_bar.MaximumValue = DATAS.Ned_default_math_mcqs;
                english_bar.MaximumValue = DATAS.Ned_default_english_mcqs;

                physics_bar.Value = DATAS.physic_score;
                chemistry_bar.Value = DATAS.chemistry_score;// Ned_default_chemistry_mcqs;

                math_bar.Value = DATAS.math_score;// Ned_default_math_mcqs;
                english_bar.Value = DATAS.english_score;// Ned_default_english_mcqs;
                total_bar.Value = DATAS.score;
                if (DATAS.score >= 50)
                {
                    pictureBox2.Visible = false;
                    pictureBox1.Visible = true;
                }
                else
                {
                    pictureBox2.Visible = true;
                    pictureBox1.Visible = false;
                }

                DATAS.score = 0;
                DATAS.english_score = 0;
                DATAS.chemistry_score = 0;
                DATAS.physic_score = 0;
                DATAS.math_score = 0;
            }


            if (DATAS.Nust_status == 1)
            {
                total.Text = (DATAS.Nust_default_chemistry_mcqs + DATAS.Nust_default_english_mcqs + DATAS.Nust_default_math_mcqs + DATAS.Nust_default_physics_mcqs).ToString();
                total_obt.Text = DATAS.score.ToString();
                physic_total.Text = DATAS.Nust_default_physics_mcqs.ToString();
                chemistry_total.Text = DATAS.Nust_default_chemistry_mcqs.ToString();

                math_total.Text = DATAS.Nust_default_math_mcqs.ToString();
                english_total.Text = DATAS.Nust_default_english_mcqs.ToString();

                eng_obt.Text = DATAS.english_score.ToString();
                math_obt.Text = DATAS.math_score.ToString();
                chem_obt.Text = DATAS.chemistry_score.ToString();
                physic_obt.Text = DATAS.physic_score.ToString();

                physics_bar.MaximumValue = DATAS.Nust_default_physics_mcqs;
                chemistry_bar.MaximumValue = DATAS.Nust_default_chemistry_mcqs;

                math_bar.MaximumValue = DATAS.Nust_default_math_mcqs;
                english_bar.MaximumValue = DATAS.Nust_default_english_mcqs;

                physics_bar.Value = DATAS.physic_score;
                chemistry_bar.Value = DATAS.chemistry_score;// Ned_default_chemistry_mcqs;

                math_bar.Value = DATAS.math_score;// Ned_default_math_mcqs;
                english_bar.Value = DATAS.english_score;// Ned_default_english_mcqs;
                total_bar.MaximumValue = 200;
                total_bar.Value = DATAS.score;
                if (DATAS.score >= 150)
                {
                    pictureBox2.Visible = false;
                    pictureBox1.Visible = true;
                }
                else
                {
                    pictureBox2.Visible = true;
                    pictureBox1.Visible = false;
                }

                DATAS.score = 0;
                DATAS.english_score = 0;
                DATAS.chemistry_score = 0;
                DATAS.physic_score = 0;
                DATAS.math_score = 0;

            }
            if (DATAS.Design_Pattern_status == 1)
            {
                int t = Convert.ToInt32(DATAS.required_CHEMISTRY_MCQS) + Convert.ToInt32(DATAS.required_ENGLISH_MCQS) + Convert.ToInt32(DATAS.required_MATH_MCQS) + Convert.ToInt32(DATAS.required_PHYSICS_MCQS);
                total.Text = t.ToString();
                total_obt.Text = DATAS.score.ToString();
                physic_total.Text = DATAS.required_PHYSICS_MCQS.ToString();
                chemistry_total.Text = DATAS.required_CHEMISTRY_MCQS.ToString();
                math_total.Text = DATAS.required_MATH_MCQS.ToString();
                english_total.Text = DATAS.required_ENGLISH_MCQS.ToString();

                eng_obt.Text = DATAS.english_score.ToString();
                math_obt.Text = DATAS.math_score.ToString();
                chem_obt.Text = DATAS.chemistry_score.ToString();
                physic_obt.Text = DATAS.physic_score.ToString();

                physics_bar.MaximumValue = Convert.ToInt32(DATAS.required_PHYSICS_MCQS);
                chemistry_bar.MaximumValue = Convert.ToInt32(DATAS.required_CHEMISTRY_MCQS);
                math_bar.MaximumValue = Convert.ToInt32(DATAS.required_MATH_MCQS);
                english_bar.MaximumValue = Convert.ToInt32(DATAS.required_ENGLISH_MCQS);

                physics_bar.Value = DATAS.physic_score;
                chemistry_bar.Value = DATAS.chemistry_score;
                math_bar.Value = DATAS.math_score;
                english_bar.Value = DATAS.english_score;
                total_bar.Value = DATAS.score;
                if (DATAS.score >= t / 2)
                {
                    pictureBox2.Visible = false;
                    pictureBox1.Visible = true;
                }
                else
                {
                    pictureBox2.Visible = true;
                    pictureBox1.Visible = false;
                }
                DATAS.score = 0;
                DATAS.english_score = 0;
                DATAS.chemistry_score = 0;
                DATAS.physic_score = 0;
                DATAS.math_score = 0;

            }
        }
        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            DATAS.review = 1;
            if (DATAS.Ned_status == 1)
            {
                ECAT sr = new ECAT();
                sr.Show();
            }
            if (DATAS.Nust_status == 1)
            {
                ECAT_1_ sr = new ECAT_1_(); sr.Show();
            }
            if (DATAS.Design_Pattern_status == 1)
            {
                ECAT_2_ sr = new ECAT_2_(); sr.Show();
            }
            if (DATAS.Chapters_status == 1)
            {
                ECAT_3_ sr = new ECAT_3_(); sr.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DATAS.review = 0;
            TEST__PATTERN ts = new TEST__PATTERN();
            //ECAT sr = new ECAT();
            ts.Show();
            if (DATAS.Ned_status == 1)
            { DATAS.Ned_status = 0; }
            if (DATAS.Nust_status == 1)
            { DATAS.Nust_status = 0; }
            if (DATAS.Design_Pattern_status == 1)
            { DATAS.Design_Pattern_status = 0; }
            if (DATAS.Chapters_status == 1)
            { DATAS.Chapters_status = 0; }
            Close();

        }

        private void bunifuGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
