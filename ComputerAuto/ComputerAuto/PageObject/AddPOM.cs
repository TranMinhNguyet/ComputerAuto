using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerAuto.PageObject
{
    public class AddPOM : BasePOM
    {
        #region Contruct
        public AddPOM(IWebDriver driver) : base(driver) { }
        #endregion

        #region declare fields
        [FindsBy(How = How.Id, Using = "name")]
        protected IWebElement Txt_Name { get; set; }

        [FindsBy(How = How.Id, Using = "introduced")]
        protected IWebElement Txt_Introduced { get; set; }

        [FindsBy(How = How.Id, Using = "discontinued")]
        protected IWebElement Txt_Discontinued { get; set; }

        [FindsBy(How = How.Id, Using = "company")]
        protected IWebElement Opt_Company { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        protected IWebElement Btn_CreateComputer { get; set; }

        [FindsBy(How = How.LinkText, Using = "Cancel")]
        protected IWebElement Btn_Cancel { get; set; }
        #endregion

        #region Validation
        public void ComputerValidation()
        {
            var onError = Txt_Name.FindElement(By.XPath("ancestor::div[contains(@class,'clearfix')]")).GetAttribute("class");
            Assert.IsTrue(onError.Contains("error"));
        }
        #endregion
    }
}
