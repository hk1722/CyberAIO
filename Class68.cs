using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EO.WebBrowser;
using Newtonsoft.Json.Linq;

// Token: 0x02000077 RID: 119
internal sealed class Class68
{
	// Token: 0x060002A6 RID: 678 RVA: 0x000166C0 File Offset: 0x000148C0
	public static void smethod_0(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		Class168.string_1 = jsextInvokeArgs_0.Arguments.First<object>().ToString();
		JObject jobject = JObject.Parse(MainWindow.webView_0.QueueScriptCall("JSON.stringify(tasklist)").smethod_0());
		foreach (KeyValuePair<string, JToken> keyValuePair in jobject)
		{
			if (Class168.jobject_4.ContainsKey(keyValuePair.Value["store"].ToString()) && Class168.string_1.Replace("www.", string.Empty).Contains(new Uri(Class168.jobject_4[keyValuePair.Value["store"].ToString()]["sitemap"].ToString().Replace("www.", string.Empty)).Host))
			{
				MainWindow.webView_0.QueueScriptCall(string.Format("updateTable('{0}','#c2c2c2',{1},2)", Class168.string_1.Replace("'", "\\'"), keyValuePair.Value["id"].ToString()));
				keyValuePair.Value["keywords"] = Class168.string_1;
			}
		}
		MainWindow.webView_0.QueueScriptCall(string.Format("tasklist = JSON.parse('{0}')", jobject.ToString().smethod_6().Replace("'", "\\'")));
	}

	// Token: 0x060002A7 RID: 679 RVA: 0x00016848 File Offset: 0x00014A48
	public static void smethod_1()
	{
		Version version = Assembly.GetEntryAssembly().GetName().Version;
		MainWindow.webView_0.QueueScriptCall(string.Format("$('#keyinput').val('{0}')", GClass0.string_2));
		MainWindow.webView_0.QueueScriptCall(string.Format("$('#version-number')[0].innerHTML = '{0}'", version));
		MainWindow.webView_0.QueueScriptCall(string.Format("$('#globaldelay')[0].value = '{0}'", GClass0.int_1));
		MainWindow.webView_0.QueueScriptCall(string.Format("$('#monitordelay')[0].value = '{0}'", GClass0.int_0));
		MainWindow.webView_0.QueueScriptCall(string.Format("$('#monitordelay')[0].value = '{0}'", GClass0.int_0));
		MainWindow.webView_0.QueueScriptCall(string.Format("$('#webhook')[0].value = '{0}'", GClass0.string_1));
		MainWindow.webView_0.QueueScriptCall(string.Format("$('#license-expiry')[0].innerHTML = $('#license-expiry')[0].innerHTML.replace('00/00/0000', '{0}')", Licenser.dateTime_0.ToShortDateString()));
		MainWindow.webView_0.QueueScriptCall(string.Format("$('#desktop-notification').prop('checked', {0})", GClass0.bool_0.ToString().ToLower()));
	}

	// Token: 0x060002A8 RID: 680 RVA: 0x00004461 File Offset: 0x00002661
	public static void smethod_2(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		Process.Start(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CyberAIO\\log.txt"));
	}

	// Token: 0x060002A9 RID: 681 RVA: 0x0000447A File Offset: 0x0000267A
	public static void smethod_3(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		GClass0.jobject_0 = JObject.Parse(MainWindow.webView_0.QueueScriptCall("JSON.stringify(profiles)").smethod_0());
		GClass0.smethod_2();
	}

	// Token: 0x060002AA RID: 682 RVA: 0x0000449F File Offset: 0x0000269F
	public static void smethod_4(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		GClass0.jobject_1 = JObject.Parse(MainWindow.webView_0.QueueScriptCall("JSON.stringify(tasklist)").smethod_0());
		GClass0.smethod_2();
	}

	// Token: 0x060002AB RID: 683 RVA: 0x000044C4 File Offset: 0x000026C4
	public static void smethod_5(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		GClass0.jarray_0 = JArray.Parse(MainWindow.webView_0.QueueScriptCall("JSON.stringify(proxy_list)").smethod_0());
		GClass0.smethod_2();
	}

	// Token: 0x060002AC RID: 684 RVA: 0x000044E9 File Offset: 0x000026E9
	public static void smethod_6()
	{
		MainWindow.webView_0.QueueScriptCall(string.Format("loadProfiles(\"{0}\")", GClass0.jobject_0.ToString().smethod_6().smethod_4()));
	}

	// Token: 0x060002AD RID: 685 RVA: 0x00004514 File Offset: 0x00002714
	public static void smethod_7()
	{
		MainWindow.webView_0.QueueScriptCall(string.Format("loadTasks('{0}')", GClass0.jobject_1.ToString().smethod_6().smethod_4()));
	}

	// Token: 0x060002AE RID: 686 RVA: 0x0000453F File Offset: 0x0000273F
	public static void smethod_8()
	{
		MainWindow.webView_0.QueueScriptCall(string.Format("loadProxies('{0}')", GClass0.jarray_0.ToString().smethod_6().smethod_4()));
	}

	// Token: 0x060002AF RID: 687 RVA: 0x00016950 File Offset: 0x00014B50
	public static void smethod_9(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		GClass0.int_1 = (int)Convert.ToInt16(MainWindow.webView_0.QueueScriptCall("$('#globaldelay').val()").smethod_0());
		GClass0.int_0 = (int)Convert.ToInt16(MainWindow.webView_0.QueueScriptCall("$('#monitordelay').val()").smethod_0());
		GClass0.string_1 = MainWindow.webView_0.QueueScriptCall("$('#webhook').val()").smethod_0();
		GClass0.bool_0 = (MainWindow.webView_0.QueueScriptCall("$('#desktop-notification').prop('checked').toString()").smethod_0() == "true");
		MainWindow.webView_0.QueueScriptCall("swal('Success', 'Successfully saved settings','success',{timer:1500})");
		GClass0.smethod_2();
	}

	// Token: 0x060002B0 RID: 688 RVA: 0x0000456A File Offset: 0x0000276A
	public static void smethod_10(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		Process.Start("mailto:help@cybersole.io?Subject=Help%20Ticket%20-%20License%20Key:%20" + GClass0.string_2);
	}

	// Token: 0x060002B1 RID: 689 RVA: 0x00004581 File Offset: 0x00002781
	public static void smethod_11(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		MainWindow.webView_0.QueueScriptCall("swal('Resetting key...','Please wait...','info',{buttons:false})");
		new Task(new Action(Class68.Class69.class69_0.method_0)).Start();
	}

	// Token: 0x060002B2 RID: 690 RVA: 0x000169EC File Offset: 0x00014BEC
	public static void smethod_12(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.Filter = "CyberAIO Backup|*.json";
		saveFileDialog.Title = "Backup CyberAIO";
		saveFileDialog.FileName = "CyberAIO Backup";
		if (saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			JObject jobject = new JObject();
			jobject["tasks"] = GClass0.jobject_1;
			jobject["proxies"] = GClass0.jarray_0;
			jobject["profiles"] = GClass0.jobject_0;
			jobject["settings"] = new JObject();
			jobject["settings"]["global_delay"] = GClass0.int_1;
			jobject["settings"]["monitor_delay"] = GClass0.int_0;
			jobject["settings"]["webhook"] = GClass0.string_1;
			StreamWriter streamWriter = new StreamWriter(saveFileDialog.OpenFile());
			streamWriter.WriteLine(jobject.ToString());
			streamWriter.Dispose();
			streamWriter.Close();
		}
	}

	// Token: 0x060002B3 RID: 691 RVA: 0x00016AF4 File Offset: 0x00014CF4
	public static void smethod_13(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = "CyberAIO Backups|*.json";
		openFileDialog.Title = "Select your backup file";
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			JObject jobject = JObject.Parse(new StreamReader(openFileDialog.FileName).ReadToEnd().ToString());
			MainWindow.webView_0.QueueScriptCall("$('#taskbody')[0].innerHTML = ''; stopTask(JSON.stringify(tasklist)); tasklist = {}; setTasks(); tasks = 0").smethod_0();
			MainWindow.webView_0.QueueScriptCall("proxy_list = []; $('#proxybody')[0].innerHTML = ''; setProxies(); proxies = 0").smethod_0();
			MainWindow.webView_0.QueueScriptCall(string.Format("loadTasks('{0}')", jobject["tasks"].ToString().smethod_6()));
			MainWindow.webView_0.QueueScriptCall(string.Format("loadProxies('{0}')", jobject["proxies"].ToString().smethod_6()));
			MainWindow.webView_0.QueueScriptCall(string.Format("loadProfiles('{0}')", jobject["profiles"].ToString().smethod_6()));
			GClass0.jarray_0 = JArray.Parse(jobject["proxies"].ToString());
			GClass0.jobject_0 = JObject.Parse(jobject["profiles"].ToString());
			GClass0.jobject_1 = JObject.Parse(jobject["tasks"].ToString());
			GClass0.int_1 = (int)jobject["settings"]["global_delay"];
			GClass0.int_0 = (int)jobject["settings"]["monitor_delay"];
			GClass0.string_1 = ((jobject["settings"]["webhook"] == null) ? string.Empty : jobject["settings"]["webhook"].ToString());
			Class68.smethod_1();
			MainWindow.webView_0.QueueScriptCall("swal('Success', 'Successfully imported tasks, proxies, profiles and settings!','success',{timer:1500})");
			GClass0.smethod_2();
		}
	}

	// Token: 0x02000078 RID: 120
	[Serializable]
	private sealed class Class69
	{
		// Token: 0x060002B6 RID: 694 RVA: 0x00016CD0 File Offset: 0x00014ED0
		internal void method_0()
		{
			try
			{
				Licenser.smethod_8();
				MainWindow.webView_0.QueueScriptCall("swal('Success','Successfully reset your license key!','success')");
				Thread.Sleep(1500);
				MainWindow.mainWindow_0.method_9(null, null);
			}
			catch
			{
				MainWindow.webView_0.QueueScriptCall("swal('Error','There was an error resetting your key, please try again later...','error')");
			}
		}

		// Token: 0x0400016D RID: 365
		public static readonly Class68.Class69 class69_0 = new Class68.Class69();

		// Token: 0x0400016E RID: 366
		public static Action action_0;
	}
}
