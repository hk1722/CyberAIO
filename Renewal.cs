using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EO.WebBrowser;

// Token: 0x020000DC RID: 220
public sealed partial class Renewal : Form
{
	// Token: 0x060005CA RID: 1482 RVA: 0x0003014C File Offset: 0x0002E34C
	public Renewal(string string_0)
	{
		this.InitializeComponent();
		this.webView_0 = new WebView();
		this.webView_0.Create(base.Handle);
		this.webView_0.BeforeContextMenu += this.method_0;
		this.webView_0.LoadUrlAndWait(string_0);
		new Thread(new ThreadStart(this.method_1)).Start();
	}

	// Token: 0x060005CB RID: 1483 RVA: 0x00002C9B File Offset: 0x00000E9B
	private void method_0(object sender, BeforeContextMenuEventArgs e)
	{
		e.Menu.Items.Clear();
	}

	// Token: 0x060005CC RID: 1484 RVA: 0x000301BC File Offset: 0x0002E3BC
	private void method_1()
	{
		while (!this.webView_0.GetHtml().Contains("paid-text"))
		{
			Thread.Sleep(1000);
		}
		new Task(new Action(Renewal.Class119.class119_0.method_0)).Start();
	}

	// Token: 0x060005CD RID: 1485 RVA: 0x00005D62 File Offset: 0x00003F62
	protected override void OnFormClosing(FormClosingEventArgs formClosingEventArgs_0)
	{
		base.OnFormClosing(formClosingEventArgs_0);
		if (formClosingEventArgs_0.CloseReason == CloseReason.UserClosing)
		{
			Class168.form_0 = null;
		}
	}

	// Token: 0x040002BB RID: 699
	public WebView webView_0;

	// Token: 0x020000DD RID: 221
	[Serializable]
	private sealed class Class119
	{
		// Token: 0x060005D2 RID: 1490 RVA: 0x000302A0 File Offset: 0x0002E4A0
		internal void method_0()
		{
			MainWindow.webView_0.QueueScriptCall("swal('Please wait...', 'Waiting for license renewal to complete', 'info', {buttons:{visible: false}, closeOnClickOutside:false})");
			for (int i = 0; i < 5; i++)
			{
				Licenser.smethod_11(GClass0.string_2, false, true);
				if (Licenser.dateTime_0 > Class168.dateTime_0)
				{
					MainWindow.webView_0.QueueScriptCall("swal('Success', 'You have successfully renewed your license! You may now update to the latest version.', 'Success')");
					Class68.smethod_1();
					return;
				}
				Thread.Sleep(3000);
			}
			MainWindow.webView_0.QueueScriptCall("swal('Uh oh', 'It seems there was a problem renewing your license, please contact help@cybersole.io', 'warning')");
		}

		// Token: 0x040002BD RID: 701
		public static readonly Renewal.Class119 class119_0 = new Renewal.Class119();

		// Token: 0x040002BE RID: 702
		public static Action action_0;
	}
}
