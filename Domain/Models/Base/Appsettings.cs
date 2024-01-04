namespace Domain.Models.Base;

/// <summary>
/// Класс конфигурации
/// </summary>
public class Appsettings
{
    /// <summary>
    /// Адреса api
    /// </summary>
    public Api? Api { get; set; }
}

/// <summary>
/// Класс адресов api
/// </summary>
public class Api
{
    /// <summary>
    /// Основной адрес
    /// </summary>
    public string? Url { get; set; }

    /// <summary>
    /// Версия
    /// </summary>
    public string? Version { get; set; }

    /// <summary>
    /// Авторизация
    /// </summary>
    public string? Authorization { get; set; }
}