using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();





builder.Services.AddDbContext<Context>();                   //�DENT�TY K�T�PHANES� ���N EKLEND�



builder.Services.AddIdentity<AppUser, AppRole>(x=>
{
    x.Password.RequireUppercase = false;                    //�DENT�TYDE �STEMED���M�Z KURALLARI FALSE YAPMAK
    x.Password.RequireNonAlphanumeric = false;              //�DENT�TYDE �STEMED���M�Z KURALLARI FALSE YAPMAK
})
    .AddEntityFrameworkStores<Context>();    






builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)    // �erez Tabanl� Kimlik Do�rulama
    .AddCookie(options =>
    {
        options.Cookie.Name = "deneme";
        options.LoginPath = "/Login/index";                                             //cookie bulunamazsa buraya gider
        options.AccessDeniedPath = "login/index";                                         //yetkisiz kullan�c�lar buraya gider
    });


builder.Services.AddSession();


var app = builder.Build();

// HTTP iste�i pipeline'�n� yap�land�r.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1", "?code={0}");

app.UseHttpsRedirection();


app.UseRouting();

app.UseSession();

app.UseStaticFiles();

app.UseAuthentication();  

app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(                                     //AREAS ROUTE tan�m�
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Category}/{action=Index}/{id?}"
    );

    endpoints.MapControllerRoute(                                        //AREAS ROUTE tan�m�
        name: "area",
        pattern: "{area:exists}/{controller}/{action}/{id?}"
    );

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
});



app.Run();
