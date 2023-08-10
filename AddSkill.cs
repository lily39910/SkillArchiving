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
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic.Logging;
using System.IO;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Xml.Linq;
using Microsoft.Office.Core;
using System.IO.Pipes;

namespace SkillExcel
{


    public partial class AddSkill : Form
    {
        public static string cName; //캐릭터명
        public static string sName; //스킬명

        string fileName; //엑셀 파일명
        string filePath;// 엑셀파일 경로
        DBClass db;        // DBClass 변수
        System.Data.DataTable dt;		// 데이터테이블 변수
        string qry = "";
        public string version = "";
        string newImage = "";

        static Excel.Application excelApp = null;
        static Excel.Workbook workBook = null;
        static Excel.Worksheet workSheet = null;

        class char_Skill
        {
            //DB
            public string skillName;
            public string skillRank;
            public string skillEvol;
            public string skillOptionCube;
            public string skillAwakeCube;
            public string skillFunction;
        }

        public AddSkill()
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
        private void AddSkill_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

            label7.Text = cName;

            if (sName == null)
            {
                //MessageBox.Show("추가");
                edit_Btn.Visible = false;
                del_Btn.Visible = false;
                save_btn.Visible = true;

            }
            else
            {
                //MessageBox.Show("수정");
                save_btn.Visible = false;
                edit_Btn.Visible = true;
                del_Btn.Visible = false;
                imgLabel.Visible = false;

                Img_Btn.Visible = false; //사용 중인 이미지 수정 불가... 
                skillName_textBox.ReadOnly = true;

                qry = "SELECT * " +
                    "FROM [" + cName + "$] " +
                    "WHERE [스킬 이름] Like '" + sName + "' ";

                dt = db.Read(qry); // 데이터테이블 형식으로 받아옴

                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    skillName_textBox.Text = row["스킬 이름"].ToString();
                    skillRank_textBox.Text = row["스킬 직급"].ToString();
                    skillEvol_comboBox.Text = row["EX 진화 여부"].ToString();
                    skillOptionCube_comboBox.Text = row["옵션 큐브"].ToString();
                    skillAwakeCube_comboBox.Text = row["각성 큐브"].ToString();
                    

                    string newLine = System.Environment.NewLine;
                    //skillFunction_textBox.Text = "I am" + newLine + "text";
                    skillFunction_textBox.Text = row["기능"].ToString();
                    skillFunction_textBox.Text.Replace("\n", "\r\n");
                    
                }

                //이미지 Load
                string save_route = filePath + "\\image\\" + cName;
                string saveName = skillName_textBox.Text;
                string imgName = saveName.Replace(":", "_");

                pictureBox.Image = Bitmap.FromFile(save_route + "\\" + imgName + ".png");
                
            }

        }

        private void Img_Btn_Click(object sender, EventArgs e)
        {

            string img_file = string.Empty;

            OpenFileDialog dlg = new OpenFileDialog();
            //dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            dlg.InitialDirectory = Environment.GetEnvironmentVariable("USERPROFILE") + @"\" + "Downloads";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                img_file = dlg.FileName;
                imgLabel.Visible = false;
                if(save_btn.Visible == false)
                {
                    newLabel.Visible = true;
                    newLabel.Text = "edit";
                    newImage = img_file;

                }
            }
            else
            {
                return;
            }

            pictureBox.Image = Bitmap.FromFile(img_file);
            pictureBox.SizeMode = PictureBoxSizeMode.Normal;
        }

        public void save_btn_Click(object sender, EventArgs e)
        {
            version = "add";
            
            if(!sender.ToString().Equals("1")) { 
                excelApp = new Excel.Application(); // 엑셀 어플리케이션 생성
                workBook = excelApp.Workbooks.Open(filePath + fileName, ReadOnly: false, Editable: true);
                //workbook = isFileExist? excelApp.Workbooks.Open(path, ReadOnly: false, Editable: true) : excelApp.Workbooks.Add(Missing.Value);


                //여기부터 Error
                Worksheet workSheet = null; //= workBook.Worksheets.Item[workBook.Worksheets.Count]; // 엑셀 마지막 워크시트 가져오기

                for (int i = 1; i <= workBook.Worksheets.Count; i++)
                {
                    workSheet = workBook.Worksheets.Item[i];
                    if (workSheet.Name == cName)
                    {
                        try
                        {
                            // 엑셀에 저장할 개 데이터
                            List<char_Skill> skills = new List<char_Skill>();
                            //skills.Add(new Skill() { name = "백구", breeds = "진돗개", sex = "여" });
                           
                            skills.Add(new char_Skill()
                            {
                                skillName = skillName_textBox.Text,
                                skillRank = skillRank_textBox.Text,
                                skillEvol = skillEvol_comboBox.Text,
                                skillOptionCube = skillOptionCube_comboBox.Text,
                                skillAwakeCube = skillAwakeCube_comboBox.Text,
                                skillFunction = skillFunction_textBox.Text
                            });

                            //저장할 이미지의 디렉토리 경로를 문자열로 생성합니다.
                            string save_route = filePath + "\\image\\" + cName;

                            //디렉터리 경로 유무 Check
                            if (!System.IO.Directory.Exists(save_route))
                            {
                                //경로에 디렉토리가 없음 만들고 있다면 만들지 않음
                                System.IO.Directory.CreateDirectory(save_route);
                            }
                            string saveName = skillName_textBox.Text;
                            string imgName = saveName.Replace(":", "_");
                            pictureBox.Image.Save(save_route + "\\" + imgName + ".png", System.Drawing.Imaging.ImageFormat.Png);


                            int range = workSheet.UsedRange.Rows.Count;

                            for (int r = range; r < range + 1; r++)
                            {
                                char_Skill skill = skills[0];

                                // 셀에 데이터 입력
                                workSheet.Cells[2 + r, 2] = skill.skillName;
                                workSheet.Cells[2 + r, 3] = skill.skillRank;
                                workSheet.Cells[2 + r, 4] = skill.skillEvol;
                                workSheet.Cells[2 + r, 5] = skill.skillOptionCube;
                                workSheet.Cells[2 + r, 6] = skill.skillAwakeCube;
                                workSheet.Cells[2 + r, 7] = skill.skillFunction;
                            }

                            workSheet.Columns.AutoFit();// 열 너비 자동 맞춤

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
                        break;//같은 캐릭 찾으면 break
                    }
                }
                this.Close();

            }
            else
            {
                MessageBox.Show("스킬이 등록되었습니다.");
                
            }
        }


        public void edit_Btn_Click(object sender, EventArgs e)
        {
            version = "edit";
            if (!sender.ToString().Equals("1"))
            {
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
                            for (int r = 3; r <= workSheet.UsedRange.Rows.Count + 1; r++)
                            {
                                string skill = "";
                                skill = workSheet.Range["B" + r].Value;

                                //스킬명이 같을 경우 찾기
                                if (sName == skill)
                                {
                                    workSheet.Range["B" + r].Value = skillName_textBox.Text;
                                    workSheet.Range["C" + r].Value = skillRank_textBox.Text;
                                    workSheet.Range["D" + r].Value = skillEvol_comboBox.Text;
                                    workSheet.Range["E" + r].Value = skillOptionCube_comboBox.Text;
                                    workSheet.Range["F" + r].Value = skillAwakeCube_comboBox.Text;
                                    workSheet.Range["G" + r].Value = skillFunction_textBox.Text;
                                    break; //error 가능
                                }

                            }
                            
                            workBook.Save();
                            workBook.Close(true);
                            excelApp.Quit();
                            if (newLabel.Text != "")
                            {
                                //저장할 이미지의 디렉토리 경로를 문자열로 생성합니다.
                                string save_route = filePath + "\\image\\" + cName;

                                //디렉터리 경로 유무 Check
                                if (!System.IO.Directory.Exists(save_route))
                                {
                                    //경로에 디렉토리가 없음 만들고 있다면 만들지 않음
                                    System.IO.Directory.CreateDirectory(save_route);
                                }
                                string saveName = skillName_textBox.Text;
                                string imgName = saveName.Replace(":", "_");

                                //File.Copy(newImage, save_route +"\\" + imgName + ".png", true);
                                //pictureBox.Image.Save(save_route + "\\" + imgName + ".png", System.Drawing.Imaging.ImageFormat.Png);
                                MessageBox.Show("이미지 저장");
                            }
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
                this.Close();
            }
            else
            {
                MessageBox.Show("수정되었습니다.");
                sName = null;
            }

        }

        public void del_Btn_Click(object sender, EventArgs e)
        {

            /*
            if (MessageBox.Show("확인 취소 테스트", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //확인시 내용
                MessageBox.Show("확인버튼 누름");
            }
            */
            
            /*
            string saveName = skillName_textBox.Text;
            string imgName = saveName.Replace(":", "_");
            
            version = "delete";
            if (!sender.ToString().Equals("1"))
            {
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
                            for (int r = 3; r <= workSheet.UsedRange.Rows.Count + 1; r++)
                            {
                                string skill = "";
                                skill = workSheet.Range["B" + r].Value;
                                if (sName == skill)
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
                pictureBox.Image.Dispose();
                pictureBox.Image = null;

                string save_route = filePath + "\\image\\" + cName;
                File.Delete(save_route + ".png");
                this.Close();
                //File.Copy(newImage, save_route +"\\" + imgName + ".png", true);
                //pictureBox.Image.Save(save_route + "\\" + imgName + ".png", System.Drawing.Imaging.ImageFormat.Png);
            }
            else
            {
                MessageBox.Show("삭제되었습니다.");
            }
            */
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

        private void AddSkill_KeyDown(object sender, KeyEventArgs e)
        {
            //ESC 종료
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void AddSkill_FormClosing(object sender, FormClosingEventArgs e)
        {
            sName = null;
        }
    }
}
