using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
namespace CustomControls.SanmarkSolutions.WPFCustomControls.MSClosableTab
{
	public class ClosableTab : TabItem
	{
		public string Title
		{
			set
			{
				((ClosableHeader)base.Header).label_tabTitle.Content = value;
			}
		}
		public ClosableTab()
		{
			ClosableHeader closableHeader = new ClosableHeader();
			base.Header = closableHeader;
			closableHeader.button_close.MouseEnter += new MouseEventHandler(this.button_close_MouseEnter);
			closableHeader.button_close.MouseLeave += new MouseEventHandler(this.button_close_MouseLeave);
			closableHeader.button_close.Click += new RoutedEventHandler(this.button_close_Click);
			closableHeader.label_tabTitle.SizeChanged += new SizeChangedEventHandler(this.label_tabTitle_SizeChanged);
			closableHeader.label_tabTitle.MouseRightButtonUp += new MouseButtonEventHandler(this.label_tabTitle_rightClick);
			closableHeader.menu_close.Click += new RoutedEventHandler(this.button_close_Click);
			closableHeader.menu_closeAll.Click += new RoutedEventHandler(this.button_closeAll_Click);
			closableHeader.menu_closeAllButThis.Click += new RoutedEventHandler(this.button_closeAllButThis_Click);
		}
		protected override void OnSelected(RoutedEventArgs e)
		{
			base.OnSelected(e);
			((ClosableHeader)base.Header).button_close.Visibility = Visibility.Visible;
		}
		protected override void OnUnselected(RoutedEventArgs e)
		{
			base.OnUnselected(e);
			((ClosableHeader)base.Header).button_close.Visibility = Visibility.Hidden;
		}
		protected override void OnMouseEnter(MouseEventArgs e)
		{
			base.OnMouseEnter(e);
			((ClosableHeader)base.Header).button_close.Visibility = Visibility.Visible;
		}
		protected override void OnMouseLeave(MouseEventArgs e)
		{
			base.OnMouseLeave(e);
			if (!base.IsSelected)
			{
				((ClosableHeader)base.Header).button_close.Visibility = Visibility.Hidden;
			}
		}
		protected override void OnKeyUp(KeyEventArgs e)
		{
			try
			{
				if (Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftShift) && Keyboard.IsKeyDown(Key.LeftAlt) && e.Key == Key.W)
				{
					this.closeAllButThis();
				}
				else
				{
					if (Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftShift) && e.Key == Key.W)
					{
						this.closeAllTabs();
					}
					else
					{
						if (Keyboard.IsKeyDown(Key.LeftCtrl) && e.Key == Key.W)
						{
							this.closeTab();
						}
					}
				}
			}
			catch (Exception)
			{
			}
			base.OnKeyUp(e);
		}
		private void button_close_MouseEnter(object sender, MouseEventArgs e)
		{
			((ClosableHeader)base.Header).button_close.Foreground = Brushes.Red;
		}
		private void button_close_MouseLeave(object sender, MouseEventArgs e)
		{
			((ClosableHeader)base.Header).button_close.Foreground = Brushes.Black;
		}
		private void button_close_Click(object sender, RoutedEventArgs e)
		{
			this.closeTab();
		}
		private void button_closeAll_Click(object sender, RoutedEventArgs e)
		{
			this.closeAllTabs();
		}
		private void button_closeAllButThis_Click(object sender, RoutedEventArgs e)
		{
			this.closeAllButThis();
		}
		private void label_tabTitle_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			((ClosableHeader)base.Header).button_close.Margin = new Thickness(((ClosableHeader)base.Header).label_tabTitle.ActualWidth + 5.0, 3.0, 4.0, 0.0);
		}
		private void label_tabTitle_rightClick(object sender, MouseButtonEventArgs e)
		{
		}
		private void closeTab()
		{
			((TabControl)base.Parent).Items.Remove(this);
		}
		private void closeAllTabs()
		{
			try
			{
				int count = ((TabControl)base.Parent).Items.Count;
				for (int i = 1; i < count; i++)
				{
					((TabControl)base.Parent).Items.RemoveAt(1);
				}
				((TabControl)base.Parent).Items.Remove(this);
			}
			catch (Exception var_2_5B)
			{
			}
		}
		private void closeAllButThis()
		{
			try
			{
				int num = ((TabControl)base.Parent).Items.IndexOf(this);
				int num2 = 1;
				int num3 = ((TabControl)base.Parent).Items.Count;
				for (int i = 1; i < num3; i++)
				{
					if (num == num2)
					{
						num2++;
						num3--;
					}
					((TabControl)base.Parent).Items.RemoveAt(num2);
					num--;
				}
			}
			catch (Exception)
			{
			}
		}
	}
}
