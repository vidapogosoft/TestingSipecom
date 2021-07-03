using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace XUnitJMendez
{
    public class IniciarSesion
    {
		//Variables globales
        private readonly string User = "LoginUser_UserName";
        private readonly string Password = "LoginUser_Password";
        private readonly string Login = "LoginUser_LoginButton";
        private readonly string MenuCliente = "liClientes";
        private readonly string btnAdd = "MainContent_btnAdd";
        private readonly string txtNombreCliente = "MainContent_txtNombreCliente";
        private readonly string txtIdentificacion = "MainContent_txtIdentificacion";
        private readonly string txtTelefono = "MainContent_txtTelefonoConvencional";
        private readonly string txtDireccion = "MainContent_txtDireccion";
        private readonly string txtCorreoDefecto = "MainContent_txtMailDefecto";
        private readonly string txtCorreoCopia = "MainContent_txtCorreosCopiaCliente";
        private readonly string ddlTipoIdent = "MainContent_ddlTipoIdentificacion";
        private readonly string chkBienvenuda = "MainContent_cbxEnviarBienvenida";
        private readonly string btnGuardarCliente = "MainContent_btnGuardarCliente";
        private readonly string txtCelular = "MainContent_txtTelefonoCelular";

        private IWebDriver _driver;

        public IniciarSesion(IWebDriver driver)
        {
            _driver = driver;
        }

        public void IngresarUsuario(string user)
        {
            var txtUser = _driver.FindElement(By.Id(User));
            txtUser.Click();
            txtUser.SendKeys(user);
        }

        public void IngresarPassword(string pass)
        {
            var txtPwd = _driver.FindElement(By.Id(Password));
            txtPwd.Click();
            txtPwd.SendKeys(pass);
        }

        public void Iniciar()
        {
            var iniciarSesionElement = _driver.FindElement(By.Id(Login));
            iniciarSesionElement.Click();
        }

        public void Clientes()
        {
            WebDriverWait wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 10));
            var liCliente = _driver.FindElement(By.Id(MenuCliente));
            liCliente.Click();
            Thread.Sleep(3000);
        }

        public void ClickAgregarCliente()
        {
            WebDriverWait wai2t = new WebDriverWait(_driver, new TimeSpan(0, 0, 10));
            var Add = _driver.FindElement(By.Id(btnAdd));
            Add.Click();
            Thread.Sleep(2000);
        }

        public void AgregarCliente(string nombre, string identificacion, string telefono, string celular, string tipoIdent, string direccion, 
            string correodefecto, string correoCopia)
        {
            WebDriverWait wait3 = new WebDriverWait(_driver, new TimeSpan(0, 0, 10));
            var txtNmbre = _driver.FindElement(By.Id(txtNombreCliente));
            txtNmbre.Click();
            txtNmbre.SendKeys(nombre);
            Thread.Sleep(2000);
            var txtIdent = _driver.FindElement(By.Id(txtIdentificacion));
            txtIdent.Click();
            txtIdent.SendKeys(identificacion);
            Thread.Sleep(2000);
            var txtTelef = _driver.FindElement(By.Id(txtTelefono));
            txtTelef.Click();
            txtTelef.SendKeys(telefono);
            Thread.Sleep(2000);
            var txtcel = _driver.FindElement(By.Id(txtCelular));
            txtcel.Click();
            txtcel.SendKeys(celular);
            Thread.Sleep(2000);
            var tipo = _driver.FindElement(By.Id(ddlTipoIdent));
            var selectElement = new SelectElement(tipo);
            selectElement.SelectByValue(tipoIdent);
            Thread.Sleep(2000);
            var txtdireccion = _driver.FindElement(By.Id(txtDireccion));
            txtdireccion.Click();
            txtdireccion.SendKeys(direccion);
            Thread.Sleep(2000);
            var txtCorreodef = _driver.FindElement(By.Id(txtCorreoDefecto));
            txtCorreodef.Click();
            txtCorreodef.SendKeys(correodefecto);
            Thread.Sleep(2000);
            var txtCorreocOP = _driver.FindElement(By.Id(txtCorreoCopia));
            txtCorreocOP.Click();
            txtCorreocOP.SendKeys(correoCopia);
            Thread.Sleep(2000);
            IWebElement check = _driver.FindElement(By.Id(chkBienvenuda));
            check.Click();
            Thread.Sleep(2000);
            var Add = _driver.FindElement(By.Id(btnGuardarCliente));
            Add.Click();
            Thread.Sleep(4000);
        }
    }
}
