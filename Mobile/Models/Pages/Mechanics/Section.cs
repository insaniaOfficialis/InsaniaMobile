namespace Mobile.Models.Pages.Mechanics;

/// <summary>
/// Модель плашек
/// </summary>
/// <param name="file"></param>
/// <param name="title"></param>
/// <param name="description"></param>
/// <param name="color"></param>
public class Section(string file, string title, string description, Color color)
{
    /// <summary>
    /// Наименование файла
    /// </summary>
    public string File { get; private set; } = file;

    /// <summary>
    /// Заголовок
    /// </summary>
    public string Title { get; private set; } = title;

    /// <summary>
    /// Описание
    /// </summary>
    public string Description { get; private set; } = description;

    /// <summary>
    /// Цвет фона
    /// </summary>
    public Color Color { get; private set; } = color;
}