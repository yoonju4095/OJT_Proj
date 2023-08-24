using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using SMT_MES.Controls;
using SMT_MES.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OJT_Proj.pyj
{
    public partial class pyj_form : DevExpress.XtraEditors.XtraForm
    {
        cls_Grid grid = new cls_Grid();

        public pyj_form()
        {
            InitializeComponent();
            SetDesign();
        }

        private void SetDesign()
        {
            Set_GridView(gridView1);

            Func_Search();
        }

        private void Set_GridView(GridView gv)
        {
            //Grid 공통 설정
            gv.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;   //Header 정렬
            gv.OptionsView.ColumnAutoWidth = false;     //Column 많으면 스크롤 생기도록 바꾸기

            //Repository 생성 or 이벤트 입력
            RepositoryItemTextEdit txt_Corp_Cd = new RepositoryItemTextEdit(); txt_Corp_Cd.MaxLength = 2;  //사업장 번호
            RepositoryItemTextEdit txt_Corp_Nm = new RepositoryItemTextEdit(); txt_Corp_Nm.MaxLength = 30;  //사업장 이름
            RepositoryItemTextEdit txt_Addr = new RepositoryItemTextEdit(); txt_Addr.MaxLength = 50;  //주소
            RepositoryItemTextEdit txt_Tel = new RepositoryItemTextEdit(); txt_Tel.MaxLength = 20;  //담당자 전화번호
            RepositoryItemTextEdit txt_Corp_No = new RepositoryItemTextEdit(); txt_Corp_No.MaxLength = 15;  //사업장 등록번호
            RepositoryItemTextEdit txt_Prs_Nm = new RepositoryItemTextEdit(); txt_Prs_Nm.MaxLength = 20;  //대표자명
            RepositoryItemTextEdit txt_BS_Con = new RepositoryItemTextEdit(); txt_BS_Con.MaxLength = 30;  //업태
            RepositoryItemTextEdit txt_BS_Tp = new RepositoryItemTextEdit(); txt_BS_Tp.MaxLength = 30;  //업종
            RepositoryItemTextEdit txt_Mail = new RepositoryItemTextEdit(); txt_Mail.MaxLength = 30;  //메일
            RepositoryItemTextEdit txt_Fax = new RepositoryItemTextEdit(); txt_Fax.MaxLength = 30;  //Fax

            //Column 생성
            grid.Create_GvColumn(gv, "상태", "Status");
            grid.Create_GvColumn(gv, "사업장번호", "Corp_Cd", txt_Corp_Cd);
            grid.Create_GvColumn(gv, "사업장 이름", "Corp_Nm", txt_Corp_Nm);
            grid.Create_GvColumn(gv, "주소", "Addr", txt_Addr);
            grid.Create_GvColumn(gv, "담당자 전화번호", "Tel", txt_Tel);
            grid.Create_GvColumn(gv, "사업장 등록번호", "Corp_No", txt_Corp_No);
            grid.Create_GvColumn(gv, "대표자명", "Prs_Nm", txt_Prs_Nm);
            grid.Create_GvColumn(gv, "업태", "BS_Con", txt_BS_Con);
            grid.Create_GvColumn(gv, "업종", "BS_Tp", txt_BS_Tp);
            grid.Create_GvColumn(gv, "메일", "Mail", txt_Mail);
            grid.Create_GvColumn(gv, "Fax", "Fax", txt_Fax);
            grid.Create_GvColumn(gv, "등록자", "Ins_Emp_No");
            grid.Create_GvColumn(gv, "등록일시", "Ins_Date_Time");
            grid.Create_GvColumn(gv, "수정자", "Upd_Emp_No");
            grid.Create_GvColumn(gv, "수정일시", "Upd_Date_Time");

            //Column 단일 설정
            //셀값 변경 허용
            grid.Column_AllowEdit(gv.Columns["Corp_Cd"]);  //사업장 번호
            grid.Column_AllowEdit(gv.Columns["Corp_Nm"]);  //사업장 이름
            grid.Column_AllowEdit(gv.Columns["Addr"]);     //주소
            grid.Column_AllowEdit(gv.Columns["Tel"]);      //담당자 전화번호
            grid.Column_AllowEdit(gv.Columns["Corp_No"]);  //사업장 등록번호
            grid.Column_AllowEdit(gv.Columns["Prs_Nm"]);   //대표자 명
            grid.Column_AllowEdit(gv.Columns["BS_Con"]);   //업태
            grid.Column_AllowEdit(gv.Columns["BS_Tp"]);    //업종
            grid.Column_AllowEdit(gv.Columns["Mail"]);     //메일
            grid.Column_AllowEdit(gv.Columns["Fax"]);      //Fax

            //셀값 정렬
            gv.Columns["Status"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;     //상태

            //이벤트 설정
            gv.RowStyle += grid.RowStyle_ChangeBg_ByStatus;           //삭제시 배경색 지정
            gv.CellValueChanged += Event_CellValueChanged;            //셀값 수정시 상태값 수정
        }

        private void Event_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView gv = sender as GridView;

            //셀값 수정 시 상태값 수정
            if (e.Column.FieldName == gv.Columns[0].FieldName) return;
            grid.Change_Status(gv, e.RowHandle);
        }

        private void Btn_RowEdit(object sender, EventArgs e)
        {
            //행삽입, 추가, 삭제 버튼 클릭 이벤트
            //1. 이름의 마지막 3글자 가져오기
            SimpleButton btn = sender as SimpleButton;
            string txt_Act = btn.Name.Substring(btn.Name.Length - 3);

            //2. 입력 데이터 설정
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if (txt_Act != "Del")
            {
                //삽입, 추가 진행인 경우
                dic.Add("Status", "신규");
            }
            else
            {
                //삭제 진행인경우
                dic.Add("Status", Convert.ToString(gridView1.GetFocusedRowCellValue("Status")) == "삭제" ? "" : "삭제");
            }

            //3. 행삽입, 추가, 삭제 프로세스 진행
            grid.Set_Row(Gc_Corp, dic, txt_Act);
        }

        private void Func_Search()
        {

            Database db = new Database();
            string query = $@"SELECT '' AS Status,
                              Corp_Cd,
                              Corp_Nm,
                              Addr,
                              Tel,

                              Corp_No,
                              Prs_Nm,
                              BS_Con,
                              BS_Tp,
                              Mail,

                              Fax,
                              
                              Ins_Emp_No, 
                              Ins_Date_Time, 
                              Upd_Emp_No, 
                              Upd_Date_Time

                            FROM SC_Corp";

            DataTable dt = db.GetDataTable(query);

            Gc_Corp.DataSource = dt;

            string a = "";

        }

        #region 저장 기능

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Func_Save();
        }

        private void Func_Save()
        {
            //작성내역 저장
            DataTable dt = Gc_Corp.DataSource as DataTable;

            //1. 데이터 불러온 상태인지 검사
            if (!Check_SaveClick(dt)) return;

            //2. 데이터 저장
            for (int curHandle = 0; curHandle < dt.Rows.Count; curHandle++)
            {
                if (Convert.ToString(dt.Rows[curHandle]["Status"]) == "신규")
                {
                    if (!Save_ToDatabase(dt.Rows[curHandle], 'I')) return;
                }
                else if (Convert.ToString(dt.Rows[curHandle]["Status"]) == "수정")
                {
                    if (!Save_ToDatabase(dt.Rows[curHandle], 'U')) return;
                }
                else if (Convert.ToString(dt.Rows[curHandle]["Status"]) == "삭제")
                {
                    if (!Save_ToDatabase(dt.Rows[curHandle], 'D')) return;
                }
            }

            //3. 정상절차 진행
            Func_Search();

            MessageBox.Show("저장이 정상적으로 완료되었습니다.");
        }

        private bool Check_SaveClick(DataTable dt)
        {
            //Data를 불러온 상태인지 검사
            if (dt == null) return false;

            // 사업장 코드 작성 안하면 못넘어가게
            int cd = dt.Select("Corp_Cd = ''").Length;
            if (cd > 0)
            {
                MessageBox.Show("사업장 코드를 입력해주세요.");
                return false;
            }

            //삭제내역 있으면 물어보기
            if (dt.Select("Status = '삭제'").Length > 0)
            {
                DialogResult dialogResult = MessageBox.Show("삭제내역이 있습니다. 삭제하시겠습니까?", "Delete OK Cancle", MessageBoxButtons.OKCancel);

                if (dialogResult == DialogResult.OK)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        private bool Save_ToDatabase(DataRow dr, char div)
        {
            // 데이터베이스에 반영
            // 1. 기본 설정
            Database db = new Database();
            string query = "";

            // 수정에 사용될 데이터 추출
            string Corp_Cd = Convert.ToString(dr["Corp_Cd"]);
            string Corp_Nm = Convert.ToString(dr["Corp_Nm"]);
            string Corp_No = Convert.ToString(dr["Corp_No"]);
            string Addr = Convert.ToString(dr["Addr"]);
            string Tel = Convert.ToString(dr["Tel"]);
            string Prs_Nm = Convert.ToString(dr["Prs_Nm"]);
            string BS_Con = Convert.ToString(dr["BS_Con"]);
            string BS_Tp = Convert.ToString(dr["BS_Tp"]);
            string Mail = Convert.ToString(dr["Mail"]);
            string Fax = Convert.ToString(dr["Fax"]);

            // 쿼리 생성 및 실행
            try
            {
                // 쿼리 생성 및 실행
                if (div == 'I')
                {
                    query = $@"INSERT INTO SC_Corp(Corp_Cd, Corp_Nm, Corp_No, Addr, Tel, Prs_Nm, BS_Con, BS_Tp, Mail, Fax, Ins_Emp_No, Ins_Date_Time)
                                    VALUES ('{Corp_Cd}', '{Corp_Nm}', '{Corp_No}', '{Addr}', '{Tel}', '{Prs_Nm}', '{BS_Con}', '{BS_Tp}', '{Mail}', '{Fax}', '{WrGlobal.LoginID}', GETDATE())";

                    return db.ExecuteQuery(query);
                }
                else if (div == 'U')
                {
                    query = $@"UPDATE SC_Corp
                               SET Corp_Nm = '{Corp_Nm}',
                                   Corp_No = '{Corp_No}',
                                   Addr = '{Addr}',
                                   Tel = '{Tel}',
                                   Prs_Nm = '{Prs_Nm}',
                                   BS_Con = '{BS_Con}',
                                   BS_Tp = '{BS_Tp}',
                                   Mail = '{Mail}',
                                   Fax = '{Fax}',
                                   Upd_Emp_No = '{WrGlobal.LoginID}',
                                   Upd_Date_Time = GETDATE()
                            WHERE Corp_Cd = '{Corp_Cd}'";

                    return db.ExecuteQuery(query);
                }
                else if (div == 'D')
                {
                    query = $@"DELETE FROM SC_Corp
                        WHERE Corp_Cd = '{Corp_Cd}'";

                    return db.ExecuteQuery(query);
                }
            }
            catch (Exception ex)
            {
                // 예외 발생 시에 실행될 코드
                MessageBox.Show("데이터 저장 중 오류가 발생했습니다: " + ex.Message);
                return false;
            }

            // 상태값 초기화
            dr[0] = "";

            return true;
        }

        #endregion 저장 기능 End

        private void Gc_Corp_Click(object sender, EventArgs e)
        {

        }
    }

}