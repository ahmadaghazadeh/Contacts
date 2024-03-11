namespace ReadModel.Application.Contract.Contacts.Dto;

public class ContactDto
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public List<ContactPhoneDto> Phones { get; set; }
}