using System;
using System.Linq;
using System.Windows.Controls;
namespace CustomControls.SanmarkSolutions.WPFCustomControls.MSTextBox
{
	internal class MSChequeNumber : TextBox
	{
		protected override void OnTextChanged(TextChangedEventArgs e)
		{
			try
			{
				int num = -1;
				if (!int.TryParse(base.Text, out num) || base.Text.Substring(base.Text.Length - 1) == " " || base.Text.Length > 6)
				{
					TextChange textChange = e.Changes.ElementAt(0);
					int addedLength = textChange.AddedLength;
					int offset = textChange.Offset;
					base.Text = base.Text.Remove(offset, addedLength);
					base.SelectionStart = base.Text.Length;
				}
				base.OnTextChanged(e);
			}
			catch (Exception)
			{
			}
		}
	}
}
