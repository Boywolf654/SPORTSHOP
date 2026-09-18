using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SPORTSHOP
{
    public partial class FormDonOnline : Form
    {
        private int maDonOnlineDangChon = 0;
        private DataTable dtDonOnline;

        public FormDonOnline()
        {
            InitializeComponent();

            CauHinhGiaoDien();
            TaoCotDanhSach();
            TaoCotChiTiet();
            KhoiTaoTrangThaiBanDau();
        }

        private void CauHinhGiaoDien()
        {
            // Không để form bị kéo quá nhỏ làm vỡ bố cục.
            this.Resize += FormDonOnline_Resize;

            // Làm các nút có cảm giác hiện đại hơn khi rê chuột.
            GanHoverButton(btnXoaDon, Color.FromArgb(225, 66, 66), Color.FromArgb(198, 52, 52));
            GanHoverButton(btnInDon, Color.FromArgb(96, 145, 225), Color.FromArgb(77, 126, 211));
            GanHoverButton(btnRaDon, Color.FromArgb(37, 166, 76), Color.FromArgb(27, 142, 62));
            GanHoverButton(btnLamMoi, Color.FromArgb(215, 225, 239), Color.FromArgb(232, 238, 247));

            // Tắt các nút thao tác khi chưa chọn đơn.
            CapNhatTrangThaiNut(false);
        }

        private void FormDonOnline_Resize(object sender, EventArgs e)
        {
            // Giữ 3 nút thao tác nằm đẹp ở khu vực bên phải.
            int totalWidth = pnlActions.ClientSize.Width;
            int buttonWidth = 145;
            int gap = 15;
            int start = Math.Max(0, (totalWidth - (buttonWidth * 3 + gap * 2)) / 2);

            btnXoaDon.Left = start;
            btnInDon.Left = start + buttonWidth + gap;
            btnRaDon.Left = start + (buttonWidth + gap) * 2;
        }

        private void GanHoverButton(Button button, Color hoverColor, Color normalColor)
        {
            button.Tag = normalColor;

            button.MouseEnter += (s, e) =>
            {
                if (button.Enabled)
                    button.BackColor = hoverColor;
            };

            button.MouseLeave += (s, e) =>
            {
                button.BackColor = normalColor;
            };
        }

        private void TaoCotDanhSach()
        {
            dgvDonOnline.Columns.Clear();

            DataGridViewTextBoxColumn colMa = new DataGridViewTextBoxColumn
            {
                Name = "colMaDon",
                HeaderText = "MÃ ĐƠN",
                Width = 90,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };

            DataGridViewTextBoxColumn colKhach = new DataGridViewTextBoxColumn
            {
                Name = "colKhachHang",
                HeaderText = "KHÁCH HÀNG",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };

            DataGridViewTextBoxColumn colTong = new DataGridViewTextBoxColumn
            {
                Name = "colTongTien",
                HeaderText = "THÀNH TIỀN",
                Width = 110,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };

            DataGridViewTextBoxColumn colTrangThai = new DataGridViewTextBoxColumn
            {
                Name = "colTrangThai",
                HeaderText = "TRẠNG THÁI",
                Width = 115,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };

            dgvDonOnline.Columns.AddRange(colMa, colKhach, colTong, colTrangThai);
        }

        private void TaoCotChiTiet()
        {
            dgvChiTiet.Columns.Clear();

            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTenSP",
                HeaderText = "SẢN PHẨM",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colSize",
                HeaderText = "SIZE",
                Width = 65
            });

            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMau",
                HeaderText = "MÀU",
                Width = 80
            });

            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colSoLuong",
                HeaderText = "SL",
                Width = 55
            });

            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDonGia",
                HeaderText = "ĐƠN GIÁ",
                Width = 115
            });

            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTien",
                HeaderText = "THÀNH TIỀN",
                Width = 125
            });
        }

        private void KhoiTaoTrangThaiBanDau()
        {
            dtDonOnline = new DataTable();
            dtDonOnline.Columns.Add("MaDonOnline", typeof(int));
            dtDonOnline.Columns.Add("KhachHang", typeof(string));
            dtDonOnline.Columns.Add("TongTien", typeof(decimal));
            dtDonOnline.Columns.Add("TrangThai", typeof(string));

            // Form để trống chờ dữ liệu SQL.
            // Khi nối database, chỉ cần đổ dữ liệu vào dtDonOnline rồi gọi HienThiDanhSach().
            HienThiDanhSach(dtDonOnline);

            XoaChiTiet();
        }

        private void HienThiDanhSach(DataTable source)
        {
            dgvDonOnline.Rows.Clear();

            if (source == null)
            {
                lblSoDon.Text = "0 đơn đã thanh toán";
                return;
            }

            foreach (DataRow row in source.Rows)
            {
                string trangThai = row["TrangThai"]?.ToString() ?? "";

                // Chỉ hiện đơn đã thanh toán / đang chờ NV xử lý.
                if (!string.Equals(trangThai, "Đã thanh toán", StringComparison.OrdinalIgnoreCase))
                    continue;

                int index = dgvDonOnline.Rows.Add(
                    "DO" + Convert.ToInt32(row["MaDonOnline"]).ToString("D4"),
                    row["KhachHang"]?.ToString() ?? "",
                    string.Format("{0:N0} đ", Convert.ToDecimal(row["TongTien"])),
                    trangThai
                );

                dgvDonOnline.Rows[index].Cells["colTrangThai"].Style.ForeColor =
                    Color.FromArgb(31, 111, 62);
                dgvDonOnline.Rows[index].Cells["colTrangThai"].Style.Font =
                    new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            }

            int count = dgvDonOnline.Rows.Count;
            lblSoDon.Text = count == 0
                ? "Không có đơn chờ xử lý"
                : count + " đơn đã thanh toán";
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim().ToLower();

            foreach (DataGridViewRow row in dgvDonOnline.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string ma = row.Cells["colMaDon"].Value?.ToString()?.ToLower() ?? "";
                string ten = row.Cells["colKhachHang"].Value?.ToString()?.ToLower() ?? "";

                row.Visible = string.IsNullOrWhiteSpace(tuKhoa)
                    || ma.Contains(tuKhoa)
                    || ten.Contains(tuKhoa);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            // TODO: Sau khi nối SQL, gọi hàm LoadDonOnline() tại đây.
            txtTimKiem.Clear();
            XoaChiTiet();
            CapNhatTrangThaiNut(false);

            MessageBox.Show(
                "Đã làm mới danh sách.\n\nKhi kết nối SQL, nút này sẽ tải lại các đơn online mới nhất.",
                "Đơn Online",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void dgvDonOnline_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvDonOnline.Rows.Count)
                return;

            DataGridViewRow row = dgvDonOnline.Rows[e.RowIndex];

            string maText = row.Cells["colMaDon"].Value?.ToString() ?? "";
            if (!maText.StartsWith("DO"))
                return;

            if (int.TryParse(maText.Substring(2), out int ma))
                maDonOnlineDangChon = ma;

            string trangThai = row.Cells["colTrangThai"].Value?.ToString() ?? "";
            string khachHang = row.Cells["colKhachHang"].Value?.ToString() ?? "";
            string tongTien = row.Cells["colTongTien"].Value?.ToString() ?? "0 đ";

            HienThiThongTinDemo(maDonOnlineDangChon, khachHang, trangThai, tongTien);
            CapNhatTrangThaiNut(true);
        }

        private void HienThiThongTinDemo(int maDon, string khachHang, string trangThai, string tongTien)
        {
            lblMaDon.Text = "DO" + maDon.ToString("D4");
            lblKhachHang.Text = string.IsNullOrWhiteSpace(khachHang) ? "—" : khachHang;
            lblTrangThai.Text = trangThai.ToUpper();
            lblThanhToan.Text = "Đã thanh toán";
            lblNgay.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            // Vì dữ liệu chi tiết sẽ lấy từ SQL sau này, ở bản UI này
            // chỉ giữ phần tổng quan. Không tự bịa sản phẩm.
            XoaChiTiet();

            lblTienHang.Text = "—";
            lblGiam.Text = "—";
            lblShip.Text = "—";
            lblThanhTien.Text = tongTien;
        }

        private void XoaChiTiet()
        {
            dgvChiTiet.Rows.Clear();

            lblMaDon.Text = "—";
            lblKhachHang.Text = "—";
            lblSDT.Text = "—";
            lblDiaChi.Text = "—";
            lblThanhToan.Text = "—";
            lblNgay.Text = "—";
            lblTrangThai.Text = "ĐÃ THANH TOÁN";

            lblTienHang.Text = "0 đ";
            lblGiam.Text = "0 đ";
            lblShip.Text = "0 đ";
            lblThanhTien.Text = "0 đ";

            maDonOnlineDangChon = 0;
        }

        private void CapNhatTrangThaiNut(bool coDon)
        {
            btnXoaDon.Enabled = coDon;
            btnInDon.Enabled = coDon;
            btnRaDon.Enabled = coDon;

            btnXoaDon.BackColor = coDon
                ? Color.FromArgb(198, 52, 52)
                : Color.FromArgb(205, 205, 205);

            btnInDon.BackColor = coDon
                ? Color.FromArgb(77, 126, 211)
                : Color.FromArgb(205, 205, 205);

            btnRaDon.BackColor = coDon
                ? Color.FromArgb(27, 142, 62)
                : Color.FromArgb(205, 205, 205);
        }

        private void btnXoaDon_Click(object sender, EventArgs e)
        {
            if (maDonOnlineDangChon <= 0)
                return;

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn hủy đơn online này không?\n\nĐơn sẽ được chuyển sang trạng thái \"Đã hủy\", không xóa vật lý khỏi cơ sở dữ liệu.",
                "Xác nhận hủy đơn",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result != DialogResult.Yes)
                return;

            // TODO SQL:
            // UPDATE DonOnline SET TrangThai = N'Đã hủy' WHERE MaDonOnline = @MaDonOnline

            MessageBox.Show(
                "Đã ghi nhận yêu cầu hủy đơn.\nKhi nối SQL, trạng thái đơn sẽ được cập nhật thành \"Đã hủy\".",
                "Đơn Online",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            XoaChiTiet();
            CapNhatTrangThaiNut(false);
        }

        private void btnInDon_Click(object sender, EventArgs e)
        {
            if (maDonOnlineDangChon <= 0)
                return;

            // TODO: Tích hợp PrintDocument / PrintPreviewDialog
            // để in phiếu đơn online.
            MessageBox.Show(
                "Khu vực in đơn đã sẵn sàng.\n\nBước tiếp theo sẽ lấy đúng dữ liệu đơn từ SQL để đưa vào mẫu in.",
                "In đơn",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnRaDon_Click(object sender, EventArgs e)
        {
            if (maDonOnlineDangChon <= 0)
                return;

            DialogResult result = MessageBox.Show(
                "Xác nhận ra đơn cho khách?\n\nĐơn online đã thanh toán sẽ được nhân viên tiếp nhận và chuyển sang bước tạo hóa đơn/xử lý đơn.",
                "Xác nhận ra đơn",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
                return;

            // TODO SQL transaction:
            // 1. Kiểm tra DonOnline vẫn đang ở trạng thái "Đã thanh toán".
            // 2. Tạo HoaDon.
            // 3. Tạo ChiTietHoaDon.
            // 4. Ghi MaNV tiếp nhận.
            // 5. Cập nhật DonOnline = "Đã ra đơn".
            //
            // Không trừ kho ở bước thanh toán phía KH.
            // Việc trừ kho sẽ thực hiện ở bước nghiệp vụ kho/ra đơn mà dự án đã thống nhất.

            MessageBox.Show(
                "Đã xác nhận ra đơn.\n\nKhi nối SQL, bước này sẽ tạo hóa đơn và cập nhật trạng thái đơn online.",
                "Ra đơn thành công",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            XoaChiTiet();
            CapNhatTrangThaiNut(false);
        }
    }
}
