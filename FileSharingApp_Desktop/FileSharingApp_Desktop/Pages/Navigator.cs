﻿using FileSharingApp_Desktop;
using System;
using System.Windows;
using System.Windows.Navigation;

public static class Navigator
{
    private static NavigationService NavigationService { get; } = (Application.Current.MainWindow as MainWindow).MainFrame.NavigationService;

    public static void Navigate(string path, object param = null)
    {
        NavigationService.Navigate(new Uri(path, UriKind.RelativeOrAbsolute), param);
    }

    public static void GoBack()
    {
        NavigationService.GoBack();
    }

    public static void GoForward()
    {
        NavigationService.GoForward();
    }
}
