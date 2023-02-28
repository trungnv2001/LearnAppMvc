using App.Sevice;
using  Microsoft.AspNetCore.Mvc.Razor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.Configure<RazorViewEngineOptions>(option => {
    //{0}-ten action {1}-ten controller -{2}-ten area

    option.ViewLocationFormats.Add("Myviews/{1}/{0}"+RazorViewEngine.ViewExtension);
});

builder.Services.AddTransient<ProductSevice>();
//mặc định đã được đăng ký logger, có thể thay thế bằng các dịnh vụ khác ví dụ như serilog,..
// builder.Services.AddTransient(typeof(ILogger<>), typeof(ILogger<>));
var app = builder.Build();
var env=app.Environment;

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();//xác thực danh tính
app.UseAuthorization();//xác thực quyền truy cập


//đoạn code bên dưới tạo ra 1 cái root có tên là default
//khi truy cập vào địa chỉ url = home/index thì sẽ khởi tạo một đối tượng
// có tên là home, chính là lớp Home có hậu tố là controller 
//và rồi thực hiện phương thức index. 
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
