using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leap;
using System.Windows.Forms;

namespace VLC_test
{
    class LeapListener : Listener
    {
        private Cursor palmCursor;
        private Form targetForm;
        public void movingPalm(int x, int y)
        {
            Cursor.Position = new System.Drawing.Point((x + 200) * 2, (y+200)*2);
        }

        public void OnInitial(Controller controller,Cursor palmCursor,Form targetForm)
        {
            
            this.palmCursor = palmCursor;
            this.targetForm = targetForm;
            this.targetForm = targetForm;
        }

        public override void OnFrame(Controller controller)
        {
            //base.OnFrame(controller);
            Frame newFrame = controller.Frame();
            

            int gestureCount = 0;
            if (!newFrame.Hands.IsEmpty)
            {
                mappingCoordinate(newFrame);
                HandList handlist = newFrame.Hands;
                GestureList gestureList = newFrame.Gestures();
                //movingPalm((int)handlist[0].PalmPosition.x, (int)handlist[0].PalmPosition.z);
                //movingPalm((int)handlist[0].StabilizedPalmPosition.x, (int)handlist[0].StabilizedPalmPosition.y);
                

                if (!gestureList.IsEmpty)
                {
                    gestureCount = gestureList.Count;
                    switch (gestureList[gestureCount - 1].Type)
                    {
                        case Gesture.GestureType.TYPE_SWIPE:

                            Form movieForm = new MovieForm();
                            movieForm.ShowDialog();

                            break;
                        default:
                            break;
                    }


                }
            }
        }//end OnFrame
        private void mappingCoordinate(Frame frame)
        {
            InteractionBox iBox = frame.InteractionBox;
            //Pointable pointable = frame.Pointables.Frontmost;



            //Leap.Vector leapPoint = pointable.StabilizedTipPosition;
            Leap.Vector leapPoint = frame.Hands[0].StabilizedPalmPosition;
            Leap.Vector normalizedPoint = iBox.NormalizePoint(leapPoint, false);

            float appX = normalizedPoint.x * targetForm.Width;
            float appY = normalizedPoint.z * targetForm.Height;

            Cursor.Position = new System.Drawing.Point((int)appX,(int)appY);

        }
    }
}
