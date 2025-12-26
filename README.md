# TeknikServisOtomasyonu
Teknik Servis Takip Otomasyonu

Bu proje, teknik servis işletmelerinin müşteri, cihaz ve arıza takiplerini dijital ortamda yönetmelerini sağlayan kapsamlı bir C# Windows Forms otomasyonudur. Veritabanı olarak PostgreSQL kullanılmış olup, Trigger ve Stored Procedure gibi ileri seviye veritabanı mimarileriyle desteklenmiştir.

Özellikler

Kullanıcı Girişi: Admin/Personel girişi ile güvenli erişim.

Müşteri Yönetimi: Müşteri ekleme, silme, güncelleme ve listeleme işlemleri.

Cihaz ve Arıza Kaydı: Müşteriye ait cihazın marka/model bilgileriyle sisteme kaydedilmesi ve arıza fişi oluşturulması.

Teknik Servis Paneli: Teknisyenlerin yapılan işlemleri, parça ve işçilik ücretlerini girdiği detaylı panel.

Otomatik Durum Güncelleme (Trigger): Cihaza bir işlem girildiğinde, cihazın durumu "Bekliyor"dan "İşlemde"ye PostgreSQL Trigger ile otomatik güncellenir.

Borç Hesaplama (Stored Procedure): Parça ve işçilik ücretleri girildiğinde toplam tutarı hesaplayan Stored Procedure entegrasyonu.

Modern Arayüz: Kullanıcı dostu, panel tabanlı (Single Page Application hissi veren) modern tasarım.

Teknolojiler ve Araçlar

Dil: C# (.NET Framework)

Platform: Windows Forms (WinForms)

Veritabanı: PostgreSQL

ORM/Kütüphane: Npgsql (Data Provider for PostgreSQL)

IDE: Visual Studio 2022

Ana Menü Kurulum ve Çalıştırma

Projeyi kendi bilgisayarınızda çalıştırmak için aşağıdaki adımları izleyin:

Projeyi Klonlayın: Bash

git clone https://github.com/kullaniciadi/TeknikServisOtomasyonu.git

Veritabanını Kurun:

Bilgisayarınızda PostgreSQL ve pgAdmin kurulu olmalıdır.

Database klasörü içindeki (veya proje ana dizinindeki) .sql dosyasını pgAdmin üzerinden Restore edin veya SQL kodlarını çalıştırarak tabloları oluşturun.

Bağlantı Ayarları:

Visual Studio'da projeyi açın.

DbHelper.cs dosyasını bulun.

connectionString satırındaki Password kısmını kendi PostgreSQL şifrenizle güncelleyin.

Çalıştırın:

Projeyi derleyin ve başlatın (F5).

Veritabanı Mimarisi

Proje, ilişkisel veritabanı yapısına (Relational Database) uygun olarak tasarlanmıştır.

Tablolar: Musteriler, Cihazlar, ArizaKayitlari, IslemDetaylari

Trigger: trg_DurumGuncelle (İşlem girilince durumu günceller)

Stored Procedure: sp_BorcHesapla (Toplam servis ücretini hesaplar)

Lisans

Bu proje açık kaynaklıdır ve eğitim amaçlı geliştirilmiştir.
