using ComputerAuto.Model;
using ComputerAuto.PageObject;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerAuto.Business
{
    public class DetailPage : DetailPOM
    {
        #region Contruct
        public DetailPage (IWebDriver driver) : base(driver) { }
        #endregion

        #region Update Computer
        public DetailPage UpdateComputer(Computer computer)
        {
            Txt_Name.Clear();
            if(computer.Name != null)
            {
                Txt_Name.SendKeys(computer.Name);
            }

            Txt_Introduced.Clear();
            if (computer.Introduced != null)
            {
                Txt_Introduced.SendKeys(computer.Introduced?.ToString("yyyy-MM-dd"));
            }

            Txt_Discontinued.Clear();
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
            Btn_SaveComputer.Click();
            return this;
        }
        #endregion

        #region Delete Computer
        public DetailPage DeleteComputer()
        {
            Btn_DeleteComputer.Click();
            return this;
        }
        #endregion

        #region Delete Computer
        public string GetComputerName()
        {
            return Txt_Name.GetAttribute("value");
        }
        #endregion
    }
}
