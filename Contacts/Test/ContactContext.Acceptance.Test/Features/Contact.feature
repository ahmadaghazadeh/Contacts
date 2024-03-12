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
					"Number":"09352185059"
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



Scenario:  Update a Contact Successfully
Given Have a Contact with the following details:
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
And Prepare the Contact with the following details
"""
		{
		"FirstName":"Ahmad",
		"LastName":"Aghazadeh",
		"Phones":
			[
				{
					"Type":"Mobile",
					"Number":"09352185070"
				},
				{
					"Type":"Mobile",
					"Number":"09352185055"
				}
			]
		}
"""
When send a request update the Contact
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
				"Number":"09352185070"
			},
			{
				"Type":"Mobile",
				"Number":"09352185055"
			}
		]
		}
"""




Scenario:  Delete a Contact Successfully
Given Have a Contact with the following details:
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
When send a request to delete the Contact with firstName "Ahmad" and lastName "Aghazadeh"
Then status code should be '200'
And should dont find the Contact with firstName "Ahmad" and lastName "Aghazadeh"



Scenario:  Get Two Contacts Successfully
Given Have several Contacts with the following details:
		"""
		  [{
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
			},
			{
			"FirstName":"Arad",
			"LastName":"Aghazadeh",
			"Phones":
				[
					{
						"Type":"Mobile",
						"Number":"09303977077"
					} 
				]
			}
			]
		"""
When send several requests to create the Contacts
Then should have Contacts with following
		"""
		  [{
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
			},
			{
			"FirstName":"Arad",
			"LastName":"Aghazadeh",
			"Phones":
				[
					{
						"Type":"Mobile",
						"Number":"09303977077"
					} 
				]
			}
			]
		"""
  
