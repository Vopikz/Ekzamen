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
    public partial class Заказы : Form
    {
        SqlConnection con;
        public Заказы()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data source =  DESKTOP-96AAM5R\SQLEXPRESS; initial catalog = СалонКрасоты; integrated security = SSPI");
            con.Open();
            SqlCommand com = new SqlCommand("SELECT [Employee].[LastName]+' '+[Employee].[MiddleName]+' '+[Employee].[FirstName] as [ФИО],[Name] as [Должность],count(Client.LastName" +
                "+ ' ' + Client.MiddleName + ' ' + Client.FirstName) as [Кол-во заказов] FROM[dbo].[Employee] " +
                "left join Position on PositionId = Position.ID " +
                "left join [Order] on [Order].EmployeeID = Employee.ID " +
                "left join Client on Client.ID = [Order].ClientID " +
                "group by [Employee].[LastName]+' '+[Employee].[MiddleName]+' '+[Employee].[FirstName],[Name]", con);
            DataTable table = new DataTable();
            SqlDataReader r = com.ExecuteReader();
            table.Load(r);
            dataGridView1.DataSource = table;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ФормированиеЗаявок заявка = new ФормированиеЗаявок();
            заявка.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Просмотр вид = new Просмотр();
            вид.Show();
            Hide();

        }

        private void Заказы_Load(object sender, EventArgs e)
        {

        }
    }
}
