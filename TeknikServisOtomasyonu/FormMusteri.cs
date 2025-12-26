using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace TeknikServisOtomasyonu
{
    public partial class FormMusteri : Form
    {
        public FormMusteri()
        {
            InitializeComponent();
            Listele();
        }

  
        private void FormMusteri_Load(object sender, EventArgs e)
        {
            Listele();
        }

        
        void Listele()
        {
            string sorgu = "SELECT * FROM Musteriler ORDER BY MusteriID DESC"; 
            DbHelper db = new DbHelper();
            DataTable dt = db.GetTable(sorgu);
            dgvMusteriler.DataSource = dt;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string sorgu = "INSERT INTO Musteriler (AdSoyad, Telefon, Adres) VALUES (@p1, @p2, @p3)";
            NpgsqlParameter[] p = {
                new NpgsqlParameter("@p1", txtAdSoyad.Text),
                new NpgsqlParameter("@p2", txtTelefon.Text),
                new NpgsqlParameter("@p3", txtAdres.Text)
            };

            DbHelper db = new DbHelper();
            db.ExecuteQuery(sorgu, p);

            MessageBox.Show("Müşteri Eklendi!");
            Listele(); 
            Temizle();
        }

       
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (lblID.Text == "-" || string.IsNullOrEmpty(lblID.Text))
            {
                MessageBox.Show("Lütfen listeden silinecek müşteriyi seçin.");
                return;
            }

            string sorgu = "DELETE FROM Musteriler WHERE MusteriID = @p1";
            NpgsqlParameter[] p = { new NpgsqlParameter("@p1", int.Parse(lblID.Text)) };

            DbHelper db = new DbHelper();
            db.ExecuteQuery(sorgu, p);

            MessageBox.Show("Müşteri Silindi!");
            Listele();
            Temizle();
        }

        
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (lblID.Text == "-" || string.IsNullOrEmpty(lblID.Text))
            {
                MessageBox.Show("Lütfen listeden güncellenecek müşteriyi seçin.");
                return;
            }

            string sorgu = "UPDATE Musteriler SET AdSoyad=@p1, Telefon=@p2, Adres=@p3 WHERE MusteriID=@p4";
            NpgsqlParameter[] p = {
                new NpgsqlParameter("@p1", txtAdSoyad.Text),
                new NpgsqlParameter("@p2", txtTelefon.Text),
                new NpgsqlParameter("@p3", txtAdres.Text),
                new NpgsqlParameter("@p4", int.Parse(lblID.Text))
            };

            DbHelper db = new DbHelper();
            db.ExecuteQuery(sorgu, p);

            MessageBox.Show("Müşteri Bilgileri Güncellendi!");
            Listele();
            Temizle();
        }

       
        private void dgvMusteriler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                
                DataGridViewRow row = dgvMusteriler.Rows[e.RowIndex];

                
                lblID.Text = row.Cells["MusteriID"].Value.ToString();
                txtAdSoyad.Text = row.Cells["AdSoyad"].Value.ToString();
                txtTelefon.Text = row.Cells["Telefon"].Value.ToString();
                txtAdres.Text = row.Cells["Adres"].Value.ToString();
            }
        }

        
        void Temizle()
        {
            txtAdSoyad.Text = "";
            txtTelefon.Text = "";
            txtAdres.Text = "";
            lblID.Text = "-";
        }

        private void FormMusteri_Load_1(object sender, EventArgs e)
        {

        }
    }
}