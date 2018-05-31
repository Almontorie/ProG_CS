using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Almontorie.ProG.Model
{

    [DataContract (Name = "date")]
    public class Date
    {
        [DataMember]
        public int Day { get; protected set; }

        [DataMember]
        public int Month { get; protected set; }

        [DataMember]
        public int Year { get; protected set; }
        
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="Day"></param>
        /// <param name="Month"></param>
        /// <param name="Year"></param>
        public Date(int Day, int Month, int Year)
        {
            if (Day > 31 || Month > 12)
                throw new ArgumentOutOfRangeException("Les valeurs passées en paramètres sont trop grandes");
            if (Day <= 0 || Month <= 0)
                throw new ArgumentOutOfRangeException("Les valeurs passées en paramètres sont négatives ou nulles");
            this.Day = Day;
            this.Month = Month;
            this.Year = Year;
        } 

        /// <summary>
        /// Constructeur
        /// </summary>
        public Date()
        {
            Day = 0;
            Month = 0;
            Year = 0;
        }

        /// <summary>
        /// Redéfinition de ToString()
        /// </summary>
        /// <returns>
        /// string contenenant le jour, le mois et l'année
        /// </returns>
        public override string ToString()
        {
            return Day + "/" + Month + "/" + Year;
        }

        /// <summary>
        /// Deux dates sont identiques si toutes leurs propriétés sont égales.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>
        /// bool :
        ///     Si égaux : true
        ///     Sinon : false
        /// </returns>
        public override bool Equals(object obj)
        {
            var date = obj as Date;
            return date != null &&
                   Day == date.Day &&
                   Month == date.Month &&
                   Year == date.Year;
        }

        /// <summary>
        /// HashCode calculé avec les propriétés Day, Month et Year
        /// </summary>
        /// <returns>
        /// int : valeur de hashCode
        /// </returns>
        public override int GetHashCode()
        {
            var hashCode = -375065194;
            hashCode = hashCode * -1521134295 + Day.GetHashCode();
            hashCode = hashCode * -1521134295 + Month.GetHashCode();
            hashCode = hashCode * -1521134295 + Year.GetHashCode();
            return hashCode;
        }
    }
}
