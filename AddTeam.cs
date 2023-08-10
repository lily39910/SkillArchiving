using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;

namespace SkillExcel
{
    public partial class AddTeam : Form
    {
        public string version;

        string fileName; //엑셀 파일명
        string filePath;// 엑셀파일 경로
        DBClass db;        // DBClass 변수
        System.Data.DataTable dt;		// 데이터테이블 변수

        static Excel.Application excelApp = null;
        static Excel.Workbook workBook = null;
        static Excel.Worksheet workSheet = null;


        public AddTeam()
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

        public void add_Btn_Click(object sender, EventArgs e)
        {

            if (!sender.ToString().Equals("1"))
            {
                if (teamName_txt.Text != "")
                {
                    version = "addTeam";
                    excelApp = new Excel.Application(); // 엑셀 어플리케이션 생성
                    workBook = excelApp.Workbooks.Open(filePath + fileName, ReadOnly: false, Editable: true);
                    try
                    {
                        workSheet = workBook.Worksheets.Item["직업 그룹"];
                        workSheet.Cells[workSheet.UsedRange.Rows.Count + 1, 1] = teamName_txt.Text;

                        workBook.Save();
                        workBook.Close(true);
                        excelApp.Quit();
                    }
                    finally
                    {
                        ReleaseObject(workSheet);
                        ReleaseObject(workBook);
                        ReleaseObject(excelApp);

                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("팀명을 입력하세요.");
                }
            }
            else
            {
                MessageBox.Show("팀이 생성되었습니다.");
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

        private void AddTeam_Load(object sender, EventArgs e)
        {
            //esc 종료용
            this.KeyPreview = true;
        }

        private void AddTeam_KeyDown(object sender, KeyEventArgs e)
        {
            //ESC 종료
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void Cancel_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
