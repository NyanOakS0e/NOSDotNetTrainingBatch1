using System.Data;
using System.Data.SqlTypes;
using System.Drawing.Text;
using Microsoft.Data.SqlClient;

namespace NOSDoTNetWinFormApp
{
    public partial class LoginForm : Form
    {
        private readonly SqlService _sqlService;
        public LoginForm()
        {
            InitializeComponent();

            _sqlService = new SqlService();

        }

        private void but_cancel_Click(object sender, EventArgs e)
        {
            
            txt_username.Clear();
            txt_password.Clear();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
           

            string username = txt_username.Text.Trim();
            string password = txt_password.Text.Trim();

            string query = "SELECT * FROM dbo.Users WHERE Name = @username AND Email = @password";
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@username", username),
                new SqlParameter("@password", password)
            };
            DataTable data =  _sqlService.Query(query, parameters);

            if (data.Rows.Count <= 0)
            {
                MessageBox.Show("User not found");
            }
            else
            {
                MessageBox.Show(@$"Welcome {username} and {password}");

            }



        }
    }
}
