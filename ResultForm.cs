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
    public partial class ResultForm : Form
    {
        public int Five { get; set; }
        public int Four { get; set; }
        public int Three { get; set; }
        public int Count { get; set; }
        public int CountOfTaked { get; set; }
        public ResultForm()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ResultForm_Load(object sender, EventArgs e)
        {
            CountValueLabel.Text = $"{CountOfTaked}/{Count}";
            Percentage.Text = $"{Math.Round((double)CountOfTaked / Count*100, 2)}%";

            if (CountOfTaked >= Five) ValueLabel.Text = "5";
            else if (CountOfTaked >= Four) ValueLabel.Text = "4";
            else if (CountOfTaked >= Three) ValueLabel.Text = "3";
            else ValueLabel.Text = "2";
        }
    }
}
