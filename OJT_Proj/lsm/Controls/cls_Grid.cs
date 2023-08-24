
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using SMT_MES.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OJT_Proj.lsm
{
    class cls_Grid
    {
        #region 디자인 관련

        /// <summary>
        /// GridView Column 생성
        /// </summary>
        /// <param name="gv">입력할 GridView</param>
        /// <param name="caption">표기명칭</param>
        /// <param name="fieldName">연동데이터 Column명칭</param>
        /// <param name="repository">Repository Item(ComboBox, Lookup 등)</param>
        internal void Create_GvColumn(GridView gv, string caption, string fieldName, RepositoryItem repository = null)
        {
            GridColumn col = new GridColumn();
            col.Caption = caption;          //표기명
            col.Name = fieldName;           //Column명
            col.FieldName = fieldName;      //연동 데이터 Column명
            col.ColumnEdit = repository;    //Repository Item(ComboBox, Lookup 등)
            col.Visible = true;             //화면에 보이기

            col.OptionsColumn.AllowEdit = false;   //유저가 수정 허용여부

            gv.Columns.Add(col);            //GridView에 추가
        }

        internal void Create_GvColumn_ByOption(GridView gv, string div_Cd, string fieldName, RepositoryItem repository = null)
        {
            if (WrGlobal.CdOption.ContainsKey(div_Cd))
            {
                if (WrGlobal.CdOption[div_Cd].ContainsKey(fieldName))
                {
                    GridColumn col = new GridColumn();
                    WrGlobal.CodeOption option = WrGlobal.CdOption[div_Cd][fieldName];

                    //표기명
                    col.Caption = option.Nm;
                    //연동 데이터 Column명
                    col.FieldName = fieldName;
                    //화면에 보이기
                    col.Visible = option.DispYn;
                    //유저가 수정 허용여부
                    col.OptionsColumn.AllowEdit = option.LockYn;
                    col.OptionsColumn.AllowFocus = option.LockYn;

                    gv.Columns.Add(col);            //GridView에 추가

                    //Add후에 넣어야 적용되는 작업들
                    //수정허용 시 작업
                    if (option.LockYn)
                    {
                        col.AppearanceCell.BackColor = WrGlobal.EditBgColor;    //Column 배경색
                    }
                }
            }
        }

        internal void Create_GvColumn_ByOption(GridView gv, string div_Cd)
        {
            if (WrGlobal.CdOption.ContainsKey(div_Cd))
            {
                int colCnt = gv.Columns.Count;

                if (gv.OptionsSelection.MultiSelectMode == GridMultiSelectMode.CheckBoxRowSelect)
                {
                    colCnt += 1;
                }

                foreach (string fieldNm in WrGlobal.CdOption[div_Cd].Keys)
                {
                    WrGlobal.CodeOption option = WrGlobal.CdOption[div_Cd][fieldNm];

                    GridColumn col = new GridColumn();

                    //표기명
                    col.Caption = option.Nm;
                    //연동 데이터 Column명
                    col.FieldName = fieldNm;
                    //화면에 보이기
                    col.Visible = option.DispYn;
                    //유저가 수정 허용여부
                    col.OptionsColumn.AllowEdit = option.LockYn;
                    col.OptionsColumn.AllowFocus = option.LockYn;
                    
                    gv.Columns.Add(col);            //GridView에 추가

                    //컬럼 순서 설정
                    gv.Columns[fieldNm].AbsoluteIndex = (colCnt - 1) + option.Disp_Seq;

                    //Add후에 넣어야 적용되는 작업들
                    //수정허용 시 작업
                    if (option.LockYn)
                    {
                        col.AppearanceCell.BackColor = WrGlobal.EditBgColor;    //Column 배경색
                    }
                }
            }
        }

        /// <summary>
        /// GridColumn 변경 허용
        /// </summary>
        /// <param name="col">적용할 Column</param>
        internal void Column_AllowEdit(GridColumn col, bool edit = true)
        {
            if (col == null) return;
            col.OptionsColumn.AllowEdit = edit;
            col.OptionsColumn.AllowFocus = edit;
            if (edit)
            {
                col.AppearanceCell.BackColor = WrGlobal.EditBgColor;    //Column 배경색
            }
            else
            {
                col.AppearanceCell.BackColor = Color.White;    //Column 배경색
                col.OptionsColumn.AllowFocus = false;
            }
        }

        internal enum TypeList
        {
            TInt,
            TFloat,
            TDate,
            TDateTime,
        }

        internal void SetCol_Type(GridColumn col, TypeList type)
        {
            if (col == null) return;
            switch (type)
            {
                case TypeList.TInt:
                    col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;

                    //표기타입
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    col.DisplayFormat.FormatString = "#,##0";
                    break;
                case TypeList.TFloat:
                    col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;

                    //표기타입
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    col.DisplayFormat.FormatString = "#,##0.##";
                    break;
                case TypeList.TDate:
                    col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    break;

                case TypeList.TDateTime:
                    col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                    //표기타입
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    col.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
                    break;
            }
        }

        internal void SetCol_Type_POP(GridColumn col, TypeList type)
        {
            if (col == null) return;

            switch (type)
            {
                case TypeList.TInt:
                    col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;

                    //표기타입
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    col.DisplayFormat.FormatString = "#,##0";
                    break;
                case TypeList.TFloat:
                    col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;

                    //표기타입
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    col.DisplayFormat.FormatString = "#,##0.##";
                    break;
                case TypeList.TDate:
                    col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;

                    // 달력의 폰트 사이즈 변경
                    DevExpress.XtraEditors.Repository.RepositoryItemDateEdit CalItem = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();

                    CalItem.CellSize = new Size(60, 50);

                    //달력 날짜 크기 키우기
                    int C_FontSize = 8;
                    CalItem.AppearanceCalendar.DayCellHoliday.FontSizeDelta = C_FontSize;
                    CalItem.AppearanceCalendar.DayCell.FontSizeDelta = C_FontSize;
                    CalItem.AppearanceCalendar.DayCellHighlighted.FontSizeDelta = C_FontSize;
                    CalItem.AppearanceCalendar.DayCellSelected.FontSizeDelta = C_FontSize;
                    CalItem.AppearanceCalendar.DayCellPressed.FontSizeDelta = C_FontSize;
                    CalItem.AppearanceCalendar.DayCellToday.FontSizeDelta = C_FontSize;
                    CalItem.AppearanceCalendar.DayCellToday.BackColor = Color.LightGray;
                    CalItem.AppearanceCalendar.Header.FontSizeDelta = C_FontSize;
                    CalItem.AppearanceCalendar.Header.ForeColor = Color.Black;
                    CalItem.AppearanceCalendar.HeaderPressed.FontSizeDelta = C_FontSize;
                    CalItem.AppearanceCalendar.HeaderHighlighted.FontSizeDelta = C_FontSize;

                    //적용
                    col.ColumnEdit = CalItem;

                    break;
                case TypeList.TDateTime:
                    col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                    //표기타입
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    col.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
                    break;
            }
        }

        #endregion 디자인 관련 End

        #region Event 관련

        /// <summary>
        /// 셀값 입력시 중복값 검사(ValidatingEditor Event용)
        /// </summary>
        /// <param name="gv">검사 할 GridView</param>
        /// <param name="e">ValidatingEditor의 EventArgs</param>
        /// <param name="fieldName">검사 할 Column FieldName</param>
        internal void Check_OverLap_CellValue(GridView gv, BaseContainerValidateEditorEventArgs e, string fieldName)
        {
            if (gv.FocusedColumn.FieldName == fieldName)
            {
                //입력된 데이터값과 일치하는 Data수 검사
                if (Convert.ToString(gv.GetFocusedRowCellValue(gv.Columns[0].FieldName)) == "신규")
                {
                    int cnt = (gv.GridControl.DataSource as DataTable).Select($" {fieldName} = '{Convert.ToString(e.Value)}'").Count();

                    //1개 이상이면 입력 불가
                    if (cnt > 0)
                    {
                        e.Valid = false;    //입력 불가 처리
                        e.ErrorText = $"중복된 {gv.FocusedColumn.Caption}이(가) 있습니다.";  //경고 알림
                    }
                }
                else
                {
                    e.Valid = false;
                    e.ErrorText = $"저장된 {gv.FocusedColumn.Caption}은/는 수정할 수 없습니다.";
                }
            }
        }
        
        /// <summary>
        /// 셀값 수정 시 상태값 변경(CellValueChanged Event용) / 가장 좌측 Column이 상태Column이여야함
        /// </summary>
        /// <param name="gv"></param>
        /// <param name="rowHandle"></param>
        internal void Change_Status(GridView gv, int rowHandle)
        {
            //셀값 수정 시 상태값 수정
            DataTable dt = gv.GridControl.DataSource as DataTable;
            string str_Status = Convert.ToString(gv.GetFocusedRowCellValue(dt.Columns[0].Caption));    //상태 값

            if (str_Status != "신규" &&
                str_Status != "신규(일괄)" &&
                str_Status != "수정" &&
                str_Status != "삭제")
            {
                gv.SetRowCellValue(rowHandle, gv.Columns[0].FieldName, "수정");
            }
        }

        #region 행 삽입, 추가 삭제

        /// <summary>
        /// 행삽입, 추가, 삭제 프로세스
        /// </summary>
        /// <param name="gc">이벤트가 발생될 GridControl</param>
        /// <param name="keys">입력 키</param>
        internal void Set_Row(GridControl gc, Dictionary<string, object> dicData, string keys)
        {
            GridView gv = gc.MainView as GridView;
            try
            {
                switch (keys)
                {
                    case "Ins": Add_Row(gv, dicData, 'U'); break;  //행삽입
                    case "Add": Add_Row(gv, dicData, 'D'); break;  //행추가
                    case "Del": Del_Row(gv, dicData); break;       //행삭제
                }
            }
            catch(Exception ex)
			{
                MessageBox.Show(ex.Message);
			}
        }

        /// <summary>
        /// Gridview Row 삽입
        /// </summary>
        /// <param name="gv">입력될 GridView</param>
        /// <param name="dicData">Row 기본값으로 입력될 데이터</param>
        /// <param name="pos">입력 위치 선택행 기준 / U : 상단입력, D : 하단입력</param>
        private void Add_Row(GridView gv, Dictionary<string, object> dicData, char pos)
        {
            //Row 데이터 하단 추가
            //1. 데이터 입력 준비
            DataTable dt = gv.GridControl.DataSource as DataTable;
            if (dt == null) return;
            int selRowCount = gv.SelectedRowsCount == 0 ? 1 : gv.SelectedRowsCount; //선택된 행 수 = 입력할 행 수

            //2. 입력 위치 설정
            int Ins_Pos = gv.FocusedRowHandle == -2147483648 ? 0 : gv.FocusedRowHandle;
            if (pos == 'D') Ins_Pos++;  //하단입력일 경우 + 1

            //2. 기본입력 데이터 설정
            for (int idx = 0; idx < selRowCount; idx++)
            {
                DataRow dr = dt.NewRow();

                foreach (string key in dicData.Keys)
                {
                    dr[key] = dicData[key];
                }

                dt.Rows.InsertAt(dr, Ins_Pos);
            }
        }

        private void Del_Row(GridView gv, Dictionary<string, object> dicData)
        {
            //선택행 삭제 표기
            //0. Dictionary 입력 검사(개발자용)
            if (dicData.Count <= 0)
            {
                MessageBox.Show("Dictionary[Del] 데이터를 추가하지 않았습니다.");
                return;
            }

            //1. 데이터 입력 준비
            DataTable dt = gv.GridControl.DataSource as DataTable;
            int selRowCount = gv.SelectedRowsCount; //선택된 행 수 = 입력할 행 수
            int[] selRow = gv.GetSelectedRows();

            //2. 입력 데이터 설정
            for (int idx = 0; idx < selRowCount; idx++)
            {
                foreach (string key in dicData.Keys)
                {
                    if ((key == "Status" || key == "Disp_Seq") &&
                         Convert.ToString(gv.GetRowCellValue(selRow[idx], key)) == "신규")
                    {
                        //상태행이 신규인경우 해당 행 삭제
                        gv.DeleteRow(selRow[idx]);

                        idx--;
                        selRowCount--;
                        break;
                    }
                    else if ((key == "Status" || key == "Disp_Seq") &&
                         Convert.ToString(gv.GetRowCellValue(selRow[idx], key)) == "삭제")
                    {
                        //상태행이 삭제인경우 삭제표기 취소
                        gv.SetRowCellValue(selRow[idx], key, "");
                        break;
                    }
                    else
                    {
                        gv.SetRowCellValue(selRow[idx], key, dicData[key]);
                    }
                }
            }

            gv.SelectRow(gv.FocusedRowHandle);
        }

        #endregion 행 삽입, 추가, 삭제 End

        internal void RowStyle_ChangeBg_ByStatus(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle < 0 ) return;

            //삭제시 배경색 지정
            GridView gv = sender as GridView;
            DataTable dt = gv.GridControl.DataSource as DataTable;
            if (dt == null) return;

            string str_Status = Convert.ToString(dt.Rows[e.RowHandle][gv.Columns[0].FieldName]);    //상태 값
            Color delBgColor = Color.LightGray; //배경색

            if (str_Status == "삭제")
            {
                e.Appearance.BackColor = delBgColor;
            }
        }

        internal void RowStyle_DataExistsYn(GridView gv, RowStyleEventArgs e, string fieldName)
        {
            //검사항목 데이터가 있으면 'Y', 없으면 'N'으로하고
            //데이터가 없으면 회색 표기
            if (e.RowHandle > -1 && gv.GetRowCellValue(e.RowHandle, fieldName).ToString() == "N")
            {
                e.Appearance.BackColor = Color.Gray;
            }
        }

        /// <summary>
        /// Form닫을때 저장내역 검사
        /// </summary>
        /// <param name="gv">입력할 GridView</param>
        /// <param name="fieldName">상태값 Column FieldName</param>
        /// <returns></returns>
        internal bool Check_Gv_FormClosing(GridView gv, string fieldName)
        {
            try
            {
                //true : 종료방지, false : 정상종료
                DataTable dt = gv.GridControl.DataSource as DataTable;
                if (dt == null) return false;
                bool writeFlag = false;

                //1. 저장하지 않은 내역있는지 확인
                foreach (DataRow dr in dt.Rows)
                {
                    if (Convert.ToString(dr[fieldName]) == "신규" ||
                        Convert.ToString(dr[fieldName]) == "수정" ||
                        Convert.ToString(dr[fieldName]) == "삭제")
                    {
                        writeFlag = true;
                        break;
                    }
                }

                //2. 사용자 선택
                if (writeFlag)
                {
                    if (MessageBox.Show("저장하지 않은 내역이 있습니다.\n종료 하시겠습니까?", "Check_Save", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        internal void RowNumber_Indicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            //GridView Indicator(좌측 현재행 표기)에 순번 표기하기
            GridView gv = sender as GridView;
            //데이터 없음 방지
            if (sender == null || gv.RowCount <= 0) return;

            //상단 Column 표시명
            if (e.RowHandle == GridControl.InvalidRowHandle) e.Info.DisplayText = "순번";

            //표기값
            if (e.Info.IsRowIndicator) e.Info.DisplayText = (e.RowHandle + 1).ToString();

            //디자인
            e.Info.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;   //정렬
        }

        internal void RowNumber_Indicator(GridView gv)
        {
            if (gv == null) return;

            gv.IndicatorWidth = 50;

            gv.CustomDrawRowIndicator += new RowIndicatorCustomDrawEventHandler((sender, e) => {
                //데이터 없음 방지
                if (gv.RowCount <= 0) return;

                //상단 Column 표시명
                if (e.RowHandle == GridControl.InvalidRowHandle) e.Info.DisplayText = "순번";

                //표기값
                if (e.Info.IsRowIndicator) e.Info.DisplayText = (e.RowHandle + 1).ToString();

                //디자인
                e.Info.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;   //정렬
            });
        }

        /// <summary>
        /// RepositoryLookup "품명" 선택 시 해당 품목정보 다른 Column에 뿌리기
        /// </summary>
        /// <param name="drChanged">적용할 DataRow</param>
        /// <param name="item_Cd">선택된 품목코드</param>
        internal void SetInfo_Item(DataRow drChanged, string item_Cd)
        {
            //if (drChanged == null) return;

            //DataRow drItem = null;  //불러올 품목정보Row

            //Model.Basic.BS_Item item = new Model.Basic.BS_Item();
            //item.Item_Cd = item_Cd;
            //drItem = item.Select_Item_RowInfo();

            //if (drItem == null || item_Cd == "")
            //{
            //    drChanged["Item_Cd"] = null;
            //    drChanged["Item_Nm"] = null;
            //    drChanged["Alias"]   = null;
            //    if (drChanged.Table.Columns.Contains("ItemClass_Nm")) { drChanged["ItemClass_Nm"] = null; }
            //    if (drChanged.Table.Columns.Contains("Spec"))         { drChanged["Spec"]         = null; }
            //    if (drChanged.Table.Columns.Contains("Unit"))         { drChanged["Unit"]         = null; }
            //    if (drChanged.Table.Columns.Contains("CT"))           { drChanged["CT"]           = null; }
            //    if (drChanged.Table.Columns.Contains("Grade"))        { drChanged["Grade"]        = null; }
            //    if (drChanged.Table.Columns.Contains("Base_Weight"))  { drChanged["Base_Weight"]  = null; }
            //    if (drChanged.Table.Columns.Contains("Color"))        { drChanged["Color"]        = null; }
            //}
            //else
            //{
            //    drChanged["Item_Cd"] = drItem["Item_Cd"];
            //    drChanged["Alias"]   = drItem["Alias"];

            //    //공통
            //    if (drChanged.Table.Columns.Contains("ItemClass_Nm")) { drChanged["ItemClass_Nm"] = drItem["ItemClass_Nm"]; }
            //    if (drChanged.Table.Columns.Contains("Spec"))         { drChanged["Spec"]         = drItem["Spec"]; }
            //    if (drChanged.Table.Columns.Contains("Unit"))         { drChanged["Unit"]         = drItem["Unit"]; }
            //    if (drChanged.Table.Columns.Contains("CT"))           { drChanged["CT"]           = drItem["CT"]; }
            //    if (drChanged.Table.Columns.Contains("Grade"))        { drChanged["Grade"]        = drItem["Grade"]; }
            //    if (drChanged.Table.Columns.Contains("Base_Weight"))  { drChanged["Base_Weight"]  = drItem["Base_Weight"]; }
            //    if (drChanged.Table.Columns.Contains("Color"))        { drChanged["Color"]        = drItem["Color"]; }
            //}
        }

        /// <summary>
        /// 거래처 수정 시 해당Row의 품목Column에 해당 거래처에 해당하는 ItemList 적용
        /// </summary>
        /// <param name="gv">적용할 GridView</param>
        /// <param name="item_Div">품목 구분 리스트</param>
        internal void SetRpoItem_ByCust(GridView gv, string[] item_Div)
        {
            //gv.CustomRowCellEditForEditing += new CustomRowCellEditEventHandler((sender, e) =>
            //{
            //    //Grid데이터가 없으면 스킵
            //    if (e.RowHandle < 0) return;
            //    //현재행 != 수정하려는 행일 시 스킵
            //    if (e.RowHandle != gv.FocusedRowHandle) return;
            //    //적용되려는열이 품목이 아니면 스킵
            //    if (e.Column.FieldName != "Item_Nm") return;

            //    //품목리스트 호출
            //    Model.Basic.BS_Item bi = new Model.Basic.BS_Item();
            //    DataRow dr = gv.GetDataRow(e.RowHandle);

            //    DataTable dtItem = bi.Select_Item_List_ByCust(Convert.ToString(dr["Cust_Cd"]), item_Div);

            //    //해당 Column인 Cell RepositoryItem 적용
            //    cls_Repository rpo = new cls_Repository();
            //    RepositoryItemSearchLookUpEdit rpoLup = rpo.Create_RepositoryItemSearchLookUp(dtItem, "Item_Cd", "Item_Nm");
            //    rpoLup.View.OptionsView.ColumnAutoWidth = false;   //Column Width 조절용
            //    rpoLup.BestFitMode = BestFitMode.BestFitResizePopup;          //Column Width 조절용
            //    e.RepositoryItem = rpoLup;
            //});
        }

        internal void SetRpoItem_ByCust(GridView gv, string[] item_Div, string task_Div)
        {
            //gv.CustomRowCellEditForEditing += new CustomRowCellEditEventHandler((sender, e) =>
            //{
            //    //Grid데이터가 없으면 스킵
            //    if (e.RowHandle < 0) return;
            //    //현재행 != 수정하려는 행일 시 스킵
            //    if (e.RowHandle != gv.FocusedRowHandle) return;
            //    //적용되려는열이 품목이 아니면 스킵
            //    if (e.Column.FieldName != "Item_Nm") return;

            //    //품목리스트 호출
            //    Model.Basic.BS_Item bi = new Model.Basic.BS_Item();
            //    DataRow dr = gv.GetDataRow(e.RowHandle);

            //    DataTable dtItem = bi.Select_Item_List_ByCust(Convert.ToString(dr["Cust_Cd"]), item_Div);

            //    //해당 Column인 Cell RepositoryItem 적용
            //    cls_Repository rpo = new cls_Repository();
            //    RepositoryItemSearchLookUpEdit rpoLup = rpo.Create_RepositoryItemSearchLookUp(dtItem, "Item_Cd", "Item_Nm");
            //    SetLupView_Item(rpoLup, task_Div);
            //    e.RepositoryItem = rpoLup;
            //});
        }

        /// <summary>
        /// Repository LookupEdit의 PopUp에해당하는 목록이 품목일 때 초기화 옵션 적용
        /// </summary>
        /// <param name="lup"></param>
        /// <param name="task_Div"></param>
        internal void SetLupView_Item(RepositoryItemSearchLookUpEdit lup, string task_Div)
        {
            lup.PopulateViewColumns();
            lup.View.OptionsView.ColumnAutoWidth = false;   //Column Width 조절용
            lup.View.OptionsView.RowAutoHeight = true;      //MultiLine 

            lup.BestFitMode = BestFitMode.BestFitResizePopup;          //Column Width 조절용

            //모든 PopupColumn 검색
            foreach (GridColumn col in lup.View.Columns)
            {
                bool colExists = false;

                //초기화옵션 검색
                foreach (string fieldNm in WrGlobal.CdOption[task_Div].Keys)
                {
                    if (col.FieldName != fieldNm) continue; //Popup의 FieldName과 CdOption의 FieldName이 다르면 다음 CdOption 검색

                    //FieldName과 초기화옵션의 FieldName이 같으면 PopUp Column의 Caption 조정
                    col.Caption = WrGlobal.CdOption[task_Div][fieldNm].Nm;
                    col.Visible = WrGlobal.CdOption[task_Div][fieldNm].DispYn;

                    colExists = true;
                }

                //Column이 초기화옵션에 없으면 숨기기
                if (!colExists)
                {
                    col.Visible = false;
                }
            }


            //규격 멀티라인 옵션 적용
            if (WrGlobal.ProcOption["BS"].ContainsKey("Item_Spec_MultiLineYN"))
            {
                if (WrGlobal.ProcOption["BS"]["Item_Spec_MultiLineYN"] == "Y")
                {
                    GridColumn colSpec = lup.View.Columns.ColumnByFieldName("Spec");

                    if (colSpec != null)
                    {
                        RepositoryItemMemoEdit memoEdit = new RepositoryItemMemoEdit();
                        lup.RepositoryItems.AddRange(new RepositoryItem[] { memoEdit });

                        colSpec.ColumnEdit = memoEdit;
                        colSpec.MinWidth = 100;
                    }
                }
            }

            lup.View.BestFitColumns();
        }

        internal void SetLupView_Item(SearchLookUpEdit lup, string task_Div)
        {
            lup.ForceInitialize();                   //Datasource 적용(안해주면 visible 안먹힘)
            lup.Properties.PopulateViewColumns();
            lup.Properties.View.OptionsView.ColumnAutoWidth = false;
            lup.Properties.View.OptionsView.RowAutoHeight = true;                 //MultiLine 
            lup.Properties.BestFitMode = BestFitMode.BestFitResizePopup;          //Column Width 조절용

            //모든 PopupColumn 검색
            foreach (GridColumn col in lup.Properties.View.Columns)
            {
                bool colExists = false;

                //초기화옵션 검색
                foreach (string fieldNm in WrGlobal.CdOption[task_Div].Keys)
                {
                    if (col.FieldName != fieldNm) continue; //Popup의 FieldName과 CdOption의 FieldName이 다르면 다음 CdOption 검색

                    //FieldName과 초기화옵션의 FieldName이 같으면 PopUp Column의 Caption 조정
                    col.Caption = WrGlobal.CdOption[task_Div][fieldNm].Nm;
                    col.Visible = WrGlobal.CdOption[task_Div][fieldNm].DispYn;
                    colExists = true;
                }

                //Column이 초기화옵션에 없으면 숨기기
                if (!colExists)
                {
                    col.Visible = false;
                }
            }

            //규격 멀티라인 옵션
            if (WrGlobal.ProcOption["BS"].ContainsKey("Item_Spec_MultiLineYN"))
            {
                if (WrGlobal.ProcOption["BS"]["Item_Spec_MultiLineYN"] == "Y")
                {
                    GridColumn colSpec = lup.Properties.View.Columns.ColumnByFieldName("Spec");

                    if (colSpec != null)
                    {
                        RepositoryItemMemoEdit memoEdit = new RepositoryItemMemoEdit();
                        colSpec.ColumnEdit = memoEdit;
                        colSpec.MinWidth = 100;
                    }
                }
            }

            //lup.Properties.Popup += new EventHandler((sender, e) => {

            //    if (lup == null) return;

            //    lup.Properties.View.BestFitColumns();

            //});
        }

        #endregion
    }
}
