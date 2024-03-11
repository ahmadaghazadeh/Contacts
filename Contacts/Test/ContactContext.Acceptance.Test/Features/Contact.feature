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
 
