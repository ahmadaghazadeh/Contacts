using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using ReadModel.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactContext.Application.Contract.Contacts;
using Microsoft.EntityFrameworkCore;

namespace ContactContext.Acceptance.Test.Drivers
{
	

	public class ContactDriver
	{

		private readonly ContactReadDbContext readContext;
		private readonly HttpClient _httpClient;
		private string _apiUrl = "contact";

		public ContactDriver(CustomWebApplicationFactory factory)
		{
			var scope = factory.Services.CreateScope();
			_httpClient = factory.CreateClient();
			this.readContext = scope.ServiceProvider.GetRequiredService<ContactReadDbContext>(); ;
		}

		public async Task<HttpResponseMessage> CreteContactViaApi(CreateContactCommand command)
		{
			var requestMessage = new HttpRequestMessage(HttpMethod.Post, _apiUrl);

			requestMessage.Content = new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json");

			return await _httpClient.SendAsync(requestMessage);
		}

		public Contact? GetContact(string firstName, string lastName)
		{
			return readContext.Contacts
				.Include(c=> c.Phones)
				.FirstOrDefault(c => c.FirstName == firstName 
				&& c.LastName == lastName);
		}

		public async Task<HttpResponseMessage> UpdateContact(UpdateContactCommand command)
		{
			var requestMessage = new HttpRequestMessage(HttpMethod.Put, $"{_apiUrl}/{command.LastName}/{command.FirstName}");

			requestMessage.Content = new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json");

			return await _httpClient.SendAsync(requestMessage);
		}

		public async Task<HttpResponseMessage> DeleteContact(DeleteContactCommand delete)
		{
			var requestMessage = new HttpRequestMessage(HttpMethod.Delete, $"{_apiUrl}/{delete.LastName}/{delete.FirstName}");

			return await _httpClient.SendAsync(requestMessage);
		}

		public bool CheckCustomerExist(string firstName, string lastName)
		{
			return readContext.Contacts
				.Any(c => c.FirstName == firstName
				          && c.LastName == lastName);
		}

		public List<Contact> GetContacts()
		{
			return readContext.Contacts.ToList();
		}
	}
}
