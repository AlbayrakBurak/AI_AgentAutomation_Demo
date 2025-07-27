# AI Agent Process Automation Demo

Bu proje, müşteri taleplerini **makine öğrenmesi (ML.NET)** ile sınıflandıran ve bu sınıflandırmaya göre otomatik yanıt öneren basit bir uygulamadır.  
WPF arayüzü üzerinden kullanıcıların talepleri alınır, eğitimli model sayesinde metinler kategorilere ayrılır ve ilgili cevaplar ekranda gösterilir.

## Projenin AI Bölümü Hakkında

- Projede kullanılan yapay zeka, Microsoft’un **ML.NET** kütüphanesi ile geliştirilmiş bir **metin sınıflandırma modeli**dir.  
- Model, örnek müşteri taleplerinden oluşan veri setiyle eğitilir (train edilir). Bu işlem modelin hangi metnin hangi kategoriye ait olduğunu öğrenmesini sağlar.  
- Kullanıcıdan gelen yeni metinler modele verilir ve model, metni öğrendiği kategorilerden birine atar (predict eder).  
- Bu süreç, yapay zekanın temel mantığı olan “veriyle öğrenme ve tahmin etme” prensibine dayanır.  
- Böylece gelen talepler otomatik olarak sınıflandırılır ve sürecin otomasyonuna temel oluşturur.

## Özellikler

- Dört ana müşteri talebi kategorisi: Fatura/Ödeme, Teknik Destek, Abonelik İşlemleri, Genel  
- Yerel (offline) ML.NET modeli ile metin sınıflandırma  
- Kullanıcı dostu WPF arayüzü ile kolay kullanım  
- AI destekli süreç otomasyonuna giriş için demo uygulaması

## Kurulum ve Çalıştırma

1. Projeyi klonlayın veya indirin.  
2. Visual Studio’da açın.  
3. `customer_requests.csv` dosyasının proje dizininde olduğundan emin olun.  
4. Gerekli NuGet paketlerini yükleyin (`Microsoft.ML` vb.).  
5. Projeyi derleyin ve çalıştırın.

## Kullanım

- Ana ekranda müşteri talebinizi yazın.  
- "İşle" butonuna basın.  
- Sistem talebinizi sınıflandırıp, kategoriye göre önerilen cevabı gösterir.

## Lisans

MIT License

---

Bu demo, AI destekli süreç otomasyonunun temel mantığını göstermek için hazırlanmıştır.
