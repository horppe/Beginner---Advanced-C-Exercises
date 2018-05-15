using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Schedule_at_a_Bus_Station
{
    class Program
    {
        static void Main(string[] args)
        {
            List<DateTime> schedule = new List<DateTime>();
            HashSet<Interval> set = new HashSet<Interval>() {
                new Interval(08, 24, 08, 33),
                new Interval(08, 20, 09, 00),
                new Interval(08, 32, 08, 37),
                new Interval(09, 00, 09, 15)
            };
            Interval range = new Interval(08, 22, 09, 05);
            HashSet<Interval> result = GetIntersections(set, range);
                Console.ReadKey();
        }

        static HashSet<Interval> GetIntersections(HashSet<Interval> set, Interval range)
        {
            HashSet<Interval> arrive = new HashSet<Interval>();
            HashSet<Interval> depart = new HashSet<Interval>();

            foreach (Interval interval in set)
            {
                if (interval.arriveHour > range.arriveHour)
                {
                    arrive.Add(interval);
                }
                if (range.arriveMinute < interval.arriveMinute)
                {
                    arrive.Add(interval);
                }
                if (interval.departHour < range.departHour)
                {
                    depart.Add(interval);
                }
                if (range.departMinute > interval.departMinute)
                {
                    depart.Add(interval);
                }
            }
            arrive.IntersectWith(depart);
            return arrive;
        }
    
    }

    public struct Interval
    {
        public int arriveHour;
        public int arriveMinute;
        public int departHour;
        public int departMinute;
        public Interval(int aHour, int aMinute, int dHour, int dMinute)
        {
            arriveHour = aHour;
            arriveMinute = aMinute;
            departHour = dHour;
            departMinute = dMinute;
        }

        public KeyValuePair<int, int> Arrive
        {
            get
            {
                return new KeyValuePair<int, int>(arriveHour, arriveMinute);
            }
        }

        public KeyValuePair<int, int> Depart
        {
            get
            {
                return new KeyValuePair<int, int>(departHour, departMinute);
            }
        }

        public override int GetHashCode()
        {
            int result = 0;
            result = result + arriveHour.GetHashCode();
            result = result + arriveMinute.GetHashCode();
            result = result + departHour.GetHashCode();
            result = result + departMinute.GetHashCode();
            return result;
        }

        public override bool Equals(object obj)
        {
            Interval otherObjt = (Interval)obj;
            if (this.arriveHour != otherObjt.arriveHour)
            {
                return false;
            }
            if (this.arriveMinute != otherObjt.arriveMinute)
            {
                return false;
            }
            if (this.departHour != otherObjt.departHour)
            {
                return false;
            }
            if (this.departMinute != otherObjt.departMinute)
            {
                return false;
            }
            return true;
        }

    }
}
