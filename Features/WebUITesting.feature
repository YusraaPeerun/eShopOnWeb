Feature: Sucessfully Login

Testing the log in page of the eshopOnWeb website

@tag1
Scenario: Sucessfully Login with email add:demouser@microsoft.com and password:Pass@word1
	Given User is on log in page
	And User enters email address demouser@microsoft.com
	And User enters Password Pass@word1
	When click on the Log in button 
	Then directed to the main page
	And We should see the email address demouser@microsoft.com on top

Scenario: Sucessfully Login with email add:admin@microsoft.com and password:Pass@word1
	Given User is on log in page
	And User enters email address admin@microsoft.com
	And User enters Password Pass@word1
	When click on the Log in button 
	Then directed to the main page
	And We should see the email address admin@microsoft.com on top