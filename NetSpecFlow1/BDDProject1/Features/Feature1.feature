Feature: Feature1
	Suma de dos numeros simulando una calculadora

@mytag
Scenario: Suma de dos numeros
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

@mytag
Scenario: Suma de tres numeros
	Given primer numero es 50
	And segundo numero es 70
	And tercer numero es 30
	When se procede con al suma
	Then el resulatado es 150