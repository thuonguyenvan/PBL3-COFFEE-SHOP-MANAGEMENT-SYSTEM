namespace PBL3_Coffee_Shop_Management_System.Views
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
        private void InitializeComponent(bool auth)
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            if (auth)
            {
                this.checkBox6 = new System.Windows.Forms.CheckBox();
                this.checkBox7 = new System.Windows.Forms.CheckBox();
            }
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(559, 227);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox5);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.checkBox4);
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.checkBox3);
            this.panel1.Location = new System.Drawing.Point(198, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(916, 630);
            this.panel1.TabIndex = 8;
            // 
            // checkBox5
            // 
            this.checkBox5.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox5.BackColor = System.Drawing.Color.Black;
            this.checkBox5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.checkBox5.ForeColor = System.Drawing.Color.SandyBrown;
            this.checkBox5.Name = "checkBox5";
            if (auth)
            {
                this.checkBox5.Size = new System.Drawing.Size(198, 90);
                this.checkBox5.Text = "QUẢN LÝ HÀNG HÓA";
            }
            else
            {
                this.checkBox5.Text = "XEM HÀNG HÓA";
                this.checkBox5.Size = new System.Drawing.Size(198, 126);
            }
            this.checkBox5.TabIndex = 19;
            this.checkBox5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox5.UseVisualStyleBackColor = false;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            this.checkBox5.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            // 
            // checkBox1
            // 
            this.checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox1.BackColor = System.Drawing.Color.Black;
            this.checkBox1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Violet;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.checkBox1.ForeColor = System.Drawing.Color.SandyBrown;
            this.checkBox1.Name = "checkBox1";
            if (auth)
            {
                this.checkBox1.Size = new System.Drawing.Size(198, 90);
            }
            else
            {
                this.checkBox1.Size = new System.Drawing.Size(198, 126);
            }
            this.checkBox1.TabIndex = 15;
            this.checkBox1.Text = "BÁN HÀNG";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            // 
            // checkBox4
            // 
            this.checkBox4.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox4.BackColor = System.Drawing.Color.Black;
            this.checkBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.checkBox4.ForeColor = System.Drawing.Color.SandyBrown;
            if (auth)
            {
                this.checkBox4.Size = new System.Drawing.Size(198, 90);
                this.checkBox4.Text = "QUẢN LÝ LỊCH LÀM VIỆC";
            }
            else
            {
                this.checkBox4.Text = "XEM LỊCH LÀM VIỆC";
                this.checkBox4.Size = new System.Drawing.Size(198, 126);
            }
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.TabIndex = 18;
            this.checkBox4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox4.UseVisualStyleBackColor = false;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            this.checkBox4.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            // 
            // checkBox2
            // 
            this.checkBox2.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox2.BackColor = System.Drawing.Color.Black;
            this.checkBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.checkBox2.ForeColor = System.Drawing.Color.SandyBrown;
            this.checkBox2.Name = "checkBox2";
            if (auth)
            {
                this.checkBox2.Size = new System.Drawing.Size(198, 90);
            }
            else
            {
                this.checkBox2.Size = new System.Drawing.Size(198, 126);
            }
            this.checkBox2.TabIndex = 16;
            this.checkBox2.Text = "QUẢN LÝ KHÁCH HÀNG";
            this.checkBox2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox2.UseVisualStyleBackColor = false;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            // 
            // checkBox3
            // 
            this.checkBox3.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox3.BackColor = System.Drawing.Color.Black;
            this.checkBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.checkBox3.ForeColor = System.Drawing.Color.SandyBrown;
            this.checkBox3.Name = "checkBox3";
            if (auth)
            {
                this.checkBox3.Size = new System.Drawing.Size(198, 90);
            }
            else
            {
                this.checkBox3.Size = new System.Drawing.Size(198, 126);
            }
            this.checkBox3.TabIndex = 17;
            this.checkBox3.Text = "XEM LỊCH SỬ BÁN HÀNG";
            this.checkBox3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox3.UseVisualStyleBackColor = false;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(948, 7);
            this.label1.Name = "label2";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Xin chào, name here";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(897, 25);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(127, 21);
            this.button7.TabIndex = 10;
            this.button7.Text = "Xem thông tin cá nhân";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(1033, 25);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(69, 21);
            this.button8.TabIndex = 11;
            this.button8.Text = "Đăng xuất";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // checkBox6
            //
            if (auth)
            {
                this.checkBox6.Appearance = System.Windows.Forms.Appearance.Button;
                this.checkBox6.BackColor = System.Drawing.Color.Black;
                this.checkBox6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.checkBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
                this.checkBox6.ForeColor = System.Drawing.Color.SandyBrown;
                this.checkBox6.Name = "checkBox3";
                this.checkBox6.Size = new System.Drawing.Size(198, 90);
                this.checkBox6.TabIndex = 20;
                this.checkBox6.Text = "QUẢN LÝ NHÂN VIÊN";
                this.checkBox6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                this.checkBox6.UseVisualStyleBackColor = false;
                this.checkBox6.CheckedChanged += new System.EventHandler(this.checkBox6_CheckedChanged);
                this.checkBox6.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            }
            //
            // checkBox7
            //
            if (auth)
            {
                this.checkBox7.Appearance = System.Windows.Forms.Appearance.Button;
                this.checkBox7.BackColor = System.Drawing.Color.Black;
                this.checkBox7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.checkBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
                this.checkBox7.ForeColor = System.Drawing.Color.SandyBrown;
                this.checkBox7.Name = "checkBox3";
                this.checkBox7.Size = new System.Drawing.Size(198, 90);
                this.checkBox7.TabIndex = 20;
                this.checkBox7.Text = "THỐNG KÊ";
                this.checkBox7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                this.checkBox7.UseVisualStyleBackColor = false;
                this.checkBox7.CheckedChanged += new System.EventHandler(this.checkBox7_CheckedChanged);
                this.checkBox7.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            }
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 51);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(198, 630);
            this.flowLayoutPanel1.TabIndex = 12;
            if (auth) this.flowLayoutPanel1.Controls.AddRange(new System.Windows.Forms.Control[] { this.checkBox1, this.checkBox2, this.checkBox6,
                this.checkBox3, this.checkBox4, this.checkBox5, this.checkBox7 });
            else this.flowLayoutPanel1.Controls.AddRange(new System.Windows.Forms.Control[] { this.checkBox1, this.checkBox2, this.checkBox3, this.checkBox4, this.checkBox5 });
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1114, 681);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}

