using ContactContext.Domain;
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
            var contact = new Contact();

            Assert.IsTrue(contact is EntityBase<Guid>);
        }

        [TestMethod, TestCategory("Initialize")]
        public void ContactShouldAggregateRoot_Retrieve()
        {
            var contact = new Contact();

            Assert.IsTrue(contact is IAggregateRoot<Contact>);
        }
    }
}