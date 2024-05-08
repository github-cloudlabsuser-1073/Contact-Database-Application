using NUnit.Framework;
using System.Web.Mvc;
using CRUD_application_2.Controllers;
using CRUD_application_2.Models;
using System.Linq;

[TestFixture]
public class UserControllerTests
{
    private UserController _userController;

    [SetUp]
    public void Setup()
    {
        _userController = new UserController();
    }

    [Test]
    public void Index_ReturnsViewResult_WithListOfUsers()
    {
        // Act
        var result = _userController.Index() as ViewResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("Index", result.ViewName);
        Assert.IsInstanceOf(typeof(System.Collections.Generic.List<User>), result.Model);
    }

    [Test]
    public void Details_ReturnsUser_WhenUserExists()
    {
        // Arrange
        var user = new User { Id = 1, Name = "Test User" };
        UserController.userlist.Add(user);

        // Act
        var result = _userController.Details(1) as ViewResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("Details", result.ViewName);
        Assert.AreEqual(user, result.Model);

        // Cleanup
        UserController.userlist.Remove(user);
    }

    // Add similar tests for Create (GET and POST), Edit (GET and POST), and Delete (GET and POST) methods here
}
