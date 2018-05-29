using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Almontorie.ProG.Model
{
    [DataContract (Name = "time")]
    public class Time : Date   
    {

        [DataMember]
        public int Hour { get; private set; }

        [DataMember]
        public int Min { get; private set; }

        [DataMember]
        public int Second { get; private set; }

        public Time(int Hour, int Min, int Second) :base() 
        {
            if (Hour >= 24 || Min >= 60 || Second >= 60)
                throw new ArgumentOutOfRangeException("Les valeurs passées en paramètres sont trop grandes");
            if (Hour < 0 || Min < 0 || Second < 0)
                throw new ArgumentOutOfRangeException("Les valeurs passées en paramètres sont négatives");
            this.Hour = Hour;
            this.Min = Min;
            this.Second = Second;
        }

        public Time(int Min, int Second) : this(0, Min, Second)
        {
        }

        public Time() : this(0, 0, 0)
        {
        }
        
        public Time Addition(Time Time)
        {
            Time retour = new Time();
            retour.Second = Second + Time.Second;
            if (retour.Second >= 60)
            {
                retour.Min += 1;
                retour.Second -= 60;
            }

            retour.Min = retour.Min + Min + Time.Min;
            if (retour.Min >= 60)
            {
                retour.Hour += 1;
                retour.Min -= 60;
            }

            retour.Hour = retour.Hour + Hour + Time.Hour;
            if (retour.Hour >= 24)
            {
                retour.Day += 1;
                retour.Hour -= 24;
            }

            retour.Day = retour.Day + Day + Time.Day;


            return retour;
        }

        public Time Substraction(Time Time)
        {
            Time retour = new Time();

            retour.Second = Second - Time.Second;
            if (retour.Second < 0)
            {
                retour.Min -= 1;
                retour.Second += 60;
            }

            retour.Min = retour.Min + Min - Time.Min;
            if (retour.Min < 0)
            {
                retour.Hour -= 1;
                retour.Min += 60;
            }

            retour.Hour = retour.Hour + Hour - Time.Hour;
            if (retour.Hour < 0)
            {
                retour.Day -= 1;
                retour.Hour += 24;
            }

            retour.Day = retour.Day + Day - Time.Day;
              
            return retour;
        }

        public override string ToString()
        {
            if(Day ==0 )
                return Hour + ":" + Min + ":"+ Second;
            return Day + "j " + Hour + ":" + Min + ":" + Second;
        }

        public override bool Equals(object obj)
        {
            var time = obj as Time;
            return time != null &&
                   base.Equals(obj) &&
                   Hour == time.Hour &&
                   Min == time.Min &&
                   Second == time.Second;
        }

        public override int GetHashCode()
        {
            var hashCode = 1227425067;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + Hour.GetHashCode();
            hashCode = hashCode * -1521134295 + Min.GetHashCode();
            hashCode = hashCode * -1521134295 + Second.GetHashCode();
            return hashCode;
        }
    }
}
