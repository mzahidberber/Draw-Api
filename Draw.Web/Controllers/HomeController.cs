using Draw.Business.DependencyResolvers.Ninject;
using Draw.Core.Business.Abstract;
using Draw.Core.DTOs.Concrete;
using Draw.Web.Mapper;
using Draw.Web.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using System.Diagnostics;

namespace Draw.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        private IMainTitleService _mainTitleService;
        
        private IEnumerable<MainTitle> _maintTitles;
        private ViewResult? _index { get; set; }=null;
        private ViewResult? _cad { get; set; } = null;
        private ViewResult? _api { get; set; } = null;
        private ViewResult? _geo { get; set; } = null;
        private ViewResult? _auth { get; set; } = null;
        
        private IWebHostEnvironment _hostingEnvironment;

        public INumbersService _numberService { get; set; }
        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _mainTitleService=BusinessInstanceFactory.GetInstance<IMainTitleService>();
            var mainTitles = _mainTitleService.GetAllWithBaseTitleAsync().Result;
            _maintTitles = WebObjectMapper.Mapper.Map<IEnumerable<MainTitle>>(mainTitles.data.ToList());
            
            _hostingEnvironment = webHostEnvironment;

        }

        //public IActionResult DownloadExe()
        //{
        //    string filePath = Path.Combine(Environment.GetEnvironmentVariable("rarPath"));
        //    string fileName = "DrawCAD.rar";
        //    AddDownloadNumber();
        //    return PhysicalFile(filePath, "application/octet-stream", fileName);
        //}
        public void AddClickNumber()
        {
            _numberService = BusinessInstanceFactory.GetInstance<INumbersService>();
            var number = _numberService.GetAsync(1).Result.data;
            number.ClickNumber++;
            _numberService = BusinessInstanceFactory.GetInstance<INumbersService>();
            _numberService.UpdateAllAsync(new List<NumbersDTO> {number}) ;
        }
        public void AddDownloadNumber()
        {
            _numberService = BusinessInstanceFactory.GetInstance<INumbersService>();
            var number = _numberService.GetAsync(1).Result.data;
            number.DownloadNumber++;
            _numberService = BusinessInstanceFactory.GetInstance<INumbersService>();
            _numberService.UpdateAllAsync(new List<NumbersDTO> { number });
        }
        public IActionResult Index()
        {
            AddClickNumber();
            if (_index == null)
                _index= View(new TitleListViewModel { MainTitles = _maintTitles.Where(x => x.IndexId == 0).ToList(), url = "home" });
            return _index;
        }
        public IActionResult DrawCAD()
        {
            if (_cad == null)
                _cad=View(new TitleListViewModel { MainTitles = _maintTitles.Where(x => x.IndexId == 1).ToList(), url = "cad" });
            return _cad;
        }

        public IActionResult DrawApi()
        {
            if (_api == null)
                _api= View(new TitleListViewModel { MainTitles = _maintTitles.Where(x => x.IndexId == 2).ToList(), url = "api" });
            return _api;
        }

        public IActionResult DrawGeo()
        {
            if (_geo == null)
                _geo = View(new TitleListViewModel { MainTitles = _maintTitles.Where(x => x.IndexId == 3).ToList(), url = "geo" });
            return _geo;
        }
        public IActionResult DrawAuth()
        {
            if (_auth == null)
                _auth = View(new TitleListViewModel { MainTitles = _maintTitles.Where(x => x.IndexId == 4).ToList(), url = "auth" });
            return _auth;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}