using System;
using System.Windows.Controls;
namespace CustomControls.SanmarkSolutions.WPFCustomControls.MSButton
{
	public class ButtonAddUpdate : Button
	{
		private string addContent = "Add";
		private string updateContent = "Update";
		private bool isShowContentText = true;
		private bool isUpdateMode = false;
		public string AddContent
		{
			get
			{
				return this.addContent;
			}
			set
			{
				this.addContent = value;
			}
		}
		public string UpdateContent
		{
			get
			{
				return this.updateContent;
			}
			set
			{
				this.updateContent = value;
			}
		}
		public bool IsShowContentText
		{
			get
			{
				return this.isShowContentText;
			}
			set
			{
				this.isShowContentText = value;
			}
		}
		public bool IsUpdateMode
		{
			get
			{
				return this.isUpdateMode;
			}
		}
		public ButtonAddUpdate()
		{
			this.updateMode(false);
		}
		protected override void OnInitialized(EventArgs e)
		{
			base.OnInitialized(e);
			this.updateMode(false);
		}
		private void changeMode(bool b)
		{
			try
			{
				if (b && this.isShowContentText)
				{
					base.Content = this.updateContent;
				}
				else
				{
					if (!b && this.isShowContentText)
					{
						base.Content = this.addContent;
					}
				}
				this.isUpdateMode = b;
			}
			catch (Exception)
			{
			}
		}
		public void updateMode(bool isUpdateMode)
		{
			this.changeMode(isUpdateMode);
		}
	}
}
