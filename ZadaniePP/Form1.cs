using System.Data.SqlClient;
using System.Data;

namespace ZadaniePP
{
    public partial class Form1 : Form
    {
        DataBase dataBase = new DataBase();
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox_login.Text;            
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"select Код_сотрудника from Сотрудники_общего where Код_сотрудника = '{login}'";
            SqlCommand command = new SqlCommand(querystring, dataBase.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count == 1)
            {
                MessageBox.Show("You logined", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Form2 menu = new Form2();
                menu.Show();
            }
            else
                MessageBox.Show("Wrong login or password!", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}