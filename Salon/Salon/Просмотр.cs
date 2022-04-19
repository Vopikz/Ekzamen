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

namespace Salon
{
    public partial class Просмотр : Form
    {
        SqlConnection con;
        public Просмотр()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data source =  DESKTOP-96AAM5R\SQLEXPRESS; initial catalog = СалонКрасоты; integrated security = SSPI");
            con.Open();
            SqlCommand com = new SqlCommand("SELECT LastName+' '+ MiddleName+' '+FirstName as [ФИО],[Name] as [Работа], Price as [Цена],[Date] as [Дата]" +
                " from [Order] Left join Client on Client.ID = [Order].ClientID " +
                "left join OrderService on OrderService.OrderID = [Order].ID " +
                "left join[Service] on[Service].ID = OrderService.ServiceID", con);
            DataTable table = new DataTable();
            SqlDataReader r = com.ExecuteReader();
            table.Load(r);
            dataGridView1.DataSource = table;
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Заказы заказы = new Заказы();
            заказы.Show();
            Hide();
        }

        private void Просмотр_Load(object sender, EventArgs e)
        {

        }
    }
}
