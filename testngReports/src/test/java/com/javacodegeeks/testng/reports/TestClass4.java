package com.javacodegeeks.testng.reports;

import org.testng.Reporter;
import org.testng.annotations.Test;

public class TestClass4 {

	@Test
	public void e1() {
	}
	
	@Test
	public void e2() {
		Reporter.log("Method name is e2");
	}	
}
