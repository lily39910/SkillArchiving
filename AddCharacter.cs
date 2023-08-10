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

namespace SkillExcel
{
    public partial class AddCharacter : Form
    {
        public string version;
        public static string tName;

        string fileName; //엑셀 파일명
        string filePath;// 엑셀파일 경로
        DBClass db;        // DBClass 변수
        System.Data.DataTable dt;		// 데이터테이블 변수

        static Excel.Application excelApp = null;
        static Excel.Workbook workBook = null;
        static Excel.Worksheet workSheet = null;

        public AddCharacter()
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

        private void AddCharacter_Load(object sender, EventArgs e)
        {
            //esc 종료용
            this.KeyPreview = true;


            string qry = "";
            qry = "SELECT [팀명] " +
                     "FROM [직업 그룹$]";

            dt = db.Read(qry); // 데이터테이블 형식으로 받아옴


            //데이터 string으로 뿌리기 위해 필요
            Team_comboBox.DataSource = dt; //데이터그리드 뷰에 뿌림
            Team_comboBox.DisplayMember = "팀명";
            Team_comboBox.ValueMember = "팀명";

            int index = Team_comboBox.FindString(tName);
            Team_comboBox.SelectedIndex = index;

        }

        public void Add_Btn_Click(object sender, EventArgs e)
        {

            if (!sender.ToString().Equals("1"))
            {
                if (Name_txtBox.Text != "")// && label1.Text != "")
                {
                    version = "addChar";

                    /*
                    string save_route = filePath + "\\character";
                    //디렉터리 경로 유무 Check
                    if (!System.IO.Directory.Exists(save_route))
                    {
                        //경로에 디렉토리가 없음 만들고 있다면 만들지 않음
                        System.IO.Directory.CreateDirectory(save_route);
                    }
                    string saveName = Name_txtBox.Text;

                    pictureBox.Image.Save(save_route + "\\" + saveName + ".png", System.Drawing.Imaging.ImageFormat.Png);
                    */


                    excelApp = new Excel.Application(); // 엑셀 어플리케이션 생성
                    workBook = excelApp.Workbooks.Open(filePath + fileName, ReadOnly: false, Editable: true);
                    workSheet = workBook.Worksheets.Add(After: workBook.Sheets[workBook.Sheets.Count]) as Excel.Worksheet;//워크북 추가
                    workSheet.Name = Name_txtBox.Text;


                    workSheet.Cells[2, 2] = "스킬 이름";
                    workSheet.Cells[2, 3] = "스킬 직급";
                    workSheet.Cells[2, 4] = "EX 진화 여부";
                    workSheet.Cells[2, 5] = "옵션 큐브";
                    workSheet.Cells[2, 6] = "각성 큐브";
                    workSheet.Cells[2, 7] = "기능";


                    try
                    {
                        workSheet = workBook.Worksheets.Item["직업 그룹"];
                        for(int i = 2; i <= workSheet.UsedRange.Rows.Count; i++)
                        {
                            string team = workSheet.Cells[i,1].Value.ToString();
                            if(team == Team_comboBox.SelectedValue.ToString())
                            {
                                //MessageBox.Show(workSheet.UsedRange.Columns.Count.ToString());
                                for(int j = 2; j <= workSheet.UsedRange.Columns.Count + 1; j++)
                                {
                                    if(workSheet.Cells[i, j].Value == null)
                                    {
                                        workSheet.Cells[i, j]= Name_txtBox.Text;
                                        break;
                                    }
                                    else
                                    {

                                    }

                                }

                            }

                        }

                        workBook.Save();
                        //workBook.SaveAs(filePath, Excel.XlFileFormat.xlWorkbookDefault);    // 엑셀 파일 저장
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
                /*
                else if(label1.Text == "")
                {
                    MessageBox.Show("캐릭터 이미지를 선택하세요.");
                }
                */
                else
                {
                    MessageBox.Show("캐릭터 명을 입력하세요.");
                }

            }
            else {
                MessageBox.Show("캐릭터가 생성되었습니다.");
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

        private void AddCharacter_KeyDown(object sender, KeyEventArgs e)
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

        private void img_btn_Click(object sender, EventArgs e)
        {
            string file = "";

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = Environment.GetEnvironmentVariable("USERPROFILE") + @"\" + "Downloads";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                file = dlg.FileName;
                char a = '\\';
                label1.Text = file.Substring(file.LastIndexOf(a)+1);

                pictureBox.Image = Bitmap.FromFile(file);
                pictureBox.SizeMode = PictureBoxSizeMode.Normal;

                label2.Visible = false;
            }
            else
            {
                return;
            }
        }
    }
}
