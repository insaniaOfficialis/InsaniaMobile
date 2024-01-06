using Domain.Models.Identification.Authorization.Response;

namespace Services.Identification.Authorization;

/// <summary>
/// Интерфейс авторизации
/// </summary>
public interface IAuthorization
{
    /// <summary>
    /// Метод обработки
    /// </summary>
    /// <param name="login"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    Task<AuthorizationResponse> Handler(string? login, string? password);

    /// <summary>
    /// Метод формирования строки запроса
    /// </summary>
    /// <param name="login"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    string BuilderUrl(string? login, string? password);

    /// <summary>
    /// Метод проверки конфигурации
    /// </summary>
    /// <returns></returns>
    bool ValidateConfiguration();

    /// <summary>
    /// Метод проверки запроса
    /// </summary>
    /// <param name="login"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    bool ValidateRequest(string? login, string? password);

    /// <summary>
    /// Метод проверки ответа
    /// </summary>
    /// <param name="response"></param>
    /// <returns></returns>
    bool ValidateResponse(HttpResponseMessage? response);

    /// <summary>
    /// Метод проверки данных
    /// </summary>
    /// <param name="response"></param>
    /// <returns></returns>
    bool ValidateData(AuthorizationResponse? response);
}
