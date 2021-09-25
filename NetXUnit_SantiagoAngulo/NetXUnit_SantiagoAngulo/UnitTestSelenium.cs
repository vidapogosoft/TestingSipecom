using System;
using System.Threading;

using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace NetXUnit1
{
    public class UnitTestSelenium : IDisposable
    {

        private IWebDriver _driver;

        public UnitTestSelenium()
        {

            _driver = new ChromeDriver();

            _driver.Navigate().GoToUrl("https://admin-sysnnova.com/OpenFact/Account/Login.aspx");

            _driver.Manage().Window.Maximize();

        }

        public void Dispose()
        {
            _driver.Quit();

        }

        [Theory]
        [InlineData("demo", "0430")]

        public void Login(string u, string p)
        {
            IniciarSesion login = new IniciarSesion(_driver);

            login.IngresarUsuario(u);
            login.IngresarPassword(p);

            Thread.Sleep(3000);
            login.Iniciar();

            Thread.Sleep(3000);

            RegistroCliente oRegistro = new RegistroCliente(_driver);
            oRegistro.Registar();

            Thread.Sleep(3000);

            var actual = _driver.Url;

            //Assert.Equal("https://admin-sysnnova.com/OpenFact/Default.aspx", actual);
        }


    }
}
