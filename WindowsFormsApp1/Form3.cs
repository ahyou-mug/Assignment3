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
        // Constant variable for connection string
        const string V = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\OP\BIT502\Ass3\v2\WindowsFormsApp1\WindowsFormsApp1\CityGym.mdf;Integrated Security=True;";

        public MemberSearch()
        {
            InitializeComponent();
            Populate();
        }

        //tooltip settings
        // Method to set tool tips
        public void MemberSearch_Load(object sender, System.EventArgs e)
        {
            foreach (var tt in Controls.OfType<ToolTip>())
            {
                tt.AutoPopDelay = 5000;
                tt.InitialDelay = 1000;
                tt.ReshowDelay = 500;
                tt.ShowAlways = true;
                tt.Active = true;
            }
        }

        // Populate dataGrid
        private void Populate()
        {
                // Establish connection, select all results
                string connectionString;
                string selectCommand = "Select * from Customers";
                SqlConnection cnn;
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


                // Create a command builder to generate SQL command
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
            StringBuilder sb = new StringBuilder("SELECT * FROM Customers WHERE ");
            foreach (Control x in SearchIt.Controls.OfType<TextBox>())
            {
                
                if (x.Text != "")
                {
                    if (!first) sb.Append(" AND ");
                    sb.Append("[" + x.Name + "] LIKE " + '\'' + x.Text + '%'+'\'');
                    first = false;
                }
            }
            //MessageBox.Show(sb.ToString());

            // Establish connection.
            string connectionString;
            string selectCommand = sb.ToString();
            SqlConnection cnn;
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


            // Create a command builder to generate SQL command.
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

            // Populate a new data table and bind it to the BindingSource.
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            customersBindingSource.DataSource = table;

            // Resize the DataGridView columns to fit the newly loaded content.
            dataGridView1.AutoResizeColumns(
                DataGridViewAutoSizeColumnsMode.ColumnHeader);
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
        

        private void blankQuery_Click(object sender, EventArgs e)
        {
            Populate();
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
            
        }

        private void toolTip1_Popup_1(object sender, PopupEventArgs e)
        {
            toolTip1.SetToolTip(SearchIt, "Enter the details, or part of the details, to search for in the member database");
        }

        private void toolTip2_Popup(object sender, PopupEventArgs e)
        {
            toolTip2.SetToolTip(Search, "Search the membership database");
        }

        private void toolTip3_Popup(object sender, PopupEventArgs e)
        {
            toolTip3.SetToolTip(Cancel, "Return to the main menu");
        }

        private void toolTip4_Popup(object sender, PopupEventArgs e)
        {
            toolTip4.SetToolTip(blankQuery, "Display all memberships in the database");
        }
    }
}
