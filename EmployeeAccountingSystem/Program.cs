using System;

namespace EmployeeAccountingSystem
{
  public class Program
  {
    static void Main(string[] args)
    {
      EmployeeManagement employeeManagement = new EmployeeManagement();
      while (true)
      {
        Console.WriteLine("1. Добавить сотрудника");
        Console.WriteLine("2. Обновить данные сотрудника");
        Console.WriteLine("3. Получить информацию о сотруднике");
        Console.WriteLine("4. Рассчитать зарплату");
        Console.WriteLine("5. Выход");
        Console.Write("Выберите действие: ");
        var choice = Console.ReadLine();

        switch (choice)
        {
          case "1":
            AddEmployee(employeeManagement);
            break;
          case "2":
            UpdateEmployee(employeeManagement);
            break;
          case "3":
            GetEmployeeInfo(employeeManagement);
            break;
          case "4":
            CalculateSalary(employeeManagement);
            break;
          case "5":
            return;
          default:
            Console.WriteLine("Неверный выбор, попробуйте снова.");
            break;
        }
      }
    }
    static void AddEmployee(EmployeeManagement employeeManagement)
    {
      Console.Write("Введите id сотрудника: ");
      int id = int.Parse(Console.ReadLine());

      Console.Write("Введите имя сотрудника: ");
      string name = Console.ReadLine();

      Console.Write("Введите зарплату: ");
      decimal salary = decimal.Parse(Console.ReadLine());

      employeeManagement.AddEmployee(new Employee { Id = id, Name = name, Salary = salary });
      Console.WriteLine("Сотрудник добавлен");
    }

    static void UpdateEmployee(EmployeeManagement employeeManagement)
    {
      Console.Write("Введите ID сотрудника для обновления: ");
      int id = int.Parse(Console.ReadLine());
      Console.Write("Новое имя (оставьте пустым, если не хотите менять): ");
      string? name = Console.ReadLine() ?? null;
      Console.Write("Новая зарплата (оставьте пустым, если не хотите менять): ");
      decimal? salary = decimal.Parse(Console.ReadLine());

      if (employeeManagement.UpdateEmployee(id, name, salary))
      {
        Console.WriteLine("Информация обновлена");
      }
      else
      {
        Console.WriteLine("Сотрудник не найден.");
      }
    }
    static void GetEmployeeInfo(EmployeeManagement employeeManagement)
    {
      Console.Write("Введите ID сотрудника: ");
      int id = int.Parse(Console.ReadLine());
      var emp = employeeManagement.GetEmployeeInfo(id);
      if (emp != null)
      {
        Console.WriteLine($"ID: {emp.Id}");
        Console.WriteLine($"Имя: {emp.Name}");
        Console.WriteLine($"Зарплата: {emp.Salary}");
      }
      else
      {
        Console.WriteLine("Сотрудник не найден");
      }
    }
    static void CalculateSalary(EmployeeManagement employeeManagement)
    {
      Console.Write("Введите ID сотрудника: ");
      int id = int.Parse(Console.ReadLine());
      decimal? salary = employeeManagement.CalculateSalary(id);
      if (salary != null)
      {
        Console.WriteLine($"Зарплата за год: {salary}");
      }
      else
      {
        Console.WriteLine("Сотрудник не найден");
      }
    }
  }
}
