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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Checkform bool variable
        bool complete = false;

        // Dictionary for Customer Data
        Dictionary<string, dynamic> Customer = new Dictionary<string, dynamic>()
        {
            {"firstName",""},
            {"lastName",""},
            {"address",""},
            {"mobileNumber",""},
            {"emContact",""},
            {"emRelationship",""},
            {"emPhone",""},
            {"membershipType",""},
            {"memDuration",""},
            {"payMethod",""},
            {"frequency",""},
            {"extra247",0},
            {"extraPT",0},
            {"extraDT",0},
            {"extraVT",0},
            {"payAmount",null},
            {"basePrice",0}
        };


        // Dictionary for Price Data
        Dictionary<string, int> Price = new Dictionary<string, int>()
        {
            {"Basic ($10/pw)",10},
            {"Regular ($15/pw)",15 },
            {"Premium ($20/pw)",20 },
            {"duration12",-2 },
            {"duration24",-5 },
            {"extras247",1 },
            {"extrasPT",20 },
            {"extrasDT",20 },
            {"extrasVT",2 },
            {"paymentDD",1 }, // subtract total - (total/100 * 1)
        };

        // Dictionary for duration data
        Dictionary<string, int> Duration = new Dictionary<string, int>()
        {
            {"duration3", 12 },
            {"duration6", 26 },
            {"duration12",52 },
            {"duration24",104 }
        };


        // Method to return customer strings
        public void textReturn()
        {
            foreach (var x in Controls.OfType<TextBox>())
                {
                    Customer[x.Name] = x.Text;
                }
        }

        // Method to return radio values
        public void membershipData()
        {
            foreach (var x in memType.Controls.OfType<RadioButton>())
            {
                if (x.Checked == true)
                {
                    Customer["membershipType"] = x.Text;
                }
            }
            foreach (var x in memDuration.Controls.OfType<RadioButton>())
            {
                if (x.Checked == true)
                {
                    Customer["memDuration"] = x.Text;
                }
            }
            foreach (var x in payMethod.Controls.OfType<RadioButton>())
            {
                if (x.Checked == true)
                {
                    Customer["payMethod"] = x.Text;
                }
            }
            foreach (var x in frequency.Controls.OfType<RadioButton>())
            {
                if (x.Checked == true)
                {
                    Customer["frequency"] = x.Text;
                }
            }
            foreach (var x in extras.Controls.OfType<CheckBox>())
            {
                if (x.Checked == true)
                {
                    Customer[x.Name] = 1;
                }
            }
        }

        // Method to calculate price
        public void priceCalc()
        {
            foreach (var x in Price.Keys)
            {
                if (x == Customer["membershipType"])
                {
                    Customer["basePrice"] += x;
                }
                if (x == Customer["memDuration"])
                {
                    Customer["basePrice"] += x;
                }
                /*if (x == Customer["membershipType"]) // double up??
                {
                    Customer["basePrice"] += x;
                }*/
                if (x.Contains("extra") == true)
                {
                    Customer["basePrice"] += Price[x];
                }
                if (x == Customer["payMethod"])
                {
                    Customer["basePrice"] = Customer["basePrice"] - (Customer["basePrice"]/100 * Price[x]); // base price - (base price/100 * 1)
                }
            }
            // Calculate payment amount based on number of weeks in duration
            if (Customer["frequency"] == "frequencyWeekly")
            {
                Customer["payAmount"] = Customer["basePrice"];// already weekly
            }
            if (Customer["frequency"] == "frequencyMonthly")
            {
                Customer["payAmount"] = Customer["basePrice"] * (Price[Customer["memDuration"].Value]/4);// divide by 4 for monthly
            }
            if (Customer["frequency"] == "frequencyFull")
            {
                Customer["payAmount"] = Customer["basePrice"] * Duration[Customer["memDuration"]];// multiply price by weeks in duration
            }
        }

        // method to check form is completed
        public void CheckForm()
        {
            int i = 0;
            foreach (var x in Controls.OfType<TextBox>())
            {
                if (x.Text == "")
                {
                    x.BackColor = SystemColors.HighlightText;
                }
            }
            foreach (var x in memType.Controls.OfType<RadioButton>())
            {
                if (x.Checked == true)
                {
                    i++;
                }
            }
            if (i > 2)
            {
                memType.BackColor = SystemColors.HighlightText; ;
            }
            else
            {
                i = 0;
            }
            foreach (var x in memDuration.Controls.OfType<RadioButton>())
            {
                if (x.Checked == true)
                {
                    i++;
                }
            }
            if (i > 2)
            {
                memDuration.BackColor = SystemColors.HighlightText;
            }
            else
            {
                i = 0;
            }
            foreach (var x in payMethod.Controls.OfType<RadioButton>())
            {
                if (x.Checked == true)
                {
                    i++;
                }
            }
            if (i > 2)
            {
                payMethod.BackColor = SystemColors.HighlightText; ;
            }
            else
            {
                i = 0;
            }
            foreach (var x in frequency.Controls.OfType<RadioButton>())
            {
                if (x.Checked == true)
                {
                    i++;
                }
            }
            if (i > 2)
            {
                frequency.BackColor = SystemColors.HighlightText; ;
            }
            else
            {
                i = 0;
            }
            if (i == 0)
            {
                complete = true;
            }
        }

        // Method to Clear form
        private void ClearForm()
        {
            foreach (var x in Controls.OfType<TextBox>())
            {
                x.Text = "";
            }
            foreach (var x in Controls.OfType<RadioButton>())
            {
                x.Checked = false;
            }
            foreach (var x in Controls.OfType<CheckBox>())
            {
                x.Checked = false;
            }
        }
        

        private void Submit_Click(object sender, EventArgs e)
        {
            CheckForm();
            textReturn();
            membershipData();
            priceCalc();
            if (complete == true)
            {
                string connectionString;
                SqlConnection cnn;
                connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\OP\BIT502\Ass3\v2\WindowsFormsApp1\WindowsFormsApp1\CityGym.mdf;Integrated Security=True;Connect Timeout=30";
                cnn = new SqlConnection(connectionString);
                cnn.Open();
                //MessageBox.Show("Connection Open");

                SqlCommand command;
                SqlDataAdapter adapter = new SqlDataAdapter();
                
                dynamic val;
                foreach (var key in Customer.Keys)
                {
                    val = Customer[key];
                    string sql = "INSERT INTO Customer (@key) VALUES (@val)";
                    command = new SqlCommand(sql, cnn);

                    adapter.SelectCommand = new SqlCommand(sql, cnn);
                    adapter.InsertCommand = command;

                    command.Dispose();
                }
                cnn.Close();
                ClearForm();
            }
        }

        // Cancel form
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
