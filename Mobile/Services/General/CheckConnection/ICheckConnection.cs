namespace Mobile.Services.General.CheckConnection;

/// <summary>
/// Интерфейс проверки соединения
/// </summary>
public interface ICheckConnection
{
    /// <summary>
    /// Метод обработки
    /// </summary>
    /// <param name="authorize"></param>
    /// <returns></returns>
    Task<bool> Handler(bool authorize);

    /// <summary>
    /// Метод формирования строки запроса
    /// </summary>
    /// <returns></returns>
    string BuilderUrl();

    /// <summary>
    /// Метод проверки конфигурации
    /// </summary>
    /// <returns></returns>
    bool ValidateConfiguration();

    /// <summary>
    /// Метод проверки ответа
    /// </summary>
    /// <param name="response"></param>
    /// <returns></returns>
    bool ValidateResponse(HttpResponseMessage? response);
}