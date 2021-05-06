Feature: DataDriverSimple
	Login en web site Demo QA

@mytag1
Scenario: Login Exitoso
	Given Usuario se dirige a web site demoqa.com/login
	When usuario ingresa credenciales
	And realiza click en boton Login
	Then Login es exitoso

@mytag2
Scenario: Salir
	When Usuario realiza Logout
	Then Salio de aplicacion