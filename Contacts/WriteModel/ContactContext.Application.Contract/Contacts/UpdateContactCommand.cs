using Framework.Core.Application;

namespace CustomerContext.Application.Contract.Customers
{
    public class UpdateContactCommand : Command
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> Phones{ get; set; }
    }
}
