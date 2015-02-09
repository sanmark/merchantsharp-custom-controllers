using System;
using System.Windows.Controls;
namespace CustomControls.SanmarkSolutions.WPFCustomControls.MSClosableTab
{
	internal class TabControler
	{
		private ClosableTab closableTab = null;
		private TabControl tabControl = null;
		public TabControl TabControl
		{
			get
			{
				return this.tabControl;
			}
		}
		public TabControler(TabControl tabControl)
		{
			this.tabControl = tabControl;
		}
		internal void openNonClosableTab(UserControl userControl, string title)
		{
			try
			{
				TabItem tabItem = new TabItem();
				tabItem.Height = 30.0;
				tabItem.Header = title;
				tabItem.Content = userControl;
				this.tabControl.Items.Add(tabItem);
			}
			catch (Exception)
			{
			}
		}
		internal void openClosableTab(UserControl userControl, string title)
		{
			try
			{
				this.closableTab = new ClosableTab();
				this.closableTab.Height = 30.0;
				this.closableTab.Title = title;
				this.closableTab.Content = userControl;
				this.tabControl.Items.Add(this.closableTab);
				this.closableTab.Focus();
			}
			catch (Exception)
			{
			}
		}
		internal void openClosableTab(object manager, string title)
		{
			try
			{
				this.closableTab = new ClosableTab();
				this.closableTab.Height = 30.0;
				this.closableTab.Title = title;
				this.closableTab.Content = manager;
				this.tabControl.Items.Add(this.closableTab);
				this.closableTab.Focus();
			}
			catch (Exception)
			{
			}
		}
		internal void closeAllClosableTabs()
		{
		}
		internal TabItem getTab(int index)
		{
			TabItem result = null;
			try
			{
				result = (TabItem)this.tabControl.Items[index];
			}
			catch (Exception)
			{
			}
			return result;
		}
	}
}
