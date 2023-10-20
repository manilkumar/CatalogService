using Application.ServiceInterfaces;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Controllers;

namespace CartServiceTest
{
    public class TestBase
    {
        public CatalogController catalogController;

        public TestBase()
        {
            var loggerMock = new Mock<ILogger<CatalogController>>();
            var serviceManagerMock = new Mock<IServiceManager>();

            catalogController = new CatalogController(serviceManagerMock.Object, loggerMock.Object);
        }
    }
}
