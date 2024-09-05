using System.Windows;
using System.Windows.Controls;

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
                textBox.GotFocus += (sender, args) =>
                {
                    if (textBox.Text == GetWatermark(textBox))
                    {
                        textBox.Text = "";
                        textBox.Foreground = System.Windows.Media.Brushes.Black;
                    }
                };

                textBox.LostFocus += (sender, args) =>
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        textBox.Text = GetWatermark(textBox);
                        textBox.Foreground = System.Windows.Media.Brushes.Gray;
                    }
                };

                textBox.Text = GetWatermark(textBox);
                textBox.Foreground = System.Windows.Media.Brushes.Gray;
            }
        }
    }
}
