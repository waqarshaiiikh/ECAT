using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ECAT_TEST_PREP
{
    public partial class ECAT : Form
    {
        string correct;
        int count1=0;
        int option=0;
        int count = 0;
        int setrandom;
        int counter = 0;
        int serial_text1 = 1;
        int seconds_t, minute_t,hours_t; 
        OleDbConnection con = new OleDbConnection(DATAS.database);
        public ECAT()
        {
           InitializeComponent();
            if (DATAS.Ned_status == 1)
            {
               if (DATAS.review == 0)
                { 
                Random ran = new Random();
                if (DATAS.review == 0) {
                    while (count < DATAS.Ned_default_english_mcqs) { DATAS.english_mcqs[count] = ran.Next(0, 178);  count++; } count = 0;

                    while (count < DATAS.Ned_default_physics_mcqs) { DATAS.physic_mcqs[count] = ran.Next(0, 312);  count++; } count = 0;

                    while (count < DATAS.Ned_default_math_mcqs) { DATAS.math_mcqs[count] = ran.Next(0, 198); count++; } count = 0;

                    while (count < DATAS.Ned_default_chemistry_mcqs) { DATAS.chemistry_mcqs[count] = ran.Next(0, 268); count++; } count = 0;
                }
               }
                OleDbDataAdapter adp = new OleDbDataAdapter("select * from ENGLISH", con);

                DataSet ds = new DataSet();
                adp.Fill(ds);
                setrandom = DATAS.english_mcqs[counter];
                serial.Text = serial_text1.ToString();
                question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();
                //Random num = new Random(1,270);
                //MessageBox.Show(setrandom.ToString());
                check_button.Visible = false;
                if (DATAS.review == 0)
                {
                    time.Start();
                    Next_button.Visible = false;
                    back_button.Visible = false;
                    sec_ned_nust.Visible = true;
                    //hours_ned_nust.Visible = true;
                    min_ned_nust.Visible = true;
                    label6.Visible = true;
                    //label8.Visible = true;
                   // second.Visible = false;
                   // label4.Visible = false;
                   // minutes.Visible = false;
                   // label2.Visible = false;
                   // hours.Visible = false;
                    minute_t = DATAS.Ned_default_time;
                    min_ned_nust.Text = minute_t.ToString();
                    hours_t = 1;
                    seconds_t = 59 ;
                    sec_ned_nust.Text = seconds_t.ToString();
                }
                else
                {
                    option = 1;
                    if (DATAS.save_option[option] == ds.Tables[0].Rows[setrandom]["CORRECT"].ToString())
                    {
                        if (DATAS.save_option[option] == "A") { Option_a.ForeColor = Color.Blue; }
                        if (DATAS.save_option[option] == "B") { Option_b.ForeColor = Color.Blue; }
                        if (DATAS.save_option[option] == "C") { Option_c.ForeColor = Color.Blue; }
                        if (DATAS.save_option[option] == "D") { Option_d.ForeColor = Color.Blue; }

                    }
                    else
                    {
                        if (DATAS.save_option[option] == "A") { Option_a.ForeColor = Color.Red; }
                        if (DATAS.save_option[option] == "B") { Option_b.ForeColor = Color.Red; }
                        if (DATAS.save_option[option] == "C") { Option_c.ForeColor = Color.Red; }
                        if (DATAS.save_option[option] == "D") { Option_d.ForeColor = Color.Red; }
                        correct=ds.Tables[0].Rows[setrandom]["CORRECT"].ToString();

                        if (correct == "A") { Option_a.ForeColor = Color.Blue; }
                        if (correct == "B") { Option_b.ForeColor = Color.Blue; }
                        if (correct == "C") { Option_c.ForeColor = Color.Blue; }
                        if (correct == "D") { Option_d.ForeColor = Color.Blue; }

                    }

                    label1.Visible = false;
                label6.Visible = false;
                label3.Visible = false;
              
                //label8.Visible = false;
                //label7.Visible = false;
              
              //  button2.Visible = false;
               // goto_question.Visible = false;
                //label17.Visible = false;
                    A.Visible = false;
                    B.Visible = false;
                    C.Visible = false;
                    D.Visible = false;
                }
             
            }
            if (DATAS.Nust_status == 1) { MessageBox.Show("get ready for nust"); }

        }

        private void question_Click(object sender, EventArgs e)
        {

        }

        private void min_Tick(object sender, EventArgs e)
        {

        }

        private void hour_Tick(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (seconds_t == -1)
            {
                if ((seconds_t == -1) && (minute_t == 0))
                { Close(); SCORE SR = new SCORE(); SR.Show(); }
                seconds_t = 59;
                min_ned_nust.Text = minute_t.ToString(); minute_t--;

            }
            if (0 <= seconds_t)
            {
                sec_ned_nust.Text = seconds_t.ToString();
                seconds_t--;
            }
        }

        private void B_CheckedChanged(object sender, EventArgs e)
        {
         
        }

        private void C_CheckedChanged(object sender, EventArgs e)
        {

         }

        private void D_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void Next_button_Click(object sender, EventArgs e)
        {
            Option_a.ForeColor = Color.Black;
            Option_b.ForeColor = Color.Black;
            Option_c.ForeColor = Color.Black;
            Option_d.ForeColor = Color.Black;
            if (Convert.ToInt32(serial.Text) == 1) { back_button.Visible = true; }
            if (Convert.ToInt32(serial.Text) == 75) { counter = -1; }
            if ((Convert.ToInt32(serial.Text) >= 75) && (Convert.ToInt32(serial.Text) < 100))
            {
                //MessageBox.Show("kia");

                // CHAPTER_NAME.Text = "ENGLISH";
                CHAPTER_NAME.Text = "MATH";

                OleDbDataAdapter adp = new OleDbDataAdapter("select * from MATH", con);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                counter++;
                serial_text1 += 1;
                serial.Text = serial_text1.ToString();
                option = Convert.ToInt32(serial.Text);

                setrandom = DATAS.math_mcqs[counter];
                question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();
                // MessageBox.Show(setrandom.ToString());
                if (DATAS.save_option[option] == ds.Tables[0].Rows[setrandom]["CORRECT"].ToString())
                {
                    if (DATAS.save_option[option] == "A") { Option_a.ForeColor = Color.Blue; }
                    if (DATAS.save_option[option] == "B") { Option_b.ForeColor = Color.Blue; }
                    if (DATAS.save_option[option] == "C") { Option_c.ForeColor = Color.Blue; }
                    if (DATAS.save_option[option] == "D") { Option_d.ForeColor = Color.Blue; }

                }
                else
                {
                    if (DATAS.save_option[option] == "A") { Option_a.ForeColor = Color.Red; }
                    if (DATAS.save_option[option] == "B") { Option_b.ForeColor = Color.Red; }
                    if (DATAS.save_option[option] == "C") { Option_c.ForeColor = Color.Red; }
                    if (DATAS.save_option[option] == "D") { Option_d.ForeColor = Color.Red; }
                    correct = ds.Tables[0].Rows[setrandom]["CORRECT"].ToString();

                    if (correct == "A") { Option_a.ForeColor = Color.Blue; }
                    if (correct == "B") { Option_b.ForeColor = Color.Blue; }
                    if (correct == "C") { Option_c.ForeColor = Color.Blue; }
                    if (correct == "D") { Option_d.ForeColor = Color.Blue; }
                }

            }
            if (Convert.ToInt32(serial.Text) == 100) { Next_button.Visible = false; }
            else { Next_button.Visible = true; }
            if (Convert.ToInt32(serial.Text) == 50) { counter = -1; }
            if ((Convert.ToInt32(serial.Text) >= 50) && (Convert.ToInt32(serial.Text) < 75))
            {
                //MessageBox.Show("kia");

                // CHAPTER_NAME.Text = "ENGLISH";
                CHAPTER_NAME.Text = "PHYSICS";

                OleDbDataAdapter adp = new OleDbDataAdapter("select * from PHYSICS", con);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                counter++;
                serial_text1 += 1;
                serial.Text = serial_text1.ToString();
                option = Convert.ToInt32(serial.Text);

                setrandom = DATAS.physic_mcqs[counter];
                question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();
                // MessageBox.Show(setrandom.ToString());
                if (DATAS.save_option[option] == ds.Tables[0].Rows[setrandom]["CORRECT"].ToString())
                {
                    if (DATAS.save_option[option] == "A") { Option_a.ForeColor = Color.Blue; }
                    if (DATAS.save_option[option] == "B") { Option_b.ForeColor = Color.Blue; }
                    if (DATAS.save_option[option] == "C") { Option_c.ForeColor = Color.Blue; }
                    if (DATAS.save_option[option] == "D") { Option_d.ForeColor = Color.Blue; }

                }
                else
                {
                    if (DATAS.save_option[option] == "A") { Option_a.ForeColor = Color.Red; }
                    if (DATAS.save_option[option] == "B") { Option_b.ForeColor = Color.Red; }
                    if (DATAS.save_option[option] == "C") { Option_c.ForeColor = Color.Red; }
                    if (DATAS.save_option[option] == "D") { Option_d.ForeColor = Color.Red; }
                    correct = ds.Tables[0].Rows[setrandom]["CORRECT"].ToString();

                    if (correct == "A") { Option_a.ForeColor = Color.Blue; }
                    if (correct == "B") { Option_b.ForeColor = Color.Blue; }
                    if (correct == "C") { Option_c.ForeColor = Color.Blue; }
                    if (correct == "D") { Option_d.ForeColor = Color.Blue; }
                }

            }

            if (Convert.ToInt32(serial.Text) == 25) { counter = -1; }
            if ((Convert.ToInt32(serial.Text) >= 25) && (Convert.ToInt32(serial.Text) < 50))
            {
                //MessageBox.Show("kia");

                // CHAPTER_NAME.Text = "ENGLISH";
                CHAPTER_NAME.Text = "CHEMISTRY";

                OleDbDataAdapter adp = new OleDbDataAdapter("select * from CHEMISTRY", con);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                counter++;
                serial_text1 += 1;
                serial.Text = serial_text1.ToString();
                option = Convert.ToInt32(serial.Text);

                setrandom = DATAS.chemistry_mcqs[counter];
                question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();
                // MessageBox.Show(setrandom.ToString());
                if (DATAS.save_option[option] == ds.Tables[0].Rows[setrandom]["CORRECT"].ToString())
                {
                    if (DATAS.save_option[option] == "A") { Option_a.ForeColor = Color.Blue; }
                    if (DATAS.save_option[option] == "B") { Option_b.ForeColor = Color.Blue; }
                    if (DATAS.save_option[option] == "C") { Option_c.ForeColor = Color.Blue; }
                    if (DATAS.save_option[option] == "D") { Option_d.ForeColor = Color.Blue; }

                }
                else
                {
                    if (DATAS.save_option[option] == "A") { Option_a.ForeColor = Color.Red; }
                    if (DATAS.save_option[option] == "B") { Option_b.ForeColor = Color.Red; }
                    if (DATAS.save_option[option] == "C") { Option_c.ForeColor = Color.Red; }
                    if (DATAS.save_option[option] == "D") { Option_d.ForeColor = Color.Red; }
                    correct = ds.Tables[0].Rows[setrandom]["CORRECT"].ToString();

                    if (correct == "A") { Option_a.ForeColor = Color.Blue; }
                    if (correct == "B") { Option_b.ForeColor = Color.Blue; }
                    if (correct == "C") { Option_c.ForeColor = Color.Blue; }
                    if (correct == "D") { Option_d.ForeColor = Color.Blue; }
                }

            }

            if (Convert.ToInt32(serial.Text) < 25)
            {

                CHAPTER_NAME.Text = "ENGLISH";
                OleDbDataAdapter adp = new OleDbDataAdapter("select * from ENGLISH", con);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                counter++;
                serial_text1 += 1;
                serial.Text = serial_text1.ToString();
                option = Convert.ToInt32(serial.Text);

                setrandom = DATAS.english_mcqs[counter];
                question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();
                // MessageBox.Show(setrandom.ToString());
                if (DATAS.save_option[option] == ds.Tables[0].Rows[setrandom]["CORRECT"].ToString())
                {
                    if (DATAS.save_option[option] == "A") { Option_a.ForeColor = Color.Blue; }
                    if (DATAS.save_option[option] == "B") { Option_b.ForeColor = Color.Blue; }
                    if (DATAS.save_option[option] == "C") { Option_c.ForeColor = Color.Blue; }
                    if (DATAS.save_option[option] == "D") { Option_d.ForeColor = Color.Blue; }

                }
                else
                {
                    if (DATAS.save_option[option] == "A") { Option_a.ForeColor = Color.Red; }
                    if (DATAS.save_option[option] == "B") { Option_b.ForeColor = Color.Red; }
                    if (DATAS.save_option[option] == "C") { Option_c.ForeColor = Color.Red; }
                    if (DATAS.save_option[option] == "D") { Option_d.ForeColor = Color.Red; }
                    correct = ds.Tables[0].Rows[setrandom]["CORRECT"].ToString();

                    if (correct == "A") { Option_a.ForeColor = Color.Blue; }
                    if (correct == "B") { Option_b.ForeColor = Color.Blue; }
                    if (correct == "C") { Option_c.ForeColor = Color.Blue; }
                    if (correct == "D") { Option_d.ForeColor = Color.Blue; }
                }


            }
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void back_button_Click(object sender, EventArgs e)
        {
            Option_a.ForeColor = Color.Black;
            Option_b.ForeColor = Color.Black;
            Option_c.ForeColor = Color.Black;
            Option_d.ForeColor = Color.Black;
            if (Convert.ToInt32(serial.Text) == 2) { back_button.Visible = false; }
            if ((Convert.ToInt32(serial.Text) > 76) && (Convert.ToInt32(serial.Text) <= 100))
            {
                //MessageBox.Show("kia");

                // CHAPTER_NAME.Text = "ENGLISH";
                CHAPTER_NAME.Text = "MATH";

                OleDbDataAdapter adp = new OleDbDataAdapter("select * from MATH", con);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                counter--;
                serial_text1 -= 1;
                serial.Text = serial_text1.ToString();
                option = Convert.ToInt32(serial.Text);

                setrandom = DATAS.math_mcqs[counter];
                question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();
                // MessageBox.Show(setrandom.ToString());
                if (DATAS.save_option[option] == ds.Tables[0].Rows[setrandom]["CORRECT"].ToString())
                {
                    if (DATAS.save_option[option] == "A") { Option_a.ForeColor = Color.Blue; }
                    if (DATAS.save_option[option] == "B") { Option_b.ForeColor = Color.Blue; }
                    if (DATAS.save_option[option] == "C") { Option_c.ForeColor = Color.Blue; }
                    if (DATAS.save_option[option] == "D") { Option_d.ForeColor = Color.Blue; }

                }
                else
                {
                    if (DATAS.save_option[option] == "A") { Option_a.ForeColor = Color.Red; }
                    if (DATAS.save_option[option] == "B") { Option_b.ForeColor = Color.Red; }
                    if (DATAS.save_option[option] == "C") { Option_c.ForeColor = Color.Red; }
                    if (DATAS.save_option[option] == "D") { Option_d.ForeColor = Color.Red; }
                    correct = ds.Tables[0].Rows[setrandom]["CORRECT"].ToString();

                    if (correct == "A") { Option_a.ForeColor = Color.Blue; }
                    if (correct == "B") { Option_b.ForeColor = Color.Blue; }
                    if (correct == "C") { Option_c.ForeColor = Color.Blue; }
                    if (correct == "D") { Option_d.ForeColor = Color.Blue; }
                }

            }
            if (Convert.ToInt32(serial.Text) == 100) { Next_button.Visible = false; }
            else { Next_button.Visible = true; }
            if (Convert.ToInt32(serial.Text) == 76) { counter = 25; }
            if ((Convert.ToInt32(serial.Text) > 51) && (Convert.ToInt32(serial.Text) <= 76))
            {
                //MessageBox.Show("kia");

                // CHAPTER_NAME.Text = "ENGLISH";
                CHAPTER_NAME.Text = "PHYSICS";

                OleDbDataAdapter adp = new OleDbDataAdapter("select * from PHYSICS", con);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                counter--;
                serial_text1 -= 1;
                serial.Text = serial_text1.ToString();
                option = Convert.ToInt32(serial.Text);

                setrandom = DATAS.physic_mcqs[counter];
                question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();
                // MessageBox.Show(setrandom.ToString());
                if (DATAS.save_option[option] == ds.Tables[0].Rows[setrandom]["CORRECT"].ToString())
                {
                    if (DATAS.save_option[option] == "A") { Option_a.ForeColor = Color.Blue; }
                    if (DATAS.save_option[option] == "B") { Option_b.ForeColor = Color.Blue; }
                    if (DATAS.save_option[option] == "C") { Option_c.ForeColor = Color.Blue; }
                    if (DATAS.save_option[option] == "D") { Option_d.ForeColor = Color.Blue; }

                }
                else
                {
                    if (DATAS.save_option[option] == "A") { Option_a.ForeColor = Color.Red; }
                    if (DATAS.save_option[option] == "B") { Option_b.ForeColor = Color.Red; }
                    if (DATAS.save_option[option] == "C") { Option_c.ForeColor = Color.Red; }
                    if (DATAS.save_option[option] == "D") { Option_d.ForeColor = Color.Red; }
                    correct = ds.Tables[0].Rows[setrandom]["CORRECT"].ToString();

                    if (correct == "A") { Option_a.ForeColor = Color.Blue; }
                    if (correct == "B") { Option_b.ForeColor = Color.Blue; }
                    if (correct == "C") { Option_c.ForeColor = Color.Blue; }
                    if (correct == "D") { Option_d.ForeColor = Color.Blue; }
                }

            }
            if (Convert.ToInt32(serial.Text) == 51) { counter = 25; }
            if ((Convert.ToInt32(serial.Text) > 26) && (Convert.ToInt32(serial.Text) <= 51))
            {
                //MessageBox.Show("kia");

                // CHAPTER_NAME.Text = "ENGLISH";
                CHAPTER_NAME.Text = "CHEMISTRY";

                OleDbDataAdapter adp = new OleDbDataAdapter("select * from CHEMISTRY", con);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                counter--;
                serial_text1 -= 1;
                serial.Text = serial_text1.ToString();
                option = Convert.ToInt32(serial.Text);

                setrandom = DATAS.chemistry_mcqs[counter];
                question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();
                // MessageBox.Show(setrandom.ToString());
                if (DATAS.save_option[option] == ds.Tables[0].Rows[setrandom]["CORRECT"].ToString())
                {
                    if (DATAS.save_option[option] == "A") { Option_a.ForeColor = Color.Blue; }
                    if (DATAS.save_option[option] == "B") { Option_b.ForeColor = Color.Blue; }
                    if (DATAS.save_option[option] == "C") { Option_c.ForeColor = Color.Blue; }
                    if (DATAS.save_option[option] == "D") { Option_d.ForeColor = Color.Blue; }

                }
                else
                {
                    if (DATAS.save_option[option] == "A") { Option_a.ForeColor = Color.Red; }
                    if (DATAS.save_option[option] == "B") { Option_b.ForeColor = Color.Red; }
                    if (DATAS.save_option[option] == "C") { Option_c.ForeColor = Color.Red; }
                    if (DATAS.save_option[option] == "D") { Option_d.ForeColor = Color.Red; }
                    correct = ds.Tables[0].Rows[setrandom]["CORRECT"].ToString();

                    if (correct == "A") { Option_a.ForeColor = Color.Blue; }
                    if (correct == "B") { Option_b.ForeColor = Color.Blue; }
                    if (correct == "C") { Option_c.ForeColor = Color.Blue; }
                    if (correct == "D") { Option_d.ForeColor = Color.Blue; }
                }

            }

            if (Convert.ToInt32(serial.Text) == 26)
            { counter = 25; }
            if (Convert.ToInt32(serial.Text) <= 26)
            {

                CHAPTER_NAME.Text = "ENGLISH";
                OleDbDataAdapter adp = new OleDbDataAdapter("select * from ENGLISH", con);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                counter--;
                serial_text1 -= 1;
                serial.Text = serial_text1.ToString();
                option = Convert.ToInt32(serial.Text);

                setrandom = DATAS.english_mcqs[counter];
                question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();
                // MessageBox.Show(setrandom.ToString());
                if (DATAS.save_option[option] == ds.Tables[0].Rows[setrandom]["CORRECT"].ToString())
                {
                    if (DATAS.save_option[option] == "A") { Option_a.ForeColor = Color.Blue; }
                    if (DATAS.save_option[option] == "B") { Option_b.ForeColor = Color.Blue; }
                    if (DATAS.save_option[option] == "C") { Option_c.ForeColor = Color.Blue; }
                    if (DATAS.save_option[option] == "D") { Option_d.ForeColor = Color.Blue; }

                }
                else
                {
                    if (DATAS.save_option[option] == "A") { Option_a.ForeColor = Color.Red; }
                    if (DATAS.save_option[option] == "B") { Option_b.ForeColor = Color.Red; }
                    if (DATAS.save_option[option] == "C") { Option_c.ForeColor = Color.Red; }
                    if (DATAS.save_option[option] == "D") { Option_d.ForeColor = Color.Red; }
                    correct = ds.Tables[0].Rows[setrandom]["CORRECT"].ToString();

                    if (correct == "A") { Option_a.ForeColor = Color.Blue; }
                    if (correct == "B") { Option_b.ForeColor = Color.Blue; }
                    if (correct == "C") { Option_c.ForeColor = Color.Blue; }
                    if (correct == "D") { Option_d.ForeColor = Color.Blue; }
                }


            }

        }

        private void B_Click(object sender, EventArgs e)
        {
            option = Convert.ToInt32(serial.Text);
            DATAS.save_option[option] = "B";
            //MessageBox.Show(option + "B");
            if (Convert.ToInt32(serial.Text) <= 25)
            {
                OleDbDataAdapter adp = new OleDbDataAdapter("select * from ENGLISH", con);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                if (ds.Tables[0].Rows[counter]["CORRECT"].ToString() == B.Name)
                { DATAS.score += 1; DATAS.english_score++; }

                counter++;
                serial_text1 += 1;
                serial.Text = serial_text1.ToString();

                if (Convert.ToInt32(serial.Text) != 26)
                {
                    setrandom = DATAS.english_mcqs[counter];
                    question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                    Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                    Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                    Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                    Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();
                    //  MessageBox.Show(setrandom.ToString());
                }
            }

            if ((Convert.ToInt32(serial.Text) > 25) && (Convert.ToInt32(serial.Text) <= 50))
            {
                if (count == 1)
                {
                    OleDbDataAdapter adp = new OleDbDataAdapter("select * from CHEMISTRY", con);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    if (ds.Tables[0].Rows[counter]["CORRECT"].ToString() == B.Name)
                    { DATAS.score += 1; DATAS.chemistry_score++; }
                    counter++;
                    serial_text1 += 1;
                    serial.Text = serial_text1.ToString();

                    if (Convert.ToInt32(serial.Text) != 51)
                    {
                        setrandom = DATAS.chemistry_mcqs[counter];
                        question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                        Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                        Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                        Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                        Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();


                    }
                    if (Convert.ToInt32(serial.Text) == 51) { count = 0; }
                }
            }

            if ((Convert.ToInt32(serial.Text) == 26) && (count == 0))
            {
                counter = 0; CHAPTER_NAME.Text = "CHEMISTRY";
                OleDbDataAdapter adp = new OleDbDataAdapter("select * from CHEMISTRY", con);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                setrandom = DATAS.chemistry_mcqs[counter];
                question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();
                count++;
                // MessageBox.Show(serial.Text);
            }

            if ((Convert.ToInt32(serial.Text) > 50) && (Convert.ToInt32(serial.Text) <= 75))
            {

                if (count == 1)
                {
                    OleDbDataAdapter adp = new OleDbDataAdapter("select * from PHYSICS", con);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    if (ds.Tables[0].Rows[counter]["CORRECT"].ToString() == B.Name)
                    { DATAS.score += 1; DATAS.physic_score++; }
                    counter++;
                    serial_text1 += 1;
                    serial.Text = serial_text1.ToString();

                    if (Convert.ToInt32(serial.Text) != 76)
                    {
                        setrandom = DATAS.physic_mcqs[counter];
                        question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                        Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                        Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                        Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                        Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();


                    }
                    if (Convert.ToInt32(serial.Text) == 76) { count = 0; }

                }
            }
            if ((Convert.ToInt32(serial.Text) == 51) && (count == 0))
            {
                counter = 0;
                CHAPTER_NAME.Text = "PHYSICS";
                OleDbDataAdapter adp = new OleDbDataAdapter("select * from PHYSICS", con);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                setrandom = DATAS.physic_mcqs[counter];
                question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();
                count++;
                //  MessageBox.Show(serial.Text);
            }



            if ((Convert.ToInt32(serial.Text) > 75) && (Convert.ToInt32(serial.Text) <= 100))
            {


                if (count == 1)
                {
                    OleDbDataAdapter adp = new OleDbDataAdapter("select * from MATH", con);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    if (ds.Tables[0].Rows[counter]["CORRECT"].ToString() == B.Name)
                    { DATAS.score += 1; DATAS.math_score++; }

                    counter++;
                    serial_text1 += 1;
                    serial.Text = serial_text1.ToString();
                    if (Convert.ToInt32(serial.Text) == 101)
                    { SCORE SR = new SCORE(); Hide(); SR.Show(); /*MessageBox.Show(DATAS.score.ToString());*/ }

                    if ((Convert.ToInt32(serial.Text) != 76) && (Convert.ToInt32(serial.Text) != 101))
                    {
                        setrandom = DATAS.math_mcqs[counter];
                        question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                        Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                        Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                        Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                        Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();

                    }



                }

                if ((Convert.ToInt32(serial.Text) == 76) && (count == 0))
                {
                    counter = 0; CHAPTER_NAME.Text = "MATHEMATICS";
                    OleDbDataAdapter adp = new OleDbDataAdapter("select * from MATH", con);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    setrandom = DATAS.math_mcqs[counter];
                    question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                    Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                    Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                    Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                    Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();
                    count++;
                    // MessageBox.Show(serial.Text);
                }
            }
            B.Checked = false;
        }

        private void D_Click(object sender, EventArgs e)
        {

            option = Convert.ToInt32(serial.Text);
            DATAS.save_option[option] = "D";
         //   MessageBox.Show(option + "D");

            if (Convert.ToInt32(serial.Text) <= 25)
            {
                OleDbDataAdapter adp = new OleDbDataAdapter("select * from ENGLISH", con);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                if (ds.Tables[0].Rows[counter]["CORRECT"].ToString() == D.Name)
                { DATAS.score += 1; DATAS.english_score += 1; }

                counter++;
                serial_text1 += 1;
                serial.Text = serial_text1.ToString();

                if (Convert.ToInt32(serial.Text) != 26)
                {
                    setrandom = DATAS.english_mcqs[counter];
                    question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                    Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                    Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                    Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                    Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();

                }
            }

            if ((Convert.ToInt32(serial.Text) > 25) && (Convert.ToInt32(serial.Text) <= 50))
            {
                if (count == 1)
                {
                    OleDbDataAdapter adp = new OleDbDataAdapter("select * from CHEMISTRY", con);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    counter++;
                    serial_text1 += 1;
                    serial.Text = serial_text1.ToString();

                    if (Convert.ToInt32(serial.Text) != 51)
                    {
                        setrandom = DATAS.chemistry_mcqs[counter];
                        question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                        Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                        Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                        Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                        Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();


                    }
                    if (Convert.ToInt32(serial.Text) == 51) { count = 0; }
                }
            }

            if ((Convert.ToInt32(serial.Text) == 26) && (count == 0))
            {
                counter = 0; CHAPTER_NAME.Text = "CHEMISTRY";
                OleDbDataAdapter adp = new OleDbDataAdapter("select * from CHEMISTRY", con);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                setrandom = DATAS.chemistry_mcqs[counter];
                question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();
                count++;
                // MessageBox.Show(serial.Text);
            }

            if ((Convert.ToInt32(serial.Text) > 50) && (Convert.ToInt32(serial.Text) <= 75))
            {

                if (count == 1)
                {
                    OleDbDataAdapter adp = new OleDbDataAdapter("select * from PHYSICS", con);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    if (ds.Tables[0].Rows[counter]["CORRECT"].ToString() == D.Name)
                    { DATAS.score += 1; DATAS.physic_score += 1; }
                    counter++;
                    serial_text1 += 1;
                    serial.Text = serial_text1.ToString();

                    if (Convert.ToInt32(serial.Text) != 76)
                    {
                        setrandom = DATAS.physic_mcqs[counter];
                        question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                        Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                        Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                        Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                        Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();


                    }
                    if (Convert.ToInt32(serial.Text) == 76) { count = 0; }

                }
            }
            if ((Convert.ToInt32(serial.Text) == 51) && (count == 0))
            {
                counter = 0;
                CHAPTER_NAME.Text = "PHYSICS";
                OleDbDataAdapter adp = new OleDbDataAdapter("select * from PHYSICS", con);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                setrandom = DATAS.physic_mcqs[counter];
                question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();
                count++;
                //  MessageBox.Show(serial.Text);
            }



            if ((Convert.ToInt32(serial.Text) > 75) && (Convert.ToInt32(serial.Text) <= 100))
            {


                if (count == 1)
                {
                    OleDbDataAdapter adp = new OleDbDataAdapter("select * from MATH", con);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    if (ds.Tables[0].Rows[counter]["CORRECT"].ToString() == D.Name)
                    { DATAS.score += 1; DATAS.math_score += 1; }

                    counter++;
                    serial_text1 += 1;
                    serial.Text = serial_text1.ToString();
                    if (Convert.ToInt32(serial.Text) == 101)
                    { SCORE SR = new SCORE(); Hide(); SR.Show();/* MessageBox.Show(DATAS.score.ToString()); */}

                    if ((Convert.ToInt32(serial.Text) != 76) && (Convert.ToInt32(serial.Text) != 101))
                    {
                        setrandom = DATAS.math_mcqs[counter];
                        question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                        Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                        Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                        Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                        Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();

                    }


                   
                }

                if ((Convert.ToInt32(serial.Text) == 76) && (count == 0))
                {
                    counter = 0; CHAPTER_NAME.Text = "MATHEMATICS";
                    OleDbDataAdapter adp = new OleDbDataAdapter("select * from MATH", con);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    setrandom = DATAS.math_mcqs[counter];
                    question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                    Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                    Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                    Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                    Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();
                    count++;
                    // MessageBox.Show(serial.Text);
                }

            }
            D.Checked = false;
        }

        private void C_Click(object sender, EventArgs e)
        {
            option = Convert.ToInt32(serial.Text);
            DATAS.save_option[option] = "C";
            // MessageBox.Show(option + "C");
            if (Convert.ToInt32(serial.Text) <= 25)
            {
                OleDbDataAdapter adp = new OleDbDataAdapter("select * from ENGLISH", con);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                if (ds.Tables[0].Rows[counter]["CORRECT"].ToString() == C.Name)
                { DATAS.score += 1; DATAS.english_score++; }

                counter++;
                serial_text1 += 1;
                serial.Text = serial_text1.ToString();

                if (Convert.ToInt32(serial.Text) != 26)
                {
                    setrandom = DATAS.english_mcqs[counter];
                    question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                    Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                    Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                    Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                    Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();

                }
            }

            if ((Convert.ToInt32(serial.Text) > 25) && (Convert.ToInt32(serial.Text) <= 50))
            {
                if (count == 1)
                {
                    OleDbDataAdapter adp = new OleDbDataAdapter("select * from CHEMISTRY", con);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    if (ds.Tables[0].Rows[counter]["CORRECT"].ToString() == C.Name)
                    { DATAS.score += 1; DATAS.chemistry_score++; }
                    counter++;
                    serial_text1 += 1;
                    serial.Text = serial_text1.ToString();

                    if (Convert.ToInt32(serial.Text) != 51)
                    {
                        setrandom = DATAS.chemistry_mcqs[counter];
                        question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                        Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                        Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                        Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                        Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();


                    }
                    if (Convert.ToInt32(serial.Text) == 51) { count = 0; }
                }
            }

            if ((Convert.ToInt32(serial.Text) == 26) && (count == 0))
            {
                counter = 0; CHAPTER_NAME.Text = "CHEMISTRY";
                OleDbDataAdapter adp = new OleDbDataAdapter("select * from CHEMISTRY", con);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                setrandom = DATAS.chemistry_mcqs[counter];
                question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();
                count++;
                // MessageBox.Show(serial.Text);
            }

            if ((Convert.ToInt32(serial.Text) > 50) && (Convert.ToInt32(serial.Text) <= 75))
            {

                if (count == 1)
                {
                    OleDbDataAdapter adp = new OleDbDataAdapter("select * from PHYSICS", con);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    if (ds.Tables[0].Rows[counter]["CORRECT"].ToString() == C.Name)
                    { DATAS.score += 1; DATAS.physic_score++; }
                    counter++;
                    serial_text1 += 1;
                    serial.Text = serial_text1.ToString();

                    if (Convert.ToInt32(serial.Text) != 76)
                    {
                        setrandom = DATAS.physic_mcqs[counter];
                        question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                        Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                        Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                        Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                        Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();


                    }
                    if (Convert.ToInt32(serial.Text) == 76) { count = 0; }

                }
            }
            if ((Convert.ToInt32(serial.Text) == 51) && (count == 0))
            {
                counter = 0;
                CHAPTER_NAME.Text = "PHYSICS";
                OleDbDataAdapter adp = new OleDbDataAdapter("select * from PHYSICS", con);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                setrandom = DATAS.physic_mcqs[counter];
                question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();
                count++;
                //  MessageBox.Show(serial.Text);
            }



            if ((Convert.ToInt32(serial.Text) > 75) && (Convert.ToInt32(serial.Text) <= 100))
            {


                if (count == 1)
                {
                    OleDbDataAdapter adp = new OleDbDataAdapter("select * from MATH", con);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    if (ds.Tables[0].Rows[counter]["CORRECT"].ToString() == C.Name)
                    { DATAS.score += 1; DATAS.math_score += 1; }

                    counter++;
                    serial_text1 += 1;
                    serial.Text = serial_text1.ToString();
                    if (Convert.ToInt32(serial.Text) == 101)
                    { SCORE SR = new SCORE(); Hide(); SR.Show(); /*MessageBox.Show(DATAS.score.ToString());*/ }

                    if ((Convert.ToInt32(serial.Text) != 76) && (Convert.ToInt32(serial.Text) != 101))
                    {
                        setrandom = DATAS.math_mcqs[counter];
                        question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                        Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                        Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                        Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                        Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();

                    }



                }

                if ((Convert.ToInt32(serial.Text) == 76) && (count == 0))
                {
                    counter = 0; CHAPTER_NAME.Text = "MATHEMATICS";
                    OleDbDataAdapter adp = new OleDbDataAdapter("select * from MATH", con);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    setrandom = DATAS.math_mcqs[counter];
                    question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                    Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                    Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                    Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                    Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();
                    count++;
                    // MessageBox.Show(serial.Text);
                }
            }
            C.Checked = false;
        }

        private void CHAPTER_NAME_Click(object sender, EventArgs e)
        {

        }

        private void ECAT_Load(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label16_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        private void box_option_A_CheckedChanged(object sender, EventArgs e)
        {
            



        }

        private void A_Click(object sender, EventArgs e)
        {
            option = Convert.ToInt32(serial.Text);
            DATAS.save_option[option] = "A";
            // MessageBox.Show(option + "A");

            if (Convert.ToInt32(serial.Text) <= 25)
            {
                OleDbDataAdapter adp = new OleDbDataAdapter("select * from ENGLISH", con);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                if (ds.Tables[0].Rows[counter]["CORRECT"].ToString() == A.Name)
                { DATAS.score += 1; DATAS.english_score += 1; }

                counter++;
                serial_text1 += 1;
                serial.Text = serial_text1.ToString();

                if (Convert.ToInt32(serial.Text) != 26)
                {
                    setrandom = DATAS.english_mcqs[counter];
                    question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                    Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                    Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                    Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                    Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();

                }
            }

            if ((Convert.ToInt32(serial.Text) > 25) && (Convert.ToInt32(serial.Text) <= 50))
            {
                if (count == 1)
                {
                    OleDbDataAdapter adp = new OleDbDataAdapter("select * from CHEMISTRY", con);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    if (ds.Tables[0].Rows[counter]["CORRECT"].ToString() == A.Name)
                    { DATAS.score += 1; DATAS.chemistry_score++; }
                    counter++;
                    serial_text1 += 1;
                    serial.Text = serial_text1.ToString();

                    if (Convert.ToInt32(serial.Text) != 51)
                    {
                        setrandom = DATAS.chemistry_mcqs[counter];
                        question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                        Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                        Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                        Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                        Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();


                    }
                    if (Convert.ToInt32(serial.Text) == 51) { count = 0; }
                }
            }

            if ((Convert.ToInt32(serial.Text) == 26) && (count == 0))
            {
                counter = 0; CHAPTER_NAME.Text = "CHEMISTRY";
                OleDbDataAdapter adp = new OleDbDataAdapter("select * from CHEMISTRY", con);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                setrandom = DATAS.chemistry_mcqs[counter];
                question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();
                count++;
                // MessageBox.Show(serial.Text);
            }

            if ((Convert.ToInt32(serial.Text) > 50) && (Convert.ToInt32(serial.Text) <= 75))
            {

                if (count == 1)
                {
                    OleDbDataAdapter adp = new OleDbDataAdapter("select * from PHYSICS", con);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    if (ds.Tables[0].Rows[counter]["CORRECT"].ToString() == A.Name)
                    { DATAS.score += 1; DATAS.physic_score++; }
                    counter++;
                    serial_text1 += 1;
                    serial.Text = serial_text1.ToString();

                    if (Convert.ToInt32(serial.Text) != 76)
                    {
                        setrandom = DATAS.physic_mcqs[counter];
                        question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                        Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                        Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                        Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                        Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();


                    }
                    if (Convert.ToInt32(serial.Text) == 76) { count = 0; }

                }
            }
            if ((Convert.ToInt32(serial.Text) == 51) && (count == 0))
            {
                counter = 0;
                CHAPTER_NAME.Text = "PHYSICS";
                OleDbDataAdapter adp = new OleDbDataAdapter("select * from PHYSICS", con);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                setrandom = DATAS.physic_mcqs[counter];
                question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();
                count++;
                //  MessageBox.Show(serial.Text);
            }



            if ((Convert.ToInt32(serial.Text) > 75) && (Convert.ToInt32(serial.Text) <= 100))
            {


                if (count == 1)
                {
                    OleDbDataAdapter adp = new OleDbDataAdapter("select * from MATH", con);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    if (ds.Tables[0].Rows[counter]["CORRECT"].ToString() == A.Name)
                    { DATAS.score += 1; DATAS.math_score++; }

                    counter++;
                    serial_text1 += 1;
                    serial.Text = serial_text1.ToString();
                    if (Convert.ToInt32(serial.Text) == 101)
                    { SCORE SR = new SCORE(); Hide(); SR.Show(); /*MessageBox.Show(DATAS.score.ToString());*/ }

                    if ((Convert.ToInt32(serial.Text) != 76) && (Convert.ToInt32(serial.Text) != 101))
                    {
                        setrandom = DATAS.math_mcqs[counter];
                        question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                        Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                        Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                        Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                        Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();

                    }



                }

                if ((Convert.ToInt32(serial.Text) == 76) && (count == 0))
                {
                    counter = 0; CHAPTER_NAME.Text = "MATHEMATICS";
                    OleDbDataAdapter adp = new OleDbDataAdapter("select * from MATH", con);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    setrandom = DATAS.math_mcqs[counter];
                    question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                    Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                    Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                    Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                    Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();
                    count++;
                    // MessageBox.Show(serial.Text);
                }
            }
            A.Checked = false;


        }
    }
}