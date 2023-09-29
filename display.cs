using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace snake_game
{
    public partial class display : Form
    {
        SqlCommand cmd;
        SqlConnection con;
       

        public display()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\provi\source\repos\snake_game\GameData.mdf;Integrated Security=True");
        }

        private void show_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string qr = "SELECT * FROM userdata";
                cmd = new SqlCommand(qr, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Assuming your DataGridView columns have specific names, replace with the actual column names.
                textBox1.Text = row.Cells["username"].Value.ToString();
                textBox2.Text = row.Cells["password"].Value.ToString();
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string updateQuery = "UPDATE userdata SET username = @username, password = @password WHERE id = @id"; // Modify the query accordingly
                cmd = new SqlCommand(updateQuery, con);
                cmd.Parameters.AddWithValue("@username", textBox1.Text);
                cmd.Parameters.AddWithValue("@password", textBox2.Text);
                cmd.Parameters.AddWithValue("@id", textBox3.Text); // Replace with the actual user ID you want to update
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data updated successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedRowIndex];
                    string userIdToDelete = selectedRow.Cells["id"].Value.ToString(); 
                    con.Open();
                    string deleteQuery = "DELETE FROM userdata WHERE id= @id";
                    cmd = new SqlCommand(deleteQuery, con);
                    cmd.Parameters.AddWithValue("@id", userIdToDelete);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data deleted successfully");
                }
                else
                {
                    MessageBox.Show("Please select a row to delete.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void menu_Click(object sender, EventArgs e)
        {
            Dashboard d = new Dashboard();
            d.ShowDialog();
            this.Close();
        }
    }
}
