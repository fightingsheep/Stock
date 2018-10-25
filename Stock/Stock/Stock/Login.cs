﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Clear();
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //TO-DO: check login username & password
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Stock;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter(@"SELECT *
                FROM[Stock].[dbo].[Login] Where UserName = '"+ textBox1.Text +"' and Password = '"+ textBox2.Text +"'",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if(dt.Rows.Count==1)
            {
                this.Hide();
                //it's a rule to create an object, new is to allocate memory
                // variable main is object reference, and new StockMain() is actually the object
                StockMain main = new StockMain();
                main.Show(); 
            }
            else
            {
                MessageBox.Show("Invalid Username & Password..!", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                button1_Click(sender, e);
            }
        }


    }
}
