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
    public partial class SpecificationsForm : Form
    {
        #region Параметры оценивания
        public string Five { get; set; }
        public string Four { get; set; }
        public string Three { get; set; }
        #endregion

        public SpecificationsForm()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if(spec1.Text != "" &&  spec2.Text != "" && spec3.Text != "")
            {
                Five = spec1.Text;
                Four = spec2.Text;
                Three = spec3.Text;
                this.Close();
            }
        }
    }
}
