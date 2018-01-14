using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace TestNSB
{
    class El : IDisposable
    {
        private const string BaseUrl = "https://www.nsb.no/";
        private const string DriverPath = @"C:\Users\Ira\Desktop\TestNSB\TestNSB\Resource";
        private const string ChromeDriver = "chromedriver";
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//input[[@id='searchJourney']")]
        private IWebElement butSok;
        [FindsBy(How = How.XPath, Using = "//input[@id='travelers - summary']")]
        private IWebElement inputvoksen;
        [FindsBy(How = How.XPath, Using = "//input[@id='from']")]
        private IWebElement inputfrom;        
        [FindsBy(How = How.XPath, Using = "//input[@id='dest']")]
        private IWebElement inputto;
        [FindsBy(How = How.XPath, Using = "//input[@id='summary - traveltime']")]
        private IWebElement inputtime;
        [FindsBy(How = How.XPath, Using = "//input[@id='toggle - oneway']")]
        private IWebElement inputsingle;        
        [FindsBy(How = How.XPath, Using = "//input[@id='toggle -return']")]
        private IWebElement inputnosingle;
        [FindsBy(How = How.XPath, Using = "//select[@id='booking-date_outward_hour']")]
        private IWebElement selecttime;
        [FindsBy(How = How.XPath, Using = "//input[@id='passengerCategory-1']")]
        private IWebElement plusperson;
        [FindsBy(How = How.XPath, Using = "//input[@id='passengerCategory-2']")]
        private IWebElement pluschild;
        [FindsBy(How = How.XPath, Using = "//input[@id='passengerCategory-8']")]
        private IWebElement pluschild4;                
        [FindsBy(How = How.ClassName, Using = "nsb-page-menu-toggle nsb-js-page-menu-toggle")]
        private IWebElement butmenu;
        [FindsBy(How = How.ClassName, Using = "nsb-page-menu-login js-nsb-login-modal")]
        private IWebElement butlogin;
        [FindsBy(How = How.ClassName, Using = "nsb-btn nsb-btn--primary nsb-btn--wide nsb-js-click-tracking")]
        private IWebElement butlogin2;
        [FindsBy(How = How.XPath, Using = "//a[@class='nsb-change-language']")]
        private IWebElement buteng;
        [FindsBy(How = How.ClassName, Using = "nsb-btn nsb-page-search-button")]
        private IWebElement butfind;
        [FindsBy(How = How.ClassName, Using = "nsb-button nsb-button-primary nsb-search-form-submit")]
        private IWebElement butfind2;
        [FindsBy(How = How.XPath, Using = "//input[@id='query']")]
        private IWebElement inputfind;
        [FindsBy(How = How.ClassName, Using = "nsb-input-radio")]
        private IWebElement butcost;
        [FindsBy(How = How.ClassName, Using = "nsb-button nsb-button-primary nsb-js-journey-next ")]
        private IWebElement butcostnext;
        [FindsBy(How = How.ClassName, Using = "selectjourney - submit_form")]
        private IWebElement butcostnext2;
        [FindsBy(How = How.ClassName, Using = "nsb-button-as-a-link")]
        private IWebElement butregister;
        [FindsBy(How = How.XPath, Using = "//input[@id='add-default-phone-number']")]
        private IWebElement butnonomer;
        [FindsBy(How = How.XPath, Using = "//input[@id='email']")]
        private IWebElement butemail;
        [FindsBy(How = How.XPath, Using = "//input[@id='username-modal']")]
        private IWebElement logemail;
        [FindsBy(How = How.XPath, Using = "//input[@id='password-modal']")]
        private IWebElement logpassword;


        public El()
        {
            driver = new ChromeDriver(DriverPath);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            PageFactory.InitElements(driver, this);



        }

        public void TestCase1()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            Thread.Sleep(10000);
            butSok.Click();

            IWebElement second = driver.FindElement(By.XPath("//*[@id='dest']"));
            string s = second.Text.ToString();
            NUnit.Framework.Assert.AreEqual(s, string.Empty);



        }
           
        public void TestCase2()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            Thread.Sleep(10000);
            wait.Until(ExpectedConditions.ElementToBeClickable(inputfrom)).Click();
            inputfrom.SendKeys("Rise");
            butSok.Click();

            IWebElement second = driver.FindElement(By.XPath("//*[@id='dest']"));
            string s = second.Text.ToString();
            NUnit.Framework.Assert.AreEqual(s, string.Empty);


        }

        public void TestCase3()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            Thread.Sleep(10000);
            wait.Until(ExpectedConditions.ElementToBeClickable(inputfrom)).Click();
            inputfrom.SendKeys("Leirsund");
            wait.Until(ExpectedConditions.ElementToBeClickable(inputto)).Click();
            inputto.SendKeys("Leirsund");
            butSok.Click();


            IWebElement second = driver.FindElement(By.XPath("//*[@id='nsb - travelplanner - search']/fieldset/div[1]"));
            string s = second.Text.ToString();
            NUnit.Framework.Assert.AreEqual(s, "Kan ikke være samme stasjon : Jeg skal reise fra, Til");

        }

        public void TestCase4()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            Thread.Sleep(10000);
            wait.Until(ExpectedConditions.ElementToBeClickable(inputfrom)).Click();
            inputfrom.SendKeys("Leirsund");
            wait.Until(ExpectedConditions.ElementToBeClickable(inputto)).Click();
            inputto.SendKeys("Eidsvoll");
            wait.Until(ExpectedConditions.ElementToBeClickable(inputtime)).Click();
            var selectedEl = driver.FindElement(By.XPath("//select[@id='booking-date_outward_hour']"));
            var action = new Actions(driver);
            action.MoveToElement(selectedEl, 1, 1).Build().Perform();
            action.Click().Perform();
            wait.Until(ExpectedConditions.ElementToBeClickable(selecttime)).Click();
            selecttime.SendKeys("22");
            butSok.Click();

            IWebElement second = driver.FindElement(By.XPath("//*[@id='center']/div[3]/form/div[1]/div/fieldset/div/div[1]/a[1]"));
            string s = second.Text.ToString();
            NUnit.Framework.Assert.AreEqual(s, "Tidligere avganger");

        }

        public void TestCase5()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            Thread.Sleep(10000);
            wait.Until(ExpectedConditions.ElementToBeClickable(inputfrom)).Click();
            inputfrom.SendKeys("Leirsund");
            wait.Until(ExpectedConditions.ElementToBeClickable(inputto)).Click();
            inputto.SendKeys("Eidsvoll");
            wait.Until(ExpectedConditions.ElementToBeClickable(inputtime)).Click();
            var selectedEl = driver.FindElement(By.XPath("//input[@id='travelers - summary']"));
            var action = new Actions(driver);
            action.MoveToElement(selectedEl, 1, 1).Build().Perform();
            action.Click().Perform();
            wait.Until(ExpectedConditions.ElementToBeClickable(plusperson)).Click();
            plusperson.SendKeys("2");
            wait.Until(ExpectedConditions.ElementToBeClickable(pluschild)).Click();
            pluschild.SendKeys("3");
            wait.Until(ExpectedConditions.ElementToBeClickable(pluschild4)).Click();
            pluschild4.SendKeys("3");
            butSok.Click();

            IWebElement second = driver.FindElement(By.XPath("//*[@id='center']/div[3]/form/div[1]/div/fieldset/div/div[1]/a[1]"));
            string s = second.Text.ToString();
            NUnit.Framework.Assert.AreEqual(s, "Tidligere avganger");


        }

        public void TestCase6()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            Thread.Sleep(10000);
            wait.Until(ExpectedConditions.ElementToBeClickable(inputfrom)).Click();
            inputfrom.SendKeys("Leirsund");
            wait.Until(ExpectedConditions.ElementToBeClickable(inputto)).Click();
            inputto.SendKeys("Eidsvoll");
            wait.Until(ExpectedConditions.ElementToBeClickable(inputtime)).Click();
            var selectedEl = driver.FindElement(By.XPath("//input[@id='travelers - summary']"));
            var action = new Actions(driver);
            action.MoveToElement(selectedEl, 1, 1).Build().Perform();
            action.Click().Perform();
            wait.Until(ExpectedConditions.ElementToBeClickable(pluschild4)).Click();
            pluschild4.SendKeys("1");
            butSok.Click();

            IWebElement second = driver.FindElement(By.XPath("//*[@id='center']/div[3]/form/div[1]/div/fieldset/div/div[1]/a[1]"));
            string s = second.Text.ToString();
            NUnit.Framework.Assert.AreEqual(s, "Tidligere avganger");
        }

        public void TestCase7()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            Thread.Sleep(10000);
            wait.Until(ExpectedConditions.ElementToBeClickable(inputfrom)).Click();
            inputfrom.SendKeys("Leirsund");
            wait.Until(ExpectedConditions.ElementToBeClickable(inputto)).Click();
            inputto.SendKeys("Eidsvoll");
            butSok.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(butcost)).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(butcostnext)).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(butcostnext2)).Click();
            var reg = driver.FindElement(By.ClassName("nsb-button-as-a-link"));
            var action = new Actions(driver);
            action.MoveToElement(reg, 1, 1).Build().Perform();
            action.Click().Perform();
            var nonom = driver.FindElement(By.XPath("//input[@id='add-default-phone-number']"));
            var ac = new Actions(driver);
            ac.MoveToElement(nonom, 1, 1).Build().Perform();
            ac.Click().Perform();
            wait.Until(ExpectedConditions.ElementToBeClickable(butemail)).Click();
            butemail.SendKeys("111111test");
            wait.Until(ExpectedConditions.ElementToBeClickable(butcostnext2)).Click();

            IWebElement second = driver.FindElement(By.XPath("//*[@id='booking - ordinary - step - 5 - 0 - form']/div[1]/div/div[2]/fieldset/div/div[3]"));
            string s = second.Text.ToString();
            NUnit.Framework.Assert.AreEqual(s, "Dette er ikke en gyldig epostadresse");



        }


        public void TestCase8()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            Thread.Sleep(10000);
            var reg = driver.FindElement(By.ClassName("nsb-page-menu-toggle nsb-js-page-menu-toggle"));
            var action = new Actions(driver);
            action.MoveToElement(reg, 1, 1).Build().Perform();
            action.Click().Perform();
            var reg1 = driver.FindElement(By.ClassName("nsb-page-menu-login js-nsb-login-modal"));
            var log = new Actions(driver);
            log.MoveToElement(reg1, 1, 1).Build().Perform();
            log.Click().Perform();
            wait.Until(ExpectedConditions.ElementToBeClickable(logemail)).Click();
            logemail.SendKeys("111@aa.ru");
            wait.Until(ExpectedConditions.ElementToBeClickable(logpassword)).Click();
            logpassword.SendKeys("111111");
            wait.Until(ExpectedConditions.ElementToBeClickable(butlogin2)).Click();


            IWebElement second = driver.FindElement(By.XPath("//*[@id='myModal']/div/div[2]/p"));
            string s = second.Text.ToString();
            NUnit.Framework.Assert.AreEqual(s, "Obligatoriske felt mangler verdi");



        }

        public void TestCase9()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            Thread.Sleep(10000);
            var menu = driver.FindElement(By.ClassName("nsb-page-menu-toggle nsb-js-page-menu-toggle"));
            var action = new Actions(driver);
            action.MoveToElement(menu, 1, 1).Build().Perform();
            action.Click().Perform();
            wait.Until(ExpectedConditions.ElementToBeClickable(buteng)).Click();

            IWebElement second = driver.FindElement(By.XPath("//*[@id='nsb - travelplanner - search']/fieldset/legend"));
            string s = second.Text.ToString();
            NUnit.Framework.Assert.AreEqual(s, "Good evening, where do you want to go?");



        }

        public void TestCase10()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            Thread.Sleep(10000);
            var menu = driver.FindElement(By.ClassName("nsb-page-menu-toggle nsb-js-page-menu-toggle"));
            var action = new Actions(driver);
            action.MoveToElement(menu, 1, 1).Build().Perform();
            action.Click().Perform();
            var find = driver.FindElement(By.ClassName("nsb-btn nsb-page-search-button"));
            var f = new Actions(driver);
            f.MoveToElement(find, 1, 1).Build().Perform();
            f.Click().Perform();
            wait.Until(ExpectedConditions.ElementToBeClickable(inputfind)).Click();
            inputfind.SendKeys("Kafe");
            wait.Until(ExpectedConditions.ElementToBeClickable(butfind2)).Click();

            IWebElement second = driver.FindElement(By.XPath("//*[@id='search - result']/ul/li[1]/h3/a/span"));
            string s = second.Text.ToString();
            NUnit.Framework.Assert.AreEqual(s, "NSB Kafé - nsb.no");




        }

        public void Dispose()
        {
            driver.Quit();
            driver = null;

            foreach (var process in Process.GetProcessesByName(ChromeDriver))
            {
                process.Kill();
            }
        }
    }
}
