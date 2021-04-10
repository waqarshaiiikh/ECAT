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
    public partial class ECAT_1_ : Form
    {
        string correct;
        int count1 = 0;
        int option = 0;
        int count = 0;
        int setrandom;
        int counter = 0;
        int serial_text1 = 1;
        int seconds_t, minute_t, hours_t;
        OleDbConnection con = new OleDbConnection(DATAS.database);

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (seconds_t == 0)
            {
                if ((seconds_t == 0) && (minute_t == 0) && (hours_t == 0))
                { Close(); SCORE SR = new SCORE(); SR.Show(); }
               
                else if ((seconds_t == 0) && (minute_t == 0))
                {
                    minute_t = 59; hours_t--;
                    hours_ned_nust.Text = hours_t.ToString();
                }
                else {
                    seconds_t = 59; minute_t--;
                    min_ned_nust.Text = minute_t.ToString();
                }
            }
            if (0 < seconds_t)
            {
                sec_ned_nust.Text = seconds_t.ToString();
                seconds_t--;
            }
        }

        private void Next_button_Click(object sender, EventArgs e)
        {
            Option_a.ForeColor = Color.Black;
            Option_b.ForeColor = Color.Black;
            Option_c.ForeColor = Color.Black;
            Option_d.ForeColor = Color.Black;
            if (Convert.ToInt32(serial.Text) == 1) { back_button.Visible = true; }
            if (Convert.ToInt32(serial.Text) == 180) { counter = -1; }
            if ((Convert.ToInt32(serial.Text) >= 180) && (Convert.ToInt32(serial.Text) < 200))
            {
                //MessageBox.Show("kia");

                // CHAPTER_NAME.Text = "ENGLISH";
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
            if (Convert.ToInt32(serial.Text) == 200) { Next_button.Visible = false; }
            else { Next_button.Visible = true; }
            if (Convert.ToInt32(serial.Text) == 130) { counter = -1; }
            if ((Convert.ToInt32(serial.Text) >= 130) && (Convert.ToInt32(serial.Text) < 180))
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

            if (Convert.ToInt32(serial.Text) == 80) { counter = -1; }
            if ((Convert.ToInt32(serial.Text) >= 80) && (Convert.ToInt32(serial.Text) < 130))
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

            if (Convert.ToInt32(serial.Text) < 80)
            {

                CHAPTER_NAME.Text = "MATHEMATICS";
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

        }

        private void back_button_Click(object sender, EventArgs e)
        {
            Option_a.ForeColor = Color.Black;
            Option_b.ForeColor = Color.Black;
            Option_c.ForeColor = Color.Black;
            Option_d.ForeColor = Color.Black;
            if (Convert.ToInt32(serial.Text) == 2) { back_button.Visible = false; }
            if ((Convert.ToInt32(serial.Text) > 186) && (Convert.ToInt32(serial.Text) <= 200))
            {
                //MessageBox.Show("kia");

                // CHAPTER_NAME.Text = "ENGLISH";
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
            if (Convert.ToInt32(serial.Text) == 200) { Next_button.Visible = false; }
            else { Next_button.Visible = true; }
            if (Convert.ToInt32(serial.Text) == 181) { counter = 50; }
            if ((Convert.ToInt32(serial.Text) > 131) && (Convert.ToInt32(serial.Text) <= 181))
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
            if (Convert.ToInt32(serial.Text) == 131) { counter = 50; }
            if ((Convert.ToInt32(serial.Text) > 81) && (Convert.ToInt32(serial.Text) <= 131))
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

            if (Convert.ToInt32(serial.Text) == 81)
            { counter = 80; }
            if (Convert.ToInt32(serial.Text) <= 81)
            {

                CHAPTER_NAME.Text = "MATHEMATICS";
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

        }

        private void A_Click(object sender, EventArgs e)
        {
            
               
            option = Convert.ToInt32(serial.Text);
            DATAS.save_option[option] = "A";
            if (Convert.ToInt32(serial.Text) == 200)
            {
                OleDbDataAdapter adp = new OleDbDataAdapter("select * from ENGLISH", con);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                if (ds.Tables[0].Rows[counter]["CORRECT"].ToString() == A.Name)
                { DATAS.score += 1; DATAS.english_score++; } 
                SCORE SR = new SCORE(); Hide(); SR.Show(); //MessageBox.Show(DATAS.score.ToString());
            }

            // MessageBox.Show(option + "A");


            //  { SCORE SR = new SCORE(); Close(); SR.Show(); MessageBox.Show(DATAS.score.ToString()); }


            if (Convert.ToInt32(serial.Text) <= 80)
            {
                OleDbDataAdapter adp = new OleDbDataAdapter("select * from MATH", con);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                if (ds.Tables[0].Rows[counter]["CORRECT"].ToString() == A.Name)
                { DATAS.score += 1; DATAS.math_score += 1; }

                counter++;
                serial_text1 += 1;
                serial.Text = serial_text1.ToString();

                if (Convert.ToInt32(serial.Text) != 81)
                {
                    setrandom = DATAS.math_mcqs[counter];
                    question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                    Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                    Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                    Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                    Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();

                }
            }

            if ((Convert.ToInt32(serial.Text) > 80) && (Convert.ToInt32(serial.Text) <= 130))
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

                    if (Convert.ToInt32(serial.Text) != 131)
                    {
                        setrandom = DATAS.physic_mcqs[counter];
                        question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                        Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                        Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                        Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                        Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();


                    }
                    if (Convert.ToInt32(serial.Text) == 131) { count = 0; }
                }
            }

            if ((Convert.ToInt32(serial.Text) == 81) && (count == 0))
            {
                counter = 0; CHAPTER_NAME.Text = "PHYSICS";
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
                // MessageBox.Show(serial.Text);
            }

            if ((Convert.ToInt32(serial.Text) > 130) && (Convert.ToInt32(serial.Text) <= 180))
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

                    if (Convert.ToInt32(serial.Text) != 181)
                    {
                        setrandom = DATAS.chemistry_mcqs[counter];
                        question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                        Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                        Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                        Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                        Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();


                    }
                    if (Convert.ToInt32(serial.Text) == 181) { count = 0; }

                }
            }
            if ((Convert.ToInt32(serial.Text) == 131) && (count == 0))
            {
                counter = 0;
                CHAPTER_NAME.Text = "CHEMISTRY";
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
                //  MessageBox.Show(serial.Text);
            }



            if ((Convert.ToInt32(serial.Text) > 180) && (Convert.ToInt32(serial.Text) < 200))
            {


                if (count == 1)
                {
                    OleDbDataAdapter adp = new OleDbDataAdapter("select * from ENGLISH", con);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    if (ds.Tables[0].Rows[counter]["CORRECT"].ToString() == A.Name)
                    { DATAS.score += 1; DATAS.english_score++; }

                    counter++;
                    serial_text1 += 1;
                    serial.Text = serial_text1.ToString();

                    if ((Convert.ToInt32(serial.Text) != 181) && (Convert.ToInt32(serial.Text) != 201))
                    {
                        setrandom = DATAS.english_mcqs[counter];
                        question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                        Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                        Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                        Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                        Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();

                    }



                }

                if ((Convert.ToInt32(serial.Text) == 181) && (count == 0))
                {
                    counter = 0; CHAPTER_NAME.Text = "ENGLISH";
                    OleDbDataAdapter adp = new OleDbDataAdapter("select * from ENGLISH", con);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    setrandom = DATAS.english_mcqs[counter];
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

        private void B_Click(object sender, EventArgs e)
        {


            option = Convert.ToInt32(serial.Text);
            DATAS.save_option[option] = "B";
            if (Convert.ToInt32(serial.Text) == 200)
            {
                OleDbDataAdapter adp = new OleDbDataAdapter("select * from ENGLISH", con);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                if (ds.Tables[0].Rows[counter]["CORRECT"].ToString() == B.Name)
                { DATAS.score += 1; DATAS.english_score++; }
                SCORE SR = new SCORE(); Hide(); SR.Show();// MessageBox.Show(DATAS.score.ToString());
            }

            // MessageBox.Show(option + "A");


            //  { SCORE SR = new SCORE(); Close(); SR.Show(); MessageBox.Show(DATAS.score.ToString()); }


            if (Convert.ToInt32(serial.Text) <= 80)
            {
                OleDbDataAdapter adp = new OleDbDataAdapter("select * from MATH", con);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                if (ds.Tables[0].Rows[counter]["CORRECT"].ToString() == B.Name)
                { DATAS.score += 1; DATAS.math_score += 1; }

                counter++;
                serial_text1 += 1;
                serial.Text = serial_text1.ToString();

                if (Convert.ToInt32(serial.Text) != 81)
                {
                    setrandom = DATAS.math_mcqs[counter];
                    question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                    Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                    Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                    Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                    Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();

                }
            }

            if ((Convert.ToInt32(serial.Text) > 80) && (Convert.ToInt32(serial.Text) <= 130))
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

                    if (Convert.ToInt32(serial.Text) != 131)
                    {
                        setrandom = DATAS.physic_mcqs[counter];
                        question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                        Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                        Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                        Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                        Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();


                    }
                    if (Convert.ToInt32(serial.Text) == 131) { count = 0; }
                }
            }

            if ((Convert.ToInt32(serial.Text) == 81) && (count == 0))
            {
                counter = 0; CHAPTER_NAME.Text = "PHYSICS";
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
                // MessageBox.Show(serial.Text);
            }

            if ((Convert.ToInt32(serial.Text) > 130) && (Convert.ToInt32(serial.Text) <= 180))
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

                    if (Convert.ToInt32(serial.Text) != 181)
                    {
                        setrandom = DATAS.chemistry_mcqs[counter];
                        question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                        Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                        Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                        Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                        Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();


                    }
                    if (Convert.ToInt32(serial.Text) == 181) { count = 0; }

                }
            }
            if ((Convert.ToInt32(serial.Text) == 131) && (count == 0))
            {
                counter = 0;
                CHAPTER_NAME.Text = "CHEMISTRY";
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
                //  MessageBox.Show(serial.Text);
            }



            if ((Convert.ToInt32(serial.Text) > 180) && (Convert.ToInt32(serial.Text) < 200))
            {


                if (count == 1)
                {
                    OleDbDataAdapter adp = new OleDbDataAdapter("select * from ENGLISH", con);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    if (ds.Tables[0].Rows[counter]["CORRECT"].ToString() == B.Name)
                    { DATAS.score += 1; DATAS.english_score++; }

                    counter++;
                    serial_text1 += 1;
                    serial.Text = serial_text1.ToString();

                    if ((Convert.ToInt32(serial.Text) != 181) && (Convert.ToInt32(serial.Text) != 201))
                    {
                        setrandom = DATAS.english_mcqs[counter];
                        question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                        Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                        Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                        Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                        Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();

                    }



                }

                if ((Convert.ToInt32(serial.Text) == 181) && (count == 0))
                {
                    counter = 0; CHAPTER_NAME.Text = "ENGLISH";
                    OleDbDataAdapter adp = new OleDbDataAdapter("select * from ENGLISH", con);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    setrandom = DATAS.english_mcqs[counter];
                    question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                    Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                    Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                    Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                    Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();
                    count++;
                    // MessageBox.Show(serial.Text);
                }
            }
//            A.Checked = false;
            B.Checked = false;

        }

        private void C_MouseCaptureChanged(object sender, EventArgs e)
        {

        }

        private void C_Click(object sender, EventArgs e)
        {



            option = Convert.ToInt32(serial.Text);
            DATAS.save_option[option] = "C";
            if (Convert.ToInt32(serial.Text) == 200)
            {
                OleDbDataAdapter adp = new OleDbDataAdapter("select * from ENGLISH", con);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                if (ds.Tables[0].Rows[counter]["CORRECT"].ToString() ==C.Name)
                { DATAS.score += 1; DATAS.english_score++; }
                SCORE SR = new SCORE(); Hide(); SR.Show(); //MessageBox.Show(DATAS.score.ToString());
            }

            // MessageBox.Show(option + "A");


            //  { SCORE SR = new SCORE(); Close(); SR.Show(); MessageBox.Show(DATAS.score.ToString()); }


            if (Convert.ToInt32(serial.Text) <= 80)
            {
                OleDbDataAdapter adp = new OleDbDataAdapter("select * from MATH", con);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                if (ds.Tables[0].Rows[counter]["CORRECT"].ToString() == C.Name)
                { DATAS.score += 1; DATAS.math_score += 1; }

                counter++;
                serial_text1 += 1;
                serial.Text = serial_text1.ToString();

                if (Convert.ToInt32(serial.Text) != 81)
                {
                    setrandom = DATAS.math_mcqs[counter];
                    question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                    Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                    Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                    Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                    Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();

                }
            }

            if ((Convert.ToInt32(serial.Text) > 80) && (Convert.ToInt32(serial.Text) <= 130))
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

                    if (Convert.ToInt32(serial.Text) != 131)
                    {
                        setrandom = DATAS.physic_mcqs[counter];
                        question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                        Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                        Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                        Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                        Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();


                    }
                    if (Convert.ToInt32(serial.Text) == 131) { count = 0; }
                }
            }

            if ((Convert.ToInt32(serial.Text) == 81) && (count == 0))
            {
                counter = 0; CHAPTER_NAME.Text = "PHYSICS";
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
                // MessageBox.Show(serial.Text);
            }

            if ((Convert.ToInt32(serial.Text) > 130) && (Convert.ToInt32(serial.Text) <= 180))
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

                    if (Convert.ToInt32(serial.Text) != 181)
                    {
                        setrandom = DATAS.chemistry_mcqs[counter];
                        question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                        Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                        Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                        Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                        Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();


                    }
                    if (Convert.ToInt32(serial.Text) == 181) { count = 0; }

                }
            }
            if ((Convert.ToInt32(serial.Text) == 131) && (count == 0))
            {
                counter = 0;
                CHAPTER_NAME.Text = "CHEMISTRY";
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
                //  MessageBox.Show(serial.Text);
            }



            if ((Convert.ToInt32(serial.Text) > 180) && (Convert.ToInt32(serial.Text) < 200))
            {


                if (count == 1)
                {
                    OleDbDataAdapter adp = new OleDbDataAdapter("select * from ENGLISH", con);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    if (ds.Tables[0].Rows[counter]["CORRECT"].ToString() == C.Name)
                    { DATAS.score += 1; DATAS.english_score++; }

                    counter++;
                    serial_text1 += 1;
                    serial.Text = serial_text1.ToString();

                    if ((Convert.ToInt32(serial.Text) != 181) && (Convert.ToInt32(serial.Text) != 201))
                    {
                        setrandom = DATAS.english_mcqs[counter];
                        question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                        Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                        Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                        Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                        Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();

                    }



                }

                if ((Convert.ToInt32(serial.Text) == 181) && (count == 0))
                {
                    counter = 0; CHAPTER_NAME.Text = "ENGLISH";
                    OleDbDataAdapter adp = new OleDbDataAdapter("select * from ENGLISH", con);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    setrandom = DATAS.english_mcqs[counter];
                    question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                    Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                    Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                    Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                    Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();
                    count++;
                    // MessageBox.Show(serial.Text);
                }
            }
//            A.Checked = false;
            C.Checked = false;

        }

        private void D_Click(object sender, EventArgs e)
        {
            
            option = Convert.ToInt32(serial.Text);
            DATAS.save_option[option] = "D";
            if (Convert.ToInt32(serial.Text) == 200)
            {
                OleDbDataAdapter adp = new OleDbDataAdapter("select * from ENGLISH", con);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                if (ds.Tables[0].Rows[counter]["CORRECT"].ToString() == D.Name)
                { DATAS.score += 1; DATAS.english_score++; }
                SCORE SR = new SCORE(); Hide(); SR.Show(); //MessageBox.Show(DATAS.score.ToString());
            }

            // MessageBox.Show(option + "A");


            //  { SCORE SR = new SCORE(); Close(); SR.Show(); MessageBox.Show(DATAS.score.ToString()); }


            if (Convert.ToInt32(serial.Text) <= 80)
            {
                OleDbDataAdapter adp = new OleDbDataAdapter("select * from MATH", con);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                if (ds.Tables[0].Rows[counter]["CORRECT"].ToString() == D.Name)
                { DATAS.score += 1; DATAS.math_score += 1; }

                counter++;
                serial_text1 += 1;
                serial.Text = serial_text1.ToString();

                if (Convert.ToInt32(serial.Text) != 81)
                {
                    setrandom = DATAS.math_mcqs[counter];
                    question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                    Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                    Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                    Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                    Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();

                }
            }

            if ((Convert.ToInt32(serial.Text) > 80) && (Convert.ToInt32(serial.Text) <= 130))
            {
                if (count == 1)
                {
                    OleDbDataAdapter adp = new OleDbDataAdapter("select * from PHYSICS", con);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    if (ds.Tables[0].Rows[counter]["CORRECT"].ToString() == D.Name)
                    { DATAS.score += 1; DATAS.physic_score++; }
                    counter++;
                    serial_text1 += 1;
                    serial.Text = serial_text1.ToString();

                    if (Convert.ToInt32(serial.Text) != 131)
                    {
                        setrandom = DATAS.physic_mcqs[counter];
                        question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                        Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                        Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                        Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                        Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();


                    }
                    if (Convert.ToInt32(serial.Text) == 131) { count = 0; }
                }
            }

            if ((Convert.ToInt32(serial.Text) == 81) && (count == 0))
            {
                counter = 0; CHAPTER_NAME.Text = "PHYSICS";
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
                // MessageBox.Show(serial.Text);
            }

            if ((Convert.ToInt32(serial.Text) > 130) && (Convert.ToInt32(serial.Text) <= 180))
            {

                if (count == 1)
                {
                    OleDbDataAdapter adp = new OleDbDataAdapter("select * from CHEMISTRY", con);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    if (ds.Tables[0].Rows[counter]["CORRECT"].ToString() == D.Name)
                    { DATAS.score += 1; DATAS.chemistry_score++; }
                    counter++;
                    serial_text1 += 1;
                    serial.Text = serial_text1.ToString();

                    if (Convert.ToInt32(serial.Text) != 181)
                    {
                        setrandom = DATAS.chemistry_mcqs[counter];
                        question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                        Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                        Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                        Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                        Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();


                    }
                    if (Convert.ToInt32(serial.Text) == 181) { count = 0; }

                }
            }
            if ((Convert.ToInt32(serial.Text) == 131) && (count == 0))
            {
                counter = 0;
                CHAPTER_NAME.Text = "CHEMISTRY";
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
                //  MessageBox.Show(serial.Text);
            }



            if ((Convert.ToInt32(serial.Text) > 180) && (Convert.ToInt32(serial.Text) < 200))
            {


                if (count == 1)
                {
                    OleDbDataAdapter adp = new OleDbDataAdapter("select * from ENGLISH", con);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    if (ds.Tables[0].Rows[counter]["CORRECT"].ToString() == D.Name)
                    { DATAS.score += 1; DATAS.english_score++; }

                    counter++;
                    serial_text1 += 1;
                    serial.Text = serial_text1.ToString();

                    if ((Convert.ToInt32(serial.Text) != 181) && (Convert.ToInt32(serial.Text) != 201))
                    {
                        setrandom = DATAS.english_mcqs[counter];
                        question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                        Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                        Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                        Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                        Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();

                    }



                }

                if ((Convert.ToInt32(serial.Text) == 181) && (count == 0))
                {
                    counter = 0; CHAPTER_NAME.Text = "ENGLISH";
                    OleDbDataAdapter adp = new OleDbDataAdapter("select * from ENGLISH", con);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    setrandom = DATAS.english_mcqs[counter];
                    question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                    Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                    Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                    Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                    Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();
                    count++;
                    // MessageBox.Show(serial.Text);
                }
            }
//            A.Checked = false;
            D.Checked = false;


        }

        private void label15_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label16_Click(object sender, EventArgs e)
        {

            this.Visible = false;
        }

        public ECAT_1_()
        {
            InitializeComponent();

            DATAS.physic_score = 0;
            DATAS.math_score = 0;
            DATAS.chemistry_score = 0;
            DATAS.english_score = 0;
            DATAS.score = 0;

            if (DATAS.Nust_status == 1)
            {
                if (DATAS.review == 0)
                {
                    Random ran = new Random();
                    if (DATAS.review == 0)
                    {
                        while (count < DATAS.Nust_default_english_mcqs) { DATAS.english_mcqs[count] = ran.Next(0, 178); count++; }
                        count = 0;

                        while (count < DATAS.Nust_default_physics_mcqs) { DATAS.physic_mcqs[count] = ran.Next(0, 300); count++; }
                        count = 0;

                        while (count < DATAS.Nust_default_math_mcqs) { DATAS.math_mcqs[count] = ran.Next(0, 198); count++; }
                        count = 0;

                        while (count < DATAS.Nust_default_chemistry_mcqs) { DATAS.chemistry_mcqs[count] = ran.Next(0, 268); count++; }
                        count = 0;
                    }
                }
                OleDbDataAdapter adp = new OleDbDataAdapter("select * from MATH", con);

                DataSet ds = new DataSet();
                adp.Fill(ds);
                setrandom = DATAS.math_mcqs[counter];
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
                    timer1.Start();
                    Next_button.Visible = false;
                    back_button.Visible = false;
                    sec_ned_nust.Visible = true;
                    hours_ned_nust.Visible = true;
                    min_ned_nust.Visible = true;
                    label6.Visible = true;
                    label8.Visible = true;
                    // second.Visible = false;
                    // label4.Visible = false;
                    // minutes.Visible = false;
                    // label2.Visible = false;
                    // hours.Visible = false;
                    minute_t = DATAS.Nust_default_time;
                    //min_ned_nust.Text = minute_t.ToString();
                    hours_t = 2;
                    //hours_ned_nust.Text = hours_t.ToString();
                    seconds_t = 59;
                    sec_ned_nust.Text = seconds_t.ToString();
                    min_ned_nust.Text = minute_t.ToString();
                    hours_ned_nust.Text = hours_t.ToString();

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
                        correct = ds.Tables[0].Rows[setrandom]["CORRECT"].ToString();

                        if (correct == "A") { Option_a.ForeColor = Color.Blue; }
                        if (correct == "B") { Option_b.ForeColor = Color.Blue; }
                        if (correct == "C") { Option_c.ForeColor = Color.Blue; }
                        if (correct == "D") { Option_d.ForeColor = Color.Blue; }

                    }

                    label1.Visible = false;
                    label6.Visible = false;
                    label3.Visible = false;

                    label8.Visible = false;
                    label7.Visible = false;

                    //  button2.Visible = false;
                    // goto_question.Visible = false;
                    //label17.Visible = false;
                    A.Visible = false;
                    B.Visible = false;
                    C.Visible = false;
                    D.Visible = false;
                }

            }
            //if (DATAS.Nust_status == 1) { MessageBox.Show("get ready for nust"); }

        }

        private void question_Click(object sender, EventArgs e)
        {

        }
    }
}
