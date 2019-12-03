using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paylocity.Benefits.WebApi.Model.Models;
using Paylocity.Benefits.Model.Models;
using Paylocity.Benefits.Model.RuleStrategies;

namespace Paylocity.Benefits.Model.UnitTests.RuleStrategyTests
{
    [TestClass]
    public class FirstNameStartsWithLetterATests
    {
        private FirstNameStartsWithLetterARule target;
        private Employee testEmployee;

        [TestInitialize]
        public void Initialize()
        {
            target = new FirstNameStartsWithLetterARule();
            testEmployee = new Employee()
            {
                BenefitCategories = new List<BenefitCategory>() {
                new BenefitCategory()
                    {
                        Amount = 1000
                    }
                }
            };
        }

        [TestMethod]
        public void FirstNameStartsWithLetterA_AppliesToEmployee()
        {
            //Arrange
            testEmployee.FirstName = "A";
            var expected = 1000;

            //Act
            var result = target.ApplyRule(testEmployee);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FirstNameStartsWithLetterA_AppliesToDependents()
        {
            //Arrange
            testEmployee.FirstName = "B";
            var testDependent = new Dependent()
            {
                FirstName = "A",
                BenefitCategories = new List<BenefitCategory>() {
                    new BenefitCategory()
                    {
                        Amount = 500
                    }
                }
            };
            testEmployee.Dependents.Add(testDependent);
            testEmployee.Dependents.Add(testDependent);
            var expected = 1000;

            //Act
            var result = target.ApplyRule(testEmployee);

            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
