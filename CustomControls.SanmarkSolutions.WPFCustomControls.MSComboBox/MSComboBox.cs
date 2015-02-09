using System;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
namespace CustomControls.SanmarkSolutions.WPFCustomControls.MSComboBox
{
	public class MSComboBox : ComboBox
	{
		private static double dValue = -1.0;
		private string addNewLink = null;
		private DataTable optionGroup = null;
		private Window addLinkWindow = null;
		private bool isPermissionDenied = false;
		private int value = 0;
		private string displayValue = "0.00";
		private string type = "String";
		private TextBox editTextBox = null;
		public string AddNewLink
		{
			get
			{
				return this.addNewLink;
			}
			set
			{
				this.addNewLink = value;
			}
		}
		public DataTable OptionGroup
		{
			get
			{
				return this.optionGroup;
			}
			set
			{
				this.optionGroup = value;
				this.bindItems(value);
			}
		}
		public Window AddLinkWindow
		{
			get
			{
				return this.addLinkWindow;
			}
			set
			{
				this.addLinkWindow = value;
			}
		}
		public bool IsPermissionDenied
		{
			get
			{
				return this.isPermissionDenied;
			}
			set
			{
				this.isPermissionDenied = value;
			}
		}
		public int Value
		{
			get
			{
				return this.value;
			}
			set
			{
				this.value = value;
				base.SelectedValue = value;
			}
		}
		public string DisplayValue
		{
			get
			{
				try
				{
					DataRowView dataRowView = (DataRowView)base.SelectedItem;
					if (dataRowView != null)
					{
						this.displayValue = Convert.ToDouble(dataRowView[1]).ToString();
					}
					else
					{
						this.displayValue = Convert.ToDouble(this.editTextBox.Text).ToString();
					}
				}
				catch (Exception)
				{
					this.displayValue = "0.00";
				}
				return this.displayValue;
			}
		}
		public double DoubleValue
		{
			get
			{
				double result;
				try
				{
					DataRowView dataRowView = (DataRowView)base.SelectedItem;
					if (dataRowView != null)
					{
						result = Convert.ToDouble(dataRowView[1]);
					}
					else
					{
						result = Convert.ToDouble(this.editTextBox.Text);
					}
				}
				catch (Exception)
				{
					result = 0.0;
				}
				return result;
			}
		}
		public string Type
		{
			get
			{
				return this.type;
			}
			set
			{
				this.type = value;
			}
		}
		public MSComboBox()
		{
			try
			{
				base.Loaded += delegate(object param0, RoutedEventArgs param1)
				{
					this.editTextBox = (base.Template.FindName("PART_EditableTextBox", this) as TextBox);
					if (this.editTextBox != null)
					{
						this.editTextBox.TextChanged += new TextChangedEventHandler(this.callback);
					}
				};
			}
			catch (Exception)
			{
			}
		}
		private void callback(object sender, TextChangedEventArgs e)
		{
			try
			{
				if (this.type == "Double")
				{
					int num = this.editTextBox.Text.IndexOf('.');
					int num2 = -1;
					if (num > -1)
					{
						num2 = this.editTextBox.Text.Substring(num).Length;
					}
					if (this.editTextBox.Text == ".")
					{
						this.editTextBox.Text = "0.";
						this.editTextBox.SelectionStart = this.editTextBox.Text.Length;
					}
					if (!double.TryParse(this.editTextBox.Text, out MSComboBox.dValue) || this.editTextBox.Text.Substring(this.editTextBox.Text.Length - 1) == " " || num2 > 3)
					{
						this.removeLastChar(e);
					}
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
				this.editTextBox.Text = this.editTextBox.Text.Remove(offset, addedLength);
				this.editTextBox.SelectionStart = this.editTextBox.Text.Length;
			}
			catch (Exception)
			{
			}
		}
		private void bindItems(DataTable dataTable)
		{
			try
			{
				if (!this.isPermissionDenied && this.addNewLink != null)
				{
					dataTable.Rows.Add(new object[]
					{
						-1,
						this.addNewLink
					});
				}
				base.ItemsSource = dataTable.DefaultView;
				base.SelectedValuePath = dataTable.Columns[0].ColumnName;
				base.DisplayMemberPath = dataTable.Columns[1].ColumnName;
			}
			catch (Exception)
			{
			}
		}
		protected override void OnSelectionChanged(SelectionChangedEventArgs e)
		{
			try
			{
				this.value = Convert.ToInt32(base.SelectedValue);
				this.displayValue = base.SelectedItem.ToString();
				if (Convert.ToInt32(base.SelectedValue) == -1 && this.addLinkWindow != null && !this.isPermissionDenied)
				{
					this.addLinkWindow.ShowDialog();
				}
			}
			catch (Exception)
			{
			}
			base.OnSelectionChanged(e);
		}
		public void ErrorMode(bool b)
		{
			try
			{
				if (b)
				{
					base.IsDropDownOpen = true;
				}
			}
			catch (Exception)
			{
			}
		}
	}
}
