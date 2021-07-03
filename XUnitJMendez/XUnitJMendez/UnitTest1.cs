using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace XUnitJMendez
{
    public class UnitTest1 : IDisposable
    {
        public IWebDriver _driver = new ChromeDriver(@"C:\Users\jmendez\source\repos\XUnitJMendez\XUnitJMendez\bin\Debug\netcoreapp3.1\");
        public string url = "https://admin-sysnnova.com/OpenFact/Account/Login.aspx";

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
            IniciarSesion login = new IniciarSesion(_driver);
            login.IngresarUsuario(u);
            login.IngresarPassword(p);
            login.Iniciar();
            login.Clientes();
            login.ClickAgregarCliente();
            login.AgregarCliente("Jaime Méndez", "0953699808", "04266753", "0999999999", "05", "Durán", "jmendez@sipecom.com", "jmendez@sipecom.com");
        }
    }
}
