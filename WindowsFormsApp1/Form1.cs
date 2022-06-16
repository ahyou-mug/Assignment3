using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        
        private void Registration_Load(object sender, System.EventArgs e)
        {
            foreach (var tt in Controls.OfType<ToolTip>())
            {
                tt.AutoPopDelay = 500;
                tt.InitialDelay = 500;
                tt.ReshowDelay = 250;
                tt.ShowAlways = true;
                tt.Active = true;
            }

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
            {"basePrice",null}
        };


        // Dictionary for Price Data
        Dictionary<string, int> Price = new Dictionary<string, int>()
        {
            {"Basic ($10/pw)",10},
            {"Regular ($15/pw)",15 },
            {"Premium ($20/pw)",20 },
            {"12",-2 },
            {"24",-5 },
            {"extra247",1 },
            {"extraPT",20 },
            {"extraDT",20 },
            {"extraVT",2 },
            {"Direct Debit",1 }, // subtract total - (total/100 * 1)
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
                    Customer["memDuration"] = Int32.Parse(x.Text);
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
                    Customer["basePrice"] = Price[x];
                }
                if (x == Customer["memDuration"].ToString())
                {
                    Customer["basePrice"] = Customer["basePrice"] + Price[x];
                }
                if (Customer.ContainsKey(x))
                {
                    if (Customer[x] == 1)
                    {
                        Customer["basePrice"] = Customer["basePrice"] + Price[x];
                    }
                }
                if (x == Customer["payMethod"])
                {
                    Customer["basePrice"] = Customer["basePrice"] - (Customer["basePrice"]/100 * Price[x]); // base price - (base price/100 * 1) - won't show unless convert to float
                }
            }
            // Calculate payment amount based on number of weeks in duration
            if (Customer["frequency"] == "Weekly")
            {
                Customer["payAmount"] = Customer["basePrice"];// already weekly
            }
            if (Customer["frequency"] == "Monthly")
            {
                Customer["payAmount"] = (Customer["basePrice"] * Customer["memDuration"]) /4;// divide by 4 for monthly
            }
            if (Customer["frequency"] == "In Full")
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
            Customer.Clear();
        }
        

        // String builder and insert into DB
        private void intoDB()
        {
            string connectionString;
            SqlConnection cnn;
            const string V = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\OP\BIT502\Ass3\v2\WindowsFormsApp1\WindowsFormsApp1\CityGym.mdf;Integrated Security=True;";
            connectionString = V;
            cnn = new SqlConnection(connectionString);
            cnn.Open();

            var names = Customer.Select(pair =>
               new
               {
                   ColumnName = pair.Key.Replace("[", "").Replace("]", ""),
                   Value = pair.Value
               }
            );

            // Build Columns
            StringBuilder sb = new StringBuilder("INSERT INTO Customers(");
            Boolean first = true;
            foreach (var pair in names)
            {
                if (!first) sb.Append(", ");
                first = false;

                sb.Append("[");
                sb.Append(pair.ColumnName);
                sb.Append("]");
            }
            // Build Values
            sb.Append(" ) VALUES ( ");

            first = true;
            foreach (var pair in names)
            {
                if (!first) sb.Append(", ");
                first = false;

                sb.Append("@");
                sb.Append(pair.ColumnName);
                //sb.Append("]]");
            }

            // Build Command
            using (SqlCommand cmd = cnn.CreateCommand())
            {

                foreach (var pair in names)
                {
                    cmd.Parameters.AddWithValue(('@' + pair.ColumnName), pair.Value);
                }
                sb.Append(")");

                cmd.CommandText = sb.ToString();

                cmd.ExecuteNonQuery();
            }
            cnn.Close();
        }

        // Submit method
        private void Submit_Click(object sender, EventArgs e)
        {
            CheckForm();
            textReturn();
            membershipData();
            priceCalc();
            //ConsoleLog();
            if (complete == true)
            {
                intoDB();
                
                ClearForm();
            }
        }

        // Cancel form
        private void button3_Click(object sender, EventArgs e)
        {
            ClearForm();
            Customer.Clear();
            this.Close();
            new Intro().Show();
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
            toolTip1.SetToolTip(this.label5, "Enter the emergency contact name");
        }

        private void toolTip2_Popup(object sender, PopupEventArgs e)
        {
            toolTip2.SetToolTip(this.label1, "Enter the new members' First Name");
        }

        private void toolTip3_Popup(object sender, PopupEventArgs e)
        {
            toolTip3.SetToolTip(this.label2, "Enter the new members' Last Name");
        }

        private void toolTip4_Popup(object sender, PopupEventArgs e)
        {
            toolTip4.SetToolTip(this.label3, "Enter the members mobile number");
        }

        private void toolTip5_Popup(object sender, PopupEventArgs e)
        {
            toolTip5.SetToolTip(this.label4, "Enter the members address");
        }

        private void toolTip6_Popup(object sender, PopupEventArgs e)
        {
            toolTip6.SetToolTip(this.label6, "Enter the emergency contact's phone number");
        }

        private void toolTip7_Popup(object sender, PopupEventArgs e)
        {
            toolTip7.SetToolTip(this.label7, "Enter the contacts relationship to the new member");
        }

        private void toolTip8_Popup(object sender, PopupEventArgs e)
        {
            toolTip8.SetToolTip(this.memType, "Select the appropriate membership type");
        }

        private void toolTip9_Popup(object sender, PopupEventArgs e)
        {
            toolTip9.SetToolTip(this.memDuration, "Set the duration in months of the membership");
        }

        private void toolTip10_Popup(object sender, PopupEventArgs e)
        {
            toolTip10.SetToolTip(this.payMethod, "Select the payment method the new member would like to use");
        }

        private void toolTip11_Popup(object sender, PopupEventArgs e)
        {
            toolTip11.SetToolTip(this.frequency, "Select how often the new member would like to pay");
        }

        private void toolTip12_Popup(object sender, PopupEventArgs e)
        {
            toolTip12.SetToolTip(this.extras, "Select any extra services the new member would like");
        }

        private void toolTip13_Popup(object sender, PopupEventArgs e)
        {
            toolTip13.SetToolTip(this.button3, "Return to the main menu without saving any changes");
        }

        private void toolTip14_Popup(object sender, PopupEventArgs e)
        {
            toolTip14.SetToolTip(this.Submit, "Complete new member registration and save details");
        }
    }
}
