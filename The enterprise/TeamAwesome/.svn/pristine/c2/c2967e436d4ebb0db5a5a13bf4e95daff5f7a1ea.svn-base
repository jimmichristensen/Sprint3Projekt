using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.VisualStyles;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace TheEnterprise
{
    class AnimationClass : Window
    {
        public static void fadeOut(UIElement itemToBeAnimated, double animationTimeInSeconds)
        {
            DoubleAnimation da = new DoubleAnimation();
            da.From = 1;
            da.To = 0;
            da.Duration = new Duration(TimeSpan.FromSeconds(animationTimeInSeconds));
            itemToBeAnimated.BeginAnimation(OpacityProperty, da);
        }

        public static void fadeIn(UIElement itemToBeAnimated, double animationTimeInSeconds)
        {
            DoubleAnimation da = new DoubleAnimation();
            da.From = 0;
            da.To = 1;
            da.Duration = new Duration(TimeSpan.FromSeconds(animationTimeInSeconds));
            itemToBeAnimated.BeginAnimation(OpacityProperty, da);
        }

        public static void fadeInOut(UIElement itemToBeAnimated, double animationTimeInSeconds, int timesRepeated)
        {
            DoubleAnimation da = new DoubleAnimation();
            da.From = 1;
            da.To = 0;
            da.Duration = new Duration(TimeSpan.FromSeconds(animationTimeInSeconds));
            da.AutoReverse = true;
            da.RepeatBehavior = new RepeatBehavior(timesRepeated);
            itemToBeAnimated.BeginAnimation(OpacityProperty, da);
        }
    }
}
