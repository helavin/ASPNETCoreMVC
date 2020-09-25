using BusinessLayer;

using DataLayer.Entities;

using PresentationLayer.Models;

using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Services
{
    public class DirectoryService
    {
        private DataManager _dataManager;
        private MaterialService _materialService;
        public DirectoryService(DataManager manager)
        {
            this._dataManager = manager;
            _materialService = new MaterialService(manager);
        }

        public List<DirectoryViewModel> GetDirectoryViewModels()
        {
            var _dbDirectories = _dataManager.DirectoryRepository.GetDirectories();
            List<DirectoryViewModel> _directoryViewModels = new List<DirectoryViewModel>();

            foreach (var item in _dbDirectories)
            {
                _directoryViewModels.Add(GetDirectoryViewModel(item.Id));
            }
            return _directoryViewModels;
        }

        public DirectoryViewModel GetDirectoryViewModel(int id)
        {
            var _dbDirectory = _dataManager.DirectoryRepository.GetDirectoryById(id, true);
            List<MaterialViewModel> _materialViewModels = new List<MaterialViewModel>();

            foreach (var item in _dbDirectory.Materials)
            {
                _materialViewModels.Add(_materialService.GetMaterialViewModel(item.Id));
            }
            return new DirectoryViewModel() { Directory = _dbDirectory, Materials = _materialViewModels };
        }

        public DirectoryEditModel GetDirectoryEditModel(int id)
        {
            if (id == 0)
                return new DirectoryEditModel() { };

            var _dbDirectory = _dataManager.DirectoryRepository.GetDirectoryById(id);
            if (_dbDirectory == null)
                return new DirectoryEditModel() { };

            var _directoryEditModel = new DirectoryEditModel()
            {
                Id = _dbDirectory.Id,
                Title = _dbDirectory.Title,
                Html = _dbDirectory.Html
            };
            return _directoryEditModel;

        }

        public DirectoryViewModel SaveDirectoryEditModelToDb(DirectoryEditModel directoryEditModel)
        {
            Directory _directory;
            if (directoryEditModel.Id != 0)
            {
                _directory = _dataManager.DirectoryRepository.GetDirectoryById(directoryEditModel.Id);
            }
            else
            {
                _directory = new Directory();
            }
            _directory.Title = directoryEditModel.Title;
            _directory.Html = directoryEditModel.Html;

            _dataManager.DirectoryRepository.SaveDirectory(_directory);

            return GetDirectoryViewModel(_directory.Id);
        }

        public DirectoryEditModel CreateNewDirectoryEditModel()
        {
            return new DirectoryEditModel() { };
        }

    }
}
