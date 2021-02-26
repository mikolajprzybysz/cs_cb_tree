namespace CBTree
{
    partial class Form1
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
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.lstPeople = new System.Windows.Forms.ListBox();
            this.btnRandom = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtSsn = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRemove
            // 
            this.btnRemove.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnRemove.Location = new System.Drawing.Point(208, 80);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 22;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(208, 56);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 21;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // lstPeople
            // 
            this.lstPeople.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPeople.FormattingEnabled = true;
            this.lstPeople.Location = new System.Drawing.Point(8, 112);
            this.lstPeople.Name = "lstPeople";
            this.lstPeople.Size = new System.Drawing.Size(272, 251);
            this.lstPeople.TabIndex = 20;
            this.lstPeople.SelectedIndexChanged += new System.EventHandler(this.lstPeople_SelectedIndexChanged);
            // 
            // btnRandom
            // 
            this.btnRandom.Location = new System.Drawing.Point(208, 32);
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Size = new System.Drawing.Size(75, 23);
            this.btnRandom.TabIndex = 19;
            this.btnRandom.Text = "Random";
            this.btnRandom.UseVisualStyleBackColor = true;
            this.btnRandom.Click += new System.EventHandler(this.btnRandom_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(208, 8);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 18;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(72, 56);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(128, 20);
            this.txtLastName.TabIndex = 17;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(8, 56);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(61, 13);
            this.Label3.TabIndex = 16;
            this.Label3.Text = "Last Name:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(72, 32);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(128, 20);
            this.txtFirstName.TabIndex = 15;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(8, 32);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(60, 13);
            this.Label2.TabIndex = 14;
            this.Label2.Text = "First Name:";
            // 
            // txtSsn
            // 
            this.txtSsn.Location = new System.Drawing.Point(72, 8);
            this.txtSsn.Name = "txtSsn";
            this.txtSsn.Size = new System.Drawing.Size(128, 20);
            this.txtSsn.TabIndex = 13;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(8, 8);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(32, 13);
            this.Label1.TabIndex = 12;
            this.Label1.Text = "SSN:";
            // 
            // Form1
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnRemove;
            this.ClientSize = new System.Drawing.Size(292, 372);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.lstPeople);
            this.Controls.Add(this.btnRandom);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.txtSsn);
            this.Controls.Add(this.Label1);
            this.Name = "Form1";
            this.Text = "CBTree";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnRemove;
        internal System.Windows.Forms.Button btnFind;
        internal System.Windows.Forms.ListBox lstPeople;
        internal System.Windows.Forms.Button btnRandom;
        internal System.Windows.Forms.Button btnAdd;
        internal System.Windows.Forms.TextBox txtLastName;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtFirstName;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtSsn;
        internal System.Windows.Forms.Label Label1;
    }
}

