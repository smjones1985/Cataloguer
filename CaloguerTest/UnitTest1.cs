using System;
using BusinessObjectLayer;
using DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CaloguerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCatalogActionsConfigure()
        {
            IDataManager dataManager = new TestDataManager();
            ICatalogueActions catalogueActions = new CatalogueActions(dataManager);
            catalogueActions.ConfigureApplication();//since this does nothing, easy pass
        }

        [TestMethod]
        public void TestCatalogActionsInsert()
        {
            IDataManager dataManager = new TestDataManager();
            ICatalogueActions catalogueActions = new CatalogueActions(dataManager);
            catalogueActions.AddRecord("BatmanTest");
        }

     
        ////I created this test sheet and gave anyone with the link the ability to edit it
        //private const string TEST_SHEET = "1abeQC3jABk5_9ceClBbUvobIfA81eFO6_pEiZzZ0C_w";


        //[TestMethod]
        //public void EstablishCredentials()
        //{
        //    GoogleSheetsManager googleSheetsManager = new GoogleSheetsManager();
        //    googleSheetsManager.EstablishCredentials();
        //}

        //[TestMethod]
        //public void GetAllData()
        //{
        //    //GoogleSheetsManager googleSheetsManager = new GoogleSheetsManager();
        //    //var response = googleSheetsManager.GetData(TEST_SHEET, "Sheet1!A1:A2");
        //    //Assert.IsTrue(response != null && response.Count > 0);
        //    GoogleSheetsDataManager dataManager = new GoogleSheetsDataManager();
        //    dataManager.SheetId = TEST_SHEET;
        //    var response = dataManager.GetAllData();
        //    Assert.IsNotNull(response);
        //}

        //[TestMethod]
        //public void InsertData()
        //{
        //    GoogleSheetsManager googleSheetsManager = new GoogleSheetsManager();
        //    string testData = "{ \"Description\": \"InsertTest\"}";
        //    var response = googleSheetsManager.InsertRecord(TEST_SHEET, "Sheet1!A1:B1", testData);
        //    Assert.IsTrue(response);
        //}


        //[TestMethod]
        //public void CreateSheet()
        //{
        //    GoogleSheetsManager googleSheetsManager = new GoogleSheetsManager();
        //    googleSheetsManager.CreateSheet("TestCreate");
        //}

    }
}
