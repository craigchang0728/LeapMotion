namespace VLC_test
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        /*protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }*/

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonPlay = new System.Windows.Forms.Button();
            this.palm = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.palm)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(364, 249);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(136, 38);
            this.buttonPlay.TabIndex = 0;
            this.buttonPlay.Text = "play";
            this.buttonPlay.UseVisualStyleBackColor = true;
            //this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // palm
            // 
            this.palm.Image = ((System.Drawing.Image)(resources.GetObject("palm.Image")));
            this.palm.InitialImage = ((System.Drawing.Image)(resources.GetObject("palm.InitialImage")));
            this.palm.Location = new System.Drawing.Point(94, 57);
            this.palm.Name = "palm";
            this.palm.Size = new System.Drawing.Size(84, 82);
            this.palm.TabIndex = 1;
            this.palm.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 323);
            this.Controls.Add(this.palm);
            this.Controls.Add(this.buttonPlay);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.palm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.PictureBox palm;

    }
}

