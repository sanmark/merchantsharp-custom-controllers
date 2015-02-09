using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
namespace CustomControls.SanmarkSolutions.WPFCustomControls.MSClosableTab
{
	public class ClosableHeader : UserControl, IComponentConnector
	{
		internal Button button_close;
		internal Label label_tabTitle;
		internal MenuItem menu_close;
		internal MenuItem menu_closeAll;
		internal MenuItem menu_closeAllButThis;
		private bool _contentLoaded;
		public ClosableHeader()
		{
			this.InitializeComponent();
		}
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0"), DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (!this._contentLoaded)
			{
				this._contentLoaded = true;
				Uri resourceLocator = new Uri("/CustomControls;component/sanmarksolutions/wpfcustomcontrols/msclosabletab/closableheader.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0"), EditorBrowsable(EditorBrowsableState.Never), DebuggerNonUserCode]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.button_close = (Button)target;
				break;
			case 2:
				this.label_tabTitle = (Label)target;
				break;
			case 3:
				this.menu_close = (MenuItem)target;
				break;
			case 4:
				this.menu_closeAll = (MenuItem)target;
				break;
			case 5:
				this.menu_closeAllButThis = (MenuItem)target;
				break;
			default:
				this._contentLoaded = true;
				break;
			}
		}
	}
}
