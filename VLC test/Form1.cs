using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Leap;
using System.Diagnostics;
using System.Drawing;

namespace VLC_test
{
    public partial class Form1 : Form, ILeapEventDelegate
    {
        private Controller controller;
        private LeapEventListener listener;
        private BackGroundTracking backgroundTracking;
        Cursor palmCursor;
        public Form1()
        {
            
            InitializeComponent();
            //palm.Show();
            this.controller = new Controller();
            this.listener = new LeapEventListener(this);
            this.controller.AddListener(listener);
            palmCursor = new Cursor(Cursor.Current.Handle);
            backgroundTracking = new BackGroundTracking(this.controller);
            
        }

        delegate void LeapEventDelegate(string EventName);
        public void LeapEventNotification(string EventName)
        {
            if (!this.InvokeRequired)
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
                        if (!this.Disposing)
                            this.newFrameHandler(this.controller.Frame());
                        break;
                }
            }
            else
            {
                BeginInvoke(new LeapEventDelegate(LeapEventNotification), new object[] { EventName });
            }
        }

        void connectHandler()
        {
            this.controller.EnableGesture(Gesture.GestureType.TYPE_CIRCLE);
            this.controller.Config.SetFloat("Gesture.Circle.MinRadius", 40.0f);
            this.controller.EnableGesture(Gesture.GestureType.TYPE_SWIPE);
        }

        void newFrameHandler(Frame frame)
        {
           
            int gestureCount = 0;
            if(!frame.Hands.IsEmpty)
            {
                HandList handlist = frame.Hands;
                GestureList gestureList = frame.Gestures();
                movingPalm((int)handlist[0].PalmPosition.x, (int)handlist[0].PalmPosition.y,palmCursor);
                playConfirm();

                if(!gestureList.IsEmpty)
                {
                    gestureCount = gestureList.Count;
                    switch(gestureList[gestureCount-1].Type)
                    {
                        case Gesture.GestureType.TYPE_SWIPE:

                            this.ActiveControl = null;
                            Form movieForm = new MovieForm();
                            movieForm.ShowDialog();

                            Debug.WriteLine("****" + this.controller.HasFocus);
                            this.controller.RemoveListener(this.listener);

                            break;
                        default:
                            break;
                    }


                }
            }


        }


        private void buttonPlay_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            Form movieForm = new MovieForm();
            movieForm.ShowDialog();
        }
       
        
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    if (components != null)
                    {
                        components.Dispose();
                    }
                    this.controller.RemoveListener(this.listener);
                    this.controller.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        public void movingPalm(int x,int y,Cursor palmCursor)
        {
            //palm.Location = new System.Drawing.Point(x+200, y+100);
            //Debug.Print(X);
            Cursor.Position = new System.Drawing.Point((x + 200)*2, this.Top + y*2);
            
        }

        public void playConfirm()
        {
            if(Cursor.Position.X > buttonPlay.Left &&
                Cursor.Position.X < (buttonPlay.Left + buttonPlay.Width) &&
                Cursor.Position.Y < buttonPlay.Top &&
                Cursor.Position.Y > (buttonPlay.Top - buttonPlay.Height))
            {
                buttonPlay.PerformClick();

            }


        }

    }//  end of class Form1





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
