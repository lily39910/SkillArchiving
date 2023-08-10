namespace SkillExcel
{
    partial class Skill
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Skill));
            this.character_dataGridView = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.skill_tabPage = new System.Windows.Forms.TabPage();
            this.skill_dataGridView = new System.Windows.Forms.DataGridView();
            this.character_tabPage = new System.Windows.Forms.TabPage();
            this.charInfo_Btn = new System.Windows.Forms.Button();
            this.charInfo_textBox = new System.Windows.Forms.TextBox();
            this.char_pictureBox = new System.Windows.Forms.PictureBox();
            this.createGroup_Btn = new System.Windows.Forms.Button();
            this.search_txtBox = new System.Windows.Forms.TextBox();
            this.search_Btn = new System.Windows.Forms.Button();
            this.search_comboBox = new System.Windows.Forms.ComboBox();
            this.language_ComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.character_dataGridView)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.skill_tabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skill_dataGridView)).BeginInit();
            this.character_tabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.char_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // character_dataGridView
            // 
            this.character_dataGridView.AllowUserToAddRows = false;
            this.character_dataGridView.AllowUserToDeleteRows = false;
            this.character_dataGridView.AllowUserToResizeColumns = false;
            this.character_dataGridView.AllowUserToResizeRows = false;
            this.character_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.character_dataGridView.ColumnHeadersVisible = false;
            this.character_dataGridView.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.character_dataGridView.Location = new System.Drawing.Point(160, 47);
            this.character_dataGridView.MultiSelect = false;
            this.character_dataGridView.Name = "character_dataGridView";
            this.character_dataGridView.ReadOnly = true;
            this.character_dataGridView.RowHeadersVisible = false;
            this.character_dataGridView.RowHeadersWidth = 57;
            this.character_dataGridView.RowTemplate.Height = 29;
            this.character_dataGridView.Size = new System.Drawing.Size(891, 164);
            this.character_dataGridView.TabIndex = 0;
            this.character_dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.character_dataGridView_CellClick);
            this.character_dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.character_dataGridView_CellDoubleClick);
            this.character_dataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.character_dataGridView_CellMouseClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.skill_tabPage);
            this.tabControl1.Controls.Add(this.character_tabPage);
            this.tabControl1.Location = new System.Drawing.Point(160, 283);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1162, 380);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // skill_tabPage
            // 
            this.skill_tabPage.Controls.Add(this.skill_dataGridView);
            this.skill_tabPage.Location = new System.Drawing.Point(4, 27);
            this.skill_tabPage.Name = "skill_tabPage";
            this.skill_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.skill_tabPage.Size = new System.Drawing.Size(1154, 349);
            this.skill_tabPage.TabIndex = 0;
            this.skill_tabPage.Text = "스킬 목록";
            this.skill_tabPage.UseVisualStyleBackColor = true;
            // 
            // skill_dataGridView
            // 
            this.skill_dataGridView.AllowUserToAddRows = false;
            this.skill_dataGridView.AllowUserToDeleteRows = false;
            this.skill_dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.skill_dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.skill_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9.134328F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.skill_dataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.skill_dataGridView.Location = new System.Drawing.Point(6, 6);
            this.skill_dataGridView.Name = "skill_dataGridView";
            this.skill_dataGridView.ReadOnly = true;
            this.skill_dataGridView.RowHeadersWidth = 57;
            this.skill_dataGridView.RowTemplate.Height = 29;
            this.skill_dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.skill_dataGridView.Size = new System.Drawing.Size(1142, 337);
            this.skill_dataGridView.TabIndex = 0;
            this.skill_dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.skill_dataGridView_CellDoubleClick);
            this.skill_dataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.skill_dataGridView_CellFormatting);
            this.skill_dataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.skill_dataGridView_CellMouseClick);
            // 
            // character_tabPage
            // 
            this.character_tabPage.Controls.Add(this.charInfo_Btn);
            this.character_tabPage.Controls.Add(this.charInfo_textBox);
            this.character_tabPage.Controls.Add(this.char_pictureBox);
            this.character_tabPage.Location = new System.Drawing.Point(4, 27);
            this.character_tabPage.Name = "character_tabPage";
            this.character_tabPage.Padding = new System.Windows.Forms.Padding(10);
            this.character_tabPage.Size = new System.Drawing.Size(1154, 349);
            this.character_tabPage.TabIndex = 1;
            this.character_tabPage.Text = "캐릭터 정보";
            this.character_tabPage.UseVisualStyleBackColor = true;
            // 
            // charInfo_Btn
            // 
            this.charInfo_Btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.charInfo_Btn.Location = new System.Drawing.Point(1069, 10);
            this.charInfo_Btn.Name = "charInfo_Btn";
            this.charInfo_Btn.Size = new System.Drawing.Size(75, 329);
            this.charInfo_Btn.TabIndex = 2;
            this.charInfo_Btn.Text = "입력";
            this.charInfo_Btn.UseVisualStyleBackColor = true;
            this.charInfo_Btn.Click += new System.EventHandler(this.charInfo_Btn_Click);
            // 
            // charInfo_textBox
            // 
            this.charInfo_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.charInfo_textBox.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.charInfo_textBox.Location = new System.Drawing.Point(763, 13);
            this.charInfo_textBox.Multiline = true;
            this.charInfo_textBox.Name = "charInfo_textBox";
            this.charInfo_textBox.ReadOnly = true;
            this.charInfo_textBox.Size = new System.Drawing.Size(300, 323);
            this.charInfo_textBox.TabIndex = 1;
            // 
            // char_pictureBox
            // 
            this.char_pictureBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.char_pictureBox.Location = new System.Drawing.Point(10, 10);
            this.char_pictureBox.Name = "char_pictureBox";
            this.char_pictureBox.Size = new System.Drawing.Size(198, 329);
            this.char_pictureBox.TabIndex = 0;
            this.char_pictureBox.TabStop = false;
            // 
            // createGroup_Btn
            // 
            this.createGroup_Btn.Location = new System.Drawing.Point(1057, 47);
            this.createGroup_Btn.Name = "createGroup_Btn";
            this.createGroup_Btn.Size = new System.Drawing.Size(109, 32);
            this.createGroup_Btn.TabIndex = 2;
            this.createGroup_Btn.Text = "팀 추가";
            this.createGroup_Btn.UseVisualStyleBackColor = true;
            this.createGroup_Btn.Click += new System.EventHandler(this.createGroup_Btn_Click);
            // 
            // search_txtBox
            // 
            this.search_txtBox.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.search_txtBox.Location = new System.Drawing.Point(282, 242);
            this.search_txtBox.Name = "search_txtBox";
            this.search_txtBox.Size = new System.Drawing.Size(237, 27);
            this.search_txtBox.TabIndex = 3;
            this.search_txtBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.search_txtBox_KeyDown);
            // 
            // search_Btn
            // 
            this.search_Btn.Location = new System.Drawing.Point(525, 242);
            this.search_Btn.Name = "search_Btn";
            this.search_Btn.Size = new System.Drawing.Size(75, 27);
            this.search_Btn.TabIndex = 5;
            this.search_Btn.Text = "검색";
            this.search_Btn.UseVisualStyleBackColor = true;
            this.search_Btn.Click += new System.EventHandler(this.search_Btn_Click);
            // 
            // search_comboBox
            // 
            this.search_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.search_comboBox.FormattingEnabled = true;
            this.search_comboBox.Items.AddRange(new object[] {
            "스킬명",
            "시너지",
            "기능",
            "코멘트"});
            this.search_comboBox.Location = new System.Drawing.Point(160, 244);
            this.search_comboBox.Name = "search_comboBox";
            this.search_comboBox.Size = new System.Drawing.Size(116, 25);
            this.search_comboBox.TabIndex = 6;
            // 
            // language_ComboBox
            // 
            this.language_ComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.language_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.language_ComboBox.FormattingEnabled = true;
            this.language_ComboBox.Items.AddRange(new object[] {
            "KOREAN",
            "ENGLISH"});
            this.language_ComboBox.Location = new System.Drawing.Point(1197, 12);
            this.language_ComboBox.Name = "language_ComboBox";
            this.language_ComboBox.Size = new System.Drawing.Size(121, 25);
            this.language_ComboBox.TabIndex = 7;
            this.language_ComboBox.SelectedIndexChanged += new System.EventHandler(this.language_ComboBox_SelectedIndexChanged);
            // 
            // Skill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 675);
            this.Controls.Add(this.language_ComboBox);
            this.Controls.Add(this.search_comboBox);
            this.Controls.Add(this.search_Btn);
            this.Controls.Add(this.search_txtBox);
            this.Controls.Add(this.createGroup_Btn);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.character_dataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Skill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "클로저스 스킬";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Skill_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.character_dataGridView)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.skill_tabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.skill_dataGridView)).EndInit();
            this.character_tabPage.ResumeLayout(false);
            this.character_tabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.char_pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView character_dataGridView;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage skill_tabPage;
        private System.Windows.Forms.TabPage character_tabPage;
        private System.Windows.Forms.Button createGroup_Btn;
        private System.Windows.Forms.TextBox search_txtBox;
        private System.Windows.Forms.Button search_Btn;
        private System.Windows.Forms.DataGridView skill_dataGridView;
        private System.Windows.Forms.ComboBox search_comboBox;
        private System.Windows.Forms.PictureBox char_pictureBox;
        private System.Windows.Forms.TextBox charInfo_textBox;
        private System.Windows.Forms.Button charInfo_Btn;
        private System.Windows.Forms.ComboBox language_ComboBox;
    }
}

