﻿
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface IDataManager
    {
        bool Readiness { get;}

        T InsertData<T>(string id, T catalogueItem);

        T GetDataById<T>(string id);

        void UpdateData(string id, object catalogueItem);

        IList<T> GetAllData<T>();

        void Configure();

        int GetRecordCount();
    }
}