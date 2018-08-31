using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using EO.Base;
using EO.WebBrowser;
using EO.WebEngine;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;

// Token: 0x02000014 RID: 20
public sealed partial class MainWindow : Form
{
	// Token: 0x06000067 RID: 103 RVA: 0x00009F0C File Offset: 0x0000810C
	public MainWindow()
	{
		this.InitializeComponent();
		MainWindow.mainWindow_0 = this;
		BrowserOptions options = new BrowserOptions
		{
			EnableWebSecurity = new bool?(false),
			LoadImages = new bool?(true)
		};
		EO.Base.Runtime.EnableEOWP = true;
		MainWindow.webView_0.SetOptions(options);
		MainWindow.webView_0.Engine = Engine.Create("CyberAIO");
		MainWindow.webView_0.Create(this.browser_panel.Handle);
		MainWindow.webView_0.BeforeContextMenu += this.method_5;
		MainWindow.webView_0.RegisterJSExtensionFunction("formDrag", new JSExtInvokeHandler(this.method_7));
		MainWindow.webView_0.RegisterJSExtensionFunction("CloseApplication", new JSExtInvokeHandler(this.method_9));
		MainWindow.webView_0.RegisterJSExtensionFunction("MinimizeApplication", new JSExtInvokeHandler(this.method_8));
		MainWindow.webView_0.RegisterJSExtensionFunction("OpenCaptchaQueue", new JSExtInvokeHandler(MainWindow.smethod_2));
		MainWindow.webView_0.RegisterJSExtensionFunction("CheckForUpdates", new JSExtInvokeHandler(Class23.smethod_7));
		MainWindow.webView_0.RegisterJSExtensionFunction("StartUpdate", new JSExtInvokeHandler(Class23.smethod_8));
		MainWindow.webView_0.RegisterJSExtensionFunction("Renew", new JSExtInvokeHandler(Class23.smethod_11));
		MainWindow.webView_0.RegisterJSExtensionFunction("ContactSupport", new JSExtInvokeHandler(Class68.smethod_10));
		MainWindow.webView_0.RegisterJSExtensionFunction("ResetKey", new JSExtInvokeHandler(Class68.smethod_11));
		MainWindow.webView_0.RegisterJSExtensionFunction("SaveSettings", new JSExtInvokeHandler(Class68.smethod_9));
		MainWindow.webView_0.RegisterJSExtensionFunction("setProfiles", new JSExtInvokeHandler(Class68.smethod_3));
		MainWindow.webView_0.RegisterJSExtensionFunction("setTasks", new JSExtInvokeHandler(Class68.smethod_4));
		MainWindow.webView_0.RegisterJSExtensionFunction("setProxies", new JSExtInvokeHandler(Class68.smethod_5));
		MainWindow.webView_0.RegisterJSExtensionFunction("ExportAll", new JSExtInvokeHandler(Class68.smethod_12));
		MainWindow.webView_0.RegisterJSExtensionFunction("ImportAll", new JSExtInvokeHandler(Class68.smethod_13));
		MainWindow.webView_0.RegisterJSExtensionFunction("showLogs", new JSExtInvokeHandler(Class68.smethod_2));
		MainWindow.webView_0.RegisterJSExtensionFunction("setMassLink", new JSExtInvokeHandler(Class68.smethod_0));
		MainWindow.webView_0.RegisterJSExtensionFunction("open_file_import", new JSExtInvokeHandler(Class46.smethod_0));
		MainWindow.webView_0.RegisterJSExtensionFunction("open_file_export", new JSExtInvokeHandler(Class46.smethod_1));
		MainWindow.webView_0.RegisterJSExtensionFunction("startTask", new JSExtInvokeHandler(Class111.smethod_0));
		MainWindow.webView_0.RegisterJSExtensionFunction("stopTask", new JSExtInvokeHandler(Class111.smethod_1));
		MainWindow.webView_0.RegisterJSExtensionFunction("testProxy", new JSExtInvokeHandler(Class96.smethod_0));
		MainWindow.webView_0.LoadHtml(this.method_4(Class168.string_0), "file:///" + Directory.GetCurrentDirectory() + "/");
		MainWindow.webView_0.LoadCompleted += this.method_2;
		EO.Base.Runtime.Exception += this.method_0;
	}

	// Token: 0x06000069 RID: 105 RVA: 0x0000A248 File Offset: 0x00008448
	public static void smethod_0(EventHandler eventHandler_1)
	{
		EventHandler eventHandler = MainWindow.eventHandler_0;
		EventHandler eventHandler2;
		do
		{
			eventHandler2 = eventHandler;
			EventHandler value = (EventHandler)Delegate.Combine(eventHandler2, eventHandler_1);
			eventHandler = Interlocked.CompareExchange<EventHandler>(ref MainWindow.eventHandler_0, value, eventHandler2);
		}
		while (eventHandler != eventHandler2);
	}

	// Token: 0x0600006A RID: 106 RVA: 0x0000A27C File Offset: 0x0000847C
	public static void smethod_1(EventHandler eventHandler_1)
	{
		EventHandler eventHandler = MainWindow.eventHandler_0;
		EventHandler eventHandler2;
		do
		{
			eventHandler2 = eventHandler;
			EventHandler value = (EventHandler)Delegate.Remove(eventHandler2, eventHandler_1);
			eventHandler = Interlocked.CompareExchange<EventHandler>(ref MainWindow.eventHandler_0, value, eventHandler2);
		}
		while (eventHandler != eventHandler2);
	}

	// Token: 0x0600006B RID: 107
	[DllImport("user32.dll")]
	public static extern int SendMessage(IntPtr intptr_0, int int_0, int int_1, int int_2);

	// Token: 0x0600006C RID: 108
	[DllImport("user32.dll")]
	public static extern bool ReleaseCapture();

	// Token: 0x0600006D RID: 109 RVA: 0x00002FB8 File Offset: 0x000011B8
	private void method_0(object sender, ExceptionEventArgs e)
	{
		GClass3.smethod_0(e.ErrorException.Message, "Webview Error");
	}

	// Token: 0x0600006E RID: 110 RVA: 0x0000A2B0 File Offset: 0x000084B0
	public void method_1()
	{
		if (Screen.PrimaryScreen.WorkingArea.Height < 800)
		{
			Size size = new Size(Screen.PrimaryScreen.WorkingArea.Width - 15, Screen.PrimaryScreen.WorkingArea.Height - 10);
			base.Size = size;
			this.browser_panel.Size = new Size(size.Width - 5, size.Height - 5);
			this.MinimumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width - 25, Screen.PrimaryScreen.WorkingArea.Height - 20);
			MainWindow.webView_0.ZoomFactor = 0.83;
			return;
		}
		Size size2 = new Size(1400, 820);
		base.Size = size2;
		this.browser_panel.Size = new Size(size2.Width - 5, size2.Height - 5);
		this.MinimumSize = new Size(1300, 820);
	}

	// Token: 0x0600006F RID: 111 RVA: 0x0000A3CC File Offset: 0x000085CC
	private void method_2(object sender, LoadCompletedEventArgs e)
	{
		this.method_1();
		Class68.smethod_1();
		MainWindow.captchaQueue_V1_0 = new CaptchaQueue_V1(true);
		Class68.smethod_6();
		Class68.smethod_7();
		Class68.smethod_8();
		Class68.smethod_5(null, null);
		bool isAttached = Debugger.IsAttached;
		Licenser.smethod_9();
		Class168.jobject_3 = JObject.Parse(MainWindow.webView_0.QueueScriptCall("JSON.stringify(window.Countries)").smethod_0());
		Class23.smethod_0();
		base.Opacity = 0.0;
		base.Show();
		this.timer_0.Interval = 10;
		this.timer_0.Tick += this.timer_0_Tick;
		this.timer_0.Start();
	}

	// Token: 0x06000070 RID: 112 RVA: 0x0000A478 File Offset: 0x00008678
	public async void method_3()
	{
		TaskAwaiter<string> taskAwaiter = Class138.smethod_1(File.OpenRead("audio.mp3")).GetAwaiter();
		if (!taskAwaiter.IsCompleted)
		{
			await taskAwaiter;
			TaskAwaiter<string> taskAwaiter2;
			taskAwaiter = taskAwaiter2;
			taskAwaiter2 = default(TaskAwaiter<string>);
		}
		Console.WriteLine(taskAwaiter.GetResult());
	}

	// Token: 0x06000071 RID: 113 RVA: 0x0000A4AC File Offset: 0x000086AC
	private void timer_0_Tick(object sender, EventArgs e)
	{
		if (base.Opacity >= 1.0)
		{
			this.timer_0.Stop();
			MainWindow.eventHandler_0(this, e);
			return;
		}
		base.Opacity += 0.05;
	}

	// Token: 0x06000072 RID: 114 RVA: 0x0000A4F8 File Offset: 0x000086F8
	public string method_4(string string_1)
	{
		HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
		htmlDocument.LoadHtml(string_1);
		string text = "<option value='Custom'>Custom</option>";
		foreach (KeyValuePair<string, JToken> keyValuePair in Class168.jobject_4)
		{
			text += string.Format("<option value='{0}'>{1}</option>", keyValuePair.Key, keyValuePair.Key);
		}
		string str = "<option></option>";
		foreach (string text2 in MainWindow.string_0)
		{
			str += string.Format("<option value='{0}'>{1}</option>", text2, text2);
		}
		htmlDocument.DocumentNode.SelectSingleNode("//optgroup[@label='Shopify']").InnerHtml = text;
		string innerHtml = str + htmlDocument.DocumentNode.SelectSingleNode("//select[@id='store-dropdown']").InnerHtml;
		htmlDocument.DocumentNode.SelectSingleNode("//select[@id='store-dropdown']").InnerHtml = innerHtml;
		return htmlDocument.DocumentNode.InnerHtml;
	}

	// Token: 0x06000073 RID: 115 RVA: 0x00002FD0 File Offset: 0x000011D0
	protected override void OnFormClosing(FormClosingEventArgs formClosingEventArgs_0)
	{
		this.method_9(null, null);
		base.OnFormClosing(formClosingEventArgs_0);
	}

	// Token: 0x06000074 RID: 116 RVA: 0x00002FE1 File Offset: 0x000011E1
	protected override void SetVisibleCore(bool value)
	{
		if (!base.IsHandleCreated)
		{
			this.CreateHandle();
			value = false;
		}
		base.SetVisibleCore(value);
	}

	// Token: 0x06000075 RID: 117 RVA: 0x00002FFB File Offset: 0x000011FB
	public static void smethod_2(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		MainWindow.captchaQueue_V1_0.Show();
		MainWindow.captchaQueue_V1_0.WindowState = FormWindowState.Normal;
		MainWindow.captchaQueue_V1_0.BringToFront();
	}

	// Token: 0x06000076 RID: 118 RVA: 0x00002C9B File Offset: 0x00000E9B
	private void method_5(object sender, BeforeContextMenuEventArgs e)
	{
		e.Menu.Items.Clear();
	}

	// Token: 0x06000077 RID: 119
	[DllImport("user32.dll")]
	private static extern IntPtr GetForegroundWindow();

	// Token: 0x06000078 RID: 120 RVA: 0x0000301C File Offset: 0x0000121C
	public bool method_6(IntPtr intptr_0)
	{
		return MainWindow.GetForegroundWindow() == intptr_0;
	}

	// Token: 0x06000079 RID: 121 RVA: 0x00003029 File Offset: 0x00001229
	private void method_7(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		if (this.method_6(base.Handle))
		{
			MainWindow.ReleaseCapture();
			MainWindow.SendMessage(base.Handle, 161, 2, 0);
		}
	}

	// Token: 0x0600007A RID: 122 RVA: 0x0000A604 File Offset: 0x00008804
	protected override void WndProc(ref Message message_0)
	{
		if (message_0.Msg == 132)
		{
			int x = (int)(message_0.LParam.ToInt64() & 65535L);
			int y = (int)((message_0.LParam.ToInt64() & 4294901760L) >> 16);
			Point point = base.PointToClient(new Point(x, y));
			Size clientSize = base.ClientSize;
			if (point.X >= clientSize.Width - 16 && point.Y >= clientSize.Height - 16 && clientSize.Height >= 16)
			{
				message_0.Result = (IntPtr)(base.IsMirrored ? 16 : 17);
				return;
			}
			if (point.X <= 16 && point.Y >= clientSize.Height - 16 && clientSize.Height >= 16)
			{
				message_0.Result = (IntPtr)(base.IsMirrored ? 17 : 16);
				return;
			}
			if (point.X <= 16 && point.Y <= 16 && clientSize.Height >= 16)
			{
				message_0.Result = (IntPtr)(base.IsMirrored ? 14 : 13);
				return;
			}
			if (point.X >= clientSize.Width - 16 && point.Y <= 16 && clientSize.Height >= 16)
			{
				message_0.Result = (IntPtr)(base.IsMirrored ? 13 : 14);
				return;
			}
			if (point.Y <= 16 && clientSize.Height >= 16)
			{
				message_0.Result = (IntPtr)12;
				return;
			}
			if (point.Y >= clientSize.Height - 16 && clientSize.Height >= 16)
			{
				message_0.Result = (IntPtr)15;
				return;
			}
			if (point.X <= 16 && clientSize.Height >= 16)
			{
				message_0.Result = (IntPtr)10;
				return;
			}
			if (point.X >= clientSize.Width - 16 && clientSize.Height >= 16)
			{
				message_0.Result = (IntPtr)11;
				return;
			}
		}
		base.WndProc(ref message_0);
	}

	// Token: 0x0600007B RID: 123 RVA: 0x00002CBD File Offset: 0x00000EBD
	public void method_8(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		base.WindowState = FormWindowState.Minimized;
	}

	// Token: 0x0600007C RID: 124 RVA: 0x00003052 File Offset: 0x00001252
	public void method_9(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		GClass0.smethod_2();
		MainWindow.mainWindow_0.BeginInvoke(null, null);
		Process.GetCurrentProcess().Kill();
	}

	// Token: 0x0600007F RID: 127 RVA: 0x0000308F File Offset: 0x0000128F
	private void method_10()
	{
		base.Hide();
		MainWindow.webView_0.Close(true);
	}

	// Token: 0x04000052 RID: 82
	public static string[] string_0 = new string[]
	{
		"Off-White"
	};

	// Token: 0x04000053 RID: 83
	[Dynamic(new bool[]
	{
		false,
		false,
		false,
		false,
		true
	})]
	public static Dictionary<int, Dictionary<string, dynamic>> dictionary_0 = new Dictionary<int, Dictionary<string, object>>();

	// Token: 0x04000054 RID: 84
	public static WebView webView_0 = new WebView();

	// Token: 0x04000055 RID: 85
	public static CaptchaQueue_V1 captchaQueue_V1_0;

	// Token: 0x04000056 RID: 86
	public static Random random_0 = new Random();

	// Token: 0x04000057 RID: 87
	public static MainWindow mainWindow_0;

	// Token: 0x04000058 RID: 88
	private readonly System.Windows.Forms.Timer timer_0 = new System.Windows.Forms.Timer();

	// Token: 0x04000059 RID: 89
	private static EventHandler eventHandler_0;

	// Token: 0x02000015 RID: 21
	[StructLayout(LayoutKind.Auto)]
	private struct Struct0 : IAsyncStateMachine
	{
		// Token: 0x06000080 RID: 128 RVA: 0x0000AA18 File Offset: 0x00008C18
		void IAsyncStateMachine.MoveNext()
		{
			int num = this.int_0;
			try
			{
				TaskAwaiter<string> awaiter;
				if (num != 0)
				{
					awaiter = Class138.smethod_1(File.OpenRead("audio.mp3")).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						this.int_0 = 0;
						this.taskAwaiter_0 = awaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, MainWindow.Struct0>(ref awaiter, ref this);
						return;
					}
				}
				else
				{
					awaiter = this.taskAwaiter_0;
					this.taskAwaiter_0 = default(TaskAwaiter<string>);
					this.int_0 = -1;
				}
				Console.WriteLine(awaiter.GetResult());
			}
			catch (Exception exception)
			{
				this.int_0 = -2;
				this.asyncVoidMethodBuilder_0.SetException(exception);
				return;
			}
			this.int_0 = -2;
			this.asyncVoidMethodBuilder_0.SetResult();
		}

		// Token: 0x06000081 RID: 129 RVA: 0x000030A2 File Offset: 0x000012A2
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncVoidMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400005F RID: 95
		public int int_0;

		// Token: 0x04000060 RID: 96
		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		// Token: 0x04000061 RID: 97
		private TaskAwaiter<string> taskAwaiter_0;
	}
}
