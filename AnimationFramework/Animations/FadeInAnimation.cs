using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace AnimationFramework.Animations
{
    public class FadeInAnimation : AnimationCore
    {
        private const string OPACITY_PROPERTY_PATH = "Opacity";
        private const string VISIBILITY_PROPERTY_PATH = "Visibility";

        public override Storyboard GetAnimationStoryboard(DependencyObject animationTarget)
        {
            var storyboard = new Storyboard { FillBehavior = FillBehavior.HoldEnd };
            var opacityKeyFrames = new DoubleAnimationUsingKeyFrames();
            var visibilityKeyFrames = new ObjectAnimationUsingKeyFrames();

            var visibilityFrame = new DiscreteObjectKeyFrame()
            {
                KeyTime = KeyTime.FromTimeSpan(TimeSpan.Zero),
                Value = Visibility.Visible
            };

            var opacityStartFrame = new EasingDoubleKeyFrame
            {
                KeyTime = KeyTime.FromTimeSpan(TimeSpan.Zero),
                Value = 0,
            };

            var opacityEndFrame = new EasingDoubleKeyFrame
            {
                KeyTime = KeyTime.FromTimeSpan(Duration),
                Value = 1,
            };

            visibilityKeyFrames.KeyFrames.Add(visibilityFrame);
            opacityKeyFrames.KeyFrames.Add(opacityStartFrame);
            opacityKeyFrames.KeyFrames.Add(opacityEndFrame);

            SetStoryboardBindings(animationTarget, visibilityKeyFrames, VISIBILITY_PROPERTY_PATH,storyboard);
            SetStoryboardBindings(animationTarget, opacityKeyFrames, OPACITY_PROPERTY_PATH, storyboard);

            return storyboard;
        }
    }
}
