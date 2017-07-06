namespace TextEditor
{
    partial class Find_Replace
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
            this.btnfindnext = new System.Windows.Forms.Button();
            this.btnreplace = new System.Windows.Forms.Button();
            this.btnreplaceall = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbfind = new System.Windows.Forms.RichTextBox();
            this.tbreplace = new System.Windows.Forms.RichTextBox();
            this.btnfindall = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnfindnext
            // 
            this.btnfindnext.Location = new System.Drawing.Point(341, 13);
            this.btnfindnext.Name = "btnfindnext";
            this.btnfindnext.Size = new System.Drawing.Size(86, 23);
            this.btnfindnext.TabIndex = 0;
            this.btnfindnext.Text = "Find Next";
            this.btnfindnext.UseVisualStyleBackColor = true;
            this.btnfindnext.Click += new System.EventHandler(this.btnfindnext_Click);
            // 
            // btnreplace
            // 
            this.btnreplace.Location = new System.Drawing.Point(341, 67);
            this.btnreplace.Name = "btnreplace";
            this.btnreplace.Size = new System.Drawing.Size(86, 23);
            this.btnreplace.TabIndex = 2;
            this.btnreplace.Text = "Replace";
            this.btnreplace.UseVisualStyleBackColor = true;
            this.btnreplace.Click += new System.EventHandler(this.btnreplace_Click);
            // 
            // btnreplaceall
            // 
            this.btnreplaceall.Location = new System.Drawing.Point(341, 96);
            this.btnreplaceall.Name = "btnreplaceall";
            this.btnreplaceall.Size = new System.Drawing.Size(86, 23);
            this.btnreplaceall.TabIndex = 3;
            this.btnreplaceall.Text = "Replace All";
            this.btnreplaceall.UseVisualStyleBackColor = true;
            this.btnreplaceall.Click += new System.EventHandler(this.btnreplaceall_Click);
            // 
            // btncancel
            // 
            this.btncancel.Location = new System.Drawing.Point(341, 125);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(86, 23);
            this.btncancel.TabIndex = 4;
            this.btncancel.Text = "Cancel";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Find What :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Replace With :";
            // 
            // tbfind
            // 
            this.tbfind.Location = new System.Drawing.Point(87, 12);
            this.tbfind.Name = "tbfind";
            this.tbfind.Size = new System.Drawing.Size(239, 23);
            this.tbfind.TabIndex = 7;
            this.tbfind.Text = "";
            // 
            // tbreplace
            // 
            this.tbreplace.Location = new System.Drawing.Point(104, 49);
            this.tbreplace.Name = "tbreplace";
            this.tbreplace.Size = new System.Drawing.Size(222, 23);
            this.tbreplace.TabIndex = 8;
            this.tbreplace.Text = "";
            // 
            // btnfindall
            // 
            this.btnfindall.Location = new System.Drawing.Point(341, 40);
            this.btnfindall.Name = "btnfindall";
            this.btnfindall.Size = new System.Drawing.Size(86, 23);
            this.btnfindall.TabIndex = 9;
            this.btnfindall.Text = "Find All";
            this.btnfindall.UseVisualStyleBackColor = true;
            this.btnfindall.Click += new System.EventHandler(this.btnfindall_Click);
            // 
            // Find_Replace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 160);
            this.Controls.Add(this.btnfindall);
            this.Controls.Add(this.tbreplace);
            this.Controls.Add(this.tbfind);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnreplaceall);
            this.Controls.Add(this.btnreplace);
            this.Controls.Add(this.btnfindnext);
            this.Name = "Find_Replace";
            this.Text = "Find/Replace";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnfindnext;
        private System.Windows.Forms.Button btnreplace;
        private System.Windows.Forms.Button btnreplaceall;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox tbfind;
        private System.Windows.Forms.RichTextBox tbreplace;
        private System.Windows.Forms.Button btnfindall;
    }
}