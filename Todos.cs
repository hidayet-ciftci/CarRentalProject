using System;

public class Class1
{
    // sıfırdan proje ++ 
    // token , refresh token ++
    // role bazlı metod'a ulasma ++
    // erisim hakkın yok uyarısı ++
    // migration yok , elle girilecek ++
    // veritabani check, unique constraint koyulacak ++ 
    // microsoft kutuphanesi ile IoC ++
    // join ile veri cekilecek , DTO ++
    // fluent validation  ++
    // N-tier arch ile projeyi kur ++


    // sorulacak sorular : -> Hem check hem fluent_validation ikisi de mi kullanilir ? -> evet check + check
    // AOP eksiklikleri ? farklı mı kullanacağız ? -> cache ? transaction ? AOP farklı bir kullanım tarzı o kadar da sart degil
    // aynı araç state tamamlandi olmadan ekleme durumu best practice ? -> backend daha pratik,

    // iş kurallari ++
    // IoC ++
    // crud ve business islemleri okey olsun. proje check et sonra auth'a gec ++
    // Auth ++
    // check constraint ve veriler elle girilecek. ++

    // Bittenler -------------------------------------

    // Salt ++
    // database View ++ -> Joinler için oluşmuş tablo'yu DTO kullanarak yansıtmak.
    // cronjob ++ -> * * * * * metodu kullanarak server'a zamanlı iş yaptırma
    // Hangfire ++ -> veya quartz.net cronJOB ASP.NET taraflı kullanmak
    // trigger ++ -> SQL Server'a yaz ya da savechanges'i override et.
    // ILogger -> private readonly ILogger<UrunController> _logger;
    // Dependency Injection ile gelir -> UrunController tip 'Den ziyade nereden geldigini belirtmek için kullanilir.
    // Task -> Asenkron yapılar için await ile birlikte kullanılır.
    // Lock -> Multi-Thread işlemlerin birbirlerini engellemek , aynı anda tek bir işlemin gerçekleşmesini saglar.
    // middleware  -> işlemler arası geçiş. Middleware = pipeline’daki işlem birimi
    // pipeline ++ -> Projedeki Akış 
    // MVC ++ -> MVC yapısı Model - View - Controller yapısı ile küçük projelerde işe yarayan
    // direkt istek karşısında html dönen yapı
    // cacheing, transaction ? AOP ? gerekliliği ? ++ -> AOP olmadan , Kodu generic yapıda , service olarak yazıp kullanırız.
    // her business func'i için tekrar yazmak gerekir.

    // rabbitMQ loglama sistemi - rebus , redis ,gencay
    // CQRS - gencay
    // Redis ile cache ?

    // expo 
}
