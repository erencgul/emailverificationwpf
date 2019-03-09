using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;

namespace LoginPage
{
    public partial class Form1 : MaterialForm
    {



        public Form1()
        {
            InitializeComponent();
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;

            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Grey800, Primary.Grey800,
                Primary.Red600, Accent.DeepPurple700,
                TextShade.WHITE
            );
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.userName != string.Empty)
            {
                textBox1.Text = Properties.Settings.Default.userName;
                textBox2.Text = Properties.Settings.Default.pass;
            }
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\eren\source\repos\LoginPage\LoginPage\userpass.mdf;Integrated Security=True;Connect Timeout=30");

            SqlDataAdapter sda = new SqlDataAdapter("Select Count (*) From userpass where email='"+textBox1.Text+"'and pass ='"+textBox2.Text+"'",con);

            

            DataTable dt = new DataTable();

            sda.Fill(dt);

            if (dt.Rows[0][0].ToString() == "1")
            {
                //I have Tried = MeesageBox.Show(dt.Rows[0]["name"].ToString());
                MessageBox.Show("Login Success!");
                this.Hide();
                main main = new main();
                main.ShowDialog();
            }
            else
            {
                MessageBox.Show("E-mail or Password is wrong! Please Try Again.");
            }

            if (materialCheckBox1.Checked)
            {
                Properties.Settings.Default.userName = textBox1.Text;
                Properties.Settings.Default.passUser = textBox2.Text;
                Properties.Settings.Default.Save();
            }
            else
            {
            }

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            creatAccount  cA = new creatAccount();
            cA.ShowDialog();
            
        }

        private void materialCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (materialCheckBox2.Checked)
            {
                MessageBox.Show("Auto Login Has Been Activated!");
            }
            else
            {
                MessageBox.Show("Auto Login Has Been Deactivated");
            }
        }

        private void materialCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (materialCheckBox1.Checked)
            {
                MessageBox.Show("Your E-mail and password has been saved!");
            }
            else
            {
                MessageBox.Show("Who are you?");
            }
        }

        private void materialFlatButton3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
    
