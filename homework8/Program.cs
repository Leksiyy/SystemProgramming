using Microsoft.Win32;

namespace homework8;

class Program
{

    const string RegistryPath = @"Software\UserSettingsApp";

    static void Main(string[] args)
    {
        string userName = ReadRegistryValue("UserName", "Гость");
        string favoriteColor = ReadRegistryValue("FavoriteColor", "Синий");

        Console.WriteLine("Текущие настройки:");
        Console.WriteLine($"Имя пользователя: {userName}");
        Console.WriteLine($"Предпочитаемый цвет: {favoriteColor}");
        Console.WriteLine();

        Console.Write("Введите ваше имя: ");
        userName = Console.ReadLine();

        Console.Write("Введите ваш любимый цвет: ");
        favoriteColor = Console.ReadLine();

        WriteRegistryValue("UserName", userName);
        WriteRegistryValue("FavoriteColor", favoriteColor);

        Console.WriteLine("Настройки сохранены!");
    }

    static string ReadRegistryValue(string valueName, string defaultValue)
    {
        using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryPath))
        {
            if (key != null)
            {
                object value = key.GetValue(valueName);
                if (value != null)
                {
                    return value.ToString();
                }
            }
        }
        return defaultValue;
    }

    static void WriteRegistryValue(string valueName, string value)
    {
        using (RegistryKey key = Registry.CurrentUser.CreateSubKey(RegistryPath))
        {
            if (key != null)
            {
                key.SetValue(valueName, value);
            }
        }
    }
}