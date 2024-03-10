using ContactContext.Domain.Contacts.Services;
using System.Text.RegularExpressions;

namespace ContactContext.Domain.Service.Contacts
{
    public class PhoneNumberFormatChecker: IPhoneNumberFormatChecker
    {
        public bool Check(string phoneNumber)
        {
            const string pattern = @"\(?\d{3}\)?[-\.]? *\d{3}[-\.]? *[-\.]?\d{4}";
            return Regex.IsMatch(phoneNumber, pattern);
        }
    }
}
