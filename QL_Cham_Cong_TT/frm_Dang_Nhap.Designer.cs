namespace QL_Cham_Cong_TT
{
    partial class frm_Dang_Nhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Dang_Nhap));
            this.lbl_Tai_Khoan = new System.Windows.Forms.Label();
            this.lbl_Mat_Khau = new System.Windows.Forms.Label();
            this.txt_Tai_Khoan = new System.Windows.Forms.TextBox();
            this.txt_Mat_Khau = new System.Windows.Forms.TextBox();
            this.btn_Đang_Nhap = new System.Windows.Forms.Button();
            this.btn_Quen_Mat_Khau = new System.Windows.Forms.Button();
            this.btn_Thoat = new System.Windows.Forms.Button();
            this.cmb_Chuc_Vu = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lib_Quen_Mat_Kau = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_Tai_Khoan
            // 
            this.lbl_Tai_Khoan.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Tai_Khoan.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbl_Tai_Khoan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Tai_Khoan.ForeColor = System.Drawing.Color.White;
            this.lbl_Tai_Khoan.Image = ((System.Drawing.Image)(resources.GetObject("lbl_Tai_Khoan.Image")));
            this.lbl_Tai_Khoan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_Tai_Khoan.Location = new System.Drawing.Point(233, 191);
            this.lbl_Tai_Khoan.Name = "lbl_Tai_Khoan";
            this.lbl_Tai_Khoan.Size = new System.Drawing.Size(111, 22);
            this.lbl_Tai_Khoan.TabIndex = 1;
            this.lbl_Tai_Khoan.Text = "   Tài Khoản";
            this.lbl_Tai_Khoan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Mat_Khau
            // 
            this.lbl_Mat_Khau.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Mat_Khau.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Mat_Khau.ForeColor = System.Drawing.Color.White;
            this.lbl_Mat_Khau.Image = ((System.Drawing.Image)(resources.GetObject("lbl_Mat_Khau.Image")));
            this.lbl_Mat_Khau.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_Mat_Khau.Location = new System.Drawing.Point(233, 244);
            this.lbl_Mat_Khau.Name = "lbl_Mat_Khau";
            this.lbl_Mat_Khau.Size = new System.Drawing.Size(111, 22);
            this.lbl_Mat_Khau.TabIndex = 2;
            this.lbl_Mat_Khau.Text = "   Mật Khẩu";
            this.lbl_Mat_Khau.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Mat_Khau.Click += new System.EventHandler(this.lbl_Mat_Khau_Click);
            // 
            // txt_Tai_Khoan
            // 
            this.txt_Tai_Khoan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Tai_Khoan.Location = new System.Drawing.Point(362, 189);
            this.txt_Tai_Khoan.Name = "txt_Tai_Khoan";
            this.txt_Tai_Khoan.Size = new System.Drawing.Size(290, 26);
            this.txt_Tai_Khoan.TabIndex = 3;
            // 
            // txt_Mat_Khau
            // 
            this.txt_Mat_Khau.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Mat_Khau.Location = new System.Drawing.Point(362, 242);
            this.txt_Mat_Khau.Name = "txt_Mat_Khau";
            this.txt_Mat_Khau.PasswordChar = '*';
            this.txt_Mat_Khau.Size = new System.Drawing.Size(290, 26);
            this.txt_Mat_Khau.TabIndex = 4;
            // 
            // btn_Đang_Nhap
            // 
            this.btn_Đang_Nhap.BackColor = System.Drawing.Color.Transparent;
            this.btn_Đang_Nhap.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btn_Đang_Nhap.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Đang_Nhap.Image = ((System.Drawing.Image)(resources.GetObject("btn_Đang_Nhap.Image")));
            this.btn_Đang_Nhap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Đang_Nhap.Location = new System.Drawing.Point(237, 356);
            this.btn_Đang_Nhap.Name = "btn_Đang_Nhap";
            this.btn_Đang_Nhap.Size = new System.Drawing.Size(134, 34);
            this.btn_Đang_Nhap.TabIndex = 5;
            this.btn_Đang_Nhap.Text = "     Đăng Nhập";
            this.btn_Đang_Nhap.UseVisualStyleBackColor = false;
            this.btn_Đang_Nhap.Click += new System.EventHandler(this.btn_Đang_Nhap_Click);
            // 
            // btn_Quen_Mat_Khau
            // 
            this.btn_Quen_Mat_Khau.BackColor = System.Drawing.Color.Transparent;
            this.btn_Quen_Mat_Khau.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btn_Quen_Mat_Khau.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Quen_Mat_Khau.Image = ((System.Drawing.Image)(resources.GetObject("btn_Quen_Mat_Khau.Image")));
            this.btn_Quen_Mat_Khau.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Quen_Mat_Khau.Location = new System.Drawing.Point(421, 356);
            this.btn_Quen_Mat_Khau.Name = "btn_Quen_Mat_Khau";
            this.btn_Quen_Mat_Khau.Size = new System.Drawing.Size(134, 34);
            this.btn_Quen_Mat_Khau.TabIndex = 6;
            this.btn_Quen_Mat_Khau.Text = "     Đổi Mật Khẩu";
            this.btn_Quen_Mat_Khau.UseVisualStyleBackColor = false;
            this.btn_Quen_Mat_Khau.Click += new System.EventHandler(this.btn_Quen_Mat_Khau_Click);
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.BackColor = System.Drawing.Color.Transparent;
            this.btn_Thoat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btn_Thoat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Thoat.Image = ((System.Drawing.Image)(resources.GetObject("btn_Thoat.Image")));
            this.btn_Thoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Thoat.Location = new System.Drawing.Point(607, 356);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(134, 34);
            this.btn_Thoat.TabIndex = 7;
            this.btn_Thoat.Text = "   Thoát";
            this.btn_Thoat.UseVisualStyleBackColor = false;
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // cmb_Chuc_Vu
            // 
            this.cmb_Chuc_Vu.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Chuc_Vu.FormattingEnabled = true;
            this.cmb_Chuc_Vu.Items.AddRange(new object[] {
            "Nhân Viên",
            "Trưởng Phòng",
            "Quản Lý"});
            this.cmb_Chuc_Vu.Location = new System.Drawing.Point(362, 288);
            this.cmb_Chuc_Vu.Name = "cmb_Chuc_Vu";
            this.cmb_Chuc_Vu.Size = new System.Drawing.Size(121, 23);
            this.cmb_Chuc_Vu.TabIndex = 8;
            this.cmb_Chuc_Vu.SelectedIndexChanged += new System.EventHandler(this.cmb_Chuc_Vu_SelectedIndexChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(658, 245);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(133, 23);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Hiện Mật Khẩu";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // lib_Quen_Mat_Kau
            // 
            this.lib_Quen_Mat_Kau.ActiveLinkColor = System.Drawing.Color.White;
            this.lib_Quen_Mat_Kau.BackColor = System.Drawing.Color.Transparent;
            this.lib_Quen_Mat_Kau.DisabledLinkColor = System.Drawing.Color.Yellow;
            this.lib_Quen_Mat_Kau.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib_Quen_Mat_Kau.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lib_Quen_Mat_Kau.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lib_Quen_Mat_Kau.Location = new System.Drawing.Point(489, 287);
            this.lib_Quen_Mat_Kau.Name = "lib_Quen_Mat_Kau";
            this.lib_Quen_Mat_Kau.Size = new System.Drawing.Size(100, 23);
            this.lib_Quen_Mat_Kau.TabIndex = 10;
            this.lib_Quen_Mat_Kau.TabStop = true;
            this.lib_Quen_Mat_Kau.Text = "Quên Mật Khẩu";
            this.lib_Quen_Mat_Kau.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lib_Quen_Mat_Kau.VisitedLinkColor = System.Drawing.Color.Black;
            this.lib_Quen_Mat_Kau.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lib_Quen_Mat_Kau_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(301, 406);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(417, 40);
            this.panel1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(333, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "       Chào Mừng Đến Với Công Ty ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(-214, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(314, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "       Chào Mừng Đến Với Công Ty ";
            // 
            // frm_Dang_Nhap
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.lib_Quen_Mat_Kau);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.cmb_Chuc_Vu);
            this.Controls.Add(this.btn_Thoat);
            this.Controls.Add(this.btn_Quen_Mat_Khau);
            this.Controls.Add(this.btn_Đang_Nhap);
            this.Controls.Add(this.txt_Mat_Khau);
            this.Controls.Add(this.txt_Tai_Khoan);
            this.Controls.Add(this.lbl_Mat_Khau);
            this.Controls.Add(this.lbl_Tai_Khoan);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Dang_Nhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập";
            this.Load += new System.EventHandler(this.frm_Dang_Nhap_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_Tai_Khoan;
        private System.Windows.Forms.Label lbl_Mat_Khau;
        private System.Windows.Forms.TextBox txt_Tai_Khoan;
        private System.Windows.Forms.TextBox txt_Mat_Khau;
        private System.Windows.Forms.Button btn_Đang_Nhap;
        private System.Windows.Forms.Button btn_Quen_Mat_Khau;
        private System.Windows.Forms.Button btn_Thoat;
        private System.Windows.Forms.ComboBox cmb_Chuc_Vu;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.LinkLabel lib_Quen_Mat_Kau;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

