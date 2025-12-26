using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 


namespace TeknikServisOtomasyonu
{
    public partial class FormGiris : Form
    {
        public FormGiris()
        {
            InitializeComponent();
        }

        private void FormGiris_Load(object sender, EventArgs e)
        {







































        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            // 1. Kutular boş mu kontrol et
            if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text) || string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                MessageBox.Show("Lütfen kullanıcı adı ve şifre giriniz.");
                return;
            }

            // 2. Veritabanı sorgusunu hazırla
            string sorgu = "SELECT * FROM Personel WHERE KullaniciAdi = @p1 AND Sifre = @p2";

            // 3. Parametreleri (Kutudaki verileri) hazırla
            NpgsqlParameter[] parametreler = {
                new NpgsqlParameter("@p1", txtKullaniciAdi.Text),
                new NpgsqlParameter("@p2", txtSifre.Text)
            };

            // 4. DbHelper'ı çağır ve sorguyu çalıştır
            DbHelper db = new DbHelper();
            DataTable dt = db.GetTable(sorgu, parametreler);

            // 5. Sonuç var mı? (Satır sayısı 0'dan büyükse kullanıcı doğrudur)
            if (dt.Rows.Count > 0)
            {
                // Giriş Başarılı!
                string rol = dt.Rows[0]["Rol"].ToString(); // Kullanıcının rolünü al (Yönetici/Teknisyen)
                string adSoyad = dt.Rows[0]["AdSoyad"].ToString();

                MessageBox.Show("Hoşgeldiniz " + adSoyad);

                // Ana Menüyü aç (Bir sonraki adımda oluşturacağız, şimdilik Form1 açalım)
                Form1 anaMenu = new Form1();
                anaMenu.Show();
                this.Hide(); // Giriş ekranını gizle
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre!");
            }
        
    }
    }
}
