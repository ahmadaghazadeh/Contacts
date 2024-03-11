using ContactContext.Domain.Contacts;
using ContactContext.Domain.Contacts.Exceptions;
using ContactContext.Domain.Contacts.Services;
using Framework.Core.Domain;
using Framework.Domain;
using Moq;

namespace Contacts.DomainTest
{
	[TestClass]
	public class PhoneTest
	{
		private readonly Mock<IPhoneNumberFormatChecker> phoneNumberChecker = new();

		[TestInitialize]
		public void Initialize()
		{
			phoneNumberChecker.Setup(c => c.Check(It.IsAny<string>())).Returns(true);
		}

		[TestMethod, TestCategory("Initialize")]
		public void PhoneShouldEntityBase_Retrieve()
		{
			var phone = new Phone(phoneNumberChecker.Object,"Mobile", "09352185069");

			Assert.IsTrue(phone is ValueObject);
		}

		[TestMethod, TestCategory("Type")]
		[DataRow(null)]
		[DataRow("")]
		[DataRow(" ")]
		[ExpectedException(typeof(PhoneTypeInvalidFormatException))]
		public void TypeIsEmpty_ThrowPhoneTypeInvalidFormatException(string type)
		{
			new Phone(phoneNumberChecker.Object, type, "09352185069");
		}

		[TestMethod, TestCategory("Type")]
		public void Type_Retrieve()
		{
			var type = "Mobile";
			var phone = new Phone(phoneNumberChecker.Object, type,"09352185069");
			Assert.AreEqual(type, phone.Type);
		}


		 

		[TestMethod, TestCategory("Number")]
		public void Number_Retrieve()
		{
			var number = "09352185069";
			var phone = new Phone(phoneNumberChecker.Object, "Mobile", "09352185069");
			Assert.AreEqual(number, phone.Number);
		}


	}
}
