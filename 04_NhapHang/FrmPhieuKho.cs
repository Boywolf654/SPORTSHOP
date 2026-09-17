using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SPORTSHOP._04_NhapHang
{
    public partial class FrmPhieuKho : Form
    {
        private KetNoiDuLieu kt = new KetNoiDuLieu();

        private int maPN = 0;
        private int maKho = 0;

        // Lưu những mã biến thể đã quét
        private HashSet<int> danhSachDaQuet = new HashSet<int>();

        private bool daXacNhan = false;

        public FrmPhieuKho()
        {
            InitializeComponent();

            // Đăng ký sự kiện
            btnDanhDauTatCa.Click += btnDanhDauTatCa_Click;
            btnDatLai.Click += btnDatLai_Click;
            btnXacNhanKiemKho.Click += btnXacNhanKiemKho_Click;

            txtMaVach.KeyDown += txtMaVach_KeyDown;

            dgvHangHoa.CellValueChanged += dgvHangHoa_CellValueChanged;
            dgvHangHoa.CurrentCellDirtyStateChanged +=
                dgvHangHoa_CurrentCellDirtyStateChanged;
        }

        // =========================================================
        // LOAD FORM
        // =========================================================

        private void FrmPhieuKho_Load_1(object sender, EventArgs e)
        {
            KhoiTaoForm();
            LoadPhieuChoXuatKho();
        }

        private void KhoiTaoForm()
        {
            // Header DataGridView
            dgvHangHoa.ColumnHeadersHeight = 35;
            dgvHangHoa.ThemeStyle.HeaderStyle.Height = 35;

            dgvHangHoa.AllowUserToAddRows = false;
            dgvHangHoa.AllowUserToDeleteRows = false;
            dgvHangHoa.AllowUserToResizeRows = false;

            dgvHangHoa.RowHeadersVisible = false;
            dgvHangHoa.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvHangHoa.MultiSelect = false;

            dgvHangHoa.AutoGenerateColumns = false;

            // Ban đầu chưa có dữ liệu
            lblMaPhieuNhap.Text = "---";
            lblKho.Text = "---";
            lblNhaCungCap.Text = "---";
            lblNguoiKiem.Text = LayTenNguoiKiem();
            lblThoiGianKiem.Text =
                DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            lblTongSanPham.Text = "0";
            lblDaKiem.Text = "0";
            lblKhop.Text = "0";
            lblLech.Text = "0";
            lblChuaKiem.Text = "Còn 0 Mục Chưa Kiểm";
            lblDaQuet.Text = "0 Lượt";
        }

        // =========================================================
        // TÌM PHIẾU ĐANG CHỜ XUẤT KHO
        // =========================================================

        private void LoadPhieuChoXuatKho()
        {
            try
            {
                string sql = @"
                    SELECT TOP 1 MaPN
                    FROM PhieuNhap
                    WHERE TrangThai = N'Chờ xuất kho'
                    ORDER BY NgayNhap ASC";

                object result = kt.ExecuteScalar(sql, null);

                if (result == null || result == DBNull.Value)
                {
                   

                    MessageBox.Show(
                        "Hiện không có phiếu nhập nào đang chờ xuất kho.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }

                maPN = Convert.ToInt32(result);

                LoadThongTinPhieu();
                LoadChiTietPhieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tải phiếu:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // LOAD THÔNG TIN PHIẾU
        // =========================================================

        private void LoadThongTinPhieu()
        {
            string sql = @"
                SELECT
                    pn.MaPN,
                    pn.MaKho,
                    pn.NgayNhap,
                    pn.MaNV,
                    pn.MaNCC,
                    pn.TrangThai,
                    k.TenKho,
                    ncc.TenNCC
                FROM PhieuNhap pn
                LEFT JOIN Kho k
                    ON pn.MaKho = k.MaKho
                LEFT JOIN NhaCungCap ncc
                    ON pn.MaNCC = ncc.MaNCC
                WHERE pn.MaPN = @MaPN";

            SqlParameter[] parameters =
            {
                new SqlParameter("@MaPN", maPN)
            };

            DataTable dt = kt.GetData(sql, parameters);

            if (dt.Rows.Count == 0)
                return;

            DataRow row = dt.Rows[0];

            maKho = Convert.ToInt32(row["MaKho"]);

            lblMaPhieuNhap.Text =
                "PN" + maPN.ToString("D4");

            lblKho.Text =
                row["TenKho"].ToString();

            lblNhaCungCap.Text =
                row["TenNCC"].ToString();

            lblNguoiKiem.Text =
                LayTenNguoiKiem();

            lblThoiGianKiem.Text =
                DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            
        }

        // =========================================================
        // LOAD CHI TIẾT PHIẾU
        // =========================================================

        private void LoadChiTietPhieu()
        {
            string sql = @"
                SELECT
                    ct.MaBienThe,
                    bt.SKU,
                    sp.TenSP,
                    sz.TenSize,
                    ms.TenMau,
                    ct.SoLuong,
                    ct.DonGia
                FROM ChiTietPhieuNhap ct
                INNER JOIN BienTheSanPham bt
                    ON ct.MaBienThe = bt.MaBienThe
                INNER JOIN SanPham sp
                    ON bt.MaSP = sp.MaSP
                LEFT JOIN Size sz
                    ON bt.MaSize = sz.MaSize
                LEFT JOIN MauSac ms
                    ON bt.MaMau = ms.MaMau
                WHERE ct.MaPN = @MaPN
                ORDER BY ct.MaBienThe";

            SqlParameter[] parameters =
            {
                new SqlParameter("@MaPN", maPN)
            };

            DataTable dt = kt.GetData(sql, parameters);

            TaoCotDGV();

            dgvHangHoa.Rows.Clear();

            int stt = 1;

            foreach (DataRow row in dt.Rows)
            {
                int index = dgvHangHoa.Rows.Add();

                DataGridViewRow r =
                    dgvHangHoa.Rows[index];

                r.Cells["colSTT"].Value = stt++;

                r.Cells["colMaBienThe"].Value =
                    row["MaBienThe"];

                r.Cells["colSKU"].Value =
                    row["SKU"];

                r.Cells["colTenSP"].Value =
                    row["TenSP"];

                r.Cells["colSize"].Value =
                    row["TenSize"];

                r.Cells["colMau"].Value =
                    row["TenMau"];

                r.Cells["colSLTheoPhieu"].Value =
                    row["SoLuong"];

                // Chưa quét = 0
                r.Cells["colSLThucTe"].Value = 0;

                r.Cells["colChenhLech"].Value =
                    -Convert.ToInt32(row["SoLuong"]);

                r.Cells["colTrangThai"].Value =
                    "Chưa kiểm";

                r.Cells["colGhiChu"].Value = "";
            }

            lblTongSanPham.Text =
                dgvHangHoa.Rows.Count.ToString();

            CapNhatThongKe();
        }

        // =========================================================
        // TẠO CỘT DATAGRIDVIEW
        // =========================================================

        private void TaoCotDGV()
        {
            dgvHangHoa.Columns.Clear();

            dgvHangHoa.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colSTT",
                    HeaderText = "STT",
                    Width = 45,
                    ReadOnly = true
                });

            dgvHangHoa.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colMaBienThe",
                    HeaderText = "Mã biến thể",
                    Visible = false,
                    ReadOnly = true
                });

            dgvHangHoa.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colSKU",
                    HeaderText = "Mã hàng",
                    Width = 110,
                    ReadOnly = true
                });

            dgvHangHoa.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colTenSP",
                    HeaderText = "Tên sản phẩm",
                    Width = 180,
                    ReadOnly = true
                });

            dgvHangHoa.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colSize",
                    HeaderText = "Size",
                    Width = 60,
                    ReadOnly = true
                });

            dgvHangHoa.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colMau",
                    HeaderText = "Màu",
                    Width = 80,
                    ReadOnly = true
                });

            dgvHangHoa.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colSLTheoPhieu",
                    HeaderText = "SL theo phiếu",
                    Width = 90,
                    ReadOnly = true
                });

            dgvHangHoa.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colSLThucTe",
                    HeaderText = "SL thực tế",
                    Width = 90,
                    ReadOnly = false
                });

            dgvHangHoa.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colChenhLech",
                    HeaderText = "Chênh lệch",
                    Width = 85,
                    ReadOnly = true
                });

            dgvHangHoa.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colTrangThai",
                    HeaderText = "Trạng thái",
                    Width = 90,
                    ReadOnly = true
                });

            dgvHangHoa.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colGhiChu",
                    HeaderText = "Ghi chú",
                    Width = 130,
                    ReadOnly = false
                });
        }

        // =========================================================
        // QUÉT MÃ HÀNG
        // =========================================================

        private void txtMaVach_KeyDown(
            object sender,
            KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            e.SuppressKeyPress = true;

            string sku = txtMaVach.Text.Trim();

            if (string.IsNullOrEmpty(sku))
                return;

            bool timThay = false;

            foreach (DataGridViewRow row
                in dgvHangHoa.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string skuTrongBang =
                    Convert.ToString(
                        row.Cells["colSKU"].Value);

                if (!string.Equals(
                    skuTrongBang,
                    sku,
                    StringComparison.OrdinalIgnoreCase))
                    continue;

                timThay = true;

                int maBienThe =
                    Convert.ToInt32(
                        row.Cells["colMaBienThe"].Value);

                int slThucTe = 0;

                int.TryParse(
                    Convert.ToString(
                        row.Cells["colSLThucTe"].Value),
                    out slThucTe);

                int slTheoPhieu = 0;

                int.TryParse(
                    Convert.ToString(
                        row.Cells["colSLTheoPhieu"].Value),
                    out slTheoPhieu);

                // Quét 1 lần -> tăng thực tế 1
                if (slThucTe < slTheoPhieu)
                {
                    slThucTe++;

                    row.Cells["colSLThucTe"].Value =
                        slThucTe;

                    danhSachDaQuet.Add(maBienThe);

                    CapNhatTrangThaiDong(row);

                    dgvHangHoa.CurrentCell =
                        row.Cells["colSLThucTe"];

                    row.Selected = true;
                }

                break;
            }

            if (!timThay)
            {
                MessageBox.Show(
                    "Không tìm thấy mã hàng:\n" + sku,
                    "Không tìm thấy",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            lblDaQuet.Text =
                danhSachDaQuet.Count + " Lượt";

            CapNhatThongKe();

            txtMaVach.Clear();
            txtMaVach.Focus();
        }

        // =========================================================
        // KHI SỬA SL THỰC TẾ BẰNG TAY
        // =========================================================

        private void dgvHangHoa_CellValueChanged(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex < 0)
                return;

            if (dgvHangHoa.Columns[e.ColumnIndex].Name
                != "colSLThucTe")
                return;

            DataGridViewRow row =
                dgvHangHoa.Rows[e.RowIndex];

            CapNhatTrangThaiDong(row);

            CapNhatThongKe();
        }

        // =========================================================
        // CẬP NHẬT TRẠNG THÁI TỪNG DÒNG
        // =========================================================

        private void CapNhatTrangThaiDong(
            DataGridViewRow row)
        {
            int slTheoPhieu = 0;
            int slThucTe = 0;

            int.TryParse(
                Convert.ToString(
                    row.Cells["colSLTheoPhieu"].Value),
                out slTheoPhieu);

            int.TryParse(
                Convert.ToString(
                    row.Cells["colSLThucTe"].Value),
                out slThucTe);

            if (slThucTe < 0)
                slThucTe = 0;

            int chenhLech =
                slThucTe - slTheoPhieu;

            row.Cells["colChenhLech"].Value =
                chenhLech;

            if (slThucTe == 0)
            {
                row.Cells["colTrangThai"].Value =
                    "Chưa kiểm";
            }
            else if (slThucTe == slTheoPhieu)
            {
                row.Cells["colTrangThai"].Value =
                    "Khớp";
            }
            else
            {
                row.Cells["colTrangThai"].Value =
                    "Lệch";
            }
        }

        // =========================================================
        // THỐNG KÊ
        // =========================================================

        private void CapNhatThongKe()
        {
            int tong = dgvHangHoa.Rows.Count;
            int daKiem = 0;
            int khop = 0;
            int lech = 0;

            foreach (DataGridViewRow row
                in dgvHangHoa.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string trangThai =
                    Convert.ToString(
                        row.Cells["colTrangThai"].Value);

                if (trangThai == "Khớp")
                {
                    daKiem++;
                    khop++;
                }
                else if (trangThai == "Lệch")
                {
                    daKiem++;
                    lech++;
                }
            }

            int chuaKiem =
                tong - daKiem;

            lblTongSanPham.Text =
                tong.ToString();

            lblDaKiem.Text =
                daKiem.ToString();

            lblKhop.Text =
                khop.ToString();

            lblLech.Text =
                lech.ToString();

            lblChuaKiem.Text =
                "Còn " + chuaKiem +
                " Mục Chưa Kiểm";

            lblChuaKiem.ForeColor =
                chuaKiem > 0
                    ? Color.DarkOrange
                    : Color.Green;
        }

        // =========================================================
        // ĐÁNH DẤU ĐỦ TẤT CẢ
        // =========================================================

        private void btnDanhDauTatCa_Click(
            object sender,
            EventArgs e)
        {
            if (daXacNhan)
                return;

            foreach (DataGridViewRow row
                in dgvHangHoa.Rows)
            {
                if (row.IsNewRow)
                    continue;

                int slTheoPhieu = 0;

                int.TryParse(
                    Convert.ToString(
                        row.Cells["colSLTheoPhieu"].Value),
                    out slTheoPhieu);

                int maBienThe =
                    Convert.ToInt32(
                        row.Cells["colMaBienThe"].Value);

                row.Cells["colSLThucTe"].Value =
                    slTheoPhieu;

                row.Cells["colChenhLech"].Value =
                    0;

                row.Cells["colTrangThai"].Value =
                    "Khớp";

                danhSachDaQuet.Add(maBienThe);
            }

            lblDaQuet.Text =
                danhSachDaQuet.Count + " Lượt";

            CapNhatThongKe();
        }

        // =========================================================
        // ĐẶT LẠI
        // =========================================================

        private void btnDatLai_Click(
            object sender,
            EventArgs e)
        {
            if (daXacNhan)
                return;

            danhSachDaQuet.Clear();

            foreach (DataGridViewRow row
                in dgvHangHoa.Rows)
            {
                if (row.IsNewRow)
                    continue;

                int slTheoPhieu = 0;

                int.TryParse(
                    Convert.ToString(
                        row.Cells["colSLTheoPhieu"].Value),
                    out slTheoPhieu);

                row.Cells["colSLThucTe"].Value =
                    0;

                row.Cells["colChenhLech"].Value =
                    -slTheoPhieu;

                row.Cells["colTrangThai"].Value =
                    "Chưa kiểm";

                row.Cells["colGhiChu"].Value =
                    "";
            }

            lblDaQuet.Text = "0 Lượt";

            CapNhatThongKe();

            
        }

        // =========================================================
        // XÁC NHẬN KIỂM KHO
        // =========================================================

        private void btnXacNhanKiemKho_Click(
            object sender,
            EventArgs e)
        {
            if (daXacNhan)
                return;

            if (maPN <= 0)
            {
                MessageBox.Show(
                    "Không có phiếu nhập để xử lý.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Không cho xác nhận nếu còn hàng chưa kiểm
            foreach (DataGridViewRow row
                in dgvHangHoa.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string trangThai =
                    Convert.ToString(
                        row.Cells["colTrangThai"].Value);

                if (trangThai == "Chưa kiểm")
                {
                    MessageBox.Show(
                        "Vẫn còn mặt hàng chưa kiểm.\n\n" +
                        "Hãy kiểm đủ tất cả mặt hàng trước khi xác nhận.",
                        "Chưa thể xác nhận",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
            }

            // Nếu có hàng lệch -> cảnh báo
            int soDongLech = 0;

            foreach (DataGridViewRow row
                in dgvHangHoa.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string trangThai =
                    Convert.ToString(
                        row.Cells["colTrangThai"].Value);

                if (trangThai == "Lệch")
                    soDongLech++;
            }

            string message =
                "Xác nhận kiểm kho phiếu PN" +
                maPN.ToString("D4") + "?";

            if (soDongLech > 0)
            {
                message +=
                    "\n\nCó " + soDongLech +
                    " mặt hàng bị lệch số lượng.";
            }

            message +=
                "\n\nSau khi xác nhận, hệ thống sẽ cập nhật tồn kho.";

            DialogResult result =
                MessageBox.Show(
                    message,
                    "Xác nhận kiểm kho",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            XacNhanVaCapNhatKho();
        }

        // =========================================================
        // CẬP NHẬT TONKHO + LICHSUTONKHO
        // =========================================================

        private void XacNhanVaCapNhatKho()
        {
            SqlConnection conn = null;
            SqlTransaction tran = null;

            try
            {
                conn = kt.GetConnection();

                if (conn.State != ConnectionState.Open)
                    conn.Open();

                tran = conn.BeginTransaction();

                // -------------------------------------------------
                // 1. Kiểm tra trạng thái phiếu lần cuối
                // -------------------------------------------------

                string sqlCheck = @"
                    SELECT TrangThai, MaKho
                    FROM PhieuNhap
                    WHERE MaPN = @MaPN";

                using (SqlCommand cmd =
                    new SqlCommand(
                        sqlCheck,
                        conn,
                        tran))
                {
                    cmd.Parameters.AddWithValue(
                        "@MaPN",
                        maPN);

                    using (SqlDataReader reader =
                        cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            throw new Exception(
                                "Không tìm thấy phiếu nhập.");
                        }

                        string trangThai =
                            reader["TrangThai"].ToString();

                        if (trangThai != "Chờ xuất kho")
                        {
                            throw new Exception(
                                "Phiếu không còn ở trạng thái 'Chờ xuất kho'.");
                        }

                        maKho =
                            Convert.ToInt32(
                                reader["MaKho"]);
                    }
                }

                // -------------------------------------------------
                // 2. Xử lý từng mặt hàng
                // -------------------------------------------------

                foreach (DataGridViewRow row
                    in dgvHangHoa.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    int maBienThe =
                        Convert.ToInt32(
                            row.Cells["colMaBienThe"].Value);

                    int slThucTe = 0;

                    int.TryParse(
                        Convert.ToString(
                            row.Cells["colSLThucTe"].Value),
                        out slThucTe);

                    if (slThucTe < 0)
                        throw new Exception(
                            "Số lượng thực tế không hợp lệ.");

                    // ---------------------------------------------
                    // Tìm dòng tồn kho
                    // ---------------------------------------------

                    string sqlTonKho = @"
                        SELECT MaTonKho
                        FROM TonKho
                        WHERE MaKho = @MaKho
                          AND MaBienThe = @MaBienThe";

                    object maTonKho;

                    using (SqlCommand cmd =
                        new SqlCommand(
                            sqlTonKho,
                            conn,
                            tran))
                    {
                        cmd.Parameters.AddWithValue(
                            "@MaKho",
                            maKho);

                        cmd.Parameters.AddWithValue(
                            "@MaBienThe",
                            maBienThe);

                        maTonKho =
                            cmd.ExecuteScalar();
                    }

                    // ---------------------------------------------
                    // Nếu chưa có TonKho -> INSERT
                    // ---------------------------------------------

                    if (maTonKho == null ||
                        maTonKho == DBNull.Value)
                    {
                        string sqlInsert = @"
                            INSERT INTO TonKho
                            (
                                MaKho,
                                MaBienThe,
                                SLTon,
                                SLToiThieu,
                                TongSLNhap,
                                TongSLXuat,
                                NgayNhapGanNhat
                            )
                            VALUES
                            (
                                @MaKho,
                                @MaBienThe,
                                @SLTon,
                                0,
                                @TongSLNhap,
                                0,
                                GETDATE()
                            )";

                        using (SqlCommand cmd =
                            new SqlCommand(
                                sqlInsert,
                                conn,
                                tran))
                        {
                            cmd.Parameters.AddWithValue(
                                "@MaKho",
                                maKho);

                            cmd.Parameters.AddWithValue(
                                "@MaBienThe",
                                maBienThe);

                            cmd.Parameters.AddWithValue(
                                "@SLTon",
                                slThucTe);

                            cmd.Parameters.AddWithValue(
                                "@TongSLNhap",
                                slThucTe);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // -----------------------------------------
                        // Có rồi -> CỘNG tồn
                        // -----------------------------------------

                        string sqlUpdate = @"
                            UPDATE TonKho
                            SET
                                SLTon = SLTon + @SL,
                                TongSLNhap =
                                    TongSLNhap + @SL,
                                NgayNhapGanNhat =
                                    GETDATE()
                            WHERE MaTonKho = @MaTonKho";

                        using (SqlCommand cmd =
                            new SqlCommand(
                                sqlUpdate,
                                conn,
                                tran))
                        {
                            cmd.Parameters.AddWithValue(
                                "@SL",
                                slThucTe);

                            cmd.Parameters.AddWithValue(
                                "@MaTonKho",
                                Convert.ToInt32(
                                    maTonKho));

                            cmd.ExecuteNonQuery();
                        }
                    }

                    // ---------------------------------------------
                    // Ghi lịch sử tồn kho
                    // ---------------------------------------------

                    if (slThucTe > 0)
                    {
                        string sqlHistory = @"
                            INSERT INTO LichSuTonKho
                            (
                                MaBienThe,
                                ThayDoi,
                                Loai,
                                MaTK,
                                ThoiGian
                            )
                            VALUES
                            (
                                @MaBienThe,
                                @ThayDoi,
                                N'Nhập hàng',
                                @MaTK,
                                GETDATE()
                            )";

                        using (SqlCommand cmd =
                            new SqlCommand(
                                sqlHistory,
                                conn,
                                tran))
                        {
                            cmd.Parameters.AddWithValue(
                                "@MaBienThe",
                                maBienThe);

                            cmd.Parameters.AddWithValue(
                                "@ThayDoi",
                                slThucTe);

                            cmd.Parameters.AddWithValue(
                                "@MaTK",
                                Session.MaTK);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                // -------------------------------------------------
                // 3. Đổi trạng thái phiếu
                // -------------------------------------------------

                string sqlUpdatePhieu = @"
                    UPDATE PhieuNhap
                    SET TrangThai = N'Đã xuất kho'
                    WHERE MaPN = @MaPN
                      AND TrangThai = N'Chờ xuất kho'";

                using (SqlCommand cmd =
                    new SqlCommand(
                        sqlUpdatePhieu,
                        conn,
                        tran))
                {
                    cmd.Parameters.AddWithValue(
                        "@MaPN",
                        maPN);

                    int affected =
                        cmd.ExecuteNonQuery();

                    if (affected != 1)
                    {
                        throw new Exception(
                            "Không thể cập nhật trạng thái phiếu.");
                    }
                }

                // -------------------------------------------------
                // 4. COMMIT
                // -------------------------------------------------

                tran.Commit();

                daXacNhan = true;

                dgvHangHoa.ReadOnly = true;

                btnDanhDauTatCa.Enabled = false;
                btnDatLai.Enabled = false;
                btnXacNhanKiemKho.Enabled = false;
                txtMaVach.Enabled = false;

              

                MessageBox.Show(
                    "Kiểm kho thành công!\n\n" +
                    "Phiếu PN" +
                    maPN.ToString("D4") +
                    " đã được cập nhật vào kho.",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                try
                {
                    if (tran != null)
                        tran.Rollback();
                }
                catch
                {
                }

                MessageBox.Show(
                    "Không thể cập nhật kho.\n\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }

        // =========================================================
        // TÊN NGƯỜI KIỂM
        // =========================================================

        private string LayTenNguoiKiem()
        {
            try
            {
                if (Session.MaTK <= 0)
                    return "Chưa xác định";

                string sql = @"
                    SELECT HoTen
                    FROM NhanVien
                    WHERE MaTK = @MaTK";

                SqlParameter[] parameters =
                {
                    new SqlParameter(
                        "@MaTK",
                        Session.MaTK)
                };

                object result =
                    kt.ExecuteScalar(
                        sql,
                        parameters);

                if (result != null &&
                    result != DBNull.Value)
                {
                    return result.ToString();
                }

                return Session.TenDangNhap ??
                       "Chưa xác định";
            }
            catch
            {
                return Session.TenDangNhap ??
                       "Chưa xác định";
            }
        }

        // =========================================================
        // DATAGRIDVIEW COMMIT
        // =========================================================

        private void dgvHangHoa_CurrentCellDirtyStateChanged(
            object sender,
            EventArgs e)
        {
            if (dgvHangHoa.IsCurrentCellDirty)
            {
                dgvHangHoa.CommitEdit(
                    DataGridViewDataErrorContexts.Commit);
            }
        }

        // =========================================================
        // EVENT CŨ - GIỮ LẠI ĐỂ DESIGNER KHÔNG LỖI
        // =========================================================

        private void grpThongTinPhieu_Click(
            object sender,
            EventArgs e)
        {
        }

        private void guna2HtmlLabel2_Click(
            object sender,
            EventArgs e)
        {
        }

        private void guna2HtmlLabel1_Click(
            object sender,
            EventArgs e)
        {
        }

        private void flowLayoutPanel1_Paint(
            object sender,
            PaintEventArgs e)
        {
        }

        private void dgvHangHoa_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
        }
    }
}