using Microsoft.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace SteevenAriasUnTest
{
    [TestClass]
    public class UnitTest
    {
        private IWebDriver Driver;

        public UnitTest()
        {
            Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl("https://admin-sysnnova.com/OpenFact/Account/Login.aspx");
            Driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void Login()
        {
            try
            {
                IniciarSesion("demo", "0430");
                IngresarModuloCliente();
                AgregarNuevoCliente();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void IniciarSesion(string usuario, string password)
        {
            Driver.FindElement(By.Id("LoginUser_UserName")).SendKeys(usuario);
            Driver.FindElement(By.Id("LoginUser_Password")).SendKeys(password);

            Thread.Sleep(5000);

            Driver.FindElement(By.Id("LoginUser_LoginButton")).Click();
        }

        private void IngresarModuloCliente()
        {
            try
            {
                Driver.FindElement(By.Id("liClientes")).Click();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void AgregarNuevoCliente()
        {
            try
            {
                Driver.FindElement(By.Id("MainContent_btnAdd")).Click();

                Thread.Sleep(5000);

                Driver.FindElement(By.Id("MainContent_txtNombreCliente")).SendKeys("SAT");
                Driver.FindElement(By.Id("MainContent_txtIdentificacion")).SendKeys("1302037690");
                Driver.FindElement(By.Id("MainContent_txtTelefonoConvencional")).SendKeys("2225222");
                Driver.FindElement(By.Id("MainContent_txtExtension")).SendKeys("153");
                Driver.FindElement(By.Id("MainContent_txtTelefonoCelular")).SendKeys("0965898745");
                Driver.FindElement(By.Id("MainContent_txtDireccion")).SendKeys("Malecon y 9 de Octubre");
                Driver.FindElement(By.Id("MainContent_txtMailDefecto")).SendKeys("sat@gmail.com");
                Driver.FindElement(By.Id("MainContent_txtCorreosCopiaCliente")).SendKeys("copia@gmail.com");
                var tipoIdent = Driver.FindElement(By.Id("MainContent_ddlTipoIdentificacion"));
                var selectElement = new SelectElement(tipoIdent);
                selectElement.SelectByText("Cédula");
                Thread.Sleep(3000);
                Driver.FindElement(By.Id("MainContent_btnGuardarCliente")).Click();
                Thread.Sleep(3000);
                this.Driver.SwitchTo().Alert().Accept();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
