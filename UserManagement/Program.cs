namespace UserManagement
{
  internal class Program
  {
    static void Main(string[] args)
    {
      UserManager userManager = new UserManager();
      Console.WriteLine("1. Добавить пользователя");
      Console.WriteLine("2. Удалить пользователя");
      Console.WriteLine("3. Список пользователей");
      Console.WriteLine("4. Выход");

      while (true)
      {
        Console.Write("Введите команду: ");
        string command = Console.ReadLine();

        try
        {
          switch (command)
          {
            case "1":
              AddUser(userManager);
              break;

            case "2":
              RemoveUser(userManager);
              break;

            case "3":
              ListUsers(userManager);
              break;

            case "4":
              return;

            default:
              Console.WriteLine("Неверный выбор, попробуйте снова.");
              break;
          }
        }
        catch (Exception ex)
        {
          Console.WriteLine($"Ошибка: {ex.Message}");
        }
      }
    }
    
    static void AddUser(UserManager userManager)
    {
      try
      {
        Console.Write("Введите Имя: ");
        string name = Console.ReadLine();

        Console.Write("Введите возраст: ");
        int age = int.Parse(Console.ReadLine());

        User user = new User(name, age);
        userManager.AddUser(user);
        Console.WriteLine("Пользователь добавлен");
      }
      catch (FormatException)
      {
        Console.WriteLine("Неверный формат ввода");
      }
      catch(Exception ex)
      {
        Console.WriteLine($"Ошибка: {ex.Message}");
      }
    }
    static void RemoveUser(UserManager userManager)
    {
      try
      {
        Console.Write("Введите имя пользователя, которого нужно удалить: ");
        string name = Console.ReadLine();
        if (userManager.RemoveUser(name))
        {
          Console.WriteLine("Пользователь удален.");
        } 
        else
        {
          Console.WriteLine("Пользователь не найден");
        }
      }
      catch (FormatException)
      {
        Console.WriteLine("Неверный формат ввода");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Ошибка: {ex.Message}");
      }
    }

    static void ListUsers(UserManager userManager)
    {
      try
      {
        var users = userManager.ListUsers();
        if (users == null)
        {
          throw new InvalidOperationException("Списка пользователей нет");
        }
        else if(users.Count == 0)
        {
          Console.WriteLine("Список пуст");
        }
        foreach (var user in users)
        {
          Console.WriteLine(user.ToString());
        }
      }catch (Exception ex)
      {
        Console.WriteLine($"Ошибка: {ex.Message}");
      }
    }
  }
}
