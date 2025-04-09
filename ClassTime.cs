using System;

namespace ClassTime
{
    public class Time
    {
        private byte _hours;
        private byte _minutes;

        public int Hours
        {
            get => _hours;
            set => _hours = (byte)((value % 24 + 24) % 24);
        }

        public int Minutes
        {
            get => _minutes;
            set => _minutes = (byte)((value % 60 + 60) % 60);
        }

        public Time(int hours, int minutes)
        {
            Hours = hours;
            Minutes = minutes;
        }

        public Time(uint minutes)
        {
            int cutMinutes = (int)minutes;
            Hours = cutMinutes / 60;
            Minutes = cutMinutes % 60;
        }


        // Унарные:
        public static Time operator -(Time t)
        {
            t._hours = 0;
            t._minutes = 0;

            return new(0, 0);
        }

        public static Time operator --(Time t)
        {
            t._minutes = 0;

            return new(t.Hours, 0);
        }


        // Приведения типов:
        public static implicit operator byte(Time t) => t._hours;

        public static explicit operator bool(Time t)
        {
            return t.Hours != 0 && t.Minutes != 0;
        }

        // Бинарыне операции:
        public static bool operator ==(Time t1, Time t2)
        {
            if (ReferenceEquals(t1, t2))
                return true;

            if (t1 is null || t2 is null)
                return false;

            return t1.Equals(t2);
        }

        public static bool operator !=(Time t1, Time t2) => !(t1 == t2);


        public override string ToString() => $"{_hours:D2}:{_minutes:D2}";

        public static Time operator -(Time t1, uint num)
        {
            Time t2 = new(num);
            return new Time(t1.Hours - t2.Hours, t1.Minutes - t2.Minutes);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            if (obj is Time other)
                return _hours == other._hours && _minutes == other._minutes;            else

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_hours, _minutes);
        }
    }
};