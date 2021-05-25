using System;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Moq;

using User.Model;

namespace CRUD_TESTS
{
    public class TestHttpMethods
    {
        [Fact]
        public void ItWasReturnedTest()
        {
            var mocKSet = new Mock<DbSet<UserModel>>();
        }
        [Fact]
        public void ItWasListedTest()
        {

        }
        [Fact]
        public void ItWasCreatedTest()
        {

        }
        [Fact]
        public void ItWasEditedTest()
        {

        }
        [Fact]
        public void ItWasDeletedTest()
        {

        }
    }
}
