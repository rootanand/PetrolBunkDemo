using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PetrolBunkV12
{
    public partial class Manager : Form
    {
        public Manager()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
SqlConnection con = new SqlConnection();
            con.ConnectionString = "Server=.\\;database=PetrolBunk2; integrated security=true;";

            try
            {
                con.Open();
                this.Text = "Connected Successfully";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Failed");
            }


            if (con.State == ConnectionState.Open)
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = con;
                //select fueltype, sum(litres) from bills where billdate='20220910' group by fueltype
                comm.CommandText = "select fueltype, sum(litres) from bills where billdate='"+date+"' group by fueltype";

                SqlDataReader dr = comm.ExecuteReader();
                listBox1.Items.Clear();
                while (dr.Read())
                {
                    listBox1.Items.Add(dr.GetString(0) + " : " + dr.GetInt32(1));
                }
                dr.Close();


                comm.CommandText="select Sum(total) from bills where billdate='"+date+"'";
                string total = comm.ExecuteScalar().ToString();

                listBox1.Items.Add("Total :" + total);
            }

        }
    }
}
