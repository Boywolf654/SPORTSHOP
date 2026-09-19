using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SPORTSHOP._07_KhachHang
{
    public partial class FormViDienTu : Form
    {
        private readonly KetNoiDuLieu kt = new KetNoiDuLieu();
        private int maKH;
        private int maVi;

        public FormViDienTu()
        {
            InitializeComponent();
            maKH = LayMaKH();
            LoadDuLieu();
        }

        private int LayMaKH()
        {
            if (Session.MaTK <= 0) return 0;

            object v = kt.ExecuteScalar(
                "SELECT TOP 1 MaKH FROM KhachHang WHERE MaTK=@MaTK",
                new SqlParameter[]
                {
                    new SqlParameter("@MaTK", Session.MaTK)
                });

            return v == null || v == DBNull.Value ? 0 : Convert.ToInt32(v);
        }

        private void LoadDuLieu()
        {
            try
            {
                if (maKH <= 0)
                {
                    lbSoDu.Text = "0 đ";
                    lbDiem.Text = "0 điểm";
                    lbHang.Text = "Chưa xác định";
                    return;
                }

                kt.Execute(@"
IF NOT EXISTS
(
    SELECT 1
    FROM ViDienTu
    WHERE MaKH=@MaKH
)
BEGIN
    INSERT INTO ViDienTu(MaKH, SoDu)
    VALUES(@MaKH, 0);
END",
                    new SqlParameter[]
                    {
                        new SqlParameter("@MaKH", maKH)
                    });

                DataTable dt = kt.GetData(@"
SELECT TOP 1
       v.MaVi,
       v.SoDu,
       kh.DiemHoiVien,
       ISNULL(h.TenHang,N'Đồng') AS TenHang
FROM ViDienTu v
JOIN KhachHang kh ON kh.MaKH=v.MaKH
LEFT JOIN HangHoiVien h ON h.MaHangHoiVien=kh.MaHangHoiVien
WHERE v.MaKH=@MaKH",
                    new SqlParameter[]
                    {
                        new SqlParameter("@MaKH", maKH)
                    });

                if (dt.Rows.Count == 0) return;

                DataRow r = dt.Rows[0];
                maVi = Convert.ToInt32(r["MaVi"]);
                lbSoDu.Text = Convert.ToDecimal(r["SoDu"]).ToString("N0") + " đ";
                lbDiem.Text = Convert.ToInt32(r["DiemHoiVien"]).ToString("N0") + " điểm";
                lbHang.Text = r["TenHang"].ToString();

                LoadLichSu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải ví.\n\n" + ex.Message,
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadLichSu()
        {
            try
            {
                if (maVi <= 0) return;

                DataTable dt = kt.GetData(@"
SELECT TOP 30
       ThoiGian,
       LoaiGD,
       SoTien,
       SoDuSau,
       NoiDung
FROM GiaoDichVi
WHERE MaVi=@MaVi
ORDER BY ThoiGian DESC,MaGD DESC",
                    new SqlParameter[]
                    {
                        new SqlParameter("@MaVi", maVi)
                    });

                dgvLichSu.DataSource = dt;

                if (dgvLichSu.Columns["ThoiGian"] != null)
                    dgvLichSu.Columns["ThoiGian"].HeaderText = "Thời gian";

                if (dgvLichSu.Columns["LoaiGD"] != null)
                    dgvLichSu.Columns["LoaiGD"].HeaderText = "Loại giao dịch";

                if (dgvLichSu.Columns["SoTien"] != null)
                {
                    dgvLichSu.Columns["SoTien"].HeaderText = "Số tiền";
                    dgvLichSu.Columns["SoTien"].DefaultCellStyle.Format = "N0";
                }

                if (dgvLichSu.Columns["SoDuSau"] != null)
                {
                    dgvLichSu.Columns["SoDuSau"].HeaderText = "Số dư sau";
                    dgvLichSu.Columns["SoDuSau"].DefaultCellStyle.Format = "N0";
                }

                if (dgvLichSu.Columns["NoiDung"] != null)
                    dgvLichSu.Columns["NoiDung"].HeaderText = "Nội dung";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải lịch sử ví.\n\n" + ex.Message,
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void NapTien(decimal soTien)
        {
            if (soTien <= 0)
            {
                MessageBox.Show(
                    "Số tiền phải lớn hơn 0.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (maVi <= 0)
            {
                MessageBox.Show(
                    "Không tìm thấy ví khách hàng.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection cn = kt.GetConnection())
            {
                cn.Open();

                using (SqlTransaction tr = cn.BeginTransaction())
                {
                    try
                    {
                        decimal truoc;

                        using (SqlCommand cmd = new SqlCommand(
                            @"SELECT SoDu
                              FROM ViDienTu WITH(UPDLOCK,ROWLOCK)
                              WHERE MaVi=@MaVi",
                            cn, tr))
                        {
                            cmd.Parameters.AddWithValue("@MaVi", maVi);
                            object v = cmd.ExecuteScalar();

                            if (v == null || v == DBNull.Value)
                                throw new Exception("Không tìm thấy ví.");

                            truoc = Convert.ToDecimal(v);
                        }

                        decimal sau = truoc + soTien;

                        using (SqlCommand cmd = new SqlCommand(@"
UPDATE ViDienTu
SET SoDu=@Sau,
    NgayCapNhat=GETDATE()
WHERE MaVi=@MaVi;

INSERT INTO GiaoDichVi
(
    MaVi,
    LoaiGD,
    SoTien,
    SoDuTruoc,
    SoDuSau,
    NoiDung
)
VALUES
(
    @MaVi,
    N'Nạp tiền',
    @Tien,
    @Truoc,
    @Sau,
    N'Nạp tiền ví mô phỏng'
);", cn, tr))
                        {
                            cmd.Parameters.AddWithValue("@MaVi", maVi);
                            cmd.Parameters.AddWithValue("@Tien", soTien);
                            cmd.Parameters.AddWithValue("@Truoc", truoc);
                            cmd.Parameters.AddWithValue("@Sau", sau);
                            cmd.ExecuteNonQuery();
                        }

                        tr.Commit();
                        LoadDuLieu();

                        MessageBox.Show(
                            "Nạp thành công " + soTien.ToString("N0") + " đ.",
                            "SPORTSHOP",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    catch
                    {
                        try { tr.Rollback(); } catch { }
                        throw;
                    }
                }
            }
        }

        private void btnNap_Click(object sender, EventArgs e)
        {
            decimal soTien;
            string text = txtSoTien.Text
                .Replace(",", "")
                .Replace(".", "")
                .Trim();

            if (!decimal.TryParse(text, out soTien))
            {
                MessageBox.Show(
                    "Số tiền không hợp lệ.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                NapTien(soTien);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Nạp tiền thất bại.\n\n" + ex.Message,
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btn100_Click(object s, EventArgs e) { txtSoTien.Text = "100000"; }
        private void btn200_Click(object s, EventArgs e) { txtSoTien.Text = "200000"; }
        private void btn500_Click(object s, EventArgs e) { txtSoTien.Text = "500000"; }
        private void btn1Tr_Click(object s, EventArgs e) { txtSoTien.Text = "1000000"; }
        private void btn2Tr_Click(object s, EventArgs e) { txtSoTien.Text = "2000000"; }
        private void btnLichSu_Click(object s, EventArgs e) { LoadLichSu(); }

        // Helper UI: để ngoài Designer để Visual Studio Designer không báo "Method ... not found".
        private void SetupPanel(
            Guna.UI2.WinForms.Guna2Panel p,
            int x,
            int y,
            int w,
            int h)
        {
            p.FillColor = System.Drawing.Color.White;
            p.BorderRadius = 16;
            p.Location = new System.Drawing.Point(x, y);
            p.Size = new System.Drawing.Size(w, h);
        }

        private void SetupQuick(
            Guna.UI2.WinForms.Guna2Button b,
            string text,
            int x)
        {
            b.Text = text;
            b.BorderRadius = 8;
            b.Size = new System.Drawing.Size(90, 40);
            b.Location = new System.Drawing.Point(x, 84);

            if (b == btn100) b.Click += btn100_Click;
            if (b == btn200) b.Click += btn200_Click;
            if (b == btn500) b.Click += btn500_Click;
            if (b == btn1Tr) b.Click += btn1Tr_Click;
            if (b == btn2Tr) b.Click += btn2Tr_Click;
        }
    }
}
