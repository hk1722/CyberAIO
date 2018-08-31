using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using EO.WebBrowser;
using Newtonsoft.Json.Linq;

// Token: 0x020000B5 RID: 181
internal sealed class Class96
{
	// Token: 0x060004D0 RID: 1232 RVA: 0x0000530C File Offset: 0x0000350C
	public static void smethod_0(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		new Thread(new ParameterizedThreadStart(new Class96.Class97
		{
			jobject_0 = JObject.Parse(jsextInvokeArgs_0.Arguments.First<object>().ToString())
		}.method_0)).Start();
	}

	// Token: 0x060004D1 RID: 1233 RVA: 0x00027A68 File Offset: 0x00025C68
	public static void smethod_1(string string_0, string string_1)
	{
		string string_2;
		string string_3;
		try
		{
			string text = MainWindow.webView_0.QueueScriptCall("$('#test-site').val()").smethod_0();
			Class70 @class = new Class70(string_0, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.181 Safari/537.36", 10, false, true, null, false);
			string text2;
			if (!(text == "Shopify"))
			{
				if (!(text == "Supreme"))
				{
					if (!(text == "Mesh"))
					{
						if (!(text == "Footsites"))
						{
							if (!(text == "Off-White"))
							{
								if (!(text == "Lacoste"))
								{
									text2 = text;
									try
									{
										text = new Uri(text2).Host;
										goto IL_11B;
									}
									catch
									{
										MainWindow.webView_0.QueueScriptCall(string.Format("updateProxyRow('{0}','{1}',7,'{2}')", string_1, "Invalid URL", "red"));
										return;
									}
								}
								text2 = "https://www.lacoste.com/gb/";
							}
							else
							{
								text2 = "https://www.off---white.com/en/GB";
							}
						}
						else
						{
							text2 = "https://www.footaction.com/";
							@class.httpClient_0.DefaultRequestHeaders.ExpectContinue = new bool?(false);
							@class.httpClient_0.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
						}
					}
					else
					{
						text2 = "https://prod.jdgroupmesh.cloud/stores/size/products/000987?api_key=3565AE9C56464BB0AD8020F735D1479E";
					}
				}
				else
				{
					text2 = "http://www.supremenewyork.com/shop/all";
				}
			}
			else
			{
				text2 = "https://kith.com/collections.json";
			}
			IL_11B:
			MainWindow.webView_0.QueueScriptCall(string.Format("updateProxyRow('{0}','{1}', 7, '{2}')", string_1, "Testing...", "orange"));
			MainWindow.webView_0.QueueScriptCall(string.Format("updateProxyRow('{0}','{1}', 6, '{2}')", string_1, text, "#c2c2c2"));
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			HttpResponseMessage httpResponseMessage = @class.method_5(text2, true);
			stopwatch.Stop();
			long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
			if (httpResponseMessage.IsSuccessStatusCode)
			{
				string_2 = elapsedMilliseconds.ToString() + "ms";
				string_3 = "#2BB873";
				if (text == "Supreme")
				{
					if (httpResponseMessage.smethod_3().Contains("LDN"))
					{
						MainWindow.webView_0.QueueScriptCall(string.Format("updateProxyRow('{0}','{1}', 6, '{2}')", string_1, "Supreme EU", "#c2c2c2"));
					}
					else if (httpResponseMessage.smethod_3().Contains("NYC"))
					{
						MainWindow.webView_0.QueueScriptCall(string.Format("updateProxyRow('{0}','{1}', 6, '{2}')", string_1, "Supreme US", "#c2c2c2"));
					}
				}
			}
			else if (httpResponseMessage.StatusCode == (HttpStatusCode)430)
			{
				string_2 = "Banned";
				string_3 = "Red";
			}
			else if (httpResponseMessage.StatusCode == HttpStatusCode.ProxyAuthenticationRequired)
			{
				string_2 = "Authentication error";
				string_3 = "Red";
			}
			else
			{
				string_2 = string.Format("Error ({0})", (int)httpResponseMessage.StatusCode);
				string_3 = "Red";
			}
		}
		catch
		{
			string_2 = "Error";
			string_3 = "Red";
		}
		Class96.smethod_2(string_1, string_3, string_2);
	}

	// Token: 0x060004D2 RID: 1234 RVA: 0x00005343 File Offset: 0x00003543
	public static void smethod_2(string string_0, string string_1, string string_2)
	{
		MainWindow.webView_0.QueueScriptCall(string.Format("updateProxyRow('{0}','{1}',7,'{2}')", string_0, string_2, string_1));
	}

	// Token: 0x020000B6 RID: 182
	private sealed class Class97
	{
		// Token: 0x060004D4 RID: 1236 RVA: 0x0000535D File Offset: 0x0000355D
		internal void method_0(object object_0)
		{
			Class96.smethod_1(this.jobject_0["proxy"].ToString(), this.jobject_0["id"].ToString());
		}

		// Token: 0x04000251 RID: 593
		public JObject jobject_0;
	}
}
