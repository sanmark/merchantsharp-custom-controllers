using System;
using System.Windows;
namespace CustomControls.SanmarkSolutions.WPFCustomControls.MSTextBox
{
	public class TextType
	{
		public static readonly DependencyProperty OverWidthProperty = DependencyProperty.RegisterAttached("OverWidth", typeof(double), typeof(MSString), new PropertyMetadata(0.0));
		public static void SetOverWidth(UIElement element, double value)
		{
			element.SetValue(TextType.OverWidthProperty, value);
		}
		public static double GetOverWidth(UIElement element)
		{
			return (double)element.GetValue(TextType.OverWidthProperty);
		}
	}
}
