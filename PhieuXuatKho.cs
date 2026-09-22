using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SPORTSHOP
{
    public partial class PhieuXuatKho : Form
    {
        private readonly KetNoiDuLieu kt =
            new KetNoiDuLieu();

        private int maPXK = 0;

        public PhieuXuatKho()
        {
            InitializeComponent();

            Load += PhieuXuatKho_Load;

            btnLamMoi.Click +=
                BtnLamMoi_Click;

            btnChiTiet.Click +=
                BtnChiTiet_Click;

            txtTimKiem.TextChanged +=
                TxtTimKiem_TextChanged;

            dgvPhieu.CellClick +=
                DgvPhieu_CellClick;
        }

        // =========================================================
        // LOAD
        // =========================================================
        private void PhieuXuatKho_Load(
            object sender,
            EventArgs e)
        {
            LoadDanhSach();
        }

        // =========================================================
        // LÀM MỚI
        // =========================================================
        private void BtnLamMoi_Click(
            object sender,
            EventArgs e)
        {
            LoadDanhSach();
        }

        // =========================================================
        // SEARCH
        // =========================================================
        private void TxtTimKiem_TextChanged(
            object sender,
            EventArgs e)
        {
            LoadDanhSach();
        }

        // =========================================================
        // CLICK GRID
        // =========================================================
        private void DgvPhieu_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            ChonPhieu(e.RowIndex);
        }

        // =========================================================
        // LOAD DANH SÁCH PHIẾU
        // =========================================================
        private void LoadDanhSach()
        {
            try
            {
                string sql = @"
SELECT
    px.MaPXK,

    px.NgayXuat,

    kx.TenKho AS KhoXuat,

    kn.TenKho AS KhoNhan,

    nv.HoTen,

    px.LoaiXuat,

    px.TrangThai,

    px.LyDo

FROM dbo.PhieuXuatKho px

INNER JOIN dbo.Kho kx
    ON kx.MaKho = px.MaKhoXuat

LEFT JOIN dbo.Kho kn
    ON kn.MaKho = px.MaKhoNhap

INNER JOIN dbo.NhanVien nv
    ON nv.MaNV = px.MaNV

WHERE
       CAST(
           px.MaPXK AS nvarchar(20)
       ) LIKE N'%' + @q + N'%'

    OR kx.TenKho LIKE N'%' + @q + N'%'

    OR ISNULL(
           kn.TenKho,
           N''
       ) LIKE N'%' + @q + N'%'

    OR nv.HoTen LIKE N'%' + @q + N'%'

ORDER BY
    px.MaPXK DESC;";

                DataTable dt =
                    kt.GetData(
                        sql,
                        new SqlParameter[]
                        {
                            new SqlParameter(
                                "@q",
                                txtTimKiem.Text.Trim())
                        });

                dgvPhieu.DataSource = dt;

                dgvPhieu.ClearSelection();

                maPXK = 0;

                lblChiTiet.Text =
                    "Chọn một phiếu để xem chi tiết";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không tải được danh sách phiếu xuất kho.\n\n" +
                    ex.Message,
                    "Phiếu xuất kho",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // CHỌN PHIẾU
        // =========================================================
        private void ChonPhieu(int rowIndex)
        {
            if (rowIndex < 0 ||
                rowIndex >= dgvPhieu.Rows.Count)
            {
                return;
            }

            object value =
                dgvPhieu.Rows[rowIndex]
                    .Cells["MaPXK"]
                    .Value;

            if (value == null ||
                value == DBNull.Value)
            {
                return;
            }

            maPXK =
                Convert.ToInt32(value);

            lblChiTiet.Text =
                "Đã chọn PXK" +
                maPXK.ToString("D5");
        }

        // =========================================================
        // XEM CHI TIẾT
        // =========================================================
        private void BtnChiTiet_Click(
            object sender,
            EventArgs e)
        {
            if (maPXK <= 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn một phiếu xuất kho.",
                    "Phiếu xuất kho",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            using (
                PhieuXuatKhoChiTiet form =
                    new PhieuXuatKhoChiTiet(maPXK))
            {
                form.ShowDialog(this);
            }
        }
    }

    // =============================================================
    // FORM CHI TIẾT PHIẾU XUẤT
    // =============================================================
    public class PhieuXuatKhoChiTiet : Form
    {
        private readonly KetNoiDuLieu kt =
            new KetNoiDuLieu();

        private readonly int maPXK;

        private DataGridView dgv;
        private Label lbl;

        public PhieuXuatKhoChiTiet(
            int id)
        {
            maPXK = id;

            Text =
                "Chi tiết phiếu xuất kho";

            StartPosition =
                FormStartPosition.CenterParent;

            Size =
                new Size(950, 560);

            Build();

            Load +=
                PhieuXuatKhoChiTiet_Load;
        }

        // =========================================================
        // BUILD GIAO DIỆN
        // =========================================================
        private void Build()
        {
            lbl = new Label
            {
                Dock = DockStyle.Top,
                Height = 55,

                Text =
                    "CHI TIẾT PHIẾU XUẤT KHO",

                Font =
                    new Font(
                        "Segoe UI",
                        15,
                        FontStyle.Bold),

                Padding =
                    new Padding(
                        20,
                        15,
                        0,
                        0),

                ForeColor =
                    Color.White,

                BackColor =
                    Color.FromArgb(
                        37,
                        55,
                        80)
            };

            dgv = new DataGridView
            {
                Dock =
                    DockStyle.Fill,

                ReadOnly = true,

                AllowUserToAddRows =
                    false,

                AllowUserToDeleteRows =
                    false,

                RowHeadersVisible =
                    false,

                SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect,

                AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill,

                BackgroundColor =
                    Color.White,

                ColumnHeadersHeight =
                    38,

                EnableHeadersVisualStyles =
                    false
            };

            dgv.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(
                    67,
                    87,
                    115);

            dgv.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgv.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    9,
                    FontStyle.Bold);

            Controls.Add(dgv);

            Controls.Add(lbl);
        }

        // =========================================================
        // LOAD CHI TIẾT
        // =========================================================
        private void PhieuXuatKhoChiTiet_Load(
            object sender,
            EventArgs e)
        {
            try
            {
                string sql = @"
SELECT
    px.MaPXK,

    px.NgayXuat,

    kx.TenKho AS KhoXuat,

    kn.TenKho AS KhoNhan,

    nv.HoTen,

    sp.TenSP,

    bt.SKU,

    ISNULL(sz.TenSize, N'') AS Size,

    ISNULL(ms.TenMau, N'') AS Mau,

    ct.SoLuong,

    px.LyDo,

    px.TrangThai

FROM dbo.PhieuXuatKho px

INNER JOIN dbo.Kho kx
    ON kx.MaKho = px.MaKhoXuat

LEFT JOIN dbo.Kho kn
    ON kn.MaKho = px.MaKhoNhap

INNER JOIN dbo.NhanVien nv
    ON nv.MaNV = px.MaNV

INNER JOIN dbo.ChiTietPhieuXuatKho ct
    ON ct.MaPXK = px.MaPXK

INNER JOIN dbo.BienTheSanPham bt
    ON bt.MaBienThe = ct.MaBienThe

INNER JOIN dbo.SanPham sp
    ON sp.MaSP = bt.MaSP

LEFT JOIN dbo.Size sz
    ON sz.MaSize = bt.MaSize

LEFT JOIN dbo.MauSac ms
    ON ms.MaMau = bt.MaMau

WHERE px.MaPXK = @MaPXK

ORDER BY
    sp.TenSP;";

                dgv.DataSource =
                    kt.GetData(
                        sql,
                        new SqlParameter[]
                        {
                            new SqlParameter(
                                "@MaPXK",
                                maPXK)
                        });
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không tải được chi tiết phiếu xuất.\n\n" +
                    ex.Message,
                    "Phiếu xuất kho",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}