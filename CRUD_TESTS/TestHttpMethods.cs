using System;
using System.Linq;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

using User.Model;
using User.Context;
using User.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CRUD_TESTS
{
    public class TestHttpMethods
    {
        
        [Fact]
        public void ItWasReturnedTest()
        {
            //Criação do contexto e do bdset com mock(Arrange)
            var data = new List<UserModel>{
                new UserModel(){
                id= 5,
                firstName = "Steven",
                surname = "Ericksen",
                age = 40
                },
                new UserModel(){
                id= 6,
                firstName = "George",
                surname = "Ericksen",
                age = 55
                },
                new UserModel(){
                id= 7,
                firstName = "Patrick",
                surname = "Ericksen",
                age = 45
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<UserModel>>();
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.Expression).Returns(data.Expression);
            var mockContext = new Mock<UserContext>();
            //Criando nosso contexto mockado para passar para nossso argumento do constructor da controller
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);
            //Criando classe para instanciar o metodo post que iremos testar
            var service = new UserController(mockContext.Object);
            //Usando metodo testavel(Act)
            IActionResult actionResult = service.MetodoGetUm(5);
            IActionResult actionResultx = service.MetodoGetUm(7);
            IActionResult actionResulty = service.MetodoGetUm(8);
            //(Assert)
            Assert.IsType<OkObjectResult>(actionResult);
            Assert.IsType<OkObjectResult>(actionResultx);
            Assert.IsType<NotFoundObjectResult>(actionResulty);
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
            mockContext.Verify(m => m.Add(It.IsAny<UserModel>()),Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
        [Fact]
        public void ItWasEditedTest()
        {
            //Criação do contexto e do bdset com mock(Arrange)
            var data = new List<UserModel>{
                new UserModel(){
                id= 5,
                firstName = "Steven",
                surname = "Ericksen",
                age = 40
                },
                new UserModel(){
                id= 6,
                firstName = "George",
                surname = "Ericksen",
                age = 55
                },
                new UserModel(){
                id= 7,
                firstName = "Patrick",
                surname = "Ericksen",
                age = 45
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<UserModel>>();
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.Expression).Returns(data.Expression);

            var mockContext = new Mock<UserContext>();
            //Criando nosso contexto mockado para passar para nossso argumento do constructor da controller
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);
            //Criando classe para instanciar o metodo post que iremos testar
            var service = new UserController(mockContext.Object);
            //Usando metodo testavel(Act)
        
            service.MetodoPut(
                new UserModel(){
                firstName = "PatrickGeorge",
                surname = "Ericksen",
                age = 75
                },6);
            service.MetodoPut(
                new UserModel(){
                firstName = "PatrickAlterado",
                surname = "Ericksen",
                age = 30
                },6);
            //(Assert)
            mockContext.Verify(m => m.Update(It.IsAny<UserModel>()),Times.Exactly(2));
            mockContext.Verify(m => m.SaveChanges(), Times.Exactly(2));
        }
        
        [Fact]
        public void ItWasDeletedTest()
        {
            //Criação do contexto e do bdset com mock(Arrange)
            var data = new List<UserModel>{
                new UserModel(){
                id= 5,
                firstName = "Steven",
                surname = "Ericksen",
                age = 40
                },
                new UserModel(){
                id= 6,
                firstName = "George",
                surname = "Ericksen",
                age = 55
                },
                new UserModel(){
                id= 7,
                firstName = "Patrick",
                surname = "Ericksen",
                age = 45
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<UserModel>>();
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<UserModel>>().Setup(m => m.Expression).Returns(data.Expression);

            var mockContext = new Mock<UserContext>();
            //Criando nosso contexto mockado para passar para nossso argumento do constructor da controller
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);
            //Criando classe para instanciar o metodo post que iremos testar
            var service = new UserController(mockContext.Object);
            //Usando metodo testavel(Act)
        
            service.MetodoDelete(7);
            //(Assert)
            mockContext.Verify(m => m.Remove(It.IsAny<UserModel>()),Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
        
    }
}
