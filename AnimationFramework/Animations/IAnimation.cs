using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace AnimationFramework.Animations
{
    public interface IAnimation
    {
        TimeSpan Duration { get; set; }
        Storyboard GetAnimationStoryboard(DependencyObject animationTarget);
    }
}
