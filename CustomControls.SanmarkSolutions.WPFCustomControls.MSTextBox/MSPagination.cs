using System;
using System.Linq;
using System.Windows.Controls;
namespace CustomControls.SanmarkSolutions.WPFCustomControls.MSTextBox
{
	internal class MSPagination : TextBox
	{
		protected override void OnTextChanged(TextChangedEventArgs e)
		{
			try
			{
				long num = -1L;
				if (!long.TryParse(base.Text, out num) || base.Text.Substring(base.Text.Length - 1) == " ")
				{
					TextChange textChange = e.Changes.ElementAt(0);
					int addedLength = textChange.AddedLength;
					int offset = textChange.Offset;
					base.Text = base.Text.Remove(offset, addedLength);
					base.SelectionStart = base.Text.Length;
				}
				if (base.Text == "0" || base.Text.Length < 1)
				{
					base.Text = "1";
					base.SelectAll();
				}
				base.OnTextChanged(e);
			}
			catch (Exception)
			{
			}
		}
	}
}
