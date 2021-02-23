using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace dentis
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                txtPassword.Focus();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                loginb.PerformClick();
        }

        private void loginb_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(txtUsername.Text == string.Empty))
                {
                    if (!(txtPassword.Text == string.Empty))
                    {
                        int count = 0;
                        string AdName = txtUsername.Text;
                        string AdPassword = txtPassword.Text;
                        string strSQL = "SELECT * FROM Users WHERE Name = '" + AdName + "' AND Password = '" + AdPassword + "'";
                        string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\lib.mdb";
                        OleDbConnection connection = new OleDbConnection(connectionString);
                        OleDbCommand command = new OleDbCommand(strSQL, connection);  
                        connection.Open();  
                        OleDbDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            count = count + 1;
                        }
                        if (count == 1)
                        {
                            this.Hide();
                            main f2 = new main(); 
                            f2.ShowDialog();

                        }
                        else if (count > 1)
                        {
                            MessageBox.Show("Duplicate username and password", "login page");
                        }
                        else
                        {
                            MessageBox.Show(" username and password incorrect", "login page");
                        }
                    }
                    else
                    {
                        MessageBox.Show(" password empty", "login page");
                    }
                }
                else
                {
                    MessageBox.Show(" username empty", "login page");
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }
    }
}
