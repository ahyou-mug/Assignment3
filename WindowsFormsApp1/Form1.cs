using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            {"extra247",false},
            {"extraPT",false },
            {"extraDT",false },
            {"extraVT",false },
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
            {"duration3",12 },
            {"duration6",26 },
            {"duration12",52 },
            {"duration24",104 }
        };

        // Method to return customer strings
        public void textReturn()
        {
            foreach (var x in Controls.OfType<TextBox>())
                {
                    Customer[x.Name].Value = x.Text;
                }
        }

        // Method to return radio values
        public void membershipData()
        {
            foreach (var x in memType.Controls.OfType<RadioButton>())
            {
                if (x.Checked == true)
                {
                    Customer["membershipType"].Value = x.Text;
                }
            }
            foreach (var x in memDuration.Controls.OfType<RadioButton>())
            {
                if (x.Checked == true)
                {
                    Customer["memDuration"].Value = x.Text;
                }
            }
            foreach (var x in payMethod.Controls.OfType<RadioButton>())
            {
                if (x.Checked == true)
                {
                    Customer["payMethod"].Value = x.Text;
                }
            }
            foreach (var x in frequency.Controls.OfType<RadioButton>())
            {
                if (x.Checked == true)
                {
                    Customer["frequency"].value = x.Text;
                }
            }
            foreach (var x in memType.Controls.OfType<CheckBox>())
            {
                if (x.Checked == true)
                {
                    if (Customer[x.Text].Exists)
                    {
                        Customer[x.Text].Value = x.Checked;
                    }
                }
            }
        }

        // Method to calculate price
        public void priceCalc()
        {
            foreach (var x in Price)
            {
                if (x == Customer["membershipType"])
                {
                    Customer["basePrice"].Value += x.Value;
                }
                if (x == Customer["memDuration"])
                {
                    Customer["basePrice"].Value += x.Value;
                }
                if (x == Customer["membershipType"])
                {
                    Customer["basePrice"].Value += x.Value;
                }
                if (Customer[x.ToString()] == true)
                {
                    Customer["basePrice"].Value += x.Value;
                }
                if (x == Customer["payMethod"])
                {
                    Customer["basePrice"].Value = Customer["basePrice"].Value - (Customer["basePrice"].value/100 * x.Value); // base price - (base price/100 * 1)
                }
            }
            // Calculate payment amount based on number of weeks in duration
            if (Customer["frequency"] == "frequencyWeekly")
            {
                Customer["payAmount"] = Customer["basePrice"];// already weekly
            }
            if (Customer["frequency"] == "frequencyMonthly")
            {
                Customer["payAmount"] = Customer["basePrice"] * (Price[Customer["memDuration"]]/4);// divide by 4 for monthly
            }
            if (Customer["frequency"] == "frequencyFull")
            {
                Customer["payAmount"] = Customer["basePrice"].Value * Price[Customer["memDuration"]];// multiply price by weeks in duration
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
        /*
        private void Submit_Click(object sender, EventArgs e)
        {
            CheckForm();
            if (complete == true)
            {
                System.Data.SqlClient.SqlConnection SqlConnection1 =
                    new System.Data.SqlClient.SqlConnection("(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\OP\BIT502\Ass3\v2\WindowsFormsApp1\WindowsFormsApp1\CityGym.mdf;Integrated Security=True;Connect Timeout=30");
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "INSERT Customers (FirstName, LastName, Address, MobileNumber, MembershipType, MembershipDuration,PaymentFrequency,PaymentMethod,extras247,extrasPT,extrasDT,extrasVT,BasePrice,PaymentAmount) VALUES (Customer['firstname'],Customer['lastname'],Customer['address'],Customer['mobileNumber'],Customer['membershipType'],Customer['memDuration'],Customer['
            }

        }
        */

        private void Submit_Click(object sender, EventArgs e)
        {
            CheckForm();
            if (complete == true)
            {
                DataSet CityGymDataSet DataRow row = Customers.newRow();

                DataRow t = .Customers.newRow();

                CityGymDataSet.Customers newCustomersRow;

                INSERT INTO dbo.CityGymDataSet.Customers
            }
        }
    }
}
