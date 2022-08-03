using System;
using System.Collections.Generic;

namespace Core.ManagersSystem
{
    public static class ManagersHolder
    {
        private static readonly Dictionary<Type, IManager> _managers = new Dictionary<Type, IManager>();

        public static void AddManager(IManager manager)
        {
            var type = manager.GetType();
            if (_managers.ContainsKey(type))
            {
                _managers[type] = manager;
            }
            else
            {
                _managers.Add(type, manager);
            }
        }

        public static void RemoveManager(IManager manager)
        {
            var type = manager.GetType();
            if (_managers.ContainsKey(type))
            {
                _managers.Remove(type);
            }
        }

        public static void GetManager<T>(out T manager) where T : class, IManager
        {
            var type = typeof(T);
            manager = (T)_managers[type];
        }

        public static T GetManager<T>() where T : class, IManager
        {
            var type = typeof(T);
            return (T)_managers[type];
        }
    }
}