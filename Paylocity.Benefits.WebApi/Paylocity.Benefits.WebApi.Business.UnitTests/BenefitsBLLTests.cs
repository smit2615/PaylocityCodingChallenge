using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Paylocity.Benefits.Model.Interfaces;
using Paylocity.Benefits.Model.Models;
using Paylocity.Benefits.WebApi.Data.Interfaces;
using Paylocity.Benefits.WebApi.Model.Models;

namespace Paylocity.Benefits.WebApi.Business.UnitTests
{
    [TestClass]
    public class BenefitsBLLTests
    {
        private Mock<IRuleEngine> mRuleEngine;
        private Mock<IBenefitRuleRepository> mRuleRepo;
        private int numPayPeriods;
        private BenefitsBLL target;

        private Employee testEmployee;

        [TestInitialize]
        public void Initialize()
        {
            mRuleEngine = new Mock<IRuleEngine>();
            mRuleRepo = new Mock<IBenefitRuleRepository>();
            numPayPeriods = 10;

            target = new BenefitsBLL(mRuleEngine.Object, mRuleRepo.Object, numPayPeriods);

            testEmployee = new Employee()
            {
                CompensationRate = 2000
            };
        }
        [TestMethod]
        public async Task BenefitsBLL_CalculatesCorrectAnnualCost()
        {
            //Arrange
            mRuleRepo.Setup(x => x.GetAllRules())
                .ReturnsAsync(new List<BenefitRule>());
            mRuleEngine.Setup(x => x.Start(It.IsAny<Employee>()))
                .Verifiable();
            mRuleEngine.Setup(x => x.SetRule(It.IsAny<BenefitRule>()))
                .Verifiable();
            mRuleEngine.Setup(x => x.ApplyRule())
                .Verifiable();
            mRuleEngine.Setup(x => x.End())
                .Returns(1000);

            var expectedAnnualCost = 19000;

            //Act
            await target.CalculateAnnualCostsAsync(testEmployee);

            //Assert
            Assert.AreEqual(expectedAnnualCost, testEmployee.AnnualCost);
        }
    }
}
