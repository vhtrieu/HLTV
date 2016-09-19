using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TTHLTV.Utilities;


namespace TTHLTV
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnGiangVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Utilities.ThamSo.ShowFormTeacher();
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void btnHocVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
             Utilities.ThamSo.ShowFormStudent();
        }
        private void btnLopHoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Utilities.ThamSo.ShowFormCoures_Subject();
        }

               private void btnKhoaHoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Utilities.ThamSo.ShowFormCoures();
        }

        private void btnSubject_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Utilities.ThamSo.ShowFormSubjects();
        }

        private void btnChungChi_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Utilities.ThamSo.ShowFormClassList();
        }

        private void btnExamResutl_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Utilities.ThamSo.ShowFormExamResult();
        }

        private void btnLichHoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Utilities.ThamSo.ShowFormTeachingCalendar();
        }

        private void btnCertification_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Utilities.ThamSo.ShowFormCertification();
            frmMoveClass frm = new frmMoveClass();
            frm.ShowDialog();

        }

        private void barbtnMoLop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           // Utilities.ThamSo.showFormAddNewClass();
            frmAddNewClass frm = new frmAddNewClass();
            frm.ShowDialog();
        }

        private void btnDKHV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmRegisterChangeCertificate frm = new frmRegisterChangeCertificate();
            frm.ShowDialog();

        }

        private void btnDkMonHoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Utilities.ThamSo.ShowFormCoures_Subject();
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmPrint frm = new frmPrint();
            frm.ShowDialog();
        }

        private void btnDienKTMon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmEntrySocres frm = new frmEntrySocres();
            frm.ShowDialog();
        }

        private void btnCapCC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmAddNewCertificate frm = new frmAddNewCertificate();
            frm.ShowDialog();
        }

        private void btnDoiChungChi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmChangeCerificate frm = new frmChangeCerificate();
            frm.ShowDialog();
        }

        private void btnDonVi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDonViList frm = new frmDonViList();
            frm.ShowDialog();
        }

        private void btn_LichHoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //updateHocVien frm = new updateHocVien();
            //frm.ShowDialog();

        }

        private void btnInGCN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {                     
            frmPrintCertificate frm = new frmPrintCertificate();
            frm.ShowDialog();
        }

        private void btnChangePass_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmChangePassword frm = new frmChangePassword();
            frm.ShowDialog();
        }

        private void btnThongKe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmStatistics frm = new frmStatistics();
            frm.ShowDialog();
        }


        private void btnBangDiemTongHop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmGeneralMark frm = new frmGeneralMark();
            frm.ShowDialog();
        }

        private void btnTraCuuGCN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmTracuuGCN frm = new frmTracuuGCN();
            frm.ShowDialog();
        }

        private void btnTraCuuHocVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmTracuuHocvien frm = new frmTracuuHocvien();
            frm.ShowDialog();
        }

        private void btnGiaHanGcn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //frmGiahanCertificate frm = new frmGiahanCertificate();
            //frm.ShowDialog();
            Utilities.ThamSo.showFormWebDangKiHoc();
        }

        private void btnChucDanh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmChucDanh frm = new frmChucDanh();
            frm.ShowDialog();
        }

        private void btnTinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmTinhTp frm = new frmTinhTp();
            frm.ShowDialog();
        }

        private void btnTraCucHvCu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmTraCuuHvCu frm = new frmTraCuuHvCu();
            frm.ShowDialog();
        }

        
    }
}
