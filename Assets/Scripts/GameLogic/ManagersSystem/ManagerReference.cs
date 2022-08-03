using System;

namespace Core.ManagersSystem
{
    public class ManagerReference<T> where T : class, IManager
    {
        [NonSerialized]
        private T _manager;
        
        public T Value
        {
            get
            {
                if (_manager == null)
                {
                    ManagersHolder.GetManager(out _manager);
                }

                return _manager;
            }
        }
    }
}