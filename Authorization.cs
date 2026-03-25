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
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void StudentButton_Click(object sender, EventArgs e)
        {
            TakeTestForm takeTestForm = new TakeTestForm();
            takeTestForm.ShowDialog();
            this.Close();
        }

        private void TeacherButton_Click(object sender, EventArgs e)
        {
            CreateTestForm testForm = new CreateTestForm();
            this.Visible = false;
            testForm.ShowDialog();
            this.Visible = true;
        }
    }
}
