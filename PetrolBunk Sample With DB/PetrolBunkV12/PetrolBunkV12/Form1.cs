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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string passcode = textBox2.Text;
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

                //select passcode from users where username='anand'
                comm.CommandText = "select passcode from users where username='"+ username+"'";

                string dbpasscode = (string)comm.ExecuteScalar();

                if (dbpasscode == passcode)
                {
                    MessageBox.Show("Login Successfull");

                    comm.CommandText = "select usertype from users where username='" + username + "'";

                    string usertype = (string)comm.ExecuteScalar();

                    
                        if(usertype=="admin")
                    {
                        Admin frm = new Admin();
                        frm.ShowDialog();
                    }
                        else if (usertype == "operator")
                        {
                            Operator frm = new Operator();
                            frm.ShowDialog();
                        }
                        else if (usertype == "manager")
                        {
                            Manager frm = new Manager();
                            frm.ShowDialog();
                        }
                }
            }



        }
    }
}
