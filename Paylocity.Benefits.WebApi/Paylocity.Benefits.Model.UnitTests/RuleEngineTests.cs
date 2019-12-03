using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Paylocity.Benefits.Model.Enums;
using Paylocity.Benefits.Model.Interfaces;
using Paylocity.Benefits.Model.Models;
using Paylocity.Benefits.WebApi.Model.Models;

namespace Paylocity.Benefits.Model.UnitTests
{
    [TestClass]
    public class RuleEngineTests
    {
        private RuleEngine target;
        private Mock<IRuleFactory> mRuleFactory;
        private Mock<IRuleStrategy> mStrategy;

        private Employee testEmployee;

        [TestInitialize]
        public void Initialize()
        {
            mRuleFactory = new Mock<IRuleFactory>();
            mStrategy = new Mock<IRuleStrategy>();
            mRuleFactory.Setup(x => x.Create(It.IsAny<RuleType>()))
                .Returns(mStrategy.Object);
            target = new RuleEngine(mRuleFactory.Object);

            testEmployee = new Employee()
            {
                BenefitCategories = new List<BenefitCategory>() {
                    new BenefitCategory()
                    {
                        Amount = 1000
                    }
                },
                Dependents = new List<Dependent>()
                {
                    new Dependent()
                    {
                        BenefitCategories = new List<BenefitCategory>() {
                            new BenefitCategory()
                            {
                                Amount = 500
                            }
                        }
                    },
                    new Dependent()
                    {
                        BenefitCategories = new List<BenefitCategory>() {
                            new BenefitCategory()
                            {
                                Amount = 500
                            }
                        }
                    }
                }
            };
        }

        [TestMethod]
        public void RuleEngine_CalculatesBaseBenefitCost()
        {
            //Arrange
            var expectedBenefitCost = 2000;

            //Act
            target.Start(testEmployee);

            //Assert
            Assert.AreEqual(expectedBenefitCost, target.End());
        }

        [TestMethod]
        public void RuleEngine_DiscountsBenefitCost()
        {
            //Arrange
            var benefitRule = new BenefitRule()
            {
                Amount = -10,
                AdjustmentType = Enums.AdjustmentType.Percentage,
            };
            target.Start(testEmployee);
            target.SetRule(benefitRule);
            mStrategy.Setup(x => x.ApplyRule(It.IsAny<Employee>()))
                .Returns(1000);
            var expectedBenefitCost = 1900;

            //Act
            target.ApplyRule();

            //Assert
            Assert.AreEqual(expectedBenefitCost, target.End());
        }

        [TestMethod]
        public void RuleEngine_UpchargesBenefitCost()
        {
            //Arrange
            var benefitRule = new BenefitRule()
            {
                Amount = 10,
                AdjustmentType = Enums.AdjustmentType.Percentage,
            };
            target.Start(testEmployee);
            target.SetRule(benefitRule);
            mStrategy.Setup(x => x.ApplyRule(It.IsAny<Employee>()))
                .Returns(1000);
            var expectedBenefitCost = 2100;

            //Act
            target.ApplyRule();

            //Assert
            Assert.AreEqual(expectedBenefitCost, target.End());
        }

        public void RuleEngine_AppliesFlatRate()
        {
            //Arrange
            var benefitRule = new BenefitRule()
            {
                Amount = -100,
                AdjustmentType = Enums.AdjustmentType.FlatRate,
            };
            target.Start(testEmployee);
            target.SetRule(benefitRule);
            mStrategy.Setup(x => x.ApplyRule(It.IsAny<Employee>()))
                .Returns(1000);
            var expectedBenefitCost = 1900;

            //Act
            target.ApplyRule();

            //Assert
            Assert.AreEqual(expectedBenefitCost, target.End());
        }
    }
}
