Feature: IntegrationTests
	In order to test the functionality of the plugin
	I want to test whether SimpleInjector is used to resolve dependencies


Scenario Outline: Add two numbers
	Given I have entered <operand1> into the calculator
	And I have entered <operand2> into the calculator
	When I press add
	Then the result should be <result> on the screen

	Examples: 
	 | operand1 | operand2 | result |
	 | 50       | 70       | 120    |
	 | 3        | 33       | 36     |
