namespace SkillExcel
{
    partial class AddCharacter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCharacter));
            this.Name_txtBox = new System.Windows.Forms.TextBox();
            this.Add_Btn = new System.Windows.Forms.Button();
            this.Cancel_Btn = new System.Windows.Forms.Button();
            this.Team_comboBox = new System.Windows.Forms.ComboBox();
            this.img_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Name_txtBox
            // 
            this.Name_txtBox.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.Name_txtBox.Location = new System.Drawing.Point(65, 129);
            this.Name_txtBox.Name = "Name_txtBox";
            this.Name_txtBox.Size = new System.Drawing.Size(179, 27);
            this.Name_txtBox.TabIndex = 0;
            // 
            // Add_Btn
            // 
            this.Add_Btn.Location = new System.Drawing.Point(65, 181);
            this.Add_Btn.Name = "Add_Btn";
            this.Add_Btn.Size = new System.Drawing.Size(75, 34);
            this.Add_Btn.TabIndex = 1;
            this.Add_Btn.Text = "확인";
            this.Add_Btn.UseVisualStyleBackColor = true;
            this.Add_Btn.Click += new System.EventHandler(this.Add_Btn_Click);
            // 
            // Cancel_Btn
            // 
            this.Cancel_Btn.Location = new System.Drawing.Point(169, 181);
            this.Cancel_Btn.Name = "Cancel_Btn";
            this.Cancel_Btn.Size = new System.Drawing.Size(75, 34);
            this.Cancel_Btn.TabIndex = 2;
            this.Cancel_Btn.Text = "취소";
            this.Cancel_Btn.UseVisualStyleBackColor = true;
            this.Cancel_Btn.Click += new System.EventHandler(this.Cancel_Btn_Click);
            // 
            // Team_comboBox
            // 
            this.Team_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Team_comboBox.FormattingEnabled = true;
            this.Team_comboBox.Location = new System.Drawing.Point(65, 81);
            this.Team_comboBox.Name = "Team_comboBox";
            this.Team_comboBox.Size = new System.Drawing.Size(179, 25);
            this.Team_comboBox.TabIndex = 3;
            // 
            // img_btn
            // 
            this.img_btn.Location = new System.Drawing.Point(222, 29);
            this.img_btn.Name = "img_btn";
            this.img_btn.Size = new System.Drawing.Size(75, 28);
            this.img_btn.TabIndex = 4;
            this.img_btn.Text = "이미지";
            this.img_btn.UseVisualStyleBackColor = true;
            this.img_btn.Visible = false;
            this.img_btn.Click += new System.EventHandler(this.img_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 5;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(190, 39);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(26, 18);
            this.pictureBox.TabIndex = 6;
            this.pictureBox.TabStop = false;
            this.pictureBox.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 9.134328F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.IndianRed;
            this.label2.Location = new System.Drawing.Point(30, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "*png 이미지만 가능";
            this.label2.Visible = false;
            // 
            // AddCharacter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 244);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.img_btn);
            this.Controls.Add(this.Team_comboBox);
            this.Controls.Add(this.Cancel_Btn);
            this.Controls.Add(this.Add_Btn);
            this.Controls.Add(this.Name_txtBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "AddCharacter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "캐릭터 추가";
            this.Load += new System.EventHandler(this.AddCharacter_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddCharacter_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Name_txtBox;
        private System.Windows.Forms.Button Add_Btn;
        private System.Windows.Forms.Button Cancel_Btn;
        private System.Windows.Forms.ComboBox Team_comboBox;
        private System.Windows.Forms.Button img_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label2;
    }
}