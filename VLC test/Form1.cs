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


namespace VLC_test
{
    public partial class Form1 : Form
    {
       
        private BackGroundTracking backgroundTracking;
        public Panel mainPanel;

        public Form1()
        {
            
            InitializeComponent();

            mainPanel = new Panel();
            this.Controls.Add(mainPanel);
            mainPanel.AutoScroll = true;
            mainPanel.Size = new Size(300,300);

            ScrollBar vScrollBar = new VScrollBar();
            
            vScrollBar.Dock = DockStyle.Right;
            vScrollBar.Scroll += (sender, e) => { mainPanel.VerticalScroll.Value = vScrollBar.Value; };
            vScrollBar.Enabled = true;
            //vScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(vScrollBar.Scroll);
            mainPanel.Controls.Add(vScrollBar);
            this.Controls.Add(mainPanel);

            

            backgroundTracking = new BackGroundTracking(this);
            
        }
        
    }//  end of class Form1





}
