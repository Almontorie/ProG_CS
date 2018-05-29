using Almontorie.ProG.Model;
using Almontorie.ProG.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Almontorie.ProG.Service;

namespace Almontorie.ProG.Controller
{
    public class LibraryController
    {
        private readonly IView _view;

        public LibraryController(IView view)
        {
            _view = view;
        }
        
        /// <summary>
        /// Menu console chargeant le fichier de sauvegarde.
        /// Il proposent les différentes options possibles pour la manipulation de la librairie.
        /// Sauvegarde la librairie avant à l'arrêt.
        /// </summary>
        public void Menu()
        {
            Library library = new Library();

            IService serv = new XmlService();
            library = serv.LoadLibrary();
            

            bool exit = false;

            do
            {
                _view.DisplayText("Menu");
                _view.DisplayText("\t 1 : Ajouter une musique");
                _view.DisplayText("\t 2 : Supprimer une musique");
                _view.DisplayText("\t 3 : Ajouter une playlist");
                _view.DisplayText("\t 4 : Supprimer une playlist");
                _view.DisplayText("\t 6 : Supprimer un album");
                _view.DisplayText("\t 7 : Afficher les musiques");
                _view.DisplayText("\t 8 : Afficher les artistes");
                _view.DisplayText("\t 9 : Afficher les albums");
                _view.DisplayText("\t 10 : Playlists");
                _view.DisplayText("\t 11 : Quitter");

                int valid = _view.AskForNumber();

                Song track;
                Playlist playlist;
                Album album;
                Artist arti;
                

                switch (valid)
                {
                    case 1:
                        track = _view.AskForSong();
                        library.AddSong(track);
                        break;

                    case 2:
                        track = _view.AskForSong();
                        library.DeleteSong(track);
                        break;

                    case 3:
                        playlist = _view.AskForPlaylist();
                        library.AddPlaylist(playlist);
                        break;

                    case 4:
                        playlist = _view.AskForPlaylist();
                        library.DeletePlaylist(playlist);
                        break;

                    case 5:
                        break;

                    case 6:
                        arti = _view.AskForArtist();
                        album = _view.AskForAlbum(arti);
                        library.DeleteAlbum(album);
                        break;

                    case 7:
                        _view.DisplayListOfSong(library);
                        _view.DisplayText("Saisir un numéro de musique (0 pour retour): ");
                        int i = _view.AskForNumber();
                        if (i == 0) break;
                        if(i > library.ListSong.Count)
                        {
                            _view.DisplayText("Numéro de musique incorrect");
                            break;
                        }

                        _view.DisplayText("1 : Supprimer la musique");
                        _view.DisplayText("2 : Ajouter à une playlist");
                        int ans = _view.AskForNumber();
                        switch (ans)
                        {
                            case 1:
                                library.DeleteSong(library.ListSong[i - 1]);
                                break;
                            case 2:
                                Playlist playli = _view.AskForPlaylist();
                                if (!library.ListPlaylist.Contains(playli))
                                {
                                    _view.DisplayText("Cette playlist n'existe pas");
                                    break;
                                }

                                library.ListPlaylist[library.ListPlaylist.IndexOf(playli)].AddSong(library.ListSong[i - 1]);
                                break;
                            default:
                                break;
                        }

                        break;

                    case 8:
                        _view.DisplayListOfArtist(library);
                        _view.DisplayText("");
                        _view.DisplayText("Saisir un numéro d'artist (0 pour retour): ");
                        i = _view.AskForNumber();
                        if (i <= 0) break;
                        if (i > library.ListArtist.Count)
                        {
                            _view.DisplayText("Numéro d'artist incorrect");
                            break;
                        }

                        _view.DisplayArtist(library.ListArtist[i - 1]);
                        _view.DisplaySongOfArtist(library.ListArtist[i - 1]);
                        _view.DisplayText("Entrée pour continuer");
                        Console.ReadLine();

                        break;

                    case 9:
                        _view.DisplayListOfAlbum(library);
                        _view.DisplayText("");
                        _view.DisplayText("Saisir un numéro d'album (0 pour retour): ");
                        i = _view.AskForNumber();
                        if (i <= 0) break;
                        if(i > library.ListAlbum.Count)
                        {
                            _view.DisplayText("Numéro d'album incorrect");
                            break;
                        }

                        _view.DisplaySongOfAlbum(library.ListAlbum[i - 1]);
                        _view.DisplayText("Entrée pour continuer");
                        Console.ReadLine();
                        break;

                    case 10:
                        _view.DisplayText("");
                        _view.DisplayListOfPlaylist(library);
                        _view.DisplayText("");
                        _view.DisplayText("Saisir un numéro de playlist (0 pour retour): ");
                        i = _view.AskForNumber();
                        if(i > library.ListPlaylist.Count)
                        {
                            _view.DisplayText("Numéro de playlist incorrect");
                            break;
                        }
                        if (i <= 0) break;

                        _view.DisplaySongOfPlaylist(library.ListPlaylist[i - 1]);
                        _view.DisplayText("Saisir un numéro de musique (0 pour retour): ");
                        int it = _view.AskForNumber();
                        if (it <= 0) break;
                        if(it > library.ListPlaylist[i - 1].ListSong.Count)
                        {
                            _view.DisplayText("Numéro de musique incorrect");
                            break;
                        }

                        _view.DisplayText("Voulez-vous supprimer cette musique ? (o/n) :");
                        string test = Console.ReadLine();
                        if (test == "o")
                            library.ListPlaylist[i - 1].DeleteSong(library.ListPlaylist[i-1].ListSong[it - 1]);
                        
                        break;

                    case 11:
                        exit = true;
                        break;

                    default:
                        _view.DisplayText("Nombre incorrect");
                        break;
                }

            } while (!exit);
            serv.SaveLibrary(library);
        }
        
    }
}
