Feature: Sucessfully Login

Testing the log in page of the eshopOnWeb website

@get
Scenario: Sucessfully Login with email add:demouser@microsoft.com and password:Pass@word1
	Given User is on log in page
	And User enters email address <email>
	And User enters Password <password>
	When click on the Log in button 
	Then directed to the main page
	And We should see the email address <email> on top
Examples: 
| email               | password   |
| admin@microsoft.com | Pass@word1 |
| demouser@microsoft.com | Pass@word1 |
