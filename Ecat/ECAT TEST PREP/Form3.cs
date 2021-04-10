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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        int i = 0 ;
        private void Form3_Load(object sender, EventArgs e)
        {
            while (i < DATAS.s_c_lenght)
            {
                listBox1.Items.Add(DATAS.selected_chapter[i]);
                i++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (0 != listBox1.Items.Count)
            {
                Close();
                CHAPTERS c = new CHAPTERS();
                ECAT_3_ E = new ECAT_3_();
                c.Close();
                E.Show();
            }
            else
            {
                MessageBox.Show("YOU HAVEN'T SELECT ANY CHAPTER");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
