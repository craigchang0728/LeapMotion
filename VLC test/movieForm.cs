using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//using LibVLC.NET;

namespace VLC_test
{
    public partial class MovieForm : Form
    {
        public MovieForm()
        {
            InitializeComponent();

            axVLCPlugin21.playlist.add("file:///C:/test.mp4");
            //this.ShowDialog();
            axVLCPlugin21.playlist.play();
            //cMovie newmovie = new cMovie("test.mp4");
            /*
            OpenFileDialog openFileDialogMovie = new OpenFileDialog();
            openFileDialogMovie.Filter = "( *.mp4 )| *.mp4";
            if (openFileDialogMovie.ShowDialog() == DialogResult.OK)
            {
                
                //axVLCPlugin21.playlist.add(@"file:///" + openFileDialogMovie.FileName, null, null);
                var uri = new Uri(openFileDialogMovie.FileName);
                var converted = uri.AbsoluteUri;
                Debug.WriteLine(converted);

                axVLCPlugin21.playlist.add("file:///C:/test.mp4");
                //this.ShowDialog();
                axVLCPlugin21.playlist.play();
            }
            */
            //
            


            if (axVLCPlugin21.playlist.isPlaying == false)
                System.Diagnostics.Debug.Write("Failed");
          
        }

       
    }
}
