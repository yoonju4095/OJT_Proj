using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using SMT_MES.Controls;
using OJT_Proj.jkj.Model.SystemCode;

namespace OJT_Proj.jkj.View.SystemCode
{
    public partial class Frm_SC_Corp : DevExpress.XtraEditors.XtraForm
    {
        cls_Grid grid = new cls_Grid();

        public Frm_SC_Corp()
        {
            InitializeComponent();
            SetDesign();
        }

        #region 디자인 아이템 생성

        private void SetDesign()
        {
            //GridView 데이터 입력
            Set_GridView(Gv_Corp);
        }

        #region GridView Setting

        private void Set_GridView(GridView gv)
        {
            //Grid 공통 설정
            gv.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;   //Header 정렬
            gv.OptionsView.ColumnAutoWidth = false;     //Column 많으면 스크롤 생기도록 바꾸기

            //Repository 생성 or 이벤트 입력
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
            gv.GridControl.ProcessGridKey += Event_ProcessGridKey;    //행추가, 삽입, 삭제 단축키기능 부여
        }

        private void Event_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView gv = sender as GridView;

            //셀값 수정 시 상태값 수정
            if (e.Column.FieldName == gv.Columns[0].FieldName) return;
            grid.Change_Status(gv, e.RowHandle);
        }

        #region 행 삽입, 추가, 삭제

        private void Event_ProcessGridKey(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case (Keys.Alt | Keys.I): Btn_Row_Ins.PerformClick(); break;  //행삽입
                case (Keys.Alt | Keys.A): Btn_Row_Add.PerformClick(); break;  //행추가
                case (Keys.Alt | Keys.D): Btn_Row_Del.PerformClick(); ; break; //행삭제
            }
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
                dic.Add("Status", Convert.ToString(Gv_Corp.GetFocusedRowCellValue("Status")) == "삭제" ? "" : "삭제");
            }

            //3. 행삽입, 추가, 삭제 프로세스 진행
            grid.Set_Row(Gc_Corp, dic, txt_Act);
        }

        #endregion 행 삽입, 추가, 삭제 End

        #endregion GridView Setting End

        #endregion 디자인 아이템 생성 종료

        #region Event

        private void Frm_SC_Corp_Load(object sender, EventArgs e)
        {
            Func_Search();
        }

        #endregion Event End

        #region 조회 기능

        private void Func_Search()
        {
            //1. 조회 검사
            if (!Check_Search()) return;

            //2. 라인 조회
            SC_Corp corp = new SC_Corp();

            Gc_Corp.DataSource = corp.Select_SC_Corp();

            Gv_Corp.BestFitColumns();   //Column 너비 조정
        }

        private bool Check_Search()
        {
            if ((Gv_Corp.GridControl.DataSource as DataTable)?.Select(@"Status = '신규'
                                                                     OR Status = '수정'
                                                                     OR Status = '삭제'").Length > 0)
            {
                if (MessageBox.Show("작성내역이 사라집니다.\n다른항목을 진행하시겠습니까?", "Yes or No", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //다른항목 진행할 경우
                    return true;
                }
                else
                {
                    //다른항목 진행하지 않을경우
                    return false;
                }
            }

            return true;
        }

        #endregion 조회 기능 End

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
            //데이터베이스에 반영
            //1. 기본 셋팅
            SC_Corp corp = new SC_Corp();
            corp.Corp_Cd = Convert.ToString(dr["Corp_Cd"]); //사업장코드
            if (div != 'D')
            {
                //Delete제외 공통
                corp.Corp_Nm = Convert.ToString(dr["Corp_Nm"]); //사업장명
                corp.Addr = Convert.ToString(dr["Addr"]);    //주소
                corp.Tel = Convert.ToString(dr["Tel"]);     //담당자 전화번호
                corp.Corp_No = Convert.ToString(dr["Corp_No"]); //사업장 등록번호
                corp.Prs_Nm = Convert.ToString(dr["Prs_Nm"]);  //대표자명
                corp.BS_Con = Convert.ToString(dr["BS_Con"]);  //업태
                corp.BS_Tp = Convert.ToString(dr["BS_Tp"]);   //업종
                corp.Mail = Convert.ToString(dr["Mail"]);    //메일
                corp.Fax = Convert.ToString(dr["Fax"]);     //Fax
            }

            //2. DB 적용
            if (div == 'I')
            {
                //Insert
                if (!corp.Ins_Corp())
                {
                    //저장 중 에러 발생시
                    MessageBox.Show("저장 중 에러가 발생하였습니다.");
                    return false;
                }

                //추가 변경사항 private 따로 만들기
            }
            else if (div == 'U')
            {
                //Update
                if (!corp.Upd_Corp())
                {
                    //저장 중 에러 발생시
                    MessageBox.Show("저장 중 에러가 발생하였습니다.");
                    return false;
                }

                //추가 변경사항 private 따로 만들기
            }
            else if (div == 'D')
            {
                //Delete
                if (!corp.Del_Corp())
                {
                    //저장 중 에러 발생시
                    MessageBox.Show("저장 중 에러가 발생하였습니다.");
                    return false;
                }

                //추가 변경사항 private 따로 만들기
            }

            //상태값 초기화
            dr[0] = "";

            return true;
        }

        #endregion 저장 기능 End
    }
}