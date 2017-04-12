using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ContactFormApi.Data.DataContext;
using ContactFormApi.Data.Models;
using ContactFormApi.Data.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ContratFormApi.Data.Tests
{
    [TestClass]
    public class RepositoryTester
    {
        private Mock<ContactInformationDataContext> mockedContext;
        private Mock<DbSet<ContactInformation>> mockedDBSet;
        private IRepository target;

        [TestInitialize]
        public void Setup()
        {
            var contactInformations = new List<ContactInformation>
            {
                new ContactInformation {
                FirstName = "Fname",
                LastName = "Lname",
                Email = "HY@gmail.com",
                PhoneNumber = "1234567890",
                Id = 1,
                Status = "Active"
                }
            }.AsQueryable();

            mockedDBSet = new Mock<DbSet<ContactInformation>>();
            mockedDBSet.As<IQueryable<ContactInformation>>().Setup(m => m.Provider).Returns(contactInformations.Provider);
            mockedDBSet.As<IQueryable<ContactInformation>>().Setup(m => m.Expression).Returns(contactInformations.Expression);
            mockedDBSet.As<IQueryable<ContactInformation>>().Setup(m => m.ElementType).Returns(contactInformations.ElementType);
            mockedDBSet.As<IQueryable<ContactInformation>>().Setup(m => m.GetEnumerator()).Returns(contactInformations.GetEnumerator());
            mockedContext = new Mock<ContactInformationDataContext>();
            mockedContext.Setup(m => m.Contacts).Returns(mockedDBSet.Object);
            mockedContext.Setup(m => m.SaveChanges()).Returns(1);

            target = new Repository(mockedContext.Object);
        }

        [TestCleanup]
        public void Dispose()
        {
            mockedDBSet.Reset();
            mockedContext.Reset();
            target = null;
        }

        [TestMethod]
        public void ConstructorSuccess()
        {
            Assert.IsNotNull(target);
        }

        [TestMethod]
        public void GetInformationSuccess()
        {
            var result = target.GetContactInformation();
            Assert.AreEqual(1,result.Count());
        }

        [TestMethod]
        public void GetInformationWithIdSuccess()
        {
            var result = target.GetContactInformation(1);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void EditSuccess()
        {
            var contact = new ContactInformation
            {
                FirstName = "Fname",
                LastName = "Lname",
                Email = "HY@gmail.com",
                PhoneNumber = "1234567890",
                Id = 1,
                Status = "InActive"
            };

            var result = target.EditContactInformation(contact);
            mockedContext.Verify(m => m.SaveChanges(), Times.AtMost(2));
            Assert.IsTrue(result);
          
        }

        [TestMethod]
        public void DeleteSuccess()
        {
            var result = target.DeleteContactInformation(1);

            mockedDBSet.Verify(m => m.Remove(It.IsAny<ContactInformation>()), Times.Once());
            mockedContext.Verify(m => m.SaveChanges(), Times.Once());
            Assert.IsTrue(result);
        }
      

        [TestMethod]
        public void AddSuccess()
        {
            var contact = new ContactInformation
            {
                FirstName = "Fname1",
                LastName = "Lname1",
                Email = "HY@gmail.com",
                PhoneNumber = "1234567890",
                Id = 2,
                Status = "Active"
            };
            var result = target.AddContactInformation(contact);
            Assert.IsTrue(result);
            mockedDBSet.Verify(m => m.Add(It.IsAny<ContactInformation>()), Times.Once());
            mockedContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}
