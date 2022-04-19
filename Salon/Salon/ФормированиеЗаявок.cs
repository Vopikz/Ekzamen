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
    public partial class ФормированиеЗаявок : Form
    {
        public ФормированиеЗаявок()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data source =  DESKTOP-96AAM5R\SQLEXPRESS; initial catalog = СалонКрасоты; integrated security = SSPI");
            con.Open();
            SqlCommand com = new SqlCommand("SELECT LastName+' '+ MiddleName+' '+FirstName,[Name], Price,[Date],[Accepted]" +
                " from [Order] Left join Client on Client.ID = [Order].ClientID " +
                "left join OrderService on OrderService.OrderID = [Order].ID " +
                "left join[Service] on[Service].ID = OrderService.ServiceID", con);
            DataTable table = new DataTable();
            SqlDataReader r = com.ExecuteReader();
            table.Load(r);
            dataGridView1.DataSource = table;
            con.Close();
        }
        SqlConnection con;
        private void button2_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data source =  DESKTOP-96AAM5R\SQLEXPRESS; initial catalog = СалонКрасоты; integrated security = SSPI");
            con.Open();
            SqlCommand com = new SqlCommand("SELECT [Order].ID, LastName+' '+ MiddleName+' '+FirstName,[Name], Price,[Date]" +
                " from [Order] Left join Client on Client.ID = [Order].ClientID " +
                "left join OrderService on OrderService.OrderID = [Order].ID " +
                "left join[Service] on[Service].ID = OrderService.ServiceID Where LastName+' '+ MiddleName+' '+FirstName = " +
                "'" + данные1 + "' and [Name] = '" + данные2 + "'", con);
            DataTable table = new DataTable();
            SqlDataReader r = com.ExecuteReader();
            table.Load(r);
            dataGridView2.DataSource = table;
            int id = Convert.ToInt32(dataGridView2.Rows[0].Cells[0].Value.ToString());


            SqlCommand com1 = new SqlCommand("Update [Order] set [Accepted] = 'False' Where ID= " + id + "", con);
            com1.ExecuteNonQuery();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data source =  DESKTOP-96AAM5R\SQLEXPRESS; initial catalog = СалонКрасоты; integrated security = SSPI");
            con.Open();
            SqlCommand com = new SqlCommand("SELECT [Order].ID, LastName+' '+ MiddleName+' '+FirstName,[Name], Price,[Date]" +
                " from [Order] Left join Client on Client.ID = [Order].ClientID " +
                "left join OrderService on OrderService.OrderID = [Order].ID " +
                "left join[Service] on[Service].ID = OrderService.ServiceID Where LastName+' '+ MiddleName+' '+FirstName = " +
                "'" + данные1 + "' and [Name] = '" + данные2 + "'", con);
            DataTable table = new DataTable();
            SqlDataReader r = com.ExecuteReader();
            table.Load(r);
            dataGridView2.DataSource = table;
            int id = Convert.ToInt32(dataGridView2.Rows[0].Cells[0].Value.ToString());


            SqlCommand com1 = new SqlCommand("Update [Order] set [Accepted] = 'True' Where ID= " + id + "", con);
            com1.ExecuteNonQuery();
            con.Close();
        }
        string данные1;
        string данные2;
        string данные3;
        string данные4;

        private void button3_Click(object sender, EventArgs e)
        {
            Заказы заказы = new Заказы();
            заказы.Show();
            Hide();
        }
    }
}
