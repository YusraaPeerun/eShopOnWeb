Feature: InvalidLogin

In this features we will test for different invalid log in

@tag1
Scenario: Enter an incorrect email address and correct password
	Given User is on log in page
	And User enters email address demouse@microsoft.com
	And User enters Password Pass@word1
	When click on the Log in button 
	Then Error message Invalid login attempt. appears
	And Field Email is not blanked out
	And Field Password is blanked out

Scenario: Enter incorrect email address but do not enter password
	Given User is on log in page
	And User enters email address demouse@microsoft.com
	When click on the Log in button 
	Then Error message The Password field is required. appears
	And Another error message appears below the field Password: The Password field is required.
	And Field Email is not blanked out
	And Field Password is blanked out

Scenario: Enter a correct email address but no password
	Given User is on log in page
	And User enters email address demouser@microsoft.com
	When click on the Log in button 
	Then Error message The Password field is required. appears
	And Another error message appears below the field Password: The Password field is required.
	And Field Email is not blanked out
	And Field Password is blanked out

Scenario: do not enter email but enter a valid password
	Given User is on log in page
	And User enters Password Pass@word1
	When click on the Log in button 
	Then Error message The Email field is required. appears
	And Another error message appears below the field Email: The Email field is required.
	And Field Email is blanked out
	And Field Password is not blanked out

Scenario: do not enter email and enter an invalid password
	Given User is on log in page
	And User enters Password Pass@wor
	When click on the Log in button 
	Then Error message The Email field is required. appears
	And Another error message appears below the field Email: The Email field is required.
	And Field Email is blanked out
	And Field Password is not blanked out
	
Scenario: Do not enter email and password
	Given User is on log in page
	When click on the Log in button 
	Then Error message The Email field is required. appears
	Then Error message The Password field is required. appears
	And Another error message appears below the field Email: The Email field is required.
	And Another error message appears below the field Password: The Password field is required.
	And Field Email is blanked out
	And Field Password is blanked out
