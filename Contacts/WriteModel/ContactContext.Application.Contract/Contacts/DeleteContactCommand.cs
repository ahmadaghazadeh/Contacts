using Framework.Core.Application;

namespace ContactContext.Application.Contract.Contacts
{
    public class DeleteContactCommand : Command
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
