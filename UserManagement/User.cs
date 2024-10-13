using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement
{
  public class User
  {
    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Возраст пользователя
    /// </summary>
    public decimal Age { get; set; }

    public User(string name, int age)
    {
      Name = name;
      Age = age;
    }

    public override string ToString()
    {
      return $"Name: {Name}, Age: {Age}";
    }
  }
}
