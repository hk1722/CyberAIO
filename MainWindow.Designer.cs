// Token: 0x02000014 RID: 20
public sealed partial class MainWindow : global::System.Windows.Forms.Form
{
	// Token: 0x0600007D RID: 125 RVA: 0x00003070 File Offset: 0x00001270
	protected override void Dispose(bool disposing)
	{
		if (disposing && this.icontainer_0 != null)
		{
			this.icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	// Token: 0x0600007E RID: 126 RVA: 0x0000A824 File Offset: 0x00008A24
	private void InitializeComponent()
	{
		this.icontainer_0 = new global::System.ComponentModel.Container();
		global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::MainWindow));
		this.resisze_button = new global::System.Windows.Forms.Label();
		this.browser_panel = new global::System.Windows.Forms.Panel();
		this.bunifuElipse_0 = new global::Bunifu.Framework.UI.BunifuElipse(this.icontainer_0);
		this.bunifuFormFadeTransition_0 = new global::Bunifu.Framework.UI.BunifuFormFadeTransition(this.icontainer_0);
		base.SuspendLayout();
		this.resisze_button.Location = new global::System.Drawing.Point(0, 0);
		this.resisze_button.Name = "resisze_button";
		this.resisze_button.Size = new global::System.Drawing.Size(100, 23);
		this.resisze_button.TabIndex = 2;
		this.browser_panel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.browser_panel.Location = new global::System.Drawing.Point(1, -1);
		this.browser_panel.Name = "browser_panel";
		this.browser_panel.Size = new global::System.Drawing.Size(1296, 734);
		this.browser_panel.TabIndex = 1;
		this.bunifuElipse_0.ElipseRadius = 20;
		this.bunifuElipse_0.TargetControl = this;
		this.bunifuFormFadeTransition_0.Delay = 3;
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = global::System.Drawing.Color.FromArgb(22, 21, 26);
		base.ClientSize = new global::System.Drawing.Size(1214, 612);
		base.Controls.Add(this.browser_panel);
		base.Controls.Add(this.resisze_button);
		this.DoubleBuffered = true;
		this.ForeColor = global::System.Drawing.Color.FromArgb(22, 21, 26);
		base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
		this.MinimumSize = new global::System.Drawing.Size(412, 252);
		base.Name = "MainWindow";
		base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "CyberAIO";
		base.ResumeLayout(false);
	}

	// Token: 0x0400005A RID: 90
	private global::System.ComponentModel.IContainer icontainer_0;

	// Token: 0x0400005B RID: 91
	private global::System.Windows.Forms.Label resisze_button;

	// Token: 0x0400005C RID: 92
	private global::System.Windows.Forms.Panel browser_panel;

	// Token: 0x0400005D RID: 93
	private global::Bunifu.Framework.UI.BunifuElipse bunifuElipse_0;

	// Token: 0x0400005E RID: 94
	private global::Bunifu.Framework.UI.BunifuFormFadeTransition bunifuFormFadeTransition_0;
}
