using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace Proyecto2
{
    //[TestFixture(typeof(EdgeDriver))]
    [TestFixture(typeof(ChromeDriver))]
    //[TestFixture(typeof(FirefoxDriver))]
    public class CasosDePrueba_Deberia<TWebDriver> where TWebDriver : IWebDriver, new()
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
            //opcionesDeChrome.AddArguments("incognito");
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

        }
        [TearDown]
        protected void TearDown()
        {
            if (Driver != null) Driver.Quit();
        }

        //Nuevo Sitio

        [Test]
        public void Validar_Registro_e_ingreso()
        {
            try
            {
                Driver.Navigate().GoToUrl("https://petstore.octoperf.com/actions/Catalog.action");

                IWebElement login = Driver.FindElement(By.XPath("//*[@id='MenuContent']/a[2]"));
                login.Click();
                Thread.Sleep(1000);

                IWebElement register = Driver.FindElement(By.XPath("//*[@id='Catalog']/ a"));
                register.Click();
                Thread.Sleep(1000);

                IWebElement IdUser = Driver.FindElement(By.XPath("/html/body/div[2]/div/form/table[1]/tbody/tr[1]/td[2]/input"));
                IdUser.Clear();
                IdUser.SendKeys("UserTestProject2");

                IWebElement Password = Driver.FindElement(By.XPath("//*[@id='Catalog']/ form/table[1]/tbody/tr[2]/td[2]/input"));
                Password.Clear();
                Password.SendKeys("user1234");

                IWebElement ConfirmPassword = Driver.FindElement(By.XPath("//*[@id='Catalog']/form/table[1]/tbody/tr[3]/td[2]/input"));
                ConfirmPassword.Clear();
                ConfirmPassword.SendKeys("user1234");

                IWebElement NamePila = Driver.FindElement(By.XPath("//*[@id='Catalog']/form/table[2]/tbody/tr[1]/td[2]/input"));
                NamePila.Clear();
                NamePila.SendKeys("IDTest");

                IWebElement LastName = Driver.FindElement(By.XPath("//*[@id='Catalog']/form/table[2]/tbody/tr[2]/td[2]/input"));
                LastName.Clear();
                LastName.SendKeys("UserTest");

                IWebElement Email = Driver.FindElement(By.XPath("//*[@id='Catalog']/ form/table[2]/tbody/tr[3]/td[2]/input"));
                Email.Clear();
                Email.SendKeys("UserTest@gmail.com");

                IWebElement PhoneNumber = Driver.FindElement(By.XPath("//*[@id='Catalog']/ form/table[2]/tbody/tr[4]/td[2]/input"));
                PhoneNumber.Clear();
                PhoneNumber.SendKeys("12345678");

                IWebElement Address1 = Driver.FindElement(By.XPath("//*[@id='Catalog']/form/table[2]/tbody/tr[5]/td[2]/input"));
                Address1.Clear();
                Address1.SendKeys("Guanacaste");

                IWebElement Address2 = Driver.FindElement(By.XPath("//*[@id='Catalog']/ form/table[2]/tbody/tr[6]/td[2]/input"));
                Address2.Clear();
                Address2.SendKeys("Hojancha");

                IWebElement City = Driver.FindElement(By.XPath("//*[@id='Catalog']/form/table[2]/tbody/tr[7]/td[2]/input"));
                City.Clear();
                City.SendKeys("Hojancha");

                IWebElement Expression = Driver.FindElement(By.XPath("//*[@id='Catalog']/ form/table[2]/tbody/tr[8]/td[2]/input"));
                Expression.Clear();
                Expression.SendKeys("Hola");

                IWebElement TShirt = Driver.FindElement(By.XPath("//*[@id='Catalog']/form/table[2]/tbody/tr[9]/td[2]/input"));
                TShirt.Clear();
                TShirt.SendKeys("Camiseta");

                IWebElement Conutry = Driver.FindElement(By.XPath("//*[@id='Catalog']/ form/table[2]/tbody/tr[10]/td[2]/input"));
                Conutry.Clear();
                Conutry.SendKeys("Costa Rica");

                IWebElement Language = Driver.FindElement(By.XPath("//*[@id='Catalog']/form/table[3]/tbody/tr[1]/td[2]/select"));
                SelectElement selectValue = new SelectElement(Language);
                selectValue.SelectByValue("japanese");

                IWebElement Category = Driver.FindElement(By.XPath("//*[@id='Catalog']/form/table[3]/tbody/tr[2]/td[2]/select"));
                SelectElement selectValue2 = new SelectElement(Category);
                selectValue2.SelectByValue("DOGS");

                IWebElement MyList = Driver.FindElement(By.XPath("//*[@id='Catalog']/ form/table[3]/tbody/tr[3]/td[2]/input"));
                MyList.Click();

                IWebElement MyBanner = Driver.FindElement(By.XPath("//*[@id='Catalog']/form/table[3]/tbody/tr[4]/td[2]/input"));
                MyBanner.Click();

                IWebElement Save = Driver.FindElement(By.Name("newAccount"));
                Save.Click();
                Thread.Sleep(3000);

                IWebElement CloseSession = Driver.FindElement(By.XPath("//*[@id='MenuContent']/ a[2]"));
                CloseSession.Click();
                Thread.Sleep(3000);

                IWebElement User = Driver.FindElement(By.Name("username"));
                User.Clear();
                User.SendKeys("UserTestProject2");

                IWebElement PasswordNow = Driver.FindElement(By.Name("password"));
                PasswordNow.Clear();
                PasswordNow.SendKeys("user1234");
                Thread.Sleep(2000);

                IWebElement Access = Driver.FindElement(By.Name("signon"));
                Access.Click();
                Thread.Sleep(3000);

                IWebElement Succes = Driver.FindElement(By.Id("WelcomeContent"));
                string val = Succes.GetAttribute("innerText");

                Assert.AreEqual("Welcome IDTest!", val);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepción al detenerse" + ex);
                Driver.Dispose();
                throw;
            }
        }
        
        [Test]
        public void Validar_la_Navegacion_por_categorias()
        {
            try
            {
                //Arrange
                Driver.Navigate().GoToUrl("https://www.demoblaze.com/index.html");
                //Act

                Driver.FindElement(By.XPath("//a[contains(text(),\'Monitors\')]")).Click();
                Thread.Sleep(2000);
                Driver.FindElement(By.XPath("//a[contains(text(),\'Apple monitor 24\')]")).Click();
                Thread.Sleep(2000);
                Driver.FindElement(By.CssSelector(".active > .nav-link")).Click();
                Thread.Sleep(1000);
                Driver.FindElement(By.XPath("//a[contains(text(),\'Laptops\')]")).Click();
                Thread.Sleep(2000);
                Driver.FindElement(By.XPath("//a[contains(text(),\'Sony vaio i5\')]")).Click();
                Thread.Sleep(1000);
                Driver.FindElement(By.CssSelector(".active > .nav-link")).Click();
                Thread.Sleep(2000);
                Driver.FindElement(By.XPath("//a[contains(text(),\'Samsung galaxy s6\')]")).Click();
                Thread.Sleep(2000);
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

        //[Test]
        //public void CasoPrueba()
        //    {
        //        try
        //        {
        //        //Act
        //            Driver.Navigate().GoToUrl("");


        //        //Assert
        //        Assert.That(Driver.SwitchTo().Alert().Text, Is.EqualTo("Success: You have added iMac to your shopping cart!"));

        //    }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine("Excepción al detenerse" + ex);
        //            Driver.Dispose();
        //            throw;
        //        }
        //    }
        }
    }
