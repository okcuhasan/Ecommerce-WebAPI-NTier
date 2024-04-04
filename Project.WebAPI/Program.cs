using Project.BLL.DependencyResolvers;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args); // var builder

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddIdentityService(); // IServiceCollection içerisine tanýmladýðým extension metotlarý çaðýrýyorum
builder.Services.AddDbContextService(); // IServiceCollection içerisine tanýmladýðým extension metotlarý çaðýrýyorum
builder.Services.AddRepositoryManagerServices(); // IServiceCollection içerisine tanýmladýðým extension metotlarý çaðýrýyorum



// Session -> session da kullanýcý bilgileri tutuluyor ve her kullanýcý için özel bir session vardýr

builder.Services.AddDistributedMemoryCache(); // daðýtýk memory cache(yani daðýtýk önbellek). sunucu tarafýnda uygulamanýn belleði kullanýlarak bir önbellek oluþturuluyor.
                                              // oluþturulan önbellek yani cache sistemi sayesinde veriler daha performanslý bir þekilde tutuluyor/eriþiliyor.
                                              // Bu iþlem ile herhangi bir tür veri bellekte daha hýzlý bir þekilde eriþiliyor dolayýsý ile de performans artýyor. Çünkü verilere bellek üzerinden eriþim daha hýzlýdýr.
                                              // burada uygulama bir iis sunucusunda ise uygulamayý çalýþtýran iis sunucusunun ram i yani belleði de olabilir veya uygulamayý direkt olarak bir bilgisayar çalýþtýrýyor ise o bilgisayarýn ram i yani belleði de olabilir ve böylelikle verilere bellek üzerinden daha hýzlý eriþim saðlanýr. 
                                              // kullanýcýnýn önbelleði yani cache'i sunucudaki belleðe yani sunucuda baðlý olduðu bilgisayarýn belleðine ram ine eriþiyor.

builder.Services.AddSession(x =>
{
    x.IdleTimeout = TimeSpan.FromMinutes(2); // 2 dakika boyunca istek yapýlmaz ise sonlandýr
    x.Cookie.HttpOnly = true; // oturum çerezi yalnýzca http istekleri aracýlýðý ile sunucuya gönderilsin
    x.Cookie.IsEssential = true; // oturum çerezinin zorunluluk durumu
});




WebApplication app = builder.Build(); // var app

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseAuthentication();

app.UseSession();

app.MapControllers();

app.Run();
