using System;
using System.Windows.Controls;
using System.Windows.Input;
namespace CustomControls.SanmarkSolutions.WPFCustomControls.MSDatePicker
{
	public class MSDatePicker : DatePicker
	{
		private bool selectToday = false;
		public DateTime SelectedValue
		{
			get
			{
				DateTime result;
				try
				{
					result = Convert.ToDateTime(base.SelectedDate);
				}
				catch (Exception)
				{
					result = DateTime.Today;
				}
				return result;
			}
		}
		public bool SelectToday
		{
			get
			{
				return this.selectToday;
			}
			set
			{
				try
				{
					if (value)
					{
						base.SelectedDate = new DateTime?(DateTime.Today);
					}
					else
					{
						base.SelectedDate = null;
					}
				}
				catch (Exception)
				{
				}
				this.selectToday = value;
			}
		}
		protected override void OnKeyUp(KeyEventArgs e)
		{
			try
			{
				if (e.Key == Key.Down)
				{
					base.IsDropDownOpen = true;
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
					base.IsDropDownOpen = true;
					base.Focus();
				}
			}
			catch (Exception)
			{
			}
		}
	}
}
