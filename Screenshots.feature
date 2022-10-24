Feature: Screenshots

UI testing using screenshots

@tag1
Scenario: Test Screenshot
	Given user is on the <page>
	When Take a screenshot of the <page>
	Then compare the screenshot page of the <page>

	Examples: 
	| page       |
	| Main page  |
	| Login page |
	| Basket Page |
