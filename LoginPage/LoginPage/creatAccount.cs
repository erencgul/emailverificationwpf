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
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Configuration;
using System.Net.Mime;
namespace LoginPage
{
    public partial class creatAccount : MaterialForm
    {
        public string randomum;


        public creatAccount()
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


        public class RandomNumbers
        {

            public static readonly int randomNumber;

            static RandomNumbers()
            {
                randomNumber = new Random().Next(1000, 9999);
                
            }

            public void InstanceMethod()
            {
                
            }
        }


        public void creatAccount_Load(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {

            string randomum = (textBox6.Text = RandomNumbers.randomNumber.ToString());





            try
            {
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);

                smtp.EnableSsl = true;
                smtp.Timeout = 10000;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("Youremail", "emailpassword"); //it will send verify code from this email.
                MailMessage msg = new MailMessage();
                msg.To.Add(textBox2.Text);
                msg.From = new MailAddress("youremail");
                msg.Subject = ("Data Saver E-Mail Verification");
                msg.Body = ("Your Verification code is: " + randomum);
                smtp.Send(msg);
                MessageBox.Show("Please check your E-Mail inbox for vaildation code.");
                groupBox2.Visible = true;
                materialFlatButton1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {

            if (textBox5.Text == textBox6.Text)
            {

                using (SqlConnection sqlCon = new SqlConnection(
                    @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\eren\source\repos\LoginPage\LoginPage\userpass.mdf;Integrated Security=True;Connect Timeout=30")
                )
                {

                    sqlCon.Open();
                    SqlCommand con = new SqlCommand("UserAdd", sqlCon);
                    con.CommandType = CommandType.StoredProcedure;
                    con.Parameters.AddWithValue("@email", textBox2.Text.Trim());
                    con.Parameters.AddWithValue("@pass", textBox3.Text.Trim());
                    con.Parameters.AddWithValue("@name", textBox1.Text.Trim());
                    con.ExecuteNonQuery();
                    Clear();

                }
                MessageBox.Show("Your E-Mail Has Been Verified! You Can Sign in your account now. Thanks for joining us!");
                button1.Visible = true;
                materialLabel10.Visible = true;



            }
            else
            {
                MessageBox.Show("Please Check Your Verification Code");
            }

            void Clear()
            {
                textBox1.Text = textBox2.Text = textBox3.Text = "";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)

        {
            
            Form1 login = new Form1();
           login.ShowDialog();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 login2 = new Form1();
            login2.ShowDialog();
        }
    }
}
