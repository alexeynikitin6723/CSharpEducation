using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAccountingSystem
{
  public class Employee
  {
    /// <summary>
    /// Id сотудника
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Имя сотрудника
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Зарплата сотрудника
    /// </summary>
    public decimal Salary { get; set; }
  }
}
