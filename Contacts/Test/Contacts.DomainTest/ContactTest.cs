using ContactContext.Domain.Contacts;
using ContactContext.Domain.Contacts.Exceptions;
using ContactContext.Domain.Contacts.Services;
using Framework.Core.Domain;
using Framework.Domain;
using Moq;

namespace Contacts.DomainTest
{
    [TestClass]
    public class ContactTest
    {
        private readonly Mock<IPhoneNumberFormatChecker> phoneNumberChecker = new();


        [TestInitialize]
        public void Initialize()
        {
            phoneNumberChecker.Setup(c => c.Check(It.IsAny<string>())).Returns(true);
        }
        [TestMethod, TestCategory("Initialize")]
        public void ContactShouldEntityBase_Retrieve()
        {
            var contact = InitContact();

            Assert.IsTrue(contact is EntityBase<Guid>);
        }

        [TestMethod, TestCategory("Initialize")]
        public void ContactShouldAggregateRoot_Retrieve()
        {
            var contact = InitContact();

            Assert.IsTrue(contact is IAggregateRoot<Contact>);
        }

        [TestMethod, TestCategory("FirstName")]
        [DataRow(null)]
        [DataRow("")]
        [DataRow(" ")]
        [ExpectedException(typeof(FirstNameInvalidFormatException))]
        public void FirstNameIsEmpty_ThrowFirstNameRequiredException(string firstName)
        {
            InitContact(firstName);
        }

        [TestMethod, TestCategory("FirstName")]
        public void FirstName_Retrieve()
        {
            var firstName = "Ahmad";
            var contact = InitContact(firstName);
            Assert.AreEqual(firstName, contact.FirstName);
        }

      
        [TestMethod, TestCategory("LastName")]
        [DataRow(null)]
        [DataRow("")]
        [DataRow(" ")]
        [ExpectedException(typeof(LastNameInvalidFormatException))]
        public void LastNameIsEmpty_ThrowLastNameRequiredException(string lastName)
        {
            InitContact(lastName: lastName);
        }



        [TestMethod, TestCategory("LastName")]
        public void LastName_Retrieve()
        {
            var LastName = "Aghazadeh";
            var customer = InitContact(lastName: LastName);
            Assert.AreEqual(LastName, customer.LastName);
        }

        [TestMethod, TestCategory("Phones")]
        [ExpectedException(typeof(PhoneNumberInvalidFormatException))]
        public void PhonesIsInvalid_ThrowPhoneNumberInvalidFormatException()
        {
            var phones= new List<string>()
            {
                "+989352185069",
                "+989303977077",
            };
            phoneNumberChecker.Setup(c => c.Check( It.IsAny<string>() )).Returns(false);
            InitContact(phones: phones);
        }




        private Contact InitContact(
            string firstName = "Ahmad",
            string lastName = "Aghazadeh",
            List<string> phones =default)
        {
            if (phones == default)
            {
                phones = new List<string>()
                {
                    "+989352185069",
                    "+989303977077",
                };
            }
            return new Contact(phoneNumberChecker.Object,firstName, lastName, phones);
        }
    }
}