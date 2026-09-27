# bakanlik-oturum-takibi
Stajımda yaptığım kurum içerisindeki bilgisayarların oturum zamanlarını takip etmek için yazdığım scriptler.
# Bakanlık Oturum Takibi

Bu proje, kurum içerisindeki bilgisayarların oturum açma (login) ve kapatma sürelerini takip etmek amacıyla geliştirilmiş bir log takip otomasyonudur. 

## Proje Hakkında
Sistem, bilgisayarların açılış ve kapanışında otomatik olarak çalışan **PowerShell** scriptleri ve bu scriptlerden gelen log verilerini okuyup kullanıcı dostu bir arayüzde gösteren bir **C# Windows Forms** uygulamasından oluşmaktadır.

##  Kullanılan Teknolojiler
* **C# / Windows Forms:** Log verilerini görüntülemek ve yönetmek için masaüstü arayüzü.
* **PowerShell:** Oturum açılış ve kapanış saatlerini tespit edip log dosyası oluşturan scriptler.
* **.NET Framework:** Uygulama altyapısı.

##  Nasıl Çalışır?
1. Bilgisayar açıldığında veya oturum kapatıldığında arka planda PowerShell scriptleri tetiklenir.
2. Bu scriptler, işlem saatini ve kullanıcı bilgisini belirli bir formata dönüştürerek metin (log) dosyalarına kaydeder.
3. C# Windows Forms uygulaması, bu log dosyalarını düzenli olarak okur ve bir tablo içerisinde yöneticinin görebileceği şekilde listeler.

