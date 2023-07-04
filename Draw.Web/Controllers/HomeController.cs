using Draw.Business.DependencyResolvers.Ninject;
using Draw.Core.Business.Abstract;
using Draw.Web.Mapper;
using Draw.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Draw.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IMainTitleService _mainTitleService;
        private IEnumerable<MainTitle> _maintTitles;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _mainTitleService=BusinessInstanceFactory.GetInstance<IMainTitleService>();
            var mainTitles = _mainTitleService.GetAllWithBaseTitleAsync().Result;
            _maintTitles = WebObjectMapper.Mapper.Map<IEnumerable<MainTitle>>(mainTitles.data.ToList());
        }

        public IActionResult Index()
        {
            return View(new TitleListViewModel { MainTitles= _maintTitles.Where(x=>x.IndexId==0).ToList() ,url="home"});
        }
        public IActionResult DrawCAD()
        {
            return View(new TitleListViewModel {  MainTitles = _maintTitles.Where(x => x.IndexId == 1).ToList(), url = "cad" });
        }

        public IActionResult DrawApi()
        {
            return View(new TitleListViewModel { MainTitles = _maintTitles.Where(x => x.IndexId == 2).ToList(), url = "api" });
        }

        public IActionResult DrawGeo()
        {
            return View(new TitleListViewModel { MainTitles = _maintTitles.Where(x => x.IndexId == 3).ToList(), url = "geo" });
        }
        public IActionResult DrawAuth()
        {
            return View(new TitleListViewModel { MainTitles = _maintTitles.Where(x => x.IndexId == 4).ToList(), url = "auth" });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}