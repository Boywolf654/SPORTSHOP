using System;
using System.Drawing;
using System.Windows.Forms;

namespace SPORTSHOP._06_BanHang
{
    public partial class Giohang : Form
    {
        private decimal giamGia = 0;
        private decimal phiVanChuyen = 0;

        public Giohang()
        {
            InitializeComponent();

            // Designer đã có Giohang_Load
            btn_xoa.Click += btn_xoa_Click;
            btn_giamgia.Click += btn_giamgia_Click;
            btn_vanchuyen.Click += btn_vanchuyen_Click;
            btn_thanhtoan.Click += btn_thanhtoan_Click;

            dgv_giohang.CellContentClick +=
                dgv_giohang_CellContentClick;

            dgv_giohang.CellMouseDown +=
                dgv_giohang_CellMouseDown;
        }

        // =========================================================
        // LOAD
        // =========================================================

        private void Giohang_Load(object sender, EventArgs e)
        {
            CauHinhGioHang();
            LoadGioHang();
        }

        // =========================================================
        // CẤU HÌNH
        // =========================================================

        private void CauHinhGioHang()
        {
            dgv_giohang.AllowUserToAddRows = false;
            dgv_giohang.ReadOnly = true;

            dgv_giohang.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgv_giohang.MultiSelect = false;

            dgv_giohang.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.None;

            dgv_giohang.RowTemplate.Height = 45;

            // Căn giữa
            dgv_giohang.Columns["Column3"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgv_giohang.Columns["Column4"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgv_giohang.Columns["Column5"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgv_giohang.Columns["Column2"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            dgv_giohang.Columns["Column6"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
        }

        // =========================================================
        // LOAD GIỎ HÀNG
        // =========================================================

        private void LoadGioHang()
        {
            dgv_giohang.Rows.Clear();

            foreach (GioHangItem item
                in GioHangManager.DanhSach)
            {
                string thongTinSP =
                    item.SanPham.TenSP;

                // Hiện size
                if (!string.IsNullOrWhiteSpace(item.Size))
                {
                    thongTinSP +=
                        Environment.NewLine +
                        "Size: " + item.Size;
                }

                // Hiện màu
                if (!string.IsNullOrWhiteSpace(item.MauSac))
                {
                    thongTinSP +=
                        " | Màu: " + item.MauSac;
                }

                dgv_giohang.Rows.Add(
                    thongTinSP,

                    item.SanPham.Gia.ToString("N0")
                    + " Đ",

                    "+",

                    item.SoLuong,

                    "-",

                    item.ThanhTien.ToString("N0")
                    + " Đ"
                );
            }

            CapNhatTongTien();
        }

        // =========================================================
        // TÍNH TỔNG
        // =========================================================

        private void CapNhatTongTien()
        {
            decimal giaGoc =
                GioHangManager.TongTien();

            // Nếu giỏ trống → reset
            if (GioHangManager.DanhSach.Count == 0)
            {
                giamGia = 0;
                phiVanChuyen = 0;
            }

            // Không để giảm giá lớn hơn giá gốc
            if (giamGia > giaGoc)
                giamGia = giaGoc;

            decimal tong =
                giaGoc
                - giamGia
                + phiVanChuyen;

            if (tong < 0)
                tong = 0;

            label4.Text =
                "Giá Gốc: "
                + giaGoc.ToString("N0")
                + " Đ";

            label5.Text =
                "Giảm Giá: "
                + giamGia.ToString("N0")
                + " Đ";

            label6.Text =
                "Vận Chuyển: "
                + phiVanChuyen.ToString("N0")
                + " Đ";

            label7.Text =
                "Tổng: "
                + tong.ToString("N0")
                + " Đ";
        }

        // =========================================================
        // + / -
        // =========================================================

        private void dgv_giohang_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.RowIndex >=
                GioHangManager.DanhSach.Count)
                return;

            GioHangItem item =
                GioHangManager.DanhSach[e.RowIndex];

            // =========================
            // TĂNG
            // =========================

            if (e.ColumnIndex == 2)
            {
                if (item.SoLuong < 99)
                {
                    item.SoLuong++;
                }
                else
                {
                    MessageBox.Show(
                        "Số lượng tối đa là 99.",
                        "SPORTSHOP",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }

            // =========================
            // GIẢM
            // =========================

            else if (e.ColumnIndex == 4)
            {
                if (item.SoLuong > 1)
                {
                    item.SoLuong--;
                }
                else
                {
                    DialogResult result =
                        MessageBox.Show(
                            "Số lượng đang là 1.\n"
                            + "Bạn có muốn xóa sản phẩm này khỏi giỏ?",
                            "Xác nhận",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        GioHangManager.Xoa(item);
                    }
                }
            }
            else
            {
                return;
            }

            LoadGioHang();
        }

        // =========================================================
        // CHUỘT PHẢI → XÓA TỪNG SẢN PHẨM
        // =========================================================

        private void dgv_giohang_CellMouseDown(
            object sender,
            DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.Button != MouseButtons.Right)
                return;

            if (e.RowIndex >=
                GioHangManager.DanhSach.Count)
                return;

            dgv_giohang.ClearSelection();

            dgv_giohang.Rows[e.RowIndex]
                .Selected = true;

            GioHangItem item =
                GioHangManager.DanhSach[e.RowIndex];

            DialogResult result =
                MessageBox.Show(
                    "Xóa sản phẩm này khỏi giỏ hàng?\n\n"
                    + item.SanPham.TenSP,
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            GioHangManager.Xoa(item);

            LoadGioHang();
        }

        // =========================================================
        // XÓA TẤT CẢ
        // =========================================================

        private void btn_xoa_Click(
            object sender,
            EventArgs e)
        {
            if (GioHangManager.DanhSach.Count == 0)
            {
                MessageBox.Show(
                    "Giỏ hàng đang trống.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            DialogResult result =
                MessageBox.Show(
                    "Bạn có chắc muốn xóa toàn bộ giỏ hàng?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            GioHangManager.XoaTatCa();

            giamGia = 0;
            phiVanChuyen = 0;

            LoadGioHang();
        }

        // =========================================================
        // GIẢM GIÁ
        // =========================================================

        private void btn_giamgia_Click(
            object sender,
            EventArgs e)
        {
            if (GioHangManager.DanhSach.Count == 0)
            {
                MessageBox.Show(
                    "Giỏ hàng đang trống.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            string ma =
                cmb_giamgia.Text
                .Trim()
                .ToUpper();

            if (string.IsNullOrWhiteSpace(ma) ||
                ma.Contains("NHẬP MÃ"))
            {
                MessageBox.Show(
                    "Vui lòng nhập mã giảm giá.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmb_giamgia.Focus();

                return;
            }

            // =========================
            // SALE10
            // =========================

            if (ma == "SALE10")
            {
                decimal giaGoc =
                    GioHangManager.TongTien();

                giamGia =
                    giaGoc * 0.10m;

                MessageBox.Show(
                    "Áp dụng mã SALE10 thành công!\n"
                    + "Giảm 10% giá trị đơn hàng.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                giamGia = 0;

                MessageBox.Show(
                    "Mã giảm giá không hợp lệ.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            CapNhatTongTien();
        }

        // =========================================================
        // VẬN CHUYỂN
        // =========================================================

        private void btn_vanchuyen_Click(
            object sender,
            EventArgs e)
        {
            if (GioHangManager.DanhSach.Count == 0)
            {
                MessageBox.Show(
                    "Giỏ hàng đang trống.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            string phuongThuc =
                cmb_vanchuyen.Text.Trim();

            if (string.IsNullOrWhiteSpace(phuongThuc) ||
                phuongThuc.Contains("Chọn"))
            {
                MessageBox.Show(
                    "Vui lòng chọn phương thức giao hàng.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmb_vanchuyen.Focus();

                return;
            }

            if (phuongThuc.IndexOf(
                "Nhanh",
                StringComparison.OrdinalIgnoreCase) >= 0)
            {
                phiVanChuyen = 40000;
            }
            else
            {
                phiVanChuyen = 30000;
            }

            CapNhatTongTien();
        }

        // =========================================================
        // THANH TOÁN
        // =========================================================

        private void btn_thanhtoan_Click(
            object sender,
            EventArgs e)
        {
            if (GioHangManager.DanhSach.Count == 0)
            {
                MessageBox.Show(
                    "Giỏ hàng đang trống.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            decimal giaGoc =
                GioHangManager.TongTien();

            decimal tong =
                giaGoc
                - giamGia
                + phiVanChuyen;

            if (tong < 0)
                tong = 0;

            DialogResult result =
                MessageBox.Show(
                    "XÁC NHẬN ĐƠN HÀNG\n\n"
                    + "Số loại sản phẩm: "
                    + GioHangManager.DanhSach.Count
                    + "\nSố lượng: "
                    + GioHangManager.TongSoLuong()
                    + "\n\n"
                    + "Giá gốc: "
                    + giaGoc.ToString("N0")
                    + " Đ\n"
                    + "Giảm giá: "
                    + giamGia.ToString("N0")
                    + " Đ\n"
                    + "Vận chuyển: "
                    + phiVanChuyen.ToString("N0")
                    + " Đ\n"
                    + "-------------------------\n"
                    + "TỔNG: "
                    + tong.ToString("N0")
                    + " Đ",
                    "SPORTSHOP",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            MessageBox.Show(
                "Giỏ hàng đã được xác nhận.\n\n"
                + "Form thanh toán/đặt hàng sẽ được "
                + "kết nối ở bước tiếp theo.",
                "SPORTSHOP",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}