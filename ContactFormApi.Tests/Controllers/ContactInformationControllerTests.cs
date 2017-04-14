using System.Collections.Generic;
using System.Web.Http.Results;
using ContactFormApi.Controllers;
using ContactFormApi.Data.Models;
using ContactFormApi.Data.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ContactFormApi.Tests.Controllers
{
    [TestClass]
    public class ContactInformationControllerTests
    {
        private Mock<IRepository> mockedRepository;
        private ContactInformationController target;

        [TestInitialize]
        public void Setup()
        {
            mockedRepository = new Mock<IRepository>();
            target = new ContactInformationController(mockedRepository.Object);
        }

        [TestCleanup]
        public void Cleanup()
        {
            mockedRepository=null;
            target = null;
        }


        [TestMethod]
        public void GetReturnsOkResult()
        {
            mockedRepository
                .Setup(m => m.GetContactInformation())
                .Returns(new List<ContactInformation>());

            var result = target.GetContacts();

            Assert.IsInstanceOfType(result,
                typeof(OkNegotiatedContentResult<IEnumerable<ContactInformation>>));
        }

        //[TestMethod]
        //public void GetWithIdReturnsOkResult()
        //{
        //    mockedRepository
        //        .Setup(m => m.GetContactInformation(It.IsAny<int>()))
        //        .Returns(new ContactInformation {FirstName = "Fname"});

        //    var result = target.Get(1);

        //    Assert.IsInstanceOfType(result,
        //     typeof(OkNegotiatedContentResult<ContactInformation>));
        //}

        //[TestMethod]
        //public void GetWithIdReturnsNotFoundResult()
        //{
        //    mockedRepository
        //        .Setup(m => m.GetContactInformation(It.IsAny<int>()))
        //        .Returns(new ContactInformation());

        //    var result = target.Get(1);

        //    Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        //}

        [TestMethod]
        public void PostReturnsOkResult()
        {
            mockedRepository
               .Setup(m => m.AddContactInformation(It.IsAny<ContactInformation>()))
               .Returns(true);

            var result = target.Post(new ContactInformation
            {
                FirstName = "Fname",
                LastName = "LName",
                Email = "HY@gmail.com",
                PhoneNumber = "123456789",
                Status = "Active"
            });

            Assert.IsInstanceOfType(result,
                typeof(OkNegotiatedContentResult<ContactInformation>));

        }

        [TestMethod]
        public void PostReturnsBadResultResult()
        {
            mockedRepository
               .Setup(m => m.AddContactInformation(It.IsAny<ContactInformation>()))
               .Returns(false);

            var result = target.Post(new ContactInformation
            {
                FirstName = "",
                LastName = "LName",
                Email = "HY@gmail.com",
                PhoneNumber = "123456789"

            });

            Assert.IsInstanceOfType(result,
                typeof(BadRequestResult));

        }

        [TestMethod]
        public void PutReturnsBadResultResult()
        {
            mockedRepository
               .Setup(m => m.EditContactInformation(It.IsAny<ContactInformation>()))
               .Returns(true);

            var result = target.Put(new ContactInformation
            {
                FirstName = "",
                LastName = "LName",
                Email = "HY@gmail.com",
                PhoneNumber = "123456789"

            });

            Assert.IsInstanceOfType(result,
                typeof(BadRequestResult));

        }

        [TestMethod]
        public void PutReturnsNotFoundResultResult()
        {
            mockedRepository
               .Setup(m => m.EditContactInformation(It.IsAny<ContactInformation>()))
               .Returns(false);

            var result = target.Put(new ContactInformation
            {
                FirstName = "Fname",
                LastName = "LName",
                Email = "HY@gmail.com",
                PhoneNumber = "123456789",
                Id = 100,
                Status = "Active"
            });


            Assert.IsInstanceOfType(result,
                typeof(NotFoundResult));

        }

        [TestMethod]
        public void PutReturnsOkResultResult()
        {
            mockedRepository
               .Setup(m => m.EditContactInformation(It.IsAny<ContactInformation>()))
               .Returns(true);

            var result = target.Put(new ContactInformation
            {
                FirstName = "Fname",
                LastName = "LName",
                Email = "HY@gmail.com",
                PhoneNumber = "123456789",
                Id = 1,
                Status = "Active"
            });

            Assert.IsInstanceOfType(result,
                typeof(OkNegotiatedContentResult<ContactInformation>));

        }

        #region Delete

        [TestMethod]
        public void DeleteReturnsOkResultResult()
        {
            mockedRepository
                .Setup(m => m.DeleteContactInformation(It.IsAny<int>()))
                .Returns(true);

            var result = target.Delete(1);

            Assert.IsInstanceOfType(result,
                typeof (OkNegotiatedContentResult<int>));

        }

        [TestMethod]
        public void DeleteReturnsNotFoundResultResult()
        {
            mockedRepository
                .Setup(m => m.DeleteContactInformation(It.IsAny<int>()))
                .Returns(false);

            var result = target.Delete(100);

            Assert.IsInstanceOfType(result,
                typeof (NotFoundResult));

        }

        #endregion




    }
}
