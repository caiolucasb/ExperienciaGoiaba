using System;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

using User.Model;
using User.Context;
using User.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_TESTS
{
    public class TestHttpMethods
    {
        
        [Fact]
        public void ItWasReturnedTest()
        {
            //Criação do contexto e do bdset com mock(Arrange)
            var mockSet = new Mock<DbSet<UserModel>>();
            var mockContext = new Mock<UserContext>();
            //Criando nosso contexto mockado para passar para nossso argumento do constructor da controller
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);
            //Criando classe para instanciar o metodo post que iremos testar
            var service = new UserController(mockContext.Object);
            var user = new UserModel(){
                firstName = "Jailton",
                surname = "Ericksen",
                age = 17
            };
            //Usando metodo testavel(Act)
            service.MetodoPost(user);
            IActionResult actionResult = service.MetodoGetUm(user.id);
            //(Assert)
            Assert.IsType<OkObjectResult>(actionResult);
        }
        [Fact]
        public void ItWasCreatedCorrectlyTest()
        {
            //Criação do contexto e do bdset com mock(Arrange)
            var mockSet = new Mock<DbSet<UserModel>>();
            var mockContext = new Mock<UserContext>();
            //Criando nosso contexto mockado para passar para nossso argumento do constructor da controller
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);
            //Criando classe para instanciar o metodo post que iremos testar
            var service = new UserController(mockContext.Object);
            //Usando metodo testavel(Act)
            service.MetodoPost(new UserModel(){
                firstName = "Jailton",
                surname = "Ericksen",
                age = 17
            });
            //(Assert)
            mockSet.Verify(m => m.Add(It.IsAny<UserModel>()),Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
        /*[Fact]
        public void ItWasEditedTest()
        {

        }
        [Fact]
        public void ItWasDeletedTest()
        {

        }
        */
    }
}
