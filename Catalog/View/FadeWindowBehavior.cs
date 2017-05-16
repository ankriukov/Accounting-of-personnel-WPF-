using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;
using System.Windows.Media.Animation;

namespace Catalog.View
{
    public class FadeWindowBehavior : Behavior<Window>
    {
        public FadeWindowBehavior()
        {
            _fadeInStoryboard = new Storyboard
            {
                Duration = TimeSpan.FromSeconds(2),
                Children =
                {
                    new DoubleAnimation
                    {
                        To = 1
                    }
                }
            };

            _fadeOutStoryboard = new Storyboard
            {
                Duration = TimeSpan.FromSeconds(1),
                Children =
                {
                    new DoubleAnimation
                    {
                        To = 0
                    }
                }
            };

            Storyboard.SetTargetProperty(_fadeInStoryboard, new PropertyPath(UIElement.OpacityProperty));
            Storyboard.SetTargetProperty(_fadeOutStoryboard, new PropertyPath(UIElement.OpacityProperty));
        }

        private readonly Storyboard _fadeInStoryboard;
        private readonly Storyboard _fadeOutStoryboard;

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Opacity = 0;
            AssociatedObject.Loaded += OnWindowLoaded;
            AssociatedObject.Closing += OnWindowClosing;
        }

        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            _fadeInStoryboard.Begin(AssociatedObject);
        }

        private void OnWindowClosing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            AssociatedObject.Closing -= OnWindowClosing;

            _fadeOutStoryboard.Completed += (o, a) => AssociatedObject.Close();
            _fadeOutStoryboard.Begin(AssociatedObject);
        }
    }
}
