Feature: User Form
	Feature which holds all the user details entry

@mytag
Scenario: User Details form entry verification
	#Given I navigate to application
	#And I enter username and password
	#	| UserName | Password |
	#	| admin    | admin    |
	#And I click login
	#And I start entering user form details like
	#	| Initial | FirstName | MiddleName |
	#	| k      | Karthik   |   k         |
	#And I click submit button
	And I verify the entered user form details in the application database
		| Initial | FirstName | MiddleName |
		| k      | Karthik   |   k         |
