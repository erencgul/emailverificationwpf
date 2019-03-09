using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using System.Data.SqlClient;
using System.Security;
using System.Diagnostics.Eventing.Reader;


namespace LoginPage
{
    public partial class main : MaterialForm
    {
        public main()
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

        public void main_Load(object sender, EventArgs e)
        {

        
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
