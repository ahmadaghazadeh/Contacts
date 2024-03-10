using ContactContext.Domain.Contacts;
using ContactContext.Domain.Contacts.Exceptions;
using Framework.Core.Domain;
using Framework.Domain;

namespace Contacts.DomainTest
{
    [TestClass]
    public class ContactTest
    {

        [TestMethod, TestCategory("Initialize")]
        public void ContactShouldEntityBase_Retrieve()
        {
            var contact = new Contact("Ahmad");

            Assert.IsTrue(contact is EntityBase<Guid>);
        }

        [TestMethod, TestCategory("Initialize")]
        public void ContactShouldAggregateRoot_Retrieve()
        {
            var contact = new Contact("Ahmad");

            Assert.IsTrue(contact is IAggregateRoot<Contact>);
        }

        [TestMethod, TestCategory("FirstName")]
        [DataRow(null)]
        [DataRow("")]
        [DataRow(" ")]
        [ExpectedException(typeof(FirstNameInvalidFormatException))]
        public void FirstNameIsEmpty_ThrowFirstNameRequiredException(string firstName)
        {
            var contact = new Contact(firstName);
        }

        [TestMethod, TestCategory("FirstName")]
        public void FirstName_Retrieve()
        {
            var firstName = "Ahmad";
            var contact = new Contact("Ahmad");
            Assert.AreEqual(firstName, contact.FirstName);
        }


    }
}