using System.Threading.Tasks;
using UnityEngine;

namespace Core.Utils
{
    public static class ResourceLoader
    {
        public static async Task<T> Load<T>(string path) where T : Object
        {
            var _request = Resources.LoadAsync<T>(path);
            var countIteration = 0;
            const int maxIterationCount = 10000;
            do
            {
                await Task.Delay(10);
                countIteration++;
            } while (!_request.isDone || countIteration > maxIterationCount);

            if (_request.asset == null)
            {
                Debug.LogWarning($"Asset of type {typeof(T)}  cant load by path {path}!");
            }

            return (T)_request.asset;
        }
        
    }
}