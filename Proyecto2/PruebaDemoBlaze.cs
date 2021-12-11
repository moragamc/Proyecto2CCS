using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace Proyecto2
{
    [TestFixture(typeof(EdgeDriver))]
    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(FirefoxDriver))]
    public class PruebaDemoBlaze<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        //Declaración de variables

        public IWebDriver Driver { get; private set; }

        internal IWebDriver ObtengaElDriverFirefox()
        {
            FirefoxOptions opcionesDelNavegador = new FirefoxOptions();
            opcionesDelNavegador.AcceptInsecureCertificates = true;
            //opcionesDelNavegador.AddArgument("--private");
            Driver = new FirefoxDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), opcionesDelNavegador);
            return Driver;
        }

        internal IWebDriver ObtengaElDriverChrome()
        {
            ChromeOptions opcionesDeChrome = new ChromeOptions();
            opcionesDeChrome.AddArguments("incognito");
            Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), opcionesDeChrome);
            return Driver;
        }

        internal IWebDriver ObtengaElDriverEdge()
        {
            EdgeOptions edgeOptions = new EdgeOptions();
            edgeOptions.AddArgument("disable-gpu");
            Driver = new EdgeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), edgeOptions);
            return Driver;
        }

        [SetUp]
        public void SetUp()
        {
            if (typeof(TWebDriver).Name == "FirefoxDriver")
            {
                Driver = ObtengaElDriverFirefox();
            }
            else if (typeof(TWebDriver).Name == "ChromeDriver")
            {
                ObtengaElDriverChrome();
            }
            else if (typeof(TWebDriver).Name == "EdgeDriver")
            {
                Driver = ObtengaElDriverEdge();
            }
            else
            {
                Driver = new TWebDriver();
            }

            Driver.Navigate().GoToUrl("https://www.demoblaze.com/index.html");
        }
        [TearDown]
        protected void TearDown()
        {
            if (Driver != null) Driver.Quit();
        }

        //Nuevo Sitio

        [Test]
        public void Navegacion_por_categorias()
        {
            try
            {
                //Act
                Driver.FindElement(By.Id("itemc")).Click();
                Thread.Sleep(1000);
                Driver.FindElement(By.LinkText("Laptops")).Click();
                Thread.Sleep(1000);
                Driver.FindElement(By.LinkText("Monitors")).Click();
                Thread.Sleep(2000);
                Driver.FindElement(By.CssSelector(".active > .nav-link")).Click();
                //Assert
                Assert.AreEqual("STORE", Driver.Title);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepción al detenerse" + ex);
                Driver.Dispose();
                throw;
            }
        }

        [Test]
        public void Validacion_de_contacto()
            {
                try
                {
                    //Act

                    Driver.FindElement(By.LinkText("Contact")).Click();
                    Thread.Sleep(1000);
                    Driver.FindElement(By.Id("recipient-email")).Click();
                    Driver.FindElement(By.Id("recipient-email")).SendKeys("correo@gmail.co");
                    Thread.Sleep(1000);
                    Driver.FindElement(By.Id("recipient-name")).Click();
                    Driver.FindElement(By.Id("recipient-name")).SendKeys("Roberth");
                    Thread.Sleep(1000);
                    Driver.FindElement(By.Id("message-text")).Click();
                    Driver.FindElement(By.Id("message-text")).SendKeys("Hola deseo información");
                    Thread.Sleep(1000);
                    Driver.FindElement(By.CssSelector("#exampleModal .btn-primary")).Click();
                    Thread.Sleep(1000);
                    //Assert
                    Assert.That(Driver.SwitchTo().Alert().Text, Is.EqualTo("Thanks for the message!!"));
            }
                catch (Exception ex)
                {
                    Console.WriteLine("Excepción al detenerse" + ex);
                    Driver.Dispose();
                    throw;
                }
            }
        }
    }
