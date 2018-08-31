using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Media;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using EO.Base;
using EO.WebBrowser;
using EO.WebEngine;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json.Linq;

// Token: 0x02000112 RID: 274
public sealed partial class CaptchaQueue_V1 : Form
{
	// Token: 0x060006FB RID: 1787 RVA: 0x0000663B File Offset: 0x0000483B
	public CaptchaQueue_V1(bool bool_1 = true)
	{
		this.InitializeComponent();
		this.method_1();
		this.method_8();
		this.solverButton1_Click(null, null);
	}

	// Token: 0x060006FD RID: 1789 RVA: 0x0003AE48 File Offset: 0x00039048
	public void method_0(string string_1, string string_2)
	{
		int num = 1;
		string text = (string_1 != null) ? string_1 : ("Solver " + num);
		while (CaptchaQueue_V1.dictionary_0.ContainsKey(text))
		{
			num++;
			text = "Solver " + num;
		}
		Panel panel = new Panel();
		panel.Dock = DockStyle.Fill;
		BrowserOptions options = new BrowserOptions
		{
			EnableXSSAuditor = new bool?(false),
			EnableWebSecurity = new bool?(false)
		};
		WebView webView = new WebView();
		Engine engine = Engine.Create(text);
		if (string_2 != null)
		{
			try
			{
				string[] array = string_2.Split(new char[]
				{
					':'
				});
				if (array.Length == 4)
				{
					engine.Options.Proxy = new ProxyInfo(ProxyType.HTTP, array[0], Convert.ToInt32(array[1]), array[2], array[3]);
				}
				else if (array.Length == 2)
				{
					engine.Options.Proxy = new ProxyInfo(ProxyType.HTTP, array[0], Convert.ToInt32(array[1]));
				}
				else
				{
					string_2 = null;
				}
			}
			catch
			{
				string_2 = null;
			}
		}
		webView.SetOptions(options);
		webView.Engine = engine;
		webView.Engine.AllowRestart = true;
		webView.Create(panel.Handle);
		webView.RegisterJSExtensionFunction("submit", new JSExtInvokeHandler(this.method_3));
		webView.RegisterJSExtensionFunction("solveAudio", new JSExtInvokeHandler(CaptchaQueue_V1.smethod_3));
		webView.CertificateError += this.method_5;
		webView.BeforeContextMenu += this.method_4;
		Dictionary<string, Dictionary<string, object>> dictionary = CaptchaQueue_V1.dictionary_0;
		string key = text;
		Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
		dictionary2["browser"] = webView;
		dictionary2["available"] = true;
		dictionary2["panel"] = panel;
		dictionary2["proxy"] = string_2;
		dictionary[key] = dictionary2;
		CaptchaQueue_V1.smethod_7(text);
		this.method_2();
	}

	// Token: 0x060006FE RID: 1790 RVA: 0x0003B01C File Offset: 0x0003921C
	public void method_1()
	{
		foreach (KeyValuePair<string, JToken> keyValuePair in GClass0.jobject_3)
		{
			string key = keyValuePair.Key;
			JToken jtoken = keyValuePair.Value["proxy"];
			this.method_0(key, (jtoken != null) ? jtoken.ToString() : null);
		}
		if (GClass0.jobject_3.Count == 0)
		{
			this.method_0(null, null);
		}
	}

	// Token: 0x060006FF RID: 1791 RVA: 0x0003B0A0 File Offset: 0x000392A0
	public void method_2()
	{
		JObject jobject = new JObject();
		foreach (KeyValuePair<string, Dictionary<string, object>> keyValuePair in CaptchaQueue_V1.dictionary_0)
		{
			jobject[keyValuePair.Key] = new JObject();
			JToken jtoken = jobject[keyValuePair.Key];
			object key = "proxy";
			if (CaptchaQueue_V1.Class200.callSite_0 == null)
			{
				CaptchaQueue_V1.Class200.callSite_0 = CallSite<Func<CallSite, object, JToken>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(JToken), typeof(CaptchaQueue_V1)));
			}
			jtoken[key] = CaptchaQueue_V1.Class200.callSite_0.Target(CaptchaQueue_V1.Class200.callSite_0, keyValuePair.Value["proxy"]);
		}
		GClass0.jobject_3 = jobject;
		GClass0.smethod_2();
	}

	// Token: 0x06000700 RID: 1792 RVA: 0x0003B17C File Offset: 0x0003937C
	private void setProxyButton_Click(object sender, EventArgs e)
	{
		try
		{
			if (!(this.proxyInput.Text == "Proxy (IP:Port:Username:Password)"))
			{
				string[] array = this.proxyInput.Text.Split(new char[]
				{
					':'
				});
				if (array.Length == 4 || array.Length == 2)
				{
					if (CaptchaQueue_V1.Class183.callSite_0 == null)
					{
						CaptchaQueue_V1.Class183.callSite_0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Engine", typeof(CaptchaQueue_V1), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					object arg = CaptchaQueue_V1.Class183.callSite_0.Target(CaptchaQueue_V1.Class183.callSite_0, CaptchaQueue_V1.dictionary_0[CaptchaQueue_V1.string_0]["browser"]);
					if (array.Length == 4)
					{
						if (CaptchaQueue_V1.Class183.callSite_2 == null)
						{
							CaptchaQueue_V1.Class183.callSite_2 = CallSite<Func<CallSite, object, ProxyInfo, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Proxy", typeof(CaptchaQueue_V1), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
							}));
						}
						Func<CallSite, object, ProxyInfo, object> target = CaptchaQueue_V1.Class183.callSite_2.Target;
						CallSite callSite_ = CaptchaQueue_V1.Class183.callSite_2;
						if (CaptchaQueue_V1.Class183.callSite_1 == null)
						{
							CaptchaQueue_V1.Class183.callSite_1 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Options", typeof(CaptchaQueue_V1), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						target(callSite_, CaptchaQueue_V1.Class183.callSite_1.Target(CaptchaQueue_V1.Class183.callSite_1, arg), new ProxyInfo(ProxyType.HTTP, array[0], Convert.ToInt32(array[1]), array[2], array[3]));
					}
					else
					{
						if (array.Length != 2)
						{
							return;
						}
						if (CaptchaQueue_V1.Class183.callSite_4 == null)
						{
							CaptchaQueue_V1.Class183.callSite_4 = CallSite<Func<CallSite, object, ProxyInfo, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Proxy", typeof(CaptchaQueue_V1), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
							}));
						}
						Func<CallSite, object, ProxyInfo, object> target2 = CaptchaQueue_V1.Class183.callSite_4.Target;
						CallSite callSite_2 = CaptchaQueue_V1.Class183.callSite_4;
						if (CaptchaQueue_V1.Class183.callSite_3 == null)
						{
							CaptchaQueue_V1.Class183.callSite_3 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Options", typeof(CaptchaQueue_V1), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						target2(callSite_2, CaptchaQueue_V1.Class183.callSite_3.Target(CaptchaQueue_V1.Class183.callSite_3, arg), new ProxyInfo(ProxyType.HTTP, array[0], Convert.ToInt32(array[1])));
					}
					if (CaptchaQueue_V1.Class183.callSite_6 == null)
					{
						CaptchaQueue_V1.Class183.callSite_6 = CallSite<Action<CallSite, object, bool>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Stop", null, typeof(CaptchaQueue_V1), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
						}));
					}
					Action<CallSite, object, bool> target3 = CaptchaQueue_V1.Class183.callSite_6.Target;
					CallSite callSite_3 = CaptchaQueue_V1.Class183.callSite_6;
					if (CaptchaQueue_V1.Class183.callSite_5 == null)
					{
						CaptchaQueue_V1.Class183.callSite_5 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Engine", typeof(CaptchaQueue_V1), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					target3(callSite_3, CaptchaQueue_V1.Class183.callSite_5.Target(CaptchaQueue_V1.Class183.callSite_5, CaptchaQueue_V1.dictionary_0[CaptchaQueue_V1.string_0]["browser"]), false);
					if (CaptchaQueue_V1.Class183.callSite_7 == null)
					{
						CaptchaQueue_V1.Class183.callSite_7 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Dispose", null, typeof(CaptchaQueue_V1), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					CaptchaQueue_V1.Class183.callSite_7.Target(CaptchaQueue_V1.Class183.callSite_7, CaptchaQueue_V1.dictionary_0[CaptchaQueue_V1.string_0]["browser"]);
					BrowserOptions options = new BrowserOptions
					{
						EnableXSSAuditor = new bool?(false),
						EnableWebSecurity = new bool?(false)
					};
					WebView webView = new WebView();
					webView.SetOptions(options);
					WebView webView2 = webView;
					if (CaptchaQueue_V1.Class183.callSite_8 == null)
					{
						CaptchaQueue_V1.Class183.callSite_8 = CallSite<Func<CallSite, object, Engine>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(Engine), typeof(CaptchaQueue_V1)));
					}
					webView2.Engine = CaptchaQueue_V1.Class183.callSite_8.Target(CaptchaQueue_V1.Class183.callSite_8, arg);
					webView.Engine.AllowRestart = true;
					if (CaptchaQueue_V1.Class183.callSite_10 == null)
					{
						CaptchaQueue_V1.Class183.callSite_10 = CallSite<Action<CallSite, WebView, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Create", null, typeof(CaptchaQueue_V1), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					Action<CallSite, WebView, object> target4 = CaptchaQueue_V1.Class183.callSite_10.Target;
					CallSite callSite_4 = CaptchaQueue_V1.Class183.callSite_10;
					WebView arg2 = webView;
					if (CaptchaQueue_V1.Class183.callSite_9 == null)
					{
						CaptchaQueue_V1.Class183.callSite_9 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Handle", typeof(CaptchaQueue_V1), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					target4(callSite_4, arg2, CaptchaQueue_V1.Class183.callSite_9.Target(CaptchaQueue_V1.Class183.callSite_9, CaptchaQueue_V1.dictionary_0[CaptchaQueue_V1.string_0]["panel"]));
					webView.RegisterJSExtensionFunction("submit", new JSExtInvokeHandler(this.method_3));
					webView.RegisterJSExtensionFunction("solveAudio", new JSExtInvokeHandler(CaptchaQueue_V1.smethod_3));
					webView.CertificateError += this.method_5;
					webView.BeforeContextMenu += this.method_4;
					CaptchaQueue_V1.dictionary_0[CaptchaQueue_V1.string_0]["browser"] = webView;
					CaptchaQueue_V1.dictionary_0[CaptchaQueue_V1.string_0]["proxy"] = this.proxyInput.Text;
					this.reloadCaptcha_Click(null, null);
					this.method_2();
				}
			}
		}
		catch
		{
		}
	}

	// Token: 0x06000701 RID: 1793 RVA: 0x0003B6D8 File Offset: 0x000398D8
	private void method_3(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		CaptchaQueue_V1.Class185 @class = new CaptchaQueue_V1.Class185();
		@class.jsextInvokeArgs_0 = jsextInvokeArgs_0;
		CaptchaQueue_V1.concurrentDictionary_0[@class.jsextInvokeArgs_0.Arguments[1].ToString()] = @class.jsextInvokeArgs_0.Arguments.First<object>().ToString();
		ConcurrentDictionary<string, string> concurrentDictionary = CaptchaQueue_V1.list_0.First(new Func<ConcurrentDictionary<string, string>, bool>(@class.method_0));
		CaptchaQueue_V1.list_0.Remove(concurrentDictionary);
		CaptchaQueue_V1.smethod_7(concurrentDictionary["browser"]);
		this.method_7();
	}

	// Token: 0x06000702 RID: 1794 RVA: 0x00002C18 File Offset: 0x00000E18
	public static string smethod_0(string string_1, string string_2, string string_3)
	{
		return string.Empty;
	}

	// Token: 0x06000703 RID: 1795 RVA: 0x0003B75C File Offset: 0x0003995C
	public static async Task<string> smethod_1(string string_1, string string_2, string string_3)
	{
		MainWindow.mainWindow_0.Invoke(new MethodInvoker(CaptchaQueue_V1.Class182.class182_0.method_0));
		string text = Class103.smethod_0(16);
		ConcurrentDictionary<string, string> concurrentDictionary = new ConcurrentDictionary<string, string>();
		concurrentDictionary["sitekey"] = string_1;
		concurrentDictionary["domain"] = string_2;
		concurrentDictionary["taskID"] = string_3;
		concurrentDictionary["token"] = text;
		concurrentDictionary["solving"] = "false";
		ConcurrentDictionary<string, string> concurrentDictionary2 = concurrentDictionary;
		CaptchaQueue_V1.list_0.Add(concurrentDictionary2);
		string result;
		try
		{
			CaptchaQueue_V1.smethod_2(null, null);
			while (!CaptchaQueue_V1.concurrentDictionary_0.ContainsKey(text))
			{
				if (!MainWindow.dictionary_0.ContainsKey((int)Convert.ToInt16(string_3)))
				{
					CaptchaQueue_V1.list_0.Remove(concurrentDictionary2);
					if (concurrentDictionary2.ContainsKey("browser"))
					{
						CaptchaQueue_V1.smethod_7(concurrentDictionary2["browser"]);
						MainWindow.mainWindow_0.Invoke(new MethodInvoker(CaptchaQueue_V1.Class182.class182_0.method_1));
					}
					return null;
				}
				TaskAwaiter taskAwaiter = Task.Delay(100).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
				}
				taskAwaiter.GetResult();
			}
			result = CaptchaQueue_V1.concurrentDictionary_0[text];
		}
		catch
		{
			CaptchaQueue_V1.list_0.Remove(concurrentDictionary2);
			if (concurrentDictionary2.ContainsKey("browser"))
			{
				CaptchaQueue_V1.smethod_7(concurrentDictionary2["browser"]);
				MainWindow.mainWindow_0.Invoke(new MethodInvoker(CaptchaQueue_V1.Class182.class182_0.method_2));
			}
			result = null;
		}
		return result;
	}

	// Token: 0x06000704 RID: 1796 RVA: 0x0003B7B4 File Offset: 0x000399B4
	public static void smethod_2(object sender, EventArgs e)
	{
		if (CaptchaQueue_V1.list_0.Any(new Func<ConcurrentDictionary<string, string>, bool>(CaptchaQueue_V1.Class182.class182_0.method_3)))
		{
			if (CaptchaQueue_V1.dictionary_0.Any(new Func<KeyValuePair<string, Dictionary<string, object>>, bool>(CaptchaQueue_V1.Class182.class182_0.method_4)))
			{
				ConcurrentDictionary<string, string> concurrentDictionary = CaptchaQueue_V1.list_0.First(new Func<ConcurrentDictionary<string, string>, bool>(CaptchaQueue_V1.Class182.class182_0.method_5));
				concurrentDictionary["solving"] = "true";
				string key = CaptchaQueue_V1.dictionary_0.ToList<KeyValuePair<string, Dictionary<string, object>>>().OrderBy(new Func<KeyValuePair<string, Dictionary<string, object>>, short>(CaptchaQueue_V1.Class182.class182_0.method_6)).First(new Func<KeyValuePair<string, Dictionary<string, object>>, bool>(CaptchaQueue_V1.Class182.class182_0.method_7)).Key;
				CaptchaQueue_V1.dictionary_0[key]["available"] = false;
				concurrentDictionary["browser"] = key;
				if (CaptchaQueue_V1.Class186.callSite_2 == null)
				{
					CaptchaQueue_V1.Class186.callSite_2 = CallSite<Action<CallSite, object, string, string>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "LoadHtml", null, typeof(CaptchaQueue_V1), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
					}));
				}
				CaptchaQueue_V1.Class186.callSite_2.Target(CaptchaQueue_V1.Class186.callSite_2, CaptchaQueue_V1.dictionary_0[key]["browser"], concurrentDictionary["domain"].Contains("supreme") ? CaptchaQueue_V1.smethod_5(concurrentDictionary["sitekey"], concurrentDictionary["token"]) : CaptchaQueue_V1.smethod_4(concurrentDictionary["sitekey"], concurrentDictionary["taskID"], concurrentDictionary["token"], concurrentDictionary["domain"]), concurrentDictionary["domain"]);
				if (key != CaptchaQueue_V1.string_0)
				{
					if (CaptchaQueue_V1.Class186.callSite_3 == null)
					{
						CaptchaQueue_V1.Class186.callSite_3 = CallSite<Func<CallSite, object, bool>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(bool), typeof(CaptchaQueue_V1)));
					}
					if (CaptchaQueue_V1.Class186.callSite_3.Target(CaptchaQueue_V1.Class186.callSite_3, CaptchaQueue_V1.dictionary_0[CaptchaQueue_V1.string_0]["available"]))
					{
						MainWindow.mainWindow_0.Invoke(new MethodInvoker(CaptchaQueue_V1.Class182.class182_0.method_8));
					}
				}
			}
		}
	}

	// Token: 0x06000705 RID: 1797 RVA: 0x0003BA58 File Offset: 0x00039C58
	public static async void smethod_3(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		try
		{
			GClass3.smethod_0("Starting ", "Audio Solver");
			TaskAwaiter<Stream> taskAwaiter = Class138.smethod_0(jsextInvokeArgs_0.Arguments.First<object>().ToString()).GetAwaiter();
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter<Stream> taskAwaiter2;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter<Stream>);
			}
			TaskAwaiter<string> taskAwaiter3 = Class138.smethod_1(taskAwaiter.GetResult()).GetAwaiter();
			if (!taskAwaiter3.IsCompleted)
			{
				await taskAwaiter3;
				TaskAwaiter<string> taskAwaiter4;
				taskAwaiter3 = taskAwaiter4;
				taskAwaiter4 = default(TaskAwaiter<string>);
			}
			string result = taskAwaiter3.GetResult();
			GClass3.smethod_0("Received answer: " + result, "Audio Solver");
		}
		catch
		{
		}
	}

	// Token: 0x06000706 RID: 1798 RVA: 0x0003BA94 File Offset: 0x00039C94
	public static string smethod_4(string string_1, string string_2, string string_3, string string_4)
	{
		return string.Concat(new string[]
		{
			"<!DOCTYPE html>\r\n                            <html>\r\n                            <script src='https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js'></script>\r\n                            <body onload='click()'>\r\n                            <style>\r\n                            body \r\n                            {\r\n                                background-color: #19171A\r\n                            }\r\n                            </style>\r\n                            <script>function _submit(token){ submit(token, '",
			string_3,
			"'); } </script>\r\n                            <div align='center' class='g-recaptcha' data-sitekey='",
			string_1,
			"' data-theme='dark' data-callback='_submit'></div>\r\n                            <center style='color:white; font-family:Verdana;margin:20px'><hr width='40px'></center>\r\n\t\t\t\t\t\t\t<center style='color:white; font-family:Verdana;margin:10px'><b>Task ID:</b> ",
			string_2,
			"</center>\r\n\t\t\t\t\t\t\t<center style='color:white; font-family:Verdana'><b>Retailer:</b> ",
			new Uri(string_4).Host,
			"</center>\r\n                            <script type='text/javascript' src='https://www.google.com/recaptcha/api.js'></script>\r\n                            <script>function click(){$('.recaptcha-checkbox-checkmark', window.frames[0].document).click(); /*setTimeout(function(){ $('#recaptcha-audio-button', window.frames[1].document).click();}, 3000); setTimeout(function(){solveAudio($('.rc-audiochallenge-tdownload-link', window.frames[1].document).href) }, 6000)*/}</script>\r\n                            </body>\r\n                            </html>"
		});
	}

	// Token: 0x06000707 RID: 1799 RVA: 0x0000668C File Offset: 0x0000488C
	public static string smethod_5(string string_1, string string_2)
	{
		return string.Concat(new string[]
		{
			"<html>\r\n\t                        <style>\r\n\t                        body \r\n\t                        {\r\n\t                        background-color: #19171A\r\n\t                        }\r\n\t                        </style>\r\n                            <script>function _submit(captcha){ submit(captcha, '",
			string_2,
			"'); };</script>\r\n\t                        <body onclick='grecaptcha.execute();' onload='grecaptcha.execute();'>\r\n                            <div class='g-recaptcha'\r\n                                  data-sitekey='",
			string_1,
			"'\r\n                                  data-callback='_submit'\r\n                                  data-size='invisible'\r\n\t\t                          data-theme='dark'>\r\n                            </div>\r\n\r\n                            <script src='https://www.google.com/recaptcha/api.js' async defer></script>\r\n                        </html>"
		});
	}

	// Token: 0x06000708 RID: 1800 RVA: 0x000066B9 File Offset: 0x000048B9
	public static string smethod_6()
	{
		return "<!DOCTYPE html>\r\n                            <html lang='en' >\r\n\r\n                            <head>\r\n                                <meta charset='UTF-8'>\r\n                                <title>Loading circle</title>\r\n\r\n  \r\n\r\n  \r\n                            </head>\r\n                            <style>\r\n                            \r\n                            body{\r\n                                background-color: #19171A;\r\n                            }\r\n                            #loader-page {\r\n                                position: fixed;\r\n                                top: 0;\r\n                                left: 0;\r\n                                height: 100%;\r\n                                width: 100%;\r\n                                background-color: transparent;\r\n                            }\r\n\r\n                            .loader-name {\r\n                                position: absolute;\r\n                                top: 50%;\r\n                                left: 50%;\r\n                                margin-top: -10px;\r\n                                margin-left: -52px;\r\n                                font-size: 125%;\r\n                                font-family: 'Montserrat', sans-serif;\r\n                                text-transform: uppercase;\r\n                                letter-spacing: 0.1em;\r\n                                color: #fefefe;\r\n                            }\r\n\r\n                            .loader-circle {\r\n                                width: 180px;\r\n                                height: 180px;\r\n                                -webkit-box-sizing: border-box;\r\n                                        box-sizing: border-box;\r\n                                position: fixed;\r\n                                top: 50%;\r\n                                left: 50%;\r\n                                border-top: 5px solid #fefefe;\r\n                                border-bottom: 2px solid transparent;\r\n                                border-left: 2px solid transparent;\r\n                                border-right: 2px solid transparent;\r\n                                border-radius: 50%;\r\n                                margin-top: -90px;\r\n                                margin-left: -90px;\r\n                                -webkit-animation: loader 1s infinite linear;\r\n                                        animation: loader 1s infinite linear;\r\n                            }\r\n\r\n                            @-webkit-keyframes loader {\r\n                                from {\r\n                                -webkit-transform: rotate(0deg);\r\n                                        transform: rotate(0deg);\r\n                                }\r\n                                to {\r\n                                -webkit-transform: rotate(360deg);\r\n                                        transform: rotate(360deg);\r\n                                }\r\n                            }\r\n\r\n                            @keyframes loader {\r\n                                from {\r\n                                -webkit-transform: rotate(0deg);\r\n                                        transform: rotate(0deg);\r\n                                }\r\n                                to {\r\n                                -webkit-transform: rotate(360deg);\r\n                                        transform: rotate(360deg);\r\n                                }\r\n                            }\r\n\r\n\r\n                            </style>\r\n                            <body>\r\n\r\n\t                            <div class='loader-name'>Waiting</div>\r\n\t                            <div class='loader-circle'></div>\r\n                            </div>\r\n  \r\n  \r\n\r\n                            </body>\r\n\r\n                            </html>\r\n                            ";
	}

	// Token: 0x06000709 RID: 1801 RVA: 0x0003BAF0 File Offset: 0x00039CF0
	public static void smethod_7(string string_1)
	{
		CaptchaQueue_V1.dictionary_0[string_1]["available"] = true;
		if (CaptchaQueue_V1.Class189.callSite_0 == null)
		{
			CaptchaQueue_V1.Class189.callSite_0 = CallSite<Action<CallSite, object, string>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "LoadHtml", null, typeof(CaptchaQueue_V1), new CSharpArgumentInfo[]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
			}));
		}
		CaptchaQueue_V1.Class189.callSite_0.Target(CaptchaQueue_V1.Class189.callSite_0, CaptchaQueue_V1.dictionary_0[string_1]["browser"], CaptchaQueue_V1.smethod_6());
		CaptchaQueue_V1.smethod_2(null, null);
	}

	// Token: 0x0600070A RID: 1802 RVA: 0x00002C9B File Offset: 0x00000E9B
	private void method_4(object sender, BeforeContextMenuEventArgs e)
	{
		e.Menu.Items.Clear();
	}

	// Token: 0x0600070B RID: 1803 RVA: 0x00002CAD File Offset: 0x00000EAD
	public void method_5(object sender, CertificateErrorEventArgs e)
	{
		e.Continue();
	}

	// Token: 0x0600070C RID: 1804 RVA: 0x00002CB5 File Offset: 0x00000EB5
	private void close_btn_Click(object sender, EventArgs e)
	{
		base.Hide();
	}

	// Token: 0x0600070D RID: 1805 RVA: 0x00002CBD File Offset: 0x00000EBD
	private void minimise_btn_Click(object sender, EventArgs e)
	{
		base.WindowState = FormWindowState.Minimized;
	}

	// Token: 0x0600070E RID: 1806 RVA: 0x0003BB94 File Offset: 0x00039D94
	private void googlelogin_button_Click(object sender, EventArgs e)
	{
		if (CaptchaQueue_V1.Class195.callSite_0 == null)
		{
			CaptchaQueue_V1.Class195.callSite_0 = CallSite<Action<CallSite, object, string>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "LoadUrl", null, typeof(CaptchaQueue_V1), new CSharpArgumentInfo[]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
			}));
		}
		CaptchaQueue_V1.Class195.callSite_0.Target(CaptchaQueue_V1.Class195.callSite_0, CaptchaQueue_V1.dictionary_0[CaptchaQueue_V1.string_0]["browser"], "https://accounts.google.com/signin/v2/sl/pwd?service=youtube&uilel=3&continue=https%3A%2F%2Fwww.youtube.com%2Fsignin%3Fapp%3Ddesktop%26action_handle_signin%3Dtrue%26hl%3Den%26next%3D%252F%253Fgl%253DGB%2526hl%253Den-GB&passive=true&flowName=GlifWebSignIn&flowEntry=ServiceLogin");
	}

	// Token: 0x0600070F RID: 1807 RVA: 0x0003BC18 File Offset: 0x00039E18
	private void clearsession_button_Click(object sender, EventArgs e)
	{
		if (CaptchaQueue_V1.Class192.callSite_1 == null)
		{
			CaptchaQueue_V1.Class192.callSite_1 = CallSite<Action<CallSite, object, bool>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Stop", null, typeof(CaptchaQueue_V1), new CSharpArgumentInfo[]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
			}));
		}
		Action<CallSite, object, bool> target = CaptchaQueue_V1.Class192.callSite_1.Target;
		CallSite callSite_ = CaptchaQueue_V1.Class192.callSite_1;
		if (CaptchaQueue_V1.Class192.callSite_0 == null)
		{
			CaptchaQueue_V1.Class192.callSite_0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Engine", typeof(CaptchaQueue_V1), new CSharpArgumentInfo[]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
			}));
		}
		target(callSite_, CaptchaQueue_V1.Class192.callSite_0.Target(CaptchaQueue_V1.Class192.callSite_0, CaptchaQueue_V1.dictionary_0[CaptchaQueue_V1.string_0]["browser"]), true);
		if (CaptchaQueue_V1.Class192.callSite_2 == null)
		{
			CaptchaQueue_V1.Class192.callSite_2 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Dispose", null, typeof(CaptchaQueue_V1), new CSharpArgumentInfo[]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
			}));
		}
		CaptchaQueue_V1.Class192.callSite_2.Target(CaptchaQueue_V1.Class192.callSite_2, CaptchaQueue_V1.dictionary_0[CaptchaQueue_V1.string_0]["browser"]);
		if (CaptchaQueue_V1.Class192.callSite_3 == null)
		{
			CaptchaQueue_V1.Class192.callSite_3 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Engine", typeof(CaptchaQueue_V1), new CSharpArgumentInfo[]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
			}));
		}
		object arg = CaptchaQueue_V1.Class192.callSite_3.Target(CaptchaQueue_V1.Class192.callSite_3, CaptchaQueue_V1.dictionary_0[CaptchaQueue_V1.string_0]["browser"]);
		BrowserOptions options = new BrowserOptions
		{
			EnableXSSAuditor = new bool?(false),
			EnableWebSecurity = new bool?(false)
		};
		WebView webView = new WebView();
		webView.SetOptions(options);
		WebView webView2 = webView;
		if (CaptchaQueue_V1.Class192.callSite_4 == null)
		{
			CaptchaQueue_V1.Class192.callSite_4 = CallSite<Func<CallSite, object, Engine>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(Engine), typeof(CaptchaQueue_V1)));
		}
		webView2.Engine = CaptchaQueue_V1.Class192.callSite_4.Target(CaptchaQueue_V1.Class192.callSite_4, arg);
		webView.Engine.AllowRestart = true;
		if (CaptchaQueue_V1.Class192.callSite_6 == null)
		{
			CaptchaQueue_V1.Class192.callSite_6 = CallSite<Action<CallSite, WebView, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Create", null, typeof(CaptchaQueue_V1), new CSharpArgumentInfo[]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
			}));
		}
		Action<CallSite, WebView, object> target2 = CaptchaQueue_V1.Class192.callSite_6.Target;
		CallSite callSite_2 = CaptchaQueue_V1.Class192.callSite_6;
		WebView arg2 = webView;
		if (CaptchaQueue_V1.Class192.callSite_5 == null)
		{
			CaptchaQueue_V1.Class192.callSite_5 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Handle", typeof(CaptchaQueue_V1), new CSharpArgumentInfo[]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
			}));
		}
		target2(callSite_2, arg2, CaptchaQueue_V1.Class192.callSite_5.Target(CaptchaQueue_V1.Class192.callSite_5, CaptchaQueue_V1.dictionary_0[CaptchaQueue_V1.string_0]["panel"]));
		webView.RegisterJSExtensionFunction("submit", new JSExtInvokeHandler(this.method_3));
		webView.RegisterJSExtensionFunction("solveAudio", new JSExtInvokeHandler(CaptchaQueue_V1.smethod_3));
		webView.CertificateError += this.method_5;
		webView.BeforeContextMenu += this.method_4;
		CaptchaQueue_V1.dictionary_0[CaptchaQueue_V1.string_0]["browser"] = webView;
		this.reloadCaptcha_Click(null, null);
	}

	// Token: 0x06000710 RID: 1808 RVA: 0x000066C0 File Offset: 0x000048C0
	private void method_6()
	{
		this.solverLine1.Visible = false;
		this.solverLine2.Visible = false;
		this.solverLine3.Visible = false;
		this.solverLine4.Visible = false;
	}

	// Token: 0x06000711 RID: 1809 RVA: 0x0003BF5C File Offset: 0x0003A15C
	private void solverButton1_Click(object sender, EventArgs e)
	{
		this.method_6();
		this.solverLine1.Visible = true;
		this.browserPanel.Controls.Clear();
		if (CaptchaQueue_V1.Class198.callSite_0 == null)
		{
			CaptchaQueue_V1.Class198.callSite_0 = CallSite<Action<CallSite, Control.ControlCollection, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", null, typeof(CaptchaQueue_V1), new CSharpArgumentInfo[]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
			}));
		}
		CaptchaQueue_V1.Class198.callSite_0.Target(CaptchaQueue_V1.Class198.callSite_0, this.browserPanel.Controls, CaptchaQueue_V1.dictionary_0[this.solverButton1.ButtonText]["panel"]);
		CaptchaQueue_V1.string_0 = this.solverButton1.ButtonText;
		if (CaptchaQueue_V1.Class198.callSite_2 == null)
		{
			CaptchaQueue_V1.Class198.callSite_2 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(CaptchaQueue_V1), new CSharpArgumentInfo[]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
			}));
		}
		Func<CallSite, object, bool> target = CaptchaQueue_V1.Class198.callSite_2.Target;
		CallSite callSite_ = CaptchaQueue_V1.Class198.callSite_2;
		if (CaptchaQueue_V1.Class198.callSite_1 == null)
		{
			CaptchaQueue_V1.Class198.callSite_1 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.NotEqual, typeof(CaptchaQueue_V1), new CSharpArgumentInfo[]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
			}));
		}
		if (target(callSite_, CaptchaQueue_V1.Class198.callSite_1.Target(CaptchaQueue_V1.Class198.callSite_1, CaptchaQueue_V1.dictionary_0[CaptchaQueue_V1.string_0]["proxy"], null)))
		{
			Control control = this.proxyInput;
			if (CaptchaQueue_V1.Class198.callSite_3 == null)
			{
				CaptchaQueue_V1.Class198.callSite_3 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(CaptchaQueue_V1)));
			}
			control.Text = CaptchaQueue_V1.Class198.callSite_3.Target(CaptchaQueue_V1.Class198.callSite_3, CaptchaQueue_V1.dictionary_0[CaptchaQueue_V1.string_0]["proxy"]);
			return;
		}
		this.proxyInput.Text = "Proxy (IP:Port:Username:Password)";
	}

	// Token: 0x06000712 RID: 1810 RVA: 0x0003C148 File Offset: 0x0003A348
	private void solverButton2_Click(object sender, EventArgs e)
	{
		this.method_6();
		this.solverLine2.Visible = true;
		this.browserPanel.Controls.Clear();
		if (CaptchaQueue_V1.Class201.callSite_0 == null)
		{
			CaptchaQueue_V1.Class201.callSite_0 = CallSite<Action<CallSite, Control.ControlCollection, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", null, typeof(CaptchaQueue_V1), new CSharpArgumentInfo[]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
			}));
		}
		CaptchaQueue_V1.Class201.callSite_0.Target(CaptchaQueue_V1.Class201.callSite_0, this.browserPanel.Controls, CaptchaQueue_V1.dictionary_0[this.solverButton2.ButtonText]["panel"]);
		CaptchaQueue_V1.string_0 = this.solverButton2.ButtonText;
		if (CaptchaQueue_V1.Class201.callSite_2 == null)
		{
			CaptchaQueue_V1.Class201.callSite_2 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(CaptchaQueue_V1), new CSharpArgumentInfo[]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
			}));
		}
		Func<CallSite, object, bool> target = CaptchaQueue_V1.Class201.callSite_2.Target;
		CallSite callSite_ = CaptchaQueue_V1.Class201.callSite_2;
		if (CaptchaQueue_V1.Class201.callSite_1 == null)
		{
			CaptchaQueue_V1.Class201.callSite_1 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.NotEqual, typeof(CaptchaQueue_V1), new CSharpArgumentInfo[]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
			}));
		}
		if (target(callSite_, CaptchaQueue_V1.Class201.callSite_1.Target(CaptchaQueue_V1.Class201.callSite_1, CaptchaQueue_V1.dictionary_0[CaptchaQueue_V1.string_0]["proxy"], null)))
		{
			Control control = this.proxyInput;
			if (CaptchaQueue_V1.Class201.callSite_3 == null)
			{
				CaptchaQueue_V1.Class201.callSite_3 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(CaptchaQueue_V1)));
			}
			control.Text = CaptchaQueue_V1.Class201.callSite_3.Target(CaptchaQueue_V1.Class201.callSite_3, CaptchaQueue_V1.dictionary_0[CaptchaQueue_V1.string_0]["proxy"]);
			return;
		}
		this.proxyInput.Text = "Proxy (IP:Port:Username:Password)";
	}

	// Token: 0x06000713 RID: 1811 RVA: 0x0003C334 File Offset: 0x0003A534
	private void solverButton3_Click(object sender, EventArgs e)
	{
		this.method_6();
		this.solverLine3.Visible = true;
		this.browserPanel.Controls.Clear();
		if (CaptchaQueue_V1.Class184.callSite_0 == null)
		{
			CaptchaQueue_V1.Class184.callSite_0 = CallSite<Action<CallSite, Control.ControlCollection, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", null, typeof(CaptchaQueue_V1), new CSharpArgumentInfo[]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
			}));
		}
		CaptchaQueue_V1.Class184.callSite_0.Target(CaptchaQueue_V1.Class184.callSite_0, this.browserPanel.Controls, CaptchaQueue_V1.dictionary_0[this.solverButton3.ButtonText]["panel"]);
		CaptchaQueue_V1.string_0 = this.solverButton3.ButtonText;
		if (CaptchaQueue_V1.Class184.callSite_2 == null)
		{
			CaptchaQueue_V1.Class184.callSite_2 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(CaptchaQueue_V1), new CSharpArgumentInfo[]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
			}));
		}
		Func<CallSite, object, bool> target = CaptchaQueue_V1.Class184.callSite_2.Target;
		CallSite callSite_ = CaptchaQueue_V1.Class184.callSite_2;
		if (CaptchaQueue_V1.Class184.callSite_1 == null)
		{
			CaptchaQueue_V1.Class184.callSite_1 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.NotEqual, typeof(CaptchaQueue_V1), new CSharpArgumentInfo[]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
			}));
		}
		if (target(callSite_, CaptchaQueue_V1.Class184.callSite_1.Target(CaptchaQueue_V1.Class184.callSite_1, CaptchaQueue_V1.dictionary_0[CaptchaQueue_V1.string_0]["proxy"], null)))
		{
			Control control = this.proxyInput;
			if (CaptchaQueue_V1.Class184.callSite_3 == null)
			{
				CaptchaQueue_V1.Class184.callSite_3 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(CaptchaQueue_V1)));
			}
			control.Text = CaptchaQueue_V1.Class184.callSite_3.Target(CaptchaQueue_V1.Class184.callSite_3, CaptchaQueue_V1.dictionary_0[CaptchaQueue_V1.string_0]["proxy"]);
			return;
		}
		this.proxyInput.Text = "Proxy (IP:Port:Username:Password)";
	}

	// Token: 0x06000714 RID: 1812 RVA: 0x0003C520 File Offset: 0x0003A720
	private void solverButton4_Click(object sender, EventArgs e)
	{
		this.method_6();
		this.solverLine4.Visible = true;
		this.browserPanel.Controls.Clear();
		if (CaptchaQueue_V1.Class187.callSite_0 == null)
		{
			CaptchaQueue_V1.Class187.callSite_0 = CallSite<Action<CallSite, Control.ControlCollection, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", null, typeof(CaptchaQueue_V1), new CSharpArgumentInfo[]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
			}));
		}
		CaptchaQueue_V1.Class187.callSite_0.Target(CaptchaQueue_V1.Class187.callSite_0, this.browserPanel.Controls, CaptchaQueue_V1.dictionary_0[this.solverButton4.ButtonText]["panel"]);
		CaptchaQueue_V1.string_0 = this.solverButton4.ButtonText;
		if (CaptchaQueue_V1.Class187.callSite_2 == null)
		{
			CaptchaQueue_V1.Class187.callSite_2 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(CaptchaQueue_V1), new CSharpArgumentInfo[]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
			}));
		}
		Func<CallSite, object, bool> target = CaptchaQueue_V1.Class187.callSite_2.Target;
		CallSite callSite_ = CaptchaQueue_V1.Class187.callSite_2;
		if (CaptchaQueue_V1.Class187.callSite_1 == null)
		{
			CaptchaQueue_V1.Class187.callSite_1 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.NotEqual, typeof(CaptchaQueue_V1), new CSharpArgumentInfo[]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
			}));
		}
		if (target(callSite_, CaptchaQueue_V1.Class187.callSite_1.Target(CaptchaQueue_V1.Class187.callSite_1, CaptchaQueue_V1.dictionary_0[CaptchaQueue_V1.string_0]["proxy"], null)))
		{
			Control control = this.proxyInput;
			if (CaptchaQueue_V1.Class187.callSite_3 == null)
			{
				CaptchaQueue_V1.Class187.callSite_3 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(CaptchaQueue_V1)));
			}
			control.Text = CaptchaQueue_V1.Class187.callSite_3.Target(CaptchaQueue_V1.Class187.callSite_3, CaptchaQueue_V1.dictionary_0[CaptchaQueue_V1.string_0]["proxy"]);
			return;
		}
		this.proxyInput.Text = "Proxy (IP:Port:Username:Password)";
	}

	// Token: 0x06000715 RID: 1813 RVA: 0x0003C70C File Offset: 0x0003A90C
	private void nextTabButton_Click(object sender, EventArgs e)
	{
		this.method_6();
		int num = (CaptchaQueue_V1.dictionary_0.Count<KeyValuePair<string, Dictionary<string, object>>>() + 3) / 4;
		this.int_0++;
		if (this.int_0 >= num)
		{
			this.int_0 = 0;
		}
		this.method_9(this.int_0);
	}

	// Token: 0x06000716 RID: 1814 RVA: 0x0003C758 File Offset: 0x0003A958
	private void method_7()
	{
		List<string> list = CaptchaQueue_V1.dictionary_0.Select(new Func<KeyValuePair<string, Dictionary<string, object>>, string>(CaptchaQueue_V1.Class182.class182_0.method_9)).OrderBy(new Func<string, short>(CaptchaQueue_V1.Class182.class182_0.method_10)).ToList<string>();
		KeyValuePair<string, Dictionary<string, object>> keyValuePair = CaptchaQueue_V1.dictionary_0.FirstOrDefault(new Func<KeyValuePair<string, Dictionary<string, object>>, bool>(CaptchaQueue_V1.Class182.class182_0.method_11));
		if (keyValuePair.Value == null)
		{
			return;
		}
		int num = list.IndexOf(keyValuePair.Key);
		int num2 = (CaptchaQueue_V1.dictionary_0.Count<KeyValuePair<string, Dictionary<string, object>>>() + 3) / 4;
		int int_ = num / 4;
		this.method_9(int_);
		switch (num % 4)
		{
		case 0:
			this.solverButton1_Click(null, null);
			return;
		case 1:
			this.solverButton2_Click(null, null);
			return;
		case 2:
			this.solverButton3_Click(null, null);
			return;
		case 3:
			this.solverButton4_Click(null, null);
			return;
		default:
			return;
		}
	}

	// Token: 0x06000717 RID: 1815 RVA: 0x0003C850 File Offset: 0x0003AA50
	private void method_8()
	{
		string buttonText = this.solverButton1.ButtonText;
		this.method_9(this.int_0);
		if (CaptchaQueue_V1.string_0 == buttonText)
		{
			CaptchaQueue_V1.string_0 = this.solverButton1.ButtonText;
			this.method_9(this.int_0);
			this.solverButton1_Click(null, null);
		}
	}

	// Token: 0x06000718 RID: 1816 RVA: 0x0003C8A8 File Offset: 0x0003AAA8
	private void method_9(int int_1)
	{
		this.int_0 = int_1;
		List<string> list = CaptchaQueue_V1.dictionary_0.Select(new Func<KeyValuePair<string, Dictionary<string, object>>, string>(CaptchaQueue_V1.Class182.class182_0.method_12)).ToList<string>().OrderBy(new Func<string, short>(CaptchaQueue_V1.Class182.class182_0.method_13)).ToList<string>();
		list = list.Skip(int_1 * 4).ToList<string>();
		int num = list.Count<string>();
		if (num <= 0)
		{
			this.int_0--;
			this.method_9(this.int_0);
			return;
		}
		this.solverButton1.ButtonText = list[0];
		this.solverButton1.Visible = true;
		this.solverLine1.Visible = (list[0] == CaptchaQueue_V1.string_0);
		if (num > 1)
		{
			this.solverButton2.ButtonText = list[1];
			this.solverButton2.Visible = true;
			this.solverLine2.Visible = (list[1] == CaptchaQueue_V1.string_0);
			this.closeButton2.Visible = true;
			this.closeButton2.BringToFront();
		}
		else
		{
			this.solverButton2.ButtonText = string.Empty;
			this.solverButton2.Visible = false;
			this.closeButton2.Visible = false;
			this.solverLine2.Visible = false;
		}
		if (num > 2)
		{
			this.solverButton3.ButtonText = list[2];
			this.solverButton3.Visible = true;
			this.solverLine3.Visible = (list[2] == CaptchaQueue_V1.string_0);
			this.closeButton3.Visible = true;
			this.closeButton3.BringToFront();
		}
		else
		{
			this.solverButton3.ButtonText = string.Empty;
			this.solverButton3.Visible = false;
			this.closeButton3.Visible = false;
			this.solverLine3.Visible = false;
		}
		if (num > 3)
		{
			this.solverButton4.ButtonText = list[3];
			this.solverButton4.Visible = true;
			this.solverLine4.Visible = (list[3] == CaptchaQueue_V1.string_0);
			this.closeButton4.Visible = true;
			this.closeButton4.BringToFront();
			return;
		}
		this.solverButton4.ButtonText = string.Empty;
		this.solverButton4.Visible = false;
		this.closeButton4.Visible = false;
		this.solverLine4.Visible = false;
	}

	// Token: 0x06000719 RID: 1817 RVA: 0x0003CB28 File Offset: 0x0003AD28
	private void addSolverButton_Click(object sender, EventArgs e)
	{
		this.method_0(null, null);
		int int_ = (CaptchaQueue_V1.dictionary_0.Count<KeyValuePair<string, Dictionary<string, object>>>() + 3) / 4 - 1;
		this.method_9(int_);
	}

	// Token: 0x0600071A RID: 1818 RVA: 0x0003CB58 File Offset: 0x0003AD58
	private void reloadCaptcha_Click(object sender, EventArgs e)
	{
		ConcurrentDictionary<string, string> concurrentDictionary = CaptchaQueue_V1.list_0.Where(new Func<ConcurrentDictionary<string, string>, bool>(CaptchaQueue_V1.Class182.class182_0.method_14)).FirstOrDefault<ConcurrentDictionary<string, string>>();
		if (concurrentDictionary != null)
		{
			concurrentDictionary["solving"] = "false";
		}
		CaptchaQueue_V1.smethod_7(CaptchaQueue_V1.string_0);
		CaptchaQueue_V1.smethod_2(null, null);
	}

	// Token: 0x0600071B RID: 1819 RVA: 0x000066F2 File Offset: 0x000048F2
	private void method_10(object sender, EventArgs e)
	{
		if (this.proxyInput.Text.Contains("Proxy"))
		{
			this.proxyInput.Text = this.proxyInput.Text.Replace("Proxy (IP:Port:Username:Password)", string.Empty);
		}
	}

	// Token: 0x0600071C RID: 1820 RVA: 0x0003CBB8 File Offset: 0x0003ADB8
	private void method_11(ConcurrentDictionary<string, string> concurrentDictionary_1)
	{
		concurrentDictionary_1["solving"] = "false";
		CaptchaQueue_V1.smethod_2(null, null);
		MainWindow.mainWindow_0.Invoke(new MethodInvoker(CaptchaQueue_V1.Class182.class182_0.method_15));
	}

	// Token: 0x0600071D RID: 1821 RVA: 0x0003CC08 File Offset: 0x0003AE08
	private void closeButton1_Click(object sender, EventArgs e)
	{
		CaptchaQueue_V1.Class188 @class = new CaptchaQueue_V1.Class188();
		if (CaptchaQueue_V1.dictionary_0.Count<KeyValuePair<string, Dictionary<string, object>>>() == 1)
		{
			return;
		}
		if (CaptchaQueue_V1.Class196.callSite_1 == null)
		{
			CaptchaQueue_V1.Class196.callSite_1 = CallSite<Action<CallSite, object, bool>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Stop", null, typeof(CaptchaQueue_V1), new CSharpArgumentInfo[]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
			}));
		}
		Action<CallSite, object, bool> target = CaptchaQueue_V1.Class196.callSite_1.Target;
		CallSite callSite_ = CaptchaQueue_V1.Class196.callSite_1;
		if (CaptchaQueue_V1.Class196.callSite_0 == null)
		{
			CaptchaQueue_V1.Class196.callSite_0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Engine", typeof(CaptchaQueue_V1), new CSharpArgumentInfo[]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
			}));
		}
		target(callSite_, CaptchaQueue_V1.Class196.callSite_0.Target(CaptchaQueue_V1.Class196.callSite_0, CaptchaQueue_V1.dictionary_0[this.solverButton1.ButtonText]["browser"]), false);
		if (CaptchaQueue_V1.Class196.callSite_2 == null)
		{
			CaptchaQueue_V1.Class196.callSite_2 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Dispose", null, typeof(CaptchaQueue_V1), new CSharpArgumentInfo[]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
			}));
		}
		CaptchaQueue_V1.Class196.callSite_2.Target(CaptchaQueue_V1.Class196.callSite_2, CaptchaQueue_V1.dictionary_0[this.solverButton1.ButtonText]["browser"]);
		CaptchaQueue_V1.dictionary_0.Remove(this.solverButton1.ButtonText);
		this.method_2();
		@class.string_0 = this.solverButton1.ButtonText;
		this.method_8();
		ConcurrentDictionary<string, string> concurrentDictionary = CaptchaQueue_V1.list_0.FirstOrDefault(new Func<ConcurrentDictionary<string, string>, bool>(@class.method_0));
		if (concurrentDictionary != null)
		{
			this.method_11(concurrentDictionary);
		}
	}

	// Token: 0x0600071E RID: 1822 RVA: 0x0003CDB0 File Offset: 0x0003AFB0
	private void closeButton2_Click(object sender, EventArgs e)
	{
		CaptchaQueue_V1.Class194 @class = new CaptchaQueue_V1.Class194();
		if (CaptchaQueue_V1.dictionary_0.Count<KeyValuePair<string, Dictionary<string, object>>>() == 1)
		{
			return;
		}
		if (CaptchaQueue_V1.Class193.callSite_1 == null)
		{
			CaptchaQueue_V1.Class193.callSite_1 = CallSite<Action<CallSite, object, bool>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Stop", null, typeof(CaptchaQueue_V1), new CSharpArgumentInfo[]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
			}));
		}
		Action<CallSite, object, bool> target = CaptchaQueue_V1.Class193.callSite_1.Target;
		CallSite callSite_ = CaptchaQueue_V1.Class193.callSite_1;
		if (CaptchaQueue_V1.Class193.callSite_0 == null)
		{
			CaptchaQueue_V1.Class193.callSite_0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Engine", typeof(CaptchaQueue_V1), new CSharpArgumentInfo[]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
			}));
		}
		target(callSite_, CaptchaQueue_V1.Class193.callSite_0.Target(CaptchaQueue_V1.Class193.callSite_0, CaptchaQueue_V1.dictionary_0[this.solverButton2.ButtonText]["browser"]), false);
		if (CaptchaQueue_V1.Class193.callSite_2 == null)
		{
			CaptchaQueue_V1.Class193.callSite_2 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Dispose", null, typeof(CaptchaQueue_V1), new CSharpArgumentInfo[]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
			}));
		}
		CaptchaQueue_V1.Class193.callSite_2.Target(CaptchaQueue_V1.Class193.callSite_2, CaptchaQueue_V1.dictionary_0[this.solverButton2.ButtonText]["browser"]);
		CaptchaQueue_V1.dictionary_0.Remove(this.solverButton2.ButtonText);
		this.method_2();
		@class.string_0 = this.solverButton2.ButtonText;
		this.method_8();
		ConcurrentDictionary<string, string> concurrentDictionary = CaptchaQueue_V1.list_0.FirstOrDefault(new Func<ConcurrentDictionary<string, string>, bool>(@class.method_0));
		if (concurrentDictionary != null)
		{
			this.method_11(concurrentDictionary);
		}
	}

	// Token: 0x0600071F RID: 1823 RVA: 0x0003CF58 File Offset: 0x0003B158
	private void closeButton3_Click(object sender, EventArgs e)
	{
		CaptchaQueue_V1.Class191 @class = new CaptchaQueue_V1.Class191();
		if (CaptchaQueue_V1.dictionary_0.Count<KeyValuePair<string, Dictionary<string, object>>>() == 1)
		{
			return;
		}
		if (CaptchaQueue_V1.Class199.callSite_1 == null)
		{
			CaptchaQueue_V1.Class199.callSite_1 = CallSite<Action<CallSite, object, bool>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Stop", null, typeof(CaptchaQueue_V1), new CSharpArgumentInfo[]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
			}));
		}
		Action<CallSite, object, bool> target = CaptchaQueue_V1.Class199.callSite_1.Target;
		CallSite callSite_ = CaptchaQueue_V1.Class199.callSite_1;
		if (CaptchaQueue_V1.Class199.callSite_0 == null)
		{
			CaptchaQueue_V1.Class199.callSite_0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Engine", typeof(CaptchaQueue_V1), new CSharpArgumentInfo[]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
			}));
		}
		target(callSite_, CaptchaQueue_V1.Class199.callSite_0.Target(CaptchaQueue_V1.Class199.callSite_0, CaptchaQueue_V1.dictionary_0[this.solverButton3.ButtonText]["browser"]), false);
		if (CaptchaQueue_V1.Class199.callSite_2 == null)
		{
			CaptchaQueue_V1.Class199.callSite_2 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Dispose", null, typeof(CaptchaQueue_V1), new CSharpArgumentInfo[]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
			}));
		}
		CaptchaQueue_V1.Class199.callSite_2.Target(CaptchaQueue_V1.Class199.callSite_2, CaptchaQueue_V1.dictionary_0[this.solverButton3.ButtonText]["browser"]);
		CaptchaQueue_V1.dictionary_0.Remove(this.solverButton3.ButtonText);
		this.method_2();
		@class.string_0 = this.solverButton3.ButtonText;
		this.method_8();
		ConcurrentDictionary<string, string> concurrentDictionary = CaptchaQueue_V1.list_0.FirstOrDefault(new Func<ConcurrentDictionary<string, string>, bool>(@class.method_0));
		if (concurrentDictionary != null)
		{
			this.method_11(concurrentDictionary);
		}
	}

	// Token: 0x06000720 RID: 1824 RVA: 0x0003D100 File Offset: 0x0003B300
	private void closeButton4_Click(object sender, EventArgs e)
	{
		CaptchaQueue_V1.Class197 @class = new CaptchaQueue_V1.Class197();
		if (CaptchaQueue_V1.dictionary_0.Count<KeyValuePair<string, Dictionary<string, object>>>() == 1)
		{
			return;
		}
		if (CaptchaQueue_V1.Class202.callSite_1 == null)
		{
			CaptchaQueue_V1.Class202.callSite_1 = CallSite<Action<CallSite, object, bool>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Stop", null, typeof(CaptchaQueue_V1), new CSharpArgumentInfo[]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
			}));
		}
		Action<CallSite, object, bool> target = CaptchaQueue_V1.Class202.callSite_1.Target;
		CallSite callSite_ = CaptchaQueue_V1.Class202.callSite_1;
		if (CaptchaQueue_V1.Class202.callSite_0 == null)
		{
			CaptchaQueue_V1.Class202.callSite_0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Engine", typeof(CaptchaQueue_V1), new CSharpArgumentInfo[]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
			}));
		}
		target(callSite_, CaptchaQueue_V1.Class202.callSite_0.Target(CaptchaQueue_V1.Class202.callSite_0, CaptchaQueue_V1.dictionary_0[this.solverButton4.ButtonText]["browser"]), false);
		if (CaptchaQueue_V1.Class202.callSite_2 == null)
		{
			CaptchaQueue_V1.Class202.callSite_2 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Dispose", null, typeof(CaptchaQueue_V1), new CSharpArgumentInfo[]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
			}));
		}
		CaptchaQueue_V1.Class202.callSite_2.Target(CaptchaQueue_V1.Class202.callSite_2, CaptchaQueue_V1.dictionary_0[this.solverButton4.ButtonText]["browser"]);
		CaptchaQueue_V1.dictionary_0.Remove(this.solverButton4.ButtonText);
		this.method_2();
		@class.string_0 = this.solverButton4.ButtonText;
		this.method_8();
		ConcurrentDictionary<string, string> concurrentDictionary = CaptchaQueue_V1.list_0.FirstOrDefault(new Func<ConcurrentDictionary<string, string>, bool>(@class.method_0));
		if (concurrentDictionary != null)
		{
			this.method_11(concurrentDictionary);
		}
	}

	// Token: 0x06000721 RID: 1825
	[DllImport("user32.dll")]
	public static extern int SendMessage(IntPtr intptr_0, int int_1, int int_2, int int_3);

	// Token: 0x06000722 RID: 1826
	[DllImport("user32.dll")]
	public static extern bool ReleaseCapture();

	// Token: 0x06000723 RID: 1827 RVA: 0x00006730 File Offset: 0x00004930
	private void top_panel_MouseMove(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
			CaptchaQueue_V1.ReleaseCapture();
			CaptchaQueue_V1.SendMessage(base.Handle, 161, 2, 0);
		}
	}

	// Token: 0x06000724 RID: 1828 RVA: 0x00006758 File Offset: 0x00004958
	private void method_12(object sender, MouseEventArgs e)
	{
		Console.WriteLine("mouse down");
	}

	// Token: 0x0400047B RID: 1147
	public static bool bool_0;

	// Token: 0x0400047C RID: 1148
	public static List<ConcurrentDictionary<string, string>> list_0 = new List<ConcurrentDictionary<string, string>>();

	// Token: 0x0400047D RID: 1149
	public static ConcurrentDictionary<string, string> concurrentDictionary_0 = new ConcurrentDictionary<string, string>();

	// Token: 0x0400047E RID: 1150
	public static SoundPlayer soundPlayer_0 = new SoundPlayer("audio/ding.wav");

	// Token: 0x0400047F RID: 1151
	public Google_Login google_Login_0;

	// Token: 0x04000480 RID: 1152
	[Dynamic(new bool[]
	{
		false,
		false,
		false,
		false,
		true
	})]
	private static Dictionary<string, Dictionary<string, dynamic>> dictionary_0 = new Dictionary<string, Dictionary<string, object>>();

	// Token: 0x04000481 RID: 1153
	private static string string_0;

	// Token: 0x04000482 RID: 1154
	private int int_0;

	// Token: 0x02000113 RID: 275
	[Serializable]
	private sealed class Class182
	{
		// Token: 0x06000729 RID: 1833 RVA: 0x0000678F File Offset: 0x0000498F
		internal void method_0()
		{
			MainWindow.smethod_2(null, null);
		}

		// Token: 0x0600072A RID: 1834 RVA: 0x00006798 File Offset: 0x00004998
		internal void method_1()
		{
			MainWindow.captchaQueue_V1_0.method_7();
		}

		// Token: 0x0600072B RID: 1835 RVA: 0x00006798 File Offset: 0x00004998
		internal void method_2()
		{
			MainWindow.captchaQueue_V1_0.method_7();
		}

		// Token: 0x0600072C RID: 1836 RVA: 0x00002D41 File Offset: 0x00000F41
		internal bool method_3(ConcurrentDictionary<string, string> concurrentDictionary_0)
		{
			return concurrentDictionary_0["solving"] == "false";
		}

		// Token: 0x0600072D RID: 1837 RVA: 0x0003F4B0 File Offset: 0x0003D6B0
		internal bool method_4(KeyValuePair<string, Dictionary<string, dynamic>> keyValuePair_0)
		{
			if (CaptchaQueue_V1.Class186.callSite_0 == null)
			{
				CaptchaQueue_V1.Class186.callSite_0 = CallSite<Func<CallSite, object, bool>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(bool), typeof(CaptchaQueue_V1)));
			}
			return CaptchaQueue_V1.Class186.callSite_0.Target(CaptchaQueue_V1.Class186.callSite_0, keyValuePair_0.Value["available"]);
		}

		// Token: 0x0600072E RID: 1838 RVA: 0x00002D41 File Offset: 0x00000F41
		internal bool method_5(ConcurrentDictionary<string, string> concurrentDictionary_0)
		{
			return concurrentDictionary_0["solving"] == "false";
		}

		// Token: 0x0600072F RID: 1839 RVA: 0x000067A4 File Offset: 0x000049A4
		internal short method_6(KeyValuePair<string, Dictionary<string, dynamic>> keyValuePair_0)
		{
			return Convert.ToInt16(keyValuePair_0.Key.Replace("Solver ", string.Empty));
		}

		// Token: 0x06000730 RID: 1840 RVA: 0x0003F510 File Offset: 0x0003D710
		internal bool method_7(KeyValuePair<string, Dictionary<string, dynamic>> keyValuePair_0)
		{
			if (CaptchaQueue_V1.Class186.callSite_1 == null)
			{
				CaptchaQueue_V1.Class186.callSite_1 = CallSite<Func<CallSite, object, bool>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(bool), typeof(CaptchaQueue_V1)));
			}
			return CaptchaQueue_V1.Class186.callSite_1.Target(CaptchaQueue_V1.Class186.callSite_1, keyValuePair_0.Value["available"]);
		}

		// Token: 0x06000731 RID: 1841 RVA: 0x00006798 File Offset: 0x00004998
		internal void method_8()
		{
			MainWindow.captchaQueue_V1_0.method_7();
		}

		// Token: 0x06000732 RID: 1842 RVA: 0x000067C1 File Offset: 0x000049C1
		internal string method_9(KeyValuePair<string, Dictionary<string, dynamic>> keyValuePair_0)
		{
			return keyValuePair_0.Key;
		}

		// Token: 0x06000733 RID: 1843 RVA: 0x000067CA File Offset: 0x000049CA
		internal short method_10(string string_0)
		{
			return Convert.ToInt16(string_0.Replace("Solver ", string.Empty));
		}

		// Token: 0x06000734 RID: 1844 RVA: 0x0003F570 File Offset: 0x0003D770
		internal bool method_11(KeyValuePair<string, Dictionary<string, dynamic>> keyValuePair_0)
		{
			if (CaptchaQueue_V1.Class190.callSite_0 == null)
			{
				CaptchaQueue_V1.Class190.callSite_0 = CallSite<Func<CallSite, object, bool>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(bool), typeof(CaptchaQueue_V1)));
			}
			return !CaptchaQueue_V1.Class190.callSite_0.Target(CaptchaQueue_V1.Class190.callSite_0, keyValuePair_0.Value["available"]);
		}

		// Token: 0x06000735 RID: 1845 RVA: 0x000067C1 File Offset: 0x000049C1
		internal string method_12(KeyValuePair<string, Dictionary<string, dynamic>> keyValuePair_0)
		{
			return keyValuePair_0.Key;
		}

		// Token: 0x06000736 RID: 1846 RVA: 0x000067CA File Offset: 0x000049CA
		internal short method_13(string string_0)
		{
			return Convert.ToInt16(string_0.Replace("Solver ", string.Empty));
		}

		// Token: 0x06000737 RID: 1847 RVA: 0x000067E1 File Offset: 0x000049E1
		internal bool method_14(ConcurrentDictionary<string, string> concurrentDictionary_0)
		{
			return concurrentDictionary_0["browser"] == CaptchaQueue_V1.string_0 && concurrentDictionary_0["solving"] == "true";
		}

		// Token: 0x06000738 RID: 1848 RVA: 0x00006798 File Offset: 0x00004998
		internal void method_15()
		{
			MainWindow.captchaQueue_V1_0.method_7();
		}

		// Token: 0x040004A1 RID: 1185
		public static readonly CaptchaQueue_V1.Class182 class182_0 = new CaptchaQueue_V1.Class182();

		// Token: 0x040004A2 RID: 1186
		public static MethodInvoker methodInvoker_0;

		// Token: 0x040004A3 RID: 1187
		public static MethodInvoker methodInvoker_1;

		// Token: 0x040004A4 RID: 1188
		public static MethodInvoker methodInvoker_2;

		// Token: 0x040004A5 RID: 1189
		public static Func<ConcurrentDictionary<string, string>, bool> func_0;

		// Token: 0x040004A6 RID: 1190
		public static Func<KeyValuePair<string, Dictionary<string, object>>, bool> func_1;

		// Token: 0x040004A7 RID: 1191
		public static Func<ConcurrentDictionary<string, string>, bool> func_2;

		// Token: 0x040004A8 RID: 1192
		public static Func<KeyValuePair<string, Dictionary<string, object>>, short> func_3;

		// Token: 0x040004A9 RID: 1193
		public static Func<KeyValuePair<string, Dictionary<string, object>>, bool> func_4;

		// Token: 0x040004AA RID: 1194
		public static MethodInvoker methodInvoker_3;

		// Token: 0x040004AB RID: 1195
		public static Func<KeyValuePair<string, Dictionary<string, object>>, string> func_5;

		// Token: 0x040004AC RID: 1196
		public static Func<string, short> func_6;

		// Token: 0x040004AD RID: 1197
		public static Func<KeyValuePair<string, Dictionary<string, object>>, bool> func_7;

		// Token: 0x040004AE RID: 1198
		public static Func<KeyValuePair<string, Dictionary<string, object>>, string> func_8;

		// Token: 0x040004AF RID: 1199
		public static Func<string, short> func_9;

		// Token: 0x040004B0 RID: 1200
		public static Func<ConcurrentDictionary<string, string>, bool> func_10;

		// Token: 0x040004B1 RID: 1201
		public static MethodInvoker methodInvoker_4;
	}

	// Token: 0x02000114 RID: 276
	private static class Class183
	{
		// Token: 0x040004B2 RID: 1202
		public static CallSite<Func<CallSite, object, object>> callSite_0;

		// Token: 0x040004B3 RID: 1203
		public static CallSite<Func<CallSite, object, object>> callSite_1;

		// Token: 0x040004B4 RID: 1204
		public static CallSite<Func<CallSite, object, ProxyInfo, object>> callSite_2;

		// Token: 0x040004B5 RID: 1205
		public static CallSite<Func<CallSite, object, object>> callSite_3;

		// Token: 0x040004B6 RID: 1206
		public static CallSite<Func<CallSite, object, ProxyInfo, object>> callSite_4;

		// Token: 0x040004B7 RID: 1207
		public static CallSite<Func<CallSite, object, object>> callSite_5;

		// Token: 0x040004B8 RID: 1208
		public static CallSite<Action<CallSite, object, bool>> callSite_6;

		// Token: 0x040004B9 RID: 1209
		public static CallSite<Action<CallSite, object>> callSite_7;

		// Token: 0x040004BA RID: 1210
		public static CallSite<Func<CallSite, object, Engine>> callSite_8;

		// Token: 0x040004BB RID: 1211
		public static CallSite<Func<CallSite, object, object>> callSite_9;

		// Token: 0x040004BC RID: 1212
		public static CallSite<Action<CallSite, WebView, object>> callSite_10;
	}

	// Token: 0x02000115 RID: 277
	private static class Class184
	{
		// Token: 0x040004BD RID: 1213
		public static CallSite<Action<CallSite, Control.ControlCollection, object>> callSite_0;

		// Token: 0x040004BE RID: 1214
		public static CallSite<Func<CallSite, object, object, object>> callSite_1;

		// Token: 0x040004BF RID: 1215
		public static CallSite<Func<CallSite, object, bool>> callSite_2;

		// Token: 0x040004C0 RID: 1216
		public static CallSite<Func<CallSite, object, string>> callSite_3;
	}

	// Token: 0x02000116 RID: 278
	[StructLayout(LayoutKind.Auto)]
	private struct Struct58 : IAsyncStateMachine
	{
		// Token: 0x06000739 RID: 1849 RVA: 0x0003F5D4 File Offset: 0x0003D7D4
		void IAsyncStateMachine.MoveNext()
		{
			int num = this.int_0;
			string result;
			try
			{
				if (num != 0)
				{
					MainWindow.mainWindow_0.Invoke(new MethodInvoker(CaptchaQueue_V1.Class182.class182_0.method_0));
					this.string_3 = Class103.smethod_0(16);
					ConcurrentDictionary<string, string> concurrentDictionary = new ConcurrentDictionary<string, string>();
					concurrentDictionary["sitekey"] = this.string_0;
					concurrentDictionary["domain"] = this.string_1;
					concurrentDictionary["taskID"] = this.string_2;
					concurrentDictionary["token"] = this.string_3;
					concurrentDictionary["solving"] = "false";
					this.concurrentDictionary_0 = concurrentDictionary;
					CaptchaQueue_V1.list_0.Add(this.concurrentDictionary_0);
				}
				try
				{
					TaskAwaiter awaiter;
					if (num == 0)
					{
						awaiter = this.taskAwaiter_0;
						this.taskAwaiter_0 = default(TaskAwaiter);
						this.int_0 = -1;
						goto IL_120;
					}
					CaptchaQueue_V1.smethod_2(null, null);
					IL_DE:
					if (CaptchaQueue_V1.concurrentDictionary_0.ContainsKey(this.string_3))
					{
						result = CaptchaQueue_V1.concurrentDictionary_0[this.string_3];
						goto IL_249;
					}
					if (!MainWindow.dictionary_0.ContainsKey((int)Convert.ToInt16(this.string_2)))
					{
						CaptchaQueue_V1.list_0.Remove(this.concurrentDictionary_0);
						if (this.concurrentDictionary_0.ContainsKey("browser"))
						{
							CaptchaQueue_V1.smethod_7(this.concurrentDictionary_0["browser"]);
							MainWindow.mainWindow_0.Invoke(new MethodInvoker(CaptchaQueue_V1.Class182.class182_0.method_1));
						}
						result = null;
						goto IL_249;
					}
					awaiter = Task.Delay(100).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						this.int_0 = 0;
						this.taskAwaiter_0 = awaiter;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, CaptchaQueue_V1.Struct58>(ref awaiter, ref this);
						return;
					}
					IL_120:
					awaiter.GetResult();
					goto IL_DE;
				}
				catch
				{
					CaptchaQueue_V1.list_0.Remove(this.concurrentDictionary_0);
					if (this.concurrentDictionary_0.ContainsKey("browser"))
					{
						CaptchaQueue_V1.smethod_7(this.concurrentDictionary_0["browser"]);
						MainWindow.mainWindow_0.Invoke(new MethodInvoker(CaptchaQueue_V1.Class182.class182_0.method_2));
					}
					result = null;
				}
			}
			catch (Exception exception)
			{
				this.int_0 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_249:
			this.int_0 = -2;
			this.asyncTaskMethodBuilder_0.SetResult(result);
		}

		// Token: 0x0600073A RID: 1850 RVA: 0x00006811 File Offset: 0x00004A11
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040004C1 RID: 1217
		public int int_0;

		// Token: 0x040004C2 RID: 1218
		public AsyncTaskMethodBuilder<string> asyncTaskMethodBuilder_0;

		// Token: 0x040004C3 RID: 1219
		public string string_0;

		// Token: 0x040004C4 RID: 1220
		public string string_1;

		// Token: 0x040004C5 RID: 1221
		public string string_2;

		// Token: 0x040004C6 RID: 1222
		private string string_3;

		// Token: 0x040004C7 RID: 1223
		private ConcurrentDictionary<string, string> concurrentDictionary_0;

		// Token: 0x040004C8 RID: 1224
		private TaskAwaiter taskAwaiter_0;
	}

	// Token: 0x02000117 RID: 279
	private sealed class Class185
	{
		// Token: 0x0600073C RID: 1852 RVA: 0x0000681F File Offset: 0x00004A1F
		internal bool method_0(ConcurrentDictionary<string, string> concurrentDictionary_0)
		{
			return concurrentDictionary_0["token"] == this.jsextInvokeArgs_0.Arguments[1].ToString();
		}

		// Token: 0x040004C9 RID: 1225
		public JSExtInvokeArgs jsextInvokeArgs_0;
	}

	// Token: 0x02000118 RID: 280
	private static class Class186
	{
		// Token: 0x040004CA RID: 1226
		public static CallSite<Func<CallSite, object, bool>> callSite_0;

		// Token: 0x040004CB RID: 1227
		public static CallSite<Func<CallSite, object, bool>> callSite_1;

		// Token: 0x040004CC RID: 1228
		public static CallSite<Action<CallSite, object, string, string>> callSite_2;

		// Token: 0x040004CD RID: 1229
		public static CallSite<Func<CallSite, object, bool>> callSite_3;
	}

	// Token: 0x02000119 RID: 281
	private static class Class187
	{
		// Token: 0x040004CE RID: 1230
		public static CallSite<Action<CallSite, Control.ControlCollection, object>> callSite_0;

		// Token: 0x040004CF RID: 1231
		public static CallSite<Func<CallSite, object, object, object>> callSite_1;

		// Token: 0x040004D0 RID: 1232
		public static CallSite<Func<CallSite, object, bool>> callSite_2;

		// Token: 0x040004D1 RID: 1233
		public static CallSite<Func<CallSite, object, string>> callSite_3;
	}

	// Token: 0x0200011A RID: 282
	[StructLayout(LayoutKind.Auto)]
	private struct Struct59 : IAsyncStateMachine
	{
		// Token: 0x0600073D RID: 1853 RVA: 0x0003F874 File Offset: 0x0003DA74
		void IAsyncStateMachine.MoveNext()
		{
			int num = this.int_0;
			try
			{
				try
				{
					TaskAwaiter<string> awaiter;
					TaskAwaiter<Stream> awaiter2;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter = this.taskAwaiter_1;
							this.taskAwaiter_1 = default(TaskAwaiter<string>);
							this.int_0 = -1;
							goto IL_DF;
						}
						GClass3.smethod_0("Starting ", "Audio Solver");
						awaiter2 = Class138.smethod_0(this.jsextInvokeArgs_0.Arguments.First<object>().ToString()).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							this.int_0 = 0;
							this.taskAwaiter_0 = awaiter2;
							this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<Stream>, CaptchaQueue_V1.Struct59>(ref awaiter2, ref this);
							return;
						}
					}
					else
					{
						awaiter2 = this.taskAwaiter_0;
						this.taskAwaiter_0 = default(TaskAwaiter<Stream>);
						this.int_0 = -1;
					}
					awaiter = Class138.smethod_1(awaiter2.GetResult()).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						this.int_0 = 1;
						this.taskAwaiter_1 = awaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, CaptchaQueue_V1.Struct59>(ref awaiter, ref this);
						return;
					}
					IL_DF:
					string result = awaiter.GetResult();
					GClass3.smethod_0("Received answer: " + result, "Audio Solver");
				}
				catch
				{
				}
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

		// Token: 0x0600073E RID: 1854 RVA: 0x00006843 File Offset: 0x00004A43
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncVoidMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040004D2 RID: 1234
		public int int_0;

		// Token: 0x040004D3 RID: 1235
		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		// Token: 0x040004D4 RID: 1236
		public JSExtInvokeArgs jsextInvokeArgs_0;

		// Token: 0x040004D5 RID: 1237
		private TaskAwaiter<Stream> taskAwaiter_0;

		// Token: 0x040004D6 RID: 1238
		private TaskAwaiter<string> taskAwaiter_1;
	}

	// Token: 0x0200011B RID: 283
	private sealed class Class188
	{
		// Token: 0x06000740 RID: 1856 RVA: 0x00006851 File Offset: 0x00004A51
		internal bool method_0(ConcurrentDictionary<string, string> concurrentDictionary_0)
		{
			return concurrentDictionary_0.ContainsKey("browser") && concurrentDictionary_0["browser"] == this.string_0 && concurrentDictionary_0["solving"] == "true";
		}

		// Token: 0x040004D7 RID: 1239
		public string string_0;
	}

	// Token: 0x0200011C RID: 284
	private static class Class189
	{
		// Token: 0x040004D8 RID: 1240
		public static CallSite<Action<CallSite, object, string>> callSite_0;
	}

	// Token: 0x0200011D RID: 285
	private static class Class190
	{
		// Token: 0x040004D9 RID: 1241
		public static CallSite<Func<CallSite, object, bool>> callSite_0;
	}

	// Token: 0x0200011E RID: 286
	private sealed class Class191
	{
		// Token: 0x06000742 RID: 1858 RVA: 0x0000688F File Offset: 0x00004A8F
		internal bool method_0(ConcurrentDictionary<string, string> concurrentDictionary_0)
		{
			return concurrentDictionary_0.ContainsKey("browser") && concurrentDictionary_0["browser"] == this.string_0 && concurrentDictionary_0["solving"] == "true";
		}

		// Token: 0x040004DA RID: 1242
		public string string_0;
	}

	// Token: 0x0200011F RID: 287
	private static class Class192
	{
		// Token: 0x040004DB RID: 1243
		public static CallSite<Func<CallSite, object, object>> callSite_0;

		// Token: 0x040004DC RID: 1244
		public static CallSite<Action<CallSite, object, bool>> callSite_1;

		// Token: 0x040004DD RID: 1245
		public static CallSite<Action<CallSite, object>> callSite_2;

		// Token: 0x040004DE RID: 1246
		public static CallSite<Func<CallSite, object, object>> callSite_3;

		// Token: 0x040004DF RID: 1247
		public static CallSite<Func<CallSite, object, Engine>> callSite_4;

		// Token: 0x040004E0 RID: 1248
		public static CallSite<Func<CallSite, object, object>> callSite_5;

		// Token: 0x040004E1 RID: 1249
		public static CallSite<Action<CallSite, WebView, object>> callSite_6;
	}

	// Token: 0x02000120 RID: 288
	private static class Class193
	{
		// Token: 0x040004E2 RID: 1250
		public static CallSite<Func<CallSite, object, object>> callSite_0;

		// Token: 0x040004E3 RID: 1251
		public static CallSite<Action<CallSite, object, bool>> callSite_1;

		// Token: 0x040004E4 RID: 1252
		public static CallSite<Action<CallSite, object>> callSite_2;
	}

	// Token: 0x02000121 RID: 289
	private sealed class Class194
	{
		// Token: 0x06000744 RID: 1860 RVA: 0x000068CD File Offset: 0x00004ACD
		internal bool method_0(ConcurrentDictionary<string, string> concurrentDictionary_0)
		{
			return concurrentDictionary_0.ContainsKey("browser") && concurrentDictionary_0["browser"] == this.string_0 && concurrentDictionary_0["solving"] == "true";
		}

		// Token: 0x040004E5 RID: 1253
		public string string_0;
	}

	// Token: 0x02000122 RID: 290
	private static class Class195
	{
		// Token: 0x040004E6 RID: 1254
		public static CallSite<Action<CallSite, object, string>> callSite_0;
	}

	// Token: 0x02000123 RID: 291
	private static class Class196
	{
		// Token: 0x040004E7 RID: 1255
		public static CallSite<Func<CallSite, object, object>> callSite_0;

		// Token: 0x040004E8 RID: 1256
		public static CallSite<Action<CallSite, object, bool>> callSite_1;

		// Token: 0x040004E9 RID: 1257
		public static CallSite<Action<CallSite, object>> callSite_2;
	}

	// Token: 0x02000124 RID: 292
	private sealed class Class197
	{
		// Token: 0x06000746 RID: 1862 RVA: 0x0000690B File Offset: 0x00004B0B
		internal bool method_0(ConcurrentDictionary<string, string> concurrentDictionary_0)
		{
			return concurrentDictionary_0.ContainsKey("browser") && concurrentDictionary_0["browser"] == this.string_0 && concurrentDictionary_0["solving"] == "true";
		}

		// Token: 0x040004EA RID: 1258
		public string string_0;
	}

	// Token: 0x02000125 RID: 293
	private static class Class198
	{
		// Token: 0x040004EB RID: 1259
		public static CallSite<Action<CallSite, Control.ControlCollection, object>> callSite_0;

		// Token: 0x040004EC RID: 1260
		public static CallSite<Func<CallSite, object, object, object>> callSite_1;

		// Token: 0x040004ED RID: 1261
		public static CallSite<Func<CallSite, object, bool>> callSite_2;

		// Token: 0x040004EE RID: 1262
		public static CallSite<Func<CallSite, object, string>> callSite_3;
	}

	// Token: 0x02000126 RID: 294
	private static class Class199
	{
		// Token: 0x040004EF RID: 1263
		public static CallSite<Func<CallSite, object, object>> callSite_0;

		// Token: 0x040004F0 RID: 1264
		public static CallSite<Action<CallSite, object, bool>> callSite_1;

		// Token: 0x040004F1 RID: 1265
		public static CallSite<Action<CallSite, object>> callSite_2;
	}

	// Token: 0x02000127 RID: 295
	private static class Class200
	{
		// Token: 0x040004F2 RID: 1266
		public static CallSite<Func<CallSite, object, JToken>> callSite_0;
	}

	// Token: 0x02000128 RID: 296
	private static class Class201
	{
		// Token: 0x040004F3 RID: 1267
		public static CallSite<Action<CallSite, Control.ControlCollection, object>> callSite_0;

		// Token: 0x040004F4 RID: 1268
		public static CallSite<Func<CallSite, object, object, object>> callSite_1;

		// Token: 0x040004F5 RID: 1269
		public static CallSite<Func<CallSite, object, bool>> callSite_2;

		// Token: 0x040004F6 RID: 1270
		public static CallSite<Func<CallSite, object, string>> callSite_3;
	}

	// Token: 0x02000129 RID: 297
	private static class Class202
	{
		// Token: 0x040004F7 RID: 1271
		public static CallSite<Func<CallSite, object, object>> callSite_0;

		// Token: 0x040004F8 RID: 1272
		public static CallSite<Action<CallSite, object, bool>> callSite_1;

		// Token: 0x040004F9 RID: 1273
		public static CallSite<Action<CallSite, object>> callSite_2;
	}
}
