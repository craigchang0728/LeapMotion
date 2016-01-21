using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leap;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;



namespace VLC_test
{

    class BackGroundTracking
    {
        public Controller leapController;
        private Form targetForm;
        private Button playButton;
        private LeapListener leapListener;
        Cursor palmCursor;
        public BackGroundTracking(Form form)
        {
            this.leapController = new Controller();
            this.targetForm = form;
            
            this.palmCursor = new Cursor(Cursor.Current.Handle);
            foreach (var control in targetForm.Controls)
            {
                if (control.GetType() == typeof(Button))
                {
                    playButton = control as Button; //cast control to button
                }
            }

            startTracking();

        }
        
        private void startTracking()
        {
            
            this.leapListener = new LeapListener();
            leapListener.OnInitial(this.leapController, this.palmCursor, this.targetForm);
            this.leapController.AddListener(leapListener);
            
            //Thread trackingThread = new Thread(trackingTask);




        }
        private void trackingTask()
        {
            

        }
     



        void connectHandler()
        {
            this.leapController.EnableGesture(Gesture.GestureType.TYPE_CIRCLE);
            this.leapController.Config.SetFloat("Gesture.Circle.MinRadius", 40.0f);
            this.leapController.EnableGesture(Gesture.GestureType.TYPE_SWIPE);
        }

       
        private void buttonPlay_Click(object sender, EventArgs e)
        {
            targetForm.ActiveControl = null;
            Form movieForm = new MovieForm();
            movieForm.ShowDialog();
        }
        public void playConfirm()
        {
            if (Cursor.Position.X > playButton.Left &&
                Cursor.Position.X < (playButton.Left + playButton.Width) &&
                Cursor.Position.Y < playButton.Top &&
                Cursor.Position.Y > (playButton.Top - playButton.Height))
            {
                playButton.PerformClick();

            }


        }




    }//end BackGroundTracking



   
   
}
