using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using SMT_MES.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMT_MES.Controls
{
    class cls_Repository
    {
        #region LookupEdit
        
        /// <summary>
        /// Repository LookupEdit ComboBox 형태로 생성
        /// </summary>
        /// <param name="dt">입력할 DataTable</param>
        /// <param name="str_Value">Value로 가질 Table Column명</param>
        /// <param name="str_Disp">화면에 표기할 Table Column명</param>
        internal RepositoryItemLookUpEdit Create_RepositoryItem(DataTable dt, string str_Value, string str_Disp)
        {
            //Repository LookUpEdit 생성
            RepositoryItemLookUpEdit rpoLup = new RepositoryItemLookUpEdit();
            rpoLup.DataSource = dt;     //공통코드 리스트
            rpoLup.ValueMember = str_Value;             //실제값
            rpoLup.DisplayMember = str_Disp;            //표시값

            rpoLup.NullText = "";                       //빈값 그냥 빈칸으로 나오도록 수정
            rpoLup.PopulateColumns();                   //Datasource 적용(안해주면 visible 안먹힘)
            rpoLup.Columns[str_Value].Visible = false;  //코드 숨김
            rpoLup.ShowHeader = false;                  //Column Header 숨김
            
            return rpoLup;
        }

        internal RepositoryItemSearchLookUpEdit Create_RepositoryItemSearchLookUp(DataTable dt, string str_Value, string str_Disp)
        {
            //Repository SearchLookUpEdit 생성
            RepositoryItemSearchLookUpEdit rpoLup = new RepositoryItemSearchLookUpEdit();
            rpoLup.DataSource = dt;             //공통코드 리스트
            rpoLup.ValueMember = str_Value;     //실제값
            rpoLup.DisplayMember = str_Disp;    //표시값

            rpoLup.NullText = "";   //빈값 그냥 빈칸으로 나오도록 수정

            return rpoLup;
        }

        internal RepositoryItemSearchLookUpEdit Create_RepositoryItemSearchLookUp(DataTable dt, string str_Value, string str_Disp, string div)
        {
            //Repository SearchLookUpEdit 생성
            RepositoryItemSearchLookUpEdit rpoLup = new RepositoryItemSearchLookUpEdit();
            rpoLup.DataSource = dt;             //공통코드 리스트
            rpoLup.ValueMember = str_Value;     //실제값
            rpoLup.DisplayMember = str_Disp;    //표시값

            rpoLup.NullText = "";   //빈값 그냥 빈칸으로 나오도록 수정

            return rpoLup;
        }

        #endregion LookupEdit End

        /// <summary>
        /// Repository CheckBox 생성, 체크값 : "Y", 미체크값 : "N"
        /// </summary>
        /// <returns></returns>
        internal RepositoryItemCheckEdit Create_rpoChk()
        {
            RepositoryItemCheckEdit rpoChk = new RepositoryItemCheckEdit();
            rpoChk.AllowGrayed = false;
            rpoChk.ValueChecked = "Y";
            rpoChk.ValueUnchecked = "N";
            rpoChk.NullStyle = StyleIndeterminate.Unchecked;

            return rpoChk;
        }

        /// <summary>
        /// Repository TextBox 숫자만 입력
        /// </summary>
        /// <returns></returns>
        internal RepositoryItemTextEdit Create_rpoTxt_Numeric()
        {
            RepositoryItemTextEdit rpoTxt = new RepositoryItemTextEdit();
            rpoTxt.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

            return rpoTxt;
        }

        /// <summary>
        /// Repository TextBox 최대 글자수 지정
        /// </summary>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        internal RepositoryItemTextEdit Create_rpoTxt_Length(int maxLength)
        {
            RepositoryItemTextEdit rpoTxt = new RepositoryItemTextEdit();
            rpoTxt.MaxLength = maxLength;

            return rpoTxt;
        }

        /// <summary>
        /// Repository ToggleSwitch 기본 셋팅
        /// </summary>
        /// <returns></returns>
        internal RepositoryItemToggleSwitch Create_rpoToggle()
        {
            RepositoryItemToggleSwitch rpo = new RepositoryItemToggleSwitch();
            rpo.ValueOff = "N";
            rpo.ValueOn = "Y";

            rpo.ShowText = true;
            rpo.OffText = "N";
            rpo.OnText = "Y";

            return rpo;
        }

        /// <summary>
        /// Repository DateEdit 기본셋팅
        /// </summary>
        /// <returns></returns>
        internal RepositoryItemDateEdit Create_rpoDate()
        {
            //날짜데이터 입력 편의성
            RepositoryItemDateEdit rpo = new RepositoryItemDateEdit();
            rpo.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;

            return rpo;
        }

        internal void Set_Dtp(DateEdit dtp)
        {
            //날짜데이터 입력 편의성
            dtp.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
        }

        internal RepositoryItemTimeSpanEdit Create_TimeSpan(string format)
        {
            //날짜데이터 입력 편의성
            RepositoryItemTimeSpanEdit rpo = new RepositoryItemTimeSpanEdit();
            rpo.AllowEditDays = false;  //날짜수정 불가능처리
            rpo.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;    //":"따로 입력 안해도 되도록 처리
            rpo.Mask.EditMask = format;
            rpo.Mask.UseMaskAsDisplayFormat = true;

            return rpo;
        }

        internal void Set_TimeSpan(TimeSpanEdit ts, string format)
        {
            ts.Properties.AllowEditDays = false;  //날짜수정 불가능처리
            ts.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;    //":"따로 입력 안해도 되도록 처리
            ts.Properties.Mask.EditMask = format;
            ts.Properties.Mask.UseMaskAsDisplayFormat = true;
        }

        internal RepositoryItemMemoEdit Create_rpoMemo()
        {
            RepositoryItemMemoEdit rpo = new RepositoryItemMemoEdit();

            return rpo;
        }

        internal RepositoryItemCalcEdit Create_rpoCalc()
        {
            RepositoryItemCalcEdit rpo = new RepositoryItemCalcEdit();
            rpo.ValidateOnEnterKey = true;

            return rpo;
        }
    }
}
