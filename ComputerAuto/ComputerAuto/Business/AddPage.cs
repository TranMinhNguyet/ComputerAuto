using ComputerAuto.Model;
using ComputerAuto.PageObject;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerAuto.Business
{
    public class AddPage : AddPOM
    {
        #region Contruct
        public AddPage(IWebDriver driver) : base(driver) { }
        #endregion

        #region Add Computer
        public AddPage AddComputer(Computer computer)
        {
            if (computer.Name != null)
            {
                Txt_Name.SendKeys(computer.Name);
            }

            if (computer.Introduced != null)
            {
                Txt_Introduced.SendKeys(computer.Introduced?.ToString("yyyy-MM-dd"));
            }

            if (computer.Discontinued != null)
            {
                Txt_Discontinued.SendKeys(computer.Discontinued?.ToString("yyyy-MM-dd"));
            }

            if (computer.Company != null)
            {
                var company = new SelectElement(Opt_Company);
                company.SelectByValue(computer.Company.Value.ToString());
                computer.Company.Text = company.SelectedOption.Text;
            }
            Btn_CreateComputer.Click();
            return this;
        }
        #endregion

        #region Cancel
        public AddPage Cancel()
        {
            Btn_Cancel.Click();
            return this;
        }
        #endregion
    }
}
