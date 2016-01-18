using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AXVLC;
using System.Windows.Forms;

namespace VLC_test
{
    class cMovie
    {
        private AXVLC.VLCPlugin2 vlc;
        private String movieName;
        public cMovie(String MovieName)
        { 
            vlc = new AXVLC.VLCPlugin2();
            movieName = MovieName;
        }
        
        public void addingVLC()
        {
            /*adding component*/
            


            
            //vlc.addTarget("C://test.mp4", null, AXVLC.VLCPlaylistMode.VLCPlayListInsert, 0);
            //vlc.playlist.add("C:\test.mp4");
        }
        public void playMovie()
        {

            vlc.playlist.play();
        }
        public void createMovieForm()
        {
            


        }



    }
}
