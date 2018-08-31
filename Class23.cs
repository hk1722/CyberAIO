using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EO.WebBrowser;
using wyDay.Controls;

// Token: 0x0200002E RID: 46
internal sealed class Class23
{
	// Token: 0x06000127 RID: 295 RVA: 0x0000DC78 File Offset: 0x0000BE78
	public static void smethod_0()
	{
		Class23.automaticUpdaterBackend_0 = new AutomaticUpdaterBackend
		{
			GUID = "CyberAIO-Cybersole",
			wyUpdateCommandline = string.Format(" -password = '{0}'", Class168.string_3),
			UpdateType = UpdateType.OnlyCheck,
			wyUpdateLocation = "wyUpdate.exe"
		};
		Class23.automaticUpdaterBackend_0.ReadyToBeInstalled += Class23.smethod_5;
		Class23.automaticUpdaterBackend_0.CheckingFailed += Class23.smethod_1;
		Class23.automaticUpdaterBackend_0.UpToDate += Class23.smethod_3;
		Class23.automaticUpdaterBackend_0.UpdateAvailable += Class23.smethod_4;
		Class23.automaticUpdaterBackend_0.ProgressChanged += Class23.smethod_2;
		Class23.automaticUpdaterBackend_0.DownloadingFailed += Class23.smethod_1;
		Class23.automaticUpdaterBackend_0.ExtractingFailed += Class23.smethod_1;
		Class23.automaticUpdaterBackend_0.UpdateFailed += Class23.smethod_1;
		Class23.automaticUpdaterBackend_0.UpdateSuccessful += Class23.smethod_3;
		Class23.automaticUpdaterBackend_0.ReadyToBeInstalled += Class23.smethod_5;
		Class23.automaticUpdaterBackend_0.Initialize();
		Class23.automaticUpdaterBackend_0.AppLoaded();
	}

	// Token: 0x06000128 RID: 296 RVA: 0x00003780 File Offset: 0x00001980
	private static void smethod_1(object object_0, FailArgs failArgs_0)
	{
		MainWindow.webView_0.QueueScriptCall(string.Format("swal('{0}', '{1}', 'error')", failArgs_0.ErrorTitle.smethod_4(), failArgs_0.ErrorMessage.smethod_4()));
	}

	// Token: 0x06000129 RID: 297 RVA: 0x0000DDB4 File Offset: 0x0000BFB4
	private static void smethod_2(object object_0, int int_1)
	{
		if ((Class23.int_0 != int_1 || Class23.string_0 != Class23.automaticUpdaterBackend_0.UpdateStepOn.ToString()) && Class23.automaticUpdaterBackend_0.UpdateStepOn != UpdateStepOn.Checking)
		{
			MainWindow.webView_0.QueueScriptCall(string.Format("swal('{0}...', 'Progress: {1}%\\n\\nPlease do not close the bot.', 'info', {{buttons:{{visible: false}}, closeOnClickOutside:false}})", Class23.automaticUpdaterBackend_0.UpdateStepOn.ToString().Replace("Update", " Update"), int_1.ToString()));
			Class23.int_0 = int_1;
			Class23.string_0 = Class23.automaticUpdaterBackend_0.UpdateStepOn.ToString();
		}
	}

	// Token: 0x0600012A RID: 298 RVA: 0x000037AD File Offset: 0x000019AD
	private static void smethod_3(object object_0, SuccessArgs successArgs_0)
	{
		if (Class23.bool_0)
		{
			MainWindow.webView_0.QueueScriptCall("swal('Up To Date', 'Your are on the latest version!', 'success', {buttons:false, timer: 2000})");
		}
	}

	// Token: 0x0600012B RID: 299 RVA: 0x0000DE60 File Offset: 0x0000C060
	private static void smethod_4(object sender, EventArgs e)
	{
		if (Class23.automaticUpdaterBackend_0.Version != null)
		{
			if (DateTime.UtcNow > Licenser.dateTime_0)
			{
				MainWindow.webView_0.QueueScriptCall("swal({ title:'License Expired', text:'An update is available but your license has expired. Would you like to renew now?', icon:'info', buttons: { cancel: { text: 'No', value: false, visible: true, className: '', closeModal: true, }, confirm: { text: 'Yes', value: true, visible: true, className: '', closeModal: false } } }).then((renew) => { if (renew) { Renew(); } });");
				return;
			}
			MainWindow.webView_0.QueueScriptCall(string.Format("var changes = document.createElement('textarea'); changes.classList.add('form-control-textarea'); changes.style = 'box-shadow: 1px 1px 20px #0e1111'; changes.rows = {0}; changes.disabled = true; changes.innerHTML = '{1}'; swal({{ title: 'Update Available', text: 'Version {2} is available, would you like to download it?', content: changes, icon: 'info', buttons: ['No', 'Yes'], }}).then((update) => {{ if (update) {{ StartUpdate(); }} }});", Class23.automaticUpdaterBackend_0.Changes.Split(new char[]
			{
				'\n'
			}).Length, Class23.automaticUpdaterBackend_0.Changes.smethod_4(), Class23.automaticUpdaterBackend_0.Version));
		}
	}

	// Token: 0x0600012C RID: 300 RVA: 0x000037C6 File Offset: 0x000019C6
	private static void smethod_5(object sender, EventArgs e)
	{
		if (Class23.automaticUpdaterBackend_0.UpdateStepOn == UpdateStepOn.UpdateReadyToInstall || Class23.automaticUpdaterBackend_0.UpdateStepOn == UpdateStepOn.UpdateDownloaded)
		{
			Class23.automaticUpdaterBackend_0.InstallNow();
		}
	}

	// Token: 0x0600012D RID: 301 RVA: 0x000037EC File Offset: 0x000019EC
	public static void smethod_6(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		new Task(new Action(new Class23.Class25
		{
			object_0 = object_0
		}.method_0)).Start();
	}

	// Token: 0x0600012E RID: 302 RVA: 0x0000380F File Offset: 0x00001A0F
	public static void smethod_7(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		Class23.bool_0 = (object_0 != null);
		Class23.automaticUpdaterBackend_0.ForceCheckForUpdate(true);
	}

	// Token: 0x0600012F RID: 303 RVA: 0x00003826 File Offset: 0x00001A26
	public static void smethod_8(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		Class23.automaticUpdaterBackend_0.InstallNow();
	}

	// Token: 0x06000130 RID: 304 RVA: 0x0000DEEC File Offset: 0x0000C0EC
	public static void smethod_9(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		GClass0.smethod_2();
		MethodInvoker method = new MethodInvoker(Class23.Class24.class24_0.method_0);
		MainWindow.mainWindow_0.BeginInvoke(method, null);
		Class23.automaticUpdaterBackend_0.InstallNow();
	}

	// Token: 0x06000131 RID: 305 RVA: 0x0000DF38 File Offset: 0x0000C138
	public static void smethod_10(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		new Process
		{
			StartInfo = new ProcessStartInfo
			{
				WindowStyle = ProcessWindowStyle.Hidden,
				FileName = "cmd.exe",
				Arguments = string.Format("/C wyUpdate.exe -password:'{0}'", Class168.string_3)
			}
		}.Start();
		MainWindow.mainWindow_0.method_9(null, null);
	}

	// Token: 0x06000132 RID: 306 RVA: 0x0000DF90 File Offset: 0x0000C190
	public static async void smethod_11(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		if (Class168.form_0 == null)
		{
			Class168.dateTime_0 = Licenser.dateTime_0;
			Dictionary<string, string> dictionary = Class70.smethod_1();
			dictionary["hosted_button_id"] = Class168.string_4;
			dictionary["cmd"] = "_s-xclick";
			dictionary["on0"] = "License Key";
			dictionary["os0"] = GClass0.string_2;
			TaskAwaiter<HttpResponseMessage> taskAwaiter = new Class70(null, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.181 Safari/537.36", 10, false, true, null, false).method_8("https://www.paypal.com/cgi-bin/webscr", dictionary, false).GetAwaiter();
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter<HttpResponseMessage> taskAwaiter2;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
			}
			Class168.form_0 = new Renewal(taskAwaiter.GetResult().Headers.Location.ToString());
			Class168.form_0.Show();
			MainWindow.webView_0.QueueScriptCall("swal('PayPal Opened', 'A PayPal browser has appeared, please complete the payment.', 'success', {timer: 3000})");
		}
		else
		{
			Class168.form_0.WindowState = FormWindowState.Normal;
			Class168.form_0.BringToFront();
		}
	}

	// Token: 0x0400009A RID: 154
	public static AutomaticUpdaterBackend automaticUpdaterBackend_0;

	// Token: 0x0400009B RID: 155
	public static int int_0 = 0;

	// Token: 0x0400009C RID: 156
	public static string string_0 = string.Empty;

	// Token: 0x0400009D RID: 157
	public static bool bool_0 = false;

	// Token: 0x0200002F RID: 47
	[Serializable]
	private sealed class Class24
	{
		// Token: 0x06000135 RID: 309 RVA: 0x0000383E File Offset: 0x00001A3E
		internal void method_0()
		{
			MainWindow.mainWindow_0.Hide();
			MainWindow.webView_0.Close(true);
		}

		// Token: 0x0400009E RID: 158
		public static readonly Class23.Class24 class24_0 = new Class23.Class24();

		// Token: 0x0400009F RID: 159
		public static MethodInvoker methodInvoker_0;
	}

	// Token: 0x02000030 RID: 48
	private sealed class Class25
	{
		// Token: 0x06000137 RID: 311 RVA: 0x0000DFC4 File Offset: 0x0000C1C4
		internal void method_0()
		{
			try
			{
				if (this.object_0 == null)
				{
					Thread.Sleep(2000);
				}
				Process process = new Process();
				process.StartInfo = new ProcessStartInfo
				{
					WindowStyle = ProcessWindowStyle.Hidden,
					FileName = "cmd.exe",
					Arguments = "/C wyUpdate.exe /quickcheck /justcheck /noerr"
				};
				process.Start();
				process.WaitForExit(20000);
				int exitCode = process.ExitCode;
				if (exitCode == 2)
				{
					if (DateTime.UtcNow > Licenser.dateTime_0)
					{
						MainWindow.webView_0.QueueScriptCall("swal({ title:'License Expired', text:'An update is available but your license has expired. Would you like to renew now?', icon:'info', buttons: { cancel: { text: 'No', value: false, visible: true, className: '', closeModal: true, }, confirm: { text: 'Yes', value: true, visible: true, className: '', closeModal: false } } }).then((renew) => { if (renew) { Renew(); } });");
					}
					else
					{
						MainWindow.webView_0.QueueScriptCall("swal({ title: 'Update Available', text: 'An update is available, would you like to install it?', icon: 'info', buttons: ['No', 'Yes'], }).then((update) => { if (update) { StartUpdate(); } });");
					}
				}
				else if (exitCode == 1)
				{
					MainWindow.webView_0.QueueScriptCall("swal('Error', 'There was an error checking for updates. Please check your connection and try again', 'error')");
				}
				else if (this.object_0 != null)
				{
					MainWindow.webView_0.QueueScriptCall("swal('Up To Date', 'Your are already on the latest version!', 'success', {buttons:false, timer: 2000})");
				}
			}
			catch
			{
				MainWindow.webView_0.QueueScriptCall("swal('Error', 'There was an error checking for updates. Please check your connection and try again', 'error')");
			}
		}

		// Token: 0x040000A0 RID: 160
		public object object_0;
	}

	// Token: 0x02000031 RID: 49
	[StructLayout(LayoutKind.Auto)]
	private struct Struct1 : IAsyncStateMachine
	{
		// Token: 0x06000138 RID: 312 RVA: 0x0000E0B8 File Offset: 0x0000C2B8
		void IAsyncStateMachine.MoveNext()
		{
			int num = this.int_0;
			try
			{
				TaskAwaiter<HttpResponseMessage> awaiter;
				if (num != 0)
				{
					if (Class168.form_0 != null)
					{
						Class168.form_0.WindowState = FormWindowState.Normal;
						Class168.form_0.BringToFront();
						goto IL_123;
					}
					Class168.dateTime_0 = Licenser.dateTime_0;
					Dictionary<string, string> dictionary = Class70.smethod_1();
					dictionary["hosted_button_id"] = Class168.string_4;
					dictionary["cmd"] = "_s-xclick";
					dictionary["on0"] = "License Key";
					dictionary["os0"] = GClass0.string_2;
					awaiter = new Class70(null, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.181 Safari/537.36", 10, false, true, null, false).method_8("https://www.paypal.com/cgi-bin/webscr", dictionary, false).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						this.int_0 = 0;
						this.taskAwaiter_0 = awaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class23.Struct1>(ref awaiter, ref this);
						return;
					}
				}
				else
				{
					awaiter = this.taskAwaiter_0;
					this.taskAwaiter_0 = default(TaskAwaiter<HttpResponseMessage>);
					this.int_0 = -1;
				}
				Class168.form_0 = new Renewal(awaiter.GetResult().Headers.Location.ToString());
				Class168.form_0.Show();
				MainWindow.webView_0.QueueScriptCall("swal('PayPal Opened', 'A PayPal browser has appeared, please complete the payment.', 'success', {timer: 3000})");
				IL_123:;
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

		// Token: 0x06000139 RID: 313 RVA: 0x00003855 File Offset: 0x00001A55
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncVoidMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040000A1 RID: 161
		public int int_0;

		// Token: 0x040000A2 RID: 162
		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		// Token: 0x040000A3 RID: 163
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;
	}
}
