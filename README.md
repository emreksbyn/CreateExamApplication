# CreateExamApplication 
Username : admin
Password : 123

*CreateExam adında bir Blank Solution açtım.

*Onion Architecture' a uygun olarak katmanlarımı oluşturdum.

*Core katmanına Enums klasörü açtım ve kullanacağım Enum'ları tanımladım.

* Entities klasörü açtım ve projede kullanacağım entity'leri tanımladım. AppUser' a IdentityUser'dan kalıtım aldım.

* Repositories klasöründe projede kullanacağım operasyonları tanımladım.

* UnitOfWork klasöründe repository'lerimi birleştirdim. Tek seferde Commit edebilmemi sağladığım bir transaction bir alan oluşturdum.
	
* Bu katmandaki alanlarım çoğunlukla soyut olanlardı.




*Infrastructure katmanı altında Configuration klasörü açtım.

* BaseMap' te IEntityTypeConfiguration'u implemente ettim . 

	- EntityFrameworkCore.Sqlite.Core ' u projeye dahil ettim. Bu paketi indirince sqlite foreign hatası aldım bunu önlemek için SQLitePCLRqw.bundle_winsqlite3 paketini indirdim ve hata çözüldü.

	- Context klasörü altında AppDbContext sınıfı oluşturuldu. Bu sınıf IdentityDbContext ' ten kalıtım aldı. Ms.AspNetCore.Identity.EfCore paketi indirildi. OnModelCreating override edildi Configuration sınıfları dahil edildi.

	- Core katanındaki Repository'ler bu katmanda somutlaştırıldı.

	- UnitOfWork class'ına IUnitOfWork interface'sini implemente ettim ve Singleton Deseninde somutlaştırma yaptım. Burada GC çağırma işlemleri de yapılmıştır. İşimiz tamamlandıktan sonra RAM'de  boşta kalan bir object istemeyiz.

*Application katmanında Services klasörü dolduruldu. Core katmanı referans alındı(Identity için)

*Models klasöründe projede kullanacağımız Dto' lar tanımlandı.

*AutoMapper projeye eklendi Mapping class'ı Profile dan kalıtım aldı. Constructor' ında Map' leme işlemleri tanımlandı. Entity ve Dto lar birbirlerine tanıtıldı.

*ValidationRules altında FluentValidation için class'lar oluşturuldu.

*Bu class'lar AbstractValidator' dan kalıtım aldı. Classların constructor' larında kurallar konuldu.
*DependencyResolvers klasörü altında Autofac IoC Container işlemleri yapıldı. AutofacBusinessModule class' ı Module class'ından kalıtım alarak bir IoC container oldu. Load metodu override edildi.

*Presentation katmanında Program.cs class'ına Autofac 'ı ekledik.

*Startup' ta DbContext'i tanımladık.

* Migration için Infrastructure katmanına EfCore.Tools, Application katmanına EfCore.Design paketleri indirildi.

	- ConnectionString'i appsettings.json dosyasının içinde "DefaultContext" adında tanımladım.

	  services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlite(Configuration.GetConnectionString("DefaultContext"));
            });

	-Admin area oluşturuldu ve sınav oluşturma ekranı controller' ları burada tanımlandı.
	
	-Kullanıcı girişi ve sınav ekranının controller'ları Controllers klasörünün altında tanımlandı.

	
	-Helpers klasörünün içinde wired.com dan metinleri çekmek için kullanılacak Tag' ler static olarak tanımlandı.
	
	-Services' in altında wired.com' dan metinleri çekme işlemleri için çalışmalar yapıldı.
	
	-ViewComponents sınıfları ile Controller' ın iş yükünü hafiflettik. Bazı requestleri controller aracılığıyla değil doğrudan yapmamızı sağladık.
	
	-Views klasörü içindeki dosyalar uygulamamızın amacına yönelik hazırlanmaya çalışıldı.
