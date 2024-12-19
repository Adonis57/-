using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GymManagementSystem
{
    public partial class DeleteMembers : Form
    {
        public DeleteMembers()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\DESKTOP\GymManagementSystem in C#\GymManagementSystem\Gym.mdf;Integrated Security=True;User Instance=True");
                con.Open();

                string str = "DELETE FROM members WHERE m_id = '" + textBox1.Text + "'";

                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Запись об участнике была удалена");

                using (SqlConnection newcon = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\DESKTOP\GymManagementSystem in C#\GymManagementSystem\Gym.mdf;Integrated Security=True;User Instance=True"))
                {
                    string str1 = "SELECT * from members";
                    SqlCommand cmd1 = new SqlCommand(str1, newcon);
                    SqlDataAdapter da = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = new BindingSource(dt, null);

                }
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Пожалуйста введите правильный ID ");
            }
        }

        private void DeleteMembers_Load(object sender, EventArgs e)
        {
  
            this.membersTableAdapter.Fill(this.gymDataSet1.members);
            using (SqlConnection newcon = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\DESKTOP\GymManagementSystem in C#\GymManagementSystem\Gym.mdf;Integrated Security=True;User Instance=True"))
            {
                string str1 = "SELECT * from members";
                SqlCommand cmd1 = new SqlCommand(str1, newcon);
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = new BindingSource(dt, null);

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
