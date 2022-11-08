using Bogus;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace ComputerAuto
{
    public class BaseTest
    {
        public ChromeDriver driver;
        public Faker fake;
        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions
            {
                PageLoadStrategy = PageLoadStrategy.Normal
            }; 
            options.AddArguments("--incognito",
                                  "start-maximized");
            driver = new ChromeDriver(options);
            fake = new Faker();

            driver.Navigate().GoToUrl("https://computer-database.herokuapp.com/computers");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}