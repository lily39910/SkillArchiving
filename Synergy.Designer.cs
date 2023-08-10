namespace SkillExcel
{
    partial class Synergy
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Synergy));
            this.addSng_Btn = new System.Windows.Forms.Button();
            this.sng_dataGridView = new System.Windows.Forms.DataGridView();
            this.coolTime_chk = new System.Windows.Forms.CheckBox();
            this.Evol_chk = new System.Windows.Forms.CheckBox();
            this.stack_chk = new System.Windows.Forms.CheckBox();
            this.all_chk = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.sng_dataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // addSng_Btn
            // 
            this.addSng_Btn.Location = new System.Drawing.Point(1183, 31);
            this.addSng_Btn.Margin = new System.Windows.Forms.Padding(4);
            this.addSng_Btn.Name = "addSng_Btn";
            this.addSng_Btn.Size = new System.Drawing.Size(112, 33);
            this.addSng_Btn.TabIndex = 0;
            this.addSng_Btn.Text = "시너지 추가";
            this.addSng_Btn.UseVisualStyleBackColor = true;
            this.addSng_Btn.Click += new System.EventHandler(this.addSng_Btn_Click);
            // 
            // sng_dataGridView
            // 
            this.sng_dataGridView.AllowUserToAddRows = false;
            this.sng_dataGridView.AllowUserToDeleteRows = false;
            this.sng_dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.sng_dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.sng_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9.134328F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sng_dataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.sng_dataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sng_dataGridView.Location = new System.Drawing.Point(0, 139);
            this.sng_dataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.sng_dataGridView.Name = "sng_dataGridView";
            this.sng_dataGridView.ReadOnly = true;
            this.sng_dataGridView.RowHeadersWidth = 57;
            this.sng_dataGridView.RowTemplate.Height = 23;
            this.sng_dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sng_dataGridView.Size = new System.Drawing.Size(1320, 496);
            this.sng_dataGridView.TabIndex = 1;
            this.sng_dataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.sng_dataGridView_CellMouseClick);
            // 
            // coolTime_chk
            // 
            this.coolTime_chk.AutoSize = true;
            this.coolTime_chk.Location = new System.Drawing.Point(81, 26);
            this.coolTime_chk.Name = "coolTime_chk";
            this.coolTime_chk.Size = new System.Drawing.Size(81, 21);
            this.coolTime_chk.TabIndex = 2;
            this.coolTime_chk.Text = "쿨타임";
            this.coolTime_chk.UseVisualStyleBackColor = true;
            this.coolTime_chk.CheckedChanged += new System.EventHandler(this.coolTime_chk_CheckedChanged);
            // 
            // Evol_chk
            // 
            this.Evol_chk.AutoSize = true;
            this.Evol_chk.Location = new System.Drawing.Point(168, 26);
            this.Evol_chk.Name = "Evol_chk";
            this.Evol_chk.Size = new System.Drawing.Size(64, 21);
            this.Evol_chk.TabIndex = 3;
            this.Evol_chk.Text = "강화";
            this.Evol_chk.UseVisualStyleBackColor = true;
            this.Evol_chk.CheckedChanged += new System.EventHandler(this.Evol_chk_CheckedChanged);
            // 
            // stack_chk
            // 
            this.stack_chk.AutoSize = true;
            this.stack_chk.Location = new System.Drawing.Point(238, 26);
            this.stack_chk.Name = "stack_chk";
            this.stack_chk.Size = new System.Drawing.Size(64, 21);
            this.stack_chk.TabIndex = 4;
            this.stack_chk.Text = "스택";
            this.stack_chk.UseVisualStyleBackColor = true;
            this.stack_chk.CheckedChanged += new System.EventHandler(this.stack_chk_CheckedChanged);
            // 
            // all_chk
            // 
            this.all_chk.AutoSize = true;
            this.all_chk.Checked = true;
            this.all_chk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.all_chk.Location = new System.Drawing.Point(11, 26);
            this.all_chk.Name = "all_chk";
            this.all_chk.Size = new System.Drawing.Size(64, 21);
            this.all_chk.TabIndex = 5;
            this.all_chk.Text = "전체";
            this.all_chk.UseVisualStyleBackColor = true;
            this.all_chk.CheckedChanged += new System.EventHandler(this.all_chk_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.all_chk);
            this.groupBox1.Controls.Add(this.coolTime_chk);
            this.groupBox1.Controls.Add(this.stack_chk);
            this.groupBox1.Controls.Add(this.Evol_chk);
            this.groupBox1.Location = new System.Drawing.Point(835, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 67);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "검색 조건";
            // 
            // Synergy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1320, 635);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.sng_dataGridView);
            this.Controls.Add(this.addSng_Btn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Synergy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "시너지 효과";
            this.Load += new System.EventHandler(this.Synergy_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Synergy_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.sng_dataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addSng_Btn;
        private System.Windows.Forms.DataGridView sng_dataGridView;
        private System.Windows.Forms.CheckBox coolTime_chk;
        private System.Windows.Forms.CheckBox Evol_chk;
        private System.Windows.Forms.CheckBox stack_chk;
        private System.Windows.Forms.CheckBox all_chk;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}