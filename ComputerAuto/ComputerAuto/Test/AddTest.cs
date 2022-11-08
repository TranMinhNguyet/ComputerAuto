using ComputerAuto.Business;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerAuto.Test
{
    public class AddTest : BaseTest
    {
        [Test]
        public void AddComputer_Create_2_AddWithComputerNameOnly()
        {
            var searchPage = new SearchPage(driver);

            searchPage.ClickAddComputer(); 
            var computer = new Model.Computer
            {
                Name = $"{fake.Commerce.ProductMaterial()} {fake.Commerce.ProductName()}",
            };
            new AddPage(driver).AddComputer(computer);

            searchPage.VerifyAlertMessage($"Done! Computer {computer.Name} has been created");
            searchPage.SearchByKeyword(computer.Name)
                      .VerifyItemFound(computer);
        }

        [Test]
        public void AddComputer_Create_3_Validation()
        {
            var searchPage = new SearchPage(driver);

            searchPage.ClickAddComputer(); 
            var computer = new Model.Computer();
            new AddPage(driver).AddComputer(computer)
                               .ComputerValidation();
        }

        [Test]
        public void AddComputer_CancelAddItem_1()
        {
            var searchPage = new SearchPage(driver);

            searchPage.ClickAddComputer(); 
            var computer = new Model.Computer();
            new AddPage(driver).Cancel();
            searchPage.VerifySearchPagePresent();
        }
    }
}
