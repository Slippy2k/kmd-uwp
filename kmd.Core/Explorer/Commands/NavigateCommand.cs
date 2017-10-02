﻿using kmd.Core.Explorer.Commands.Abstractions;
using kmd.Core.Explorer.Commands.Configuration;
using kmd.Storage.Contracts;
using System;
using Windows.Storage;

namespace kmd.Core.Explorer.Commands
{
    [ExplorerCommand]
    public class NavigateCommand : ExplorerCommandBase
    {
        public NavigateCommand(IStorageFolderExploder storageFolderExpander, IStorageFolderLister storageFolderLister)
        {
            _storageFolderExpander = storageFolderExpander ?? throw new ArgumentNullException(nameof(storageFolderExpander));
            _storageFolderLister = storageFolderLister ?? throw new ArgumentNullException(nameof(storageFolderLister));
        }

        protected readonly IStorageFolderExploder _storageFolderExpander;

        protected readonly IStorageFolderLister _storageFolderLister;

        protected override bool OnCanExecute(object parameter)
        {
            return true;
        }

        protected override async void OnExecute(object parameter)
        {
            await ViewModel.GoToAsync(parameter as IStorageFolder);
        }
    }
}