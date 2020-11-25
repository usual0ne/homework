using System;
using EmployeesDB.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmployeesDB
{
    class Program
    {
        static private EmployeesContext _context = new EmployeesContext();
        static void Main(string[] args)
        {
            Console.WriteLine(Task1());
        }

        //Get highly paid employees
        static string Task1()
        {
            var employees = from e in _context.Employees
                            where e.Salary > 48000
                            orderby e.LastName
                            select new
                            {
                                FirstName = e.FirstName,
                                LastName = e.LastName,
                                MiddleName = e.MiddleName,
                                JobTitle = e.JobTitle,
                                Salary = e.Salary,
                                AddressText = e.Address.AddressText,
                                Name = e.Department.Name,
                                HireDate = e.HireDate
                            };

            var sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName}, {e.JobTitle}, {e.Salary}, {e.AddressText}, department name: {e.Name}, hire date: {e.HireDate};");
            }

            return sb.ToString().TrimEnd();
        }


        //Relocate employees
        static string Task2()
        {
            Addresses address = new Addresses();
            address.TownId = 5;
            address.AddressText = "13 Yellow St.";

            var employees = from e in _context.Employees
                            where e.LastName == "Brown"
                            select e;

            var sb = new StringBuilder();
            foreach (var e in employees)
            {
                e.Address = address;
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName}, {e.JobTitle}, {e.Salary}, {e.Address.AddressText}");
            }

            _context.SaveChanges();

            return sb.ToString().TrimEnd();

        }
        

        //Projects audit
        static string Task3()
        {
            DateTime startDdate = new DateTime(2002, 1, 1);
            DateTime endDate = new DateTime(2005, 12, 31, 23, 59, 59);

            var employeesProjects = (from ep in _context.EmployeesProjects
                                    where ep.Project.StartDate >= startDdate & ep.Project.EndDate <= endDate
                                    select new 
                                    {
                                        ep.Employee,
                                        ep.Project,
                                        ep.Employee.Manager
                                    }).Take(5);


            var sb = new StringBuilder();
            foreach (var ep in employeesProjects)
            {
                if (ep.Project.EndDate == null)
                {
                    sb.AppendLine($"Employee: {ep.Employee.FirstName} {ep.Employee.LastName} {ep.Employee.MiddleName}, " +
                    $"Manager: {ep.Employee.Manager.FirstName} {ep.Employee.Manager.LastName} {ep.Employee.Manager.MiddleName}\n" +
                    $"Project: {ep.Project.Name}, start date: {ep.Project.StartDate}, НЕ ЗАВЕРШЕН \n");
                }

                else
                {
                    sb.AppendLine($"Employee: {ep.Employee.FirstName} {ep.Employee.LastName} {ep.Employee.MiddleName}, " +
                        $"Manager: {ep.Employee.Manager.FirstName} {ep.Employee.Manager.LastName} {ep.Employee.Manager.MiddleName}\n" +
                        $"Project: {ep.Project.Name}, start date: {ep.Project.StartDate}, end date: {ep.Project.EndDate}\n");
                }
            }

            return sb.ToString().TrimEnd();
        }


        //Employee dossier
        static string Task4()
        {
            Console.Write("Введите id сотрудника: ");

            int id = int.Parse(Console.ReadLine());


            var employeeProjects = from ep in _context.EmployeesProjects
                                   where ep.EmployeeId == id
                                   select new
                                   {
                                       ep.Employee,
                                       ep.Project
                                   };

            var sb = new StringBuilder();



            sb.AppendLine($"{employeeProjects.First().Employee.FirstName} {employeeProjects.First().Employee.LastName} {employeeProjects.First().Employee.MiddleName} {employeeProjects.First().Employee.JobTitle}\n");


            sb.AppendLine("Проекты сотрудника:");

            foreach (var p in employeeProjects)
            {
                sb.AppendLine($"{p.Project.Name}");
            }

            return sb.ToString().TrimEnd();

        }

        //Small departments
        static string Task5()
        {
            var departments = (from d in _context.Departments
                              select new
                              {
                                  d.Name,
                                  d.DepartmentId
                              }).ToList();

            var employees = (from e in _context.Employees
                            select new
                            {
                                e.DepartmentId
                            }).ToList();

            var sb = new StringBuilder();

            foreach (var d in departments)
            {
                var count = (from e in employees where e.DepartmentId == d.DepartmentId select e).Count();

                if (count < 5)
                {
                    sb.AppendLine($"{d.Name}");
                }
            }

            return sb.ToString().TrimEnd();
        }


        //Raise salary
        static void Task6(string departmentName, int percentage)
        {
            var employees = from e in _context.Employees
                            where e.Department.Name == departmentName
                            select e;

            foreach (var e in employees)
            {
                e.Salary = e.Salary + e.Salary * percentage / 100;
            }

            _context.SaveChanges();
        }


        //Delete department
        static void Task7(int id)
        {
            var department = (from d in _context.Departments
                             where d.DepartmentId == id
                             select d).FirstOrDefault();

            _context.Departments.Remove(department);

            _context.SaveChanges();
        }

        //Delete town
        static void Task8(string name)
        {
            var town = (from t in _context.Towns
                       where t.Name == name
                       select t).FirstOrDefault();

            _context.Towns.Remove(town);

            _context.SaveChanges();
        }
    }
}
