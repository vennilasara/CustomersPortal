using CustomersPortal.Controllers;
using CustomersPortal.Entities;
using CustomersPortal.Repositories;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Web.Http.Results;
using Xunit;
using NotFoundResult = Microsoft.AspNetCore.Mvc.NotFoundResult;

namespace CustomersPortal.UnitTests;

public class CustomersControllerTests
{
    [Fact]
    public void GetCustomer_WithNullCustomer()
    {
        //Mocking repository
        var repository = new Mock<ICustomerRepository>();

        var logger = new Mock<ILogger<CustomersController>>();

        var controller = new CustomersController(repository.Object, logger.Object);
      
        var result = controller.GetCustomer(Guid.NewGuid());

        //Assert

        Assert.IsType<NotFoundResult>(result.Result);

    }
}