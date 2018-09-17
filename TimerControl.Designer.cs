namespace TimerControl
{
    partial class TimerControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.timerBox = new System.Windows.Forms.TextBox();
			this.startStopBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// timerBox
			// 
			this.timerBox.Location = new System.Drawing.Point(3, 4);
			this.timerBox.Name = "timerBox";
			this.timerBox.Size = new System.Drawing.Size(109, 20);
			this.timerBox.TabIndex = 0;
			this.timerBox.Text = "00:00:00.000";
			this.timerBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.timerBox.TextChanged += new System.EventHandler(this.timerBox_TextChanged);
			// 
			// startStopBtn
			// 
			this.startStopBtn.Location = new System.Drawing.Point(116, 2);
			this.startStopBtn.Name = "startStopBtn";
			this.startStopBtn.Size = new System.Drawing.Size(51, 24);
			this.startStopBtn.TabIndex = 1;
			this.startStopBtn.Text = "Start";
			this.startStopBtn.UseVisualStyleBackColor = true;
			this.startStopBtn.Click += new System.EventHandler(this.startStopBtn_Click);
			// 
			// TimerControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.Controls.Add(this.startStopBtn);
			this.Controls.Add(this.timerBox);
			this.Name = "TimerControl";
			this.Size = new System.Drawing.Size(172, 29);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion
		private System.Windows.Forms.TextBox timerBox;
		private System.Windows.Forms.Button startStopBtn;
	}
}
