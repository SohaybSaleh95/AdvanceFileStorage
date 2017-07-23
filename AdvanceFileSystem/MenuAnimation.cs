using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace AdvanceFileSystem
{
    public class MenuAnimation : DoubleAnimation
    {
        public MenuAnimation()
        {
            this.From = 0;
            this.To = 70;
            this.Duration = new Duration(TimeSpan.FromMilliseconds(250));
        }

        public void ReverseAnimation()
        {
            double? temp = this.From;
            this.From = this.To;
            this.To = temp;
        }
    }
}
