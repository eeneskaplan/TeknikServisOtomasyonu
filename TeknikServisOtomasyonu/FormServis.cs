using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace TeknikServisOtomasyonu
{
    public partial class FormServis : Form
    {
        public FormServis()
        {
            InitializeComponent();
            
        }

        private void FormServis_Load(object sender, EventArgs e)
        {
            Listele();
        }

        
        
        void Listele()
        {
            string sorgu = @"
                SELECT 
                    A.ArizaID, 
                    M.AdSoyad, 
                    C.Marka || ' ' || C.Model AS Cihaz, 
                    A.AnlikDurum, 
                    A.GirisTarihi 
                FROM ArizaKayitlari A
                INNER JOIN Cihazlar C ON A.CihazID = C.CihazID
                INNER JOIN Musteriler M ON C.MusteriID = M.MusteriID
                ORDER BY A.ArizaID DESC";

            DbHelper db = new DbHelper();
            DataTable dt = db.GetTable(sorgu);
            dgvArizalar.DataSource = dt;
        }


        private void dgvArizalar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                lblArizaID.Text = dgvArizalar.Rows[e.RowIndex].Cells["ArizaID"].Value.ToString();
            }
        }

       
        private void btnIslemEkle_Click(object sender, EventArgs e)
        {
            if (lblArizaID.Text == "-") { MessageBox.Show("Listeden kayıt seçin!"); return; }

            
            string sql = "INSERT INTO IslemDetaylari (ArizaID, YapilanIslem, ParcaUcreti, IscilikUcreti) VALUES (@p1, @p2, @p3, @p4)";

            decimal parca = string.IsNullOrEmpty(txtParca.Text) ? 0 : Convert.ToDecimal(txtParca.Text);
            decimal iscilik = string.IsNullOrEmpty(txtIscilik.Text) ? 0 : Convert.ToDecimal(txtIscilik.Text);

            NpgsqlParameter[] p = {
                new NpgsqlParameter("@p1", int.Parse(lblArizaID.Text)),
                new NpgsqlParameter("@p2", txtIslem.Text),
                new NpgsqlParameter("@p3", parca),
                new NpgsqlParameter("@p4", iscilik)
            };

            DbHelper db = new DbHelper();
            db.ExecuteQuery(sql, p);

            MessageBox.Show("İşlem Eklendi!");
            Listele(); 
            Temizle();
        }

        
        private void btnHesapla_Click(object sender, EventArgs e)
        {
            if (lblArizaID.Text == "-") { MessageBox.Show("Listeden kayıt seçin!"); return; }

            
            string sql = "CALL sp_BorcHesapla(@p1, @p2)";

            NpgsqlParameter p2 = new NpgsqlParameter("@p2", NpgsqlTypes.NpgsqlDbType.Numeric);
            p2.Direction = ParameterDirection.InputOutput;
            p2.Value = 0;

            NpgsqlParameter[] p = {
                new NpgsqlParameter("@p1", int.Parse(lblArizaID.Text)),
                p2
            };

            DbHelper db = new DbHelper();
            db.ExecuteQuery(sql, p);

            MessageBox.Show("Toplam Tutar : " + p2.Value.ToString() + " TL");
        }

        private void btnBitir_Click(object sender, EventArgs e)
        {
            if (lblArizaID.Text == "-") return;

            string sql = "UPDATE ArizaKayitlari SET AnlikDurum='Tamamlandı' WHERE ArizaID=@p1";
            NpgsqlParameter[] p = { new NpgsqlParameter("@p1", int.Parse(lblArizaID.Text)) };

            DbHelper db = new DbHelper();
            db.ExecuteQuery(sql, p);

            MessageBox.Show("Cihaz servisten çıktı. Durum: Tamamlandı.");
            Listele();
        }

        void Temizle()
        {
            txtIslem.Text = ""; txtParca.Text = "0"; txtIscilik.Text = "0";
        }

        private void dgvArizalar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}