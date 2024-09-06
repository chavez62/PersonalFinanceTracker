using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PersonalFinanceTracker.Behaviors
{
    public static class WatermarkBehavior
    {
        public static readonly DependencyProperty WatermarkProperty =
            DependencyProperty.RegisterAttached(
                "Watermark",
                typeof(string),
                typeof(WatermarkBehavior),
                new PropertyMetadata(default(string), OnWatermarkChanged));

        public static string GetWatermark(DependencyObject obj)
        {
            return (string)obj.GetValue(WatermarkProperty);
        }

        public static void SetWatermark(DependencyObject obj, string value)
        {
            obj.SetValue(WatermarkProperty, value);
        }

        private static void OnWatermarkChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBox textBox)
            {
                // Detach previous event handlers
                textBox.GotFocus -= RemoveWatermark;
                textBox.LostFocus -= ApplyWatermark;

                // Attach event handlers
                textBox.GotFocus += RemoveWatermark;
                textBox.LostFocus += ApplyWatermark;

                // Apply watermark initially
                ApplyWatermark(textBox, null);
            }
        }

        private static void RemoveWatermark(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.Text == GetWatermark(textBox))
            {
                textBox.Text = string.Empty;
                textBox.Foreground = Brushes.Black; // Reset to normal text color
            }
        }

        private static void ApplyWatermark(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = GetWatermark(textBox);
                textBox.Foreground = Brushes.Gray; // Watermark color
            }
        }
    }
}
