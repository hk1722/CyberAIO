// Token: 0x020000BE RID: 190
public sealed partial class Loading : global::System.Windows.Forms.Form
{
	// Token: 0x06000500 RID: 1280 RVA: 0x0000554A File Offset: 0x0000374A
	protected override void Dispose(bool disposing)
	{
		if (disposing && this.icontainer_0 != null)
		{
			this.icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	// Token: 0x06000501 RID: 1281 RVA: 0x000287B0 File Offset: 0x000269B0
	private void InitializeComponent()
	{
		this.icontainer_0 = new global::System.ComponentModel.Container();
		global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Loading));
		this.bunifuElipse_0 = new global::Bunifu.Framework.UI.BunifuElipse(this.icontainer_0);
		this.bunifuFormFadeTransition_0 = new global::Bunifu.Framework.UI.BunifuFormFadeTransition(this.icontainer_0);
		base.SuspendLayout();
		this.bunifuElipse_0.ElipseRadius = 5;
		this.bunifuElipse_0.TargetControl = this;
		this.bunifuFormFadeTransition_0.Delay = 1;
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new global::System.Drawing.Size(910, 583);
		base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
		this.MinimumSize = new global::System.Drawing.Size(652, 322);
		base.Name = "Loading";
		base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Loading";
		base.ResumeLayout(false);
	}

	// Token: 0x0400025F RID: 607
	private global::System.ComponentModel.IContainer icontainer_0;

	// Token: 0x04000260 RID: 608
	private global::Bunifu.Framework.UI.BunifuElipse bunifuElipse_0;

	// Token: 0x04000261 RID: 609
	private global::Bunifu.Framework.UI.BunifuFormFadeTransition bunifuFormFadeTransition_0;
}
