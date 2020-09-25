using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using BusinessLayer;
using BusinessLayer.Interfaces;

using DataLayer;
using DataLayer.Entities;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using PresentationLayer;
using PresentationLayer.Models;

using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //private EFDBContext _context;
        private DataManager _dataManager;
        private ServicesManager _servicesManager;

        public HomeController(/*EFDBContext context,*/ DataManager manager)
        {
            //_context = context;
            _dataManager = manager;
            _servicesManager = new ServicesManager(manager);
        }

        public IActionResult Index()
        {
            HelloModel _model = new HelloModel() { HelloMessage = "Hi there!" };
            //List<Directory> directories = _context.Directories.Include(x => x.Materials).ToList();
            //List<Directory> directories = _dataManager.DirectoryRepository.GetDirectories(true).ToList();
            List<DirectoryViewModel> directories = _servicesManager.DirectoryService.GetDirectoryViewModels();
            return View(directories);// (_model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
