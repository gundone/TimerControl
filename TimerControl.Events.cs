using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimerControl
{
    public partial class TimerControl
    {
	    public event EventHandler CountDownReached;

	    protected virtual void OnCountDownReached()
	    {
		    CountDownReached?.Invoke(this, EventArgs.Empty);
	    }
    }
}
