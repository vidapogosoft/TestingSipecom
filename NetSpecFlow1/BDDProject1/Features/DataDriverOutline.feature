Feature: DataDriverOutline
	Login en web site Demo QA 2

@mytag1
Scenario Outline: Login Exitoso con parametros
	Given Usuario se dirige a website demoqa.com/login 
	When para ingresar digita su usuario <username> y contraseña <password>  
	And realiza click en boton Login para ingresar
	Then Login correcto

	Examples: 
	| username   | password |
	| testuser_1 | Test@123 |
	| testuser_2 | Test@153 |


@mytag2
Scenario: Salir de web site
	When Usuario realiza Logout del site
	Then Salio de aplicacion web