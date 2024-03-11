using Azure;
using ContactContext.Application.Contract.Contacts;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;
using ContactContext.Acceptance.Test.Drivers;

namespace ContactContext.Acceptance.Test.StepDefinitions
{
	[Binding]
	public sealed class ContactStepDefinitions
	{
		// For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

		ContactDriver driver;
		private CreateContactCommand command;
		private HttpResponseMessage response;


		public ContactStepDefinitions(ContactDriver driver)
		{
			this.driver = driver;
		}

		[Given(@"a customer with the following details:")]
		public void GivenACustomerWithTheFollowingDetails(string contact)
		{
			command = JsonSerializer.Deserialize<CreateContactCommand>(contact);
		}

		[When(@"send a request to create the Contact")]
		public async Task WhenSendARequestToCreateTheContact()
		{
			response = await driver.CreteContactViaApi(command);
		}

		[Then(@"status code should be '([^']*)'")]
		public void ThenStatusCodeShouldBe(int statusCode)
		{
			response.StatusCode.Should().Be((HttpStatusCode)statusCode);
			Assert.AreEqual(statusCode, (int)HttpStatusCode.OK);
		}

		[Then(@"should have my Contact with following")]
		public void ThenShouldHaveMyContactWithFollowing(string contactJson)
		{
			var contact = JsonSerializer.Deserialize<CreateContactCommand>(contactJson);

			var createdContact = driver.GetContact(contact?.FirstName,contact?.LastName);
			contact?.FirstName.Should().Equals(createdContact?.FirstName);
			contact?.LastName.Should().Equals(createdContact?.LastName);
			Assert.IsTrue(contact.Phones.Any(c => c.Number == contact.Phones[0].Number));
			Assert.IsTrue(contact.Phones.Any(c => c.Number == contact.Phones[1].Number));
		}

	}
}
