using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AnimationFramework.Animations;

namespace AnimationFramework.Core
{
    internal static class AnimationExecutor
    {
        internal static void BeginAnimation(DependencyObject animationTarget, IAnimation animationProvider)
        {
            var animationToExecute = animationProvider.GetAnimationStoryboard(animationTarget);
            if(animationToExecute != null)
                animationToExecute.Begin();
        }
    }
}
