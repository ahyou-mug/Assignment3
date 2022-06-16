namespace WindowsFormsApp1
{
    partial class Form4
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.classSearch = new System.Windows.Forms.Button();
            this.bookClass = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 145);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 293);
            this.dataGridView1.TabIndex = 0;
            // 
            // classSearch
            // 
            this.classSearch.Location = new System.Drawing.Point(214, 54);
            this.classSearch.Name = "classSearch";
            this.classSearch.Size = new System.Drawing.Size(166, 39);
            this.classSearch.TabIndex = 1;
            this.classSearch.Text = "Search Classes";
            this.classSearch.UseVisualStyleBackColor = true;
            // 
            // bookClass
            // 
            this.bookClass.Location = new System.Drawing.Point(407, 54);
            this.bookClass.Name = "bookClass";
            this.bookClass.Size = new System.Drawing.Size(170, 39);
            this.bookClass.TabIndex = 2;
            this.bookClass.Text = "Book Class";
            this.bookClass.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(597, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(190, 38);
            this.button1.TabIndex = 3;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bookClass);
            this.Controls.Add(this.classSearch);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form4";
            this.Text = "Form4";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button classSearch;
        private System.Windows.Forms.Button bookClass;
        private System.Windows.Forms.Button button1;
    }
}