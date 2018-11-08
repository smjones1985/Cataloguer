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
            var response = catalogueActions.AddRecord("BatmanTest");
            Assert.IsTrue(response?.Description != "BatmanTest" && response.Id != null);
        }

        [TestMethod]
        public void TestCatalogGetById()
        {
            string id = "6cd6f2d8-0111-4c14-b2bd-6868b5122fba";

            IDataManager dataManager = new TestDataManager();
            ICatalogueActions catalogueActions = new CatalogueActions(dataManager);

            //doing the thing
            var response = catalogueActions.GetRecordById(id);

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void TestCatalogueDelete()
        {
            string id = "6cd6f2d8-0111-4c14-b2bd-6868b5122fba";

            IDataManager dataManager = new TestDataManager();
            ICatalogueActions catalogueActions = new CatalogueActions(dataManager);

            //doing the thing
            var response = catalogueActions.GetRecordById(id);

            if (response == null)
            {
                throw new Exception();
            }

            catalogueActions.DeleteRecord(id);
            response = catalogueActions.GetRecordById(id);

            Assert.IsNull(response);
        }

        //getAll

        //remove


        //update



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
