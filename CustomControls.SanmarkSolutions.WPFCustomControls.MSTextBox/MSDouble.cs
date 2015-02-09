using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
namespace CustomControls.SanmarkSolutions.WPFCustomControls.MSTextBox
{
	internal class MSDouble : TextBox
	{
		private double value = 0.0;
		public double Value
		{
			get
			{
				return this.value;
			}
			set
			{
				this.value = value;
			}
		}
		private void setValue()
		{
			try
			{
				this.value = Convert.ToDouble(base.Text);
			}
			catch (Exception)
			{
				this.value = 0.0;
			}
		}
		protected override void OnTextChanged(TextChangedEventArgs e)
		{
			try
			{
				double num = -1.0;
				int num2 = base.Text.IndexOf('.');
				int num3 = -1;
				if (num2 > -1)
				{
					num3 = base.Text.Substring(num2).Length;
				}
				if (base.Text == ".")
				{
					base.Text = "0.";
					base.SelectionStart = base.Text.Length;
				}
				if (!double.TryParse(base.Text, out num) || base.Text.Substring(base.Text.Length - 1) == " " || num3 > 4)
				{
					TextChange textChange = e.Changes.ElementAt(0);
					int addedLength = textChange.AddedLength;
					int offset = textChange.Offset;
					base.Text = base.Text.Remove(offset, addedLength);
					base.SelectionStart = base.Text.Length;
				}
				this.setValue();
				base.OnTextChanged(e);
			}
			catch (Exception)
			{
			}
		}
		protected override void OnGotFocus(RoutedEventArgs e)
		{
			base.SelectAll();
			base.OnGotFocus(e);
		}
	}
}
