using ComputerAuto.Business;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerAuto.Test
{
    public class EditTest : BaseTest
    {
        [Test]
        public void ComputerDetail_EditItem_2_EditWithComputerNameOnly()
        {
            var searchPage = new SearchPage(driver);

            searchPage.ClickOnDetail();
            var computer = new Model.Computer
            {
                Name = $"{fake.Commerce.ProductMaterial()} {fake.Commerce.ProductName()}",
            };
            new DetailPage(driver).UpdateComputer(computer);

            searchPage.VerifyAlertMessage($"Done! Computer {computer.Name} has been updated");
            searchPage.SearchByKeyword(computer.Name)
                      .VerifyItemFound(computer);
        }

        [Test]
        public void ComputerDetail_EditItem_3_Validation()
        {
            var searchPage = new SearchPage(driver);

            searchPage.ClickOnDetail();
            var computer = new Model.Computer();
            new DetailPage(driver).UpdateComputer(computer)
                                  .ComputerValidation();
        }

        [Test]
        public void ComputerDetail_CancelEditItem_1()
        {
            var searchPage = new SearchPage(driver);

            searchPage.ClickAddComputer();
            var computer = new Model.Computer();
            new AddPage(driver).Cancel();
            searchPage.VerifySearchPagePresent();
        }
    }
}
