using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace NetTestSelenium
{
    public class TestSysnNova
    {
        #region Constantes

        private const string LOGIN_URL = "https://admin-sysnnova.com/OpenFact/Account/Login.aspx";
        private const string LOGIN_USER = "demo";
        private const string LOGIN_PASSWORD = "0430";

        private const string DEFAULT_URL = "https://admin-sysnnova.com/OpenFact/Default.aspx";

        #endregion

        #region Miembros

        private IWebDriver m_driver;
        private ITakesScreenshot m_screenshotDriver;

        #endregion

        #region Constructores

        public TestSysnNova()
        {
            m_driver = new ChromeDriver();
            m_screenshotDriver = m_driver as ITakesScreenshot;
        }

        #endregion

        #region Metodos privados

        private void TakeScreenShot(string nombreImagen)
        {
            //var appDir = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            var appDir = Environment.CurrentDirectory;
            var imgNom = nombreImagen + DateTime.Now.Ticks.ToString() + ".png";
            var imgPath = Path.Combine(appDir, imgNom);

            var screenshot = m_screenshotDriver.GetScreenshot();

            screenshot.SaveAsFile(imgPath, ScreenshotImageFormat.Png);
        }

        private void SendKeys(string elementoId, string valor)
        {
            var element = m_driver.FindElement(By.Id(elementoId));
            element.Click();
            element.SendKeys(valor);
        }

        private void Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }

        #endregion

        #region Metodos inicializacion y destruccion

        [SetUp]
        public void Setup()
        {
            m_driver.Navigate().GoToUrl(LOGIN_URL);
            m_driver.Manage().Window.Maximize();
            //m_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TearDown]
        public void Teardown()
        {
            if (m_driver != null)
            {
                m_driver.Quit();
            }
        }

        #endregion

        #region Metodos de pruebas

        [Test]
        public void Registro()
        {
            try
            {
                TakeScreenShot("Inicio");

                SendKeys("LoginUser_UserName", LOGIN_USER);
                SendKeys("LoginUser_Password", LOGIN_PASSWORD);

                var loginBtn = m_driver.FindElement(By.Id("LoginUser_LoginButton"));
                loginBtn.Click();

                TakeScreenShot("LogueoOK");

                Wait(10);

                //Assert.AreEqual(DEFAULT_URL, m_driver.Url);

                var clientesLi = m_driver.FindElement(By.Id("liClientes"));
                clientesLi.Click();

                Wait(5);

                var addClienteBtn = m_driver.FindElement(By.Id("MainContent_btnAdd"));
                addClienteBtn.Click();

                Wait(5);

                SendKeys("MainContent_txtNombreCliente", "Juan Montiel");

                Wait(2);

                var tipoIdentDdl = m_driver.FindElement(By.Id("MainContent_ddlTipoIdentificacion"));
                var tipiIdentSelect = new SelectElement(tipoIdentDdl);
                tipiIdentSelect.SelectByValue("05");

                Wait(2);

                //SendKeys("MainContent_txtIdentificacion", "0925147858");
                //SendKeys("MainContent_txtIdentificacion", "0919172551");
                SendKeys("MainContent_txtIdentificacion", "0920010105");
                Wait(2);
                SendKeys("MainContent_txtTelefonoConvencional", "042528987");
                Wait(2);
                SendKeys("MainContent_txtMailDefecto", "jmontiel.sipecom@gmail.com");
                Wait(2);

                var bienvenidaCheck = m_driver.FindElement(By.Id("MainContent_cbxEnviarBienvenida"));
                bienvenidaCheck.Click();

                Wait(2);

                var guardarBtn = m_driver.FindElement(By.Id("MainContent_btnGuardarCliente"));
                guardarBtn.Click();

                Wait(5);

                TakeScreenShot("ProcesoOk");

            }
            catch (UnhandledAlertException uae)
            {
                //Manejamos alerta inesperada
                try
                {
                    var alert = m_driver.SwitchTo().Alert();
                    alert.Dismiss();
                }
                catch (NoAlertPresentException ex)
                {
                    Console.WriteLine("No hay alerta presente");
                }

                Wait(5);

                TakeScreenShot("ProcesoOk");

            }
            catch (Exception ex)
            {
                TakeScreenShot("Error");
                Assert.Fail(ex.Message);
            }

        }

        #endregion
    }
}
