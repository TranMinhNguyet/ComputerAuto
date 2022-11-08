using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;

namespace ComputerAuto.PageObject
{
    public class BasePOM
    {
        IWebDriver _driver;
        #region Contruct
        public BasePOM(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }
        #endregion
    }
}
