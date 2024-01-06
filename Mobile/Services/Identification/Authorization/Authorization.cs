using Domain.Models.Identification.Authorization.Response;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Text.Json;

namespace Services.Identification.Authorization;

/// <summary>
/// Сервис авторизации
/// </summary>
public class Authorization : IAuthorization
{
    /// <summary>
    /// Конфигурация
    /// </summary>
    private readonly IConfiguration _configuration;

    /// <summary>
    /// Параметры json
    /// </summary>
    private readonly JsonSerializerOptions _settings = new();

    /// <summary>
    /// Конструктор сервиса авторизации
    /// </summary>
    /// <param name="configuration"></param>
    public Authorization(IConfiguration configuration)
    {
        //Получаем конфигурацию
        _configuration = configuration;

        //Устанавливаем параметры json
        _settings.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    }

    /// <summary>
    /// Метод обработки
    /// </summary>
    /// <param name="login"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<AuthorizationResponse> Handler(string? login, string? password)
    {
        //Получаем строку запроса
        string url = BuilderUrl(login, password);

        //Формируем клиента
        ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
        using var client = new HttpClient(new HttpClientHandler()
        {
            ServerCertificateCustomValidationCallback = delegate { return true; },
        });

        //Получаем данные по запросу
        using var result = await client.GetAsync(url);

        if (ValidateResponse(result))
        {
            //Десериализуем ответ
            var content = await result.Content.ReadAsStringAsync();
            var respose = JsonSerializer.Deserialize<AuthorizationResponse>(content, _settings);

            if (ValidateData(respose))
            {
                //Записываем токен
                await SecureStorage.Default.SetAsync("token", respose!.Token!);
                return respose!;
            }
            else
                throw new Exception("Не пройдена проверка данных");
        }
        else
            throw new Exception("Не пройдена проверка ответа");
    }

    /// <summary>
    /// Метод формирования строки запроса
    /// </summary>
    /// <param name="login"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public string BuilderUrl(string? login, string? password)
    {
        //Проверяем конфигурацию файла
        if (ValidateConfiguration() && ValidateRequest(login, password))
        {
            //Формируем ссылку запроса
            string url = _configuration["Api:Url"] 
                + _configuration["Api:Version"] 
                + _configuration["Api:Authorization"]
                + string.Format("login?username={0}&password={1}", login, password);

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
        if (string.IsNullOrEmpty(_configuration["Api:Authorization"]))
            throw new Exception(Errors.EmptyAuthorization);

        //Возвращаем результат
        return true;
    }

    /// <summary>
    /// Метод проверки запроса
    /// </summary>
    /// <param name="login"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public bool ValidateRequest(string? login, string? password)
    {
        //Проверяем данные из файла конфигурации
        if (string.IsNullOrEmpty(login))
            throw new Exception(Errors.NotExistsLogin);
        if (string.IsNullOrEmpty(password))
            throw new Exception(Errors.NotExistsPassword);

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

    /// <summary>
    /// Метод проверки данных
    /// </summary>
    /// <param name="response"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public bool ValidateData(AuthorizationResponse? response)
    {
        //Если ответ не пустой
        if (response != null)
        {
            //Если статус ответ - Успешно, возвращаем успешный результат
            if (response.Success)
                return true;
            //В ином случае обрабатываем ошибки
            else
            {
                //Если есть текст ошибки, возвращаем исключение об этом
                if (response.Error != null && !string.IsNullOrEmpty(response.Error.Message))
                    throw new Exception(response.Error.Message);
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
