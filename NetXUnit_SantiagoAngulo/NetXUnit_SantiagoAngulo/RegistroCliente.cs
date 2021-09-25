using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace NetXUnit1
{
    public class RegistroCliente
    {
        private readonly string Menu = "liClientes";
        private readonly string BtnAgregar = "MainContent_btnAdd";
        private readonly string ListTipoIdentificacion = "MainContent_ddlTipoIdentificacion";
        private readonly string ChkBienvenida = "MainContent_cbxEnviarBienvenida";
        private readonly string BtnGuardar = "MainContent_btnGuardarCliente";


        private IWebDriver _driver;

        public RegistroCliente(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Registar()
        {            
            try
            {
                var clientesLi = _driver.FindElement(By.Id(Menu));
                clientesLi.Click();

                Thread.Sleep(3000);

                var addClienteBtn = _driver.FindElement(By.Id(BtnAgregar));
                addClienteBtn.Click();

                Thread.Sleep(3000);

                var txtNombreCliente = _driver.FindElement(By.Id("MainContent_txtNombreCliente"));
                txtNombreCliente.SendKeys("Santiago Angulo");

                Thread.Sleep(2000);

                var ddlTipoIdentificacion = _driver.FindElement(By.Id(ListTipoIdentificacion));
                var tipoIdenSelect = new SelectElement(ddlTipoIdentificacion);
                tipoIdenSelect.SelectByValue("04");

                Thread.Sleep(2000); 

                var txtIdentificacion = _driver.FindElement(By.Id("MainContent_txtIdentificacion"));
                txtIdentificacion.SendKeys("0924740566001");

                Thread.Sleep(2000);

                var txtTelefonoConvencional = _driver.FindElement(By.Id("MainContent_txtTelefonoConvencional"));
                txtTelefonoConvencional.SendKeys("044223344");

                Thread.Sleep(2000);

                var txtTelefonoCelular = _driver.FindElement(By.Id("MainContent_txtTelefonoCelular"));
                txtTelefonoCelular.SendKeys("099223344");

                Thread.Sleep(2000);

                var txtDireccion = _driver.FindElement(By.Id("MainContent_txtDireccion"));
                txtDireccion.SendKeys("Malecón y Padre Aguirre");

                Thread.Sleep(2000);

                var txtMailDefecto = _driver.FindElement(By.Id("MainContent_txtMailDefecto"));
                txtMailDefecto.SendKeys("envio.notificacion.svap@gmail.com");

                Thread.Sleep(2000);

                //var chkBienvenida = _driver.FindElement(By.Id(ChkBienvenida));
                //chkBienvenida.Click();

                //Thread.Sleep(2000);

                var guardarBtn = _driver.FindElement(By.Id("MainContent_btnGuardarCliente"));
                guardarBtn.Click();

                Thread.Sleep(5000);

                var itsTomarCaptura = _driver as ITakesScreenshot;
                var path = Environment.CurrentDirectory;
                var file = "RegistroExitoso_" + DateTime.Now.ToString("yyyy-MM-dd_hhmmss") + ".png";
                var captura = Path.Combine(path, file);
                var oScreenshot = itsTomarCaptura.GetScreenshot();
                oScreenshot.SaveAsFile(captura, ScreenshotImageFormat.Png);

                file = "ConsultaPrincipal_" + DateTime.Now.ToString("yyyy-MM-dd_hhmmss") + ".png";
                captura = Path.Combine(path, file);
                oScreenshot.SaveAsFile(captura, ScreenshotImageFormat.Png);

                Thread.Sleep(2000); 
            }
            catch (Exception ex)
            {
                throw new Exception("Error en registro de cliente: " + ex.Message);
            }

        }


    }
}
