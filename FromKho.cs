using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SPORTSHOP
{
    public partial class FromKho : Form
    {
        private KetNoiDuLieu kt = new KetNoiDuLieu();

        private int? maKhoDangChon = null;

        public FromKho()
        {
            InitializeComponent();

            // Event
            txt_timkiem.TextChanged += txt_timkiem_TextChanged;
            cmb_tenkho.SelectedIndexChanged += cmb_tenkho_SelectedIndexChanged;
            cmb_trangthai.SelectedIndexChanged += cmb_trangthai_SelectedIndexChanged;

            cgv_danhsachkho.CellClick += cgv_danhsachkho_CellClick;
            cgv_danhsachkho.CellPainting += cgv_danhsachkho_CellPainting;

            btn_capnhat.Click += btn_capnhat_Click;
            btn_xuatbaocao.Click += btn_xuatbaocao_Click;

            this.Load += FromKho_Load;
        }
        private void cgv_danhsachkho_CellPainting(
    object sender,
    DataGridViewCellPaintingEventArgs e)
        {
            // Chỉ xử lý cột Trạng Thái
            if (e.RowIndex < 0 ||
                e.ColumnIndex < 0 ||
                cgv_danhsachkho.Columns[e.ColumnIndex].Name != "TrangThai")
            {
                return;
            }

            if (e.Value == null || e.Value == DBNull.Value)
                return;

            string trangThai = e.Value.ToString();

            bool dangHoatDong =
                trangThai == "Đang Hoạt Động" ||
                trangThai == "True" ||
                trangThai == "1";

            // Vẽ nền ô bình thường
            e.PaintBackground(
                e.CellBounds,
                true);

            // Kích thước badge
            int badgeWidth = dangHoatDong ? 120 : 90;
            int badgeHeight = 20;

            int x =
                e.CellBounds.X +
                (e.CellBounds.Width - badgeWidth) / 2;

            int y =
                e.CellBounds.Y +
                (e.CellBounds.Height - badgeHeight) / 2;

            Rectangle badgeRect =
                new Rectangle(
                    x,
                    y,
                    badgeWidth,
                    badgeHeight);

            // Màu badge
            Color backgroundColor;
            Color textColor;

            if (dangHoatDong)
            {
                backgroundColor =
                    Color.FromArgb(220, 245, 228);

                textColor =
                    Color.FromArgb(35, 130, 70);
            }
            else
            {
                backgroundColor =
                    Color.FromArgb(252, 225, 225);

                textColor =
                    Color.FromArgb(190, 50, 50);
            }

            using (SolidBrush brush =
                new SolidBrush(backgroundColor))
            {
                FillRoundedRectangle(
                e.Graphics,
                brush,
                badgeRect,
                10);
            }

            // Text
            string text =
                dangHoatDong
                    ? "✓ Đang Hoạt Động"
                    : "✕ Tạm Ngưng";

            using (SolidBrush brush =
                new SolidBrush(textColor))
            {
                StringFormat format =
                    new StringFormat
                    {
                        Alignment =
                            StringAlignment.Center,

                        LineAlignment =
                            StringAlignment.Center
                    };

                e.Graphics.DrawString(
                    text,
                    new Font(
                    "Segoe UI",
                    8F,
                    FontStyle.Bold),
                    brush,
                    badgeRect,
                    format);
            }

            // Không cho DataGridView tự vẽ lại
            e.Handled = true;
        }
        // =========================================================
        // LOAD FORM
        // =========================================================
        private void FromKho_Load(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra quyền xem kho
                if (!PhanQuyen.CoQuyenXemKho())
                {
                    MessageBox.Show(
                        "Tài khoản của bạn không có quyền xem kho!",
                        "Không có quyền",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    this.Close();
                    return;
                }

                LoadComboTenKho();
                LoadComboTrangThai();

                LoadDanhSachKho();
                LoadThongKe();

                btn_capnhat.Enabled = false;

                // Phân quyền nút
                btn_themkho.Enabled = PhanQuyen.CoQuyenThemKho();
                btn_capnhat.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải dữ liệu kho.\n\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =========================================================
        // COMBO TÊN KHO
        // =========================================================
        private void LoadComboTenKho()
        {
            cmb_tenkho.Items.Clear();
            cmb_tenkho.Items.Add("Tất Cả");

            string sql = @"
                SELECT DISTINCT TenKho
                FROM Kho
                ORDER BY TenKho";

            DataTable dt = kt.GetData(sql);

            foreach (DataRow row in dt.Rows)
            {
                cmb_tenkho.Items.Add(
                    row["TenKho"].ToString());
            }

            cmb_tenkho.SelectedIndex = 0;
        }

        // =========================================================
        // COMBO TRẠNG THÁI
        // =========================================================
        private void LoadComboTrangThai()
        {
            cmb_trangthai.Items.Clear();

            cmb_trangthai.Items.Add("Tất Cả");
            cmb_trangthai.Items.Add("Đang Hoạt Động");
            cmb_trangthai.Items.Add("Tạm Ngưng");

            cmb_trangthai.SelectedIndex = 0;
        }

        // =========================================================
        // LOAD DANH SÁCH KHO
        // =========================================================
        private void LoadDanhSachKho()
        {
                string sql = @"
                SELECT
                    MaKho,
                    TenKho,
                    DiaChi,
                    MoTa,
                    TongHangNhap,
                    CASE
                        WHEN TrangThai = 1 THEN N'Đang Hoạt Động'
                        ELSE N'Tạm Ngưng'
                    END AS TrangThai
                FROM Kho
                WHERE 1 = 1
                    ";

            // -----------------------------------------------------
            // Từ khóa
            // -----------------------------------------------------
            string tuKhoa = txt_timkiem.Text.Trim();

            if (!string.IsNullOrWhiteSpace(tuKhoa))
            {
                sql += @"
                    AND
                    (
                        TenKho LIKE @TuKhoa
                        OR DiaChi LIKE @TuKhoa
                    )";
            }

            // -----------------------------------------------------
            // Lọc tên kho
            // -----------------------------------------------------
            if (cmb_tenkho.SelectedIndex > 0)
            {
                sql += @"
                    AND TenKho = @TenKho";
            }

            // -----------------------------------------------------
            // Lọc trạng thái
            // -----------------------------------------------------
            if (cmb_trangthai.SelectedIndex > 0)
            {
                sql += @"
                    AND TrangThai = @TrangThai";
            }

            sql += " ORDER BY MaKho";

            SqlParameter[] parameters =
            {
                new SqlParameter(
                    "@TuKhoa",
                    "%" + tuKhoa + "%"),

                new SqlParameter(
                    "@TenKho",
                    cmb_tenkho.SelectedIndex > 0
                        ? cmb_tenkho.Text
                        : ""),

                new SqlParameter(
                    "@TrangThai",
                    cmb_trangthai.SelectedIndex == 1
                        ? 1
                        : 0)
            };

            DataTable dt = kt.GetData(sql, parameters);

            cgv_danhsachkho.DataSource = dt;

            DinhDangGrid();
        }

        // =========================================================
        // ĐỊNH DẠNG DATAGRIDVIEW
        // =========================================================
        private void DinhDangGrid()
        {
            // ==============================
            // TÊN CỘT
            // ==============================

            if (cgv_danhsachkho.Columns["MaKho"] != null)
                cgv_danhsachkho.Columns["MaKho"].HeaderText = "Mã Kho";

            if (cgv_danhsachkho.Columns["TenKho"] != null)
                cgv_danhsachkho.Columns["TenKho"].HeaderText = "Tên Kho";

            if (cgv_danhsachkho.Columns["DiaChi"] != null)
                cgv_danhsachkho.Columns["DiaChi"].HeaderText = "Địa Chỉ";

            if (cgv_danhsachkho.Columns["MoTa"] != null)
                cgv_danhsachkho.Columns["MoTa"].HeaderText = "Mô Tả";

            if (cgv_danhsachkho.Columns["TongHangNhap"] != null)
                cgv_danhsachkho.Columns["TongHangNhap"].HeaderText =
                    "Tổng Hàng Nhập";

            if (cgv_danhsachkho.Columns["TrangThai"] != null)
                cgv_danhsachkho.Columns["TrangThai"].HeaderText =
                    "Trạng Thái";


            // ==============================
            // FONT
            // ==============================

            cgv_danhsachkho.DefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            cgv_danhsachkho.AlternatingRowsDefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            cgv_danhsachkho.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold);


            // ==============================
            // CĂN GIỮA
            // ==============================

            cgv_danhsachkho.Columns["MaKho"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            cgv_danhsachkho.Columns["TongHangNhap"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            cgv_danhsachkho.Columns["TrangThai"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;


            // ==============================
            // CHIỀU RỘNG
            // ==============================

            cgv_danhsachkho.Columns["MaKho"].Width = 90;
            cgv_danhsachkho.Columns["TenKho"].Width = 200;
            cgv_danhsachkho.Columns["DiaChi"].Width = 300;
            cgv_danhsachkho.Columns["MoTa"].Width = 300;
            cgv_danhsachkho.Columns["TongHangNhap"].Width = 160;
            cgv_danhsachkho.Columns["TrangThai"].Width = 180;
        }

        // =========================================================
        // THỐNG KÊ
        // =========================================================
        private void LoadThongKe()
        {
            try
            {
                // Tổng số kho
                string sqlTongKho = @"
                    SELECT COUNT(*)
                    FROM Kho";

                int tongKho =
                    Convert.ToInt32(
                        kt.ExecuteScalar(sqlTongKho));

                label2.Text =
                    tongKho.ToString();

                // Kho tạm ngưng
                string sqlKhoNgung = @"
                    SELECT COUNT(*)
                    FROM Kho
                    WHERE TrangThai = 0";

                int khoNgung =
                    Convert.ToInt32(
                        kt.ExecuteScalar(sqlKhoNgung));

                label4.Text =
                    khoNgung + " (Cảnh báo)";

                // Tổng hàng nhập
                string sqlTongNhap = @"
                    SELECT ISNULL(SUM(TongHangNhap), 0)
                    FROM Kho";

                decimal tongNhap =
                    Convert.ToDecimal(
                        kt.ExecuteScalar(sqlTongNhap));

                label6.Text =
                    tongNhap.ToString("N0");
            }
            catch
            {
                label2.Text = "0";
                label4.Text = "0";
                label6.Text = "0";
            }
        }

        // =========================================================
        // TÌM KIẾM
        // =========================================================
        private void txt_timkiem_TextChanged(
            object sender,
            EventArgs e)
        {
            LoadDanhSachKho();
        }

        // =========================================================
        // LỌC TÊN KHO
        // =========================================================
        private void cmb_tenkho_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            if (!IsHandleCreated)
                return;

            LoadDanhSachKho();
        }

        // =========================================================
        // LỌC TRẠNG THÁI
        // =========================================================
        private void cmb_trangthai_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            if (!IsHandleCreated)
                return;

            LoadDanhSachKho();
        }

        // =========================================================
        // CLICK CHỌN KHO
        // =========================================================
        private void cgv_danhsachkho_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            // Không xử lý khi click header
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row =
                cgv_danhsachkho.Rows[e.RowIndex];

            object value = row.Cells["MaKho"].Value;

            // Kiểm tra null hoặc DBNull
            if (value == null || value == DBNull.Value)
                return;

            // Kiểm tra mã kho có hợp lệ không
            if (!int.TryParse(value.ToString(), out int maKho))
                return;

            maKhoDangChon = maKho;

            // Chỉ cho cập nhật nếu có quyền
            btn_capnhat.Enabled =
                PhanQuyen.CoQuyenSuaKho();
        }


        // =========================================================
        // CẬP NHẬT
        // =========================================================
        private void btn_capnhat_Click(
            object sender,
            EventArgs e)
        {
            if (!PhanQuyen.CoQuyenSuaKho())
            {
                MessageBox.Show(
                    "Tài khoản của bạn không có quyền sửa kho!",
                    "Không có quyền",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (maKhoDangChon == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn kho cần cập nhật.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            FormCapNhatKho frm =
    new FormCapNhatKho(maKhoDangChon.Value);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadComboTenKho();
                LoadDanhSachKho();
                LoadThongKe();

                maKhoDangChon = null;
                btn_capnhat.Enabled = false;
            }
        }

        // =========================================================
        // XUẤT BÁO CÁO
        // =========================================================
        private void btn_xuatbaocao_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                string sql = @"
            SELECT
                MaKho,
                TenKho,
                DiaChi,
                MoTa,
                TongHangNhap,
                CASE
                    WHEN TrangThai = 1
                        THEN N'Đang Hoạt Động'
                    ELSE N'Tạm Ngưng'
                END AS TrangThai
            FROM Kho
            ORDER BY MaKho";

                DataTable dt = kt.GetData(sql);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "Không có dữ liệu kho để xuất báo cáo!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();

                saveFileDialog.Filter =
                    "Excel Workbook (*.xlsx)|*.xlsx";

                saveFileDialog.Title =
                    "Lưu báo cáo danh sách kho";

                saveFileDialog.FileName =
                    "BaoCaoDanhSachKho_" +
                    DateTime.Now.ToString("yyyyMMdd_HHmmss") +
                    ".xlsx";

                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                using (var workbook =
                    new ClosedXML.Excel.XLWorkbook())
                {
                    var worksheet =
                        workbook.Worksheets.Add("Danh Sach Kho");

                    // =====================================
                    // TIÊU ĐỀ
                    // =====================================

                    worksheet.Cell(1, 1).Value =
                        "BÁO CÁO DANH SÁCH KHO";

                    worksheet.Range(1, 1, 1, 6)
                        .Merge();

                    worksheet.Cell(1, 1)
                        .Style.Font.Bold = true;

                    worksheet.Cell(1, 1)
                        .Style.Font.FontSize = 18;

                    worksheet.Cell(1, 1)
                        .Style.Alignment.Horizontal =
                            ClosedXML.Excel.XLAlignmentHorizontalValues.Center;

                    // =====================================
                    // THỜI GIAN
                    // =====================================

                    worksheet.Cell(2, 1).Value =
                        "Ngày xuất: " +
                        DateTime.Now.ToString("dd/MM/yyyy HH:mm");

                    worksheet.Range(2, 1, 2, 6)
                        .Merge();

                    worksheet.Cell(2, 1)
                        .Style.Alignment.Horizontal =
                            ClosedXML.Excel.XLAlignmentHorizontalValues.Center;

                    // =====================================
                    // HEADER
                    // =====================================

                    string[] headers =
                    {
                "Mã Kho",
                "Tên Kho",
                "Địa Chỉ",
                "Mô Tả",
                "Tổng Hàng Nhập",
                "Trạng Thái"
            };

                    for (int i = 0; i < headers.Length; i++)
                    {
                        worksheet.Cell(4, i + 1).Value =
                            headers[i];
                    }

                    var headerRange =
                        worksheet.Range(4, 1, 4, 6);

                    headerRange.Style.Font.Bold = true;

                    headerRange.Style.Alignment.Horizontal =
                        ClosedXML.Excel.XLAlignmentHorizontalValues.Center;

                    // =====================================
                    // DỮ LIỆU
                    // =====================================

                    int rowIndex = 5;

                    foreach (DataRow row in dt.Rows)
                    {
                        worksheet.Cell(rowIndex, 1).Value =
                            Convert.ToInt32(row["MaKho"]);

                        worksheet.Cell(rowIndex, 2).Value =
                            row["TenKho"].ToString();

                        worksheet.Cell(rowIndex, 3).Value =
                            row["DiaChi"] == DBNull.Value
                                ? ""
                                : row["DiaChi"].ToString();

                        worksheet.Cell(rowIndex, 4).Value =
                            row["MoTa"] == DBNull.Value
                                ? ""
                                : row["MoTa"].ToString();

                        worksheet.Cell(rowIndex, 5).Value =
                            Convert.ToDecimal(
                                row["TongHangNhap"]);

                        worksheet.Cell(rowIndex, 6).Value =
                            row["TrangThai"].ToString();

                        rowIndex++;
                    }

                    // =====================================
                    // THỐNG KÊ
                    // =====================================

                    int thongKeRow = rowIndex + 2;

                    worksheet.Cell(thongKeRow, 1).Value =
                        "THỐNG KÊ";

                    worksheet.Cell(thongKeRow, 1)
                        .Style.Font.Bold = true;

                    worksheet.Cell(thongKeRow + 1, 1).Value =
                        "Tổng số kho";

                    worksheet.Cell(thongKeRow + 1, 2).Value =
                        dt.Rows.Count;

                    int khoHoatDong = 0;
                    int khoTamNgung = 0;
                    decimal tongHangNhap = 0;

                    foreach (DataRow row in dt.Rows)
                    {
                        string trangThai =
                            row["TrangThai"].ToString();

                        if (trangThai == "Đang Hoạt Động")
                            khoHoatDong++;
                        else
                            khoTamNgung++;

                        tongHangNhap +=
                            Convert.ToDecimal(
                                row["TongHangNhap"]);
                    }

                    worksheet.Cell(thongKeRow + 2, 1).Value =
                        "Đang hoạt động";

                    worksheet.Cell(thongKeRow + 2, 2).Value =
                        khoHoatDong;

                    worksheet.Cell(thongKeRow + 3, 1).Value =
                        "Tạm ngưng";

                    worksheet.Cell(thongKeRow + 3, 2).Value =
                        khoTamNgung;

                    worksheet.Cell(thongKeRow + 4, 1).Value =
                        "Tổng hàng nhập";

                    worksheet.Cell(thongKeRow + 4, 2).Value =
                        tongHangNhap;

                    // =====================================
                    // FORMAT
                    // =====================================

                    worksheet.Columns().AdjustToContents();

                    worksheet.Column(3).Width = 30;
                    worksheet.Column(4).Width = 35;

                    worksheet.Range(
                        4,
                        1,
                        rowIndex - 1,
                        6).Style.Border.OutsideBorder =
                            ClosedXML.Excel.XLBorderStyleValues.Thin;

                    worksheet.Range(
                        4,
                        1,
                        rowIndex - 1,
                        6).Style.Border.InsideBorder =
                            ClosedXML.Excel.XLBorderStyleValues.Thin;

                    worksheet.SheetView.FreezeRows(4);

                    workbook.SaveAs(
                        saveFileDialog.FileName);
                }

                MessageBox.Show(
                    "Xuất báo cáo thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi xuất báo cáo:\n\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void guna2PanelTieuDe_Paint(
    object sender,
    PaintEventArgs e)
        {
        }

        

        private void btn_themkho_Click(object sender, EventArgs e)
        {
            if (!PhanQuyen.CoQuyenThemKho())
            {
                MessageBox.Show(
                    "Tài khoản của bạn không có quyền thêm kho!",
                    "Không có quyền",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            FormThemKho frm = new FormThemKho();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadComboTenKho();
                LoadDanhSachKho();
                LoadThongKe();

                maKhoDangChon = null;
                btn_capnhat.Enabled = false;
            }
        }
        private void FillRoundedRectangle(
    Graphics graphics,
    Brush brush,
    Rectangle rectangle,
    int radius)
        {
            using (System.Drawing.Drawing2D.GraphicsPath path =
                new System.Drawing.Drawing2D.GraphicsPath())
            {
                int diameter = radius * 2;

                path.AddArc(
                    rectangle.X,
                    rectangle.Y,
                    diameter,
                    diameter,
                    180,
                    90);

                path.AddArc(
                    rectangle.Right - diameter,
                    rectangle.Y,
                    diameter,
                    diameter,
                    270,
                    90);

                path.AddArc(
                    rectangle.Right - diameter,
                    rectangle.Bottom - diameter,
                    diameter,
                    diameter,
                    0,
                    90);

                path.AddArc(
                    rectangle.X,
                    rectangle.Bottom - diameter,
                    diameter,
                    diameter,
                    90,
                    90);

                path.CloseFigure();

                graphics.FillPath(brush, path);
            }
        }

    }
}