using System;
using TechTalk.SpecFlow;

using TechTalk.SpecFlow.Assist;
using BDDProject1.Drivers;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

using System.Threading;

namespace BDDProject1.Steps
{
    [Binding]
    public class DataDriverTableSteps
    {
        public ChromeDriver driver = new ChromeDriver();
        public string URlLoginExitoso = "https://demoqa.com/profile";
        public string URlLoginValidar = "";


        [Given(@"Usuario ingresa a website demoqa.com/login")]
        public void GivenUsuarioIngresaAWebsiteDemoqa_ComLogin()
        {

            driver.Navigate().GoToUrl("https://demoqa.com/login");

            driver.Manage().Window.Maximize();

        }
        
        [When(@"digita sus credenciales de acceso")]
        public void WhenDigitaSusCredencialesDeAcceso(Table table)
        {

            var CredencialesAcceso = table.CreateInstance<Credenciales>();

            driver.FindElement(By.Id("userName")).SendKeys(CredencialesAcceso.Username);
            driver.FindElement(By.Id("password")).SendKeys(CredencialesAcceso.Password);

        }
        
        [When(@"realiza click en Login para ingresar")]
        public void WhenRealizaClickEnLoginParaIngresar()
        {
            Thread.Sleep(5000);
            driver.FindElement(By.Id("login")).Click();
        }
        
        
        [Then(@"Ingreso correcto")]
        public void ThenIngresoCorrecto()
        {
            Thread.Sleep(5000);

            URlLoginValidar = driver.Url;
            Assert.AreEqual(URlLoginExitoso, URlLoginValidar);
        }


        [AfterScenario("@mytag1")]
        [When(@"Usuario realiza Log out")]
        public void WhenUsuarioRealizaLogOut()
        {
            Thread.Sleep(5000);

            Console.WriteLine("Se Sale del web site");

        }


        [AfterScenario("@mytag1")]
        [Then(@"Salio")]
        public void ThenSalio()
        {
            Thread.Sleep(5000);

            driver.Quit();
        }
    }
}
