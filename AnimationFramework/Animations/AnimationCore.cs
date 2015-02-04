using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace AnimationFramework.Animations
{
    public abstract class AnimationCore: IAnimation
    {
        public TimeSpan Duration { get; set; }

        public abstract System.Windows.Media.Animation.Storyboard GetAnimationStoryboard(
            System.Windows.DependencyObject animationTarget);

        protected virtual void SetStoryboardBindings(DependencyObject animationTarget, Timeline animationTimeline,
            string propertyPath, Storyboard storyboard)
        {
            storyboard.Children.Add(animationTimeline);
            Storyboard.SetTarget(animationTimeline, animationTarget);
            Storyboard.SetTargetProperty(animationTimeline, new PropertyPath(propertyPath));
        }
    }
}
