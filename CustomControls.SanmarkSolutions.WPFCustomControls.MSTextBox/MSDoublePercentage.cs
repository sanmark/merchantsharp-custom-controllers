using System;
using System.Linq;
using System.Windows.Controls;
namespace CustomControls.SanmarkSolutions.WPFCustomControls.MSTextBox
{
	internal class MSDoublePercentage : TextBox
	{
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
				if (base.Text.Length > 0 && base.Text.Substring(base.Text.Length - 1) == "%")
				{
					bool flag = false;
					double num4 = 0.0;
					try
					{
						if (base.Text.Contains("%"))
						{
							num4 = Convert.ToDouble(base.Text.Replace("%", ""));
						}
						else
						{
							num4 = Convert.ToDouble(base.Text);
						}
					}
					catch (Exception)
					{
						num4 = 0.0;
					}
					if (num4 > 100.0)
					{
						this.removeLastChar(e);
					}
					else
					{
						for (int i = 0; i < base.Text.Length; i++)
						{
							if (flag)
							{
								this.removeLastChar(e);
							}
							else
							{
								if (base.Text.Substring(i, 1) == "%")
								{
									flag = true;
									if (base.Text.Length == 1)
									{
										this.removeLastChar(e);
									}
								}
							}
						}
					}
				}
				else
				{
					if (!double.TryParse(base.Text, out num) || base.Text.Substring(base.Text.Length - 1) == " " || num3 > 3)
					{
						this.removeLastChar(e);
					}
				}
				base.OnTextChanged(e);
			}
			catch (Exception)
			{
			}
		}
		private void removeLastChar(TextChangedEventArgs e)
		{
			try
			{
				TextChange textChange = e.Changes.ElementAt(0);
				int addedLength = textChange.AddedLength;
				int offset = textChange.Offset;
				base.Text = base.Text.Remove(offset, addedLength);
				base.SelectionStart = base.Text.Length;
			}
			catch (Exception)
			{
			}
		}
	}
}
