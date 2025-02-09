﻿using Microsoft.Toolkit.Mvvm.Input;

namespace CosmosDbExplorer.ViewModels.DatabaseNodes
{
    public interface ICanEditDelete
    {
        RelayCommand EditCommand { get; }

        RelayCommand DeleteCommand { get; }
    }
}
