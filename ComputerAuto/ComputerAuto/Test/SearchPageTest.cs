using Bogus;
using ComputerAuto.Business;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAuto.Test
{
    public class SearchPageTest : BaseTest
    {
        [Test]
        public void SearchPage_Search_4_SearchUnmatchItem()
        {
            var searchPage = new SearchPage(driver);

            searchPage.SearchByKeyword("abc123456")
                      .VerifyNotFound();
        }

        [Test]
        public void SearchPage_Search_6_SearchNewAddedItem()
        {
            var searchPage = new SearchPage(driver);

            searchPage.ClickAddComputer();
            var computer = new Model.Computer
            {
                Name = $"{fake.Commerce.ProductMaterial()} {fake.Commerce.ProductName()}",
                Introduced = DateTime.Now,
                Discontinued = DateTime.Now.AddYears(5),
                Company = new Model.Company { Value = fake.Random.Int(1, 43) }
            };
            new AddPage(driver).AddComputer(computer);

            searchPage.VerifyAlertMessage($"Done! Computer {computer.Name} has been created");
            searchPage.SearchByKeyword(computer.Name)
                      .VerifyItemFound(computer);
        }

        [Test]
        public void SearchPage_Search_7_SearchUpdatedItem()
        {
            var searchPage = new SearchPage(driver);

            searchPage.ClickOnDetail();
            var computer = new Model.Computer
            {
                Name = $"{fake.Commerce.ProductMaterial()} {fake.Commerce.ProductName()}",
                Introduced = DateTime.Now,
                Discontinued = DateTime.Now.AddYears(5),
                Company = new Model.Company { Value = fake.Random.Int(1, 43) }
            };
            new DetailPage(driver).UpdateComputer(computer);

            searchPage.VerifyAlertMessage($"Done! Computer {computer.Name} has been updated");
            searchPage.SearchByKeyword(computer.Name)
                      .VerifyItemFound(computer);
        }

        [Test]
        public void SearchPage_Search_8_SearchDeletedItem()
        {
            var searchPage = new SearchPage(driver);

            searchPage.ClickOnDetail();
            var detailPage = new DetailPage(driver);
            string computerName = detailPage.GetComputerName();
            detailPage.DeleteComputer();

            searchPage.VerifyAlertMessage($"Done! Computer has been deleted");
            searchPage.SearchByKeyword(computerName)
                      .VerifyNotFound();
        }
    }
}
