﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almontorie.ProG.Model
{
    public class Album 
    {
        public String Name { get; private set; }
        public Artist Artist { get; private set; }
        public Date ReleaseDate { get; private set; }
        public Time Length { get; private set; }

        public List<Song> ListSong { get; private set; }
        public Album(string Name, Artist Artist, Date ReleaseDate)
        {
            if(Name == null || Artist == null || ReleaseDate == null)
                throw new ArgumentNullException("Le nom, l'artiste ou la date de sortie de l'album est nul");
            this.Name = Name;
            this.Artist = Artist;
            this.ReleaseDate = ReleaseDate;
            ListSong = new List<Song>();
            Length = new Time();
        } 

        public Album(string Name, Artist Artist) :this(Name,Artist,new Date())
        {
        }

        public Album(string Name, Date ReleaseDate) :this(Name, new Artist(), ReleaseDate)
        {
        }

        public Album(string Name) :this(Name,new Date())
        {
        }

        public Album() : this("Unknown")
        {
        }

        internal void AddSong(Song Track)
        {
            ListSong.Add(Track);
            Length = Length.Addition(Track.Length);
        }

        internal void DeleteSong(Song Track)
        {
            ListSong.Remove(Track);
            Length = Length.Substraction(Track.Length);
        }
        

        public override string ToString()
        {
            return Name + " de " + Artist + " sorti le : " + ReleaseDate + " (" + Length + ")";
        }

        public override bool Equals(object obj)
        {
            var album = obj as Album;
            return album != null &&
                   Name == album.Name &&
                   EqualityComparer<Artist>.Default.Equals(Artist, album.Artist);
        }

        public override int GetHashCode()
        {
            var hashCode = 88401470;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<Artist>.Default.GetHashCode(Artist);
            return hashCode;
        }
    }
}