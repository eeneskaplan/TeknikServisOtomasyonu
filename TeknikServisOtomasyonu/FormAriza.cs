using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace TeknikServisOtomasyonu
{
    public partial class FormAriza : Form
    {
        public FormAriza()
        {
            InitializeComponent();
        }

        private void FormAriza_Load(object sender, EventArgs e)
        {
            MusterileriGetir();
        }

        
        void MusterileriGetir()
        {
            DbHelper db = new DbHelper();
            DataTable dt = db.GetTable("SELECT MusteriID, AdSoyad FROM Musteriler");

            cmbMusteri.DataSource = dt;
            
            cmbMusteri.DisplayMember = "adsoyad";
            cmbMusteri.ValueMember = "musteriid";
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            
            if (cmbMusteri.SelectedValue == null)
            {
                MessageBox.Show("Lütfen bir müşteri seçin.");
                return;
            }

            string cihazSql = "INSERT INTO Cihazlar (MusteriID, Marka, Model, SeriNo) VALUES (@p1, @p2, @p3, @p4) RETURNING CihazID";

            int secilenMusteriID = Convert.ToInt32(cmbMusteri.SelectedValue);

            NpgsqlParameter[] pCihaz = {
                new NpgsqlParameter("@p1", secilenMusteriID),
                new NpgsqlParameter("@p2", txtMarka.Text),
                new NpgsqlParameter("@p3", txtModel.Text),
                new NpgsqlParameter("@p4", txtSeriNo.Text)
            };

            DbHelper db = new DbHelper();
            
            DataTable dtCihaz = db.GetTable(cihazSql, pCihaz);
            int yeniCihazID = Convert.ToInt32(dtCihaz.Rows[0][0]);

            
            string arizaSql = "INSERT INTO ArizaKayitlari (CihazID, PersonelID, AnlikDurum) VALUES (@p1, 1, 'Bekliyor')";

            NpgsqlParameter[] pAriza = {
                new NpgsqlParameter("@p1", yeniCihazID)
            };

            db.ExecuteQuery(arizaSql, pAriza);

            MessageBox.Show("Cihaz kabul edildi ve arıza kaydı açıldı! \nCihaz ID: " + yeniCihazID);
            this.Close(); 
        }
    }
}