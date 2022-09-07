Feature: CrossBrowserTesting

A short summary of the feature

@tag1
Scenario: Cross-browser testing
	Given User is using browser <browserName>
	And navigate to Main page
	Then check main page title

	Examples: 
	| browserName   |
	| Google Chrome |
	| FireFox       |
	| Edge          |
