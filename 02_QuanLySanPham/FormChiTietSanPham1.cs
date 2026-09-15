using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPORTSHOP
{
    public partial class FormChiTietSanPham1: Form
    {
        private KetNoiDuLieu kt = new KetNoiDuLieu();

        private int maSP;
        public FormChiTietSanPham1(int maSP)
        {
            InitializeComponent();

            this.maSP = maSP;

            // Gắn sự kiện
            this.Load += FormChiTietSanPham1_Load;
            btn_dong.Click += btn_dong_Click;

            // Chỉ xem, không cho sửa
            txt_MaSP.ReadOnly = true;
            txt_tenSP.ReadOnly = true;
            txt_danhmuc.ReadOnly = true;
            textBox4.ReadOnly = true;
            txt_trangthai.ReadOnly = true;
            txt_mota.ReadOnly = true;

            dtp_ngaytao.Enabled = false;
        }

        private void FormChiTietSanPham1_Load(object sender, EventArgs e)
        {
            LoadThongTinSanPham();
            LoadBienThe();
            CauHinhGiaoDien();
        }

        private void LoadThongTinSanPham()
        {
            try
            {
                string sql = @"
                    SELECT
                        sp.MaSP,
                        sp.TenSP,
                        dm.TenDanhMuc,
                        th.TenThuongHieu,
                        sp.TrangThai,
                        sp.NgayTao,
                        sp.MoTa
                    FROM SanPham sp
                    INNER JOIN DanhMuc dm
                        ON sp.MaDM = dm.MaDM
                    INNER JOIN ThuongHieu th
                        ON sp.MaTH = th.MaTH
                    WHERE sp.MaSP = " + maSP;

                DataTable dt = kt.GetData(sql);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "Không tìm thấy sản phẩm.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    Close();
                    return;
                }

                DataRow row = dt.Rows[0];

                txt_MaSP.Text = row["MaSP"].ToString();

                txt_tenSP.Text = row["TenSP"].ToString();

                txt_danhmuc.Text =
                    row["TenDanhMuc"].ToString();

                // textBox4 = Thương hiệu
                textBox4.Text =
                    row["TenThuongHieu"].ToString();

                // Trạng thái
                bool trangThai =
                    Convert.ToBoolean(row["TrangThai"]);

                txt_trangthai.Text =
                    trangThai
                    ? "Đang hoạt động"
                    : "Ngừng hoạt động";

                if (trangThai)
                {
                    txt_trangthai.ForeColor =
                        Color.FromArgb(25, 140, 80);
                }
                else
                {
                    txt_trangthai.ForeColor =
                        Color.FromArgb(210, 60, 60);
                }

                // Ngày tạo
                if (row["NgayTao"] != DBNull.Value)
                {
                    dtp_ngaytao.Value =
                        Convert.ToDateTime(row["NgayTao"]);
                }

                // Mô tả
                if (row["MoTa"] == DBNull.Value ||
                    string.IsNullOrWhiteSpace(
                        row["MoTa"].ToString()))
                {
                    txt_mota.Text = "Chưa có mô tả.";
                }
                else
                {
                    txt_mota.Text =
                        row["MoTa"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải thông tin sản phẩm.\n\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadBienThe()
        {
            try
            {
                string sql = @"
                    SELECT
                        bt.MaBienThe,
                        s.TenSize,
                        m.TenMau,
                        bt.SKU,
                        bt.GiaNhap,
                        bt.GiaBan,
                        bt.SoLuong
                    FROM BienTheSanPham bt
                    LEFT JOIN Size s
                        ON bt.MaSize = s.MaSize
                    LEFT JOIN MauSac m
                        ON bt.MaMau = m.MaMau
                    WHERE bt.MaSP = " + maSP + @"
                      AND bt.TrangThai = 1
                    ORDER BY bt.MaBienThe";

                DataTable dt = kt.GetData(sql);

                dgvbienthe.DataSource = dt;

                CauHinhDataGridView();
            }


            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải biến thể sản phẩm.\n\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CauHinhDataGridView()
        {
            dgvbienthe.ReadOnly = true;

            dgvbienthe.AllowUserToAddRows = false;
            dgvbienthe.AllowUserToDeleteRows = false;
            dgvbienthe.AllowUserToResizeRows = false;

            dgvbienthe.RowHeadersVisible = false;

            dgvbienthe.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvbienthe.MultiSelect = false;

            dgvbienthe.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvbienthe.ColumnHeadersHeight = 35;

            dgvbienthe.DefaultCellStyle.Font =
                new Font("Segoe UI", 9F);

            dgvbienthe.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);

            // Tên cột
            if (dgvbienthe.Columns["MaBienThe"] != null)
                dgvbienthe.Columns["MaBienThe"].HeaderText =
                    "Mã biến thể";

            if (dgvbienthe.Columns["TenSize"] != null)
                dgvbienthe.Columns["TenSize"].HeaderText =
                    "Size";

            if (dgvbienthe.Columns["TenMau"] != null)
                dgvbienthe.Columns["TenMau"].HeaderText =
                    "Màu";

            if (dgvbienthe.Columns["SKU"] != null)
                dgvbienthe.Columns["SKU"].HeaderText =
                    "SKU";

            if (dgvbienthe.Columns["GiaNhap"] != null)
            {
                dgvbienthe.Columns["GiaNhap"].HeaderText =
                    "Giá nhập";

                dgvbienthe.Columns["GiaNhap"]
                    .DefaultCellStyle.Format = "N0";
            }

            if (dgvbienthe.Columns["GiaBan"] != null)
            {
                dgvbienthe.Columns["GiaBan"].HeaderText =
                    "Giá bán";

                dgvbienthe.Columns["GiaBan"]
                    .DefaultCellStyle.Format = "N0";
            }

            if (dgvbienthe.Columns["SoLuong"] != null)
            {
                dgvbienthe.Columns["SoLuong"].HeaderText =
                    "Tồn kho";

                dgvbienthe.Columns["SoLuong"]
                    .DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void CauHinhGiaoDien()
        {
            this.Text = "Chi tiết sản phẩm";
            this.StartPosition =
                FormStartPosition.CenterScreen;

            this.FormBorderStyle =
                FormBorderStyle.FixedSingle;

            this.MaximizeBox = false;

            // Các ô thông tin chỉ đọc
            txt_MaSP.BackColor =
                Color.FromArgb(245, 245, 245);

            txt_tenSP.BackColor =
                Color.FromArgb(245, 245, 245);

            txt_danhmuc.BackColor =
                Color.FromArgb(245, 245, 245);

            textBox4.BackColor =
                Color.FromArgb(245, 245, 245);

            txt_trangthai.BackColor =
                Color.FromArgb(245, 245, 245);

            txt_mota.FillColor =
                Color.FromArgb(245, 245, 245);

            // Ngày tạo
            dtp_ngaytao.FillColor =
                Color.FromArgb(245, 245, 245);

            dtp_ngaytao.ForeColor =
                Color.Black;

            // Nút đóng
            btn_dong.Cursor = Cursors.Hand;

            btn_dong.Text = "ĐÓNG";
        }

        // =====================================================
        // NÚT ĐÓNG
        // =====================================================

        private void btn_dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    


private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
