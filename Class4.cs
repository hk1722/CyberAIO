using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Media;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json.Linq;

// Token: 0x0200000D RID: 13
internal sealed class Class4
{
	// Token: 0x06000041 RID: 65 RVA: 0x000088B4 File Offset: 0x00006AB4
	public Class4(JToken jtoken_2)
	{
		this.jtoken_1 = jtoken_2;
		this.string_2 = jtoken_2["size"].ToString();
		MainWindow.dictionary_0[(int)jtoken_2["id"]]["product"] = string.Empty;
		this.method_4("Initialising...", "#c2c2c2", true, false);
	}

	// Token: 0x06000043 RID: 67 RVA: 0x0000892C File Offset: 0x00006B2C
	public void method_0(string string_3, string string_4, bool bool_2)
	{
		if (bool_2)
		{
			MainWindow.webView_0.QueueScriptCall(string.Format("updateButton({0},false)", this.jtoken_1["id"]));
		}
		this.method_4(string_3, string_4, true, true);
		this.bool_0 = true;
		Class30.smethod_1((int)this.jtoken_1["id"], null);
		Thread.CurrentThread.Abort();
	}

	// Token: 0x06000044 RID: 68 RVA: 0x00008998 File Offset: 0x00006B98
	public HttpResponseMessage method_1(string string_3, bool bool_2, JObject jobject_0)
	{
		return Class30.smethod_2(string_3, (int)this.jtoken_1["id"], jobject_0, bool_2);
	}

	// Token: 0x06000045 RID: 69 RVA: 0x00002E88 File Offset: 0x00001088
	public Task<HttpResponseMessage> method_2(string string_3, bool bool_2, JObject jobject_0)
	{
		Task<HttpResponseMessage> task = new Task<HttpResponseMessage>(new Func<HttpResponseMessage>(new Class4.Class5
		{
			string_0 = string_3,
			class4_0 = this,
			bool_0 = bool_2,
			jobject_0 = jobject_0
		}.method_0));
		task.Start();
		return task;
	}

	// Token: 0x06000046 RID: 70 RVA: 0x000089C4 File Offset: 0x00006BC4
	public bool method_3(out JToken jtoken_2)
	{
		bool result;
		try
		{
			jtoken_2 = JObject.Parse(MainWindow.webView_0.QueueScriptCall(string.Format("JSON.stringify(profiles['{0}'])", this.jtoken_1["profile"])).smethod_0());
			this.jtoken_0 = jtoken_2;
			result = true;
		}
		catch
		{
			jtoken_2 = null;
			result = false;
		}
		return result;
	}

	// Token: 0x06000047 RID: 71 RVA: 0x00008A28 File Offset: 0x00006C28
	public void method_4(string string_3, string string_4, bool bool_2, bool bool_3)
	{
		if (Class4.Class7.callSite_6 == null)
		{
			Class4.Class7.callSite_6 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Class4), new CSharpArgumentInfo[]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
			}));
		}
		Func<CallSite, object, bool> target = Class4.Class7.callSite_6.Target;
		CallSite callSite_ = Class4.Class7.callSite_6;
		bool flag;
		object obj;
		if (flag = MainWindow.dictionary_0.ContainsKey((int)this.jtoken_1["id"]))
		{
			if (Class4.Class7.callSite_1 == null)
			{
				Class4.Class7.callSite_1 = CallSite<Func<CallSite, bool, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, ExpressionType.And, typeof(Class4), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Func<CallSite, bool, object, object> target2 = Class4.Class7.callSite_1.Target;
			CallSite callSite_2 = Class4.Class7.callSite_1;
			bool arg = flag;
			if (Class4.Class7.callSite_0 == null)
			{
				Class4.Class7.callSite_0 = CallSite<Func<CallSite, object, bool, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(Class4), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
				}));
			}
			obj = target2(callSite_2, arg, Class4.Class7.callSite_0.Target(Class4.Class7.callSite_0, MainWindow.dictionary_0[(int)this.jtoken_1["id"]]["stop"], false));
		}
		else
		{
			obj = flag;
		}
		object obj2 = obj;
		if (Class4.Class7.callSite_3 == null)
		{
			Class4.Class7.callSite_3 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Class4), new CSharpArgumentInfo[]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
			}));
		}
		object obj3;
		if (!Class4.Class7.callSite_3.Target(Class4.Class7.callSite_3, obj2))
		{
			if (Class4.Class7.callSite_2 == null)
			{
				Class4.Class7.callSite_2 = CallSite<Func<CallSite, object, bool, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, ExpressionType.Or, typeof(Class4), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
				}));
			}
			obj3 = Class4.Class7.callSite_2.Target(Class4.Class7.callSite_2, obj2, bool_3);
		}
		else
		{
			obj3 = obj2;
		}
		object obj4 = obj3;
		if (Class4.Class7.callSite_5 == null)
		{
			Class4.Class7.callSite_5 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsFalse, typeof(Class4), new CSharpArgumentInfo[]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
			}));
		}
		object arg2;
		if (!Class4.Class7.callSite_5.Target(Class4.Class7.callSite_5, obj4))
		{
			if (Class4.Class7.callSite_4 == null)
			{
				Class4.Class7.callSite_4 = CallSite<Func<CallSite, object, bool, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, ExpressionType.And, typeof(Class4), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
				}));
			}
			arg2 = Class4.Class7.callSite_4.Target(Class4.Class7.callSite_4, obj4, !this.bool_0);
		}
		else
		{
			arg2 = obj4;
		}
		if (target(callSite_, arg2))
		{
			if (bool_2)
			{
				GClass3.smethod_0(string_3, "Task " + this.jtoken_1["id"]);
			}
			if (string_3.ToLower().Contains("error"))
			{
				string_4 = "red";
			}
			if (!this.bool_1)
			{
				MainWindow.webView_0.QueueScriptCall(string.Format("updateTable('{0}','{1}',{2},7)", string_3, string_4, this.jtoken_1["id"]));
				return;
			}
		}
		else
		{
			Thread.CurrentThread.Abort();
		}
	}

	// Token: 0x06000048 RID: 72 RVA: 0x00002EC1 File Offset: 0x000010C1
	public void method_5(string string_3)
	{
		MainWindow.webView_0.QueueScriptCall(string.Format("updateTable('{0}','#c2c2c2',{1},3)", string_3, this.jtoken_1["id"]));
		this.string_2 = string_3;
	}

	// Token: 0x06000049 RID: 73 RVA: 0x00008D3C File Offset: 0x00006F3C
	public string method_6()
	{
		string result;
		try
		{
			if (this.jtoken_1["proxy"].ToString() != "False")
			{
				result = this.jtoken_1["proxy"].ToString();
			}
			else
			{
				short num = Convert.ToInt16(MainWindow.webView_0.QueueScriptCall(string.Format("$('#row{0}').index()", this.jtoken_1["id"])).smethod_0());
				JArray jarray_ = GClass0.jarray_0;
				if ((int)num > jarray_.Count<JToken>() - 1)
				{
					MainWindow.webView_0.QueueScriptCall(string.Format("updateTable('none','#c2c2c2',{0},6)", this.jtoken_1["id"]));
					result = null;
				}
				else
				{
					string text = jarray_[(int)num]["proxy"].ToString();
					MainWindow.webView_0.QueueScriptCall(string.Format("updateTable('{0}','#c2c2c2',{1},6)", text, this.jtoken_1["id"]));
					result = text;
				}
			}
		}
		catch
		{
			MainWindow.webView_0.QueueScriptCall(string.Format("updateTable('none','#c2c2c2',{0},6)", this.jtoken_1["id"]));
			result = null;
		}
		return result;
	}

	// Token: 0x0600004A RID: 74 RVA: 0x00008E6C File Offset: 0x0000706C
	public void method_7(string string_3, string string_4 = "#c2c2c2")
	{
		this.jtoken_1["product"] = string_3;
		MainWindow.dictionary_0[(int)this.jtoken_1["id"]]["product"] = string_3;
		MainWindow.webView_0.QueueScriptCall(string.Format("updateTable('{0}','{1}',{2},2)", string_3.Replace("'", "\\'"), string_4, this.jtoken_1["id"]));
	}

	// Token: 0x0600004B RID: 75 RVA: 0x00008EF0 File Offset: 0x000070F0
	public void method_8()
	{
		string text = (string)this.jtoken_1["afk"];
		if (text == "False")
		{
			return;
		}
		int num = (int)new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(Convert.ToDouble(text)).Subtract(DateTime.UtcNow).TotalSeconds;
		if (num > 0)
		{
			this.method_13(num, "Waiting", 0);
			return;
		}
	}

	// Token: 0x0600004C RID: 76 RVA: 0x00008F68 File Offset: 0x00007168
	public void method_9(bool bool_2)
	{
		Class4.Class6 @class = new Class4.Class6();
		@class.bool_0 = bool_2;
		@class.class4_0 = this;
		try
		{
			if (GClass0.bool_0)
			{
				MethodInvoker method = new MethodInvoker(@class.method_0);
				MainWindow.mainWindow_0.Invoke(method);
			}
			new Task(new Action(@class.method_1)).Start();
		}
		catch
		{
		}
		try
		{
			Class4.soundPlayer_0.Play();
		}
		catch
		{
		}
	}

	// Token: 0x0600004D RID: 77 RVA: 0x00008FF0 File Offset: 0x000071F0
	public void method_10(bool bool_2)
	{
		try
		{
			if (GClass0.string_1.Contains("https://discordapp.com/api/webhooks/"))
			{
				JObject jobject = new JObject(new JProperty("embeds", new JObject()));
				jobject["username"] = "CyberAIO";
				jobject["avatar_url"] = "https://cdn.discordapp.com/attachments/422926053745623040/437275593571172362/logo.png";
				JArray jarray = new JArray();
				JObject jobject2 = new JObject();
				jobject2["title"] = (bool_2 ? "Your card was Declined!" : "You checked out!");
				jobject2["description"] = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture);
				jobject2["color"] = (bool_2 ? 16711680 : 3329330);
				if (this.string_1 != null)
				{
					jobject2["thumbnail"] = new JObject();
					jobject2["thumbnail"]["url"] = (this.string_1.Contains("http") ? this.string_1.Replace("\\/", "/") : ("http:" + this.string_1.Replace("\\/", "/")));
				}
				jobject2["footer"] = new JObject();
				jobject2["footer"]["text"] = "CyberAIO Success Logger";
				JArray jarray2 = new JArray();
				JObject jobject3 = new JObject();
				jobject3["name"] = "Product";
				jobject3["value"] = this.jtoken_1["product"].ToString();
				jobject3["inline"] = false;
				jarray2.Add(jobject3);
				jobject3 = new JObject();
				jobject3["name"] = "Store";
				jobject3["value"] = this.jtoken_1["store"].ToString();
				jobject3["inline"] = true;
				jarray2.Add(jobject3);
				jobject3 = new JObject();
				jobject3["name"] = "Size";
				jobject3["value"] = this.string_2;
				jobject3["inline"] = true;
				jarray2.Add(jobject3);
				if (this.jtoken_1["store"].ToString() == "Supreme")
				{
					jobject3 = new JObject();
					jobject3["name"] = "Color";
					jobject3["value"] = this.string_0;
					jobject3["inline"] = true;
					jarray2.Add(jobject3);
					jobject3 = new JObject();
					jobject3["name"] = "Category";
					jobject3["value"] = this.jtoken_1["supreme"]["category"].ToString();
					jobject3["inline"] = false;
					jarray2.Add(jobject3);
				}
				jobject3 = new JObject();
				jobject3["name"] = "Profile";
				jobject3["value"] = this.jtoken_1["profile"].ToString();
				jobject3["inline"] = true;
				jarray2.Add(jobject3);
				jobject2["fields"] = jarray2;
				jarray.Add(jobject2);
				jobject["embeds"] = jarray;
				new Class70(null, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.181 Safari/537.36", 10, false, true, null, false).method_10(GClass0.string_1, jobject);
			}
		}
		catch
		{
		}
	}

	// Token: 0x0600004E RID: 78 RVA: 0x000093F4 File Offset: 0x000075F4
	public void method_11(bool bool_2)
	{
		try
		{
			if (GClass0.string_1.Contains("https://discordapp.com/api/webhooks/") || GClass0.string_1.Contains("https://hooks.slack.com/services/"))
			{
				JObject jobject = new JObject(new JProperty("attachments", new JObject()));
				jobject["username"] = "CyberAIO";
				jobject["icon_url"] = "https://cdn.discordapp.com/attachments/422926053745623040/437275593571172362/logo.png";
				JArray jarray = new JArray();
				JObject jobject2 = new JObject();
				jobject2["title"] = (bool_2 ? "Your card was Declined!" : "You checked out!");
				jobject2["text"] = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture);
				jobject2["color"] = (bool_2 ? "#FF0000" : "#32CD32");
				if (this.string_1 != null)
				{
					jobject2["thumb_url"] = (this.string_1.Contains("http") ? this.string_1.Replace("\\/", "/") : ("http:" + this.string_1.Replace("\\/", "/")));
				}
				jobject2["footer"] = "CyberAIO Success Logger";
				JArray jarray2 = new JArray();
				JObject jobject3 = new JObject();
				jobject3["title"] = "Product";
				jobject3["value"] = this.jtoken_1["product"].ToString();
				jobject3["short"] = false;
				jarray2.Add(jobject3);
				jobject3 = new JObject();
				jobject3["title"] = "Store";
				jobject3["value"] = this.jtoken_1["store"].ToString();
				jobject3["short"] = true;
				jarray2.Add(jobject3);
				jobject3 = new JObject();
				jobject3["title"] = "Size";
				jobject3["value"] = this.string_2;
				jobject3["short"] = true;
				jarray2.Add(jobject3);
				if (this.jtoken_1["store"].ToString() == "Supreme")
				{
					jobject3 = new JObject();
					jobject3["title"] = "Color";
					jobject3["value"] = this.string_0;
					jobject3["short"] = true;
					jarray2.Add(jobject3);
					jobject3 = new JObject();
					jobject3["title"] = "Category";
					jobject3["value"] = this.jtoken_1["supreme"]["category"].ToString();
					jobject3["short"] = false;
					jarray2.Add(jobject3);
				}
				jobject3 = new JObject();
				jobject3["title"] = "Profile";
				jobject3["value"] = this.jtoken_1["profile"].ToString();
				jobject3["short"] = true;
				jarray2.Add(jobject3);
				jobject2["fields"] = jarray2;
				jarray.Add(jobject2);
				jobject["attachments"] = jarray;
				new Class70(null, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.181 Safari/537.36", 10, false, true, null, false).method_10(GClass0.string_1.Contains("discord") ? (GClass0.string_1.Replace("/slack", string.Empty) + "/slack") : GClass0.string_1, jobject);
			}
		}
		catch
		{
		}
	}

	// Token: 0x0600004F RID: 79 RVA: 0x00009804 File Offset: 0x00007A04
	public void method_12()
	{
		if (object.Equals(true, (bool)this.jtoken_0["one_checkout"]))
		{
			foreach (JToken jtoken in JObject.Parse(MainWindow.webView_0.QueueScriptCall("JSON.stringify(tasklist)").smethod_0()).Values())
			{
				if (jtoken["profile"].ToString() == this.jtoken_1["profile"].ToString() && jtoken["store"].ToString() == this.jtoken_1["store"].ToString() && jtoken["id"].ToString() != this.jtoken_1["id"].ToString())
				{
					if (Class4.Class8.callSite_3 == null)
					{
						Class4.Class8.callSite_3 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Class4), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					Func<CallSite, object, bool> target = Class4.Class8.callSite_3.Target;
					CallSite callSite_ = Class4.Class8.callSite_3;
					bool flag;
					object arg2;
					if (flag = MainWindow.dictionary_0.ContainsKey((int)jtoken["id"]))
					{
						if (Class4.Class8.callSite_2 == null)
						{
							Class4.Class8.callSite_2 = CallSite<Func<CallSite, bool, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, ExpressionType.And, typeof(Class4), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						Func<CallSite, bool, object, object> target2 = Class4.Class8.callSite_2.Target;
						CallSite callSite_2 = Class4.Class8.callSite_2;
						bool arg = flag;
						if (Class4.Class8.callSite_1 == null)
						{
							Class4.Class8.callSite_1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(Class4), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
							}));
						}
						Func<CallSite, object, string, object> target3 = Class4.Class8.callSite_1.Target;
						CallSite callSite_3 = Class4.Class8.callSite_1;
						if (Class4.Class8.callSite_0 == null)
						{
							Class4.Class8.callSite_0 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(Class4), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						arg2 = target2(callSite_2, arg, target3(callSite_3, Class4.Class8.callSite_0.Target(Class4.Class8.callSite_0, MainWindow.dictionary_0[(int)jtoken["id"]]["product"]), this.jtoken_1["product"].ToString()));
					}
					else
					{
						arg2 = flag;
					}
					if (target(callSite_, arg2))
					{
						object arg3 = MainWindow.dictionary_0[(int)jtoken["id"]]["thread"];
						MainWindow.dictionary_0[(int)jtoken["id"]]["stop"] = true;
						MainWindow.webView_0.QueueScriptCall(string.Format("updateTable('Stopping...','DARKORANGE',{0},7)", jtoken["id"]));
						if (Class4.Class8.callSite_4 == null)
						{
							Class4.Class8.callSite_4 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Abort", null, typeof(Class4), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						Class4.Class8.callSite_4.Target(Class4.Class8.callSite_4, arg3);
						if (Class4.Class8.callSite_5 == null)
						{
							Class4.Class8.callSite_5 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Join", null, typeof(Class4), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						Class4.Class8.callSite_5.Target(Class4.Class8.callSite_5, arg3);
						MainWindow.dictionary_0.Remove((int)jtoken["id"]);
						MainWindow.webView_0.QueueScriptCall(string.Format("updateTable('Billing used','red',{0},7)", jtoken["id"]));
						MainWindow.webView_0.QueueScriptCall(string.Format("updateButton({0},false)", jtoken["id"]));
					}
				}
			}
		}
	}

	// Token: 0x06000050 RID: 80 RVA: 0x00009C34 File Offset: 0x00007E34
	public void method_13(int int_0, string string_3, int int_1)
	{
		this.stopwatch_0.Restart();
		while ((double)int_0 > this.stopwatch_0.Elapsed.TotalSeconds)
		{
			this.method_4(string_3 + " " + TimeSpan.FromSeconds((double)int_0 - this.stopwatch_0.Elapsed.TotalSeconds).ToString("d\\d\\ hh\\:mm\\:ss"), "#c2c2c2", false, false);
			Thread.Sleep(1000);
		}
		this.stopwatch_0.Stop();
	}

	// Token: 0x06000051 RID: 81 RVA: 0x00002EF0 File Offset: 0x000010F0
	internal void method_14(string string_3, string string_4 = "#c2c2c2")
	{
		this.method_7(string_3, string_4);
	}

	// Token: 0x04000034 RID: 52
	public static SoundPlayer soundPlayer_0 = new SoundPlayer("audio/Success.wav");

	// Token: 0x04000035 RID: 53
	public string string_0;

	// Token: 0x04000036 RID: 54
	public string string_1;

	// Token: 0x04000037 RID: 55
	public bool bool_0;

	// Token: 0x04000038 RID: 56
	private JToken jtoken_0;

	// Token: 0x04000039 RID: 57
	private string string_2;

	// Token: 0x0400003A RID: 58
	private readonly JToken jtoken_1;

	// Token: 0x0400003B RID: 59
	private readonly Stopwatch stopwatch_0 = new Stopwatch();

	// Token: 0x0400003C RID: 60
	public bool bool_1;

	// Token: 0x0200000E RID: 14
	private sealed class Class5
	{
		// Token: 0x06000053 RID: 83 RVA: 0x00009CBC File Offset: 0x00007EBC
		internal HttpResponseMessage method_0()
		{
			string text = this.string_0;
			int int_ = (int)this.class4_0.jtoken_1["id"];
			bool flag = this.bool_0;
			return Class30.smethod_2(text, int_, this.jobject_0, flag);
		}

		// Token: 0x0400003D RID: 61
		public string string_0;

		// Token: 0x0400003E RID: 62
		public Class4 class4_0;

		// Token: 0x0400003F RID: 63
		public bool bool_0;

		// Token: 0x04000040 RID: 64
		public JObject jobject_0;
	}

	// Token: 0x0200000F RID: 15
	private sealed class Class6
	{
		// Token: 0x06000055 RID: 85 RVA: 0x00009CFC File Offset: 0x00007EFC
		internal void method_0()
		{
			Notification.smethod_0(this.bool_0 ? "Card Declined" : "Successfully Checked Out", (string)this.class4_0.jtoken_1["product"], this.bool_0 ? ((Notification.GEnum0)1) : ((Notification.GEnum0)0), true);
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00009D4C File Offset: 0x00007F4C
		internal void method_1()
		{
			this.class4_0.method_11(this.bool_0);
			string text = DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture);
			long num = Convert.ToInt64(text.Replace(" ", string.Empty).Replace("/", string.Empty).Replace(":", string.Empty).Replace(".", string.Empty)) * 27L;
			Dictionary<string, string> dictionary = Class70.smethod_1();
			dictionary["token"] = num.ToString();
			dictionary["timestamp"] = text;
			dictionary["store"] = this.class4_0.jtoken_1["store"].ToString();
			dictionary["product"] = this.class4_0.jtoken_1["product"].ToString();
			dictionary["customer"] = Licenser.string_0;
			dictionary["Declined"] = this.bool_0.ToString();
			new Class70(null, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.181 Safari/537.36", 4, false, false, null, false).method_7("https://www.cybersole.io/api/success", dictionary, false);
		}

		// Token: 0x04000041 RID: 65
		public bool bool_0;

		// Token: 0x04000042 RID: 66
		public Class4 class4_0;
	}

	// Token: 0x02000010 RID: 16
	private static class Class7
	{
		// Token: 0x04000043 RID: 67
		public static CallSite<Func<CallSite, object, bool, object>> callSite_0;

		// Token: 0x04000044 RID: 68
		public static CallSite<Func<CallSite, bool, object, object>> callSite_1;

		// Token: 0x04000045 RID: 69
		public static CallSite<Func<CallSite, object, bool, object>> callSite_2;

		// Token: 0x04000046 RID: 70
		public static CallSite<Func<CallSite, object, bool>> callSite_3;

		// Token: 0x04000047 RID: 71
		public static CallSite<Func<CallSite, object, bool, object>> callSite_4;

		// Token: 0x04000048 RID: 72
		public static CallSite<Func<CallSite, object, bool>> callSite_5;

		// Token: 0x04000049 RID: 73
		public static CallSite<Func<CallSite, object, bool>> callSite_6;
	}

	// Token: 0x02000011 RID: 17
	private static class Class8
	{
		// Token: 0x0400004A RID: 74
		public static CallSite<Func<CallSite, object, object>> callSite_0;

		// Token: 0x0400004B RID: 75
		public static CallSite<Func<CallSite, object, string, object>> callSite_1;

		// Token: 0x0400004C RID: 76
		public static CallSite<Func<CallSite, bool, object, object>> callSite_2;

		// Token: 0x0400004D RID: 77
		public static CallSite<Func<CallSite, object, bool>> callSite_3;

		// Token: 0x0400004E RID: 78
		public static CallSite<Action<CallSite, object>> callSite_4;

		// Token: 0x0400004F RID: 79
		public static CallSite<Action<CallSite, object>> callSite_5;
	}
}
