using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
namespace CustomControls.SanmarkSolutions.WPFCustomControls.MSListBox
{
	public class MSListBox : ListBox
	{
		private int selectedID = 0;
		private DataTable optionGroup = null;
		public int SelectedID
		{
			get
			{
				return this.selectedID;
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
		private void bindItems(DataTable dataTable)
		{
			try
			{
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
				this.selectedID = Convert.ToInt32(base.SelectedValue);
				this.ErrorMode(false);
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
					base.BorderThickness = new Thickness(2.0, 2.0, 2.0, 2.0);
					base.Focus();
				}
				else
				{
					base.BorderThickness = new Thickness(1.0, 1.0, 1.0, 1.0);
				}
			}
			catch (Exception)
			{
			}
		}
	}
}
