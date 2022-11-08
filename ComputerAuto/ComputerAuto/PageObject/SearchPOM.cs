using ComputerAuto.Model;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using System.Linq;

namespace ComputerAuto.PageObject
{
    public class SearchPOM : BasePOM
    {
        #region Contruct
        public SearchPOM(IWebDriver driver) : base(driver) { }
        #endregion

        #region Declare elements
        [FindsBy(How = How.Id, Using = "searchbox")]
        protected IWebElement Txt_SearchBox { get; set; }

        [FindsBy(How = How.Id, Using = "searchsubmit")]
        protected IWebElement Btn_Search { get; set; }

        [FindsBy(How = How.Id, Using = "add")]
        protected IWebElement Btn_AddComputer { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@class,'computers')]//td/a")]
        protected IList<IWebElement> Lnk_Computers { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@class,'computers')]/tbody/tr")]
        protected IList<IWebElement> Lnk_ComputersDetail { get; set; }

        [FindsBy(How = How.ClassName, Using = "well")]
        protected IWebElement Lbl_NotFound { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='alert-message warning']")]
        protected IWebElement Lbl_Alert { get; set; }
        #endregion

        #region Verify Not Found
        public void VerifyNotFound()
        {
            Assert.AreEqual("Nothing to display", Lbl_NotFound.Text);
        }
        #endregion

        #region Verify Item Found
        public void VerifyItemFound(Computer computer)
        {
            var actual = Lnk_ComputersDetail.First().Text.Trim();
            Assert.IsTrue(actual.Contains(computer.Name));
            if (computer.Introduced != null)
            {
                Assert.IsTrue(actual.Contains(computer.Introduced?.ToString("dd MMM yyyy")));
            }

            if (computer.Discontinued != null)
            {
                Assert.IsTrue(actual.Contains(computer.Discontinued?.ToString("dd MMM yyyy")));
            }

            if (computer.Company != null)
            {
                Assert.IsTrue(actual.Contains(computer.Company?.Text));
            }
        }
        #endregion

        #region Verify Alert Message
        public void VerifyAlertMessage(string alert)
        {
            Assert.AreEqual(alert, Lbl_Alert.Text);
        }
        #endregion

        #region Verify Alert Message
        public void VerifySearchPagePresent()
        {
            Assert.IsTrue(Txt_SearchBox.Displayed);
        }
        #endregion
    }
}
