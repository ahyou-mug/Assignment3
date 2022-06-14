namespace WindowsFormsApp1
{
    partial class MemberSearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cityGymDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cityGymDataSet = new WindowsFormsApp1.CityGymDataSet();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Search = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.cityGymDataSetBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.cityGymDataSetBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.cityGymDataSetBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.cityGymDataSet1 = new WindowsFormsApp1.CityGymDataSet1();
            this.customersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.customersTableAdapter = new WindowsFormsApp1.CityGymDataSet1TableAdapters.CustomersTableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SearchIt = new System.Windows.Forms.GroupBox();
            this.firstName = new System.Windows.Forms.TextBox();
            this.lastName = new System.Windows.Forms.TextBox();
            this.address = new System.Windows.Forms.TextBox();
            this.mobileNumber = new System.Windows.Forms.TextBox();
            this.custId = new System.Windows.Forms.TextBox();
            this.blankQuery = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cityGymDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityGymDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityGymDataSetBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityGymDataSetBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityGymDataSetBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityGymDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SearchIt.SuspendLayout();
            this.SuspendLayout();
            // 
            // cityGymDataSetBindingSource
            // 
            this.cityGymDataSetBindingSource.DataSource = this.cityGymDataSet;
            this.cityGymDataSetBindingSource.Position = 0;
            // 
            // cityGymDataSet
            // 
            this.cityGymDataSet.DataSetName = "CityGymDataSet";
            this.cityGymDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "First Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Last Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Address:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Mobile Number:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Customer ID:";
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(318, 31);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(130, 34);
            this.Search.TabIndex = 11;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(318, 81);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(129, 34);
            this.Cancel.TabIndex = 12;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // cityGymDataSetBindingSource1
            // 
            this.cityGymDataSetBindingSource1.DataSource = this.cityGymDataSet;
            this.cityGymDataSetBindingSource1.Position = 0;
            // 
            // cityGymDataSetBindingSource2
            // 
            this.cityGymDataSetBindingSource2.DataSource = this.cityGymDataSet;
            this.cityGymDataSetBindingSource2.Position = 0;
            // 
            // cityGymDataSetBindingSource3
            // 
            this.cityGymDataSetBindingSource3.DataSource = this.cityGymDataSet;
            this.cityGymDataSetBindingSource3.Position = 0;
            // 
            // cityGymDataSet1
            // 
            this.cityGymDataSet1.DataSetName = "CityGymDataSet1";
            this.cityGymDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // customersBindingSource
            // 
            this.customersBindingSource.DataMember = "Customers";
            this.customersBindingSource.DataSource = this.cityGymDataSet1;
            // 
            // customersTableAdapter
            // 
            this.customersTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.DataSource = this.cityGymDataSet;
            this.dataGridView1.Location = new System.Drawing.Point(30, 198);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(736, 241);
            this.dataGridView1.TabIndex = 13;
            // 
            // SearchIt
            // 
            this.SearchIt.Controls.Add(this.custId);
            this.SearchIt.Controls.Add(this.mobileNumber);
            this.SearchIt.Controls.Add(this.address);
            this.SearchIt.Controls.Add(this.lastName);
            this.SearchIt.Controls.Add(this.firstName);
            this.SearchIt.Controls.Add(this.label5);
            this.SearchIt.Controls.Add(this.label4);
            this.SearchIt.Controls.Add(this.label3);
            this.SearchIt.Controls.Add(this.label2);
            this.SearchIt.Controls.Add(this.label1);
            this.SearchIt.Location = new System.Drawing.Point(26, 31);
            this.SearchIt.Name = "SearchIt";
            this.SearchIt.Size = new System.Drawing.Size(200, 161);
            this.SearchIt.TabIndex = 14;
            this.SearchIt.TabStop = false;
            this.SearchIt.Text = "SearchCriteria";
            // 
            // firstName
            // 
            this.firstName.Location = new System.Drawing.Point(76, 17);
            this.firstName.Name = "firstName";
            this.firstName.Size = new System.Drawing.Size(112, 20);
            this.firstName.TabIndex = 6;
            // 
            // lastName
            // 
            this.lastName.Location = new System.Drawing.Point(76, 43);
            this.lastName.Name = "lastName";
            this.lastName.Size = new System.Drawing.Size(112, 20);
            this.lastName.TabIndex = 7;
            // 
            // address
            // 
            this.address.Location = new System.Drawing.Point(76, 69);
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(112, 20);
            this.address.TabIndex = 8;
            // 
            // mobileNumber
            // 
            this.mobileNumber.Location = new System.Drawing.Point(88, 95);
            this.mobileNumber.Name = "mobileNumber";
            this.mobileNumber.Size = new System.Drawing.Size(100, 20);
            this.mobileNumber.TabIndex = 9;
            // 
            // custId
            // 
            this.custId.Location = new System.Drawing.Point(76, 120);
            this.custId.Name = "custId";
            this.custId.Size = new System.Drawing.Size(112, 20);
            this.custId.TabIndex = 10;
            // 
            // blankQuery
            // 
            this.blankQuery.Location = new System.Drawing.Point(320, 130);
            this.blankQuery.Name = "blankQuery";
            this.blankQuery.Size = new System.Drawing.Size(126, 36);
            this.blankQuery.TabIndex = 15;
            this.blankQuery.Text = "Refresh";
            this.blankQuery.UseVisualStyleBackColor = true;
            this.blankQuery.Click += new System.EventHandler(this.blankQuery_Click);
            // 
            // MemberSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.blankQuery);
            this.Controls.Add(this.SearchIt);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Search);
            this.Name = "MemberSearch";
            this.Text = "Member Search";
            this.Load += new System.EventHandler(this.MemberSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cityGymDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityGymDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityGymDataSetBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityGymDataSetBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityGymDataSetBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityGymDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.SearchIt.ResumeLayout(false);
            this.SearchIt.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource cityGymDataSetBindingSource;
        private CityGymDataSet cityGymDataSet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.BindingSource cityGymDataSetBindingSource1;
        private System.Windows.Forms.BindingSource cityGymDataSetBindingSource2;
        private System.Windows.Forms.BindingSource cityGymDataSetBindingSource3;
        private CityGymDataSet1 cityGymDataSet1;
        private System.Windows.Forms.BindingSource customersBindingSource;
        private CityGymDataSet1TableAdapters.CustomersTableAdapter customersTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox SearchIt;
        private System.Windows.Forms.TextBox custId;
        private System.Windows.Forms.TextBox mobileNumber;
        private System.Windows.Forms.TextBox address;
        private System.Windows.Forms.TextBox lastName;
        private System.Windows.Forms.TextBox firstName;
        private System.Windows.Forms.Button blankQuery;
    }
}