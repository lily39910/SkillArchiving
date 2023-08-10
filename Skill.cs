using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Runtime.InteropServices;
using Point = System.Drawing.Point;

//네트워크 접근 권한
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;


namespace SkillExcel
{
    public partial class Skill : Form
    {
        //네트워크 Connection
        NetworkConnector net = new NetworkConnector();
        public void ConnectionNetworkDrive()
        {
            string ip = @"\\10.80.251.201\\넥슨네트웍스 퍼블리싱qa2팀\\3. 클로저스\\[클로저스] 스킬 아카이빙 프로그램$";
            
            net.ConnectRemoteServer(ip);
            /*
            while (true)
            {
                int state = net.TryConnectionNetwork(ip);
                
                if(TryConnectResult(state) == true)
                {
                    MessageBox.Show(string.Format("start folder Connect. {0}", ip));
                }
                else
                {
                    MessageBox.Show("Fail " + ip);
                }
                break;
            }
            */
        }

        /*
        public bool TryConnectResult(int state)
        {
            bool result = true;

            if(state == 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }
        */

        ////////////////////////////////////////////////////////
        
        DateTime today = DateTime.Today; //날짜

        string language = "KOREAN";//
        public string name;//이름
        string skillName; //스킬명
        string teamName; //팀명

        string fileName; //엑셀 파일명
        string filePath;// 엑셀파일 경로
        DBClass db;        // DBClass 변수
        System.Data.DataTable dt;		// 데이터테이블 변수

        public EventHandler AddSkillHandler;
        public EventHandler AddCharHandler;


        //캐릭터 정보
        class characterInfo
        {
            //DB
            public string charName;
            public string charInfo;
        }

        public Skill()
        {
            InitializeComponent();

            //네트워크
            this.Load += Form1_Load;


            //콤보박스 기본 검색 값 스킬명
            search_comboBox.SelectedIndex = 0;
            language_ComboBox.SelectedIndex = 0;

            //filePath = $"{Environment.CurrentDirectory}";
            //넥슨 경로
            filePath = "\\\\10.80.251.201\\넥슨네트웍스 퍼블리싱qa2팀\\3. 클로저스\\[클로저스] 스킬 아카이빙 프로그램";
            fileName = "\\Skill.xlsx";
            
            db = new DBClass(filePath, fileName); // 생성자에 매개변수를 넘기면서 객체생성
            dt = new System.Data.DataTable(); // 객체생성
            //dt = db.Read(qry); // 데이터테이블 형식으로 받아옴
            //character_dataGridView.DataSource = dt; //데이터그리드 뷰에 뿌림

        }

        private void Skill_SizeChanged(object sender, EventArgs e)
        {
            int tabX = tabControl1.Location.X;
            int tabY = tabControl1.Location.Y;

            int gridX = skill_dataGridView.Location.X;   //그리드컨트롤의 시작 X 좌표
            int gridY = skill_dataGridView.Location.Y;   //그리드컨트롤의 시작 Y 좌표

            tabControl1.Width = this.Width - (gridX + 200); // 보기 좋게 적당한 사이즈로 계산
            tabControl1.Height = this.Height - (gridY + 250); // 보기 좋게 적당한 사이즈로 계산

            skill_dataGridView.Width = this.Width - (gridX + 220); // 보기 좋게 적당한 사이즈로 계산
            skill_dataGridView.Height = this.Height - (gridY + 280); // 보기 좋게 적당한 사이즈로 계산




            char_pictureBox.Width = this.Width - (gridX + 460);
            char_pictureBox.Height = this.Height - (gridY + 230);

        }

        private void refreshSkillGridview()
        {
            string qry = "";

            qry = "SELECT * " +
                     "FROM ["+ name +"$]";
            
            dt = db.Read(qry); // 데이터테이블 형식으로 받아옴
            skill_dataGridView.DataSource = dt;
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                String img_path = $"{Environment.CurrentDirectory}" + "\\image\\" + name + "\\";

                String img_name = skill_dataGridView[1, i].Value.ToString().Replace(":", "_");

                bool fileExist = File.Exists(img_path + img_name + ".png");
                if (fileExist)
                {
                    //File exist
                    skill_dataGridView[0, i].Value = Image.FromFile(@"" + img_path + img_name + ".png");
                }
                else
                {
                    skill_dataGridView[0, i].Value = null;
                }

            }
            //full 사이즈 일 때 컬럼 사이즈
            skill_dataGridView.Columns[0].Width = 80;
            skill_dataGridView.Columns[1].Width = 150;
            skill_dataGridView.Columns[2].Width = 75;
            skill_dataGridView.Columns[3].Width = 120;
            skill_dataGridView.Columns[4].Width = 80;
            skill_dataGridView.Columns[5].Width = 80;
        }

        private void refreshCharGridview()
        {
            string qry = "";
            qry = "SELECT * " +
                     "FROM [직업 그룹$]";

            dt = db.Read(qry); // 데이터테이블 형식으로 받아옴

            character_dataGridView.DataSource = dt; //데이터그리드 뷰에 뿌림
            character_dataGridView.Columns[0].DefaultCellStyle.BackColor = Color.LightBlue;

            character_dataGridView.ClearSelection();
     
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //네트워크 드라이브 접근
            ConnectionNetworkDrive();

            refreshCharGridview();
            
            /*
            //이미지
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            skill_dataGridView.Columns.Add(img);
            img.HeaderText = "스킬 이미지";
            img.ImageLayout = DataGridViewImageCellLayout.Normal;//Stretch;
            */

            skill_dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            skill_dataGridView.RowTemplate.Height = 70;
            skill_dataGridView.Columns[0].Width = 70;

            //화면 초기값
            int tabX = tabControl1.Location.X;
            int tabY = tabControl1.Location.Y;

            int gridX = skill_dataGridView.Location.X;   //그리드컨트롤의 시작 X 좌표
            int gridY = skill_dataGridView.Location.Y;   //그리드컨트롤의 시작 Y 좌표

            tabControl1.Width = this.Width - (gridX + 200); // 보기 좋게 적당한 사이즈로 계산
            tabControl1.Height = this.Height - (gridY + 250); // 보기 좋게 적당한 사이즈로 계산

            skill_dataGridView.Width = this.Width - (gridX + 220); // 보기 좋게 적당한 사이즈로 계산
            skill_dataGridView.Height = this.Height - (gridY + 280); // 보기 좋게 적당한 사이즈로 계산


            char_pictureBox.Width = this.Width - (gridX + 460);
            char_pictureBox.Height = this.Height - (gridY + 230);

        }

        private void character_dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            //스킬 추가 및 캐릭터 추가
            if (e.ColumnIndex == 0)
            {
                teamName = character_dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                //캐릭터 추가
                AddCharacter addChar = new AddCharacter();
                AddCharacter.tName = teamName;
                addChar.ShowDialog();

                if(addChar.version == "addChar")
                {
                    AddCharHandler = new EventHandler(addChar.Add_Btn_Click);
                    AddCharHandler.Invoke("1", EventArgs.Empty);
                    AddSkillHandler = null;

                    refreshCharGridview();

                }
            }
            else
            {
                name = character_dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                //스킬 추가
                AddSkill addSk = new AddSkill();
                AddSkill.cName = name;
                AddSkill.sName = null;
                addSk.ShowDialog();
                
                if(addSk.version == "add")
                {
                    AddSkillHandler = new EventHandler(addSk.save_btn_Click);
                    AddSkillHandler.Invoke("1", EventArgs.Empty);
                    AddSkillHandler = null;

                    refreshSkillGridview();
                }

                
            }
            */
        }

        public void character_dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        //public void character_dataGridView_CellClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //캐릭터 스킬 검색
            /*
            //행
            int r = character_dataGridView.CurrentCell.RowIndex;
            //열
            int c = character_dataGridView.CurrentCell.ColumnIndex;
            */

            if (character_dataGridView.CurrentCell.Value.ToString() != "")
            {
                if (e.ColumnIndex != 0)
                {
                    
                    name = character_dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                    refreshSkillGridview();

                }
                else
                {
                    character_dataGridView.ClearSelection();
                    skill_dataGridView.DataSource = null;
                    skill_dataGridView.Refresh();
                    name = "";
                }
                skill_dataGridView.ClearSelection();

                Excel.Application excelApp = null;
                Excel.Workbook workBook = null;
                excelApp = new Excel.Application(); // 엑셀 어플리케이션 생성
                workBook = excelApp.Workbooks.Open(filePath + fileName);

                Worksheet workSheet = workBook.Worksheets.Item["캐릭터 정보"];
                
                charInfo_textBox.Text = "";
                charInfo_textBox.ReadOnly = true;
                charInfo_Btn.Text = "입력";
                
                string qry = "SELECT * " +
                 "FROM [캐릭터 정보$] " +
                 "WHERE [캐릭터명] Like '" + "%" + name + "%'";

                int range = workSheet.UsedRange.Rows.Count;

                for (int r = 3; r <= range + 1; r++)
                {
                    if (name == workSheet.Range["B" + r].Value)
                    {
                        charInfo_textBox.Text = workSheet.Range["C" + r].Value.ToString();
                    }
                }
                workBook.Close(true);
                excelApp.Quit();

            }
            else
            {
                MessageBox.Show("값이 없어요");
            }
            tabControl1.SelectedIndex = 0;


        }

       
        private void search_Btn_Click(object sender, EventArgs e)
        {
            string qry = "";
            
            if (name != null)
            {
                if(search_comboBox.SelectedIndex == 0)
                    {
                    //스킬명
                    qry = "SELECT * " +
                         "FROM [" + name + "$] " +
                         "WHERE [스킬 이름] Like '" + "%" + search_txtBox.Text + "%'";
                }
                    else if (search_comboBox.SelectedIndex == 1)
                {
                    //시너지
                    qry = "SELECT DISTINCT [" + name + "$].[스킬 이름], [스킬 직급], [EX 진화 여부], [옵션 큐브], [각성 큐브], [기능]" +
                        "FROM [" + name + "$] INNER JOIN [스킬시너지$] " +
                        "ON [스킬시너지$].[스킬 이름] = [" + name + "$].[스킬 이름]" +
                        "WHERE [캐릭터명] = '" + name + "'" +
                        "AND [영향 받는 스킬] Like '" + "%" + search_txtBox.Text + "%'" +
                        "OR [영향 주는 스킬] Like '" + "%" + search_txtBox.Text + "%'" +
                        "OR [영향 요약] Like '" + "%" + search_txtBox.Text + "%' ";
                }
                else if (search_comboBox.SelectedIndex == 2)
                {
                    //기능
                    qry = "SELECT * " +
                         "FROM [" + name + "$] " +
                         "WHERE [기능] Like '" + "%" + search_txtBox.Text + "%'";
                }
                else if (search_comboBox.SelectedIndex == 3)
                {
                    //코멘트
                    qry = "SELECT DISTINCT [" + name + "$].[스킬 이름], [스킬 직급], [EX 진화 여부], [옵션 큐브], [각성 큐브], [기능]" +
                        "FROM [" + name + "$] INNER JOIN [스킬시너지$] " +
                        "ON [스킬시너지$].[스킬 이름] = [" + name + "$].[스킬 이름]" +
                        "WHERE [캐릭터명] = '" + name + "'" +
                        "AND [스킬 관련 코멘트] Like '" + "%" + search_txtBox.Text + "%'";
                }




                dt = db.Read(qry); // 데이터테이블 형식으로 받아옴

                skill_dataGridView.DataSource = dt; //데이터그리드 뷰에 뿌림
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    String img_path = $"{Environment.CurrentDirectory}" + "\\image\\" + name + "\\";
                    String img_name = skill_dataGridView[1, i].Value.ToString().Replace(":", "_");

                    bool fileExist = File.Exists(img_path + img_name + ".png");
                    if (fileExist)
                    {
                        //File exist
                        skill_dataGridView[0, i].Value = Image.FromFile(@"" + img_path + img_name + ".png");
                    }
                    else
                    {
                        skill_dataGridView[0, i].Value = null;
                    }

                }
            }
            else
            {

                qry = "SELECT * " +
                             "FROM [" + name + "$] " +
                             "WHERE [스킬 이름] Like '" + "%" + search_txtBox.Text + "%'";
                MessageBox.Show("캐릭터를 선택해주세요.");
            }
            
        }

        //Enter 자동 검색
        private void search_txtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                search_Btn_Click(sender, e);
            }
        }

        public void createGroup_Btn_Click(object sender, EventArgs e)
        {
            AddTeam addTeam = new AddTeam();
            addTeam.ShowDialog();

            if(addTeam.version == "addTeam")
            {
                AddCharHandler = new EventHandler(addTeam.add_Btn_Click);
                AddCharHandler.Invoke("1", EventArgs.Empty);
                AddSkillHandler = null;
                refreshCharGridview();
            }


        }

        private void skill_dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1) //Header 제외
            {
                Synergy sng = new Synergy();
                Synergy.cName = name;

                skillName = skill_dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                Synergy.skillName = skillName;
                
                //sql문 특수문자 인식 x
                skillName = skillName.Replace("[", "[[]");

                string qry = "";
                qry = "SELECT * " +
                         "FROM [스킬시너지$] " +
                         "WHERE [캐릭터명] Like '" + name + "' " +
                         "AND [스킬 이름] Like '" + skillName + "' ";
                dt = db.Read(qry); // 데이터테이블 형식으로 받아옴

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("시너지 효과 없음");
                    Synergy.sng_dt = dt;
                    sng.ShowDialog();
                }
                else
                {
                    Synergy.sng_dt = dt;
                    sng.ShowDialog();
                }

            }

        }

        //스킬 순서정렬방지
        private void skill_dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewColumn item in skill_dataGridView.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void skill_Edit_Event(object sender, EventArgs e)
        {
            /* 메뉴 실행 */
            
            AddSkill addSk = new AddSkill();
            AddSkill.sName = skillName;
            AddSkill.cName = name;
            addSk.ShowDialog();

            if (addSk.version == "edit")
            {
                AddSkillHandler = new EventHandler(addSk.edit_Btn_Click);
                AddSkillHandler.Invoke("1", EventArgs.Empty);
                AddSkillHandler = null;

                refreshSkillGridview();
            }
        }

        private void skill_Delete_Event(object sender, EventArgs e)
        {
            string question = "";
            if (language == "KOREAN")
            {
                question = skillName + "을 정말 삭제하시겠습니까?";
            }
            else
            {
                question = "Delete " + skillName +"?";
            }
                //스킬 삭제
                //YESNO 확인 후 삭제 qry 실행
                if (MessageBox.Show(question, "Yes Or No", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Excel.Application excelApp = null;
                Excel.Workbook workBook = null;


                excelApp = new Excel.Application(); // 엑셀 어플리케이션 생성
                workBook = excelApp.Workbooks.Open(filePath + fileName, ReadOnly: false, Editable: true);
                
                Worksheet workSheet = null;

                for (int i = 1; i <= workBook.Worksheets.Count; i++)
                {
                    workSheet = workBook.Worksheets.Item[i];
                    if (workSheet.Name == name)
                    {
                        try
                        {
                            for (int r = 3; r <= workSheet.UsedRange.Rows.Count + 1; r++)
                            {
                                string skill = "";
                                skill = workSheet.Range["B" + r].Value;
                                if (skillName == skill)
                                {
                                    workSheet.Rows[r, Missing.Value].Delete();

                                    break;
                                }
                            }

                            workBook.Save();
                            workBook.Close(true);
                            excelApp.Quit();
                            break;//해당 데이터 찾은 경우 break;
                        }

                        finally
                        {
                            ReleaseObject(workSheet);
                            ReleaseObject(workBook);
                            ReleaseObject(excelApp);
                        }
                    }
                }
                if(language == "KOREAN")
                {
                    MessageBox.Show(skillName + " 가 삭제되었습니다.");
                }
                else
                {
                    MessageBox.Show(skillName + " has Deleted");
                }
                refreshSkillGridview();
                skillName = null;
            }
            else
            {
                if (language == "KOREAN")
                {
                    MessageBox.Show("삭제가 취소되었습니다.");
                }
                else
                {
                    MessageBox.Show("Delete has Canceled.");
                }
            }

        }

        private void skill_dataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                skillName = skill_dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();

                skill_dataGridView.ClearSelection();
                skill_dataGridView.Rows[e.RowIndex].Selected = true;

                DataGridView grid = sender as DataGridView;

                ContextMenuStrip menu = new ContextMenuStrip();
                if (language == "KOREAN")
                {
                    menu.Items.Add("수정", null, skill_Edit_Event);
                    menu.Items.Add("삭제", null, skill_Delete_Event);
                }
                else
                {
                    menu.Items.Add("Edit", null, skill_Edit_Event);
                    menu.Items.Add("Delete", null, skill_Delete_Event);
                }

                Point pt = grid.PointToClient(Control.MousePosition);

                menu.Show(skill_dataGridView, pt.X, pt.Y);
            }

            /*
            if (e.Button == MouseButtons.Right)
            {
                skillName = skill_dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                AddSkill addSk = new AddSkill();
                AddSkill.sName = skillName;
                AddSkill.cName = name;
                addSk.ShowDialog();

                if(addSk.version == "edit")
                {
                    AddSkillHandler = new EventHandler(addSk.edit_Btn_Click);
                    AddSkillHandler.Invoke("1", EventArgs.Empty);
                    AddSkillHandler = null;

                    refreshSkillGridview();
                }
                else if(addSk.version == "delete")
                {
                    AddSkillHandler = new EventHandler(addSk.del_Btn_Click);
                    AddSkillHandler.Invoke("1", EventArgs.Empty);
                    AddSkillHandler = null;

                    refreshSkillGridview();
                }   
            }
            */
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(name != null)
            {
                if (tabControl1.SelectedIndex == 1)
                {
                    String img_path = $"{Environment.CurrentDirectory}" + "\\character\\" + name;

                    bool fileExist = File.Exists(img_path + ".png");
                    if (fileExist)
                    {
                        Image img = Image.FromFile(@"" + img_path + ".png");
                        char_pictureBox.Image = img;

                        char_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                        
                    }
                    else
                    {
                        char_pictureBox.Image = null;
                    }


                }
            }
            else
            {
                if (tabControl1.SelectedIndex == 1)
                {
                    if (language == "KOREAN")
                    {
                        MessageBox.Show("캐릭터를 선택해주세요.");
                    }
                    else
                    {
                        MessageBox.Show("Select Character Please.");
                    }
                    tabControl1.SelectedIndex = 0;

                }
            }
            
        }

        private void charInfo_Btn_Click(object sender, EventArgs e)
        {
            if(charInfo_Btn.Text == "입력")
            {
                charInfo_Btn.Text = "저장";
                charInfo_textBox.ReadOnly = false;

            }
            else
            {
                Excel.Application excelApp = null;
                Excel.Workbook workBook = null;


                excelApp = new Excel.Application(); // 엑셀 어플리케이션 생성
                workBook = excelApp.Workbooks.Open(filePath + fileName, ReadOnly: false, Editable: true);
                Worksheet workSheet = workBook.Worksheets.Item["캐릭터 정보"];

                try
                {
                    // 엑셀에 저장할 개 데이터
                    List<characterInfo> infos = new List<characterInfo>();

                    infos.Add(new characterInfo()
                    {
                        charName = name,
                        charInfo = charInfo_textBox.Text
                    }); ;

                    

                    int range = workSheet.UsedRange.Rows.Count;
                    if(range == 1)
                    {
                        range = 3;
                    }
                    
                    for (int r = 3; r <= range + 1; r++)
                    {
                        characterInfo info = infos[0];
                        //스킬명과 이름이 같을 경우 찾기
                        if (name == workSheet.Range["B" + r].Value)
                        {
                            workSheet.Range["C" + r].Value = info.charInfo;
                            break; //error 가능
                        }
                        else
                        {
                            workSheet.Range["B" + r].Value = info.charName;
                            workSheet.Range["C" + r].Value = info.charInfo;
                            break;
                        }
                    }

                    workSheet.Columns.AutoFit();// 열 너비 자동 맞춤

                    workBook.Save();
                    workBook.Close(true);
                    excelApp.Quit();
                }
                finally
                {
                    ReleaseObject(workSheet);
                    ReleaseObject(workBook);
                    ReleaseObject(excelApp);
                }

                MessageBox.Show("캐릭터 정보가 등록되었습니다.");
                
                charInfo_Btn.Text = "입력";
                charInfo_textBox.ReadOnly = true;
            }
        }


        static void ReleaseObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj);  // 액셀 객체 해제
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                obj = null;
                throw ex;
            }
            finally
            {
                GC.Collect();   // 가비지 수집
            }
        }

        private void character_dataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.ColumnIndex == 0)
                {
                    teamName = character_dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                    character_dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;

                    DataGridView grid = sender as DataGridView;

                    ContextMenuStrip menu = new ContextMenuStrip();

                    if(language == "KOREAN")
                    {
                        menu.Items.Add("캐릭터 추가", null, char_Add_Event);
                    }
                    else
                    {
                        menu.Items.Add("Add Character", null, char_Add_Event);
                    }

                    Point pt = grid.PointToClient(Control.MousePosition);

                    menu.Show(character_dataGridView, pt.X, pt.Y);

                }
                else
                {
                    name = character_dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    
                    if(name != "")
                    {
                        character_dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                        skillName = null;


                        DataGridView grid = sender as DataGridView;

                        ContextMenuStrip menu = new ContextMenuStrip();
                        if (language == "KOREAN")
                        {
                            menu.Items.Add("스킬 추가", null, skill_Add_Event);
                        }
                        else
                        {
                            menu.Items.Add("Add Skill", null, skill_Add_Event);
                        }

                        Point pt = grid.PointToClient(Control.MousePosition);

                        menu.Show(character_dataGridView, pt.X, pt.Y);
                    }
                    
                }
            }
        }

        private void skill_Add_Event(object sender, EventArgs e)
        {
            /* 메뉴 실행 */

            AddSkill addSk = new AddSkill();
            //AddSkill.sName = skillName;
            AddSkill.cName = name;
            addSk.ShowDialog();

            if (addSk.version == "add")
            {
                AddSkillHandler = new EventHandler(addSk.save_btn_Click);
                AddSkillHandler.Invoke("1", EventArgs.Empty);
                AddSkillHandler = null;

                refreshSkillGridview();
            }
        }
        private void char_Add_Event(object sender, EventArgs e)
        {
            //캐릭터 추가
            AddCharacter addChar = new AddCharacter();
            AddCharacter.tName = teamName;
            addChar.ShowDialog();

            if (addChar.version == "addChar")
            {
                AddCharHandler = new EventHandler(addChar.Add_Btn_Click);
                AddCharHandler.Invoke("1", EventArgs.Empty);
                AddSkillHandler = null;

                refreshCharGridview();

            }

        }

        private void language_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(language_ComboBox.SelectedIndex == 0)
            {
                fileName = "\\Skill.xlsx";

                createGroup_Btn.Text = "팀 추가";
                search_Btn.Text = "검색";
                language = "KOREAN";

                tabControl1.TabPages[0].Text = "스킬 목록";
                tabControl1.TabPages[1].Text = "캐릭터 정보";

                //skill_dataGridView.Columns.Clear();
                //refreshCharGridview();

                search_comboBox.Items.Clear();

                //스킬명, 시너지, 기능, 코멘트
                search_comboBox.Items.Add("스킬명");
                search_comboBox.Items.Add("시너지");
                search_comboBox.Items.Add("기능");
                search_comboBox.Items.Add("코멘트");


                DataGridViewImageColumn img = new DataGridViewImageColumn();
                skill_dataGridView.Columns.Add(img);
                img.HeaderText = "스킬 이미지";
                img.ImageLayout = DataGridViewImageCellLayout.Normal;//Stretch;
                
            }
            else
            {
                fileName = "\\Skill_en.xlsx";
                
                createGroup_Btn.Text = "Add Team";
                search_Btn.Text = "Search";
                language = "ENGLISH";

                tabControl1.TabPages[0].Text = "Skill List";
                tabControl1.TabPages[1].Text = "Character Information";

                character_dataGridView.Columns.Clear();
                

                search_comboBox.Items.Clear();

                search_comboBox.Items.Add("Skill Name");
                search_comboBox.Items.Add("Synergy");
                search_comboBox.Items.Add("Function");
                search_comboBox.Items.Add("Comment");

                skill_dataGridView.Columns.Clear();

                DataGridViewImageColumn img = new DataGridViewImageColumn();
                skill_dataGridView.Columns.Add(img);
                img.HeaderText = "Skill Image";
                img.ImageLayout = DataGridViewImageCellLayout.Normal;//Stretch;
                
            }
            search_comboBox.SelectedIndex = 0;
            
        }
    }
}
