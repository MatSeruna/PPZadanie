using System.Data;
using System.Data.SqlClient;
namespace ZadaniePP
{
    public partial class Form2 : Form
    {
        DataBase data = new DataBase();
        DataTable table;
        SqlDataAdapter adapter;
        public int selectedRow;
        public static string? fio;
        public Form2()
        {
            InitializeComponent();
        }
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            table.Clear();

            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            data.OpenConnection();
            adapter = new SqlDataAdapter("SELECT ФИО FROM Пользователи", data.GetConnection());
            
            table = new DataTable();

            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ModalWindow modal = new ModalWindow();
            if (selectedRow >= 0)
            {
                modal.ShowDialog();
            }
            
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (selectedRow >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];
                fio = row.Cells[0].Value.ToString();
            }
        }
    }
}
