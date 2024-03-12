using Azure;
using ContactContext.Application.Contract.Contacts;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;
using ContactContext.Acceptance.Test.Drivers;
using ContactContext.Acceptance.Test.Models;

namespace ContactContext.Acceptance.Test.StepDefinitions
{
	[Binding]
	public sealed class ContactStepDefinitions
	{
		// For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

		ContactDriver driver;
		private CreateContactCommand createCommand;
		private List<CreateContactCommand> createCommands;
		private UpdateContactCommand updateCommand;
		private HttpResponseMessage response;


		public ContactStepDefinitions(ContactDriver driver)
		{
			this.driver = driver;
		}

		[Given(@"a customer with the following details:")]
		public void GivenACustomerWithTheFollowingDetails(string contact)
		{
			createCommand = JsonSerializer.Deserialize<CreateContactCommand>(contact);
		}

		[When(@"send a request to create the Contact")]
		public async Task WhenSendARequestToCreateTheContact()
		{
			response = await driver.CreteContactViaApi(createCommand);
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
			Assert.IsTrue(createdContact.Phones.Any(c => c.Number == contact?.Phones[0].Number));
			Assert.IsTrue(createdContact.Phones.Any(c => c.Number == contact?.Phones[1].Number));
		}


		[Then(@"status code should be BadRequest")]
		public void ThenStatusCodeShouldBeBadRequest()
		{
			response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
		}

		[Then(@"the error message should be ""([^""]*)""")]
		public async Task ThenTheErrorMessageShouldBeAsync(string expectedMessage)
		{
			var content = await response.Content.ReadAsStringAsync();

			var myClass = JsonSerializer.Deserialize<MyException>(content);

			Assert.AreEqual(expectedMessage, myClass.Message);
		}

		[Given(@"Have a Contact with the following details:")]
		public async Task GivenHaveAContactWithTheFollowingDetailsAsync(string contactJson)
		{
			var contact = JsonSerializer.Deserialize<CreateContactCommand>(contactJson);

			response =await driver.CreteContactViaApi(contact);
		}



		[Given(@"Prepare the Contact with the following details")]
		public async Task GivenPrepareTheContactWithTheFollowingDetails(string contactJson)
		{
			updateCommand = JsonSerializer.Deserialize<UpdateContactCommand>(contactJson);


		}

		[When(@"send a request update the Contact")]
		public async Task WhenSendARequestUpdateTheContactAsync()
		{
			response = await driver.UpdateContact(updateCommand);
		}


		[When(@"send a request to delete the Contact with firstName ""([^""]*)"" and lastName ""([^""]*)""")]
		public async Task WhenSendARequestToDeleteTheContactWithFirstNameAndLastNameAsync(string firstName, string lastName)
		{
			var deleteCommand= new DeleteContactCommand()
			{
				FirstName = firstName,
				LastName = lastName

			};
			response =await driver.DeleteContact(deleteCommand);
		}

		[Then(@"should dont find the Contact with firstName ""([^""]*)"" and lastName ""([^""]*)""")]
		public void ThenShouldDontFindTheContactWithFirstNameAndLastName(string firstName, string lastName)
		{
			var createdContact = driver.CheckCustomerExist(firstName, lastName);
			Assert.IsFalse(createdContact);
		}

		[Given(@"Have several Contacts with the following details:")]
		public void GivenHaveSeveralContactsWithTheFollowingDetails(string contactsJson)
		{
			createCommands = JsonSerializer.Deserialize<List<CreateContactCommand>>(contactsJson);
		}

		[When(@"send several requests to create the Contacts")]
		public async Task WhenSendSeveralRequestsToCreateTheContacts()
		{
			foreach (var contact in createCommands)
			{
				await driver.CreteContactViaApi(contact);
			}
		}

		[Then(@"should have Contacts with following")]
		public void ThenShouldHaveContactsWithFollowing(string contactsJson)
		{
			var expectedContacts = JsonSerializer.Deserialize<List<CreateContactCommand>>(contactsJson);
			var contacts= driver.GetContacts();

			Assert.IsTrue(contacts.Any(c => c.FirstName == expectedContacts[0].FirstName
			&& c.LastName== expectedContacts[0].LastName));

			Assert.IsTrue(contacts.Any(c => c.FirstName == expectedContacts[1].FirstName
			                                && c.LastName == expectedContacts[1].LastName));
		}

	}
}
