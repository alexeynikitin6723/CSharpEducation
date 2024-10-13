using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement
{
  public class UserManager
  {
    private List<User> users = new List<User>();

    /// <summary>
    /// Добавление пользователя
    /// </summary>
    /// <param name="user">Пользователь</param>
    public void AddUser(User user)
    {
      if (users.Contains(user))
      {
        Console.WriteLine("Пользователей уже существует");
        return;
      }
      users.Add(user);
    }

    /// <summary>
    /// Удаление пользователя по имени
    /// </summary>
    /// <param name="name">Имя пользователя</param>
    public bool RemoveUser(string name)
    {
      User removeUser = users.Find(x => x.Name == name);
      if (removeUser == null)
      {
        return false;
      }
      users.Remove(removeUser);
      return true;
    }

    /// <summary>
    /// Вернуть список пользователей
    /// </summary>
    public List<User> ListUsers()
    {
      return users;
    }
  }
}
