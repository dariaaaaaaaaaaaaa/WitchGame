using TMPro;
using UnityEngine;

namespace Time
{
    public class TimeViewer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI label;

        private void Update()
        {
            var time = TimeManager.Instance.GetTime();
            var hour = time.Hour < 10 ? 0 + time.Hour.ToString() : time.Hour.ToString();
            var minute = time.Minute < 10 ? 0 + time.Minute.ToString() : time.Minute.ToString();
            label.text = $"Day {time.Day}\n{hour}:{minute}";
        }
    }
}