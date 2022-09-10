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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = textBox3.Text;
            string newpasscode = textBox4.Text;
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
                //update users set passcode='data' where username='anand'
                comm.CommandText = "update users set passcode='" + newpasscode + "' where username='" + username + "'";

                comm.ExecuteNonQuery();
                MessageBox.Show("Password Reset Successfull");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string username = textBox1.Text;
            string passcode = textBox2.Text;
            string usertype = comboBox1.SelectedItem.ToString();
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
                //insert into users values('anand', 'data123', 'admin')
                comm.CommandText = "insert into users values('"+username+"','"+passcode+"','"+usertype+"')";

                comm.ExecuteNonQuery();
                MessageBox.Show("Inserted Successfully");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string username = textBox5.Text;
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
                //delete from users where username='arun'
                comm.CommandText = "delete from users where username='" + username + "'";
                comm.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully");
            }

        }

        private void button4_Click(object sender, EventArgs e)
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
                if (comboBox2.SelectedItem == "petrol")
                {
                    int price = Convert.ToInt32(textBox6.Text);
                    //update FuelPrice set petrol=101
                    comm.CommandText = "update fuelprice set petrol="+price;
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Updated Successfully");
                }
                else if (comboBox2.SelectedItem == "diesel")
                {
                    int price = Convert.ToInt32(textBox6.Text);
                    //update FuelPrice set diesel=101
                    comm.CommandText = "update fuelprice set diesel=" + price;
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Updated Successfully");
                }
                else if (comboBox2.SelectedItem == "oil")
                {
                    int price = Convert.ToInt32(textBox6.Text);
                    //update FuelPrice set oil=101
                    comm.CommandText = "update fuelprice set oil=" + price;
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Updated Successfully");
                }


            }

        }
    }
}
