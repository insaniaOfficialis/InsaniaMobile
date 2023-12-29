﻿using Mobile.Pages.Base;

namespace Mobile;

/// <summary>
/// Логика главной страницы
/// </summary>
public partial class MainPage : ContentPage
{
    /// <summary>
    /// Логика главной страницы
    /// </summary>
    public MainPage()
    {
        //Инициализируем компоненты
        InitializeComponent();

        ToAuthorization(null, null);
    }

    private async void ToAuthorization(object? sender, EventArgs? e)
    {
        await Navigation.PushModalAsync(new Authorization());
    }
}