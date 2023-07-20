namespace QL_Cham_Cong_TT
{
    partial class from_test
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
            this.btn_Chon_Anh = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_Them = new System.Windows.Forms.Button();
            this.btn_Sua = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Chon_Anh
            // 
            this.btn_Chon_Anh.Location = new System.Drawing.Point(229, 197);
            this.btn_Chon_Anh.Name = "btn_Chon_Anh";
            this.btn_Chon_Anh.Size = new System.Drawing.Size(88, 30);
            this.btn_Chon_Anh.TabIndex = 0;
            this.btn_Chon_Anh.Text = "Chọn Ảnh";
            this.btn_Chon_Anh.UseVisualStyleBackColor = true;
            this.btn_Chon_Anh.Click += new System.EventHandler(this.btn_Chon_Anh_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(211, 215);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btn_Them
            // 
            this.btn_Them.Location = new System.Drawing.Point(12, 292);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(75, 23);
            this.btn_Them.TabIndex = 2;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.UseVisualStyleBackColor = true;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // btn_Sua
            // 
            this.btn_Sua.Location = new System.Drawing.Point(148, 292);
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.Size = new System.Drawing.Size(75, 23);
            this.btn_Sua.TabIndex = 3;
            this.btn_Sua.Text = "Sửa";
            this.btn_Sua.UseVisualStyleBackColor = true;
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Location = new System.Drawing.Point(285, 292);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(75, 23);
            this.btn_Xoa.TabIndex = 4;
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.UseVisualStyleBackColor = true;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // from_test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 612);
            this.Controls.Add(this.btn_Xoa);
            this.Controls.Add(this.btn_Sua);
            this.Controls.Add(this.btn_Them);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_Chon_Anh);
            this.Name = "from_test";
            this.Text = "from_test";
            this.Load += new System.EventHandler(this.from_test_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Chon_Anh;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.Button btn_Sua;
        private System.Windows.Forms.Button btn_Xoa;
    }
}