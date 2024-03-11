
using ContactContext.Domain.Contacts.Exceptions;
using Framework.Domain;
using System.Numerics;
using ContactContext.Domain.Contacts.Services;

namespace ContactContext.Domain.Contacts
{
	public class Phone : ValueObject
	{
		public Phone(IPhoneNumberFormatChecker checker, string type, string number)
		{
			SetType(type);
			SetNumber(checker,number);
		}

		protected Phone(){}

		public string Type { get; set; }
		public string Number { get; set; }

		private void SetType(string type)
		{
			if (string.IsNullOrWhiteSpace(type))
				throw new PhoneTypeInvalidFormatException();

			Type = type;
		}

		private void SetNumber(IPhoneNumberFormatChecker checker, string number)
		{
			if (!checker.Check(number))
				throw new PhoneNumberInvalidFormatException();

			this.Number = number;
		}

		protected override IEnumerable<object> GetEqualityComponents()
		{
			throw new NotImplementedException();
		}
	}
}
