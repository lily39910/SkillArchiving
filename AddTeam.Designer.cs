namespace SkillExcel
{
    partial class AddTeam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTeam));
            this.teamName_txt = new System.Windows.Forms.TextBox();
            this.add_Btn = new System.Windows.Forms.Button();
            this.Cancel_Btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // teamName_txt
            // 
            this.teamName_txt.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.teamName_txt.Location = new System.Drawing.Point(70, 36);
            this.teamName_txt.Name = "teamName_txt";
            this.teamName_txt.Size = new System.Drawing.Size(206, 27);
            this.teamName_txt.TabIndex = 0;
            // 
            // add_Btn
            // 
            this.add_Btn.Location = new System.Drawing.Point(70, 90);
            this.add_Btn.Name = "add_Btn";
            this.add_Btn.Size = new System.Drawing.Size(75, 31);
            this.add_Btn.TabIndex = 1;
            this.add_Btn.Text = "등록";
            this.add_Btn.UseVisualStyleBackColor = true;
            this.add_Btn.Click += new System.EventHandler(this.add_Btn_Click);
            // 
            // Cancel_Btn
            // 
            this.Cancel_Btn.Location = new System.Drawing.Point(151, 90);
            this.Cancel_Btn.Name = "Cancel_Btn";
            this.Cancel_Btn.Size = new System.Drawing.Size(75, 31);
            this.Cancel_Btn.TabIndex = 2;
            this.Cancel_Btn.Text = "취소";
            this.Cancel_Btn.UseVisualStyleBackColor = true;
            this.Cancel_Btn.Click += new System.EventHandler(this.Cancel_Btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "팀명 : ";
            // 
            // AddTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 145);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cancel_Btn);
            this.Controls.Add(this.add_Btn);
            this.Controls.Add(this.teamName_txt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "AddTeam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "팀 추가";
            this.Load += new System.EventHandler(this.AddTeam_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddTeam_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox teamName_txt;
        private System.Windows.Forms.Button add_Btn;
        private System.Windows.Forms.Button Cancel_Btn;
        private System.Windows.Forms.Label label1;
    }
}