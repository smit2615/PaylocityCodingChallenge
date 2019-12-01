using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paylocity.Benefits.Model.Models;
using Paylocity.Benefits.WebApi.Data.Contexts;
using Paylocity.Benefits.WebApi.Model.Models;

namespace Paylocity.Benefits.WebApi.Data.UnitTests
{
    [TestClass]
    public class EmployeeRepositoryTests
    {
        private EmployeeRepository target;

        [TestInitialize]
        public void Initialize()
        {
            EffortProviderFactory.ResetDb();
            target = new EmployeeRepository();
        }

        [TestMethod]
        public async Task EmployeeRepository_GetsEmployeeById()
        {
            //Arrange
            PrepareData();

            //Act
            var result = await target.GetEmployeeByIdAsync(1);

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task EmployeeRepository_DoesNotGetFakeEmpoyeeById()
        {
            //Arrange
            PrepareData();

            //Act
            var result = await target.GetEmployeeByIdAsync(999);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task EmployeeRepository_GetsAllEmployees()
        {
            //Arrange
            PrepareData();

            //Act
            var result = await target.GetAllEmployeesAsync();

            //Assert
            Assert.AreEqual(2, result.Count);
        }

        private void PrepareData()
        {
            using(var db = new BenefitsContext())
            {
                db.Database.CreateIfNotExists();
                db.Employees.Add(new Employee()
                {
                    FirstName = "FirstName",
                    LastName = "LastName"
                });
                db.Employees.Add(new Employee()
                {
                    FirstName = "FirstName",
                    LastName = "LastName"
                });

                db.SaveChanges();
            }
        }
    }
}
