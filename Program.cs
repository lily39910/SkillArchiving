using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace SkillExcel
{
    static class Program
    {
        static Excel.Application excelApp = null;
        static Excel.Workbook workBook = null;
        static Excel.Worksheet workSheet = null;

        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Skill());
        }


        // 확장명 XLSX (Excel 2007 이상용)
        private const string ConnectStrFrm_Excel =
            "Provider=Microsoft.ACE.OLEDB.12.0;" +
            "Data Source=\"{0}\";" +
            "Mode=ReadWrite|Share Deny None;" +
            "Extended Properties='Excel 12.0; HDR={1}; IMEX={2}';" +
            "Persist Security Info=False";
    }

    public class DBClass
    {
        private readonly String filePath;
        private readonly String fileName;
        OleDbConnection oleCon;


        //생성자
        public DBClass(String filePath, String fileName)
        {
            this.filePath = filePath;
            this.fileName = fileName;
        }

        //연결 함수
        public void Conn()
        {
            String conn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source ="
                                     + this.filePath + this.fileName + "; Extended Properties = Excel 12.0;";

            this.oleCon = new OleDbConnection(conn);
            //MessageBox.Show(conn);
            oleCon.Open(); 

        }

        public DataTable Read(String query)
        {
            try
            {
                Conn();
                /*
                 select문에 대한 읽어오는 방법이 여러가지 방법 중 
                dataAdapter를 이용하는 방법 / dataReader를 이용하는 방법
                아래는 Adapter 활용
                Dataset 을 채우고 데이터 원본을 업데이트 하는 데이터 명령 집합
                 */

                OleDbDataAdapter oleOda = new OleDbDataAdapter(query, oleCon);
                DataTable excelDatatable = new DataTable();
                //excelDatatable.Columns.Add("선택", typeof(bool)); //선택 체크박스용
                oleOda.Fill(excelDatatable);
                oleCon.Close();

                return excelDatatable;
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
