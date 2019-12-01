using Paylocity.Benefits.Model;
using Paylocity.Benefits.Model.Interfaces;
using Paylocity.Benefits.WebApi.Business;
using Paylocity.Benefits.WebApi.Business.Interfaces;
using Paylocity.Benefits.WebApi.Data;
using Paylocity.Benefits.WebApi.Data.Interfaces;
using Paylocity.Benefits.WebApi.Model.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Unity;
using Unity.Injection;

namespace Paylocity.Benefits.WebApi.App_Start
{
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }

        public static T Get<T>()
        {
            return (T)GetConfiguredContainer().Resolve(typeof(T));
        }
        #endregion

        public static void RegisterTypes(IUnityContainer container)
        {
            //App Variables
            var numPayPeriods = Convert.ToInt32(ConfigurationManager.AppSettings["NumPayPeriods"]);
            var defaultCompensationRate = Convert.ToDecimal(ConfigurationManager.AppSettings["DefaultCompensationRate"]);

            //Model
            container.RegisterType<IRuleFactory, RuleFactory>();
            container.RegisterType<IRuleEngine, RuleEngine>(new InjectionConstructor(
                container.Resolve<IRuleFactory>()
            ));

            //Data
            container.RegisterType<IEmployeeRepository, EmployeeRepository>();
            container.RegisterType<IBenefitRuleRepository, BenefitRuleRepository>();

            //Business
            container.RegisterType<IBenefitsBLL, BenefitsBLL>(new InjectionConstructor(
                container.Resolve<IRuleEngine>(),
                container.Resolve<IBenefitRuleRepository>(),
                numPayPeriods
            ));

            container.RegisterType<IEmployeeBLL, EmployeeBLL>(new InjectionConstructor(
                container.Resolve<IBenefitsBLL>(),
                container.Resolve<IEmployeeRepository>(),
                defaultCompensationRate
            ));
        }
    }
}