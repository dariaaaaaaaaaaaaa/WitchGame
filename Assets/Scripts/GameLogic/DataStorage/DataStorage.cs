using System;
using System.Collections.Generic;
using Core.ManagersSystem;

namespace Core.DataStorage
{
    [Serializable]
    public class DataStorage : IManager
    {
        public List<object> containers = new List<object>();
    }
}