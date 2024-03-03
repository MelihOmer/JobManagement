**Ticket - Bildirim Yönetim Sistemi**
# Kullandığım Teknolojiler

 - C# .Net Core 6 Mvc - NLayer Architecture
 - EntityFrameWork Core
 - Microsoft Identity
 - SignalR
 - Fluent Validation
 - AutoMapper
 - Sql Server
 - Toast Notification
 - Bootstrap
 - JQuery
 - Ajax

Projeyi tamamen kendim kurguladım, planladım ve geliştirdim. UI olarak hazır tema bulup projeme entegre ettim. Custom TagHelper'ler yazarak uygulamayı besledim.

# Kullanım İçeriği

**Uygulamanın Amacı** İş sürecinin başlatılması, takip edilmesi, uygulanması, çözüm süreci, ve ilgilenen personelleri takip edebildiğimiz bir otomasyon.

> Bir bildirim oluşturulur kullanıcı oluşturduğu bildirimi dashboard ekranından anlık olarak takip eder. Bildirimin oluşturulduğu birime ve birimin teknik yetkisine sahip kullanıcılar dashboardda havuzda olan bildirimi göre ve kendi üstüne atayabilir. Artık açılan bildirim bir kişi tarafından takip edilmektedir. Teknik yetkili bildirimi analize alabilir, durdurabilir, çözümleyebilir veya bir başka aynı yetkilere sahip kişiye atayabilir. Bu durumların hepsi bildirim altında oluşan hareketlerde gösterilir ve bildirimin başından sonuna kimlerin neler yaptığı izlenebilir. Birde uygulamanın eğitim modülü bulunmakta yetkili olan kullanıcılar eğitim kategorisi,eğitim ekleyebilir silebilir düzenleyebilir, eğitime döküman,resim veya video ekleyebilir. Tüm kullanıcılar eğitim ekranına erişebilirler herhangi bir Auth işlemi bulunmamaktadır. Uygulamaya SignalR desteği ekledim. Artık kullanıcı yorumlarında bildirimi oluşturan ve atanan kullanıcılara anlık olarak notify gitmekte. Ayrıca layout'a notify buttonları ekleyerek bildirimleri ajax ile çekiyorum.

## Projeyi Clonlamak için

Bilgisayarınızda Visual Studio, .Net Core 6, Sql Server olması gerekiyor. Projeyi ayağa kaldırmadan önce veritabanı migration işlemlerini yapmanız gerekmekte, appsettings.json dosyasından veritabanı yolunu belirtin daha sonra console ekranında dataAccess katmanı seçiliyken add-migration ardınden update-database demeniz yeterli. Seed datalar oluşacaktır hazır admin kullanıcısı gelecektir. 

> Kullanıcı adı : admin Şifre : 12345

ile giriş yapabilirsiniz.
## File I/O işlemleri
Uygulamada kullanıcı profil resimleri, Bildirim için eklenen dökümanlar,ekran görüntüleri ve Eğitim modülü için eklenen resim, video dosyaları wwwroot klasörü içerisinde tutulmaktadır. Bildirim için olan evrakları  GUID oluşturup kayıt ediyorum dosya adını veritabanında tutuyorum birbiri ile ilişkelindiriyorum. Bildirim detay ekranında eklenen dosyaları indirebilirisiniz dosyalar kendi isimleri ile görünecektir.

## Projeden Görseller
*Admin Dashboard*
![image](https://r.resimlink.com/BM_AOh.png)
*Standart Kullanıcı DashBoard*
![image](https://r.resimlink.com/TKQtNg1Mu7LS.png)
*Bildirim Detay Sayfası*
![image](https://r.resimlink.com/aXl53kOu.png)
*Bildirim Detay Hareketler*
![image](https://r.resimlink.com/95-RmjuMNK.png)
*Kullanıcılar Listesi (Admin)*
![image](https://r.resimlink.com/AHesSl.png)
*Kullanıcı Detay*
![image](https://r.resimlink.com/Jwe9kM.png)
*Rol Atama - Yetkilendirme*
![image](https://r.resimlink.com/wl63dFn_9.png)
*Eğitim Modülü*
![image](https://r.resimlink.com/QUiGBe.png)
*Eğitim Listesi (Admin veya Yetkili Kullanıcı)*
![image](https://r.resimlink.com/b-RsWYie2Dok.png)

> Gelişimime devam ederken görüşlerinizi, fikirlerinizi ve katkılarınızı
> beklerim.
