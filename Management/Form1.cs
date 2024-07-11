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

namespace Management
{
    public partial class Form1 : Form
    {
        DataTable table=new DataTable("table");
        int index;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            table.Columns.Add("Title", Type.GetType("System.String"));
            table.Columns.Add("Author", Type.GetType("System.String"));
            table.Columns.Add("Year Published", Type.GetType("System.Int32"));
            table.Columns.Add("Genre", Type.GetType("System.String"));
            dvgBooks.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-R7HH38E;Initial Catalog=LMSDB;Integrated Security=True;");
            con.Open();
            table.Rows.Add(txtTitle.Text,txtAuthor.Text,txtYearPublished.Text,txtGenre.Text);
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-R7HH38E;Initial Catalog=LMSDB;Integrated Security=True;");
            con.Open();
            txtTitle.Text = string.Empty;
            txtAuthor.Text=string.Empty;
            txtYearPublished.Text=string.Empty;
            txtGenre.Text=string.Empty;
            con.Close();
        }

        private void dataGridview1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index= e.RowIndex;
            DataGridViewRow row = dvgBooks.Rows[index];
            txtTitle.Text = row.Cells[0].Value.ToString();
            txtAuthor.Text = row.Cells[1].Value.ToString();
            txtYearPublished.Text = row.Cells[2].Value.ToString();
            txtGenre.Text = row.Cells[3].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-R7HH38E;Initial Catalog=LMSDB;Integrated Security=True;");
            con.Open();
            DataGridViewRow newdata=dvgBooks.Rows[index];
            newdata.Cells[0].Value = txtTitle.Text;
            newdata.Cells[1].Value = txtAuthor.Text;
            newdata.Cells[2].Value = txtYearPublished.Text;
            newdata.Cells[3].Value = txtGenre.Text;
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-R7HH38E;Initial Catalog=LMSDB;Integrated Security=True;");
            con.Open();
            index =dvgBooks.CurrentCell.RowIndex;
            dvgBooks.Rows.RemoveAt(index);
            con.Close();
            DataTable dt = new DataTable();
            
            dvgBooks.DataSource = dt;
        }

        
    }
}
