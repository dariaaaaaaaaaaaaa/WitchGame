using UnityEngine;

namespace Core.Utils
{
    public static class VectorExtensions
    {
        public static Vector3 Average(this Vector3 a, Vector3 b)
        {
            return (a + b) / 2;
        }
    }
}