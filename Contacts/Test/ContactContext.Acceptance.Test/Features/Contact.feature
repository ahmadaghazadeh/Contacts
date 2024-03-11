Feature: ContactManager

Scenario:  Adding a New Contact Successfully
Given a customer with the following details:
"""
		{
		"FirstName":"Ahmad",
		"LastName":"Aghazadeh",
		"Phones":
			[
				{
					"Type":"Mobile",
					"Number":"09352185069"
				},
				{
					"Type":"Mobile",
					"Number":"09352185059"
				}
			]
		}
"""
When send a request to create the Contact
Then status code should be '200'
And should have my Contact with following
"""
{
		"FirstName":"Ahmad",
		"LastName":"Aghazadeh",
		"Phones":
		[
			{
				"Type":"Mobile",
				"Number":"09352185069"
			},
			{
				"Type":"Mobile",
				"Number":"09352185069"
			}
		]
		}
"""
 

Scenario:  Creating a new Contact with Invalid PhoneNumber
Given a customer with the following details:
"""
{
		"FirstName":"Ahmad",
		"LastName":"Aghazadeh",
		"Phones":
		[
			{
				"Type":"Mobile",
				"Number":"093521"
			}
		]
		}
"""
When send a request to create the Contact
Then status code should be BadRequest
And the error message should be "Phone Number Invalid Format Exception"