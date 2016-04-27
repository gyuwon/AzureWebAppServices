using System.Web.Mvc;
using ContactManager.Controllers;
using ContactManager.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ContactManager.Tests.Controllers
{
    [TestClass]
    public class ContactsControllerTest
    {
        [TestMethod]
        public void IndexReturnsViewResultWithAllContacts()
        {
            // Arrange
            var contacts = new Contact[]
            {
                new Contact { FirstName = "Tony", LastName = "Stark" },
                new Contact { FirstName = "Bruce", LastName = "Banner" }
            };
            var repository = Mock.Of<ContactRepository>(
                x => x.GetAllContacts() == contacts);
            var sut = new ContactsController(repository);

            // Act
            ActionResult actual = sut.Index();

            // Assert
            actual.Should().BeOfType<ViewResult>()
                .Which.Model.Should().BeOfType<Contact[]>()
                .Which.Should().Equal(contacts);
        }
    }
}
