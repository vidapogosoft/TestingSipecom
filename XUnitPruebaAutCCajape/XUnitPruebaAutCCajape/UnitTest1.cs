using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace XUnitPruebaAutCCajape
{
    public class UnitTest1 : IDisposable
    {
        public IWebDriver _driver = new ChromeDriver(@"D:\Users\ccajape\source\repos\XUnitPruebaAutCCajape\XUnitPruebaAutCCajape\bin\Debug\netcoreapp3.1\");
        public string url = "https://admin-sysnnova.com/OpenFact/Account/Login.aspx";
        private readonly string UserName = "LoginUser_UserName";
        private readonly string Contrasena = "LoginUser_Password";
        private readonly string BtnLogin = "LoginUser_LoginButton";
        private readonly string MCliente = "liClientes";
        private readonly string btnAdd = "MainContent_btnAdd";
        private readonly string txtNC = "MainContent_txtNombreCliente";
        private readonly string txtI = "MainContent_txtIdentificacion";
        private readonly string txtT = "MainContent_txtTelefonoConvencional";
        private readonly string txtD = "MainContent_txtDireccion";
        private readonly string txtCD = "MainContent_txtMailDefecto";
        private readonly string txtCC = "MainContent_txtCorreosCopiaCliente";
        private readonly string ddlTId = "MainContent_ddlTipoIdentificacion";
        private readonly string chkB = "MainContent_cbxEnviarBienvenida";
        private readonly string btnGuardar = "MainContent_btnGuardarCliente";
        private readonly string txtCel = "MainContent_txtTelefonoCelular";

        public UnitTest1()
        {
            ITakesScreenshot ScreenShotDrive = _driver as ITakesScreenshot;
            Screenshot screenshot = ScreenShotDrive.GetScreenshot();
            _driver.Navigate().GoToUrl(url);
            _driver.Manage().Window.Maximize();
        }

        public void Dispose()
        {
            //_driver.Quit();
        }

        [Theory]
        [InlineData("demo", "0430")]
        public void Login(string u, string p)
        {
            var txtUser = _driver.FindElement(By.Id(UserName));
            txtUser.Click();
            txtUser.SendKeys(u);
            var txtPwd = _driver.FindElement(By.Id(Contrasena));
            txtPwd.Click();
            txtPwd.SendKeys(p);
            var iniciarSesionElement = _driver.FindElement(By.Id(BtnLogin));
            iniciarSesionElement.Click();
            WebDriverWait wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 10));
            var liCliente = _driver.FindElement(By.Id(MCliente));
            liCliente.Click();
            Thread.Sleep(3000);
            WebDriverWait wai2t = new WebDriverWait(_driver, new TimeSpan(0, 0, 10));
            var Add = _driver.FindElement(By.Id(btnAdd));
            Add.Click();
            Thread.Sleep(2000);
            WebDriverWait wait3 = new WebDriverWait(_driver, new TimeSpan(0, 0, 10));
            var txtNmbre = _driver.FindElement(By.Id(txtNC));
            txtNmbre.Click();
            txtNmbre.SendKeys("CC");
            Thread.Sleep(2000);
            var txtIdent = _driver.FindElement(By.Id(txtI));
            txtIdent.Click();
            txtIdent.SendKeys("0931782544");
            Thread.Sleep(2000);
            var txtTelef = _driver.FindElement(By.Id(txtT));
            txtTelef.Click();
            txtTelef.SendKeys("5033392");
            Thread.Sleep(2000);
            var txtcel = _driver.FindElement(By.Id(txtCel));
            txtcel.Click();
            txtcel.SendKeys("0989983504");
            Thread.Sleep(2000);
            var tipo = _driver.FindElement(By.Id(ddlTId));
            var selectElement = new SelectElement(tipo);
            selectElement.SelectByValue("05");
            Thread.Sleep(2000);
            var txtdireccion = _driver.FindElement(By.Id(txtD));
            txtdireccion.Click();
            txtdireccion.SendKeys("GUAYAQUIL");
            Thread.Sleep(2000);
            var txtCorreodef = _driver.FindElement(By.Id(txtCD));
            txtCorreodef.Click();
            txtCorreodef.SendKeys("ejemplo@sipecom.com");
            Thread.Sleep(2000);
            var txtCorreocOP = _driver.FindElement(By.Id(txtCC));
            txtCorreocOP.Click();
            txtCorreocOP.SendKeys("ejemplo@sipecom.com");
            Thread.Sleep(2000);
            IWebElement check = _driver.FindElement(By.Id(chkB));
            check.Click();
            Thread.Sleep(2000);
            var AddCliente = _driver.FindElement(By.Id(btnGuardar));
            AddCliente.Click();
            Thread.Sleep(4000);
        }

    }
}
