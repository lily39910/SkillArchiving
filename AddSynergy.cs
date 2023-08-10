using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Reflection;

namespace SkillExcel
{
    public partial class AddSynergy : Form
    {
        public static string cName;
        public static string skillName;
        public static string affected;
        public static string affect;
        public static string summery;
        public static string comment;

        string summerySkill;
        string impactSummery;



        string fileName; //엑셀 파일명
        string filePath;// 엑셀파일 경로
        DBClass db;        // DBClass 변수
        System.Data.DataTable dt;		// 데이터테이블 변수

        static Excel.Application excelApp = null;
        static Excel.Workbook workBook = null;
        static Excel.Worksheet workSheet = null;

        public string version = "";

        class sny_Skill
        {
            //DB
            public string charName;
            public string skillName;
            public string affectedSkill;
            public string affectSkill;
            public string impactSummery;
            public string skillComment;
        }



        public AddSynergy()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            //filePath = $"{Environment.CurrentDirectory}";

            //넥슨 경로
            filePath = "\\\\10.80.251.201\\넥슨네트웍스 퍼블리싱qa2팀\\3. 클로저스\\[클로저스] 스킬 아카이빙 프로그램";

            fileName = "\\Skill.xlsx";

            db = new DBClass(filePath, fileName); // 생성자에 매개변수를 넘기면서 객체생성
            dt = new System.Data.DataTable(); // 객체생성
        }

        private void AddSynergy_Load(object sender, EventArgs e)
        {
            char_Label.Text = cName;
            synAdd_Btn.Visible = true;
            synEdit_Btn.Visible = false;
            synDelete_Btn.Visible = false;


            //esc 종료용
            this.KeyPreview = true;
            excelApp = new Excel.Application(); // 엑셀 어플리케이션 생성
            workBook = excelApp.Workbooks.Open(filePath + fileName, ReadOnly: false, Editable: true);
            Worksheet workSheet = null;

            for (int i = 1; i <= workBook.Worksheets.Count; i++)
            {
                workSheet = workBook.Worksheets.Item[i];
                if (workSheet.Name == cName)
                {
                    try
                    {
                        int range = workSheet.UsedRange.Rows.Count;

                        for (int r = 3; r <= range + 1; r++)
                        {
                            if (skillName == workSheet.Range["B" + r].Value)
                            {
                                skillName_comboBox.Items.Add(workSheet.Range["B" + r].Value);
                                skillName_comboBox.SelectedItem = workSheet.Range["B" + r].Value.ToString();
                            }

                            affected_comboBox.Items.Add(workSheet.Range["B" + r].Value);
                            affect_comboBox.Items.Add(workSheet.Range["B" + r].Value);
                            impactSummery_comboBox.Items.Add(workSheet.Range["B" + r].Value);
                        }

                        workBook.Close(true);
                        excelApp.Quit();
                    }
                    finally
                    {
                        ReleaseObject(workSheet);
                        ReleaseObject(workBook);
                        ReleaseObject(excelApp);
                    }
                    break;//같은 캐릭 찾으면 break
                }
            }



            //수정, 삭제
            if (affected != null)
            {
                synAdd_Btn.Visible = false;
                synEdit_Btn.Visible = true;
                synDelete_Btn.Visible = false;

                //스킬명만 호출
                if (affected != null)
                {
                    affected = affected.Replace("[", "");
                    affected = affected.Replace("]", "");
                }
                if (affect != null)
                {
                    affect = affect.Replace("[", "");
                    affect = affect.Replace("]", "");
                }
                if (summery != null)
                {
                    int startIdx = summery.IndexOf("]");
                    summerySkill = summery.Substring(0, startIdx+1);
                    summerySkill = summerySkill.Replace("[", "");
                    summerySkill = summerySkill.Replace("]", "");

                    impactSummery = summery.Substring(startIdx + 2);

                }

                //수정, 삭제
                affected_comboBox.Text = affected;
                affect_comboBox.Text = affect;
                impactSummery_comboBox.Text = summerySkill;
                impactSummery_txt.Text = impactSummery;
                skillComment_txt.Text = comment;
            }

        }

        public void synAdd_Btn_Click(object sender, EventArgs e)
        {
            version = "addSyn";

            if (!sender.ToString().Equals("1"))
            {
                excelApp = new Excel.Application(); // 엑셀 어플리케이션 생성
                workBook = excelApp.Workbooks.Open(filePath + fileName, ReadOnly: false, Editable: true);
                
                Worksheet workSheet = workBook.Worksheets.Item["스킬시너지"]; // 스킬시너지 시트

                try
                {
                    // 엑셀에 저장할 개 데이터
                    List<sny_Skill> skills = new List<sny_Skill>();

                    skills.Add(new sny_Skill()
                    {
                        charName = cName,
                        skillName = skillName,
                        affectedSkill = "[" + affected_comboBox.Text +"]",
                        affectSkill = "["+ affect_comboBox.Text +"]",
                        impactSummery = "["+ impactSummery_comboBox.Text +"] " + impactSummery_txt.Text,
                        skillComment = skillComment_txt.Text
                    });

                            
                    int range = workSheet.UsedRange.Rows.Count;

                    for (int r = range; r < range + 1; r++)
                    {
                        sny_Skill skill = skills[0];

                        // 셀에 데이터 입력
                        workSheet.Cells[2 + r, 2] = skill.charName;
                        workSheet.Cells[2 + r, 3] = skill.skillName;
                        workSheet.Cells[2 + r, 4] = skill.affectedSkill;
                        workSheet.Cells[2 + r, 5] = skill.affectSkill;
                        workSheet.Cells[2 + r, 6] = skill.impactSummery;
                        workSheet.Cells[2 + r, 7] = skill.skillComment;
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
                
                this.Close();

            }
            else
            {
                MessageBox.Show("스킬 시너지가 등록되었습니다.");

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

        private void AddSynergy_KeyDown(object sender, KeyEventArgs e)
        {
            //ESC 종료
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        public void synEdit_Btn_Click(object sender, EventArgs e)
        {
            version = "editSyn";
            if (!sender.ToString().Equals("1"))
            {
                excelApp = new Excel.Application(); // 엑셀 어플리케이션 생성
                workBook = excelApp.Workbooks.Open(filePath + fileName, ReadOnly: false, Editable: true);

                Worksheet workSheet = workBook.Worksheets.Item["스킬시너지"]; // 스킬시너지 시트

                try
                {
                    int range = workSheet.UsedRange.Rows.Count;

                    if (range == 1)
                    {
                        range = 3;
                    }

                    for (int r = 3; r <= range + 1; r++)
                    {
                        List<sny_Skill> skills = new List<sny_Skill>();

                        skills.Add(new sny_Skill()
                        {
                            charName = cName,
                            skillName = skillName,
                            affectedSkill = "[" + affected_comboBox.Text + "]",
                            affectSkill = "[" + affect_comboBox.Text + "]",
                            impactSummery = "[" + impactSummery_comboBox.Text + "] " + impactSummery_txt.Text,
                            skillComment = skillComment_txt.Text

                        });


                        if(workSheet.Range["G" + r].Value == null)
                        {
                            comment = null;
                        }
                        else //안 주면 값 널로 인식
                        {
                            comment = workSheet.Range["G" + r].Value;
                        }
                        
                        sny_Skill skill = skills[0];

                        

                        //excel은 빈값 null로 인식 not ""

                        //스킬명과 이름이 같을 경우 찾기
                        if (cName == workSheet.Range["B" + r].Value && 
                            skillName_comboBox.Text == workSheet.Range["C" + r].Value &&
                            workSheet.Range["D" + r].Value == "[" + affected +"]" &&
                            workSheet.Range["E" + r].Value == "["+ affect + "]" &&
                            summery == workSheet.Range["F" + r].Value &&
                            comment == workSheet.Range["G" + r].Value)
                        {
                            workSheet.Range["D" + r].Value = skill.affectedSkill;
                            workSheet.Range["E" + r].Value = skill.affectSkill;
                            workSheet.Range["F" + r].Value = skill.impactSummery;
                            workSheet.Range["G" + r].Value = skill.skillComment;
                            
                            break; //error 가능
                        }
                    }
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

                this.Close();
            }
            else
            {
                MessageBox.Show("수정되었습니다.");
            }
        }

        public void synDelete_Btn_Click(object sender, EventArgs e)
        {
            /*
            version = "deleteSyn";
            if (!sender.ToString().Equals("1"))
            {
                excelApp = new Excel.Application(); // 엑셀 어플리케이션 생성
                workBook = excelApp.Workbooks.Open(filePath + fileName, ReadOnly: false, Editable: true);

                Worksheet workSheet = workBook.Worksheets.Item["스킬시너지"]; // 스킬시너지 시트

                try
                {
                    for (int r = 3; r <= workSheet.UsedRange.Rows.Count + 1; r++)
                    {

                        //스킬명과 이름이 같을 경우 찾기
                        if (cName == workSheet.Range["B" + r].Value &&
                            skillName_comboBox.Text == workSheet.Range["C" + r].Value &&
                            workSheet.Range["D" + r].Value == "[" + affected + "]" &&
                            workSheet.Range["E" + r].Value == "[" + affect + "]" &&
                            summery == workSheet.Range["F" + r].Value &&
                            comment == workSheet.Range["G" + r].Value)
                        {
                            workSheet.Rows[r, Missing.Value].Delete();

                            break;
                        }
                    }
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

                this.Close();
            }
            else
            {
                MessageBox.Show("삭제되었습니다.");
            }
            
            */
        }
    }
}
