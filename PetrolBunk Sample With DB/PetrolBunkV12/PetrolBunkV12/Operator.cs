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
    public partial class Operator : Form
    {
       int petrolprice=0;
       int dieselprice=0;
       int oilprice = 0;


        
        public Operator()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string regno = textBox1.Text;
            int price = 0;
            int wheels = 0;
            int litres = (int)numericUpDown1.Value;
            int ml = (int)numericUpDown2.Value;
            string fueltype = comboBox1.SelectedItem.ToString();
            int total = 0;
            string vehicletype = "";

            if (radioButton1.Checked)
            {
                wheels = 2;
                vehicletype = "Two Wheeler";
                
            }
            else if (radioButton2.Checked)
            {
                wheels = 4;
                vehicletype = "Four Wheeler";
            }


            if (comboBox1.SelectedItem == "petrol")
            {
                price = petrolprice;
            }
            else
            {
                price = dieselprice;
            }

            if (checkBox1.Checked)
            {
                int temp = wheels * 5;
                total += temp;
                listBox1.Items.Add("Cost for filling fuel is : " + temp);

            }

            if (checkBox2.Checked)
            {
                int temp = litres * price;
                total += temp;
                listBox1.Items.Add("Cost for filling fuel is : " + temp);
            }

            if (checkBox3.Checked)
            {
                int temp = ml * oilprice;
                total += temp;
                listBox1.Items.Add("Cost for filling oil is: " + temp);
            }

            listBox1.Items.Add("Total amount is : " + total);

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
                //insert into bills values('tn45t9810', 'petrol', 'Two Wheeler', 2, 5, 20, 551)
                comm.CommandText = "insert into bills values('"+ regno+ "', '"+ fueltype+"', '"+vehicletype+"', "+wheels+","+litres+","+ml+","+ total+",'"+DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss")+"')";

                comm.ExecuteNonQuery();
                MessageBox.Show("Bill Inserted Successfully");
            }







        }

        private void Operator_Load(object sender, EventArgs e)
        {
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

                comm.CommandText = "select petrol from fuelprice";
                petrolprice = int.Parse(comm.ExecuteScalar().ToString());

                comm.CommandText = "select diesel from fuelprice";
                dieselprice = int.Parse(comm.ExecuteScalar().ToString());

                comm.CommandText = "select oil from fuelprice";
                oilprice = int.Parse(comm.ExecuteScalar().ToString());
            }

        }
    }
}
