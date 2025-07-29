using HR.LeaveManagement.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Shouldly;

namespace HR.LeaveManagement.Application.UnitTests.Controllers;

public class HelloWorldControllerTests
{
    private readonly HelloWorldController _controller;

    public HelloWorldControllerTests()
    {
        _controller = new HelloWorldController();
    }

    [Fact]
    public void Get_ShouldReturnHelloWorldMessage()
    {
        // Act
        var result = _controller.Get();

        // Assert
        result.ShouldNotBeNull();
        var okResult = result.Result as OkObjectResult;
        okResult.ShouldNotBeNull();
        okResult.Value.ShouldBe("Hello World from HR Leave Management API!");
    }

    [Fact]
    public void Get_WithValidName_ShouldReturnPersonalizedMessage()
    {
        // Arrange
        var name = "John";

        // Act
        var result = _controller.Get(name);

        // Assert
        result.ShouldNotBeNull();
        var okResult = result.Result as OkObjectResult;
        okResult.ShouldNotBeNull();
        okResult.Value.ShouldBe("Hello John from HR Leave Management API!");
    }

    [Fact]
    public void Get_WithEmptyName_ShouldReturnDefaultMessage()
    {
        // Arrange
        var name = "";

        // Act
        var result = _controller.Get(name);

        // Assert
        result.ShouldNotBeNull();
        var okResult = result.Result as OkObjectResult;
        okResult.ShouldNotBeNull();
        okResult.Value.ShouldBe("Hello World from HR Leave Management API!");
    }

    [Fact]
    public void Get_WithNullName_ShouldReturnDefaultMessage()
    {
        // Arrange
        string name = null!;

        // Act
        var result = _controller.Get(name);

        // Assert
        result.ShouldNotBeNull();
        var okResult = result.Result as OkObjectResult;
        okResult.ShouldNotBeNull();
        okResult.Value.ShouldBe("Hello World from HR Leave Management API!");
    }
}