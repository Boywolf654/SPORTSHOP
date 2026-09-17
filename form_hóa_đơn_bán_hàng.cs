using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace SPORTSHOP
{
    public partial class form_hóa_đơn_bán_hàng : Form
    {
        public form_hóa_đơn_bán_hàng()
        {
            InitializeComponent();
            // Cấu hình nút Sửa và Xóa trong DataGridView
            if (dgv_ChiTietHoaDon.Columns.Count >= 8)
            {
                DataGridViewButtonColumn btnSua =
                    dgv_ChiTietHoaDon.Columns[6] as DataGridViewButtonColumn;

                DataGridViewButtonColumn btnXoa =
                    dgv_ChiTietHoaDon.Columns[7] as DataGridViewButtonColumn;

                if (btnSua != null)
                {
                    btnSua.Text = "✎";
                    btnSua.UseColumnTextForButtonValue = true;
                }

                if (btnXoa != null)
                {
                    btnXoa.Text = "🗑";
                    btnXoa.UseColumnTextForButtonValue = true;
                }
            }

            //Thêm sản phẩm mẫu
            dgv_ChiTietHoaDon.Rows.Add(
                "SP001",
                "Giày bóng đá Nike",
                1,
                1500000,
                "0%",
                1500000
            );

            dgv_ChiTietHoaDon.Rows.Add(
                "SP005",
                "Áo bóng chuyền Mizuno",
                2,
                450000,
                "10%",
                810000
            );

            dgv_ChiTietHoaDon.Rows.Add(
                "SP012",
                "Bóng chuyền Molten",
                1,
                650000,
                "0%",
                650000
            );

            TinhTongTien();
        }
        private void TinhTongTien()
        {
            decimal tongTienHang = 0;
            decimal tongGiamGia = 0;

            foreach (DataGridViewRow row in dgv_ChiTietHoaDon.Rows)
            {
                if (row.IsNewRow)
                    continue;

                decimal donGia = 0;
                decimal giamGia = 0;
                int soLuong = 0;

                // Lấy đơn giá
                decimal.TryParse(
                    row.Cells["DonGia"].Value?.ToString(),
                    out donGia);

                // Lấy số lượng
                int.TryParse(
                    row.Cells["SoLuong"].Value?.ToString(),
                    out soLuong);

                // Lấy % giảm giá
                decimal.TryParse(
                    row.Cells["GiamGia"].Value?.ToString()
                        ?.Replace("%", ""),
                    out giamGia);

                // Tiền hàng trước giảm
                decimal tienGoc = donGia * soLuong;

                // Tiền giảm
                decimal tienGiam = tienGoc * giamGia / 100;

                // Thành tiền sau giảm
                decimal thanhTien = tienGoc - tienGiam;

                // Cộng tổng
                tongTienHang += tienGoc;
                tongGiamGia += tienGiam;

                // Cập nhật thành tiền trên DataGridView
                row.Cells["ThanhTien"].Value =
                    thanhTien.ToString("N0");
            }

            // Tiền thực tế phải thanh toán
            decimal thanhToan = tongTienHang - tongGiamGia;

            // Hiển thị
            lb_TongTienHang.Text =
                tongTienHang.ToString("N0") + " VNĐ";

            lb_GiamGia.Text =
                tongGiamGia.ToString("N0") + " VNĐ";

            lb_ThanhToan.Text =
                thanhToan.ToString("N0") + " VNĐ";
        }
        private void form_hóa_đơn_bán_hàng_Load(object sender, EventArgs e)
        {
            //TỰ ĐỘNG SINH MÃ HÓA ĐƠN
            txt_MaHoaDon.Text ="HD" + DateTime.Now.ToString("yyyyMMddHHmmss");

            dtp_NgayLap.Value = DateTime.Now;

            cmb_NhanVien.Items.Add("Lê Văn Nam");
            cmb_NhanVien.Items.Add("Nguyễn Văn Bình");
            cmb_NhanVien.Items.Add("Trần Văn Minh");

            if (cmb_NhanVien.Items.Count > 0)
                cmb_NhanVien.SelectedIndex = 0;
        }

        private void btn_XoaSanPham_Click(object sender, EventArgs e)
        {
            if (dgv_ChiTietHoaDon.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn sản phẩm cần xóa!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn xóa sản phẩm này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                dgv_ChiTietHoaDon.Rows.RemoveAt(
                    dgv_ChiTietHoaDon.SelectedRows[0].Index);

                TinhTongTien();
            }
        }

        private void btn_SuaSoLuong_Click(object sender, EventArgs e)
        {
            if (dgv_ChiTietHoaDon.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn sản phẩm!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int index = dgv_ChiTietHoaDon.SelectedRows[0].Index;

            string soLuongCu =
                dgv_ChiTietHoaDon.Rows[index]
                .Cells["SoLuong"]
                .Value?.ToString();

            string input = Interaction.InputBox(
                "Nhập số lượng mới:",
                "Sửa số lượng",
                soLuongCu);

            // Người dùng bấm Cancel
            if (string.IsNullOrWhiteSpace(input))
                return;

            if (!int.TryParse(input, out int soLuong))
            {
                MessageBox.Show(
                    "Số lượng phải là số nguyên!",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            if (soLuong <= 0)
            {
                MessageBox.Show(
                    "Số lượng phải lớn hơn 0!",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Cập nhật số lượng
            dgv_ChiTietHoaDon.Rows[index]
                .Cells["SoLuong"]
                .Value = soLuong;

            // Tính lại toàn bộ tiền
            TinhTongTien();
        }

        private void btn_TaoHoaDon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_KhachHang.Text))
            {
                MessageBox.Show(
                    "Vui lòng chọn khách hàng!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (dgv_ChiTietHoaDon.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Hóa đơn chưa có sản phẩm!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            MessageBox.Show(
                "Tạo hóa đơn thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btn_ThanhToan_Click(object sender, EventArgs e)
        {
            if (dgv_ChiTietHoaDon.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có sản phẩm trong hóa đơn!");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Xác nhận thanh toán hóa đơn?\n\n" +
                "Số tiền: " + lb_ThanhToan.Text,
                "Thanh toán",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                MessageBox.Show(
                    "Thanh toán thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void btn_InHoaDon_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng in hóa đơn đang được phát triển!","Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
