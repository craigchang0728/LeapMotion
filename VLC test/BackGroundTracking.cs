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

    class BackGroundTracking : ILeapEventDelegate
    {
        private Controller leapController;
        private Form targetForm;
        private Button playButton;
        private Listener leapListener;
        Cursor palmCursor;
        public BackGroundTracking(Form form)
        {
            this.leapController = new Controller();
            this.leapListener = new LeapEventListener(this);
            this.leapController.AddListener(leapListener);
            
            
            this.targetForm = form;
            
            this.palmCursor = new Cursor(Cursor.Current.Handle);
            foreach (var control in targetForm.Controls)
            {
                if (control.GetType() == typeof(Button))
                {
                    playButton = control as Button; //cast control to button
                }
            }

        }
        delegate void LeapEventDelegate(string EventName);
        public void LeapEventNotification(string EventName)
        {
            
            switch (EventName)
            {
                case "onInit":
                    Debug.WriteLine("Init");
                    break;
                case "onConnect":
                    this.connectHandler();
                    break;
                case "onFrame":
                    this.newFrameHandler(this.leapController.Frame());
                    break;
            }
           
        }

        void connectHandler()
        {
            this.leapController.EnableGesture(Gesture.GestureType.TYPE_CIRCLE);
            this.leapController.Config.SetFloat("Gesture.Circle.MinRadius", 40.0f);
            this.leapController.EnableGesture(Gesture.GestureType.TYPE_SWIPE);
        }

        void newFrameHandler(Frame frame)
        {

            int gestureCount = 0;
            if (!frame.Hands.IsEmpty)
            {
                HandList handlist = frame.Hands;
                GestureList gestureList = frame.Gestures();
                //movingPalm((int)handlist[0].PalmPosition.x, (int)handlist[0].PalmPosition.y, palmCursor);
                playConfirm();

                if (!gestureList.IsEmpty)
                {
                    gestureCount = gestureList.Count;
                    switch (gestureList[gestureCount - 1].Type)
                    {
                        case Gesture.GestureType.TYPE_SWIPE:

                            
                            Form movieForm = new MovieForm();
                            movieForm.ShowDialog();

                            Debug.WriteLine("****" + this.leapController.HasFocus);
                            this.leapController.RemoveListener(this.leapListener);

                            break;
                        default:
                            break;
                    }


                }
            }


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


    public interface ILeapEventDelegate
    {
        void LeapEventNotification(string EventName);
    }



    public class LeapEventListener : Listener
    {
        ILeapEventDelegate eventDelegate;

        public LeapEventListener(ILeapEventDelegate delegateObject)
        {
            this.eventDelegate = delegateObject;
        }
        public override void OnInit(Controller controller)
        {
            this.eventDelegate.LeapEventNotification("onInit");
        }
        public override void OnConnect(Controller controller)
        {
            this.eventDelegate.LeapEventNotification("onConnect");
        }
        public override void OnFrame(Controller controller)
        {
            this.eventDelegate.LeapEventNotification("onFrame");
        }
        public override void OnExit(Controller controller)
        {
            this.eventDelegate.LeapEventNotification("onExit");
        }
        public override void OnDisconnect(Controller controller)
        {
            this.eventDelegate.LeapEventNotification("onDisconnect");
        }
    }
   
}
