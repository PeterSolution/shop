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

namespace sklep
{
    public partial class Form2 : Form
    {
        public Form2(string productname, string description)
        {
            InitializeComponent();
            textBox1.Text = productname;
            textBox2.Text = description;


        }

        private void button1_Click(object sender, EventArgs e)
        {

            /*int buy = int.Parse(textBox2.Text) - 1;
            string query = "UPDATE magazyn set ilosc = buy WHERE nazwa = @productname";
            SqlConnection connection = new SqlConnection("Data Source = desktop-psu2pdc\\sqlexpress; Initial Catalog = produkty; Integrated Security=True");
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Close();
            MessageBox.Show("zakupiono produkt");*/
            string productName = textBox1.Text; // Pobierz nazwę produktu z textBox1
            int buy = int.Parse(textBox2.Text) - 1;

            string query = "UPDATE magazynn SET ilosc = @buy WHERE nazwa = @productName";
            string connectionString = "write your database";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@buy", buy);
                //cmd.Parameters.AddWithValue("@ilosc", buy); // <- niby zły kod w linii int rowsAffected = cmd.ExecuteNonQuery();
                cmd.Parameters.AddWithValue("@productName", productName);

                int rowsAffected = cmd.ExecuteNonQuery();
                textBox2.Text = buy.ToString();
                connection.Close();

            }
        }
    }
}
