using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Exam2Question2.Models;

namespace Exam2Question2.DAL
{
    public class OfficeInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<OfficeContext>
    {
        protected override void Seed(OfficeContext context)
        {
            var Employee = new List<Employee>
            {
            new Employee{FirstMidName="Carson",LastName="Alexander",BillingDate=DateTime.Parse("2005-09-01")},
            new Employee{FirstMidName="Meredith",LastName="Alonso",BillingDate=DateTime.Parse("2002-09-01")},
            new Employee{FirstMidName="Arturo",LastName="Anand",BillingDate=DateTime.Parse("2003-09-01")},
            new Employee{FirstMidName="Gytis",LastName="Barzdukas",BillingDate=DateTime.Parse("2002-09-01")},
            new Employee{FirstMidName="Yan",LastName="Li",BillingDate=DateTime.Parse("2002-09-01")},
            new Employee{FirstMidName="Peggy",LastName="Justice",BillingDate=DateTime.Parse("2001-09-01")},
            new Employee{FirstMidName="Laura",LastName="Norman",BillingDate=DateTime.Parse("2003-09-01")},
            new Employee{FirstMidName="Nino",LastName="Olivetto",BillingDate=DateTime.Parse("2005-09-01")}
            };

            Employee.ForEach(s => context.Employees.Add(s));
            context.SaveChanges();
            var Project = new List<Project>
            {
            new Project{ProjectID=1050,Title="Chemistry",Credits=3,},
            new Project{ProjectID=4022,Title="Microeconomics",Credits=3,},
            new Project{ProjectID=4041,Title="Macroeconomics",Credits=3,},
            new Project{ProjectID=1045,Title="Calculus",Credits=4,},
            new Project{ProjectID=3141,Title="Trigonometry",Credits=4,},
            new Project{ProjectID=2021,Title="Composition",Credits=3,},
            new Project{ProjectID=2042,Title="Literature",Credits=4,}
            };
            Project.ForEach(s => context.Projects.Add(s));
            context.SaveChanges();
            var Billings = new List<Billing>
            {
            new Billing{EmployeeID=1,ProjectID=1050,Rate=Rate.A},
            new Billing{EmployeeID=1,ProjectID=4022,Rate=Rate.C},
            new Billing{EmployeeID=1,ProjectID=4041,Rate=Rate.B},
            new Billing{EmployeeID=2,ProjectID=1045,Rate=Rate.B},
            new Billing{EmployeeID=2,ProjectID=3141,Rate=Rate.F},
            new Billing{EmployeeID=2,ProjectID=2021,Rate=Rate.F},
            new Billing{EmployeeID=3,ProjectID=1050},
            new Billing{EmployeeID=4,ProjectID=1050,},
            new Billing{EmployeeID=4,ProjectID=4022,Rate=Rate.F},
            new Billing{EmployeeID=5,ProjectID=4041,Rate=Rate.C},
            new Billing{EmployeeID=6,ProjectID=1045},
            new Billing{EmployeeID=7,ProjectID=3141,Rate=Rate.A},
            };
            Billings.ForEach(s => context.Billings.Add(s));
            context.SaveChanges();
        }
    }
}