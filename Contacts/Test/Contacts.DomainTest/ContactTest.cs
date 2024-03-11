using ContactContext.Application.Contract.Contacts;
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

        private readonly Mock<IFirstNameLastNameDuplicationChecker> firstNameLastNameDuplicationChecker = new();


        [TestInitialize]
        public void Initialize()
        {
            phoneNumberChecker.Setup(c => c.Check(It.IsAny<string>())).Returns(true);
            firstNameLastNameDuplicationChecker.Setup(c => c.IsDuplicate(It.IsAny<string>(),It.IsAny<string>())).Returns(false);
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
            var contact = InitContact(lastName: LastName);
            Assert.AreEqual(LastName, contact.LastName);
        }

        [TestMethod, TestCategory("Phones")]
        [ExpectedException(typeof(PhoneNumberDuplicateException))]
        public void PhonesIsInvalid_ThrowPhoneNumberDuplicateException()
        {
            var phones= new List<PhoneDto>()
            {
                new PhoneDto()
                {
	                Type = "Mobile",
	                Number = "+989352185069"
				},
                new PhoneDto()
                {
	                Type = "Mobile",
	                Number = "+989352185069"
				} 
            };
            InitContact(phones: phones);
        }

        [TestMethod, TestCategory("Phones")]
        public void Phones_Retrieve()
        {
			var phones = new List<PhoneDto>()
			{
				new PhoneDto()
				{
					Type = "Mobile",
					Number = "+989352185069"
				},
				new PhoneDto()
				{
					Type = "Mobile",
					Number = "+09303977077"
				}
			};

			var contact = InitContact(phones: phones);

			Assert.IsTrue(contact.Phones.Any(c => c.Number == phones[0].Number));
			Assert.IsTrue(contact.Phones.Any(c => c.Number == phones[1].Number));

			Assert.AreEqual(phones.Count, contact.Phones.Count);
        }

        [TestMethod, TestCategory("Constraint")]
        [ExpectedException(typeof(FirstNameLastNameDuplicatedException))]
        public void FirstNameLastNameDuplicate_FirstNameLastNameDuplicatedException()
        {
            var firstName = "Ahmad";
            var lastName = "Aghazadeh";

            firstNameLastNameDuplicationChecker.Setup(c => c.IsDuplicate(firstName, lastName)).Returns(true);
            InitContact(firstName: firstName, lastName: lastName);
        }



        private Contact InitContact(
            string firstName = "Ahmad",
            string lastName = "Aghazadeh",
            List<PhoneDto> phones =default)
        {
            if (phones == default)
            {
				phones = new List<PhoneDto>()
				{
					new PhoneDto()
					{
						Type = "Mobile",
						Number = "+989352185069"
					},
					new PhoneDto()
					{
						Type = "Mobile",
						Number = "+09303977077"
					}
				};
			}
            return new Contact(phoneNumberChecker.Object,
            firstNameLastNameDuplicationChecker.Object, firstName, lastName, phones);
        }
    }
}