using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using git;
namespace Library
{
    public partial class AddBook : Form
    {
        public AddBook()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (txtisbn.Text != "" && txtbook.Text != "" && txtauthor.Text != "" && category.Text != "")
            {
                String bname = txtbook.Text;
                String bisbn = txtisbn.Text;
                String bauthor = txtauthor.Text;
                String cat = category.Text;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = IND-4382YD3;database=Library;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "insert into booksl (isbn,bookname,author,category) values ('" + bisbn + "','" + bname + "','" + bauthor + "','" + cat + "')";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Book Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtbook.Clear();
                txtisbn.Clear();
                txtauthor.Clear();
                category.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Fill All Fields.", "Warning!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
