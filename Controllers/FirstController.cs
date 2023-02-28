using Microsoft.AspNetCore.Mvc;
using System.IO;
using App.Sevice;
using App.Models;

namespace App.Controllers
{

    public class FirstController: Controller
    {
        
        private readonly ILogger<FirstController> _logger;
        private readonly ProductSevice _productSevice;
        public FirstController(ILogger<FirstController> logger, ProductSevice procductSevice)
        {
            _logger = logger;
            _productSevice=procductSevice;
        } 
        //this.HttpContext;
        //this.HttpRequest;
        //this.HttpResponse;
        //this.RouteData;
        //ngoài ra là các thuộc tính như sử dụng pagemodel
        // this.user
        // this.url

        
        public string Index()
        {
            //LogLevel có 6 cấp độ để theo dõi ứng dụng
            //ví dụ như:
            // _logger.LogWarning("thông báo");
            // _logger.LogError("thông báo");
            // _logger.LogInformation("thông báo");
            // _logger.LogDebug("thông báo");
            // _logger.LogTrace("thông báo");
            // _logger.LogCritical("thông báo");
            //ngoài ra có thể đăng ký các dịch vụ thay thế ví dụ như serilog,...
            //_logger.LogInformation("action index");
            return "tôi là index của first";
        }
        //các action có thể trả về bất cứ kiểu dữ liệu nào, nó sẽ được convert thành
        //chuỗi để trả về cho client
        public void Nothing(){
            _logger.LogInformation("notthing action");
            Response.Headers.Add("hi", "xin chao cac ban");
        }
        public object Anything(){
            return DateTime.Now;//ở đây đã được convert thành chuỗi chuyển về 
            //giao diện cho client
            //tuy nhiên các đối tượng trả về từ action thường là các đối tượng
            //được triển khai từ IactionResult
        }
        public IActionResult Readme()
        {
            string rs=@"
            xin chào các bạn
            chúng ta đang học aspnet mvc


            trung nguyen
            ";
            return this.Content(rs, "text/html");
            //sẽ được thư viện chuyển nội dung rs thành response trả về
        }
        // public IActionResult logo()
        // {
        public IActionResult logo(){
            string path=@"E:\C SHARP\AppMvc.Net\Files\logoMu.jpg";
            var bytes= System.IO.File.ReadAllBytes(path);
            return File(bytes, "image/jpg");
        }

        public IActionResult product()
        {
            var product= new {
                name="samsung",
                Model="14 pro max",
                price=1500
            };
            return Json(product);
        }


        public IActionResult goole()
        {
            return Redirect("https://www.google.gg/");
        }
        // }
        
    //     Kiểu trả về                 | Phương thức
    // ------------------------------------------------
    // ContentResult               | Content()
    // EmptyResult                 | new EmptyResult() tương đương trả về void
    // FileResult                  | File()
    // ForbidResult                | Forbid()
    // JsonResult                  | Json()
    // LocalRedirectResult         | LocalRedirect()
    // RedirectResult              | Redirect()
    // RedirectToActionResult      | RedirectToAction()
    // RedirectToPageResult        | RedirectToRoute()
    // RedirectToRouteResult       | RedirectToPage()

    // PartialViewResult           | PartialView() đã có trong phần razor page
    // ViewComponentResult         | ViewComponent() đã có trong phần razor page
    // StatusCodeResult            | StatusCode()
    // ViewResult                  | View() => phương thức quan trọng nhất

        public IActionResult helloview(string user)
        {
            //view sử dụng razor engineer để đọc file .cshtml(temple) 
            //trả về nội dung cho client
            //mặc định sẽ vào phần "View/controller/action" ~ đường dẫn trong view
            // return View();
            // return View(@"Views\first\view1.cshtml");
            //~ trong phương thức view có thể truyền 2 tham số(tham số 1 là đường 
            //  dẫn tuyệt đối, tham số thứ 2 là model)
            //các cách truyền dữ liệu sang view:
            //_model, viewdata,viewbag , temdata. 
            // user ="khach";
            return View("xinchao2");//Myviews/First/xinchao2 ~ Myviews/controller/action
        }
        public IActionResult viewproduct(int ? id)//id được bingding đến thông qua url
        {
            //ProductModel _product;
            var product = _productSevice.Where(p=>p.id==id).FirstOrDefault();
            if(product == null){
                TempData["error"]="sản phẩm không tồn tại!";
                return Redirect( "/home/index");
            }
            // return View(product);
            // this.ViewData["product"]=product;
            // this.ViewData["Title"]=product.name;

            this.ViewBag.product=product;
            return View();
        }

    }
}