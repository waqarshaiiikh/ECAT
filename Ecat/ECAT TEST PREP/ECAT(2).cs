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
    public partial class ECAT_2_ : Form
    {
        string correct;
        int count1 = 0;
        int option = 0;
        int count = 0;
        int setrandom;
        int counter = 0;
        int serial_text1 = 1;
        int seconds_t, minute_t, hours_t,time_t;
       int time_math, time_phy, time_chem, time_eng;
      int hours_math, hours_phy, hours_chem, hours_eng;
        int minute_math, minute_phy, minute_chem, minute_eng ;

        OleDbConnection con = new OleDbConnection(DATAS.database);
        int em = Convert.ToInt32(DATAS.required_ENGLISH_MCQS);
        int mm = Convert.ToInt32(DATAS.required_MATH_MCQS);

        int cm = Convert.ToInt32(DATAS.required_CHEMISTRY_MCQS);
        int pm = Convert.ToInt32(DATAS.required_PHYSICS_MCQS);

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void label15_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void min_ned_nust_Click(object sender, EventArgs e)
        {

        }
        private void sec_ned_nust_Click(object sender, EventArgs e)
        {

        }
        private void hours_ned_nust_Click(object sender, EventArgs e)
        {

        }

        private void serial_Click(object sender, EventArgs e)
        {

        }
        private void label16_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        public ECAT_2_()
        {
            InitializeComponent();
            if (DATAS.Design_Pattern_status == 1)
            {
                if (DATAS.review == 0)
                {
                    Random ran = new Random();
                    if (DATAS.review == 0)
                    {
                        while (count < em) { DATAS.english_mcqs[count] = ran.Next(0, 178); count++; }
                        count = 0;

                        while (count < mm) { DATAS.physic_mcqs[count] = ran.Next(0, 312); count++; }
                        count = 0;

                        while (count < cm) { DATAS.math_mcqs[count] = ran.Next(0, 198); count++; }
                        count = 0;

                        while (count < pm ) { DATAS.chemistry_mcqs[count] = ran.Next(0, 268); count++; }
                        count = 0;
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
                   // label8.Visible = true;
                    // second.Visible = false;
                    // label4.Visible = false;
                    // minutes.Visible = false;
                    // label2.Visible = false;
                    // hours.Visible = false;
                    if (DATAS.whole_MCQS_TIME_status == 1)
                    {
                         time_t= Convert.ToInt32(DATAS.whole_MCQS_TIME);
                        hours_t = time_t / 60;
                        minute_t = time_t % 60;

                    }
                    else if(DATAS.each_MCQS_TIME_status==1)
                    {
                        time_t = Convert.ToInt32(DATAS.each_MCQS_TIME);
                    }
                    else
                    {
                        time_eng = Convert.ToInt32(DATAS.required_ENGLISH_TIME);
                        time_math = Convert.ToInt32(DATAS.required_MATH_TIME);
                        time_phy = Convert.ToInt32(DATAS.required_PHYSICS_TIME);
                        time_chem = Convert.ToInt32(DATAS.required_CHEMISTRY_TIME);
                        //  hours_eng = time_eng / 60;
                        minute_eng = time_eng-1;
                        //hours_math = time_math / 60;
                        minute_math = time_math-1;
                        //hours_phy = time_phy / 60;
                        minute_phy = time_phy-1;
                        //hours_chem = time_chem / 60;
                        minute_chem = time_chem-1;

                    }
                    seconds_t = 59;
                    min_ned_nust.Text = minute_eng.ToString();
                  //  hours_ned_nust.Text = hours_t.ToString();
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
            
        }

        private void question_Click(object sender, EventArgs e){}
       
        private void back_button_Click(object sender, EventArgs e)
        {
            Option_a.ForeColor = Color.Black;
            Option_b.ForeColor = Color.Black;
            Option_c.ForeColor = Color.Black;
            Option_d.ForeColor = Color.Black;
            if (Convert.ToInt32(serial.Text) == 2) { back_button.Visible = false; }
            if ((Convert.ToInt32(serial.Text) > em + cm + pm + 1) && (Convert.ToInt32(serial.Text) <= em + cm + pm + mm))
            {
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
            if (Convert.ToInt32(serial.Text) == em + cm + pm + mm) { Next_button.Visible = false; }
            else { Next_button.Visible = true; }
            if (Convert.ToInt32(serial.Text) == em + cm + pm + 1) { counter = pm; }
            if ((Convert.ToInt32(serial.Text) > em + cm + 1) && (Convert.ToInt32(serial.Text) <= em + cm + pm + 1))
            {
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
            if (Convert.ToInt32(serial.Text) == em + cm + 1) { counter = cm; }
            if ((Convert.ToInt32(serial.Text) > em + 1) && (Convert.ToInt32(serial.Text) <= em + cm + 1))
            {
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

            if (Convert.ToInt32(serial.Text) == em + 1)
            { counter = em; }
            if (Convert.ToInt32(serial.Text) <= em + 1)
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

        private void Next_button_Click_1(object sender, EventArgs e)
        {
            Option_a.ForeColor = Color.Black;
            Option_b.ForeColor = Color.Black;
            Option_c.ForeColor = Color.Black;
            Option_d.ForeColor = Color.Black;
            if (Convert.ToInt32(serial.Text) == 1) { back_button.Visible = true; }
            if (Convert.ToInt32(serial.Text) == em + cm + pm) { counter = -1; }
            if ((Convert.ToInt32(serial.Text) >= em + cm + pm) && (Convert.ToInt32(serial.Text) < em + cm + pm + mm))
            {
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
            if (Convert.ToInt32(serial.Text) == em + cm + pm + mm) { Next_button.Visible = false; }
            else { Next_button.Visible = true; }
            if (Convert.ToInt32(serial.Text) == em + cm) { counter = -1; }
            if ((Convert.ToInt32(serial.Text) >= em + cm) && (Convert.ToInt32(serial.Text) < em + cm + pm))
            {
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

            if (Convert.ToInt32(serial.Text) == em) { counter = -1; }
            if ((Convert.ToInt32(serial.Text) >= em) && (Convert.ToInt32(serial.Text) < em + cm))
            {
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

            if (Convert.ToInt32(serial.Text) < em)
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


        private void B_Click_1(object sender, EventArgs e)

        {

            option = Convert.ToInt32(serial.Text);
            DATAS.save_option[option] = "B";

            if (Convert.ToInt32(serial.Text) <= em)
            {
                OleDbDataAdapter adp = new OleDbDataAdapter("select * from ENGLISH", con);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                if (ds.Tables[0].Rows[setrandom]["CORRECT"].ToString() == B.Name)
                { DATAS.score += 1; DATAS.english_score += 1; }

                counter++;
                serial_text1 += 1;
                serial.Text = serial_text1.ToString();

                if (Convert.ToInt32(serial.Text) != em + 1)
                {
                    setrandom = DATAS.english_mcqs[counter];
                    question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                    Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                    Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                    Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                    Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();

                }
            }

            if ((Convert.ToInt32(serial.Text) > em) && (Convert.ToInt32(serial.Text) <= em + cm))
            {
                if (count == 1)
                {
                    OleDbDataAdapter adp = new OleDbDataAdapter("select * from CHEMISTRY", con);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    if (ds.Tables[0].Rows[setrandom]["CORRECT"].ToString() == B.Name)
                    { DATAS.score += 1; DATAS.chemistry_score++; }
                    counter++;
                    serial_text1 += 1;
                    serial.Text = serial_text1.ToString();

                    if (Convert.ToInt32(serial.Text) != em + cm + 1)
                    {
                        setrandom = DATAS.chemistry_mcqs[counter];
                        question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                        Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                        Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                        Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                        Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();


                    }
                    if (Convert.ToInt32(serial.Text) == em + cm + 1) {  count = 0; }
                }
            }

            if ((Convert.ToInt32(serial.Text) == em + 1) && (count == 0))
            {
                seconds_t = 59;
                min_ned_nust.Text = minute_chem.ToString();
                //  hours_ned_nust.Text = hours_t.ToString();
                sec_ned_nust.Text = seconds_t.ToString();

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

            if ((Convert.ToInt32(serial.Text) > em + cm) && (Convert.ToInt32(serial.Text) <= em + cm + pm))
            {

                if (count == 1)
                {
                    OleDbDataAdapter adp = new OleDbDataAdapter("select * from PHYSICS", con);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    if (ds.Tables[0].Rows[setrandom]["CORRECT"].ToString() == B.Name)
                    { DATAS.score += 1; DATAS.physic_score++; }
                    counter++;
                    serial_text1 += 1;
                    serial.Text = serial_text1.ToString();

                    if (Convert.ToInt32(serial.Text) != em + cm + pm + 1)
                    {
                        setrandom = DATAS.physic_mcqs[counter];
                        question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                        Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                        Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                        Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                        Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();


                    }
                    if (Convert.ToInt32(serial.Text) == em + cm + pm + 1) { count = 0; }

                }
            }
            if ((Convert.ToInt32(serial.Text) == em + cm + 1) && (count == 0))
            {

                seconds_t = 59;
                min_ned_nust.Text = minute_phy.ToString();
                //  hours_ned_nust.Text = hours_t.ToString();
                sec_ned_nust.Text = seconds_t.ToString();

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
            }



            if ((Convert.ToInt32(serial.Text) > em + cm + pm) && (Convert.ToInt32(serial.Text) <= em + cm + pm + mm))
            {
                if (count == 1)
                {
                    OleDbDataAdapter adp = new OleDbDataAdapter("select * from MATH", con);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    if (ds.Tables[0].Rows[setrandom]["CORRECT"].ToString() == B.Name)
                    { DATAS.score += 1; DATAS.math_score++; }
                    counter++;
                    serial_text1 += 1;
                    serial.Text = serial_text1.ToString();
                    if (Convert.ToInt32(serial.Text) == em + cm + pm + mm + 1)
                    {
                        SCORE SR = new SCORE(); Hide(); SR.Show(); /*MessageBox.Show(DATAS.score.ToString());*/
                    }

                    if ((Convert.ToInt32(serial.Text) != em + cm + pm) && (Convert.ToInt32(serial.Text) != em + cm + pm + mm + 1))
                    {
                        setrandom = DATAS.math_mcqs[counter];
                        question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                        Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                        Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                        Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                        Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();

                    }
                }

                if ((Convert.ToInt32(serial.Text) == em + cm + pm + 1) && (count == 0))
                {

                    seconds_t = 59;
                    min_ned_nust.Text = minute_math.ToString();
                    //  hours_ned_nust.Text = hours_t.ToString();
                    sec_ned_nust.Text = seconds_t.ToString();

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

        private void C_Click_1(object sender, EventArgs e)

        {

            option = Convert.ToInt32(serial.Text);
            DATAS.save_option[option] = "C";

            if (Convert.ToInt32(serial.Text) <= em)
            {
                OleDbDataAdapter adp = new OleDbDataAdapter("select * from ENGLISH", con);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                if (ds.Tables[0].Rows[setrandom]["CORRECT"].ToString() == C.Name)
                { DATAS.score += 1; DATAS.english_score += 1; }

                counter++;
                serial_text1 += 1;
                serial.Text = serial_text1.ToString();

                if (Convert.ToInt32(serial.Text) != em + 1)
                {
                    setrandom = DATAS.english_mcqs[counter];
                    question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                    Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                    Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                    Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                    Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();

                }
            }

            if ((Convert.ToInt32(serial.Text) > em) && (Convert.ToInt32(serial.Text) <= em + cm))
            {
                if (count == 1)
                {
                    OleDbDataAdapter adp = new OleDbDataAdapter("select * from CHEMISTRY", con);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    if (ds.Tables[0].Rows[setrandom]["CORRECT"].ToString() == C.Name)
                    { DATAS.score += 1; DATAS.chemistry_score++; }
                    counter++;
                    serial_text1 += 1;
                    serial.Text = serial_text1.ToString();

                    if (Convert.ToInt32(serial.Text) != em + cm + 1)
                    {
                        setrandom = DATAS.chemistry_mcqs[counter];
                        question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                        Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                        Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                        Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                        Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();


                    }
                    if (Convert.ToInt32(serial.Text) == em + cm + 1) { count = 0; }
                }
            }

            if ((Convert.ToInt32(serial.Text) == em + 1) && (count == 0))
            {

                seconds_t = 59;
                min_ned_nust.Text = minute_chem.ToString();
                //  hours_ned_nust.Text = hours_t.ToString();
                sec_ned_nust.Text = seconds_t.ToString();

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

            if ((Convert.ToInt32(serial.Text) > em + cm) && (Convert.ToInt32(serial.Text) <= em + cm + pm))
            {

                if (count == 1)
                {
                    OleDbDataAdapter adp = new OleDbDataAdapter("select * from PHYSICS", con);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    if (ds.Tables[0].Rows[setrandom]["CORRECT"].ToString() == C.Name)
                    { DATAS.score += 1; DATAS.physic_score++; }
                    counter++;
                    serial_text1 += 1;
                    serial.Text = serial_text1.ToString();

                    if (Convert.ToInt32(serial.Text) != em + cm + pm + 1)
                    {
                        setrandom = DATAS.physic_mcqs[counter];
                        question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                        Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                        Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                        Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                        Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();


                    }
                    if (Convert.ToInt32(serial.Text) == em + cm + pm + 1) { count = 0; }

                }
            }
            if ((Convert.ToInt32(serial.Text) == em + cm + 1) && (count == 0))
            {

                seconds_t = 59;
                min_ned_nust.Text = minute_chem.ToString();
                //  hours_ned_nust.Text = hours_t.ToString();
                sec_ned_nust.Text = seconds_t.ToString();

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
            }



            if ((Convert.ToInt32(serial.Text) > em + cm + pm) && (Convert.ToInt32(serial.Text) <= em + cm + pm + mm))
            {
                if (count == 1)
                {
                    OleDbDataAdapter adp = new OleDbDataAdapter("select * from MATH", con);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    if (ds.Tables[0].Rows[setrandom]["CORRECT"].ToString() == C.Name)
                    { DATAS.score += 1; DATAS.math_score++; }
                    counter++;
                    serial_text1 += 1;
                    serial.Text = serial_text1.ToString();
                    if (Convert.ToInt32(serial.Text) == em + cm + pm + mm + 1)
                    { SCORE SR = new SCORE(); Hide(); SR.Show();/* MessageBox.Show(DATAS.score.ToString()); */}

                    if ((Convert.ToInt32(serial.Text) != em + cm + pm) && (Convert.ToInt32(serial.Text) != em + cm + pm + mm + 1))
                    {
                        setrandom = DATAS.math_mcqs[counter];
                        question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                        Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                        Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                        Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                        Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();

                    }



                }

                if ((Convert.ToInt32(serial.Text) == em + cm + pm + 1) && (count == 0))
                {

                    seconds_t = 59;
                    min_ned_nust.Text = minute_math.ToString();
                    //  hours_ned_nust.Text = hours_t.ToString();
                    sec_ned_nust.Text = seconds_t.ToString();

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

        private void time_Tick(object sender, EventArgs e)
        {
            if (serial_text1 <= em)
                {
                    if (seconds_t >= 0)
                    {
                        sec_ned_nust.Text = seconds_t.ToString();
                        seconds_t--;
                    }
                    if (seconds_t == -1)
                    {
                        if ((seconds_t == -1) && (minute_eng == 0))
                        {  serial_text1 = em + 1; serial.Text = serial_text1.ToString(); A_Click_1(sender, e); }
                         else
                        {
                        minute_eng -= 1; min_ned_nust.Text = minute_eng.ToString(); seconds_t = 59;
                        }
                    }
                    /*if (minute_eng == -1&&hours_eng!=0)
                    {
                        hours_eng--; minute_eng = 59;
                        hours_ned_nust.Text = hours_eng.ToString();
                    }*/
            }
                else if ((serial_text1 <= em+cm) && (serial_text1 >= em))
                {
                    if (seconds_t >= 0)
                    {
                        sec_ned_nust.Text = seconds_t.ToString();
                        seconds_t--;
                    }
                    if (seconds_t == -1)
                    {
                    if ((seconds_t == -1) && (minute_chem == 0))
                    { serial_text1 = em + cm; serial.Text = serial_text1.ToString(); A_Click_1(sender, e); }
                    else
                    {minute_chem -= 1; min_ned_nust.Text = minute_chem.ToString(); seconds_t = 59; }
                    }
                 /*   if (minute_chem == -1 && hours_chem != 0)
                    {
                        hours_chem--; minute_chem = 59;
                        hours_ned_nust.Text = hours_chem.ToString();
                    }*/
                }
                else if ((serial_text1 <= em+cm+pm) && (serial_text1 >= em + cm))
                {
                    if (seconds_t >= 0)
                    {
                        sec_ned_nust.Text = seconds_t.ToString();
                        seconds_t--;
                    }
                if (seconds_t == -1)
                {
                    if ((seconds_t == -1) && (minute_phy == 0))
                    { serial_text1 = em + cm + pm; serial.Text = serial_text1.ToString(); A_Click_1(sender, e); }
                    else {   minute_phy -= 1; min_ned_nust.Text = minute_phy.ToString(); seconds_t = 59;
                }
                    }
                /* if (minute_phy == -1 && hours_phy != 0)
                 {
                     hours_phy--; minute_phy = 59;
                     hours_ned_nust.Text = hours_phy.ToString();
                 }*/
            }
            //if ((serial_text1 <= em+cm+pm+mm)&& (serial_text1 >= em + cm + pm))
              else
            {
                    if (seconds_t >= 0)
                    {
                        sec_ned_nust.Text = seconds_t.ToString();
                        seconds_t--;
                    }
                    if (seconds_t == -1)
                    {
                    if ((seconds_t == -1) && (minute_math == 0))
                    { Close(); SCORE SR = new SCORE(); SR.Show(); }
                    else
                    {
                        minute_math -= 1; min_ned_nust.Text = minute_math.ToString(); seconds_t = 59;
                    }
                }
                    /*if (minute_math == -1 && hours_math != 0)
                    {
                        hours_math--; minute_eng = 59;
                        hours_ned_nust.Text = hours_math.ToString();
                    }*/
                }
        }

        private void D_Click_1(object sender, EventArgs e)

        {

            option = Convert.ToInt32(serial.Text);
            DATAS.save_option[option] = "D";

            if (Convert.ToInt32(serial.Text) <= em)
            {
                OleDbDataAdapter adp = new OleDbDataAdapter("select * from ENGLISH", con);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                if (ds.Tables[0].Rows[setrandom]["CORRECT"].ToString() == D.Name)
                { DATAS.score += 1; DATAS.english_score += 1; }

                counter++;
                serial_text1 += 1;
                serial.Text = serial_text1.ToString();

                if (Convert.ToInt32(serial.Text) != em + 1)
                {
                    setrandom = DATAS.english_mcqs[counter];
                    question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                    Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                    Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                    Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                    Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();

                }
            }

            if ((Convert.ToInt32(serial.Text) > em) && (Convert.ToInt32(serial.Text) <= em + cm))
            {
                if (count == 1)
                {
                    OleDbDataAdapter adp = new OleDbDataAdapter("select * from CHEMISTRY", con);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    if (ds.Tables[0].Rows[setrandom]["CORRECT"].ToString() == D.Name)
                    { DATAS.score += 1; DATAS.chemistry_score++; }
                    counter++;
                    serial_text1 += 1;
                    serial.Text = serial_text1.ToString();

                    if (Convert.ToInt32(serial.Text) != em + cm + 1)
                    {
                        setrandom = DATAS.chemistry_mcqs[counter];
                        question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                        Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                        Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                        Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                        Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();


                    }
                    if (Convert.ToInt32(serial.Text) == em + cm + 1) { count = 0; }
                }
            }

            if ((Convert.ToInt32(serial.Text) == em + 1) && (count == 0))
            {

                seconds_t = 59;
                min_ned_nust.Text = minute_chem.ToString();
                //  hours_ned_nust.Text = hours_t.ToString();
                sec_ned_nust.Text = seconds_t.ToString();

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

            if ((Convert.ToInt32(serial.Text) > em + cm) && (Convert.ToInt32(serial.Text) <= em + cm + pm))
            {

                if (count == 1)
                {
                    OleDbDataAdapter adp = new OleDbDataAdapter("select * from PHYSICS", con);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    if (ds.Tables[0].Rows[setrandom]["CORRECT"].ToString() == D.Name)
                    { DATAS.score += 1; DATAS.physic_score++; }
                    counter++;
                    serial_text1 += 1;
                    serial.Text = serial_text1.ToString();

                    if (Convert.ToInt32(serial.Text) != em + cm + pm + 1)
                    {
                        setrandom = DATAS.physic_mcqs[counter];
                        question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                        Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                        Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                        Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                        Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();


                    }
                    if (Convert.ToInt32(serial.Text) == em + cm + pm + 1) { count = 0; }

                }
            }
            if ((Convert.ToInt32(serial.Text) == em + cm + 1) && (count == 0))
            {

                seconds_t = 59;
                min_ned_nust.Text = minute_chem.ToString();
                //  hours_ned_nust.Text = hours_t.ToString();
                sec_ned_nust.Text = seconds_t.ToString();

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
            }



            if ((Convert.ToInt32(serial.Text) > em + cm + pm) && (Convert.ToInt32(serial.Text) <= em + cm + pm + mm))
            {
                if (count == 1)
                {
                    OleDbDataAdapter adp = new OleDbDataAdapter("select * from MATH", con);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    if (ds.Tables[0].Rows[setrandom]["CORRECT"].ToString() == D.Name)
                    { DATAS.score += 1; DATAS.math_score++; }
                    counter++;
                    serial_text1 += 1;
                    serial.Text = serial_text1.ToString();
                    if (Convert.ToInt32(serial.Text) == em + cm + pm + mm + 1)
                    { SCORE SR = new SCORE(); Hide(); SR.Show(); /*MessageBox.Show(DATAS.score.ToString());*/ }

                    if ((Convert.ToInt32(serial.Text) != em + cm + pm) && (Convert.ToInt32(serial.Text) != em + cm + pm + mm + 1))
                    {
                        setrandom = DATAS.math_mcqs[counter];
                        question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                        Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                        Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                        Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                        Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();

                    }


                   
                }

                if ((Convert.ToInt32(serial.Text) == em + cm + pm + 1) && (count == 0))
                {

                    seconds_t = 59;
                    min_ned_nust.Text = minute_math.ToString();
                    //  hours_ned_nust.Text = hours_t.ToString();
                    sec_ned_nust.Text = seconds_t.ToString();

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

        private void A_Click_1(object sender, EventArgs e)
        {
            option = Convert.ToInt32(serial.Text);
            DATAS.save_option[option] = "A";

            if (Convert.ToInt32(serial.Text) <= em)
            {
                OleDbDataAdapter adp = new OleDbDataAdapter("select * from ENGLISH", con);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                if (ds.Tables[0].Rows[setrandom]["CORRECT"].ToString() == A.Name)
                { DATAS.score += 1; DATAS.english_score += 1; }

                counter++;
                serial_text1 += 1;
                serial.Text = serial_text1.ToString();

                if (Convert.ToInt32(serial.Text) != em + 1)
                {
                    setrandom = DATAS.english_mcqs[counter];
                    question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                    Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                    Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                    Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                    Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();

                }
            }

            if ((Convert.ToInt32(serial.Text) > em) && (Convert.ToInt32(serial.Text) <= em + cm))
            {
                if (count == 1)
                {
                    OleDbDataAdapter adp = new OleDbDataAdapter("select * from CHEMISTRY", con);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    if (ds.Tables[0].Rows[setrandom]["CORRECT"].ToString() == A.Name)
                    { DATAS.score += 1; DATAS.chemistry_score++; }
                    counter++;
                    serial_text1 += 1;
                    serial.Text = serial_text1.ToString();

                    if (Convert.ToInt32(serial.Text) != em + cm + 1)
                    {
                        setrandom = DATAS.chemistry_mcqs[counter];
                        question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                        Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                        Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                        Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                        Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();


                    }
                    if (Convert.ToInt32(serial.Text) == em + cm + 1) { count = 0; }
                }
            }

            if ((Convert.ToInt32(serial.Text) == em + 1) && (count == 0))
            {

                seconds_t = 59;
                min_ned_nust.Text = minute_chem.ToString();
                //  hours_ned_nust.Text = hours_t.ToString();
                sec_ned_nust.Text = seconds_t.ToString();


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

            if ((Convert.ToInt32(serial.Text) > em + cm) && (Convert.ToInt32(serial.Text) <= em + cm + pm))
            {

                if (count == 1)
                {
                    OleDbDataAdapter adp = new OleDbDataAdapter("select * from PHYSICS", con);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    if (ds.Tables[0].Rows[setrandom]["CORRECT"].ToString() == A.Name)
                    { DATAS.score += 1; DATAS.physic_score++; }
                    counter++;
                    serial_text1 += 1;
                    serial.Text = serial_text1.ToString();

                    if (Convert.ToInt32(serial.Text) != em + cm + pm + 1)
                    {
                        setrandom = DATAS.physic_mcqs[counter];
                        question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                        Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                        Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                        Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                        Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();


                    }
                    if (Convert.ToInt32(serial.Text) == em + cm + pm + 1) { count = 0; }

                }
            }
            if ((Convert.ToInt32(serial.Text) == em + cm + 1) && (count == 0))
            {

                seconds_t = 59;
                min_ned_nust.Text = (minute_phy).ToString();
                //  hours_ned_nust.Text = hours_t.ToString();
                sec_ned_nust.Text = seconds_t.ToString();

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
            }



            if ((Convert.ToInt32(serial.Text) > em + cm + pm) && (Convert.ToInt32(serial.Text) <= em + cm + pm + mm))
            {
                if (count == 1)
                {
                    OleDbDataAdapter adp = new OleDbDataAdapter("select * from MATH", con);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    if (ds.Tables[0].Rows[setrandom]["CORRECT"].ToString() == A.Name)
                    { DATAS.score += 1; DATAS.math_score++; }
                    counter++;
                    serial_text1 += 1;
                    serial.Text = serial_text1.ToString();
                    if (Convert.ToInt32(serial.Text) == em + cm + pm + mm + 1)
                    { SCORE SR = new SCORE(); Hide(); SR.Show(); /*MessageBox.Show(DATAS.score.ToString());*/ }

                    if ((Convert.ToInt32(serial.Text) != em + cm + pm) && (Convert.ToInt32(serial.Text) != em + cm + pm + mm + 1))
                    {
                        setrandom = DATAS.math_mcqs[counter];
                        question.Text = ds.Tables[0].Rows[setrandom]["QUESTION"].ToString();
                        Option_a.Text = ds.Tables[0].Rows[setrandom]["A"].ToString();
                        Option_b.Text = ds.Tables[0].Rows[setrandom]["B"].ToString();
                        Option_c.Text = ds.Tables[0].Rows[setrandom]["C"].ToString();
                        Option_d.Text = ds.Tables[0].Rows[setrandom]["D"].ToString();

                    }



                }

                if ((Convert.ToInt32(serial.Text) == em + cm + pm + 1) && (count == 0))
                {

                    seconds_t = 59;
                    min_ned_nust.Text = minute_math.ToString();
                    //  hours_ned_nust.Text = hours_t.ToString();
                    sec_ned_nust.Text = seconds_t.ToString();

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
