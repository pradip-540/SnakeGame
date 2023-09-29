using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snake_game
{
    public partial class crud : Form
    {

        SqlCommand cmd;
        SqlConnection cn;
        SqlDataReader dr;

        public crud()
        {
            InitializeComponent();
            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\provi\source\repos\snake_game\GameData.mdf;Integrated Security=True");
            cn.Open();
        }

        private void update_Click(object sender, EventArgs e)
        {
            

        }

        private void Display_Click(object sender, EventArgs e)
        {
            try
            {
                // Create a SQL query to retrieve data from the "userdata" table
                string selectQuery = "SELECT * FROM userdata";

                // Create a SqlCommand to execute the query
                SqlCommand selectCommand = new SqlCommand(selectQuery, cn);

                // Create a DataTable to store the retrieved data
                DataTable dataTable = new DataTable();

                // Create a SqlDataAdapter to fill the DataTable
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCommand);

                // Fill the DataTable with data from the database
                dataAdapter.Fill(dataTable);

                // Bind the DataTable to a DataGridView (assuming you have one named dataGridView1)
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., display an error message)
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

    }
}
