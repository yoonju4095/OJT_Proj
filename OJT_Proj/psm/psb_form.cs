using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using SMT_MES.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OJT_Proj.psm.SB_Model;

namespace OJT_Proj.psm
{
    public partial class psb_form : DevExpress.XtraEditors.XtraForm
    {
        cls_Grid grid = new cls_Grid();

        public psb_form()
        {
            InitializeComponent();
            SetDesign();
        }

        private void SetDesign()
        {
            Set_GridView(Gv_Corp);
        }

        private void Set_GridView(GridView gv)//그리드셋팅
        {
            gv.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;   //Header 정렬
            gv.OptionsView.ColumnAutoWidth = false; //자동 넓이 끔

            RepositoryItemTextEdit txt_Corp_Nm = new RepositoryItemTextEdit(); txt_Corp_Nm.MaxLength = 30;  //사업장 이름
            RepositoryItemTextEdit txt_Addr = new RepositoryItemTextEdit(); txt_Addr.MaxLength = 50;  //주소
            RepositoryItemTextEdit txt_Tel = new RepositoryItemTextEdit(); txt_Tel.MaxLength = 20;  //담당자 전화번호
            RepositoryItemTextEdit txt_Corp_No = new RepositoryItemTextEdit(); txt_Corp_No.MaxLength = 15;  //사업장 등록번호
            RepositoryItemTextEdit txt_Prs_Nm = new RepositoryItemTextEdit(); txt_Prs_Nm.MaxLength = 20;  //대표자명
            RepositoryItemTextEdit txt_BS_Con = new RepositoryItemTextEdit(); txt_BS_Con.MaxLength = 30;  //업태
            RepositoryItemTextEdit txt_BS_Tp = new RepositoryItemTextEdit(); txt_BS_Tp.MaxLength = 30;  //업종
            RepositoryItemTextEdit txt_Mail = new RepositoryItemTextEdit(); txt_Mail.MaxLength = 30;  //메일
            RepositoryItemTextEdit txt_Fax = new RepositoryItemTextEdit(); txt_Fax.MaxLength = 30;  //Fax
            RepositoryItemTextEdit txt_Corp_Cd = new RepositoryItemTextEdit(); txt_Corp_Cd.MaxLength = 2;  //Fax

            grid.Create_GvColumn(gv, "상태", "Status");
            grid.Create_GvColumn(gv, "사업장 코드", "Corp_Cd", txt_Corp_Cd);
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
            grid.Column_AllowEdit(gv.Columns["Corp_Cd"]);  //순번
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
            //gv.GridControl.ProcessGridKey += Event_ProcessGridKey;    //행추가, 삽입, 삭제 단축키기능 부여
        }

        //행삽입,행추가,행삭제
        private void BtnRow_Click(object sender, EventArgs e)
        {
            SimpleButton btn = (SimpleButton)sender;
            string txt_Btn = btn.Name.Substring(btn.Name.Length - 3);

            Dictionary<string, object> dic = new Dictionary<string, object>();
            if (txt_Btn != "Del")
            {
                dic.Add("Status", "신규"); //추가, 삽입
            }
            else
            {
                dic.Add("Status", Convert.ToString(Gv_Corp.GetFocusedRowCellValue("Status")) == "삭제" ? "" : "삭제");
            }

            grid.Set_Row(Gc_Corp, dic, txt_Btn);
        }

        private void psb_form_Load(object sender, EventArgs e)
        {
            Corp_Search();
        }

        private void Corp_Search()
        {
            if (!Check_Search())
            {
                return;
            }

            SC_Corp corp = new SC_Corp();

            Gc_Corp.DataSource = corp.Select_SC_Corp();

            Gv_Corp.BestFitColumns();
        }

        private bool Check_Search()
        {
            if ((Gv_Corp.GridControl.DataSource as DataTable)?.Select(@"Status = '신규' 
                                                                OR Status = '수정'
                                                                OR Status = '삭제'").Length > 0) // ?는 null이 아닐 때만 실행한단 뜻
            {
                if (MessageBox.Show("작성내역이 사라집니다. \n다른항목을 진행하시겠습니까?", "Yes or No", MessageBoxButtons.YesNo) == DialogResult.Yes)
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

        //저장
        private void BtnSave_Click(object sender, EventArgs e)
        {
            Corp_Save();
        }

        private void Corp_Save()
        {
            //그리드 내용 저장
            DataTable dt = (DataTable)Gc_Corp.DataSource;
            if (!Check_SaveClick(dt)) return;
            for (int index = 0; index < dt.Rows.Count; index++)
            {
                if (Convert.ToString(dt.Rows[index]["Status"]) == "신규")
                {
                    if (!Save_ToDatabase(dt.Rows[index], 'I')) return;
                }
                else if (Convert.ToString(dt.Rows[index]["Status"]) == "수정")
                {
                    if (!Save_ToDatabase(dt.Rows[index], 'U')) return;
                }
                else if (Convert.ToString(dt.Rows[index]["Status"]) == "삭제")
                {
                    if (!Save_ToDatabase(dt.Rows[index], 'D')) return;
                }
            }

            Corp_Search();

            MessageBox.Show("저장이 정상적으로 완료되었습니다.");
        }

        private bool Save_ToDatabase(DataRow dr, char status)
        {
            //DB로 여기서 보내는 것
            SC_Corp corp = new SC_Corp();
            corp.Corp_Cd = dr["Corp_Cd"].ToString(); //조건에 넣어야되니깐 사업장 번호 필수 셋팅


            if (status != 'D')
            {
                // 등록|수정할때 값필요함
                corp.Corp_Nm = Convert.ToString(dr["Corp_Nm"]);
                corp.Addr = Convert.ToString(dr["Addr"]);
                corp.Tel = Convert.ToString(dr["Tel"]);
                corp.Corp_No = Convert.ToString(dr["Corp_No"]);
                corp.Prs_Nm = Convert.ToString(dr["Prs_Nm"]);
                corp.BS_Con = Convert.ToString(dr["BS_Con"]);
                corp.BS_Tp = Convert.ToString(dr["BS_Tp"]);
                corp.Mail = Convert.ToString(dr["Mail"]);
                corp.Fax = Convert.ToString(dr["Fax"]);
            }

            //I,U,D 맞게 DB넣기
            if (status == 'I')
            {
                if (!corp.Ins_Corp())
                {
                    //저장 에러났을 때
                    MessageBox.Show("저장 중 에러가 발생했습니다.");
                    return false;
                }
            }
            else if (status == 'U')
            {
                if (!corp.Upd_Corp())
                {
                    //저장 에러났을 때
                    MessageBox.Show("저장 중 에러가 발생했습니다.");
                    return false;
                }
            }
            else if (status == 'D')
            {
                if (!corp.Del_Corp())
                {
                    //저장 에러났을 때
                    MessageBox.Show("저장 중 에러가 발생했습니다.");
                    return false;
                }
            }

            dr[0] = "";//Status 초기화 (원래 수정,신규... 적혀있었음)

            return true;
        }

        private void Event_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView gv = sender as GridView;

            //셀값 수정 시 상태값 수정
            if (e.Column.FieldName == gv.Columns[0].FieldName) return;
            grid.Change_Status(gv, e.RowHandle);
        }

        private bool Check_SaveClick(DataTable dt)
        {
            //Data를 불러온 상태인지 검사
            if (dt == null) return false;

            // 사업장 코드 작성 안하면 못넘어가게
            int t = dt.Select("Corp_Cd = '' AND NOT Status = '삭제'").Length;
            if (t > 0)
            {
                MessageBox.Show("사업장 코드를 입력해주세요.\nex) 01, 02, 03");
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

    }
}