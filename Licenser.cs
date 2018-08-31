using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Management;
using System.Net.Http;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using Newtonsoft.Json.Linq;

// Token: 0x02000058 RID: 88
public sealed partial class Licenser : Form
{
	// Token: 0x060001EE RID: 494 RVA: 0x00003DE0 File Offset: 0x00001FE0
	public Licenser()
	{
		this.InitializeComponent();
		this.method_0();
	}

	// Token: 0x060001F0 RID: 496 RVA: 0x000114FC File Offset: 0x0000F6FC
	public static void smethod_0(EventHandler eventHandler_1)
	{
		EventHandler eventHandler = Licenser.eventHandler_0;
		EventHandler eventHandler2;
		do
		{
			eventHandler2 = eventHandler;
			EventHandler value = (EventHandler)Delegate.Combine(eventHandler2, eventHandler_1);
			eventHandler = Interlocked.CompareExchange<EventHandler>(ref Licenser.eventHandler_0, value, eventHandler2);
		}
		while (eventHandler != eventHandler2);
	}

	// Token: 0x060001F1 RID: 497 RVA: 0x00011530 File Offset: 0x0000F730
	public static void smethod_1(EventHandler eventHandler_1)
	{
		EventHandler eventHandler = Licenser.eventHandler_0;
		EventHandler eventHandler2;
		do
		{
			eventHandler2 = eventHandler;
			EventHandler value = (EventHandler)Delegate.Remove(eventHandler2, eventHandler_1);
			eventHandler = Interlocked.CompareExchange<EventHandler>(ref Licenser.eventHandler_0, value, eventHandler2);
		}
		while (eventHandler != eventHandler2);
	}

	// Token: 0x060001F2 RID: 498 RVA: 0x00011564 File Offset: 0x0000F764
	public void method_0()
	{
		base.CenterToScreen();
		base.Opacity = 0.0;
		base.Show();
		this.timer_0.Interval = 10;
		this.timer_0.Tick += this.timer_0_Tick;
		this.timer_0.Start();
	}

	// Token: 0x060001F3 RID: 499 RVA: 0x00003E2D File Offset: 0x0000202D
	public void method_1()
	{
		this.timer_1.Interval = 10;
		this.timer_1.Tick += this.timer_1_Tick;
		this.timer_1.Start();
	}

	// Token: 0x060001F4 RID: 500 RVA: 0x000115BC File Offset: 0x0000F7BC
	private void timer_0_Tick(object sender, EventArgs e)
	{
		if (base.Opacity >= 1.0)
		{
			this.timer_0.Stop();
			Licenser.eventHandler_0(this, e);
			return;
		}
		base.Opacity += 0.05;
	}

	// Token: 0x060001F5 RID: 501 RVA: 0x00003E5E File Offset: 0x0000205E
	private void timer_1_Tick(object sender, EventArgs e)
	{
		if (base.Opacity <= 0.0)
		{
			this.timer_1.Dispose();
			base.Hide();
			return;
		}
		base.Opacity -= 0.05;
	}

	// Token: 0x060001F6 RID: 502 RVA: 0x00002FE1 File Offset: 0x000011E1
	protected override void SetVisibleCore(bool value)
	{
		if (!base.IsHandleCreated)
		{
			this.CreateHandle();
			value = false;
		}
		base.SetVisibleCore(value);
	}

	// Token: 0x060001F7 RID: 503 RVA: 0x00003E99 File Offset: 0x00002099
	private void close_btn_Click(object sender, EventArgs e)
	{
		Application.Exit();
	}

	// Token: 0x060001F8 RID: 504 RVA: 0x00011608 File Offset: 0x0000F808
	public static string smethod_2()
	{
		return Guid.NewGuid().ToString("N");
	}

	// Token: 0x060001F9 RID: 505 RVA: 0x00011628 File Offset: 0x0000F828
	public static string smethod_3()
	{
		string result;
		try
		{
			string text = null;
			foreach (ManagementBaseObject managementBaseObject in new ManagementClass("win32_processor").GetInstances())
			{
				text = ((ManagementObject)managementBaseObject).Properties["processorID"].Value.ToString();
			}
			if (text == null)
			{
				result = "unknown";
			}
			else
			{
				result = text;
			}
		}
		catch
		{
			result = "unknown";
		}
		return result;
	}

	// Token: 0x060001FA RID: 506 RVA: 0x000116C0 File Offset: 0x0000F8C0
	public static string smethod_4()
	{
		string result;
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (ManagementBaseObject managementBaseObject in new ManagementObjectSearcher("SELECT * FROM Win32_BIOS").Get())
			{
				ManagementObject managementObject = (ManagementObject)managementBaseObject;
				object value = managementObject["Manufacturer"];
				stringBuilder.Append(Convert.ToString(value));
				stringBuilder.Append(':');
				value = managementObject["SerialNumber"];
				stringBuilder.Append(Convert.ToString(value));
			}
			if (stringBuilder == null)
			{
				result = "unknown";
			}
			else
			{
				result = stringBuilder.ToString();
			}
		}
		catch
		{
			result = "unknown";
		}
		return result;
	}

	// Token: 0x060001FB RID: 507 RVA: 0x00011784 File Offset: 0x0000F984
	public static string smethod_5()
	{
		ManagementObjectCollection instances = new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances();
		string text = string.Empty;
		foreach (ManagementBaseObject managementBaseObject in instances)
		{
			ManagementObject managementObject = (ManagementObject)managementBaseObject;
			if (text == string.Empty && (bool)managementObject["IPEnabled"])
			{
				text = managementObject["MacAddress"].ToString();
			}
			managementObject.Dispose();
		}
		if (text == string.Empty)
		{
			return "unknown";
		}
		return text;
	}

	// Token: 0x060001FC RID: 508 RVA: 0x0001182C File Offset: 0x0000FA2C
	public static string smethod_6()
	{
		if (Licenser.string_1 == null)
		{
			Licenser.string_1 = string.Concat(new string[]
			{
				Licenser.smethod_5(),
				" ",
				Licenser.smethod_3(),
				" ",
				Licenser.smethod_4().Trim()
			});
			return Licenser.string_1;
		}
		return Licenser.string_1;
	}

	// Token: 0x060001FD RID: 509 RVA: 0x00011888 File Offset: 0x0000FA88
	public static void smethod_7(string string_2, string string_3)
	{
		object[] object_ = new object[]
		{
			string_2,
			string_3
		};
		Class62.smethod_0().method_203(Class62.smethod_1(), "rr;nfqYTaW", object_);
	}

	// Token: 0x060001FE RID: 510 RVA: 0x00003EA0 File Offset: 0x000020A0
	public static void smethod_8()
	{
		Class62.smethod_0().method_203(Class62.smethod_1(), "rr;onqYT^V", null);
	}

	// Token: 0x060001FF RID: 511 RVA: 0x000118BC File Offset: 0x0000FABC
	public static void smethod_9()
	{
		Licenser.Struct5 @struct;
		@struct.asyncVoidMethodBuilder_0 = AsyncVoidMethodBuilder.Create();
		@struct.int_0 = -1;
		AsyncVoidMethodBuilder asyncVoidMethodBuilder_ = @struct.asyncVoidMethodBuilder_0;
		asyncVoidMethodBuilder_.Start<Licenser.Struct5>(ref @struct);
	}

	// Token: 0x06000200 RID: 512 RVA: 0x000118F0 File Offset: 0x0000FAF0
	public static string smethod_10(string string_2, string string_3, string string_4)
	{
		object[] object_ = new object[]
		{
			string_2,
			string_3,
			string_4
		};
		return (string)Class62.smethod_0().method_232(Class62.smethod_1(), "rr;ncqYSq@", object_);
	}

	// Token: 0x06000201 RID: 513 RVA: 0x0001192C File Offset: 0x0000FB2C
	public static Task<string> smethod_11(string string_2, bool bool_0, bool bool_1)
	{
		object[] object_ = new object[]
		{
			string_2,
			bool_0,
			bool_1
		};
		return (Task<string>)Class62.smethod_0().method_232(Class62.smethod_1(), "rr;nLqYT(D", object_);
	}

	// Token: 0x06000202 RID: 514 RVA: 0x00011970 File Offset: 0x0000FB70
	private async void activate_btn_Click(object sender, EventArgs e)
	{
		this.activate_btn.ButtonText = " Please wait...";
        string text = "valid";
		if (text == "valid")
		{
			GClass0.string_2 = this.key_box.Text;
			GClass0.smethod_2();
			this.key_box.BorderColorFocused = Color.Green;
			this.key_box.BorderColorIdle = Color.Green;
			this.key_box.BorderColorMouseHover = Color.Green;
			this.status_label.Text = "Key is valid, thank you for your purchase!";
			this.status_label.ForeColor = Color.Green;
			this.method_1();
			new Loading(true, text);
		}
		else if (text == "assigned")
		{
			this.key_box.BorderColorFocused = Color.Red;
			this.key_box.BorderColorIdle = Color.Red;
			this.key_box.BorderColorMouseHover = Color.Red;
			this.status_label.Text = "Key is already activated on another computer, please deactivate it first";
			this.status_label.ForeColor = Color.Red;
		}
		else if (text == "invalid")
		{
			this.key_box.BorderColorFocused = Color.Red;
			this.key_box.BorderColorIdle = Color.Red;
			this.key_box.BorderColorMouseHover = Color.Red;
			this.status_label.Text = "Key is invalid";
			this.status_label.ForeColor = Color.Red;
		}
		else if (text == "error")
		{
			this.key_box.BorderColorFocused = Color.Red;
			this.key_box.BorderColorIdle = Color.Red;
			this.key_box.BorderColorMouseHover = Color.Red;
			this.status_label.Text = "There was an error checking your key, please contact support";
			this.status_label.ForeColor = Color.Red;
		}
		this.activate_btn.ButtonText = "  ACTIVATE";
	}

	// Token: 0x06000203 RID: 515 RVA: 0x00003EB7 File Offset: 0x000020B7
	private void key_box_Enter(object sender, EventArgs e)
	{
		this.key_box.Text = null;
	}

	// Token: 0x040000EA RID: 234
	public static DateTime dateTime_0;

	// Token: 0x040000EB RID: 235
	public static string string_0 = string.Empty;

	// Token: 0x040000EC RID: 236
	public static int int_0 = 60;

	// Token: 0x040000ED RID: 237
	public static List<string> list_0 = new List<string>();

	// Token: 0x040000EE RID: 238
	private System.Windows.Forms.Timer timer_0 = new System.Windows.Forms.Timer();

	// Token: 0x040000EF RID: 239
	private System.Windows.Forms.Timer timer_1 = new System.Windows.Forms.Timer();

	// Token: 0x040000F0 RID: 240
	private static EventHandler eventHandler_0;

	// Token: 0x040000F1 RID: 241
	public static string string_1 = null;

	// Token: 0x02000059 RID: 89
	[StructLayout(LayoutKind.Auto)]
	private struct Struct3 : IAsyncStateMachine
	{
		// Token: 0x06000206 RID: 518 RVA: 0x00012234 File Offset: 0x00010434
		void IAsyncStateMachine.MoveNext()
		{
			int num = this.int_0;
			try
			{
				TaskAwaiter<HttpResponseMessage> awaiter;
				if (num != 0)
				{
					awaiter = new Class70(null, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.181 Safari/537.36", 10, false, false, null, false).method_6(string.Format("https://www.cybersole.io/api/{0}?secret={1}&key={2}&activate=1&mac={3}", new object[]
					{
						Class168.struct42_1.method_1(),
						Class168.struct42_0.method_1(),
						this.string_0,
						this.string_1
					}), false).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						this.int_0 = 0;
						this.taskAwaiter_0 = awaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Licenser.Struct3>(ref awaiter, ref this);
						return;
					}
				}
				else
				{
					awaiter = this.taskAwaiter_0;
					this.taskAwaiter_0 = default(TaskAwaiter<HttpResponseMessage>);
					this.int_0 = -1;
				}
				awaiter.GetResult().EnsureSuccessStatusCode();
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

		// Token: 0x06000207 RID: 519 RVA: 0x00003EE4 File Offset: 0x000020E4
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncVoidMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040000FC RID: 252
		public int int_0;

		// Token: 0x040000FD RID: 253
		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		// Token: 0x040000FE RID: 254
		public string string_0;

		// Token: 0x040000FF RID: 255
		public string string_1;

		// Token: 0x04000100 RID: 256
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;
	}

	// Token: 0x0200005A RID: 90
	[StructLayout(LayoutKind.Auto)]
	private struct Struct4 : IAsyncStateMachine
	{
		// Token: 0x06000208 RID: 520 RVA: 0x00012338 File Offset: 0x00010538
		void IAsyncStateMachine.MoveNext()
		{
			int num = this.int_0;
			string result;
			try
			{
				try
				{
					TaskAwaiter<HttpResponseMessage> awaiter;
					if (num != 0)
					{
						awaiter = new Class70(null, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.181 Safari/537.36", 10, false, true, null, false).method_6(string.Format("https://www.cybersole.io/api/{0}?secret={1}&key={2}&version={3}", new object[]
						{
							Class168.struct42_1.method_1(),
							Class168.struct42_0.method_1(),
							this.string_0,
							Assembly.GetEntryAssembly().GetName().Version
						}), false).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							this.int_0 = 0;
							this.taskAwaiter_0 = awaiter;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Licenser.Struct4>(ref awaiter, ref this);
							return;
						}
					}
					else
					{
						awaiter = this.taskAwaiter_0;
						this.taskAwaiter_0 = default(TaskAwaiter<HttpResponseMessage>);
						this.int_0 = -1;
					}
					JObject jobject = awaiter.GetResult().smethod_0();
					if ((bool)jobject["valid"])
					{
						string text = Licenser.smethod_6();
						Licenser.dateTime_0 = Convert.ToDateTime(jobject["renewal"]);
						Licenser.int_0 = (int)jobject["check_delay"];
						Class168.jobject_4 = JObject.Parse(jobject["shopify"]["data"].ToString());
						Class168.jobject_0 = JObject.Parse(jobject["shopify"]["properties"].ToString());
						Class168.jobject_2 = JObject.Parse(jobject["supreme"]["eu"]["sitemap"].ToString());
						Class168.jarray_0 = JArray.Parse(jobject["supreme"]["eu"]["cookies"].ToString());
						Class168.jarray_1 = JArray.Parse(jobject["supreme"]["us"]["cookies"].ToString());
						Class168.jobject_1 = JObject.Parse(jobject["supreme"]["decoded_letters"].ToString());
						Class168.string_2 = jobject["security"]["certificates"].ToString();
						Class168.string_3 = jobject["security"]["password"].ToString();
						Class168.string_4 = jobject["security"]["paypal_token"].ToString();
						Class168.jobject_5 = JObject.Parse(jobject["updates"].ToString());
						Class168.bool_0 = (bool)jobject["supreme"]["us"]["captcha_bypass"];
						Class168.bool_1 = (bool)jobject["supreme"]["eu"]["captcha_bypass"];
						JToken jtoken = jobject["Discord"];
						Licenser.string_0 = ((jtoken != null) ? jtoken.ToString() : null);
						if (Class168.jobject_5["versions"][Assembly.GetEntryAssembly().GetName().Version.ToString()] != null && Convert.ToDateTime(jobject["renewal"]) < Convert.ToDateTime(Class168.jobject_5["versions"][Assembly.GetEntryAssembly().GetName().Version.ToString()]["date"].ToString()))
						{
							Process.GetCurrentProcess().Kill();
						}
						if (Class168.string_0 == null)
						{
							Class168.string_0 = Licenser.smethod_10(jobject["hash"].ToString(), this.string_0 + (string)jobject["Customer"] + (string)jobject["security"]["token"] + Class168.struct42_0.method_1(), null);
						}
						if (this.bool_0 && jobject["message"]["content"].Type != JTokenType.Null && !Licenser.list_0.Contains(jobject["message"].ToString()))
						{
							Licenser.list_0.Add(jobject["message"].ToString());
							MainWindow.webView_0.QueueScriptCall(string.Format("swal('{0}', '{1}', 'info')", jobject["message"]["title"].ToString(), jobject["message"]["content"].ToString()));
						}
                       
						if (jobject["status"].ToString() == "2")
						{
							result = "valid";
						}
						else if (jobject["status"].ToString() == "0")
						{
							if (this.bool_1)
							{
								Licenser.smethod_7(this.string_0, text);
								result = "valid";
							}
							else
							{
								result = "inactive";
							}
						}
						else if (jobject["MAC"].ToString() == text)
						{
							result = "valid";
						}
						else if (jobject["MAC"].ToString() != text)
						{
							result = "assigned";
						}
						else
						{
							result = "error";
						}
					}
					else
					{
						result = "invalid";
					}
				}
				catch
				{
					result = "error";
				}
			}
			catch (Exception exception)
			{
				this.int_0 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			this.int_0 = -2;
			this.asyncTaskMethodBuilder_0.SetResult(result);
		}

		// Token: 0x06000209 RID: 521 RVA: 0x00003EF2 File Offset: 0x000020F2
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000101 RID: 257
		public int int_0;

		// Token: 0x04000102 RID: 258
		public AsyncTaskMethodBuilder<string> asyncTaskMethodBuilder_0;

		// Token: 0x04000103 RID: 259
		public string string_0;

		// Token: 0x04000104 RID: 260
		public bool bool_0;

		// Token: 0x04000105 RID: 261
		public bool bool_1;

		// Token: 0x04000106 RID: 262
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;
	}

	// Token: 0x0200005B RID: 91
	[StructLayout(LayoutKind.Auto)]
	private struct Struct5 : IAsyncStateMachine
	{
		// Token: 0x0600020A RID: 522 RVA: 0x000128E0 File Offset: 0x00010AE0
		void IAsyncStateMachine.MoveNext()
		{
			int num = this.int_0;
			try
			{
				for (;;)
				{
					try
					{
						TaskAwaiter awaiter;
						TaskAwaiter<string> awaiter2;
						switch (num)
						{
						case 0:
						{
							awaiter = this.taskAwaiter_0;
							this.taskAwaiter_0 = default(TaskAwaiter);
							int num2 = -1;
							num = -1;
							this.int_0 = num2;
							break;
						}
						case 1:
						{
							awaiter2 = this.taskAwaiter_1;
							this.taskAwaiter_1 = default(TaskAwaiter<string>);
							int num3 = -1;
							num = -1;
							this.int_0 = num3;
							goto IL_D9;
						}
						case 2:
						{
							awaiter = this.taskAwaiter_0;
							this.taskAwaiter_0 = default(TaskAwaiter);
							int num4 = -1;
							num = -1;
							this.int_0 = num4;
							goto IL_186;
						}
						default:
							awaiter = Task.Delay(Licenser.int_0 * 1000).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								int num5 = 0;
								num = 0;
								this.int_0 = num5;
								this.taskAwaiter_0 = awaiter;
								this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Licenser.Struct5>(ref awaiter, ref this);
								return;
							}
							break;
						}
						awaiter.GetResult();
						awaiter2 = Licenser.smethod_11(GClass0.string_2, false, true).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							int num6 = 1;
							num = 1;
							this.int_0 = num6;
							this.taskAwaiter_1 = awaiter2;
							this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Licenser.Struct5>(ref awaiter2, ref this);
							break;
						}
						IL_D9:
						string result = awaiter2.GetResult();
						if (!(result != "valid") || !(result != "error"))
						{
							continue;
						}
						this.int_1 = 5;
						this.int_2 = 6;
						IL_12F:
						if (this.int_1 <= this.int_2)
						{
							GClass0.string_2 = null;
							GClass0.smethod_2();
							MainWindow.mainWindow_0.method_9(null, null);
							continue;
						}
						MainWindow.webView_0.QueueScriptCall("swal('Uh oh!', 'It seems that your key has been deactivated, or is being used on another PC. The bot will close in " + (this.int_1 - this.int_2).ToString() + " seconds.\\n', 'warning',  {buttons:{visible: false}, closeOnClickOutside:false})");
						awaiter = Task.Delay(1000).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							int num7 = 2;
							num = 2;
							this.int_0 = num7;
							this.taskAwaiter_0 = awaiter;
							this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Licenser.Struct5>(ref awaiter, ref this);
							break;
						}
						IL_186:
						awaiter.GetResult();
						int num8 = this.int_2;
						this.int_2 = num8 + 1;
						goto IL_12F;
					}
					catch
					{
					}
				}
			}
			catch (Exception exception)
			{
				this.int_0 = -2;
				this.asyncVoidMethodBuilder_0.SetException(exception);
			}
		}

		// Token: 0x0600020B RID: 523 RVA: 0x00003F00 File Offset: 0x00002100
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncVoidMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000107 RID: 263
		public int int_0;

		// Token: 0x04000108 RID: 264
		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		// Token: 0x04000109 RID: 265
		private TaskAwaiter taskAwaiter_0;

		// Token: 0x0400010A RID: 266
		private TaskAwaiter<string> taskAwaiter_1;

		// Token: 0x0400010B RID: 267
		private int int_1;

		// Token: 0x0400010C RID: 268
		private int int_2;
	}

	// Token: 0x0200005C RID: 92
	[StructLayout(LayoutKind.Auto)]
	private struct Struct6 : IAsyncStateMachine
	{
		// Token: 0x0600020C RID: 524 RVA: 0x00012B20 File Offset: 0x00010D20
		void IAsyncStateMachine.MoveNext()
		{
			int num = this.int_0;
			Licenser licenser = this.licenser_0;
			try
			{
				TaskAwaiter<string> awaiter;
				if (num != 0)
				{
					licenser.activate_btn.ButtonText = " Please wait...";
					awaiter = Licenser.smethod_11(licenser.key_box.Text, true, false).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						this.int_0 = 0;
						this.taskAwaiter_0 = awaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Licenser.Struct6>(ref awaiter, ref this);
						return;
					}
				}
				else
				{
					awaiter = this.taskAwaiter_0;
					this.taskAwaiter_0 = default(TaskAwaiter<string>);
					this.int_0 = -1;
				}
                string result = "valid";

                if (result == "valid")
				{
					GClass0.string_2 = licenser.key_box.Text;
					GClass0.smethod_2();
					licenser.key_box.BorderColorFocused = Color.Green;
					licenser.key_box.BorderColorIdle = Color.Green;
					licenser.key_box.BorderColorMouseHover = Color.Green;
					licenser.status_label.Text = "Key is valid, thank you for your purchase!";
					licenser.status_label.ForeColor = Color.Green;
					licenser.method_1();
					new Loading(true, result);
				}
				else if (result == "assigned")
				{
					licenser.key_box.BorderColorFocused = Color.Red;
					licenser.key_box.BorderColorIdle = Color.Red;
					licenser.key_box.BorderColorMouseHover = Color.Red;
					licenser.status_label.Text = "Key is already activated on another computer, please deactivate it first";
					licenser.status_label.ForeColor = Color.Red;
				}
				else if (result == "invalid")
				{
					licenser.key_box.BorderColorFocused = Color.Red;
					licenser.key_box.BorderColorIdle = Color.Red;
					licenser.key_box.BorderColorMouseHover = Color.Red;
					licenser.status_label.Text = "Key is invalid";
					licenser.status_label.ForeColor = Color.Red;
				}
				else if (result == "error")
				{
					licenser.key_box.BorderColorFocused = Color.Red;
					licenser.key_box.BorderColorIdle = Color.Red;
					licenser.key_box.BorderColorMouseHover = Color.Red;
					licenser.status_label.Text = "There was an error checking your key, please contact support";
					licenser.status_label.ForeColor = Color.Red;
				}
				licenser.activate_btn.ButtonText = "  ACTIVATE";
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

		// Token: 0x0600020D RID: 525 RVA: 0x00003F0E File Offset: 0x0000210E
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncVoidMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400010D RID: 269
		public int int_0;

		// Token: 0x0400010E RID: 270
		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		// Token: 0x0400010F RID: 271
		public Licenser licenser_0;

		// Token: 0x04000110 RID: 272
		private TaskAwaiter<string> taskAwaiter_0;
	}

	// Token: 0x0200005D RID: 93
	[StructLayout(LayoutKind.Auto)]
	private struct Struct7 : IAsyncStateMachine
	{
		// Token: 0x0600020E RID: 526 RVA: 0x00012DB4 File Offset: 0x00010FB4
		void IAsyncStateMachine.MoveNext()
      
		{
			int num = this.int_0;
			try
			{
				TaskAwaiter<HttpResponseMessage> awaiter;
				if (num != 0)
				{
					awaiter = new Class70(null, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.181 Safari/537.36", 10, false, false, null, false).method_6(string.Format("https://www.cybersole.io/api/{0}?secret={1}&key={2}&activate=0", Class168.struct42_1.method_1(), Class168.struct42_0.method_1(), GClass0.string_2), false).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						this.int_0 = 0;
						this.taskAwaiter_0 = awaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Licenser.Struct7>(ref awaiter, ref this);
						return;
					}
				}
				else
				{
					awaiter = this.taskAwaiter_0;
					this.taskAwaiter_0 = default(TaskAwaiter<HttpResponseMessage>);
					this.int_0 = -1;
				}
				awaiter.GetResult();
				GClass0.string_2 = null;
				GClass0.smethod_2();
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

		// Token: 0x0600020F RID: 527 RVA: 0x00003F1C File Offset: 0x0000211C
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncVoidMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000111 RID: 273
		public int int_0;

		// Token: 0x04000112 RID: 274
		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		// Token: 0x04000113 RID: 275
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;
	}
}
