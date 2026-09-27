using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace BakanlikOturumTakibi
{
    public partial class Form1 : Form
    {
        // PowerShell scriptlerinin .txt dosyalarýný oluþturduðu ortak að klasörü yolu.
        // Kendi sisteminize/aðýnýza göre bu yolu güncelleyin.
        private readonly string _ortakKlasorYolu = @"C:\OrtakAgKlasoru";

        // Verileri tutacaðýmýz sanal tablo nesnesi
        private DataTable _oturumTablosu;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Form açýldýðýnda önce tablo iskeletini kuruyoruz
            TabloyuHazirla();
            // Ardýndan klasörü okuyup ilk verileri çekiyoruz
            VerileriGuncelle();
        }

        private void TabloyuHazirla()
        {
            _oturumTablosu = new DataTable();

            // Tablo sütunlarýný eksiksiz tanýmlýyoruz
            _oturumTablosu.Columns.Add("Bilgisayar Adý", typeof(string));
            _oturumTablosu.Columns.Add("Kullanýcý Adý / Sicil", typeof(string));
            _oturumTablosu.Columns.Add("Giriþ Zamaný", typeof(string));

            // Sanal tabloyu, ekrandaki DataGridView'a baðlýyoruz
            gridOturumlar.DataSource = _oturumTablosu;

            // Görsel iyileþtirmeler: Sütunlar ekraný kaplasýn, kullanýcý satýr ekleyemesin
            gridOturumlar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridOturumlar.AllowUserToAddRows = false;
            gridOturumlar.ReadOnly = true;
            gridOturumlar.RowHeadersVisible = false;
        }

        private void VerileriGuncelle()
        {
            // Ortak klasör o an ulaþýlamaz durumdaysa programýn çökmesini engelliyoruz
            if (Directory.Exists(_ortakKlasorYolu) == false)
            {
                return;
            }

            // Önceki verileri temizliyoruz ki üst üste binmesin
            _oturumTablosu.Rows.Clear();

            // Sadece .txt uzantýlý dosyalarý alýyoruz
            string[] dosyalar = Directory.GetFiles(_ortakKlasorYolu, "*.txt");

            foreach (string dosyaYolu in dosyalar)
            {
                try
                {
                    // Dosyanýn adý = Bilgisayar Adý (LogonScript.ps1 bu þekilde kaydedecek)
                    string bilgisayarAdi = Path.GetFileNameWithoutExtension(dosyaYolu);

                    // Dosyanýn içindeki metin = Kullanýcý Adý / Sicil
                    string kullaniciAdi = File.ReadAllText(dosyaYolu).Trim();

                  
                    // Dosyanýn son deðiþtirilme tarihi = Giriþ Zamaný
                    string girisZamani = File.GetLastWriteTime(dosyaYolu).ToString("g");

                    // Elde edilen verileri tabloya yeni bir satýr olarak ekliyoruz
                    _oturumTablosu.Rows.Add(bilgisayarAdi, kullaniciAdi, girisZamani);
                }
                catch (Exception)
                {
                    // Eðer .txt dosyasý tam o milisaniyede siliniyor veya yazýlýyorsa hata vermemesi için
                    // Exception bloðunu boþ geçiyoruz, bir sonraki döngüde toparlayacaktýr.
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Her 10 saniyede bir bu metot çalýþýp tabloyu tazeleyecek
            VerileriGuncelle();
        }

        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            // Arama kutusuna yazý yazýldýkça DataGridView'i anlýk filtreliyoruz
            if (_oturumTablosu != null)
            {
                string arananKelimeler = txtArama.Text.Trim();
                // SQL yapýsýna uygun filtreleme (Bilgisayar adýna veya kullanýcý adýna göre arama)
                _oturumTablosu.DefaultView.RowFilter = string.Format("[Bilgisayar Adý] LIKE '%{0}%' OR [Kullanýcý Adý / Sicil] LIKE '%{0}%'", arananKelimeler);
            }
        }

        // Tasarým ekranýnda yanlýþlýkla týkladýðýn için oluþan boþ olay bloðu
        private void gridOturumlar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}