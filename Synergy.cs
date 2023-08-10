using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Runtime.InteropServices;

namespace SkillExcel
{
    public partial class Synergy : Form
    {
        public static string cName;//이름
        public static string skillName; //

        string fileName; //엑셀 파일명
        string filePath;// 엑셀파일 경로
        DBClass db;        // DBClass 변수
        public static System.Data.DataTable sng_dt;		// 데이터테이블 변수
        string coolChkQry = "";
        string evolChkQry = "";
        string stackChkQry = "";


        //값 저장
        string affected;
        string affect;
        string summery;
        string comment;



        public EventHandler AddSnyHandler;

        public Synergy()
        {
            InitializeComponent();
            //filePath = $"{Environment.CurrentDirectory}";

            //넥슨 경로
            filePath = "\\\\10.80.251.201\\넥슨네트웍스 퍼블리싱qa2팀\\3. 클로저스\\[클로저스] 스킬 아카이빙 프로그램";

            fileName = "\\Skill.xlsx";

            db = new DBClass(filePath, fileName); // 생성자에 매개변수를 넘기면서 객체생성
            sng_dt = new System.Data.DataTable(); // 객체생성
        }

        private void refreshSynGridview()
        {
            string qry = "";
            qry = "SELECT * " +
            "FROM [스킬시너지$] " +
                     "WHERE [캐릭터명] Like '" + cName + "' " +
                     "AND [스킬 이름] Like '" + skillName + "' ";

            if(coolChkQry != "" && coolTime_chk.Checked == true)
            {
                qry += "AND( " + coolChkQry;
                if(evolChkQry != "" && Evol_chk.Checked == true)
                {
                    qry += "OR " + evolChkQry;
                }
                if(stackChkQry != "" && stack_chk.Checked == true)
                {
                    qry += "OR " + stackChkQry;
                }
                qry += ")";
            }
            else
            {
                if(evolChkQry != "" && Evol_chk.Checked == true)
                {
                    qry += "AND( " + evolChkQry;
                    if(stackChkQry != "" && stack_chk.Checked == true)
                    {
                        qry += "OR " + stackChkQry;
                    }
                    qry += ")";
                }
                else
                {
                    if(stack_chk.Checked == true)
                    {
                        qry += "AND " + stackChkQry;
                    }
                }
            }
            
            sng_dt = db.Read(qry); // 데이터테이블 형식으로 받아옴

            sng_dataGridView.DataSource = sng_dt; //데이터그리드 뷰에 뿌림
            

        }


        private void addSng_Btn_Click(object sender, EventArgs e)
        {
            AddSynergy addSyn = new AddSynergy();
            AddSynergy.cName = cName;
            AddSynergy.skillName = skillName;
            AddSynergy.affected = null;
            AddSynergy.affect = null;
            AddSynergy.summery = null;
            AddSynergy.comment = null;
            addSyn.ShowDialog();

            if (addSyn.version == "addSyn")
            {
                AddSnyHandler = new EventHandler(addSyn.synAdd_Btn_Click);
                AddSnyHandler.Invoke("1", EventArgs.Empty);
                AddSnyHandler = null;
                refreshSynGridview();
            }

        }

        private void Synergy_Load(object sender, EventArgs e)
        {
            //esc 종료용
            this.KeyPreview = true;

            sng_dataGridView.DataSource = sng_dt; //데이터그리드 뷰에 뿌림

        }

        private void Synergy_KeyDown(object sender, KeyEventArgs e)
        {
            //ESC 종료
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void coolTime_chk_CheckedChanged(object sender, EventArgs e)
        {
            if(coolTime_chk.Checked == true)
            {
                all_chk.Checked = false;
                coolChkQry = "[영향 요약] Like '" + "%" + "쿨" + "%' ";
            }
            else if (coolTime_chk.Checked == true || Evol_chk.Checked == true || stack_chk.Checked == true)
            {
                all_chk.Checked = false;
                if(!coolTime_chk.Checked == true)
                {
                    coolChkQry = "";
                }
                else
                {
                    coolChkQry = "[영향 요약] Like '" + "%" + "쿨" + "%' ";
                }
            }
            else if (!coolTime_chk.Checked == true || !Evol_chk.Checked == true || !stack_chk.Checked == true)
            {
                all_chk.Checked = true;
            }
            refreshSynGridview();
        }

        private void Evol_chk_CheckedChanged(object sender, EventArgs e)
        {
            if(Evol_chk.Checked == true)
            {
                all_chk.Checked = false;
                evolChkQry = "[영향 요약] Like '" + "%" + "강화" + "%' ";
            }
            else if (coolTime_chk.Checked == true || Evol_chk.Checked == true || stack_chk.Checked == true)
            {
                all_chk.Checked = false;
                if (!Evol_chk.Checked == true)
                {
                    evolChkQry = "";
                }
                else
                {
                    evolChkQry = "[영향 요약] Like '" + "%" + "강화" + "%' ";
                }

            }
            else if (!coolTime_chk.Checked == true || !Evol_chk.Checked == true || !stack_chk.Checked == true)
            {
                all_chk.Checked = true;
            }
            refreshSynGridview();
            
        }

        private void stack_chk_CheckedChanged(object sender, EventArgs e)
        {
            if (stack_chk.Checked == true)
            {
                all_chk.Checked = false;
                stackChkQry = "[영향 요약] Like '" + "%" + "스택" + "%' ";
            }
            else if (coolTime_chk.Checked == true || Evol_chk.Checked == true || stack_chk.Checked == true)
            {
                all_chk.Checked = false;
                if (!stack_chk.Checked == true)
                {
                    stackChkQry = "";
                }
                else
                {
                    stackChkQry = "[영향 요약] Like '" + "%" + "스택" + "%' ";
                }
            }
            else if (!coolTime_chk.Checked == true || !Evol_chk.Checked == true || !stack_chk.Checked == true)
            {
                all_chk.Checked = true;
            }
            refreshSynGridview();
    
        }

        private void all_chk_CheckedChanged(object sender, EventArgs e)
        {
            if (all_chk.Checked == true)
            {
                coolTime_chk.Checked = false;
                Evol_chk.Checked = false;
                stack_chk.Checked = false;
            }
            else if (coolTime_chk.Checked == true || Evol_chk.Checked == true || stack_chk.Checked == true)
            {
                all_chk.Checked = false;     
            }
            else if(!coolTime_chk.Checked == true || !Evol_chk.Checked == true || !stack_chk.Checked == true)
            {
                all_chk.Checked = true;
            }
        }

        private void sng_dataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 )
            {
                sng_dataGridView.ClearSelection();
                sng_dataGridView.Rows[e.RowIndex].Selected = true;

                AddSynergy.cName = cName;
                AddSynergy.skillName = skillName;
                AddSynergy.affected = sng_dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                AddSynergy.affect = sng_dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                AddSynergy.summery = sng_dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                AddSynergy.comment = sng_dataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();


                //삭제용
                affected = sng_dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                affect = sng_dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                summery = sng_dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                comment = sng_dataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
                
                DataGridView grid = sender as DataGridView;

                ContextMenuStrip menu = new ContextMenuStrip();

                menu.Items.Add("수정", null, sng_Edit_Event);
                menu.Items.Add("삭제", null, sng_Delete_Event);

                System.Drawing.Point pt = grid.PointToClient(Control.MousePosition);

                menu.Show(sng_dataGridView, pt.X, pt.Y);
            }
            /*
            if (e.Button == MouseButtons.Right)
            {
                AddSynergy addSyn = new AddSynergy();
                AddSynergy.cName = cName;
                AddSynergy.skillName = skillName;
                AddSynergy.affected = sng_dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                AddSynergy.affect = sng_dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                AddSynergy.summery = sng_dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                AddSynergy.comment = sng_dataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
                
                addSyn.ShowDialog();

                if (addSyn.version == "editSyn")
                {
                    AddSnyHandler = new EventHandler(addSyn.synEdit_Btn_Click);
                    AddSnyHandler.Invoke("1", EventArgs.Empty);
                    AddSnyHandler = null;
                    refreshSynGridview();
                }
                else if (addSyn.version == "deleteSyn")
                {
                    AddSnyHandler = new EventHandler(addSyn.synDelete_Btn_Click);
                    AddSnyHandler.Invoke("1", EventArgs.Empty);
                    AddSnyHandler = null;
                    refreshSynGridview();
                }

            }
            */
        }


        private void sng_Edit_Event(object sender, EventArgs e)
        {
            /* 메뉴 실행 */

            AddSynergy addSyn = new AddSynergy();
            
            addSyn.ShowDialog();

            if (addSyn.version == "editSyn")
            {
                AddSnyHandler = new EventHandler(addSyn.synEdit_Btn_Click);
                AddSnyHandler.Invoke("1", EventArgs.Empty);
                AddSnyHandler = null;
                refreshSynGridview();
            }
        }

        private void sng_Delete_Event(object sender, EventArgs e)
        {
            //스킬 삭제
            //YESNO 확인 후 삭제 qry 실행
            if (MessageBox.Show("선택된 시너지 효과를 정말 삭제하시겠습니까?", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Excel.Application excelApp = null;
                Excel.Workbook workBook = null;

                excelApp = new Excel.Application(); // 엑셀 어플리케이션 생성
                workBook = excelApp.Workbooks.Open(filePath + fileName, ReadOnly: false, Editable: true);

                Worksheet workSheet = workBook.Worksheets.Item["스킬시너지"]; // 스킬시너지 시트
                
                try
                {
                    if (comment == "")
                    {
                        comment = null;
                    }

                    int range = workSheet.UsedRange.Rows.Count;

                    if (range == 1)
                    {
                        range = 3;
                    }
                    for (int r = 3; r <= range + 1; r++)
                    {
                        //스킬명과 이름이 같을 경우 찾기
                        if (cName == workSheet.Range["B" + r].Value &&
                            skillName == workSheet.Range["C" + r].Value &&
                            
                            workSheet.Range["D" + r].Value == affected &&
                            workSheet.Range["E" + r].Value == affect &&
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
                MessageBox.Show("해당 시너지 효과를 삭제하였습니다.");
                refreshSynGridview();
            }
            else
            {
                MessageBox.Show("삭제가 취소되었습니다.");
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
    }
}
