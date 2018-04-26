using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace OfficeCoreExer
{
    public class MainViewModel: PropChangedNotifiableBase
    {
        ISongsFetchingService SongsFetchingService;
        public MainViewModel(ISongsFetchingService sfs)
        {
            SongsFetchingService = sfs;

            _Fetch10RndItunesSongsCommand = new DelegateCommand(Fetch10RndItunesSongs, o => { return true; });
        }


        private string _ArtistName= "Rolling Stones";
        public string ArtistName
        {
            get { return _ArtistName; }
            set { SetProperty(ref _ArtistName, value, "ArtistName"); }
        }


        private itunesSong[] _TenRndSongs;
        public itunesSong[] TenRndSongs
        {
            get { return _TenRndSongs; }
            set
            {
                SetProperty(ref _TenRndSongs, value, "TenRndSongs");
            }
        }


        //private bool _NowFetchingSongs;
        //public bool NowFetchingSongs
        //{
        //    get { return _NowFetchingSongs; }
        //    set { SetProperty(ref _NowFetchingSongs, value, "NowFetchingSongs"); }
        //}




        private DelegateCommand _Fetch10RndItunesSongsCommand;
        public ICommand Fetch10RndItunesSongsCommand { get { return _Fetch10RndItunesSongsCommand; } }
        private async void Fetch10RndItunesSongs(object parameter)
        {
            TenRndSongs = await Task.Run(() => SongsFetchingService.Fetch10RndSongs(_ArtistName));
        }

    }
}
