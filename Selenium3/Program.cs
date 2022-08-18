using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Selenium3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // change download directory
            string downloadDir = @"C:\";
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("download.default_directory", downloadDir);
            chromeOptions.AddUserProfilePreference("intl.accept_languages", "de");
            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");

            IWebDriver driver = new ChromeDriver(chromeOptions);
            driver.Navigate().GoToUrl("http://192.168.0.24:5500/index.html");


            IWebElement dateBox = driver.FindElement(By.XPath("//*[@id=\"start\"]"));
            Thread.Sleep(2000);
            DateTime y = DateTime.Today;
            dateBox.SendKeys(y.ToString());
            //dateBox.SendKeys(Keys.Tab);

            // dropdwon
            string car = "audi";
            IWebElement valuebox = driver.FindElement(By.XPath("//*[@id=\"cars\"]"));
            SelectElement dropDown = new SelectElement(valuebox);
            dropDown.SelectByValue(car);

            // write in textbox
            IWebElement input = driver.FindElement(By.XPath("//*[@id=\"TextBox\"]"));
            input.SendKeys("Hallo");

            // click link
            IWebElement link = driver.FindElement(By.XPath("/html/body/a"));
            new Actions(driver)
                .Click(link)
                .Perform();

            IWebElement linkexport = driver.FindElement(By.XPath("/html/body/a[2]"));
            new Actions(driver)
                .Click(linkexport)
                .Perform();

            
            Console.ReadLine();
        }
    }
}