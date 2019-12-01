using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Paylocity.Benefits.WebApi.Data.UnitTests
{
    [TestClass]
    public class TestInitialize
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            Effort.Provider.EffortProviderConfiguration.RegisterProvider();
        }
    }
}
