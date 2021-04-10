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
   
    public partial class ECAT_3_ : Form
    {
        OleDbConnection con = new OleDbConnection(DATAS.database);
        int chapter_coun = 0;//chapter counter
        public ECAT_3_()
        {
            InitializeComponent();
            if (DATAS.s_c_lenght_p>0) { button1.Visible = true; }
            if (DATAS.s_c_lenght_c > 0) { button3.Visible = true; }
            if (DATAS.s_c_lenght_e > 0) { button2.Visible = true; }
            if (DATAS.s_c_lenght_m > 0) { button4.Visible = true; }
            if      (DATAS.s_c_lenght_p>0)
            {
                SUBJECT_NAME.Text = "PHYSICS";
               
                OleDbDataAdapter ADP = new OleDbDataAdapter("select * from PHYSICS WHERE CHAPTER ='" + DATAS.p_selected_chapter[0] + "' ", con);
                DataSet DS = new DataSet();
                ADP.Fill(DS);
                CHAPTER.Text = DATAS.p_selected_chapter[0];
                question.Text = DS.Tables[0].Rows[0]["QUESTION"].ToString();
                Option_a.Text = DS.Tables[0].Rows[0]["A"].ToString();
                Option_b.Text = DS.Tables[0].Rows[0]["B"].ToString();
                Option_c.Text = DS.Tables[0].Rows[0]["C"].ToString();
                Option_d.Text = DS.Tables[0].Rows[0]["D"].ToString();

            }

            else if (DATAS.s_c_lenght_c > 0)
            {
                
                SUBJECT_NAME.Text = "CHEMISTRY";
                OleDbDataAdapter ADP = new OleDbDataAdapter("select * from CHEMISTRY WHERE CHAPTER ='" + DATAS.c_selected_chapter[0] + "' ", con);
                DataSet DS = new DataSet();
                ADP.Fill(DS);
                CHAPTER.Text = DATAS.c_selected_chapter[0];
                question.Text = DS.Tables[0].Rows[0]["QUESTION"].ToString();
                Option_a.Text = DS.Tables[0].Rows[0]["A"].ToString();
                Option_b.Text = DS.Tables[0].Rows[0]["B"].ToString();
                Option_c.Text = DS.Tables[0].Rows[0]["C"].ToString();
                Option_d.Text = DS.Tables[0].Rows[0]["D"].ToString();
            }

            else if (DATAS.s_c_lenght_e > 0)
            {

                SUBJECT_NAME.Text = "ENGLISH";

                OleDbDataAdapter ADP = new OleDbDataAdapter("select * from ENGLISH WHERE CHAPTER ='" + DATAS.e_selected_chapter[0] + "' ", con);
                DataSet DS = new DataSet();
                ADP.Fill(DS);
                CHAPTER.Text = DATAS.p_selected_chapter[0];
                question.Text = DS.Tables[0].Rows[0]["QUESTION"].ToString();
                Option_a.Text = DS.Tables[0].Rows[0]["A"].ToString();
                Option_b.Text = DS.Tables[0].Rows[0]["B"].ToString();
                Option_c.Text = DS.Tables[0].Rows[0]["C"].ToString();
                Option_d.Text = DS.Tables[0].Rows[0]["D"].ToString();
            }

            else if (DATAS.s_c_lenght_m > 0)
            {
                
                SUBJECT_NAME.Text = "MATH";
                OleDbDataAdapter ADP = new OleDbDataAdapter("select * from MATH WHERE CHAPTER ='" + DATAS.m_selected_chapter[0] + "' ", con);
                DataSet DS = new DataSet();
                ADP.Fill(DS);
                CHAPTER.Text = DATAS.m_selected_chapter[0];
                question.Text = DS.Tables[0].Rows[0]["QUESTION"].ToString();
                Option_a.Text = DS.Tables[0].Rows[0]["A"].ToString();
                Option_b.Text = DS.Tables[0].Rows[0]["B"].ToString();
                Option_c.Text = DS.Tables[0].Rows[0]["C"].ToString();
                Option_d.Text = DS.Tables[0].Rows[0]["D"].ToString();
            }
        }
        public void common_function()
        {
            A.Checked = false;
            B.Checked = false;
            C.Checked = false;
            D.Checked = false;
            RIGHT_A.Visible = false;
            RIGHT_B.Visible = false;
            RIGHT_C.Visible = false;
            RIGHT_D.Visible = false;
        }
        private void question_Click(object sender, EventArgs e)
        {

        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        int TEMP;
        int temp_next;//temp for next button
        private void Next_button_Click(object sender, EventArgs e)
        {

         
            common_function(); checked_box_true();

            if (serial.Text == "1") { back_button.Visible = true; }
            
            TEMP = Convert.ToInt32(serial.Text);
            TEMP++;// FOR NEXT SERIAL
            serial.Text = TEMP.ToString();
            OleDbDataAdapter ADP;
            DataSet DS = new DataSet();
            if (SUBJECT_NAME.Text == "PHYSICS")
            {

                ADP = new OleDbDataAdapter("select * from PHYSICS where CHAPTER='" + CHAPTER.Text + "'", con);
                ADP.Fill(DS);
                if (TEMP== DS.Tables[0].Rows.Count) { Next_button.Visible = false; }
               
            }
            else if (SUBJECT_NAME.Text == "MATH")
            {

                 ADP = new OleDbDataAdapter("select * from MATH where CHAPTER='" + CHAPTER.Text + "'", con);
                ADP.Fill(DS);
                if (TEMP == DS.Tables[0].Rows.Count) { Next_button.Visible = false; }
                
            }
            else if (SUBJECT_NAME.Text == "CHEMISTRY")
            {

                 ADP = new OleDbDataAdapter("select * from CHEMISTRY where CHAPTER='" + CHAPTER.Text + "'", con);
                ADP.Fill(DS);
                if (TEMP == DS.Tables[0].Rows.Count) { Next_button.Visible = false; }
                
            }
            else if (SUBJECT_NAME.Text == "ENGLISH")
            {

                 ADP = new OleDbDataAdapter("select * from ENGLISH where CHAPTER='" + CHAPTER.Text + "'", con);
                ADP.Fill(DS);
                if (TEMP == DS.Tables[0].Rows.Count) { Next_button.Visible = false; }
                
            }
            TEMP -=1; //FOR INDEX DS ROWS
            question.Text = DS.Tables[0].Rows[TEMP]["QUESTION"].ToString();
            Option_a.Text = DS.Tables[0].Rows[TEMP]["A"].ToString();
            Option_b.Text = DS.Tables[0].Rows[TEMP]["B"].ToString();
            Option_c.Text = DS.Tables[0].Rows[TEMP]["C"].ToString();
            Option_d.Text = DS.Tables[0].Rows[TEMP]["D"].ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            back_button.Visible = false;
            checked_box_true(); common_function();

            if ("ENGLISH" == SUBJECT_NAME.Text)
            {

                chapter_coun++;
                if (chapter_coun == DATAS.s_c_lenght_e - 1)
                {
                    button5.Visible = false;
                    button6.Visible = true;
                    Next_button.Visible = true;
                }
                else { button6.Visible = true; }
                CHAPTER.Text = DATAS.e_selected_chapter[chapter_coun];

                serial.Text = "0";
                Next_button.PerformClick();
            }
            else if ("PHYSICS" == SUBJECT_NAME.Text)
            {

                chapter_coun++;
                if (chapter_coun == DATAS.s_c_lenght_p - 1)
                {
                    button5.Visible = false; button6.Visible = true;
                    Next_button.Visible = true;
                }
                else { button6.Visible = true; }

                CHAPTER.Text = DATAS.p_selected_chapter[chapter_coun];
                serial.Text = "0";
                Next_button.PerformClick();
            }

            else if("CHEMISTRY" == SUBJECT_NAME.Text)
            {

                chapter_coun++;
                if (chapter_coun == DATAS.s_c_lenght_c - 1)
                {
                    button5.Visible = false; button6.Visible = true;
                    Next_button.Visible = true;
                }
                else { button6.Visible = true; }
                CHAPTER.Text = DATAS.c_selected_chapter[chapter_coun];

                serial.Text = "0";
                Next_button.PerformClick();
            }

            else if("MATH" == SUBJECT_NAME.Text)
            {

                chapter_coun++;
                if (chapter_coun == DATAS.s_c_lenght_m - 1)
                {
                    button5.Visible = false; button6.Visible = true;
                    Next_button.Visible = true;
                }
                else { button6.Visible = true; }
                CHAPTER.Text = DATAS.m_selected_chapter[chapter_coun];

                serial.Text = "0";
                Next_button.PerformClick();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            back_button.Visible = false;
            common_function(); checked_box_true();
            button6.Visible = false;
            serial.Text = "1";
            button5.Visible = true;
            chapter_coun = 0;
            SUBJECT_NAME.Text ="PHYSICS";
            Next_button.Visible = true;
            CHAPTER.Text = DATAS.p_selected_chapter[0];
            DataSet DS = new DataSet();
            OleDbDataAdapter ADP = new OleDbDataAdapter("select * from PHYSICS where CHAPTER='" + CHAPTER.Text + "'", con);
            ADP.Fill(DS);
            question.Text = DS.Tables[0].Rows[0]["QUESTION"].ToString();
            Option_a.Text = DS.Tables[0].Rows[0]["A"].ToString();
            Option_b.Text = DS.Tables[0].Rows[0]["B"].ToString();
            Option_c.Text = DS.Tables[0].Rows[0]["C"].ToString();
            Option_d.Text = DS.Tables[0].Rows[0]["D"].ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            back_button.Visible = false;
            common_function(); checked_box_true();
            button6.Visible = false;

            serial.Text = "1";
            button5.Visible = true;
            chapter_coun = 0;
            SUBJECT_NAME.Text = "CHEMISTRY";
            Next_button.Visible = true;
            CHAPTER.Text = DATAS.c_selected_chapter[0];
            DataSet DS = new DataSet();
            OleDbDataAdapter ADP = new OleDbDataAdapter("select * from CHEMISTRY where CHAPTER='" + CHAPTER.Text + "'", con);
            ADP.Fill(DS);
            question.Text = DS.Tables[0].Rows[0]["QUESTION"].ToString();
            Option_a.Text = DS.Tables[0].Rows[0]["A"].ToString();
            Option_b.Text = DS.Tables[0].Rows[0]["B"].ToString();
            Option_c.Text = DS.Tables[0].Rows[0]["C"].ToString();
            Option_d.Text = DS.Tables[0].Rows[0]["D"].ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            back_button.Visible = false;
            common_function(); checked_box_true();
            button6.Visible = false;

            serial.Text = "1";
            button5.Visible = true;
            chapter_coun = 0;
            SUBJECT_NAME.Text = "ENGLISH";
            Next_button.Visible = true;
            CHAPTER.Text = DATAS.e_selected_chapter[0];
            DataSet DS = new DataSet();
            OleDbDataAdapter ADP = new OleDbDataAdapter("select * from ENGLISH where CHAPTER='" + CHAPTER.Text + "'", con);
            ADP.Fill(DS);
            question.Text = DS.Tables[0].Rows[0]["QUESTION"].ToString();
            Option_a.Text = DS.Tables[0].Rows[0]["A"].ToString();
            Option_b.Text = DS.Tables[0].Rows[0]["B"].ToString();
            Option_c.Text = DS.Tables[0].Rows[0]["C"].ToString();
            Option_d.Text = DS.Tables[0].Rows[0]["D"].ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {

            back_button.Visible = false;
            common_function(); checked_box_true();
            button6.Visible = false;

            serial.Text = "1";
            button5.Visible = true;
            chapter_coun = 0;
            SUBJECT_NAME.Text = "MATH";
            Next_button.Visible = true;
            CHAPTER.Text = DATAS.m_selected_chapter[0];
            DataSet DS = new DataSet();
            OleDbDataAdapter ADP = new OleDbDataAdapter("select * from MATH where CHAPTER='" + CHAPTER.Text + "'", con);
            ADP.Fill(DS);
            question.Text = DS.Tables[0].Rows[0]["QUESTION"].ToString();
            Option_a.Text = DS.Tables[0].Rows[0]["A"].ToString();
            Option_b.Text = DS.Tables[0].Rows[0]["B"].ToString();
            Option_c.Text = DS.Tables[0].Rows[0]["C"].ToString();
            Option_d.Text = DS.Tables[0].Rows[0]["D"].ToString();

        }

        private void back_button_Click(object sender, EventArgs e)
        {

            common_function(); checked_box_true();
            TEMP = Convert.ToInt32(serial.Text);
            TEMP--;// FOR NEXT SERIAL
            serial.Text = TEMP.ToString();
            OleDbDataAdapter ADP;
            DataSet DS = new DataSet();
            
            if (SUBJECT_NAME.Text == "PHYSICS")
            {

                ADP = new OleDbDataAdapter("select * from PHYSICS where CHAPTER='" + CHAPTER.Text + "'", con);
                ADP.Fill(DS);
                if (TEMP == 1) { back_button.Visible = false; }
                if (TEMP == DS.Tables[0].Rows.Count - 1) { Next_button.Visible = true; }

            }
            else if (SUBJECT_NAME.Text == "MATH")
            {

                ADP = new OleDbDataAdapter("select * from MATH where CHAPTER='" + CHAPTER.Text + "'", con);
                ADP.Fill(DS);
                if (TEMP == 1) { back_button.Visible = false; }
                if (TEMP == DS.Tables[0].Rows.Count - 1) { Next_button.Visible = true; }

            }
            else if (SUBJECT_NAME.Text == "CHEMISTRY")
            {

                ADP = new OleDbDataAdapter("select * from CHEMISTRY where CHAPTER='" + CHAPTER.Text + "'", con);
                ADP.Fill(DS);
                if (TEMP == 1) { back_button.Visible = false; }
                if (TEMP == DS.Tables[0].Rows.Count - 1) { Next_button.Visible = true; }

            }
            else if (SUBJECT_NAME.Text == "ENGLISH")
            {

                ADP = new OleDbDataAdapter("select * from ENGLISH where CHAPTER='" + CHAPTER.Text + "'", con);
                ADP.Fill(DS);
                if (TEMP == 1) { back_button.Visible = false; }

                if (TEMP == DS.Tables[0].Rows.Count-1) { Next_button.Visible = true; }

            }
            TEMP -= 1; //FOR INDEX DS ROWS
            question.Text = DS.Tables[0].Rows[TEMP]["QUESTION"].ToString();
            Option_a.Text = DS.Tables[0].Rows[TEMP]["A"].ToString();
            Option_b.Text = DS.Tables[0].Rows[TEMP]["B"].ToString();
            Option_c.Text = DS.Tables[0].Rows[TEMP]["C"].ToString();
            Option_d.Text = DS.Tables[0].Rows[TEMP]["D"].ToString();

        }

        private void button6_Click(object sender, EventArgs e)
        {

            back_button.Visible = false;
            checked_box_true(); common_function();

            if ("ENGLISH" == SUBJECT_NAME.Text)
            {

                chapter_coun--;
                if (chapter_coun == 0)
                {
                    button6.Visible = false;
                    button5.Visible = true;
                    Next_button.Visible = true;
                }
                else { button5.Visible = true; }

                CHAPTER.Text = DATAS.e_selected_chapter[chapter_coun];

                serial.Text = "0";
                Next_button.PerformClick();
            }
            else if ("PHYSICS" == SUBJECT_NAME.Text)
            {

                chapter_coun--;
                if (chapter_coun == 0)
                {
                    button6.Visible = false; button5.Visible = true;
                    Next_button.Visible = true;
                }
                else { button5.Visible = true; }

                CHAPTER.Text = DATAS.p_selected_chapter[chapter_coun];
                serial.Text = "0";
                Next_button.PerformClick();
            }

            else if ("CHEMISTRY" == SUBJECT_NAME.Text)
            {

                chapter_coun--;
                if (chapter_coun == 0)
                {
                    button6.Visible = false; button5.Visible = true;
                    Next_button.Visible = true;
                }
                else { button5.Visible = true; }
                CHAPTER.Text = DATAS.c_selected_chapter[chapter_coun];

                serial.Text = "0";
                Next_button.PerformClick();
            }

            else if ("MATH" == SUBJECT_NAME.Text)
            {

                chapter_coun--;
                if (chapter_coun == 0)
                {
                    button6.Visible = false; button5.Visible = true;
                    Next_button.Visible = true;
                }
                else { button5.Visible = true; }
                CHAPTER.Text = DATAS.m_selected_chapter[chapter_coun];

                serial.Text = "0";
                Next_button.PerformClick();
            }
        }
        public void checked_box_true()
        {
            A.Visible = true;
            B.Visible = true;
            C.Visible = true;
            D.Visible = true;

            A.Checked = false;
            B.Checked = false;
            C.Checked = false;
            D.Checked = false;
        }
        public void RIGHT_PIC_BOX() {
            RIGHT_A.Visible = false;
            RIGHT_B.Visible = false;
            RIGHT_C.Visible = false;
            RIGHT_D.Visible = false;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Close();
            CHAPTERS ed = new CHAPTERS(); ed.Hide();
            TEST__PATTERN ts = new TEST__PATTERN();
            ts.Show();
        }

        private void A_CheckedChanged(object sender, EventArgs e)
        {
            RIGHT_PIC_BOX();

            B.Visible = false;
            A.Visible = true;
            C.Visible = false;
            D.Visible = false;
            OleDbDataAdapter ADP;
            DataSet DS = new DataSet();

            if (SUBJECT_NAME.Text == "PHYSICS")
            {

                ADP = new OleDbDataAdapter("select * from PHYSICS where CHAPTER='" + CHAPTER.Text + "'AND QUESTION='"+question.Text+"'", con);
                ADP.Fill(DS);
                if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "A")
                { RIGHT_A.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "B")
                { RIGHT_B.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "C")
                { RIGHT_C.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "D")
                { RIGHT_D.Visible = true; }
            }
            else if (SUBJECT_NAME.Text == "MATH")
            {

                ADP = new OleDbDataAdapter("select * from MATH where CHAPTER='" + CHAPTER.Text + "'AND QUESTION='" + question.Text + "'", con);
                ADP.Fill(DS);
                if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "A")
                { RIGHT_A.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "B")
                { RIGHT_B.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "C")
                { RIGHT_C.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "D")
                { RIGHT_D.Visible = true; }

            }
            else if (SUBJECT_NAME.Text == "CHEMISTRY")
            {

                ADP = new OleDbDataAdapter("select * from CHEMISTRY where CHAPTER='" + CHAPTER.Text + "'AND QUESTION='" + question.Text + "'", con);
                ADP.Fill(DS);
                if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "A")
                { RIGHT_A.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "B")
                { RIGHT_B.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "C")
                { RIGHT_C.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "D")
                { RIGHT_D.Visible = true; }

            }
            else if (SUBJECT_NAME.Text == "ENGLISH")
            {

                ADP = new OleDbDataAdapter("select * from ENGLISH where CHAPTER='" + CHAPTER.Text + "'AND QUESTION='" + question.Text + "'", con);
                ADP.Fill(DS);
                if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "A")
                { RIGHT_A.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "B")
                { RIGHT_B.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "C")
                { RIGHT_C.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "D")
                { RIGHT_D.Visible = true; }

            }

        }

        private void B_CheckedChanged(object sender, EventArgs e)
        {

            RIGHT_PIC_BOX();
            B.Visible = true;
            A.Visible = false;
            C.Visible = false;
            D.Visible = false;
            OleDbDataAdapter ADP;
            DataSet DS = new DataSet();

            if (SUBJECT_NAME.Text == "PHYSICS")
            {

                ADP = new OleDbDataAdapter("select * from PHYSICS where CHAPTER='" + CHAPTER.Text + "'AND QUESTION='" + question.Text + "'", con);
                ADP.Fill(DS);
                if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "A")
                { RIGHT_A.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "B")
                { RIGHT_B.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "C")
                { RIGHT_C.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "D")
                { RIGHT_D.Visible = true; }
            }
            else if (SUBJECT_NAME.Text == "MATH")
            {

                ADP = new OleDbDataAdapter("select * from MATH where CHAPTER='" + CHAPTER.Text + "'AND QUESTION='" + question.Text + "'", con);
                ADP.Fill(DS);
                if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "A")
                { RIGHT_A.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "B")
                { RIGHT_B.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "C")
                { RIGHT_C.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "D")
                { RIGHT_D.Visible = true; }

            }
            else if (SUBJECT_NAME.Text == "CHEMISTRY")
            {

                ADP = new OleDbDataAdapter("select * from CHEMISTRY where CHAPTER='" + CHAPTER.Text + "'AND QUESTION='" + question.Text + "'", con);
                ADP.Fill(DS);
                if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "A")
                { RIGHT_A.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "B")
                { RIGHT_B.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "C")
                { RIGHT_C.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "D")
                { RIGHT_D.Visible = true; }

            }
            else if (SUBJECT_NAME.Text == "ENGLISH")
            {

                ADP = new OleDbDataAdapter("select * from ENGLISH where CHAPTER='" + CHAPTER.Text + "'AND QUESTION='" + question.Text + "'", con);
                ADP.Fill(DS);
                if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "A")
                { RIGHT_A.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "B")
                { RIGHT_B.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "C")
                { RIGHT_C.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "D")
                { RIGHT_D.Visible = true; }

            }

        }

        private void C_CheckedChanged(object sender, EventArgs e)
        {

            RIGHT_PIC_BOX();
            B.Visible = false;
            C.Visible = true;
            A.Visible = false;
            D.Visible = false;
            OleDbDataAdapter ADP;
            DataSet DS = new DataSet();

            if (SUBJECT_NAME.Text == "PHYSICS")
            {

                ADP = new OleDbDataAdapter("select * from PHYSICS where CHAPTER='" + CHAPTER.Text + "'AND QUESTION='" + question.Text + "'", con);
                ADP.Fill(DS);
                if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "A")
                { RIGHT_A.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "B")
                { RIGHT_B.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "C")
                { RIGHT_C.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "D")
                { RIGHT_D.Visible = true; }
            }
            else if (SUBJECT_NAME.Text == "MATH")
            {

                ADP = new OleDbDataAdapter("select * from MATH where CHAPTER='" + CHAPTER.Text + "'AND QUESTION='" + question.Text + "'", con);
                ADP.Fill(DS);
                if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "A")
                { RIGHT_A.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "B")
                { RIGHT_B.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "C")
                { RIGHT_C.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "D")
                { RIGHT_D.Visible = true; }

            }
            else if (SUBJECT_NAME.Text == "CHEMISTRY")
            {

                ADP = new OleDbDataAdapter("select * from CHEMISTRY where CHAPTER='" + CHAPTER.Text + "'AND QUESTION='" + question.Text + "'", con);
                ADP.Fill(DS);
                if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "A")
                { RIGHT_A.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "B")
                { RIGHT_B.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "C")
                { RIGHT_C.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "D")
                { RIGHT_D.Visible = true; }

            }
            else if (SUBJECT_NAME.Text == "ENGLISH")
            {

                ADP = new OleDbDataAdapter("select * from ENGLISH where CHAPTER='" + CHAPTER.Text + "'AND QUESTION='" + question.Text + "'", con);
                ADP.Fill(DS);
                if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "A")
                { RIGHT_A.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "B")
                { RIGHT_B.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "C")
                { RIGHT_C.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "D")
                { RIGHT_D.Visible = true; }

            }

        }

        private void D_CheckedChanged(object sender, EventArgs e)
        {

            RIGHT_PIC_BOX();
            B.Visible = false;
            D.Visible = true;
            C.Visible = false;
            A.Visible = false;
            OleDbDataAdapter ADP;
            DataSet DS = new DataSet();

            if (SUBJECT_NAME.Text == "PHYSICS")
            {

                ADP = new OleDbDataAdapter("select * from PHYSICS where CHAPTER='" + CHAPTER.Text + "'AND QUESTION='" + question.Text + "'", con);
                ADP.Fill(DS);
                if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "A")
                { RIGHT_A.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "B")
                { RIGHT_B.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "C")
                { RIGHT_C.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "D")
                { RIGHT_D.Visible = true; }
            }
            else if (SUBJECT_NAME.Text == "MATH")
            {

                ADP = new OleDbDataAdapter("select * from MATH where CHAPTER='" + CHAPTER.Text + "'AND QUESTION='" + question.Text + "'", con);
                ADP.Fill(DS);
                if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "A")
                { RIGHT_A.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "B")
                { RIGHT_B.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "C")
                { RIGHT_C.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "D")
                { RIGHT_D.Visible = true; }

            }
            else if (SUBJECT_NAME.Text == "CHEMISTRY")
            {

                ADP = new OleDbDataAdapter("select * from CHEMISTRY where CHAPTER='" + CHAPTER.Text + "'AND QUESTION='" + question.Text + "'", con);
                ADP.Fill(DS);
                if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "A")
                { RIGHT_A.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "B")
                { RIGHT_B.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "C")
                { RIGHT_C.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "D")
                { RIGHT_D.Visible = true; }

            }
            else if (SUBJECT_NAME.Text == "ENGLISH")
            {

                ADP = new OleDbDataAdapter("select * from ENGLISH where CHAPTER='" + CHAPTER.Text + "'AND QUESTION='" + question.Text + "'", con);
                ADP.Fill(DS);
                if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "A")
                { RIGHT_A.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "B")
                { RIGHT_B.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "C")
                { RIGHT_C.Visible = true; }

                else if (DS.Tables[0].Rows[0]["CORRECT"].ToString() == "D")
                { RIGHT_D.Visible = true; }

            }

        }

        private void label15_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label16_Click(object sender, EventArgs e)
        {

            this.Visible = false;
        }
    }
}
