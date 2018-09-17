using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimerControl
{
    public partial class TimerControl: UserControl
    {
	    


	    readonly Timer _timer1 = new Timer();

	    public bool TimerEnabled => _timer1.Enabled;
		#region Control's Properties

	    private int _h;
	    [Description("Hours"), Category("Data")] 
	    public int Hours {
		    get => _h;
		    set
		    {
			    _h = value;
			    SetTime();
			    if (_h > 0 || _m > 0 || _s > 0 || !CountDown || !_timer1.Enabled)
			    {
					return;
			    }
			    _h = 0;
			    _m = 0;
			    _s = 0;
			    _timer1.Enabled = false;
			    startStopBtn.Text = @"Start";
			    CountDownReached?.Invoke(this, EventArgs.Empty);

		    } 
	    }

	    private int _m;
	    [Description("Minutes"), Category("Data")] 
	    public int Minutes
	    {
		    get => _m;
		    set
		    {
			    _m = value % 60;
			    Hours = (value / 60) >= 1 ?  (int) value / 60 : _h;
			    if (_m < 0)
			    {
				    _m = 59;
				    Hours--;
			    }
		    } 
	    }

	    private decimal _s;
	    [Description("Seconds"), Category("Data")] 
	    public decimal Seconds
	    {
		    get => _s;
		    set
		    {
			    _s = value % 60;
				
			    Minutes = (value / 60) >= 1 ?  (int) value / 60 : _m;
			    if (_s < 0)
			    {
				    _s = 59;
				    Minutes--;
			    }
		    }
	    }

	    [Description("CountDown"), Category("Data")] 
	    public bool CountDown { get; set; }

	  


	    [Description("Value"), Category("Data")] 
	    public TimeSpan Value 
	    {
		    get => new TimeSpan(_h, _m, (int)_s);
		    set
		    {
			    _h = value.Hours;
			    _m = value.Minutes;
			    _s = value.Seconds;
		    }
	    }


	    [Description("Manual start-stop"), Category("Data")] 
	    public bool Manual {
		    get => startStopBtn.Visible;
		    set => startStopBtn.Visible = value;
	    }
		#endregion

	    private void SetTime()
	    {
		    Task.Run(() =>
		    {
			    if (timerBox.InvokeRequired)
			    {
				    timerBox.BeginInvoke((Action)(() => { timerBox.Text = $@"{_h:D2}:{_m:D2}:{_s:00}"; }));
			    }
			    else
			    {
				    timerBox.Text = $@"{_h:D2}:{_m:D2}:{_s:00}";
			    }
		    });
	    }


	    public TimerControl()
	    {
		    _timer1.Interval = 1000;
		    _timer1.Tick += timer1_Tick;
		    InitializeComponent();
		   
		    Console.WriteLine(Stopwatch.IsHighResolution
			    ? @"Operations timed using the system's high-resolution performance counter."
			    : @"Operations timed using the DateTime class.");
	    }

		private void timer1_Tick(object sender, EventArgs e)
		{
			Seconds += CountDown ? -_timer1.Interval / 1000m : _timer1.Interval / 1000m;
		}

		private void startStopBtn_Click(object sender, EventArgs e)
		{
			Toggle();
		}

	    public void Start()
	    {
		    _timer1.Enabled = true;
		    startStopBtn.Text = @"Stop";
		}

	    public void Stop()
	    {
		    _timer1.Enabled = false;
		    startStopBtn.Text = @"Start";
	    }

	    public void Toggle()
	    {
		    _timer1.Enabled = !_timer1.Enabled;
		    startStopBtn.Text = _timer1.Enabled ? @"Stop" : @"Start";
	    }


		private void timerBox_TextChanged(object sender, EventArgs e)
		{
			try
			{
				var t = timerBox.Text.Split(':').Select(int.Parse).ToArray();
				_h = t[0];
				_m = t[1];
				_s = t[2];
			}
			catch
			{
				//supress incorrect input
				Value = TimeSpan.Zero;
			}
			SetTime();
		}
	}
}
