using System.Data;
using System.Data.SqlClient;
namespace ZadaniePP
{
    public partial class ModalWindow : Form
    {
        DataBase data = new DataBase();
        DataTable table;
        SqlDataAdapter adapter;
        public ModalWindow()
        {
            InitializeComponent();
        }
        private void ModalWindow_Load(object sender, EventArgs e)
        { 
            data.OpenConnection();
            adapter = new SqlDataAdapter($"SELECT * FROM Пользователи where ФИО = '{Form2.fio}'", data.GetConnection());

            table = new DataTable();

            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
    }
}
