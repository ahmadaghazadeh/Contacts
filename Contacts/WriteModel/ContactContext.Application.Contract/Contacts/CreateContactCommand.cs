using Framework.Core.Application;

namespace ContactContext.Application.Contract.Contacts
{
    public class CreateContactCommand: Command
    {
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public List<string> Phones { get;  set; }
    }
}
