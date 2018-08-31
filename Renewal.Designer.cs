// Token: 0x020000DC RID: 220
public sealed partial class Renewal : global::System.Windows.Forms.Form
{
	// Token: 0x060005CE RID: 1486 RVA: 0x00005D7A File Offset: 0x00003F7A
	protected override void Dispose(bool disposing)
	{
		if (disposing && this.icontainer_0 != null)
		{
			this.icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	// Token: 0x060005CF RID: 1487 RVA: 0x00030218 File Offset: 0x0002E418
	private void InitializeComponent()
	{
		global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Renewal));
		base.SuspendLayout();
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new global::System.Drawing.Size(620, 615);
		base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
		base.Name = "Renewal";
		this.Text = "Renew License";
		base.ResumeLayout(false);
	}

	// Token: 0x040002BC RID: 700
	private global::System.ComponentModel.IContainer icontainer_0;
}
