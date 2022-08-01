namespace Utils.Debug
{
    public static class Debug
    {
        public static void Log(object from, object message)
        {
            UnityEngine.Debug.Log(GetMessage(from, message));
        }
        
        public static void LogWarning(object from, object message)
        {
            UnityEngine.Debug.LogWarning(GetMessage(from, message));
        }

        private static string GetMessage(object from, object message)
        {
            return $"[{from.GetType().Name}] {message}";
        }
    }
}