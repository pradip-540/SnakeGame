using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snake_game
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login obj1 = new login();
            obj1.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            login obj1 = new login();
            obj1.Show();
            this.Hide();
        }
    }
}
