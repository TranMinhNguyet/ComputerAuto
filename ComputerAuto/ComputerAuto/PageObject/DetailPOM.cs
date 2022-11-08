using ComputerAuto.Model;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerAuto.PageObject
{
    public class DetailPOM : AddPOM
    {
        #region Contruct
        public DetailPOM (IWebDriver driver) : base(driver) { }
        #endregion

        #region Declare Elements
        [FindsBy(How = How.XPath, Using = "//input[contains(@class,'danger')]")]
        protected IWebElement Btn_DeleteComputer { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@class,'primary')]")]
        protected IWebElement Btn_SaveComputer { get; set; }
        #endregion

        #region Verify Detail
        public void VerifyDetail(Computer computer)
        {
            Assert.AreEqual(Txt_Name, computer.Name);
            Assert.AreEqual(Txt_Introduced, computer.Introduced?.ToString("yyyy-MM-dd"));
            Assert.AreEqual(Txt_Discontinued, computer.Discontinued?.ToString("yyyy-MM-dd"));
            if (computer.Company != null)
            {
                var company = new SelectElement(Opt_Company);
                Assert.AreEqual(company.SelectedOption.Text, computer.Company.Text);
            }
        }
        #endregion
    }
}
