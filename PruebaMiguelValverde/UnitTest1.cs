using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace PruebaMiguelValverde
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver Driver;

        public UnitTest1()
        {
            Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl("https://admin-sysnnova.com/OpenFact/Account/Login.aspx");
            Driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void Iniciar()
        {
            Login();
            AgregarCliente();
        }

        private void Login()
        {
            Driver.FindElement(By.Id("LoginUser_UserName")).SendKeys("demo");
            Driver.FindElement(By.Id("LoginUser_Password")).SendKeys("0430");
            Driver.FindElement(By.Id("LoginUser_LoginButton")).Click();
        }

        private void AgregarCliente()
        {
            try
            {
                //Seleccionar opcion de menu
                Driver.FindElement(By.Id("liClientes")).Click();

                //Click sobre boton nuevo cliente
                Driver.FindElement(By.Id("MainContent_btnAdd")).Click();

                //Tiempo de espera hasta que levante modal
                Thread.Sleep(1000);

                //Se llenan los campos del formulario
                Driver.FindElement(By.Id("MainContent_txtNombreCliente")).SendKeys("Miguel Valverde");
                
                var tipoIdent = Driver.FindElement(By.Id("MainContent_ddlTipoIdentificacion"));
                var selectElement = new SelectElement(tipoIdent);
                selectElement.SelectByText("Cédula");
                
                Driver.FindElement(By.Id("MainContent_txtIdentificacion")).SendKeys("0104292461");
                Driver.FindElement(By.Id("MainContent_txtTelefonoConvencional")).SendKeys("2222222222");
                Driver.FindElement(By.Id("MainContent_txtExtension")).SendKeys("333");
                Driver.FindElement(By.Id("MainContent_txtTelefonoCelular")).SendKeys("0921212121");
                Driver.FindElement(By.Id("MainContent_txtDireccion")).SendKeys("Direccion de domicilio");
                Driver.FindElement(By.Id("MainContent_txtMailDefecto")).SendKeys("correo1@dominio.com");
                Driver.FindElement(By.Id("MainContent_txtCorreosCopiaCliente")).SendKeys("correo2@dominio.com");
                
                Driver.FindElement(By.Id("MainContent_btnGuardarCliente")).Click();
                Thread.Sleep(1000);
                this.Driver.SwitchTo().Alert().Accept();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
