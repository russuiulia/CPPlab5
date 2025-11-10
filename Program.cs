using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace CPPlab5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Selenium automation...");

            var driver = new ChromeDriver();
            Console.WriteLine("ChromeDriver started.");

            driver.Navigate().GoToUrl("https://google.com");
            Console.WriteLine("Opened google.com");

            try
            {
                driver.FindElement(By.Id("L2AGLb")).Click();
                Console.WriteLine("Accepted cookies.");
            }
            catch
            {
                Console.WriteLine("No cookies popup found.");
            }

            try
            {
                var searchBox = driver.FindElement(By.Name("q"));
                Console.WriteLine("Found search box.");

                searchBox.SendKeys("computer");
                Console.WriteLine("Typed 'computer'.");

                searchBox.SendKeys(Keys.Enter);
                Console.WriteLine("Executed search.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error during search: " + e.Message);
            }

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                wait.Until(drv => drv.FindElement(By.Id("search")));
                Console.WriteLine("Search results page loaded.");

                Console.WriteLine("Checking header...");

                var header = driver.FindElement(By.CssSelector("h1, div[role='heading']"));

                Console.WriteLine("Header found and displayed: " + header.Displayed);
            }
            catch (Exception e)
            {
                Console.WriteLine("Header not found: " + e.Message);
            }

            driver.Quit();
            Console.WriteLine("Browser closed.");
            Console.WriteLine("Automation script finished.");

            Console.ReadLine();
        }
    }
}
