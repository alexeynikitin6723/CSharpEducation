using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeAccountingSystem
{
  public class EmployeeManagement
  {
    /// <summary>
    /// Список сотудников
    /// </summary>
    private List<Employee> employees = new List<Employee>();

    /// <summary>
    /// Добавляет сотрудника
    /// </summary>
    /// <param name="employee">Сотрудник</param>
    public void AddEmployee(Employee employee)
    {
      if (employees.Select(x => employee.Id == x.Id).Any())
      {
        Console.WriteLine("Данный сотрудник c таким ID уже существует");
        return;
      }
      employees.Add(employee);

    }

    /// <summary>
    /// Обнвляет данные сотрудника
    /// </summary>
    /// <param name="id">ID сотрудника.</param>
    /// <param name="name">Новое имя сотрудника.</param>
    /// <param name="salary">Новая зарплата сотрудника.</param>
    /// <returns>true, если сотрудник найден и обновлен</returns>
    public bool UpdateEmployee(int id, string? name = null, decimal? salary = null)
    {
      Employee emp = employees.Find(x => x.Id == id);
      if (emp != null)
      {
        if (!string.IsNullOrWhiteSpace(name)) emp.Name = name;
        if (salary.HasValue) emp.Salary = salary.Value;
        return true;
      }
      return false;
    }

    /// <summary>
    /// Возвращает информацию по Id сотрудника
    /// </summary>
    /// <param name="id">Id сотрудника</param>
    /// <returns>Сотрудник с указанным id</returns>
    public Employee GetEmployeeInfo(int id)
    {
      return employees.Find(x => x.Id == id);
    }

    /// <summary>
    /// Вычисляет годовую зарплату
    /// </summary>
    /// <param name="id">Id сотрудника</param>
    /// <returns>Размер годовой зарплаты</returns>
    public decimal CalculateSalary(int id)
    {
      return employees.Find(x => x.Id == id).Salary * 12;
    }
  }
}
