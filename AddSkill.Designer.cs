namespace SkillExcel
{
    partial class AddSkill
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSkill));
            this.Img_Btn = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.skillName_textBox = new System.Windows.Forms.TextBox();
            this.save_btn = new System.Windows.Forms.Button();
            this.edit_Btn = new System.Windows.Forms.Button();
            this.del_Btn = new System.Windows.Forms.Button();
            this.skillFunction_textBox = new System.Windows.Forms.TextBox();
            this.skillRank_textBox = new System.Windows.Forms.TextBox();
            this.skillEvol_comboBox = new System.Windows.Forms.ComboBox();
            this.skillOptionCube_comboBox = new System.Windows.Forms.ComboBox();
            this.skillAwakeCube_comboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.imgLabel = new System.Windows.Forms.Label();
            this.newLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Img_Btn
            // 
            this.Img_Btn.Location = new System.Drawing.Point(232, 185);
            this.Img_Btn.Name = "Img_Btn";
            this.Img_Btn.Size = new System.Drawing.Size(113, 28);
            this.Img_Btn.TabIndex = 0;
            this.Img_Btn.Text = "이미지 등록";
            this.Img_Btn.UseVisualStyleBackColor = true;
            this.Img_Btn.Click += new System.EventHandler(this.Img_Btn_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(232, 81);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(144, 98);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // skillName_textBox
            // 
            this.skillName_textBox.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.skillName_textBox.Location = new System.Drawing.Point(232, 247);
            this.skillName_textBox.Name = "skillName_textBox";
            this.skillName_textBox.Size = new System.Drawing.Size(183, 27);
            this.skillName_textBox.TabIndex = 1;
            // 
            // save_btn
            // 
            this.save_btn.Location = new System.Drawing.Point(267, 649);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(75, 37);
            this.save_btn.TabIndex = 7;
            this.save_btn.Text = "등록";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // edit_Btn
            // 
            this.edit_Btn.Location = new System.Drawing.Point(348, 649);
            this.edit_Btn.Name = "edit_Btn";
            this.edit_Btn.Size = new System.Drawing.Size(75, 37);
            this.edit_Btn.TabIndex = 8;
            this.edit_Btn.Text = "수정";
            this.edit_Btn.UseVisualStyleBackColor = true;
            this.edit_Btn.Click += new System.EventHandler(this.edit_Btn_Click);
            // 
            // del_Btn
            // 
            this.del_Btn.Location = new System.Drawing.Point(429, 649);
            this.del_Btn.Name = "del_Btn";
            this.del_Btn.Size = new System.Drawing.Size(75, 37);
            this.del_Btn.TabIndex = 9;
            this.del_Btn.Text = "삭제";
            this.del_Btn.UseVisualStyleBackColor = true;
            this.del_Btn.Visible = false;
            this.del_Btn.Click += new System.EventHandler(this.del_Btn_Click);
            // 
            // skillFunction_textBox
            // 
            this.skillFunction_textBox.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.skillFunction_textBox.Location = new System.Drawing.Point(232, 515);
            this.skillFunction_textBox.Multiline = true;
            this.skillFunction_textBox.Name = "skillFunction_textBox";
            this.skillFunction_textBox.Size = new System.Drawing.Size(399, 105);
            this.skillFunction_textBox.TabIndex = 6;
            // 
            // skillRank_textBox
            // 
            this.skillRank_textBox.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.skillRank_textBox.Location = new System.Drawing.Point(232, 295);
            this.skillRank_textBox.Name = "skillRank_textBox";
            this.skillRank_textBox.Size = new System.Drawing.Size(183, 27);
            this.skillRank_textBox.TabIndex = 2;
            // 
            // skillEvol_comboBox
            // 
            this.skillEvol_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skillEvol_comboBox.FormattingEnabled = true;
            this.skillEvol_comboBox.Items.AddRange(new object[] {
            "",
            "EX 진화 스킬",
            "EX 진화 가능 스킬"});
            this.skillEvol_comboBox.Location = new System.Drawing.Point(232, 345);
            this.skillEvol_comboBox.Name = "skillEvol_comboBox";
            this.skillEvol_comboBox.Size = new System.Drawing.Size(183, 25);
            this.skillEvol_comboBox.TabIndex = 3;
            // 
            // skillOptionCube_comboBox
            // 
            this.skillOptionCube_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skillOptionCube_comboBox.FormattingEnabled = true;
            this.skillOptionCube_comboBox.Items.AddRange(new object[] {
            "옵션 큐브 O",
            "옵션 큐브 X"});
            this.skillOptionCube_comboBox.Location = new System.Drawing.Point(232, 396);
            this.skillOptionCube_comboBox.Name = "skillOptionCube_comboBox";
            this.skillOptionCube_comboBox.Size = new System.Drawing.Size(183, 25);
            this.skillOptionCube_comboBox.TabIndex = 4;
            // 
            // skillAwakeCube_comboBox
            // 
            this.skillAwakeCube_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skillAwakeCube_comboBox.FormattingEnabled = true;
            this.skillAwakeCube_comboBox.Items.AddRange(new object[] {
            "각성 큐브 O",
            "각성 큐브 X",
            "각성 스킬"});
            this.skillAwakeCube_comboBox.Location = new System.Drawing.Point(232, 445);
            this.skillAwakeCube_comboBox.Name = "skillAwakeCube_comboBox";
            this.skillAwakeCube_comboBox.Size = new System.Drawing.Size(183, 25);
            this.skillAwakeCube_comboBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 10.20895F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(129, 249);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 19);
            this.label1.TabIndex = 10;
            this.label1.Text = "스킬 이름";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 10.20895F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(129, 297);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 19);
            this.label2.TabIndex = 11;
            this.label2.Text = "스킬 직급";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 10.20895F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(101, 348);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 19);
            this.label3.TabIndex = 12;
            this.label3.Text = "EX 진화 여부";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 10.20895F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(129, 398);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 19);
            this.label4.TabIndex = 13;
            this.label4.Text = "옵션 큐브";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 10.20895F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(129, 447);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 19);
            this.label5.TabIndex = 14;
            this.label5.Text = "각성 큐브";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 10.20895F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(173, 517);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 19);
            this.label6.TabIndex = 15;
            this.label6.Text = "기능";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("굴림", 16.1194F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(24, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 30);
            this.label7.TabIndex = 16;
            this.label7.Text = "캐릭터명";
            // 
            // imgLabel
            // 
            this.imgLabel.AutoSize = true;
            this.imgLabel.Font = new System.Drawing.Font("굴림", 9.134328F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.imgLabel.ForeColor = System.Drawing.Color.IndianRed;
            this.imgLabel.Location = new System.Drawing.Point(229, 148);
            this.imgLabel.Name = "imgLabel";
            this.imgLabel.Size = new System.Drawing.Size(166, 17);
            this.imgLabel.TabIndex = 17;
            this.imgLabel.Text = "*png 이미지만 가능";
            // 
            // newLabel
            // 
            this.newLabel.AutoSize = true;
            this.newLabel.Location = new System.Drawing.Point(238, 113);
            this.newLabel.Name = "newLabel";
            this.newLabel.Size = new System.Drawing.Size(0, 17);
            this.newLabel.TabIndex = 18;
            this.newLabel.Visible = false;
            // 
            // AddSkill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 714);
            this.Controls.Add(this.newLabel);
            this.Controls.Add(this.imgLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.skillAwakeCube_comboBox);
            this.Controls.Add(this.skillOptionCube_comboBox);
            this.Controls.Add(this.skillEvol_comboBox);
            this.Controls.Add(this.skillRank_textBox);
            this.Controls.Add(this.skillFunction_textBox);
            this.Controls.Add(this.del_Btn);
            this.Controls.Add(this.edit_Btn);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.skillName_textBox);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.Img_Btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddSkill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "스킬 등록";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddSkill_FormClosing);
            this.Load += new System.EventHandler(this.AddSkill_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddSkill_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Img_Btn;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox skillName_textBox;
        private System.Windows.Forms.TextBox skillFunction_textBox;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Button edit_Btn;
        private System.Windows.Forms.Button del_Btn;
        private System.Windows.Forms.TextBox skillRank_textBox;
        private System.Windows.Forms.ComboBox skillEvol_comboBox;
        private System.Windows.Forms.ComboBox skillOptionCube_comboBox;
        private System.Windows.Forms.ComboBox skillAwakeCube_comboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label imgLabel;
        private System.Windows.Forms.Label newLabel;
    }
}