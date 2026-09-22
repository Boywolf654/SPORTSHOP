using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SPORTSHOP
{
    public partial class CanhBaoKho : Form
    {
        private readonly KetNoiDuLieu kt = new KetNoiDuLieu();

        private bool dangLoad = false;

        public CanhBaoKho()
        {
            InitializeComponent();

            Load += CanhBaoKho_Load;

            cmbKho.SelectedIndexChanged += CmbKho_SelectedIndexChanged;

            btnLamMoi.Click += BtnLamMoi_Click;

            btnDieuChuyen.Click += BtnDieuChuyen_Click;
        }

        // =========================================================
        // LOAD FORM
        // =========================================================
        private void CanhBaoKho_Load(object sender, EventArgs e)
        {
            LoadKho();
            LoadCanhBao();
        }

        // =========================================================
        // LOAD DANH SÁCH KHO
        // =========================================================
        private void LoadKho()
        {
            dangLoad = true;

            try
            {
                DataTable dt = KhoService.LayKhoHoatDong(kt);

                DataRow row = dt.NewRow();

                row["MaKho"] = 0;
                row["TenKho"] = "Tất cả kho";
                row["LoaiKho"] = "";

                dt.Rows.InsertAt(row, 0);

                cmbKho.DataSource = dt;
                cmbKho.DisplayMember = "TenKho";
                cmbKho.ValueMember = "MaKho";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không tải được danh sách kho.\n\n" + ex.Message,
                    "Cảnh báo kho",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                dangLoad = false;
            }
        }

        // =========================================================
        // CHỌN KHO
        // =========================================================
        private void CmbKho_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            if (!dangLoad)
            {
                LoadCanhBao();
            }
        }

        // =========================================================
        // LẤY MÃ KHO
        // =========================================================
        private int LayMaKhoDangChon()
        {
            if (cmbKho.SelectedValue == null)
                return 0;

            try
            {
                return Convert.ToInt32(cmbKho.SelectedValue);
            }
            catch
            {
                return 0;
            }
        }

        // =========================================================
        // LOAD CẢNH BÁO TỒN KHO
        // =========================================================
        private void LoadCanhBao()
        {
            try
            {
                int maKho = LayMaKhoDangChon();

                string sql = @"
SELECT
    tk.MaKho,

    k.TenKho,

    ISNULL(k.LoaiKho, N'Phụ') AS LoaiKho,

    tk.MaBienThe,

    bt.SKU,

    sp.TenSP,

    ISNULL(sz.TenSize, N'') AS Size,

    ISNULL(ms.TenMau, N'') AS Mau,

    tk.SLTon,

    tk.SLToiThieu,

    ISNULL(
        (
            SELECT SUM(x.SLTon)
            FROM dbo.TonKho x
            WHERE x.MaBienThe = tk.MaBienThe
              AND x.MaKho <> tk.MaKho
        ),
        0
    ) AS TonKhoKhac,

    CASE
        WHEN tk.SLTon = 0
            THEN N'Hết hàng'
        ELSE N'Sắp hết'
    END AS MucDo

FROM dbo.TonKho tk

INNER JOIN dbo.Kho k
    ON k.MaKho = tk.MaKho

INNER JOIN dbo.BienTheSanPham bt
    ON bt.MaBienThe = tk.MaBienThe

INNER JOIN dbo.SanPham sp
    ON sp.MaSP = bt.MaSP

LEFT JOIN dbo.Size sz
    ON sz.MaSize = bt.MaSize

LEFT JOIN dbo.MauSac ms
    ON ms.MaMau = bt.MaMau

WHERE tk.SLTon <= tk.SLToiThieu

  AND
  (
      @MaKho = 0
      OR tk.MaKho = @MaKho
  )

ORDER BY
    CASE
        WHEN tk.SLTon = 0 THEN 0
        ELSE 1
    END,

    tk.SLTon,

    sp.TenSP;";

                dgvCanhBao.DataSource = kt.GetData(
                    sql,
                    new SqlParameter[]
                    {
                        new SqlParameter("@MaKho", maKho)
                    });

                int soLuong = 0;

                if (dgvCanhBao.Rows.Count > 0)
                    soLuong = dgvCanhBao.Rows.Count;

                lblSoLuong.Text =
                    "Có " +
                    soLuong.ToString("N0") +
                    " biến thể cần xử lý";

                dgvCanhBao.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không tải được cảnh báo tồn kho.\n\n" +
                    ex.Message,
                    "Cảnh báo kho",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // LÀM MỚI
        // =========================================================
        private void BtnLamMoi_Click(
            object sender,
            EventArgs e)
        {
            LoadKho();
            LoadCanhBao();
        }

        // =========================================================
        // ĐIỀU CHUYỂN
        // =========================================================
        private void BtnDieuChuyen_Click(
            object sender,
            EventArgs e)
        {
            if (dgvCanhBao.CurrentRow == null)
            {
                MessageBox.Show(
                    "Hãy chọn một mặt hàng cần xử lý.",
                    "Cảnh báo kho",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                int maKhoXuat =
                    Convert.ToInt32(
                        dgvCanhBao.CurrentRow
                            .Cells["MaKho"]
                            .Value);

                int maBienThe =
                    Convert.ToInt32(
                        dgvCanhBao.CurrentRow
                            .Cells["MaBienThe"]
                            .Value);

                using (DieuChuyenKho form =
                    new DieuChuyenKho(
                        maKhoXuat,
                        maBienThe,
                        true))
                {
                    form.ShowDialog(this);
                }

                LoadCanhBao();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể mở chức năng điều chuyển.\n\n" +
                    ex.Message,
                    "Cảnh báo kho",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}