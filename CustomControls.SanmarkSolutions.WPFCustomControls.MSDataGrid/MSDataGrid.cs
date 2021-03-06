using System;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
namespace CustomControls.SanmarkSolutions.WPFCustomControls.MSDataGrid
{
	public class MSDataGrid : DataGrid
	{
		private string hideColumnIndexes = null;
		private int selectedItemID = 0;
		private int itemIdIndex = 0;
		private IFooter iFooter = null;
		private string totalColumnIndexes = null;
		private string textAlignRightColumnIndexes = null;
		private static Style s = null;
		public string HideColumnIndexes
		{
			get
			{
				return this.hideColumnIndexes;
			}
			set
			{
				this.hideColumnIndexes = value;
			}
		}
		public int SelectedItemID
		{
			get
			{
				return this.selectedItemID;
			}
		}
		public int ItemIdIndex
		{
			get
			{
				return this.itemIdIndex;
			}
			set
			{
				this.itemIdIndex = value;
			}
		}
		public IFooter IFooter
		{
			get
			{
				return this.iFooter;
			}
			set
			{
				this.iFooter = value;
			}
		}
		public string TotalColumnIndexes
		{
			get
			{
				return this.totalColumnIndexes;
			}
			set
			{
				this.totalColumnIndexes = value;
			}
		}
		public string TextAlignRightColumnIndexes
		{
			set
			{
				this.textAlignRightColumnIndexes = value;
			}
		}
		public MSDataGrid()
		{
			try
			{
				CollectionView collectionView = (CollectionView)CollectionViewSource.GetDefaultView(base.Items);
				((INotifyCollectionChanged)collectionView).CollectionChanged += new NotifyCollectionChangedEventHandler(this.callBack_NotifyCollectionChangedEventHandler);
				base.AutoGenerateColumns = true;
				base.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
				base.IsReadOnly = true;
				if (MSDataGrid.s == null)
				{
					MSDataGrid.s = new Style();
					MSDataGrid.s.Setters.Add(new Setter(TextBlock.TextAlignmentProperty, TextAlignment.Right));
				}
			}
			catch (Exception)
			{
			}
		}
		private void setTextAlignRight()
		{
			try
			{
				if (this.textAlignRightColumnIndexes != null && this.textAlignRightColumnIndexes.Length > 0)
				{
					int[] array = (
						from n in this.textAlignRightColumnIndexes.Split(new char[]
						{
							','
						})
						select Convert.ToInt32(n)).ToArray<int>();
					for (int i = 0; i < array.Length; i++)
					{
						base.Columns[array[i]].CellStyle = MSDataGrid.s;
						base.Columns[array[i]].MinWidth = 80.0;
					}
				}
				else
				{
					if (this.totalColumnIndexes != null && this.totalColumnIndexes.Length > 0)
					{
						int[] array = (
							from n in this.totalColumnIndexes.Split(new char[]
							{
								','
							})
							select Convert.ToInt32(n)).ToArray<int>();
						for (int i = 0; i < array.Length; i++)
						{
							base.Columns[array[i]].CellStyle = MSDataGrid.s;
							base.Columns[array[i]].MinWidth = 80.0;
						}
					}
				}
			}
			catch (Exception)
			{
			}
		}
		private void callBack_NotifyCollectionChangedEventHandler(object sender, NotifyCollectionChangedEventArgs e)
		{
			try
			{
				this.setTextAlignRight();
				if (this.IFooter != null && base.Columns.Count > 0)
				{
					this.IFooter.dataContextBinded(this);
				}
			}
			catch (Exception)
			{
			}
		}
		protected override void OnAutoGeneratedColumns(EventArgs e)
		{
			try
			{
				if (this.hideColumnIndexes != null && this.hideColumnIndexes.Length > 0)
				{
					int[] array = (
						from n in this.hideColumnIndexes.Split(new char[]
						{
							','
						})
						select Convert.ToInt32(n)).ToArray<int>();
					for (int i = 0; i < array.Length; i++)
					{
						base.Columns[i].Visibility = Visibility.Hidden;
					}
				}
			}
			catch (Exception)
			{
			}
			base.OnAutoGeneratedColumns(e);
		}
		protected override void OnSelectionChanged(SelectionChangedEventArgs e)
		{
			try
			{
				DataRowView dataRowView = (DataRowView)base.SelectedItem;
				this.selectedItemID = Convert.ToInt32(dataRowView[this.itemIdIndex]);
			}
			catch (Exception)
			{
				this.selectedItemID = 0;
			}
			base.OnSelectionChanged(e);
		}
	}
}
