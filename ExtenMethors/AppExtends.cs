namespace App.Extendmethors;

public static class AppExtends
{
    public static void AddStatusCodepage(this IApplicationBuilder appError)
    {
        appError.UseStatusCodePages(appError =>
    {
    appError.Run(async context => {
        var reponse=context.Response;
        var code=reponse.StatusCode;
        
        var content=@$"
        <html>
        <head>
        <meta charset='UTF-8'/>
        <title>Lỗi: {code}</title>
        </head>
        <body>
        <p style='color:red; font-size:40px'>
        Có lỗi xảy ra: {code}-{(System.Net.HttpStatusCode)code}
        </p>
        </body>
        </html>
        ";
        await reponse.WriteAsync(content);
    }); 
    }
);//tạo trang lỗi từ 400-599
    }
}