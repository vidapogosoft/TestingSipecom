using System;
using TechTalk.SpecFlow;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Threading;

namespace BDDProject1.Steps
{
    [Binding]
    public class DataDriverOutlineSteps
    {

        public ChromeDriver driver = new ChromeDriver();
        public string URlLoginExitoso = "https://demoqa.com/profile";
        public string URlLoginValidar = "";


        [Given(@"Usuario se dirige a website demoqa.com/login")]
        public void GivenUsuarioSeDirigeAWebsiteDemoqa_ComLogin()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/login");

            driver.Manage().Window.Maximize();

        }
        
        [When(@"para ingresar digita su usuario (.*) y contraseña (.*)")]
        public void WhenParaIngresarDigitaSuUsuarioTestuser_YContrasenaTest(string user, string pwd )
        {
           
            driver.FindElement(By.Id("userName")).SendKeys(user);
            driver.FindElement(By.Id("password")).SendKeys(pwd);
        }
        
        [When(@"realiza click en boton Login para ingresar")]
        public void WhenRealizaClickEnBotonLoginParaIngresar()
        {

            Thread.Sleep(5000);

            driver.FindElement(By.Id("login")).Click();
        }
        
       
        [Then(@"Login correcto")]
        public void ThenLoginCorrecto()
        {
            Thread.Sleep(5000);

            URlLoginValidar = driver.Url;
            Assert.AreEqual(URlLoginExitoso, URlLoginValidar);
        }


        [AfterScenario("@mytag1")]
        [When(@"Usuario realiza Logout del site")]
        public void WhenUsuarioRealizaLogoutDelSite()
        {

            Thread.Sleep(5000);

            Console.WriteLine("Se Sale del web site");

        }

        [AfterScenario("@mytag1")]
        [Then(@"Salio de aplicacion web")]
        public void ThenSalioDeAplicacionWeb()
        {
            Thread.Sleep(5000);

            driver.Quit();
        }
    }
}
