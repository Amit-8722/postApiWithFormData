Feature: createForm
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: Create a form
	When I request to create a form
	Then I get back 200 response

Scenario: Create a form without file
	When I request to create a form without file
	Then I get back 200 response
