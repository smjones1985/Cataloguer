using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface IGoogleSheetsManager
    {
        void CreateSheet(string sheetName);
        void EstablishCredentials();
        IList<IList<object>> GetData(string spreadsheetId, string range);
        bool InsertRecord(string spreadSheetId, string range, object catalogueRecord);
        void UpdateRecord(string id, object newData);
    }
}