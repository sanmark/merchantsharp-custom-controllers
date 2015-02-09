using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
namespace CustomControls.SanmarkSolutions.WPFCustomControls.MSTextBox
{
	public class MSTextBox : TextBox
	{
		private string type = "String";
		private ListBox listBox = null;
		private double doubleValue = 0.0;
		private int intValue = 0;
		private static int iValue = -1;
		private static double dValue = -1.0;
		private BrushConverter bc = new BrushConverter();
		private string formattedValue = "0.00";
		public string Type
		{
			get
			{
				return this.type;
			}
			set
			{
				this.type = value;
				if (this.type == "Double" || this.type == "DoublePercentage")
				{
					base.HorizontalContentAlignment = HorizontalAlignment.Right;
				}
			}
		}
		public string TrimedText
		{
			get
			{
				return Regex.Replace(base.Text.Trim(), "\\s+", " ");
			}
		}
		public ListBox ListBox
		{
			set
			{
				this.listBox = value;
			}
		}
		public double DoubleValue
		{
			get
			{
				return this.doubleValue;
			}
			set
			{
				base.Text = value.ToString("#,##0.00");
			}
		}
		public int IntValue
		{
			get
			{
				return this.intValue;
			}
			set
			{
				base.Text = value.ToString();
			}
		}
		public string FormattedValue
		{
			get
			{
				return this.formattedValue;
			}
		}
		public MSTextBox()
		{
			try
			{
				if (this.type == "Double" || this.type == "DoublePercentage")
				{
					base.HorizontalContentAlignment = HorizontalAlignment.Right;
				}
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
		private void setDoubleValue()
		{
			try
			{
				this.doubleValue = Convert.ToDouble(base.Text);
				this.formattedValue = this.DoubleValue.ToString("#,##0.00");
			}
			catch (Exception)
			{
				this.doubleValue = 0.0;
			}
		}
		private void setIntValue()
		{
			try
			{
				this.intValue = Convert.ToInt32(base.Text);
			}
			catch (Exception)
			{
				this.intValue = 0;
			}
		}
		protected override void OnTextChanged(TextChangedEventArgs e)
		{
			try
			{
				if (this.Type == "String")
				{
					base.OnTextChanged(e);
				}
				else
				{
					if (this.Type == "ChequeNumber" && (!int.TryParse(base.Text, out MSTextBox.iValue) || base.Text.Substring(base.Text.Length - 1) == " " || base.Text.Length > 6))
					{
						this.removeLastChar(e);
					}
					else
					{
						if (this.Type == "Double")
						{
							int num = base.Text.IndexOf('.');
							int num2 = -1;
							if (num > -1)
							{
								num2 = base.Text.Substring(num).Length;
							}
							if (base.Text == ".")
							{
								base.Text = "0.";
								base.SelectionStart = base.Text.Length;
							}
							if (!double.TryParse(base.Text, out MSTextBox.dValue) || base.Text.Substring(base.Text.Length - 1) == " " || num2 > 4)
							{
								this.removeLastChar(e);
							}
							this.setDoubleValue();
							base.OnTextChanged(e);
						}
						else
						{
							if (this.Type == "DoublePercentage")
							{
								int num3 = base.Text.IndexOf('.');
								int num2 = -1;
								if (num3 > -1)
								{
									num2 = base.Text.Substring(num3).Length;
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
											this.setDoubleValue();
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
									if (!double.TryParse(base.Text, out MSTextBox.dValue) || base.Text.Substring(base.Text.Length - 1) == " " || num2 > 3)
									{
										this.removeLastChar(e);
										this.setDoubleValue();
									}
									else
									{
										this.setDoubleValue();
									}
								}
								base.OnTextChanged(e);
							}
							else
							{
								if (this.Type == "Integer")
								{
									if (!int.TryParse(base.Text, out MSTextBox.iValue) || base.Text.Substring(base.Text.Length - 1) == " ")
									{
										this.removeLastChar(e);
									}
									this.setIntValue();
									base.OnTextChanged(e);
								}
								else
								{
									if (this.Type == "Pagination")
									{
										if (!int.TryParse(base.Text, out MSTextBox.iValue) || base.Text.Substring(base.Text.Length - 1) == " ")
										{
											this.removeLastChar(e);
										}
										if (base.Text == "0" || base.Text.Length < 1)
										{
											base.Text = "1";
											base.SelectAll();
										}
										this.setIntValue();
										base.OnTextChanged(e);
									}
									else
									{
										base.OnTextChanged(e);
									}
								}
							}
						}
					}
				}
				this.ErrorMode(false);
			}
			catch (Exception)
			{
				base.OnTextChanged(e);
			}
		}
		protected override void OnGotFocus(RoutedEventArgs e)
		{
			try
			{
				base.SelectAll();
			}
			catch (Exception)
			{
			}
			base.OnGotFocus(e);
		}
		protected override void OnKeyUp(KeyEventArgs e)
		{
			try
			{
				if (this.Type == "String" && e.Key == Key.Down && this.listBox != null && this.listBox.Items.Count > 0)
				{
					this.listBox.Focus();
					this.listBox.SelectedIndex = 0;
				}
			}
			catch (Exception)
			{
			}
			base.OnKeyUp(e);
		}
		public void ErrorMode(bool b)
		{
			try
			{
				if (b)
				{
					base.BorderThickness = new Thickness(2.0, 2.0, 2.0, 2.0);
					base.BorderBrush = Brushes.Red;
					base.Focus();
				}
				else
				{
					base.BorderThickness = new Thickness(1.0, 1.0, 1.0, 1.0);
					base.BorderBrush = (Brush)this.bc.ConvertFrom("#FFABADB3");
				}
			}
			catch (Exception)
			{
			}
		}
		public bool IsNull()
		{
			bool result;
			try
			{
				result = string.IsNullOrWhiteSpace(base.Text);
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}
	}
}
