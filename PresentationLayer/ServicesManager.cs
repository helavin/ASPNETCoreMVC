using BusinessLayer;

using PresentationLayer.Services;

using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer
{
    public class ServicesManager
    {
        private DataManager _dataManager;
        private MaterialService _materialService;

        public ServicesManager(DataManager manager)
        {
            _dataManager = manager;
            DirectoryService = new DirectoryService(manager);
            _materialService = new MaterialService(manager);
        }

        public DirectoryService DirectoryService { get; }
        public MaterialService MaterialService { get { return _materialService; } }
    }
}
