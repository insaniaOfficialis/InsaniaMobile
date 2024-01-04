namespace Services;

/// <summary>
/// Статический класс ошибок
/// </summary>
public static class Errors
{
    //ОБЩИЕ
    public static readonly string EmptyUrl = "Пустая ссылка";
    public static readonly string EmptyVersion = "Пустая версия api";

    //АВТОРИЗАЦИЯ
    public static readonly string EmptyAuthorization = "Пустая ссылка авторизации";
    public static readonly string NotExistsLogin = "Не указан логин";
    public static readonly string NotExistsPassword = "Не указан пароль";
}
