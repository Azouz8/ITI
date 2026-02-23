using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Lab
{
    internal class Duration
    {
        int hours, minutes, seconds;
        public Duration(int hours, int minutes, int seconds)
        {
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;
        }
        public Duration(int sec)
        {
            int h = sec / 3600;
            int m = (sec % 3600) / 60;
            int s = ((sec % 3600)) % 60;
            hours = h;
            minutes = m;
            seconds = s;
        }
        public override string ToString()
        {
            return $"Output: Hours: {hours}, Minutes: {minutes}, Secondes: {seconds}";
        }

        public override bool Equals(object? obj)
        {

            if (obj is Duration other)
            {
                return hours == other.hours &&
                       minutes == other.minutes &&
                       seconds == other.seconds;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(hours, minutes, seconds);
        }
        public static Duration operator +(Duration d1, Duration d2)
        {
            int totalSeconds = (d1.hours * 3600 + d1.minutes * 60 + d1.seconds) +
                               (d2.hours * 3600 + d2.minutes * 60 + d2.seconds);
            return new Duration(totalSeconds);
        }
        public static Duration operator +(Duration d1, int sec)
        {
            int totalSeconds = (d1.hours * 3600 + d1.minutes * 60 + d1.seconds) + sec;
            return new Duration(totalSeconds);
        }
        public static Duration operator +(int sec, Duration d1)
        {
            int totalSeconds = (d1.hours * 3600 + d1.minutes * 60 + d1.seconds) + sec;
            return new Duration(totalSeconds);
        }
        public static Duration operator ++(Duration d1)
        {
            int totalSeconds = (d1.hours * 3600 + d1.minutes * 60 + d1.seconds) + 60;
            return new Duration(totalSeconds);
        }
        public static Duration operator --(Duration d1)
        {
            int totalSeconds = (d1.hours * 3600 + d1.minutes * 60 + d1.seconds) - 60;
            return new Duration(totalSeconds);
        }
        public static bool operator >(Duration d1, Duration d2)
        {
            int totalSecondsD1 = (d1.hours * 3600 + d1.minutes * 60 + d1.seconds);
            int totalSecondsD2 = (d2.hours * 3600 + d2.minutes * 60 + d2.seconds);
            return totalSecondsD1 > totalSecondsD2;
        }
        public static bool operator <(Duration d1, Duration d2)
        {
            int totalSecondsD1 = (d1.hours * 3600 + d1.minutes * 60 + d1.seconds);
            int totalSecondsD2 = (d2.hours * 3600 + d2.minutes * 60 + d2.seconds);
            return totalSecondsD1 < totalSecondsD2;
        }
        public static bool operator >=(Duration d1, Duration d2)
        {
            int totalSecondsD1 = (d1.hours * 3600 + d1.minutes * 60 + d1.seconds);
            int totalSecondsD2 = (d2.hours * 3600 + d2.minutes * 60 + d2.seconds);
            return totalSecondsD1 >= totalSecondsD2;
        }
        public static bool operator <=(Duration d1, Duration d2)
        {
            int totalSecondsD1 = (d1.hours * 3600 + d1.minutes * 60 + d1.seconds);
            int totalSecondsD2 = (d2.hours * 3600 + d2.minutes * 60 + d2.seconds);
            return totalSecondsD1 <= totalSecondsD2;
        }
        public static bool operator true(Duration d)
        {
            int totalSeconds = (d.hours * 3600 + d.minutes * 60 + d.seconds);
            return totalSeconds != 0;
        }
        public static bool operator false(Duration d)
        {
            int totalSeconds = (d.hours * 3600 + d.minutes * 60 + d.seconds);
            return totalSeconds == 0;
        }
    }
}
