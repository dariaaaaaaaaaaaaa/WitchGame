using System;
using System.Collections;
using UnityEngine;

namespace Time
{
    public class TimeManager : MonoBehaviour
    {
        [SerializeField] private float secondsInTick = 20f;

        private DateTime _time;

        private static TimeManager mInstance;
        public static TimeManager Instance => mInstance;

        public event Action OnTick;

        private void Awake()
        {
            mInstance = this;
        }

        private void Start()
        {
            StartCoroutine(CountTimeRoutine());
        }

        private IEnumerator CountTimeRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(secondsInTick);
                _time = _time.AddMinutes(10);
                OnTick?.Invoke();
            }
        }

        public GameTime GetTime()
        {
            return new GameTime(_time.Year, _time.Month, _time.Day, _time.Hour, _time.Minute);
        }
    }

    public class GameTime
    {
        private int _year;
        private int _month;
        private int _day;
        private int _hour;
        private int _minute;

        public int Year => _year;
        public int Month => _month;
        public int Day => _day;
        public int Hour => _hour;
        public int Minute => _minute;

        public GameTime(int year, int month, int day, int hour, int minute)
        {
            _year = year;
            _month = month;
            _day = day;
            _hour = hour;
            _minute = minute;
        }
    }
}