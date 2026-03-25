using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_For_Tests
{
    public partial class Warning : Form
    {
        public Warning()
        {
            InitializeComponent();
        }

        private void Error_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
