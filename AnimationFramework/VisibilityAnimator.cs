using System;
using System.ComponentModel;
using System.Windows;
using AnimationFramework.Animations;
using AnimationFramework.Core;

namespace AnimationFramework
{
    
    public static class VisibilityAnimator
    {

        public static readonly DependencyProperty IsVisible = DependencyProperty.RegisterAttached(
            "IsVisible",
            typeof (Boolean?),
            typeof (VisibilityAnimator),
            new PropertyMetadata(null, IsVisiblePropertyChangedCallback));

        public static bool GetIsVisible(DependencyObject d)
        {
            return (bool)d.GetValue(IsVisible);
        }

        public static void SetIsVisible(DependencyObject d, bool value)
        {
            d.SetValue(IsVisible, value);
        }

        public static void IsVisiblePropertyChangedCallback(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var control = sender as UIElement;

            if (control != null && e.NewValue is bool)
            {
                if (((bool) e.NewValue))
                {
                    //Direction from Collapsed to Visible
                    var animation = (IAnimation) sender.GetValue(InAnimation);
                    AnimationExecutor.BeginAnimation(sender,animation);
                }
                else
                {
                    sender.SetValue(UIElement.VisibilityProperty,Visibility.Collapsed);
                }

            }
        }

        public static readonly DependencyProperty InAnimation = DependencyProperty.RegisterAttached(
            "InAnimation",
            typeof (IAnimation),
            typeof (VisibilityAnimator),
            new PropertyMetadata(null, null));

        public static IAnimation GetInAnimation(DependencyObject d)
        {
            return (IAnimation)d.GetValue(InAnimation);
        }

        public static void SetInAnimation(DependencyObject d, IAnimation value)
        {
            d.SetValue(InAnimation, value);
        }
    }
}
