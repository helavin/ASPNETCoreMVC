using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BusinessLayer;

using Microsoft.AspNetCore.Mvc;

using PresentationLayer;
using PresentationLayer.Models;

using static DataLayer.Enums.PageEnums;

namespace WebApplication1.Controllers
{
    public class PageController : Controller
    {
        private DataManager _dataManager;
        private ServicesManager _servicesManager;

        public PageController(DataManager manager)
        {
            this._dataManager = manager;
            _servicesManager = new ServicesManager(manager);
        }

        public IActionResult Index(int pageId, PageType pageType)
        {
            PageViewModel _viewModel;
            switch (pageType)
            {
                case PageType.Directory:
                    _viewModel = _servicesManager.DirectoryService.GetDirectoryViewModel(pageId);
                    break;
                case PageType.Material:
                    _viewModel = _servicesManager.MaterialService.GetMaterialViewModel(pageId);
                    break;
                default:
                    _viewModel = null;
                    break;
            }
            ViewBag.PageType = pageType;
            return View(_viewModel);
        }

        public IActionResult PageEditor(int pageId, PageType pageType)
        {
            PageEditModel _editModel;
            switch (pageType)
            {
                case PageType.Directory:
                    _editModel = _servicesManager.DirectoryService.GetDirectoryEditModel(pageId);
                    break;
                case PageType.Material:
                    _editModel = _servicesManager.MaterialService.GetMaterialEditModel(pageId);
                    break;
                default:
                    _editModel = null;
                    break;
            }

            ViewBag.PageType = pageType;
            return View(_editModel);
        }
    }
}
