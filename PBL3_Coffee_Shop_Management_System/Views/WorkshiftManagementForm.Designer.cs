namespace PBL3_Coffee_Shop_Management_System.Views
{
    partial class WorkshiftManagementForm
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
            this.button26 = new System.Windows.Forms.Button();
            this.button27 = new System.Windows.Forms.Button();
            this.button28 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // button26
            // 
            this.button26.BackColor = System.Drawing.Color.Transparent;
            this.button26.Image = global::PBL3_Coffee_Shop_Management_System.Properties.Resources.pngegg__2_;
            this.button26.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button26.Location = new System.Drawing.Point(348, 40);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(96, 34);
            this.button26.TabIndex = 12;
            this.button26.Text = " Chỉnh sửa";
            this.button26.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button26.UseVisualStyleBackColor = false;
            this.button26.Click += new System.EventHandler(this.button26_Click);
            // 
            // button27
            // 
            this.button27.Image = global::PBL3_Coffee_Shop_Management_System.Properties.Resources.pngegg;
            this.button27.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button27.Location = new System.Drawing.Point(224, 40);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(66, 34);
            this.button27.TabIndex = 11;
            this.button27.Text = " Xóa";
            this.button27.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button27.UseVisualStyleBackColor = true;
            this.button27.Click += new System.EventHandler(this.button27_Click);
            // 
            // button28
            // 
            this.button28.Image = global::PBL3_Coffee_Shop_Management_System.Properties.Resources.pngegg__1_;
            this.button28.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button28.Location = new System.Drawing.Point(89, 40);
            this.button28.Name = "button28";
            this.button28.Size = new System.Drawing.Size(73, 34);
            this.button28.TabIndex = 10;
            this.button28.Text = " Thêm";
            this.button28.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button28.UseVisualStyleBackColor = true;
            this.button28.Click += new System.EventHandler(this.button28_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(21, 112);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(861, 461);
            this.listView1.TabIndex = 13;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã ca làm";
            this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader1.Width = 94;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Thời gian bắt đầu";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 272;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Thời gian kết thúc";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 158;
            // 
            // WorkshiftManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Peru;
            this.ClientSize = new System.Drawing.Size(900, 591);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button26);
            this.Controls.Add(this.button27);
            this.Controls.Add(this.button28);
            this.Name = "WorkshiftManagementForm";
            this.Text = "WorkshiftManagementForm";
            this.Load += new System.EventHandler(this.WorkshiftManagementForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button26;
        private System.Windows.Forms.Button button27;
        private System.Windows.Forms.Button button28;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}