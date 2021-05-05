using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace NetUnitTest1
{
    [TestClass]
    public class UnitTest1
    {

        public string FirstName = "vpr";
        public string LastName = "vidapogosoft";

        public ChromeDriver driver = new ChromeDriver();

        [TestMethod]
        public void TestMethod1()
        {

            try
            {


                //Inicio el cliente de chrome

                //URL

                string url = "https://demoqa.com/automation-practice-form";

                //driver

               
               //----    //*[@id="header_logo"]/a/img


                driver = new ChromeDriver();

                //Open el web browser

                //Direcciona a la url
                driver.Navigate().GoToUrl(url);
                driver.Manage().Window.Maximize();


                //las esperas
                //explicita
                WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0,0,5));

                //Eventos hacia mis controles

                driver.FindElement(By.Id("firstName"));

                driver.FindElement(By.Id("firstName")).Click();

                driver.FindElement(By.Id("firstName")).SendKeys(FirstName);


                driver.FindElement(By.Id("lastName"));

                driver.FindElement(By.Id("lastName")).Click();

                driver.FindElement(By.Id("lastName")).SendKeys(LastName);


                driver.FindElement(By.Id("userEmail"));

                driver.FindElement(By.Id("userEmail")).Click();

                driver.FindElement(By.Id("userEmail")).SendKeys("vidapogosoft@gmail.com");


                driver.FindElement(By.Id("userNumber"));

                driver.FindElement(By.Id("userNumber")).Click();

                driver.FindElement(By.Id("userNumber")).SendKeys("0960574445");


                driver.FindElement(By.Id("currentAddress"));

                driver.FindElement(By.Id("currentAddress")).Click();

                driver.FindElement(By.Id("currentAddress")).SendKeys("Miraflores");


                //Click al boton

                driver.FindElement(By.Id("submit")).Click();
                //driver.FindElement(By.Id("submit")).SendKeys(Keys.Enter);


                //Cierro el Browser
                //driver.Close();

            }
            catch
            {
                ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;

                Screenshot screenshot = screenshotDriver.GetScreenshot();

                screenshot.SaveAsFile("C:/vidapogosoft/Cursos/2021/SIPECOM/Testing/code/" + DateTime.Now.Ticks.ToString() + ".png" , ScreenshotImageFormat.Png);

                driver.Quit();
            } 

        }

        public void TestMethod11()
        {
            Console.Write("Se invoco el metodo");

        }

    }
}
