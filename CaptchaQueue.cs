using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using EO.WebBrowser;
using EO.WebEngine;

// Token: 0x02000004 RID: 4
public sealed partial class CaptchaQueue : Form
{
	// Token: 0x0600000B RID: 11 RVA: 0x00006D14 File Offset: 0x00004F14
	public CaptchaQueue()
	{
		this.InitializeComponent();
		this.method_0();
		System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
		timer.Interval = 500;
		timer.Tick += CaptchaQueue.smethod_3;
		timer.Start();
	}

	// Token: 0x0600000D RID: 13 RVA: 0x00006D68 File Offset: 0x00004F68
	public void method_0()
	{
		BrowserOptions options = new BrowserOptions
		{
			EnableXSSAuditor = new bool?(false),
			EnableWebSecurity = new bool?(false)
		};
		CaptchaQueue.webView_0 = new WebView();
		CaptchaQueue.webView_0.SetOptions(options);
		CaptchaQueue.webView_0.Create(this.browser_panel.Handle);
		CaptchaQueue.webView_0.RegisterJSExtensionFunction("submit", new JSExtInvokeHandler(this.method_1));
		CaptchaQueue.webView_0.CertificateError += this.method_3;
		CaptchaQueue.webView_0.BeforeContextMenu += this.method_2;
		CaptchaQueue.concurrentDictionary_1["main"] = true;
		CaptchaQueue.webView_1 = this.threadRunner_0.CreateWebView();
		CaptchaQueue.webView_1.SetOptions(options);
		CaptchaQueue.webView_1.RegisterJSExtensionFunction("submit", new JSExtInvokeHandler(this.method_1));
		CaptchaQueue.webView_1.CertificateError += this.method_3;
		CaptchaQueue.webView_1.BeforeContextMenu += this.method_2;
		CaptchaQueue.concurrentDictionary_1["browser2"] = true;
		CaptchaQueue.webView_2 = this.threadRunner_0.CreateWebView();
		CaptchaQueue.webView_2.SetOptions(options);
		CaptchaQueue.webView_2.RegisterJSExtensionFunction("submit", new JSExtInvokeHandler(this.method_1));
		CaptchaQueue.webView_2.CertificateError += this.method_3;
		CaptchaQueue.webView_2.BeforeContextMenu += this.method_2;
		CaptchaQueue.concurrentDictionary_1["browser3"] = true;
		CaptchaQueue.webView_3 = this.threadRunner_0.CreateWebView();
		CaptchaQueue.webView_3.SetOptions(options);
		CaptchaQueue.webView_3.RegisterJSExtensionFunction("submit", new JSExtInvokeHandler(this.method_1));
		CaptchaQueue.webView_3.CertificateError += this.method_3;
		CaptchaQueue.webView_3.BeforeContextMenu += this.method_2;
		CaptchaQueue.concurrentDictionary_1["browser4"] = true;
		CaptchaQueue.smethod_7();
		this.google_Login_0 = new Google_Login();
	}

	// Token: 0x0600000E RID: 14 RVA: 0x00006F7C File Offset: 0x0000517C
	private void method_1(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		CaptchaQueue.Class1 @class = new CaptchaQueue.Class1();
		@class.jsextInvokeArgs_0 = jsextInvokeArgs_0;
		CaptchaQueue.concurrentDictionary_0[@class.jsextInvokeArgs_0.Arguments[1].ToString()] = @class.jsextInvokeArgs_0.Arguments.First<object>().ToString();
		ConcurrentDictionary<string, string> concurrentDictionary = CaptchaQueue.list_0.Where(new Func<ConcurrentDictionary<string, string>, bool>(@class.method_0)).First<ConcurrentDictionary<string, string>>();
		CaptchaQueue.list_0.Remove(concurrentDictionary);
		CaptchaQueue.concurrentDictionary_1[concurrentDictionary["browser_name"]] = true;
	}

	// Token: 0x0600000F RID: 15 RVA: 0x00002C18 File Offset: 0x00000E18
	public static string smethod_0(string string_0, string string_1, string string_2)
	{
		return string.Empty;
	}

	// Token: 0x06000010 RID: 16 RVA: 0x00007008 File Offset: 0x00005208
	public static string smethod_1(string string_0, string string_1, string string_2)
	{
		if (string_1.Contains("supreme") && Licenser.string_0.Contains("Sole Solution"))
		{
			return CaptchaQueue.smethod_0(string_0, string_1, string_2);
		}
		if (!MainWindow.captchaQueue_V1_0.Visible)
		{
			MainWindow.mainWindow_0.Invoke(new MethodInvoker(CaptchaQueue.Class0.class0_0.method_0));
		}
		string text = Class103.smethod_0(16);
		ConcurrentDictionary<string, string> concurrentDictionary = new ConcurrentDictionary<string, string>();
		concurrentDictionary["sitekey"] = string_0;
		concurrentDictionary["domain"] = string_1;
		concurrentDictionary["taskID"] = string_2;
		concurrentDictionary["token"] = text;
		concurrentDictionary["use_invisible"] = "true";
		concurrentDictionary["solving"] = "false";
		CaptchaQueue.list_0.Add(concurrentDictionary);
		string result;
		try
		{
			while (!CaptchaQueue.concurrentDictionary_0.ContainsKey(text))
			{
				Thread.Sleep(100);
			}
			result = CaptchaQueue.concurrentDictionary_0[text];
		}
		catch (ThreadAbortException)
		{
			CaptchaQueue.list_0.Remove(concurrentDictionary);
			if (concurrentDictionary.ContainsKey("browser_name"))
			{
				CaptchaQueue.concurrentDictionary_1[concurrentDictionary["browser_name"]] = true;
			}
			Thread.CurrentThread.Abort();
			result = string.Empty;
		}
		catch
		{
			result = string.Empty;
		}
		return result;
	}

	// Token: 0x06000011 RID: 17 RVA: 0x00007168 File Offset: 0x00005368
	public static WebView smethod_2(bool bool_1, out bool bool_2, out bool bool_3, out string string_0)
	{
		if (CaptchaQueue.concurrentDictionary_1["main"])
		{
			CaptchaQueue.concurrentDictionary_1["main"] = false;
			bool_2 = false;
			bool_3 = true;
			string_0 = "main";
			GClass3.smethod_0("Main solver is available", "Captcha Solver");
			return CaptchaQueue.webView_0;
		}
		if (bool_1)
		{
			CaptchaQueue.concurrentDictionary_1.Where(new Func<KeyValuePair<string, bool>, bool>(CaptchaQueue.Class0.class0_0.method_1));
			if (CaptchaQueue.concurrentDictionary_1["browser2"])
			{
				CaptchaQueue.concurrentDictionary_1["browser2"] = false;
				bool_2 = true;
				bool_3 = true;
				string_0 = "browser2";
				GClass3.smethod_0("Solver 2 is available", "Captcha Solver");
				return CaptchaQueue.webView_1;
			}
			if (CaptchaQueue.concurrentDictionary_1["browser3"])
			{
				CaptchaQueue.concurrentDictionary_1["browser3"] = false;
				bool_2 = true;
				bool_3 = true;
				string_0 = "browser3";
				GClass3.smethod_0("Solver 3 is available", "Captcha Solver");
				return CaptchaQueue.webView_2;
			}
			if (CaptchaQueue.concurrentDictionary_1["browser4"])
			{
				CaptchaQueue.concurrentDictionary_1["browser4"] = false;
				bool_2 = true;
				bool_3 = true;
				string_0 = "browser4";
				GClass3.smethod_0("Solver 4 is available", "Captcha Solver");
				return CaptchaQueue.webView_2;
			}
		}
		bool_3 = false;
		bool_2 = false;
		string_0 = string.Empty;
		return null;
	}

	// Token: 0x06000012 RID: 18 RVA: 0x00002C1F File Offset: 0x00000E1F
	public static void smethod_3(object sender, EventArgs e)
	{
		new Task(new Action(CaptchaQueue.Class0.class0_0.method_2)).Start();
	}

	// Token: 0x06000013 RID: 19 RVA: 0x000072C4 File Offset: 0x000054C4
	public static string smethod_4(string string_0, string string_1, string string_2, string string_3)
	{
		CaptchaQueue.bool_0 = true;
		return string.Concat(new string[]
		{
			"<!DOCTYPE html>\r\n                            <html>\r\n                            <body onload='click()'>\r\n                            <style>\r\n                            body \r\n                            {\r\n                                background-color: #19171A\r\n                            }\r\n                            </style>\r\n                            <script>function _submit(token){ submit(token, '",
			string_2,
			"'); } </script>\r\n                            <div align='center' class='g-recaptcha' data-sitekey='",
			string_0,
			"' data-theme='dark' data-callback='_submit'></div>\r\n                            <center style='color:white; font-family:Verdana;margin:20px'><hr width='40px'></center>\r\n\t\t\t\t\t\t\t<center style='color:white; font-family:Verdana;margin:10px'><b>Task ID:</b> ",
			string_1,
			"</center>\r\n\t\t\t\t\t\t\t<center style='color:white; font-family:Verdana'><b>Retailer:</b> ",
			new Uri(string_3).Host,
			"</center>\r\n                            <script type='text/javascript' src='https://www.google.com/recaptcha/api.js'></script>\r\n                            <script>function click(){window.frames[0].document.getElementsByClassName('recaptcha-checkbox-checkmark')[0].click();}</script>\r\n                            </body>\r\n                            </html>"
		});
	}

	// Token: 0x06000014 RID: 20 RVA: 0x00002C4A File Offset: 0x00000E4A
	public static string smethod_5(string string_0, string string_1)
	{
		CaptchaQueue.bool_0 = true;
		return string.Concat(new string[]
		{
			"<html>\r\n\t                        <style>\r\n\t                        body \r\n\t                        {\r\n\t                        background-color: #19171A\r\n\t                        }\r\n\t                        </style>\r\n                            <script>function _submit(captcha){ submit(captcha, '",
			string_1,
			"'); };</script>\r\n\t                        <body onclick='grecaptcha.execute();' onload='grecaptcha.execute();'>\r\n                            <div class='g-recaptcha'\r\n                                  data-sitekey='",
			string_0,
			"'\r\n                                  data-callback='_submit'\r\n                                  data-size='invisible'\r\n\t\t                          data-theme='dark'>\r\n                            </div>\r\n\r\n                            <script src='https://www.google.com/recaptcha/api.js' async defer></script>\r\n                        </html>"
		});
	}

	// Token: 0x06000015 RID: 21 RVA: 0x00002C7D File Offset: 0x00000E7D
	public static string smethod_6()
	{
		CaptchaQueue.bool_0 = false;
		return "<!DOCTYPE html>\r\n                            <html lang='en' >\r\n\r\n                            <head>\r\n                                <meta charset='UTF-8'>\r\n                                <title>Loading circle</title>\r\n                                <link href='https://fonts.googleapis.com/css?family=Montserrat' rel='stylesheet'>\r\n\r\n                                <link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/normalize/5.0.0/normalize.min.css'>\r\n\r\n  \r\n\r\n  \r\n                            </head>\r\n                            <style>\r\n                            \r\n                            body{\r\n                                background-color: #19171A;\r\n                            }\r\n                            #loader-page {\r\n                                position: fixed;\r\n                                top: 0;\r\n                                left: 0;\r\n                                height: 100%;\r\n                                width: 100%;\r\n                                background-color: transparent;\r\n                            }\r\n\r\n                            .loader-name {\r\n                                position: absolute;\r\n                                top: 50%;\r\n                                left: 50%;\r\n                                margin-top: -10px;\r\n                                margin-left: -52px;\r\n                                font-size: 125%;\r\n                                font-family: 'Montserrat', sans-serif;\r\n                                text-transform: uppercase;\r\n                                letter-spacing: 0.1em;\r\n                                color: #fefefe;\r\n                            }\r\n\r\n                            .loader-circle {\r\n                                width: 180px;\r\n                                height: 180px;\r\n                                -webkit-box-sizing: border-box;\r\n                                        box-sizing: border-box;\r\n                                position: fixed;\r\n                                top: 50%;\r\n                                left: 50%;\r\n                                border-top: 5px solid #fefefe;\r\n                                border-bottom: 2px solid transparent;\r\n                                border-left: 2px solid transparent;\r\n                                border-right: 2px solid transparent;\r\n                                border-radius: 50%;\r\n                                margin-top: -90px;\r\n                                margin-left: -90px;\r\n                                -webkit-animation: loader 1s infinite linear;\r\n                                        animation: loader 1s infinite linear;\r\n                            }\r\n\r\n                            @-webkit-keyframes loader {\r\n                                from {\r\n                                -webkit-transform: rotate(0deg);\r\n                                        transform: rotate(0deg);\r\n                                }\r\n                                to {\r\n                                -webkit-transform: rotate(360deg);\r\n                                        transform: rotate(360deg);\r\n                                }\r\n                            }\r\n\r\n                            @keyframes loader {\r\n                                from {\r\n                                -webkit-transform: rotate(0deg);\r\n                                        transform: rotate(0deg);\r\n                                }\r\n                                to {\r\n                                -webkit-transform: rotate(360deg);\r\n                                        transform: rotate(360deg);\r\n                                }\r\n                            }\r\n\r\n\r\n                            </style>\r\n                            <body>\r\n\r\n\t                            <div class='loader-name'>Waiting</div>\r\n\t                            <div class='loader-circle'></div>\r\n                            </div>\r\n  \r\n  \r\n\r\n                            </body>\r\n\r\n                            </html>\r\n                            ";
	}

	// Token: 0x06000016 RID: 22 RVA: 0x00002C8A File Offset: 0x00000E8A
	public static void smethod_7()
	{
		CaptchaQueue.webView_0.LoadHtmlAndWait(CaptchaQueue.smethod_6());
	}

	// Token: 0x06000017 RID: 23 RVA: 0x00002C9B File Offset: 0x00000E9B
	private void method_2(object sender, BeforeContextMenuEventArgs e)
	{
		e.Menu.Items.Clear();
	}

	// Token: 0x06000018 RID: 24 RVA: 0x00002CAD File Offset: 0x00000EAD
	public void method_3(object sender, CertificateErrorEventArgs e)
	{
		e.Continue();
	}

	// Token: 0x06000019 RID: 25 RVA: 0x00002CB5 File Offset: 0x00000EB5
	private void close_btn_Click(object sender, EventArgs e)
	{
		base.Hide();
	}

	// Token: 0x0600001A RID: 26 RVA: 0x00002CBD File Offset: 0x00000EBD
	private void minimise_btn_Click(object sender, EventArgs e)
	{
		base.WindowState = FormWindowState.Minimized;
	}

	// Token: 0x0600001B RID: 27 RVA: 0x00002CC6 File Offset: 0x00000EC6
	private void googlelogin_button_Click(object sender, EventArgs e)
	{
		this.google_Login_0.Show();
		this.google_Login_0.webView_0.LoadUrl("https://accounts.google.com/signin/v2/sl/pwd?service=youtube&uilel=3&continue=https%3A%2F%2Fwww.youtube.com%2Fsignin%3Fapp%3Ddesktop%26action_handle_signin%3Dtrue%26hl%3Den%26next%3D%252F%253Fgl%253DGB%2526hl%253Den-GB&passive=true&flowName=GlifWebSignIn&flowEntry=ServiceLogin");
	}

	// Token: 0x0600001C RID: 28 RVA: 0x00007328 File Offset: 0x00005528
	private void clearsession_button_Click(object sender, EventArgs e)
	{
		CaptchaQueue.webView_0.Engine.Stop(true);
		CaptchaQueue.webView_0.Dispose();
		this.method_0();
		this.google_Login_0.webView_0.Dispose();
		this.google_Login_0.method_0(null);
		CaptchaQueue.list_0.ForEach(new Action<ConcurrentDictionary<string, string>>(CaptchaQueue.Class0.class0_0.method_4));
	}

	// Token: 0x04000002 RID: 2
	public static WebView webView_0;

	// Token: 0x04000003 RID: 3
	public static WebView webView_1;

	// Token: 0x04000004 RID: 4
	public static WebView webView_2;

	// Token: 0x04000005 RID: 5
	public static WebView webView_3;

	// Token: 0x04000006 RID: 6
	public static bool bool_0;

	// Token: 0x04000007 RID: 7
	public static List<ConcurrentDictionary<string, string>> list_0 = new List<ConcurrentDictionary<string, string>>();

	// Token: 0x04000008 RID: 8
	public static ConcurrentDictionary<string, string> concurrentDictionary_0 = new ConcurrentDictionary<string, string>();

	// Token: 0x04000009 RID: 9
	public static ConcurrentDictionary<string, bool> concurrentDictionary_1 = new ConcurrentDictionary<string, bool>();

	// Token: 0x0400000A RID: 10
	public static SoundPlayer soundPlayer_0 = new SoundPlayer("audio/ding.wav");

	// Token: 0x0400000B RID: 11
	public Google_Login google_Login_0;

	// Token: 0x0400000C RID: 12
	private readonly ThreadRunner threadRunner_0 = new ThreadRunner();

	// Token: 0x02000005 RID: 5
	[Serializable]
	private sealed class Class0
	{
		// Token: 0x06000021 RID: 33 RVA: 0x00002D1C File Offset: 0x00000F1C
		internal void method_0()
		{
			MainWindow.captchaQueue_V1_0.Show();
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002D28 File Offset: 0x00000F28
		internal bool method_1(KeyValuePair<string, bool> keyValuePair_0)
		{
			return object.Equals(true, keyValuePair_0.Value);
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00007E4C File Offset: 0x0000604C
		internal void method_2()
		{
			if (CaptchaQueue.list_0.Count > 0)
			{
				ConcurrentDictionary<string, string>[] array = CaptchaQueue.list_0.Where(new Func<ConcurrentDictionary<string, string>, bool>(CaptchaQueue.Class0.class0_0.method_3)).ToArray<ConcurrentDictionary<string, string>>();
				for (int i = 0; i < array.Length; i++)
				{
					CaptchaQueue.Class2 @class = new CaptchaQueue.Class2();
					@class.concurrentDictionary_0 = array[i];
					CaptchaQueue.Class3 class2 = new CaptchaQueue.Class3();
					class2.class2_0 = @class;
					if (class2.class2_0.concurrentDictionary_0 == null)
					{
						return;
					}
					bool flag = false;
					bool flag2 = false;
					class2.webView_0 = CaptchaQueue.smethod_2(class2.class2_0.concurrentDictionary_0["use_invisible"] == "true", out flag2, out flag, out class2.string_0);
					if (!flag2)
					{
						class2.class2_0.concurrentDictionary_0["use_invisible"] = "false";
					}
					class2.class2_0.concurrentDictionary_0["browser_name"] = class2.string_0;
					if (flag)
					{
						class2.class2_0.concurrentDictionary_0["solving"] = "true";
						if (!flag2)
						{
							CaptchaQueue.soundPlayer_0.Play();
						}
						if (class2.class2_0.concurrentDictionary_0["domain"].Contains("supreme"))
						{
							class2.webView_0.LoadHtml(CaptchaQueue.smethod_5(class2.class2_0.concurrentDictionary_0["sitekey"], class2.class2_0.concurrentDictionary_0["token"]), class2.class2_0.concurrentDictionary_0["domain"]);
						}
						else
						{
							class2.webView_0.LoadHtml(CaptchaQueue.smethod_4(class2.class2_0.concurrentDictionary_0["sitekey"], class2.class2_0.concurrentDictionary_0["taskID"], class2.class2_0.concurrentDictionary_0["token"], class2.class2_0.concurrentDictionary_0["domain"]), class2.class2_0.concurrentDictionary_0["domain"]);
						}
						if (flag2)
						{
							new Task(new Action(class2.method_0)).Start();
						}
					}
				}
				return;
			}
			if (CaptchaQueue.concurrentDictionary_1["main"] && !CaptchaQueue.webView_0.GetText().Contains("WAITING"))
			{
				CaptchaQueue.smethod_7();
			}
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002D41 File Offset: 0x00000F41
		internal bool method_3(ConcurrentDictionary<string, string> concurrentDictionary_0)
		{
			return concurrentDictionary_0["solving"] == "false";
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002D58 File Offset: 0x00000F58
		internal void method_4(ConcurrentDictionary<string, string> concurrentDictionary_0)
		{
			concurrentDictionary_0["solving"] = "false";
		}

		// Token: 0x0400001A RID: 26
		public static readonly CaptchaQueue.Class0 class0_0 = new CaptchaQueue.Class0();

		// Token: 0x0400001B RID: 27
		public static MethodInvoker methodInvoker_0;

		// Token: 0x0400001C RID: 28
		public static Func<KeyValuePair<string, bool>, bool> func_0;

		// Token: 0x0400001D RID: 29
		public static Func<ConcurrentDictionary<string, string>, bool> func_1;

		// Token: 0x0400001E RID: 30
		public static Action action_0;

		// Token: 0x0400001F RID: 31
		public static Action<ConcurrentDictionary<string, string>> action_1;
	}

	// Token: 0x02000006 RID: 6
	private sealed class Class1
	{
		// Token: 0x06000027 RID: 39 RVA: 0x00002D6A File Offset: 0x00000F6A
		internal bool method_0(ConcurrentDictionary<string, string> concurrentDictionary_0)
		{
			return concurrentDictionary_0["token"] == this.jsextInvokeArgs_0.Arguments[1].ToString();
		}

		// Token: 0x04000020 RID: 32
		public JSExtInvokeArgs jsextInvokeArgs_0;
	}

	// Token: 0x02000007 RID: 7
	private sealed class Class2
	{
		// Token: 0x04000021 RID: 33
		public ConcurrentDictionary<string, string> concurrentDictionary_0;
	}

	// Token: 0x02000008 RID: 8
	private sealed class Class3
	{
		// Token: 0x0600002A RID: 42 RVA: 0x000080B0 File Offset: 0x000062B0
		internal void method_0()
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			while (!CaptchaQueue.concurrentDictionary_0.ContainsKey(this.class2_0.concurrentDictionary_0["token"]) && this.class2_0.concurrentDictionary_0["use_invisible"] == "true" && CaptchaQueue.list_0.Contains(this.class2_0.concurrentDictionary_0))
			{
				try
				{
					string text = this.webView_0.QueueScriptCall("if(window.frames.length > 1){ if(window.frames[1].document.readyState == 'complete'){ window.frames[1].document.body.innerHTML; }else{ '' }}else{ ''}").smethod_0();
					if (text.Contains("rc-imageselect-desc"))
					{
						this.webView_0.LoadHtml("WAITING");
						GClass3.smethod_0("Manual solving needed, pushing to main queue", "Captcha Queue");
						this.class2_0.concurrentDictionary_0["use_invisible"] = "false";
						this.class2_0.concurrentDictionary_0["solving"] = "false";
						CaptchaQueue.concurrentDictionary_1[this.string_0] = true;
						return;
					}
					if (text.Contains("recaptcha-checkbox-checkmark"))
					{
						this.webView_0.LoadHtml("WAITING");
						CaptchaQueue.concurrentDictionary_1[this.string_0] = true;
						return;
					}
					if (stopwatch.Elapsed.TotalSeconds > 5.0)
					{
						this.webView_0.LoadHtml("WAITING");
						GClass3.smethod_0("Solving timed out, pushing to main queue", "Captcha Queue");
						this.class2_0.concurrentDictionary_0["solving"] = "false";
						this.class2_0.concurrentDictionary_0["use_invisible"] = "false";
						CaptchaQueue.concurrentDictionary_1[this.string_0] = true;
						return;
					}
				}
				catch
				{
				}
				Thread.Sleep(200);
			}
			CaptchaQueue.concurrentDictionary_1[this.string_0] = true;
		}

		// Token: 0x04000022 RID: 34
		public WebView webView_0;

		// Token: 0x04000023 RID: 35
		public string string_0;

		// Token: 0x04000024 RID: 36
		public CaptchaQueue.Class2 class2_0;
	}
}
