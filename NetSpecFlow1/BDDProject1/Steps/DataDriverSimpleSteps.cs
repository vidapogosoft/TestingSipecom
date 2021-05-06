using System;
using TechTalk.SpecFlow;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Threading;

namespace BDDProject1.Steps
{
    [Binding]
    public class DataDriverSimpleSteps
    {

        public ChromeDriver driver = new ChromeDriver();
        public string URlLoginExitoso = "https://demoqa.com/profile";
        public string URlLoginValidar = "";

        [Given(@"Usuario se dirige a web site demoqa.com/login")]
        public void GivenUsuarioSeDirigeAWebSiteDemoqa_ComLogin()
        {

           //driver = new ChromeDriver();

           driver.Navigate().GoToUrl("https://demoqa.com/login");

            driver.Manage().Window.Maximize();

        }
        
        [When(@"usuario ingresa credenciales")]
        public void WhenUsuarioIngresaCredenciales()
        {

            driver.FindElement(By.Id("userName")).SendKeys("testuser_1");
            driver.FindElement(By.Id("password")).SendKeys("Test@123");

        }


        [When(@"realiza click en boton Login")]
        public void WhenRealizaClickEnBotonLogin()
        {
            Thread.Sleep(5000);

            driver.FindElement(By.Id("login")).Click();

        }

        
        [Then(@"Login es exitoso")]
        public void ThenLoginEsExitoso()
        {

            Thread.Sleep(5000);

            URlLoginValidar = driver.Url;
            Assert.AreEqual(URlLoginExitoso, URlLoginValidar);

        }


        [AfterScenario("@mytag1")]
        [When(@"Usuario realiza Logout")]
        public void WhenUsuarioRealizaLogout()
        {
            Thread.Sleep(5000);

            Console.WriteLine("Se Sale del web site");
            //driver.FindElement(By.CssSelector("#submit")).Click();

        }

        [AfterScenario("@mytag1")]
        [Then(@"Salio de aplicacion")]
        public void ThenSalioDeAplicacion()
        {
           
            //driver.Close();

            Thread.Sleep(5000);
            
            driver.Quit();
            
        }
    }
}
