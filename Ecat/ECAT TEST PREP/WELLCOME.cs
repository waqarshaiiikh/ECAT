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
    public partial class WELLCOME : Form
    {

        int x = 1; int y=1;
        public WELLCOME()
        {
            InitializeComponent();
            WEL_TIME.Start();
            timer1.Start();
        }

        private void WEL_TIME_Tick(object sender, EventArgs e)
        {
             x++;
             if (x==5) { this.Hide(); PERSONAL_INFO info = new PERSONAL_INFO(); info.Show(); }
        }

        private void WELLCOME_Load(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           

        }
    }
}
