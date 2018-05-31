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

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="Hour"></param>
        /// <param name="Min"></param>
        /// <param name="Second"></param>
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

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="Min"></param>
        /// <param name="Second"></param>
        public Time(int Min, int Second) : this(0, Min, Second)
        {
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        public Time() : this(0, 0, 0)
        {
        }
        
        /// <summary>
        /// Additionne la durée qui a appelé la méthode avec la durée passée en paramètre.
        /// </summary>
        /// <param name="Time"></param>
        /// <returns>
        /// Retourne le résultat de la somme.
        /// </returns>
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

        /// <summary>
        /// Soustrait la durée passée en paramètre à la durée qui a appelé la méthode.
        /// </summary>
        /// <param name="Time"></param>
        /// <returns>
        /// Retourne le résultat de la soustraction.
        /// </returns>
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

        /// <summary>
        /// Redéfinition de ToString()
        /// </summary>
        /// <returns>
        /// string contenant les heures, les minutes et les secondes
        /// Si l'heure est nulle, contient seulement les minutes et les secondes
        /// </returns>
        public override string ToString()
        {
            if(Day ==0 )
                return Hour + ":" + Min + ":"+ Second;
            return Day + "j " + Hour + ":" + Min + ":" + Second;
        }

        /// <summary>
        /// Deux durées sont identiques si :
        ///     Elles instancient la même classe
        ///     Si les propriérés de la classe mère, Hour, Min et Sec sont égales
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>
        /// Si égaux true
        /// Sinon false
        /// </returns>
        public override bool Equals(object obj)
        {
            var time = obj as Time;
            return time != null &&
                   base.Equals(obj) &&
                   Hour == time.Hour &&
                   Min == time.Min &&
                   Second == time.Second;
        }

        /// <summary>
        /// HashCode calculé avec les propriétés de la classe mère, Hour, Min et Sec
        /// </summary>
        /// <returns>
        /// int : valeur du hashCode
        /// </returns>
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
