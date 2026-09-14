using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPORTSHOP._03_QuanLyKho
{
    public partial class FormLStonkho : Form
    {
        private KetNoiDuLieu kt = new KetNoiDuLieu();

        private DataTable dtLichSu;
        public FormLStonkho()
        {
            InitializeComponent();

            LoadLoai();
            LoadLichSu();

            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            cmbLoai.SelectedIndexChanged += cmbLoai_SelectedIndexChanged;
            btnLamMoi.Click += btnLamMoi_Click;
        }

        private void LoadLichSu()
        {
            string sql = @"
                SELECT
                    ls.MaLS,
                    sp.TenSP,
                    bt.SKU,
                    sz.TenSize AS Size,
                    ms.TenMau AS Mau,
                    ls.ThayDoi,
                    ls.Loai,
                    ls.MaTK,
                    ls.ThoiGian
                FROM LichSuTonKho ls

                INNER JOIN BienTheSanPham bt
                    ON ls.MaBienThe = bt.MaBienThe

                INNER JOIN SanPham sp
                    ON bt.MaSP = sp.MaSP

                INNER JOIN Size sz
                    ON bt.MaSize = sz.MaSize

                INNER JOIN MauSac ms
                    ON bt.MaMau = ms.MaMau

                ORDER BY ls.ThoiGian DESC;
            ";

            dtLichSu = kt.GetData(sql);

            dgvLichSuTonKho.DataSource = dtLichSu;

            DatTenCot();
            CauHinhDataGridView();
        }
        private void FormLStonkho_Load(object sender, EventArgs e)
        {

        }

        private void DatTenCot()
        {
            if (dgvLichSuTonKho.Columns.Count == 0)
                return;

            dgvLichSuTonKho.Columns["MaLS"].HeaderText = "Mã LS";
            dgvLichSuTonKho.Columns["TenSP"].HeaderText = "Sản phẩm";
            dgvLichSuTonKho.Columns["SKU"].HeaderText = "SKU";
            dgvLichSuTonKho.Columns["Size"].HeaderText = "Size";
            dgvLichSuTonKho.Columns["Mau"].HeaderText = "Màu";
            dgvLichSuTonKho.Columns["ThayDoi"].HeaderText = "Thay đổi";
            dgvLichSuTonKho.Columns["Loai"].HeaderText = "Loại";
            dgvLichSuTonKho.Columns["MaTK"].HeaderText = "Mã tài khoản";
            dgvLichSuTonKho.Columns["ThoiGian"].HeaderText = "Thời gian";

            dgvLichSuTonKho.Columns["ThoiGian"]
                .DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            dgvLichSuTonKho.Columns["ThayDoi"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
        }


        // =====================================================
        // 3. CẤU HÌNH DATAGRIDVIEW
        // =====================================================
        private void CauHinhDataGridView()
        {
            dgvLichSuTonKho.AllowUserToAddRows = false;
            dgvLichSuTonKho.AllowUserToDeleteRows = false;
            dgvLichSuTonKho.ReadOnly = true;

            dgvLichSuTonKho.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvLichSuTonKho.MultiSelect = false;

            dgvLichSuTonKho.ScrollBars = ScrollBars.Both;

            dgvLichSuTonKho.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvLichSuTonKho.ColumnHeadersHeight = 35;

            dgvLichSuTonKho.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvLichSuTonKho.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);


            // Độ rộng cột
            dgvLichSuTonKho.Columns["MaLS"].Width = 70;
            dgvLichSuTonKho.Columns["TenSP"].Width = 190;
            dgvLichSuTonKho.Columns["SKU"].Width = 150;
            dgvLichSuTonKho.Columns["Size"].Width = 70;
            dgvLichSuTonKho.Columns["Mau"].Width = 80;
            dgvLichSuTonKho.Columns["ThayDoi"].Width = 90;
            dgvLichSuTonKho.Columns["Loai"].Width = 120;
            dgvLichSuTonKho.Columns["MaTK"].Width = 110;
            dgvLichSuTonKho.Columns["ThoiGian"].Width = 150;
        }


        // =====================================================
        // 4. LOAD LOẠI GIAO DỊCH
        // =====================================================
        private void LoadLoai()
        {
            cmbLoai.Items.Clear();

            cmbLoai.Items.Add("Tất cả loại");
            cmbLoai.Items.Add("Nhập hàng");
            cmbLoai.Items.Add("Bán hàng");
            cmbLoai.Items.Add("Điều chỉnh");

            cmbLoai.SelectedIndex = 0;
        }


        // =====================================================
        // 5. TÌM KIẾM + LỌC
        // =====================================================
        private void LocDuLieu()
        {
            if (dtLichSu == null)
                return;

            string tuKhoa = txtTimKiem.Text.Trim();

            string loai = "";

            if (cmbLoai.SelectedIndex > 0)
            {
                loai = cmbLoai.SelectedItem.ToString();
            }

            DataView view = new DataView(dtLichSu);

            string filter = "";


            // -----------------------------
            // TÌM THEO TÊN / SKU
            // -----------------------------
            if (!string.IsNullOrEmpty(tuKhoa))
            {
                tuKhoa = tuKhoa.Replace("'", "''");

                filter =
                    $"TenSP LIKE '%{tuKhoa}%' " +
                    $"OR SKU LIKE '%{tuKhoa}%'";
            }


            // -----------------------------
            // LỌC LOẠI
            // -----------------------------
            if (!string.IsNullOrEmpty(loai))
            {
                loai = loai.Replace("'", "''");

                if (filter != "")
                    filter += " AND ";

                filter += $"Loai = '{loai}'";
            }


            view.RowFilter = filter;

            dgvLichSuTonKho.DataSource = view;

            DatTenCot();
        }


        // =====================================================
        // 6. TÌM KIẾM
        // =====================================================
        private void txtTimKiem_TextChanged(
            object sender,
            EventArgs e)
        {
            LocDuLieu();
        }


        // =====================================================
        // 7. LỌC LOẠI
        // =====================================================
        private void cmbLoai_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            LocDuLieu();
        }


        // =====================================================
        // 8. LÀM MỚI
        // =====================================================
        private void btnLamMoi_Click(
            object sender,
            EventArgs e)
        {
            txtTimKiem.Clear();

            cmbLoai.SelectedIndex = 0;

            LoadLichSu();
        }
    }
}

