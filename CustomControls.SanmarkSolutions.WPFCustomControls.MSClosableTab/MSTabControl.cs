using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
namespace CustomControls.SanmarkSolutions.WPFCustomControls.MSClosableTab
{
	public class MSTabControl : UserControl, IComponentConnector
	{
		private TabControler tabControler = null;
		internal TabControl mSTabControl;
		private bool _contentLoaded;
		public MSTabControl()
		{
			this.InitializeComponent();
			this.tabControler = new TabControler(this.mSTabControl);
		}
		public void openNonClosableTab(UserControl userControl, string title)
		{
			try
			{
				this.tabControler.openNonClosableTab(userControl, title);
			}
			catch (Exception var_0_13)
			{
			}
		}
		public void openClosableTab(UserControl userControl, string title)
		{
			try
			{
				this.tabControler.openClosableTab(userControl, title);
			}
			catch (Exception var_0_13)
			{
			}
		}
		public void openClosableTab<T>(T manager, string title)
		{
			try
			{
				this.tabControler.openClosableTab(manager, title);
			}
			catch (Exception var_0_18)
			{
			}
		}
		public void closeAllClosableTabs()
		{
		}
		public TabItem getTab(int index)
		{
			return this.tabControler.getTab(index);
		}
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0"), DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (!this._contentLoaded)
			{
				this._contentLoaded = true;
				Uri resourceLocator = new Uri("/CustomControls;component/sanmarksolutions/wpfcustomcontrols/msclosabletab/mstabcontrol.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0"), EditorBrowsable(EditorBrowsableState.Never), DebuggerNonUserCode]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId != 1)
			{
				this._contentLoaded = true;
			}
			else
			{
				this.mSTabControl = (TabControl)target;
			}
		}
	}
}
