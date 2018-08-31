// Token: 0x02000004 RID: 4
public sealed partial class CaptchaQueue : global::System.Windows.Forms.Form
{
	// Token: 0x0600001D RID: 29 RVA: 0x00002CE9 File Offset: 0x00000EE9
	protected override void Dispose(bool disposing)
	{
		if (disposing && this.icontainer_0 != null)
		{
			this.icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	// Token: 0x0600001E RID: 30 RVA: 0x0000739C File Offset: 0x0000559C
	private void InitializeComponent()
	{
		this.icontainer_0 = new global::System.ComponentModel.Container();
		global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::CaptchaQueue_V1));
		this.bunifuElipse_0 = new global::Bunifu.Framework.UI.BunifuElipse(this.icontainer_0);
		this.browser_panel = new global::System.Windows.Forms.Panel();
		this.top_panel = new global::System.Windows.Forms.Panel();
		this.close_btn = new global::System.Windows.Forms.PictureBox();
		this.minimise_btn = new global::System.Windows.Forms.PictureBox();
		this.label1 = new global::System.Windows.Forms.Label();
		this.bunifuDragControl_0 = new global::Bunifu.Framework.UI.BunifuDragControl(this.icontainer_0);
		this.buttons_panel = new global::System.Windows.Forms.Panel();
		this.pictureBox2 = new global::System.Windows.Forms.PictureBox();
		this.clearsession_button = new global::Bunifu.Framework.UI.BunifuThinButton2();
		this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
		this.googlelogin_button = new global::Bunifu.Framework.UI.BunifuThinButton2();
		this.top_panel.SuspendLayout();
		((global::System.ComponentModel.ISupportInitialize)this.close_btn).BeginInit();
		((global::System.ComponentModel.ISupportInitialize)this.minimise_btn).BeginInit();
		this.buttons_panel.SuspendLayout();
		((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
		((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		base.SuspendLayout();
		this.bunifuElipse_0.ElipseRadius = 10;
		this.bunifuElipse_0.TargetControl = this;
		this.browser_panel.BackColor = global::System.Drawing.Color.FromArgb(25, 23, 26);
		this.browser_panel.Dock = global::System.Windows.Forms.DockStyle.Fill;
		this.browser_panel.Location = new global::System.Drawing.Point(0, 52);
		this.browser_panel.Name = "browser_panel";
		this.browser_panel.Size = new global::System.Drawing.Size(439, 497);
		this.browser_panel.TabIndex = 0;
		this.top_panel.BackColor = global::System.Drawing.Color.FromArgb(25, 23, 26);
		this.top_panel.Controls.Add(this.close_btn);
		this.top_panel.Controls.Add(this.minimise_btn);
		this.top_panel.Controls.Add(this.label1);
		this.top_panel.Dock = global::System.Windows.Forms.DockStyle.Top;
		this.top_panel.Location = new global::System.Drawing.Point(0, 0);
		this.top_panel.Name = "top_panel";
		this.top_panel.Size = new global::System.Drawing.Size(439, 52);
		this.top_panel.TabIndex = 1;
		this.close_btn.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.close_btn.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("close_btn.Image");
		this.close_btn.Location = new global::System.Drawing.Point(400, 9);
		this.close_btn.Name = "close_btn";
		this.close_btn.Size = new global::System.Drawing.Size(27, 28);
		this.close_btn.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.close_btn.TabIndex = 7;
		this.close_btn.TabStop = false;
		this.close_btn.Click += new global::System.EventHandler(this.close_btn_Click);
		this.minimise_btn.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.minimise_btn.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("minimise_btn.Image");
		this.minimise_btn.Location = new global::System.Drawing.Point(367, 18);
		this.minimise_btn.Name = "minimise_btn";
		this.minimise_btn.Size = new global::System.Drawing.Size(27, 22);
		this.minimise_btn.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.minimise_btn.TabIndex = 8;
		this.minimise_btn.TabStop = false;
		this.minimise_btn.Click += new global::System.EventHandler(this.minimise_btn_Click);
		this.label1.AutoSize = true;
		this.label1.BackColor = global::System.Drawing.Color.Transparent;
		this.label1.Font = new global::System.Drawing.Font("Verdana", 14.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
		this.label1.ForeColor = global::System.Drawing.Color.FromArgb(44, 186, 118);
		this.label1.Location = new global::System.Drawing.Point(123, 14);
		this.label1.Name = "label1";
		this.label1.Size = new global::System.Drawing.Size(190, 23);
		this.label1.TabIndex = 6;
		this.label1.Text = "CAPTCHA QUEUE";
		this.bunifuDragControl_0.Fixed = true;
		this.bunifuDragControl_0.Horizontal = true;
		this.bunifuDragControl_0.TargetControl = this.top_panel;
		this.bunifuDragControl_0.Vertical = true;
		this.buttons_panel.BackColor = global::System.Drawing.Color.FromArgb(25, 23, 26);
		this.buttons_panel.Controls.Add(this.pictureBox2);
		this.buttons_panel.Controls.Add(this.clearsession_button);
		this.buttons_panel.Controls.Add(this.pictureBox1);
		this.buttons_panel.Controls.Add(this.googlelogin_button);
		this.buttons_panel.Dock = global::System.Windows.Forms.DockStyle.Bottom;
		this.buttons_panel.Location = new global::System.Drawing.Point(0, 549);
		this.buttons_panel.Name = "buttons_panel";
		this.buttons_panel.Size = new global::System.Drawing.Size(439, 67);
		this.buttons_panel.TabIndex = 1;
		this.pictureBox2.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.pictureBox2.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox2.Image");
		this.pictureBox2.Location = new global::System.Drawing.Point(29, 18);
		this.pictureBox2.Name = "pictureBox2";
		this.pictureBox2.Size = new global::System.Drawing.Size(27, 28);
		this.pictureBox2.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pictureBox2.TabIndex = 11;
		this.pictureBox2.TabStop = false;
		this.clearsession_button.ActiveBorderThickness = 1;
		this.clearsession_button.ActiveCornerRadius = 30;
		this.clearsession_button.ActiveFillColor = global::System.Drawing.Color.FromArgb(25, 23, 26);
		this.clearsession_button.ActiveForecolor = global::System.Drawing.Color.FromArgb(225, 29, 65);
		this.clearsession_button.ActiveLineColor = global::System.Drawing.Color.FromArgb(225, 29, 65);
		this.clearsession_button.BackColor = global::System.Drawing.Color.FromArgb(25, 23, 26);
		this.clearsession_button.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("clearsession_button.BackgroundImage");
		this.clearsession_button.ButtonText = "    Clear Cookies";
		this.clearsession_button.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.clearsession_button.Font = new global::System.Drawing.Font("Verdana", 12f);
		this.clearsession_button.ForeColor = global::System.Drawing.Color.FromArgb(44, 186, 118);
		this.clearsession_button.IdleBorderThickness = 1;
		this.clearsession_button.IdleCornerRadius = 30;
		this.clearsession_button.IdleFillColor = global::System.Drawing.Color.FromArgb(25, 23, 26);
		this.clearsession_button.IdleForecolor = global::System.Drawing.Color.FromArgb(225, 29, 65);
		this.clearsession_button.IdleLineColor = global::System.Drawing.Color.FromArgb(225, 29, 65);
		this.clearsession_button.Location = new global::System.Drawing.Point(14, 10);
		this.clearsession_button.Margin = new global::System.Windows.Forms.Padding(5, 4, 5, 4);
		this.clearsession_button.Name = "clearsession_button";
		this.clearsession_button.Size = new global::System.Drawing.Size(192, 44);
		this.clearsession_button.TabIndex = 10;
		this.clearsession_button.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
		this.clearsession_button.Click += new global::System.EventHandler(this.clearsession_button_Click);
		this.pictureBox1.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.pictureBox1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox1.Image");
		this.pictureBox1.Location = new global::System.Drawing.Point(251, 17);
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.Size = new global::System.Drawing.Size(27, 28);
		this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pictureBox1.TabIndex = 9;
		this.pictureBox1.TabStop = false;
		this.googlelogin_button.ActiveBorderThickness = 1;
		this.googlelogin_button.ActiveCornerRadius = 30;
		this.googlelogin_button.ActiveFillColor = global::System.Drawing.Color.FromArgb(25, 23, 26);
		this.googlelogin_button.ActiveForecolor = global::System.Drawing.Color.FromArgb(44, 186, 118);
		this.googlelogin_button.ActiveLineColor = global::System.Drawing.Color.FromArgb(44, 186, 118);
		this.googlelogin_button.BackColor = global::System.Drawing.Color.FromArgb(25, 23, 26);
		this.googlelogin_button.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("googlelogin_button.BackgroundImage");
		this.googlelogin_button.ButtonText = "    Google Login";
		this.googlelogin_button.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.googlelogin_button.Font = new global::System.Drawing.Font("Verdana", 12f);
		this.googlelogin_button.ForeColor = global::System.Drawing.Color.FromArgb(44, 186, 118);
		this.googlelogin_button.IdleBorderThickness = 1;
		this.googlelogin_button.IdleCornerRadius = 30;
		this.googlelogin_button.IdleFillColor = global::System.Drawing.Color.FromArgb(25, 23, 26);
		this.googlelogin_button.IdleForecolor = global::System.Drawing.Color.FromArgb(44, 186, 118);
		this.googlelogin_button.IdleLineColor = global::System.Drawing.Color.FromArgb(44, 186, 118);
		this.googlelogin_button.Location = new global::System.Drawing.Point(232, 9);
		this.googlelogin_button.Margin = new global::System.Windows.Forms.Padding(5, 4, 5, 4);
		this.googlelogin_button.Name = "googlelogin_button";
		this.googlelogin_button.Size = new global::System.Drawing.Size(192, 44);
		this.googlelogin_button.TabIndex = 0;
		this.googlelogin_button.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
		this.googlelogin_button.Click += new global::System.EventHandler(this.googlelogin_button_Click);
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = global::System.Drawing.Color.FromArgb(32, 30, 38);
		base.ClientSize = new global::System.Drawing.Size(439, 616);
		base.Controls.Add(this.browser_panel);
		base.Controls.Add(this.buttons_panel);
		base.Controls.Add(this.top_panel);
		base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
		base.Name = "CaptchaQueue";
		this.Text = "CaptchaQueue";
		this.top_panel.ResumeLayout(false);
		this.top_panel.PerformLayout();
		((global::System.ComponentModel.ISupportInitialize)this.close_btn).EndInit();
		((global::System.ComponentModel.ISupportInitialize)this.minimise_btn).EndInit();
		this.buttons_panel.ResumeLayout(false);
		((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
		((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		base.ResumeLayout(false);
	}

	// Token: 0x0400000D RID: 13
	private global::System.ComponentModel.IContainer icontainer_0;

	// Token: 0x0400000E RID: 14
	private global::Bunifu.Framework.UI.BunifuElipse bunifuElipse_0;

	// Token: 0x0400000F RID: 15
	private global::System.Windows.Forms.Panel browser_panel;

	// Token: 0x04000010 RID: 16
	private global::System.Windows.Forms.Panel top_panel;

	// Token: 0x04000011 RID: 17
	private global::System.Windows.Forms.PictureBox close_btn;

	// Token: 0x04000012 RID: 18
	private global::System.Windows.Forms.PictureBox minimise_btn;

	// Token: 0x04000013 RID: 19
	private global::System.Windows.Forms.Label label1;

	// Token: 0x04000014 RID: 20
	private global::Bunifu.Framework.UI.BunifuDragControl bunifuDragControl_0;

	// Token: 0x04000015 RID: 21
	private global::System.Windows.Forms.Panel buttons_panel;

	// Token: 0x04000016 RID: 22
	private global::System.Windows.Forms.PictureBox pictureBox2;

	// Token: 0x04000017 RID: 23
	private global::Bunifu.Framework.UI.BunifuThinButton2 clearsession_button;

	// Token: 0x04000018 RID: 24
	private global::System.Windows.Forms.PictureBox pictureBox1;

	// Token: 0x04000019 RID: 25
	private global::Bunifu.Framework.UI.BunifuThinButton2 googlelogin_button;
}
