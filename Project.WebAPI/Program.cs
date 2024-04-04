using Project.BLL.DependencyResolvers;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args); // var builder

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddIdentityService(); // IServiceCollection i�erisine tan�mlad���m extension metotlar� �a��r�yorum
builder.Services.AddDbContextService(); // IServiceCollection i�erisine tan�mlad���m extension metotlar� �a��r�yorum
builder.Services.AddRepositoryManagerServices(); // IServiceCollection i�erisine tan�mlad���m extension metotlar� �a��r�yorum



// Session -> session da kullan�c� bilgileri tutuluyor ve her kullan�c� i�in �zel bir session vard�r

builder.Services.AddDistributedMemoryCache(); // da��t�k memory cache(yani da��t�k �nbellek). sunucu taraf�nda uygulaman�n belle�i kullan�larak bir �nbellek olu�turuluyor.
                                              // olu�turulan �nbellek yani cache sistemi sayesinde veriler daha performansl� bir �ekilde tutuluyor/eri�iliyor.
                                              // Bu i�lem ile herhangi bir t�r veri bellekte daha h�zl� bir �ekilde eri�iliyor dolay�s� ile de performans art�yor. ��nk� verilere bellek �zerinden eri�im daha h�zl�d�r.
                                              // burada uygulama bir iis sunucusunda ise uygulamay� �al��t�ran iis sunucusunun ram i yani belle�i de olabilir veya uygulamay� direkt olarak bir bilgisayar �al��t�r�yor ise o bilgisayar�n ram i yani belle�i de olabilir ve b�ylelikle verilere bellek �zerinden daha h�zl� eri�im sa�lan�r. 
                                              // kullan�c�n�n �nbelle�i yani cache'i sunucudaki belle�e yani sunucuda ba�l� oldu�u bilgisayar�n belle�ine ram ine eri�iyor.

builder.Services.AddSession(x =>
{
    x.IdleTimeout = TimeSpan.FromMinutes(2); // 2 dakika boyunca istek yap�lmaz ise sonland�r
    x.Cookie.HttpOnly = true; // oturum �erezi yaln�zca http istekleri arac�l��� ile sunucuya g�nderilsin
    x.Cookie.IsEssential = true; // oturum �erezinin zorunluluk durumu
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
