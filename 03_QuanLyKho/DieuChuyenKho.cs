using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SPORTSHOP
{
    public partial class DieuChuyenKho : Form
    {
        private readonly KetNoiDuLieu kt = new KetNoiDuLieu();

        private readonly int khoXuatMacDinh;
        private readonly int khoNhapMacDinh;
        private readonly int bienTheMacDinh;
        private readonly bool moTuCanhBao;

        private bool dangNap = false;

        public DieuChuyenKho()
            : this(0, 0)
        {
        }

        public DieuChuyenKho(int maKhoXuat, int maBienThe)
        {
            khoXuatMacDinh = maKhoXuat;
            khoNhapMacDinh = 0;
            bienTheMacDinh = maBienThe;
            moTuCanhBao = false;

            InitializeComponent();

            this.Load += DieuChuyenKho_Load;
            this.cmbKhoXuat.SelectedIndexChanged += CmbKhoXuat_SelectedIndexChanged;
            this.cmbBienThe.SelectedIndexChanged += CmbBienThe_SelectedIndexChanged;
            this.btnChuyen.Click += BtnChuyen_Click;
            this.btnDong.Click += BtnDong_Click;
        }

        // Dùng khi mở từ màn hình Cảnh báo kho:
        // kho đang cảnh báo được ưu tiên làm KHO NHẬN,
        // còn KHO XUẤT sẽ cho phép chọn một kho khác.
        public DieuChuyenKho(int maKhoCanhBao, int maBienThe, bool tuCanhBao)
        {
            khoXuatMacDinh = 0;
            khoNhapMacDinh = tuCanhBao ? maKhoCanhBao : 0;
            bienTheMacDinh = maBienThe;
            moTuCanhBao = tuCanhBao;

            InitializeComponent();

            this.Load += DieuChuyenKho_Load;
            this.cmbKhoXuat.SelectedIndexChanged += CmbKhoXuat_SelectedIndexChanged;
            this.cmbBienThe.SelectedIndexChanged += CmbBienThe_SelectedIndexChanged;
            this.btnChuyen.Click += BtnChuyen_Click;
            this.btnDong.Click += BtnDong_Click;
        }

        private void DieuChuyenKho_Load(object sender, EventArgs e)
        {
            LoadKho();

            if (moTuCanhBao)
            {
                // Khi mở từ Cảnh báo kho, kho đang thiếu hàng là KHO NHẬN.
                if (khoNhapMacDinh > 0)
                    cmbKhoNhap.SelectedValue = khoNhapMacDinh;

                // Chọn mặc định một kho khác làm KHO XUẤT.
                ChonKhoXuatKhac(khoNhapMacDinh);
            }
            else
            {
                if (khoXuatMacDinh > 0)
                    cmbKhoXuat.SelectedValue = khoXuatMacDinh;

                if (khoNhapMacDinh > 0)
                    cmbKhoNhap.SelectedValue = khoNhapMacDinh;
            }

            LoadBienThe();

            if (bienTheMacDinh > 0)
                ChonBienTheNeuCo(bienTheMacDinh);

            CapNhatTon();
        }

        private void LoadKho()
        {
            dangNap = true;

            try
            {
                DataTable dt = KhoService.LayKhoHoatDong(kt);

                cmbKhoXuat.DataSource = dt.Copy();
                cmbKhoXuat.DisplayMember = "TenKho";
                cmbKhoXuat.ValueMember = "MaKho";

                cmbKhoNhap.DataSource = dt.Copy();
                cmbKhoNhap.DisplayMember = "TenKho";
                cmbKhoNhap.ValueMember = "MaKho";

                // Không tự ép kho nhận = dòng số 2 nữa.
                // Nếu mở từ Cảnh báo kho, DieuChuyenKho_Load sẽ chọn kho nhận
                // theo kho đang thiếu hàng.
                if (!moTuCanhBao && dt.Rows.Count > 1)
                    cmbKhoNhap.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không tải được danh sách kho.\n\n" + ex.Message,
                    "Điều chuyển kho",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                dangNap = false;
            }
        }

        private void ChonKhoXuatKhac(int maKhoKhongChon)
        {
            if (cmbKhoXuat.Items.Count == 0)
                return;

            for (int i = 0; i < cmbKhoXuat.Items.Count; i++)
            {
                cmbKhoXuat.SelectedIndex = i;

                if (LayMaKhoXuat() != maKhoKhongChon)
                    return;
            }
        }

        private void ChonBienTheNeuCo(int maBienThe)
        {
            for (int i = 0; i < cmbBienThe.Items.Count; i++)
            {
                cmbBienThe.SelectedIndex = i;

                if (LayMaBienThe() == maBienThe)
                    return;
            }
        }

        private int LayMaKhoXuat()
        {
            if (cmbKhoXuat.SelectedValue == null)
                return 0;

            try
            {
                return Convert.ToInt32(cmbKhoXuat.SelectedValue);
            }
            catch
            {
                return 0;
            }
        }

        private int LayMaKhoNhap()
        {
            if (cmbKhoNhap.SelectedValue == null)
                return 0;

            try
            {
                return Convert.ToInt32(cmbKhoNhap.SelectedValue);
            }
            catch
            {
                return 0;
            }
        }

        private int LayMaBienThe()
        {
            if (cmbBienThe.SelectedValue == null)
                return 0;

            try
            {
                return Convert.ToInt32(cmbBienThe.SelectedValue);
            }
            catch
            {
                return 0;
            }
        }

        private void CmbKhoXuat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!dangNap)
                LoadBienThe();
        }

        private void CmbBienThe_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatTon();
        }

        private void LoadBienThe()
        {
            int maKhoXuat = LayMaKhoXuat();

            if (maKhoXuat <= 0)
            {
                cmbBienThe.DataSource = null;
                lblTon.Text = "Tồn kho xuất: -";
                nudSoLuong.Maximum = 1;
                nudSoLuong.Value = 1;
                return;
            }

            try
            {
                string sql = @"
SELECT
    tk.MaBienThe,
    sp.TenSP
        + N' | Size ' + ISNULL(sz.TenSize, N'')
        + N' | Màu ' + ISNULL(ms.TenMau, N'')
        + N' | Tồn ' + CONVERT(nvarchar(20), tk.SLTon) AS HienThi,
    tk.SLTon
FROM dbo.TonKho tk
INNER JOIN dbo.BienTheSanPham bt
    ON bt.MaBienThe = tk.MaBienThe
INNER JOIN dbo.SanPham sp
    ON sp.MaSP = bt.MaSP
LEFT JOIN dbo.Size sz
    ON sz.MaSize = bt.MaSize
LEFT JOIN dbo.MauSac ms
    ON ms.MaMau = bt.MaMau
WHERE tk.MaKho = @MaKho
  AND tk.SLTon > 0
ORDER BY sp.TenSP, sz.TenSize, ms.TenMau;";

                DataTable dt = kt.GetData(
                    sql,
                    new SqlParameter[]
                    {
                        new SqlParameter("@MaKho", maKhoXuat)
                    });

                cmbBienThe.DataSource = dt;
                cmbBienThe.DisplayMember = "HienThi";
                cmbBienThe.ValueMember = "MaBienThe";

                CapNhatTon();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không tải được danh sách biến thể trong kho.\n\n" + ex.Message,
                    "Điều chuyển kho",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CapNhatTon()
        {
            DataRowView row = cmbBienThe.SelectedItem as DataRowView;

            if (row != null)
            {
                int ton = Convert.ToInt32(row["SLTon"]);

                lblTon.Text = "Tồn kho xuất: " + ton.ToString("N0");

                nudSoLuong.Maximum = Math.Max(1, ton);

                if (nudSoLuong.Value > nudSoLuong.Maximum)
                    nudSoLuong.Value = nudSoLuong.Maximum;
            }
            else
            {
                lblTon.Text = "Tồn kho xuất: -";
                nudSoLuong.Maximum = 1;
                nudSoLuong.Value = 1;
            }
        }

        private void BtnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnChuyen_Click(object sender, EventArgs e)
        {
            int maKhoXuat = LayMaKhoXuat();
            int maKhoNhap = LayMaKhoNhap();
            int maBienThe = LayMaBienThe();
            int soLuong = Convert.ToInt32(nudSoLuong.Value);
            int maNV = Session.MaNV;

            if (maKhoXuat <= 0 || maKhoNhap <= 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn đầy đủ kho xuất và kho nhận.",
                    "Điều chuyển kho",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (maKhoXuat == maKhoNhap)
            {
                MessageBox.Show(
                    "Kho xuất và kho nhận phải khác nhau.",
                    "Điều chuyển kho",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (maBienThe <= 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn biến thể sản phẩm.",
                    "Điều chuyển kho",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (soLuong <= 0)
            {
                MessageBox.Show(
                    "Số lượng phải lớn hơn 0.",
                    "Điều chuyển kho",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (maNV <= 0)
            {
                MessageBox.Show(
                    "Không xác định được nhân viên đăng nhập.",
                    "Điều chuyển kho",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Xác nhận điều chuyển " + soLuong.ToString("N0")
                + " sản phẩm từ:\n\n"
                + cmbKhoXuat.Text
                + "\n\nsang:\n\n"
                + cmbKhoNhap.Text
                + "?",
                "Xác nhận điều chuyển",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            using (SqlConnection conn = kt.GetConnection())
            {
                conn.Open();

                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        int tonXuat = 0;

                        using (SqlCommand cmd = new SqlCommand(
                            @"SELECT SLTon
                              FROM dbo.TonKho WITH (UPDLOCK, ROWLOCK)
                              WHERE MaKho = @MaKho
                                AND MaBienThe = @MaBienThe;",
                            conn,
                            tran))
                        {
                            cmd.Parameters.AddWithValue("@MaKho", maKhoXuat);
                            cmd.Parameters.AddWithValue("@MaBienThe", maBienThe);

                            object result = cmd.ExecuteScalar();

                            if (result != null && result != DBNull.Value)
                                tonXuat = Convert.ToInt32(result);
                        }

                        if (tonXuat < soLuong)
                            throw new Exception(
                                "Kho xuất chỉ còn "
                                + tonXuat.ToString("N0")
                                + " sản phẩm.");

                        int affected = ExecTon(
                            conn,
                            tran,
                            @"UPDATE dbo.TonKho
                              SET SLTon = SLTon - @SL,
                                  TongSLXuat = ISNULL(TongSLXuat, 0) + @SL
                              WHERE MaKho = @MaKho
                                AND MaBienThe = @MaBienThe
                                AND SLTon >= @SL;",
                            soLuong,
                            maKhoXuat,
                            maBienThe);

                        if (affected != 1)
                            throw new Exception("Không thể trừ tồn kho xuất.");

                        affected = ExecTon(
                            conn,
                            tran,
                            @"UPDATE dbo.TonKho
                              SET SLTon = SLTon + @SL
                              WHERE MaKho = @MaKho
                                AND MaBienThe = @MaBienThe;",
                            soLuong,
                            maKhoNhap,
                            maBienThe);

                        if (affected == 0)
                        {
                            using (SqlCommand cmd = new SqlCommand(
                                @"INSERT INTO dbo.TonKho
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
                                      @SL,
                                      0,
                                      @SL,
                                      0,
                                      GETDATE()
                                  );",
                                conn,
                                tran))
                            {
                                cmd.Parameters.AddWithValue("@MaKho", maKhoNhap);
                                cmd.Parameters.AddWithValue("@MaBienThe", maBienThe);
                                cmd.Parameters.AddWithValue("@SL", soLuong);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        int maPCK = InsertPck(
                            conn,
                            tran,
                            maKhoXuat,
                            maKhoNhap,
                            maNV);

                        ExecChiTiet(
                            conn,
                            tran,
                            @"INSERT INTO dbo.ChiTietPhieuChuyenKho
                              (MaPCK, MaBienThe, SoLuong)
                              VALUES (@MaPCK, @MaBienThe, @SL);",
                            maPCK,
                            maBienThe,
                            soLuong);

                        int maPXK = InsertPxk(
                            conn,
                            tran,
                            maKhoXuat,
                            maKhoNhap,
                            maNV,
                            maPCK);

                        ExecChiTietPxk(
                            conn,
                            tran,
                            maPXK,
                            maBienThe,
                            soLuong);

                        GhiLichSuNeuCo(
                            conn,
                            tran,
                            maBienThe,
                            -soLuong,
                            maNV,
                            "Chuyển kho xuất");

                        GhiLichSuNeuCo(
                            conn,
                            tran,
                            maBienThe,
                            soLuong,
                            maNV,
                            "Chuyển kho nhập");

                        tran.Commit();

                        MessageBox.Show(
                            "ĐIỀU CHUYỂN THÀNH CÔNG!\n\n"
                            + "Phiếu xuất kho: PXK"
                            + maPXK.ToString("D5")
                            + "\n"
                            + "Phiếu điều chuyển: PCK"
                            + maPCK.ToString("D5"),
                            "Kho",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            tran.Rollback();
                        }
                        catch
                        {
                        }

                        MessageBox.Show(
                            "ĐIỀU CHUYỂN THẤT BẠI.\n\n" + ex.Message,
                            "Kho",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        private int ExecTon(
            SqlConnection conn,
            SqlTransaction tran,
            string sql,
            int soLuong,
            int maKho,
            int maBienThe)
        {
            using (SqlCommand cmd = new SqlCommand(sql, conn, tran))
            {
                cmd.Parameters.AddWithValue("@SL", soLuong);
                cmd.Parameters.AddWithValue("@MaKho", maKho);
                cmd.Parameters.AddWithValue("@MaBienThe", maBienThe);

                return cmd.ExecuteNonQuery();
            }
        }

        private int ExecChiTiet(
            SqlConnection conn,
            SqlTransaction tran,
            string sql,
            int maPCK,
            int maBienThe,
            int soLuong)
        {
            using (SqlCommand cmd = new SqlCommand(sql, conn, tran))
            {
                cmd.Parameters.AddWithValue("@MaPCK", maPCK);
                cmd.Parameters.AddWithValue("@MaBienThe", maBienThe);
                cmd.Parameters.AddWithValue("@SL", soLuong);

                return cmd.ExecuteNonQuery();
            }
        }

        private int InsertPck(
            SqlConnection conn,
            SqlTransaction tran,
            int maKhoXuat,
            int maKhoNhap,
            int maNV)
        {
            using (SqlCommand cmd = new SqlCommand(
                @"INSERT INTO dbo.PhieuChuyenKho
                  (
                      NgayChuyen,
                      MaKhoXuat,
                      MaKhoNhap,
                      MaNV,
                      LyDo,
                      TrangThai
                  )
                  OUTPUT INSERTED.MaPCK
                  VALUES
                  (
                      GETDATE(),
                      @Xuat,
                      @Nhap,
                      @NV,
                      @LyDo,
                      N'Đã chuyển'
                  );",
                conn,
                tran))
            {
                cmd.Parameters.AddWithValue("@Xuat", maKhoXuat);
                cmd.Parameters.AddWithValue("@Nhap", maKhoNhap);
                cmd.Parameters.AddWithValue("@NV", maNV);
                cmd.Parameters.AddWithValue(
                    "@LyDo",
                    string.IsNullOrWhiteSpace(txtLyDo.Text)
                        ? (object)DBNull.Value
                        : txtLyDo.Text.Trim());

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private int InsertPxk(
            SqlConnection conn,
            SqlTransaction tran,
            int maKhoXuat,
            int maKhoNhap,
            int maNV,
            int maPCK)
        {
            using (SqlCommand cmd = new SqlCommand(
                @"INSERT INTO dbo.PhieuXuatKho
                  (
                      NgayXuat,
                      MaKhoXuat,
                      MaKhoNhap,
                      MaNV,
                      MaPCK,
                      LoaiXuat,
                      LyDo,
                      TrangThai
                  )
                  OUTPUT INSERTED.MaPXK
                  VALUES
                  (
                      GETDATE(),
                      @Xuat,
                      @Nhap,
                      @NV,
                      @PCK,
                      N'Chuyển kho',
                      @LyDo,
                      N'Đã xuất'
                  );",
                conn,
                tran))
            {
                cmd.Parameters.AddWithValue("@Xuat", maKhoXuat);
                cmd.Parameters.AddWithValue("@Nhap", maKhoNhap);
                cmd.Parameters.AddWithValue("@NV", maNV);
                cmd.Parameters.AddWithValue("@PCK", maPCK);
                cmd.Parameters.AddWithValue(
                    "@LyDo",
                    string.IsNullOrWhiteSpace(txtLyDo.Text)
                        ? (object)DBNull.Value
                        : txtLyDo.Text.Trim());

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private int ExecChiTietPxk(
            SqlConnection conn,
            SqlTransaction tran,
            int maPXK,
            int maBienThe,
            int soLuong)
        {
            using (SqlCommand cmd = new SqlCommand(
                @"INSERT INTO dbo.ChiTietPhieuXuatKho
                  (MaPXK, MaBienThe, SoLuong)
                  VALUES (@MaPXK, @MaBienThe, @SL);",
                conn,
                tran))
            {
                cmd.Parameters.AddWithValue("@MaPXK", maPXK);
                cmd.Parameters.AddWithValue("@MaBienThe", maBienThe);
                cmd.Parameters.AddWithValue("@SL", soLuong);

                return cmd.ExecuteNonQuery();
            }
        }

        private void GhiLichSuNeuCo(
            SqlConnection conn,
            SqlTransaction tran,
            int maBienThe,
            int thayDoi,
            int maTK,
            string loai)
        {
            string checkSql = @"
SELECT COUNT(*)
FROM sys.columns
WHERE object_id = OBJECT_ID(N'dbo.LichSuTonKho')
  AND name = N'Loai';";

            using (SqlCommand check = new SqlCommand(
                checkSql,
                conn,
                tran))
            {
                int coCotLoai =
                    Convert.ToInt32(check.ExecuteScalar());

                if (coCotLoai == 0)
                    return;
            }

            using (SqlCommand cmd = new SqlCommand(
                @"INSERT INTO dbo.LichSuTonKho
                  (MaBienThe, ThayDoi, Loai, MaTK, ThoiGian)
                  VALUES
                  (@MaBienThe, @ThayDoi, @Loai, @MaTK, GETDATE());",
                conn,
                tran))
            {
                cmd.Parameters.AddWithValue("@MaBienThe", maBienThe);
                cmd.Parameters.AddWithValue("@ThayDoi", thayDoi);
                cmd.Parameters.AddWithValue("@Loai", loai);
                cmd.Parameters.AddWithValue("@MaTK", maTK);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
