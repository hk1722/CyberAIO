// Token: 0x02000112 RID: 274
public sealed partial class CaptchaQueue_V1 : global::System.Windows.Forms.Form
{
	// Token: 0x06000725 RID: 1829 RVA: 0x00006764 File Offset: 0x00004964
	protected override void Dispose(bool disposing)
	{
		if (disposing && this.icontainer_0 != null)
		{
			this.icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	// Token: 0x06000726 RID: 1830 RVA: 0x0003D2A8 File Offset: 0x0003B4A8
	private void InitializeComponent()
	{
		this.icontainer_0 = new global::System.ComponentModel.Container();
		global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::CaptchaQueue_V1));
		this.bunifuElipse_0 = new global::Bunifu.Framework.UI.BunifuElipse(this.icontainer_0);
		this.top_panel = new global::System.Windows.Forms.Panel();
		this.addSolverButton = new global::Bunifu.Framework.UI.BunifuThinButton2();
		this.close_btn = new global::System.Windows.Forms.PictureBox();
		this.minimise_btn = new global::System.Windows.Forms.PictureBox();
		this.label1 = new global::System.Windows.Forms.Label();
		this.buttons_panel = new global::System.Windows.Forms.Panel();
		this.setProxyButton = new global::Bunifu.Framework.UI.BunifuThinButton2();
		this.reloadCaptcha = new global::System.Windows.Forms.PictureBox();
		this.proxyInput = new global::Bunifu.Framework.UI.BunifuMaterialTextbox();
		this.pictureBox2 = new global::System.Windows.Forms.PictureBox();
		this.clearsession_button = new global::Bunifu.Framework.UI.BunifuThinButton2();
		this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
		this.googlelogin_button = new global::Bunifu.Framework.UI.BunifuThinButton2();
		this.tabPanel = new global::System.Windows.Forms.Panel();
		this.closeButton4 = new global::Bunifu.Framework.UI.BunifuThinButton2();
		this.solverButton4 = new global::Bunifu.Framework.UI.BunifuThinButton2();
		this.solverLine4 = new global::Bunifu.Framework.UI.BunifuCustomLabel();
		this.closeButton3 = new global::Bunifu.Framework.UI.BunifuThinButton2();
		this.solverLine3 = new global::Bunifu.Framework.UI.BunifuCustomLabel();
		this.solverButton3 = new global::Bunifu.Framework.UI.BunifuThinButton2();
		this.closeButton2 = new global::Bunifu.Framework.UI.BunifuThinButton2();
		this.solverLine2 = new global::Bunifu.Framework.UI.BunifuCustomLabel();
		this.solverButton2 = new global::Bunifu.Framework.UI.BunifuThinButton2();
		this.closeButton1 = new global::Bunifu.Framework.UI.BunifuThinButton2();
		this.nextTabButton = new global::Bunifu.Framework.UI.BunifuThinButton2();
		this.solverLine1 = new global::Bunifu.Framework.UI.BunifuCustomLabel();
		this.solverButton1 = new global::Bunifu.Framework.UI.BunifuThinButton2();
		this.browserPanel = new global::System.Windows.Forms.Panel();
		this.top_panel.SuspendLayout();
		((global::System.ComponentModel.ISupportInitialize)this.close_btn).BeginInit();
		((global::System.ComponentModel.ISupportInitialize)this.minimise_btn).BeginInit();
		this.buttons_panel.SuspendLayout();
		((global::System.ComponentModel.ISupportInitialize)this.reloadCaptcha).BeginInit();
		((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
		((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		this.tabPanel.SuspendLayout();
		base.SuspendLayout();
		this.bunifuElipse_0.ElipseRadius = 10;
		this.bunifuElipse_0.TargetControl = this;
		this.top_panel.BackColor = global::System.Drawing.Color.FromArgb(25, 23, 26);
		this.top_panel.Controls.Add(this.addSolverButton);
		this.top_panel.Controls.Add(this.close_btn);
		this.top_panel.Controls.Add(this.minimise_btn);
		this.top_panel.Controls.Add(this.label1);
		this.top_panel.Dock = global::System.Windows.Forms.DockStyle.Top;
		this.top_panel.ForeColor = global::System.Drawing.Color.FromArgb(25, 23, 26);
		this.top_panel.Location = new global::System.Drawing.Point(0, 0);
		this.top_panel.Name = "top_panel";
		this.top_panel.Size = new global::System.Drawing.Size(439, 53);
		this.top_panel.TabIndex = 1;
		this.top_panel.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.top_panel_MouseMove);
		this.addSolverButton.ActiveBorderThickness = 1;
		this.addSolverButton.ActiveCornerRadius = 20;
		this.addSolverButton.ActiveFillColor = global::System.Drawing.Color.Empty;
		this.addSolverButton.ActiveForecolor = global::System.Drawing.Color.Empty;
		this.addSolverButton.ActiveLineColor = global::System.Drawing.Color.Empty;
		this.addSolverButton.BackColor = global::System.Drawing.Color.FromArgb(25, 23, 26);
		this.addSolverButton.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("addSolverButton.BackgroundImage");
		this.addSolverButton.ButtonText = "+";
		this.addSolverButton.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.addSolverButton.Font = new global::System.Drawing.Font("Century Gothic", 18f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
		this.addSolverButton.ForeColor = global::System.Drawing.Color.FromArgb(44, 186, 118);
		this.addSolverButton.IdleBorderThickness = 1;
		this.addSolverButton.IdleCornerRadius = 20;
		this.addSolverButton.IdleFillColor = global::System.Drawing.Color.Empty;
		this.addSolverButton.IdleForecolor = global::System.Drawing.Color.Empty;
		this.addSolverButton.IdleLineColor = global::System.Drawing.Color.Empty;
		this.addSolverButton.Location = new global::System.Drawing.Point(21, 9);
		this.addSolverButton.Margin = new global::System.Windows.Forms.Padding(6, 5, 6, 5);
		this.addSolverButton.Name = "addSolverButton";
		this.addSolverButton.Size = new global::System.Drawing.Size(36, 31);
		this.addSolverButton.TabIndex = 9;
		this.addSolverButton.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
		this.addSolverButton.Click += new global::System.EventHandler(this.addSolverButton_Click);
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
		this.label1.Location = new global::System.Drawing.Point(118, 14);
		this.label1.Name = "label1";
		this.label1.Size = new global::System.Drawing.Size(190, 23);
		this.label1.TabIndex = 6;
		this.label1.Text = "CAPTCHA QUEUE";
		this.buttons_panel.BackColor = global::System.Drawing.Color.FromArgb(25, 23, 26);
		this.buttons_panel.Controls.Add(this.setProxyButton);
		this.buttons_panel.Controls.Add(this.reloadCaptcha);
		this.buttons_panel.Controls.Add(this.proxyInput);
		this.buttons_panel.Controls.Add(this.pictureBox2);
		this.buttons_panel.Controls.Add(this.clearsession_button);
		this.buttons_panel.Controls.Add(this.pictureBox1);
		this.buttons_panel.Controls.Add(this.googlelogin_button);
		this.buttons_panel.Dock = global::System.Windows.Forms.DockStyle.Bottom;
		this.buttons_panel.Location = new global::System.Drawing.Point(0, 626);
		this.buttons_panel.Name = "buttons_panel";
		this.buttons_panel.Size = new global::System.Drawing.Size(439, 115);
		this.buttons_panel.TabIndex = 1;
		this.setProxyButton.ActiveBorderThickness = 1;
		this.setProxyButton.ActiveCornerRadius = 20;
		this.setProxyButton.ActiveFillColor = global::System.Drawing.Color.Empty;
		this.setProxyButton.ActiveForecolor = global::System.Drawing.Color.Empty;
		this.setProxyButton.ActiveLineColor = global::System.Drawing.Color.Empty;
		this.setProxyButton.BackColor = global::System.Drawing.Color.FromArgb(25, 23, 26);
		this.setProxyButton.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("setProxyButton.BackgroundImage");
		this.setProxyButton.ButtonText = "✔";
		this.setProxyButton.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.setProxyButton.Font = new global::System.Drawing.Font("Century Gothic", 18f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
		this.setProxyButton.ForeColor = global::System.Drawing.Color.FromArgb(44, 186, 118);
		this.setProxyButton.IdleBorderThickness = 1;
		this.setProxyButton.IdleCornerRadius = 20;
		this.setProxyButton.IdleFillColor = global::System.Drawing.Color.Empty;
		this.setProxyButton.IdleForecolor = global::System.Drawing.Color.Empty;
		this.setProxyButton.IdleLineColor = global::System.Drawing.Color.Empty;
		this.setProxyButton.Location = new global::System.Drawing.Point(398, 14);
		this.setProxyButton.Margin = new global::System.Windows.Forms.Padding(6, 5, 6, 5);
		this.setProxyButton.Name = "setProxyButton";
		this.setProxyButton.Size = new global::System.Drawing.Size(30, 31);
		this.setProxyButton.TabIndex = 10;
		this.setProxyButton.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
		this.setProxyButton.Click += new global::System.EventHandler(this.setProxyButton_Click);
		this.reloadCaptcha.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.reloadCaptcha.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("reloadCaptcha.Image");
		this.reloadCaptcha.Location = new global::System.Drawing.Point(398, 67);
		this.reloadCaptcha.Name = "reloadCaptcha";
		this.reloadCaptcha.Size = new global::System.Drawing.Size(27, 28);
		this.reloadCaptcha.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.reloadCaptcha.TabIndex = 15;
		this.reloadCaptcha.TabStop = false;
		this.reloadCaptcha.Click += new global::System.EventHandler(this.reloadCaptcha_Click);
		this.proxyInput.AutoCompleteMode = global::System.Windows.Forms.AutoCompleteMode.None;
		this.proxyInput.AutoCompleteSource = global::System.Windows.Forms.AutoCompleteSource.None;
		this.proxyInput.characterCasing = global::System.Windows.Forms.CharacterCasing.Normal;
		this.proxyInput.Cursor = global::System.Windows.Forms.Cursors.IBeam;
		this.proxyInput.Font = new global::System.Drawing.Font("Century Gothic", 9.75f);
		this.proxyInput.ForeColor = global::System.Drawing.Color.DimGray;
		this.proxyInput.HintForeColor = global::System.Drawing.Color.Empty;
		this.proxyInput.HintText = string.Empty;
		this.proxyInput.isPassword = false;
		this.proxyInput.LineFocusedColor = global::System.Drawing.Color.DimGray;
		this.proxyInput.LineIdleColor = global::System.Drawing.Color.DimGray;
		this.proxyInput.LineMouseHoverColor = global::System.Drawing.Color.DimGray;
		this.proxyInput.LineThickness = 2;
		this.proxyInput.Location = new global::System.Drawing.Point(17, 8);
		this.proxyInput.Margin = new global::System.Windows.Forms.Padding(4);
		this.proxyInput.MaxLength = 32767;
		this.proxyInput.Name = "proxyInput";
		this.proxyInput.Size = new global::System.Drawing.Size(372, 37);
		this.proxyInput.TabIndex = 12;
		this.proxyInput.Text = "Proxy (IP:Port:Username:Password)";
		this.proxyInput.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Left;
		this.pictureBox2.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.pictureBox2.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox2.Image");
		this.pictureBox2.Location = new global::System.Drawing.Point(29, 66);
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
		this.clearsession_button.Location = new global::System.Drawing.Point(14, 58);
		this.clearsession_button.Margin = new global::System.Windows.Forms.Padding(5, 4, 5, 4);
		this.clearsession_button.Name = "clearsession_button";
		this.clearsession_button.Size = new global::System.Drawing.Size(183, 44);
		this.clearsession_button.TabIndex = 10;
		this.clearsession_button.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
		this.clearsession_button.Click += new global::System.EventHandler(this.clearsession_button_Click);
		this.pictureBox1.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.pictureBox1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox1.Image");
		this.pictureBox1.Location = new global::System.Drawing.Point(220, 66);
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
		this.googlelogin_button.Location = new global::System.Drawing.Point(207, 58);
		this.googlelogin_button.Margin = new global::System.Windows.Forms.Padding(5, 4, 5, 4);
		this.googlelogin_button.Name = "googlelogin_button";
		this.googlelogin_button.Size = new global::System.Drawing.Size(182, 44);
		this.googlelogin_button.TabIndex = 0;
		this.googlelogin_button.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
		this.googlelogin_button.Click += new global::System.EventHandler(this.googlelogin_button_Click);
		this.tabPanel.Controls.Add(this.closeButton4);
		this.tabPanel.Controls.Add(this.solverButton4);
		this.tabPanel.Controls.Add(this.solverLine4);
		this.tabPanel.Controls.Add(this.closeButton3);
		this.tabPanel.Controls.Add(this.solverLine3);
		this.tabPanel.Controls.Add(this.solverButton3);
		this.tabPanel.Controls.Add(this.closeButton2);
		this.tabPanel.Controls.Add(this.solverLine2);
		this.tabPanel.Controls.Add(this.solverButton2);
		this.tabPanel.Controls.Add(this.closeButton1);
		this.tabPanel.Controls.Add(this.nextTabButton);
		this.tabPanel.Controls.Add(this.solverLine1);
		this.tabPanel.Controls.Add(this.solverButton1);
		this.tabPanel.Dock = global::System.Windows.Forms.DockStyle.Top;
		this.tabPanel.Location = new global::System.Drawing.Point(0, 53);
		this.tabPanel.Name = "tabPanel";
		this.tabPanel.Size = new global::System.Drawing.Size(439, 42);
		this.tabPanel.TabIndex = 2;
		this.closeButton4.ActiveBorderThickness = 1;
		this.closeButton4.ActiveCornerRadius = 20;
		this.closeButton4.ActiveFillColor = global::System.Drawing.Color.Empty;
		this.closeButton4.ActiveForecolor = global::System.Drawing.Color.Empty;
		this.closeButton4.ActiveLineColor = global::System.Drawing.Color.Empty;
		this.closeButton4.BackColor = global::System.Drawing.Color.FromArgb(25, 23, 26);
		this.closeButton4.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("closeButton4.BackgroundImage");
		this.closeButton4.ButtonText = "x";
		this.closeButton4.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.closeButton4.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
		this.closeButton4.ForeColor = global::System.Drawing.Color.White;
		this.closeButton4.IdleBorderThickness = 1;
		this.closeButton4.IdleCornerRadius = 20;
		this.closeButton4.IdleFillColor = global::System.Drawing.Color.Empty;
		this.closeButton4.IdleForecolor = global::System.Drawing.Color.Empty;
		this.closeButton4.IdleLineColor = global::System.Drawing.Color.Empty;
		this.closeButton4.Location = new global::System.Drawing.Point(388, 7);
		this.closeButton4.Margin = new global::System.Windows.Forms.Padding(4, 4, 4, 4);
		this.closeButton4.Name = "closeButton4";
		this.closeButton4.Size = new global::System.Drawing.Size(17, 21);
		this.closeButton4.TabIndex = 19;
		this.closeButton4.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
		this.closeButton4.Click += new global::System.EventHandler(this.closeButton4_Click);
		this.solverButton4.ActiveBorderThickness = 1;
		this.solverButton4.ActiveCornerRadius = 20;
		this.solverButton4.ActiveFillColor = global::System.Drawing.Color.Transparent;
		this.solverButton4.ActiveForecolor = global::System.Drawing.Color.White;
		this.solverButton4.ActiveLineColor = global::System.Drawing.Color.Transparent;
		this.solverButton4.BackColor = global::System.Drawing.Color.FromArgb(25, 23, 26);
		this.solverButton4.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("solverButton4.BackgroundImage");
		this.solverButton4.ButtonText = "Solver 4";
		this.solverButton4.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.solverButton4.Font = new global::System.Drawing.Font("Century Gothic", 10f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
		this.solverButton4.ForeColor = global::System.Drawing.Color.SeaGreen;
		this.solverButton4.IdleBorderThickness = 1;
		this.solverButton4.IdleCornerRadius = 20;
		this.solverButton4.IdleFillColor = global::System.Drawing.Color.Transparent;
		this.solverButton4.IdleForecolor = global::System.Drawing.Color.White;
		this.solverButton4.IdleLineColor = global::System.Drawing.Color.Transparent;
		this.solverButton4.Location = new global::System.Drawing.Point(321, 16);
		this.solverButton4.Margin = new global::System.Windows.Forms.Padding(4, 4, 4, 4);
		this.solverButton4.Name = "solverButton4";
		this.solverButton4.Size = new global::System.Drawing.Size(75, 17);
		this.solverButton4.TabIndex = 18;
		this.solverButton4.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
		this.solverButton4.Click += new global::System.EventHandler(this.solverButton4_Click);
		this.solverLine4.BackColor = global::System.Drawing.Color.SeaGreen;
		this.solverLine4.ForeColor = global::System.Drawing.Color.Coral;
		this.solverLine4.Location = new global::System.Drawing.Point(321, 37);
		this.solverLine4.Name = "solverLine4";
		this.solverLine4.Size = new global::System.Drawing.Size(75, 3);
		this.solverLine4.TabIndex = 17;
		this.closeButton3.ActiveBorderThickness = 1;
		this.closeButton3.ActiveCornerRadius = 20;
		this.closeButton3.ActiveFillColor = global::System.Drawing.Color.Empty;
		this.closeButton3.ActiveForecolor = global::System.Drawing.Color.Empty;
		this.closeButton3.ActiveLineColor = global::System.Drawing.Color.Empty;
		this.closeButton3.BackColor = global::System.Drawing.Color.FromArgb(25, 23, 26);
		this.closeButton3.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("closeButton3.BackgroundImage");
		this.closeButton3.ButtonText = "x";
		this.closeButton3.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.closeButton3.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
		this.closeButton3.ForeColor = global::System.Drawing.Color.White;
		this.closeButton3.IdleBorderThickness = 1;
		this.closeButton3.IdleCornerRadius = 20;
		this.closeButton3.IdleFillColor = global::System.Drawing.Color.Empty;
		this.closeButton3.IdleForecolor = global::System.Drawing.Color.Empty;
		this.closeButton3.IdleLineColor = global::System.Drawing.Color.Empty;
		this.closeButton3.Location = new global::System.Drawing.Point(283, 7);
		this.closeButton3.Margin = new global::System.Windows.Forms.Padding(4, 4, 4, 4);
		this.closeButton3.Name = "closeButton3";
		this.closeButton3.Size = new global::System.Drawing.Size(17, 21);
		this.closeButton3.TabIndex = 16;
		this.closeButton3.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
		this.closeButton3.Click += new global::System.EventHandler(this.closeButton3_Click);
		this.solverLine3.BackColor = global::System.Drawing.Color.SeaGreen;
		this.solverLine3.ForeColor = global::System.Drawing.Color.Coral;
		this.solverLine3.Location = new global::System.Drawing.Point(217, 37);
		this.solverLine3.Name = "solverLine3";
		this.solverLine3.Size = new global::System.Drawing.Size(75, 3);
		this.solverLine3.TabIndex = 14;
		this.solverButton3.ActiveBorderThickness = 1;
		this.solverButton3.ActiveCornerRadius = 20;
		this.solverButton3.ActiveFillColor = global::System.Drawing.Color.Transparent;
		this.solverButton3.ActiveForecolor = global::System.Drawing.Color.White;
		this.solverButton3.ActiveLineColor = global::System.Drawing.Color.Transparent;
		this.solverButton3.BackColor = global::System.Drawing.Color.FromArgb(25, 23, 26);
		this.solverButton3.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("solverButton3.BackgroundImage");
		this.solverButton3.ButtonText = "Solver 3";
		this.solverButton3.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.solverButton3.Font = new global::System.Drawing.Font("Century Gothic", 10f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
		this.solverButton3.ForeColor = global::System.Drawing.Color.SeaGreen;
		this.solverButton3.IdleBorderThickness = 1;
		this.solverButton3.IdleCornerRadius = 20;
		this.solverButton3.IdleFillColor = global::System.Drawing.Color.Transparent;
		this.solverButton3.IdleForecolor = global::System.Drawing.Color.White;
		this.solverButton3.IdleLineColor = global::System.Drawing.Color.Transparent;
		this.solverButton3.Location = new global::System.Drawing.Point(217, 16);
		this.solverButton3.Margin = new global::System.Windows.Forms.Padding(4, 4, 4, 4);
		this.solverButton3.Name = "solverButton3";
		this.solverButton3.Size = new global::System.Drawing.Size(75, 17);
		this.solverButton3.TabIndex = 15;
		this.solverButton3.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
		this.solverButton3.Click += new global::System.EventHandler(this.solverButton3_Click);
		this.closeButton2.ActiveBorderThickness = 1;
		this.closeButton2.ActiveCornerRadius = 20;
		this.closeButton2.ActiveFillColor = global::System.Drawing.Color.Empty;
		this.closeButton2.ActiveForecolor = global::System.Drawing.Color.Empty;
		this.closeButton2.ActiveLineColor = global::System.Drawing.Color.Empty;
		this.closeButton2.BackColor = global::System.Drawing.Color.FromArgb(25, 23, 26);
		this.closeButton2.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("closeButton2.BackgroundImage");
		this.closeButton2.ButtonText = "x";
		this.closeButton2.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.closeButton2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
		this.closeButton2.ForeColor = global::System.Drawing.Color.White;
		this.closeButton2.IdleBorderThickness = 1;
		this.closeButton2.IdleCornerRadius = 20;
		this.closeButton2.IdleFillColor = global::System.Drawing.Color.Empty;
		this.closeButton2.IdleForecolor = global::System.Drawing.Color.Empty;
		this.closeButton2.IdleLineColor = global::System.Drawing.Color.Empty;
		this.closeButton2.Location = new global::System.Drawing.Point(182, 7);
		this.closeButton2.Margin = new global::System.Windows.Forms.Padding(4, 4, 4, 4);
		this.closeButton2.Name = "closeButton2";
		this.closeButton2.Size = new global::System.Drawing.Size(17, 21);
		this.closeButton2.TabIndex = 13;
		this.closeButton2.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
		this.closeButton2.Click += new global::System.EventHandler(this.closeButton2_Click);
		this.solverLine2.BackColor = global::System.Drawing.Color.SeaGreen;
		this.solverLine2.ForeColor = global::System.Drawing.Color.Coral;
		this.solverLine2.Location = new global::System.Drawing.Point(116, 37);
		this.solverLine2.Name = "solverLine2";
		this.solverLine2.Size = new global::System.Drawing.Size(75, 3);
		this.solverLine2.TabIndex = 11;
		this.solverButton2.ActiveBorderThickness = 1;
		this.solverButton2.ActiveCornerRadius = 20;
		this.solverButton2.ActiveFillColor = global::System.Drawing.Color.Transparent;
		this.solverButton2.ActiveForecolor = global::System.Drawing.Color.White;
		this.solverButton2.ActiveLineColor = global::System.Drawing.Color.Transparent;
		this.solverButton2.BackColor = global::System.Drawing.Color.FromArgb(25, 23, 26);
		this.solverButton2.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("solverButton2.BackgroundImage");
		this.solverButton2.ButtonText = "Solver 2";
		this.solverButton2.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.solverButton2.Font = new global::System.Drawing.Font("Century Gothic", 10f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
		this.solverButton2.ForeColor = global::System.Drawing.Color.SeaGreen;
		this.solverButton2.IdleBorderThickness = 1;
		this.solverButton2.IdleCornerRadius = 20;
		this.solverButton2.IdleFillColor = global::System.Drawing.Color.Transparent;
		this.solverButton2.IdleForecolor = global::System.Drawing.Color.White;
		this.solverButton2.IdleLineColor = global::System.Drawing.Color.Transparent;
		this.solverButton2.Location = new global::System.Drawing.Point(116, 16);
		this.solverButton2.Margin = new global::System.Windows.Forms.Padding(4, 4, 4, 4);
		this.solverButton2.Name = "solverButton2";
		this.solverButton2.Size = new global::System.Drawing.Size(75, 17);
		this.solverButton2.TabIndex = 12;
		this.solverButton2.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
		this.solverButton2.Click += new global::System.EventHandler(this.solverButton2_Click);
		this.closeButton1.ActiveBorderThickness = 1;
		this.closeButton1.ActiveCornerRadius = 20;
		this.closeButton1.ActiveFillColor = global::System.Drawing.Color.Empty;
		this.closeButton1.ActiveForecolor = global::System.Drawing.Color.Empty;
		this.closeButton1.ActiveLineColor = global::System.Drawing.Color.Empty;
		this.closeButton1.BackColor = global::System.Drawing.Color.FromArgb(25, 23, 26);
		this.closeButton1.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("closeButton1.BackgroundImage");
		this.closeButton1.ButtonText = "x";
		this.closeButton1.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.closeButton1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
		this.closeButton1.ForeColor = global::System.Drawing.Color.White;
		this.closeButton1.IdleBorderThickness = 1;
		this.closeButton1.IdleCornerRadius = 20;
		this.closeButton1.IdleFillColor = global::System.Drawing.Color.Empty;
		this.closeButton1.IdleForecolor = global::System.Drawing.Color.Empty;
		this.closeButton1.IdleLineColor = global::System.Drawing.Color.Empty;
		this.closeButton1.Location = new global::System.Drawing.Point(78, 7);
		this.closeButton1.Margin = new global::System.Windows.Forms.Padding(4, 4, 4, 4);
		this.closeButton1.Name = "closeButton1";
		this.closeButton1.Size = new global::System.Drawing.Size(17, 21);
		this.closeButton1.TabIndex = 10;
		this.closeButton1.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
		this.closeButton1.Click += new global::System.EventHandler(this.closeButton1_Click);
		this.nextTabButton.ActiveBorderThickness = 1;
		this.nextTabButton.ActiveCornerRadius = 20;
		this.nextTabButton.ActiveFillColor = global::System.Drawing.Color.Empty;
		this.nextTabButton.ActiveForecolor = global::System.Drawing.Color.Empty;
		this.nextTabButton.ActiveLineColor = global::System.Drawing.Color.Empty;
		this.nextTabButton.BackColor = global::System.Drawing.Color.FromArgb(25, 23, 26);
		this.nextTabButton.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("nextTabButton.BackgroundImage");
		this.nextTabButton.ButtonText = ">";
		this.nextTabButton.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.nextTabButton.Font = new global::System.Drawing.Font("Century Gothic", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
		this.nextTabButton.ForeColor = global::System.Drawing.Color.FromArgb(44, 186, 118);
		this.nextTabButton.IdleBorderThickness = 1;
		this.nextTabButton.IdleCornerRadius = 20;
		this.nextTabButton.IdleFillColor = global::System.Drawing.Color.Empty;
		this.nextTabButton.IdleForecolor = global::System.Drawing.Color.Empty;
		this.nextTabButton.IdleLineColor = global::System.Drawing.Color.Empty;
		this.nextTabButton.Location = new global::System.Drawing.Point(408, 11);
		this.nextTabButton.Margin = new global::System.Windows.Forms.Padding(5);
		this.nextTabButton.Name = "nextTabButton";
		this.nextTabButton.Size = new global::System.Drawing.Size(33, 29);
		this.nextTabButton.TabIndex = 0;
		this.nextTabButton.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
		this.nextTabButton.Click += new global::System.EventHandler(this.nextTabButton_Click);
		this.solverLine1.BackColor = global::System.Drawing.Color.SeaGreen;
		this.solverLine1.ForeColor = global::System.Drawing.Color.Coral;
		this.solverLine1.Location = new global::System.Drawing.Point(12, 37);
		this.solverLine1.Name = "solverLine1";
		this.solverLine1.Size = new global::System.Drawing.Size(75, 3);
		this.solverLine1.TabIndex = 1;
		this.solverButton1.ActiveBorderThickness = 1;
		this.solverButton1.ActiveCornerRadius = 20;
		this.solverButton1.ActiveFillColor = global::System.Drawing.Color.Transparent;
		this.solverButton1.ActiveForecolor = global::System.Drawing.Color.White;
		this.solverButton1.ActiveLineColor = global::System.Drawing.Color.Transparent;
		this.solverButton1.BackColor = global::System.Drawing.Color.FromArgb(25, 23, 26);
		this.solverButton1.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("solverButton1.BackgroundImage");
		this.solverButton1.ButtonText = "Solver 1";
		this.solverButton1.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.solverButton1.Font = new global::System.Drawing.Font("Century Gothic", 10f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
		this.solverButton1.ForeColor = global::System.Drawing.Color.SeaGreen;
		this.solverButton1.IdleBorderThickness = 1;
		this.solverButton1.IdleCornerRadius = 20;
		this.solverButton1.IdleFillColor = global::System.Drawing.Color.Transparent;
		this.solverButton1.IdleForecolor = global::System.Drawing.Color.White;
		this.solverButton1.IdleLineColor = global::System.Drawing.Color.Transparent;
		this.solverButton1.Location = new global::System.Drawing.Point(12, 16);
		this.solverButton1.Margin = new global::System.Windows.Forms.Padding(4, 4, 4, 4);
		this.solverButton1.Name = "solverButton1";
		this.solverButton1.Size = new global::System.Drawing.Size(75, 17);
		this.solverButton1.TabIndex = 2;
		this.solverButton1.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
		this.solverButton1.Click += new global::System.EventHandler(this.solverButton1_Click);
		this.browserPanel.Dock = global::System.Windows.Forms.DockStyle.Fill;
		this.browserPanel.Location = new global::System.Drawing.Point(0, 95);
		this.browserPanel.Name = "browserPanel";
		this.browserPanel.Size = new global::System.Drawing.Size(439, 531);
		this.browserPanel.TabIndex = 3;
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = global::System.Drawing.Color.FromArgb(25, 23, 26);
		base.ClientSize = new global::System.Drawing.Size(439, 741);
		base.Controls.Add(this.browserPanel);
		base.Controls.Add(this.tabPanel);
		base.Controls.Add(this.buttons_panel);
		base.Controls.Add(this.top_panel);
		base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
		base.Name = "CaptchaQueue_V1";
		this.Text = "CaptchaQueue";
		this.top_panel.ResumeLayout(false);
		this.top_panel.PerformLayout();
		((global::System.ComponentModel.ISupportInitialize)this.close_btn).EndInit();
		((global::System.ComponentModel.ISupportInitialize)this.minimise_btn).EndInit();
		this.buttons_panel.ResumeLayout(false);
		((global::System.ComponentModel.ISupportInitialize)this.reloadCaptcha).EndInit();
		((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
		((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		this.tabPanel.ResumeLayout(false);
		base.ResumeLayout(false);
	}

	// Token: 0x04000483 RID: 1155
	private global::System.ComponentModel.IContainer icontainer_0;

	// Token: 0x04000484 RID: 1156
	private global::Bunifu.Framework.UI.BunifuElipse bunifuElipse_0;

	// Token: 0x04000485 RID: 1157
	private global::System.Windows.Forms.PictureBox close_btn;

	// Token: 0x04000486 RID: 1158
	private global::System.Windows.Forms.PictureBox minimise_btn;

	// Token: 0x04000487 RID: 1159
	private global::System.Windows.Forms.Label label1;

	// Token: 0x04000488 RID: 1160
	private global::System.Windows.Forms.Panel buttons_panel;

	// Token: 0x04000489 RID: 1161
	private global::System.Windows.Forms.PictureBox pictureBox2;

	// Token: 0x0400048A RID: 1162
	private global::Bunifu.Framework.UI.BunifuThinButton2 clearsession_button;

	// Token: 0x0400048B RID: 1163
	private global::System.Windows.Forms.PictureBox pictureBox1;

	// Token: 0x0400048C RID: 1164
	private global::Bunifu.Framework.UI.BunifuThinButton2 googlelogin_button;

	// Token: 0x0400048D RID: 1165
	private global::Bunifu.Framework.UI.BunifuMaterialTextbox proxyInput;

	// Token: 0x0400048E RID: 1166
	private global::System.Windows.Forms.Panel browserPanel;

	// Token: 0x0400048F RID: 1167
	private global::System.Windows.Forms.Panel tabPanel;

	// Token: 0x04000490 RID: 1168
	private global::Bunifu.Framework.UI.BunifuThinButton2 solverButton1;

	// Token: 0x04000491 RID: 1169
	private global::Bunifu.Framework.UI.BunifuCustomLabel solverLine1;

	// Token: 0x04000492 RID: 1170
	private global::Bunifu.Framework.UI.BunifuThinButton2 nextTabButton;

	// Token: 0x04000493 RID: 1171
	private global::Bunifu.Framework.UI.BunifuThinButton2 addSolverButton;

	// Token: 0x04000494 RID: 1172
	private global::System.Windows.Forms.PictureBox reloadCaptcha;

	// Token: 0x04000495 RID: 1173
	private global::Bunifu.Framework.UI.BunifuThinButton2 closeButton1;

	// Token: 0x04000496 RID: 1174
	public global::System.Windows.Forms.Panel top_panel;

	// Token: 0x04000497 RID: 1175
	private global::Bunifu.Framework.UI.BunifuThinButton2 closeButton4;

	// Token: 0x04000498 RID: 1176
	private global::Bunifu.Framework.UI.BunifuThinButton2 solverButton4;

	// Token: 0x04000499 RID: 1177
	private global::Bunifu.Framework.UI.BunifuCustomLabel solverLine4;

	// Token: 0x0400049A RID: 1178
	private global::Bunifu.Framework.UI.BunifuThinButton2 closeButton3;

	// Token: 0x0400049B RID: 1179
	private global::Bunifu.Framework.UI.BunifuCustomLabel solverLine3;

	// Token: 0x0400049C RID: 1180
	private global::Bunifu.Framework.UI.BunifuThinButton2 solverButton3;

	// Token: 0x0400049D RID: 1181
	private global::Bunifu.Framework.UI.BunifuThinButton2 closeButton2;

	// Token: 0x0400049E RID: 1182
	private global::Bunifu.Framework.UI.BunifuCustomLabel solverLine2;

	// Token: 0x0400049F RID: 1183
	private global::Bunifu.Framework.UI.BunifuThinButton2 solverButton2;

	// Token: 0x040004A0 RID: 1184
	private global::Bunifu.Framework.UI.BunifuThinButton2 setProxyButton;
}
