using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Paylocity.Benefits.Model.Enums;
using Paylocity.Benefits.Model.Models;
using Paylocity.Benefits.WebApi.Business.Interfaces;
using Paylocity.Benefits.WebApi.Data.Interfaces;
using Paylocity.Benefits.WebApi.Model.Models;

namespace Paylocity.Benefits.WebApi.Business.UnitTests
{
    [TestClass]
    public class EmployeeBLLTests
    {
        private EmployeeBLL target;
        private Mock<IBenefitsBLL> mBenefitsBLL;
        private Mock<IEmployeeRepository> mEmployeeRepo;
        private int defaultCompensationRate;

        private Employee testEmployee;

        [TestInitialize]
        public void Initialize()
        {
            mBenefitsBLL = new Mock<IBenefitsBLL>();
            mEmployeeRepo = new Mock<IEmployeeRepository>();
            defaultCompensationRate = 2000;

            target = new EmployeeBLL(mBenefitsBLL.Object, mEmployeeRepo.Object, defaultCompensationRate);

            testEmployee = new Employee()
            {
                Dependents = new List<Dependent>()
                {
                    new Dependent(),
                    new Dependent()
                }
            };
        }

        [TestMethod]
        public async Task EmployeeBLL_AssignsBenefitCategories()
        {
            //Arrange
            var expectedEmployeeCategoryId = 1;
            var expectedDependenctCategoryId = 2;
            mEmployeeRepo.Setup(x => x.GetBenefitCategoryByTypeAsync(BenefitType.Employee))
                .ReturnsAsync(new BenefitCategory()
                {
                    BenefitCategoryId = expectedEmployeeCategoryId
                });
            mEmployeeRepo.Setup(x => x.GetBenefitCategoryByTypeAsync(BenefitType.Dependent))
                .ReturnsAsync(new BenefitCategory()
                {
                    BenefitCategoryId = expectedDependenctCategoryId
                });
            mEmployeeRepo.Setup(x => x.CreateEmployeeAsync(It.Is<Employee>(y => y.EmployeeId == testEmployee.EmployeeId)));
            mBenefitsBLL.Setup(x => x.CalculateAnnualCostsAsync(It.Is<Employee>(y => y.EmployeeId == testEmployee.EmployeeId)));

            //Act
            await target.CreateEmployeeAsync(testEmployee);

            //Assert
            Assert.AreEqual(testEmployee.BenefitCategory.BenefitCategoryId, expectedEmployeeCategoryId);
            foreach(var dependent in testEmployee.Dependents)
            {
                Assert.AreEqual(expectedDependenctCategoryId, dependent.BenefitCategory.BenefitCategoryId);
            }
        }

        [TestMethod]
        public async Task EmployeeBLL_DoesNotOverrideCompensationRate()
        {
            //Arrange 
            mEmployeeRepo.Setup(x => x.GetBenefitCategoryByTypeAsync(It.IsAny<BenefitType>()))
                .ReturnsAsync(new BenefitCategory());
            mEmployeeRepo.Setup(x => x.CreateEmployeeAsync(It.Is<Employee>(y => y.EmployeeId == testEmployee.EmployeeId)));
            mBenefitsBLL.Setup(x => x.CalculateAnnualCostsAsync(It.Is<Employee>(y => y.EmployeeId == testEmployee.EmployeeId)));

            var expectedCompensationRate = 2000;
            testEmployee.CompensationRate = expectedCompensationRate;

            //Act 
            await target.CreateEmployeeAsync(testEmployee);

            //Assert
            Assert.AreEqual(expectedCompensationRate, testEmployee.CompensationRate);
        }
    }
}
