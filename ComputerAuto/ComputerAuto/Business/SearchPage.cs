using ComputerAuto.PageObject;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAuto.Business
{
    public class SearchPage : SearchPOM
    {
        protected IWebDriver _driver;

        #region Contruct
        public SearchPage(IWebDriver driver) : base(driver) { }
        #endregion

        public SearchPage SearchByKeyword(string keyword)
        {
            Txt_SearchBox.SendKeys(keyword);
            Btn_Search.Click();
            return this;
        }

        public SearchPage ClickAddComputer()
        {
            Btn_AddComputer.Click();
            return this;
        }

        public SearchPage ClickOnDetail()
        {
            Lnk_Computers.First().Click();
            return this;
        }
    }
}
