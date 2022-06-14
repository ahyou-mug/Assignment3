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

namespace WindowsFormsApp1
{
    public partial class MemberSearch : Form
    {
        public MemberSearch()
        {
            InitializeComponent();
            Populate();
        }

        // Populate dataGrid
        private void Populate()
        {
                // Specify a connection string.
                // Replace <SQL Server> with the SQL Server for your Northwind sample database.
                // Replace "Integrated Security=True" with user login information if necessary.
                string connectionString;
                string selectCommand = "Select * from Customers";
                SqlConnection cnn;
                const string V = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\OP\BIT502\Ass3\v2\WindowsFormsApp1\WindowsFormsApp1\CityGym.mdf;Integrated Security=True;";
                connectionString = V;
                cnn = new SqlConnection(connectionString);
                cnn.Open();
                SqlDataAdapter

                // Create a new data adapter based on the specified query.
                dataAdapter = new SqlDataAdapter(selectCommand, connectionString);

                // Bind the DataGridView to the BindingSource
                // and load the data from the database.
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = customersBindingSource;


                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand.
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                // Populate a new data table and bind it to the BindingSource.
                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                customersBindingSource.DataSource = table;

                // Resize the DataGridView columns to fit the newly loaded content.
                dataGridView1.AutoResizeColumns(
                    DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
        }

        // Search filter
        private void GetData()
        {
            //Build Search String
            bool first = true;
            StringBuilder sb = new StringBuilder("");
            foreach (Control x in SearchIt.Controls.OfType<TextBox>())
            {
                if (!first) sb.Append(", ");
                if (x.Text != "")
                {
                    sb.Append("[" + x.Name + "]=" + x.Text);
                    first = false;
                }
            }
            MessageBox.Show(sb.ToString());

            DataView customersDataView = new DataView(cityGymDataSet.Tables["Customers"]);
            customersDataView.RowFilter = sb.ToString();
            dataGridView1.DataSource = customersDataView;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            new Intro().Show();
        }


        private void Search_Click(object sender, EventArgs e)
        {
            GetData();
        }

        

        private void MemberSearch_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cityGymDataSet1.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.cityGymDataSet1.Customers);

        }
    }
}
