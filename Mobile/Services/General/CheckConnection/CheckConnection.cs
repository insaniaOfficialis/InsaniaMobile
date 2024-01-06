using Microsoft.Extensions.Configuration;
using Services;
using System.Net;
using System.Net.Http.Headers;

namespace Mobile.Services.General.CheckConnection;

/// <summary>
/// Сервис проверки соединения
/// </summary>
/// <param name="configuration"></param>
public class CheckConnection(IConfiguration configuration) : ICheckConnection
{
    /// <summary>
    /// Конфигурация
    /// </summary>
    private readonly IConfiguration _configuration = configuration;

    /// <summary>
    /// Токен доступа
    /// </summary>
    private string? _token;

    /// <summary>
    /// Метод обработки
    /// </summary>
    /// <param name="authorize"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<bool> Handler(bool authorize)
    {
        //Получаем токен
        _token = await SecureStorage.Default.GetAsync("token");

        //Если требуется проверить соединения и нет токена возвращаем не успех
        if (authorize && string.IsNullOrEmpty(_token))
            return false;

        //Получаем строку запроса
        string url = BuilderUrl();

        //Формируем клиента
        ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
        using var client = new HttpClient(new HttpClientHandler()
        {
            ServerCertificateCustomValidationCallback = delegate { return true; },
        });
        if (!string.IsNullOrEmpty(_token))
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
                _token);

        //Получаем данные по запросу
        using var result = await client.SendAsync(new HttpRequestMessage(HttpMethod.Head, url));

        if (!ValidateResponse(result))
            throw new Exception("Не пройдена проверка ответа");
        else
            return true;
    }

    /// <summary>
    /// Метод формирования строки запроса
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public string BuilderUrl()
    {
        //Проверяем конфигурацию файла
        if (ValidateConfiguration())
        {
            //Формируем ссылку запроса
            string url = _configuration["Api:Url"]
                + _configuration["Api:Version"]
                + _configuration["Api:Check"]
                + (!string.IsNullOrEmpty(_token) ? "" : "anonymous");

            //Возвращаем результат
            return url;
        }
        else
            throw new Exception("Не удалось пройти проверку");
    }

    /// <summary>
    /// Метод проверки конфигурации
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public bool ValidateConfiguration()
    {
        //Проверяем данные из файла конфигурации
        if (string.IsNullOrEmpty(_configuration["Api:Url"]))
            throw new Exception(Errors.EmptyUrl);
        if (string.IsNullOrEmpty(_configuration["Api:Version"]))
            throw new Exception(Errors.EmptyVersion);
        if (string.IsNullOrEmpty(_configuration["Api:Check"]))
            throw new Exception(Errors.EmptyCheck);

        //Возвращаем результат
        return true;
    }

    /// <summary>
    /// Метод проверки ответа
    /// </summary>
    /// <param name="response"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public bool ValidateResponse(HttpResponseMessage? response)
    {
        //Если ответ не пустой
        if (response != null)
        {
            //Если статус ответ - Успешно или Некорректный ответ, возвращаем успешный результат
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.BadRequest)
                return true;
            //В ином случае обрабатываем ошибки
            else
            {
                //Если пришёл статус - Неавторизованн, возвращаем исключение об этом
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                    throw new Exception("Некорректный токен");
                //Иначе возвращаем общее исключение
                else
                    throw new Exception("Ошибка сервера");
            }
        }
        //Иначе возвращаем общее исключение
        else
            throw new Exception("Пустой ответ");
    }
}
