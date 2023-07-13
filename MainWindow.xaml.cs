using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly RoutedUICommand Bold = new RoutedUICommand("Bold", "Bold", typeof(MainWindow));
        public static readonly RoutedUICommand Italic = new RoutedUICommand("Italic", "Italic", typeof(MainWindow));
        public static readonly RoutedUICommand Underline = new RoutedUICommand("Underline", "Underline", typeof(MainWindow));
        public static readonly RoutedUICommand Clear = new RoutedUICommand("Clear", "Clear", typeof(MainWindow));
        public static readonly RoutedUICommand FontSize15 = new RoutedUICommand("Font 15", "FontSize15", typeof(MainWindow));
        public static readonly RoutedUICommand FontSize30 = new RoutedUICommand("Font 30", "FontSize30", typeof(MainWindow));
        public static readonly RoutedUICommand RedColor = new RoutedUICommand("Red", "RedColor", typeof(MainWindow));
        public static readonly RoutedUICommand GreenColor = new RoutedUICommand("Green", "GreenColor", typeof(MainWindow));
        public static readonly RoutedUICommand BlueColor = new RoutedUICommand("Blue", "BlueColor", typeof(MainWindow));

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Bold_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ApplyFormattingToSelection(TextElement.FontWeightProperty, FontWeights.Bold);
        }

        private void Italic_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ApplyFormattingToSelection(TextElement.FontStyleProperty, FontStyles.Italic);
        }

        private void Underline_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ApplyFormattingToSelection(Inline.TextDecorationsProperty, TextDecorations.Underline);
        }

        private void Clear_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ApplyFormattingToSelection(TextElement.FontWeightProperty, DependencyProperty.UnsetValue);
            ApplyFormattingToSelection(TextElement.FontStyleProperty, DependencyProperty.UnsetValue);
            ApplyFormattingToSelection(Inline.TextDecorationsProperty, DependencyProperty.UnsetValue);
            ApplyFormattingToSelection(TextElement.FontSizeProperty, DependencyProperty.UnsetValue);
            ApplyFormattingToSelection(TextElement.ForegroundProperty, DependencyProperty.UnsetValue);
        }

        private void FontSize15_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ApplyFormattingToSelection(TextElement.FontSizeProperty, 15.0);
        }

        private void FontSize30_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ApplyFormattingToSelection(TextElement.FontSizeProperty, 30.0);
        }

        private void RedColor_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ApplyFormattingToSelection(TextElement.ForegroundProperty, Brushes.Red);
        }

        private void GreenColor_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ApplyFormattingToSelection(TextElement.ForegroundProperty, Brushes.Green);
        }

        private void BlueColor_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ApplyFormattingToSelection(TextElement.ForegroundProperty, Brushes.Blue);
        }

        private void ApplyFormattingToSelection(DependencyProperty property, object value)
        {
            if (richTextbox.Selection.IsEmpty)
            {
                richTextbox.Selection.ApplyPropertyValue(property, value);
            }
            else
            {
                TextRange range = new TextRange(richTextbox.Selection.Start, richTextbox.Selection.End);
                range.ApplyPropertyValue(property, value);
            }
        }
    }
}
