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
    public partial class CHAPTERS : Form
    {

        OleDbConnection con = new OleDbConnection(DATAS.database);
        int status1 = 0, status2 = 0, status3 = 0, status4 = 0;
        int X = 0, X1 = 0, X2 = 0, X3 = 0, X4 = 0;
        public CHAPTERS()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            status1 = 0; status2 = 1; status3 = 0; status4 = 0;
            listBox2.Visible = false;
            listBox3.Visible = true;
            listBox4.Visible = false;
            listBox5.Visible = false;
            listBox1.Items.Clear();

            if (X1 == 0)
            {

                // bunifuButton1.Visible = true;         // button 1
                bunifuGradientPanel3.Visible = true;
                label10.Visible = true;
                label11.Visible = true;
                //  listBox2.Visible = true;
                listBox1.Visible = true;
                // label9.Visible = false;
                //label8.Visible = false;
                //  label7.Visible = false;
                // numericUpDown1.Visible = false;
                // numericUpDown3.Visible = false;
                //  numericUpDown2.Visible = false;
                //label4.Visible = false;
                //label6.Visible = false;
                //  label5.Visible = false;

            }

            int srt;
            string X9 = "1";
            int rowe = 0;
            OleDbDataAdapter ADP = new OleDbDataAdapter("select * from CHEMISTRY ", con);
            DataSet P_CHAP = new DataSet();
            ADP.Fill(P_CHAP);
            while (X9 != "28")
            {
                if (X9 == P_CHAP.Tables[0].Rows[rowe]["INDEXS"].ToString())
                {
                    listBox1.Items.Add(P_CHAP.Tables[0].Rows[rowe]["CHAPTER"].ToString());
                    srt = Convert.ToInt32(X9);
                    srt++;
                    X9 = srt.ToString();

                }

                rowe++;
            }

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton2_Click_1(object sender, EventArgs e)
        {
            status1 = 0; status2 = 0; status3 = 1; status4 = 0;
            listBox2.Visible = false;
            listBox3.Visible = false;
            listBox4.Visible = true;
            listBox5.Visible = false;
            listBox1.Items.Clear();

            if (X1 == 0)
            {

            //    bunifuButton1.Visible = true;    // button 1 
                bunifuGradientPanel3.Visible = true;
                label10.Visible = true;
                label11.Visible = true;
                // listBox2.Visible = true;
                listBox1.Visible = true;
                // label9.Visible = false;
                //label8.Visible = false;
                //label7.Visible = false;
                //numericUpDown1.Visible = false;
                // numericUpDown3.Visible = false;
                // numericUpDown2.Visible = false;
                ///label4.Visible = false;
                //label6.Visible = false;
                //  label5.Visible = false;
            }
            int srt;
            string X9 = "1";
            int rowe = 0;
            OleDbDataAdapter ADP = new OleDbDataAdapter("select * from ENGLISH ", con);
            DataSet P_CHAP = new DataSet();
            ADP.Fill(P_CHAP);
            while (X9 != "9")
            {
                if (X9 == P_CHAP.Tables[0].Rows[rowe]["INDEXS"].ToString())
                {
                    listBox1.Items.Add(P_CHAP.Tables[0].Rows[rowe]["CHAPTER"].ToString());
                    srt = Convert.ToInt32(X9);
                    srt++;
                    X9 = srt.ToString();

                }

                rowe++;
            }

        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {

        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            label10.Visible = true;

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (status1 == 1)
            {
                listBox2.Items.Remove(listBox2.SelectedItem);
            }
            else if (status2 == 1)
            {
                listBox3.Items.Remove(listBox3.SelectedItem);
            }
            else if (status3 == 1)
            {
                listBox4.Items.Remove(listBox4.SelectedItem);
            }
            else if (status4 == 1)
            {

                listBox5.Items.Remove(listBox5.SelectedItem);
            }


        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;   
        }

        private void CHAPTERS_Load(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
        private void bunifuFlatButton6_Click_1(object sender, EventArgs e)
        {
            listBox1.Visible = false;

            listBox2.Visible = false;

            listBox3.Visible = false;

            listBox4.Visible = false;

            listBox5.Visible = false;

            int counter = 0;
            string[] ITEMS = new string[100];
            string[] ITEMS1 = new string[100];
            string[] ITEMS2 = new string[100];
            string[] ITEMS3 = new string[100];

            int i, j, k;
            int temp, temp1, temp2, temp3;
            while (counter < listBox2.Items.Count)
            {
                ITEMS[counter] = listBox2.Items[counter].ToString();
                counter++;

            }
            counter = 0;
            while (counter < listBox3.Items.Count)
            {
                ITEMS1[counter] = listBox3.Items[counter].ToString();
                counter++;

            }
            counter = 0;
            while (counter < listBox4.Items.Count)
            {
                ITEMS2[counter] = listBox4.Items[counter].ToString();
                counter++;

            }
            counter = 0;
            while (counter < listBox5.Items.Count)
            {
                ITEMS3[counter] = listBox5.Items[counter].ToString();
                counter++;

            }
            //sorting
            temp = listBox2.Items.Count;
            for (i = 0; i < temp; i++)
            {
                for (j = i + 1; j < temp;)
                {
                    if (ITEMS[j] == ITEMS[i])
                    {
                        for (k = j; k < temp; k++)
                        {
                            ITEMS[k] = ITEMS[k + 1];
                        }
                        temp--;
                    }
                    else
                    {
                        j++;
                    }
                }
            }
            temp1 = listBox3.Items.Count;
            for (i = 0; i < temp1; i++)
            {
                for (j = i + 1; j < temp1;)
                {
                    if (ITEMS1[j] == ITEMS1[i])
                    {
                        for (k = j; k < temp1; k++)
                        {
                            ITEMS1[k] = ITEMS1[k + 1];
                        }
                        temp1--;
                    }
                    else
                    {
                        j++;
                    }
                }
            }
            temp2 = listBox4.Items.Count;
            for (i = 0; i < temp2; i++)
            {
                for (j = i + 1; j < temp2;)
                {
                    if (ITEMS2[j] == ITEMS2[i])
                    {
                        for (k = j; k < temp2; k++)
                        {
                            ITEMS2[k] = ITEMS2[k + 1];
                        }
                        temp2--;
                    }
                    else
                    {
                        j++;
                    }
                }
            }
            temp3 = listBox5.Items.Count;
            for (i = 0; i < temp3; i++)
            {
                for (j = i + 1; j < temp3;)
                {
                    if (ITEMS3[j] == ITEMS3[i])
                    {
                        for (k = j; k < temp3; k++)
                        {
                            ITEMS3[k] = ITEMS3[k + 1];
                        }
                        temp3--;
                    }
                    else
                    {
                        j++;
                    }
                }
            }
            DATAS.s_c_lenght_p = temp;
            DATAS.s_c_lenght_c = temp1;
            DATAS.s_c_lenght_e = temp2;
            DATAS.s_c_lenght_m = temp3;

            DATAS.s_c_lenght = temp + temp1 + temp2 + temp3;
            for (i = 0; i < temp; i++) { DATAS.p_selected_chapter[i] = ITEMS[i]; }
            for (i = 0; i < temp1; i++) { DATAS.c_selected_chapter[i] = ITEMS1[i]; }
            for (i = 0; i < temp2; i++) { DATAS.e_selected_chapter[i] = ITEMS2[i]; }
            for (i = 0; i < temp3; i++) { DATAS.m_selected_chapter[i] = ITEMS3[i]; }

            i = 0;
            j = 0;
            while (i < temp) { DATAS.selected_chapter[i] = ITEMS[j]; j++; i++; }
            j = 0;
            while (i < temp + temp1) { DATAS.selected_chapter[i] = ITEMS1[j]; i++; j++; }
            j = 0;

            while (i < temp1 + temp + temp2) { DATAS.selected_chapter[i] = ITEMS2[j]; j++; i++; }
            j = 0;

            while (i < temp1 + temp + temp2 + temp3) { DATAS.selected_chapter[i] = ITEMS3[j]; j++; i++; }


            Form3 F = new Form3();
            F.Show();

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            status1 = 1; status2 = 0; status3 = 0; status4 = 0;
            listBox2.Visible = true;
            listBox3.Visible = false;
            listBox4.Visible = false;
            listBox5.Visible = false;

            listBox1.Items.Clear();
            int srt;
            string X9 = "1";
            int rowe = 0;
            OleDbDataAdapter adp = new OleDbDataAdapter("select * from PHYSICS", con);
            DataSet P_CHAP = new DataSet();
            adp.Fill(P_CHAP);

            while (X9 != "21")
            {
                if (X9 == P_CHAP.Tables[0].Rows[rowe]["INDEXS"].ToString())
                {
                    listBox1.Items.Add(P_CHAP.Tables[0].Rows[rowe]["CHAPTER"].ToString());
                    srt = Convert.ToInt32(X9);
                    srt++;
                    X9 = srt.ToString();

                }

                rowe++;
            }
            if (X1 == 0)
            {
                //bunifuButton1.Visible = true; // button 1
                bunifuGradientPanel3.Visible = true;
                label10.Visible = true;
                label11.Visible = true;
                listBox2.Visible = true;
                listBox1.Visible = true;
                //  label9.Visible = false;
                // label8.Visible = false;
                // label7.Visible = false;
                // numericUpDown1.Visible = false;
                //numericUpDown3.Visible = false;
                //  numericUpDown2.Visible = false;
                /// label4.Visible = false;
                ///label6.Visible = false;
                //   label5.Visible = false;
            }

        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            listBox2.Visible = false;
            listBox3.Visible = false;
            listBox4.Visible = false;
            listBox5.Visible = false;
            if (X1 == 0)
            {
                //bunifuButton1.Visible = false; // button 1
                bunifuGradientPanel3.Visible = false;
                listBox1.Visible = false;
             
                label10.Visible = false;
                label11.Visible = false;
                listBox2.Visible = false;
            }

        }
       
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*   MessageBox.Show(listBox1.SelectedIndex.ToString());
               while ((i < listBox2.Items.Count) && listBox2.Items.Count != 0)
               { if (listBox1.Items[listBox1.SelectedIndex].ToString() == listBox2.Items[i].ToString()) { j++; break; } i++; } 

                   if(j==1)
                   { listBox2.Items.Add("    " + listBox1.SelectedItem); }
       */

            if (status1 == 1)
            {
                listBox2.Items.Add(listBox1.SelectedItem);
            }
            else if (status2 == 1)
            {
                listBox3.Items.Add(listBox1.SelectedItem);
            }
           else if (status3 == 1)
            {
                listBox4.Items.Add(listBox1.SelectedItem);
            }
            else if (status4 == 1)
            {
                listBox5.Items.Add(listBox1.SelectedItem);
            }



        }
        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            status1 = 0; status2 = 0; status3 = 0; status4 = 1;
            listBox2.Visible = false;
            listBox3.Visible = false;
            listBox4.Visible = false;
            listBox5.Visible = true;
            listBox1.Items.Clear();
            if (X1 == 0)
            {

                //bunifuButton1.Visible = true; // button 1
                bunifuGradientPanel3.Visible = true;
                label10.Visible = true;
                label11.Visible = true;
             //   listBox2.Visible = true;
                listBox1.Visible = true;
               // label9.Visible = false;
                //label8.Visible = false;
                //label7.Visible = false;
                //numericUpDown1.Visible = false;
               /// numericUpDown3.Visible = false;
               // numericUpDown2.Visible = false;
                //label4.Visible = false;
                //label6.Visible = false;
              //  label5.Visible = false;
            }
            int TEMP;
            int srt;
            string X9 = "1";
            int rowe = 0;
            OleDbDataAdapter ADP = new OleDbDataAdapter("select * from MATH ", con);
            DataSet P_CHAP = new DataSet();
            ADP.Fill(P_CHAP);
            TEMP=P_CHAP.Tables[0].Rows.Count;
            while (X9 != "21"&&rowe!=TEMP)
            {
                if (X9 == P_CHAP.Tables[0].Rows[rowe]["INDEXS"].ToString())
                {
                    listBox1.Items.Add(P_CHAP.Tables[0].Rows[rowe]["CHAPTER"].ToString());
                    srt = Convert.ToInt32(X9);
                    srt+=1;
                    X9 = srt.ToString();

                }

                rowe++;
            }

        }
    }
}
