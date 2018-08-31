using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;

// Token: 0x0200007B RID: 123
internal sealed class Class70
{
	// Token: 0x060002BF RID: 703 RVA: 0x00016FD0 File Offset: 0x000151D0
	public Class70(string string_0 = null, string string_1 = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.181 Safari/537.36", int int_0 = 10, bool bool_1 = false, bool bool_2 = false, JObject jobject_0 = null, bool bool_3 = false)
	{
		this.bool_0 = bool_1;
		this.cookieContainer_0 = new CookieContainer();
		WebRequestHandler webRequestHandler = new WebRequestHandler
		{
			UseCookies = true,
			CookieContainer = this.cookieContainer_0,
			AllowAutoRedirect = bool_3,
			Proxy = Class70.smethod_0(string_0),
			PreAuthenticate = true,
			AutomaticDecompression = (DecompressionMethods.GZip | DecompressionMethods.Deflate),
			ClientCertificateOptions = ClientCertificateOption.Manual
		};
		if (!bool_2)
		{
			webRequestHandler.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(this.method_0);
		}
		this.httpClient_0 = new HttpClient(webRequestHandler)
		{
			Timeout = TimeSpan.FromSeconds((double)int_0)
		};
		this.httpClient_0.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", string_1);
		this.httpClient_0.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate");
		this.httpClient_0.DefaultRequestHeaders.TryAddWithoutValidation("Upgrade-Insecure-Requests", "1");
		this.httpClient_0.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Language", "en-GB,en-US;q=0.9,en;q=0.8");
		this.httpClient_0.DefaultRequestHeaders.TryAddWithoutValidation("Connection", "keep-alive");
		if (jobject_0 != null)
		{
			foreach (KeyValuePair<string, JToken> keyValuePair in jobject_0)
			{
				this.httpClient_0.DefaultRequestHeaders.TryAddWithoutValidation(keyValuePair.Key, (string)keyValuePair.Value);
			}
		}
	}

	// Token: 0x060002C0 RID: 704 RVA: 0x00017148 File Offset: 0x00015348
	public bool method_0(object object_0, X509Certificate x509Certificate_0, X509Chain x509Chain_0, SslPolicyErrors sslPolicyErrors_0)
	{
		string host = ((HttpWebRequest)object_0).Host;
		string certHashString = x509Certificate_0.GetCertHashString();
		if (Debugger.IsAttached)
		{
			return true;
		}
		if (Class168.string_2.ToUpper().Contains(certHashString.ToUpper()))
		{
			return true;
		}
		if (this.bool_0)
		{
			return x509Certificate_0.Issuer.Contains("Let's Encrypt Authority X3") || x509Certificate_0.Issuer.Contains("DigiCert SHA2 High Assurance Server CA");
		}
		if (host.Contains("supreme"))
		{
			return true;
		}
		GClass3.smethod_0(certHashString, "SSL");
		return host.Replace("www.", string.Empty) == "supremenewyork.com" && x509Certificate_0.Issuer == "CN=GlobalSign CloudSSL CA - SHA256 - G3, O=GlobalSign nv-sa, C=BE";
	}

	// Token: 0x060002C1 RID: 705 RVA: 0x00017208 File Offset: 0x00015408
	private static WebProxy smethod_0(string string_0)
	{
		WebProxy result;
		try
		{
			WebProxy webProxy = Debugger.IsAttached ? null : new WebProxy();
			if (string_0 == null)
			{
				result = webProxy;
			}
			else
			{
				string[] array = string_0.Split(new char[]
				{
					':'
				});
				if (array.Length == 4)
				{
					string address = string.Format("http://{0}:{1}", array[0], array[1]);
					NetworkCredential credentials = new NetworkCredential(array[2], array[3]);
					webProxy = new WebProxy(address, false)
					{
						UseDefaultCredentials = false,
						Credentials = credentials
					};
					result = webProxy;
				}
				else
				{
					result = ((array.Length == 2) ? new WebProxy(string.Format("{0}:{1}", array[0], array[1]), false) : webProxy);
				}
			}
		}
		catch
		{
			result = new WebProxy();
		}
		return result;
	}

	// Token: 0x060002C2 RID: 706 RVA: 0x000172B8 File Offset: 0x000154B8
	private HttpResponseMessage method_1(string string_0, HttpResponseMessage httpResponseMessage_0)
	{
		while (httpResponseMessage_0.StatusCode >= HttpStatusCode.MultipleChoices && httpResponseMessage_0.StatusCode <= (HttpStatusCode)399)
		{
			Uri uri = httpResponseMessage_0.Headers.Location;
			if (!uri.IsAbsoluteUri)
			{
				uri = new Uri(new Uri(string_0).GetLeftPart(UriPartial.Authority) + uri);
			}
			httpResponseMessage_0 = this.httpClient_0.GetAsync(uri).Result;
		}
		return httpResponseMessage_0;
	}

	// Token: 0x060002C3 RID: 707 RVA: 0x00017324 File Offset: 0x00015524
	private async Task<HttpResponseMessage> method_2(string string_0, HttpResponseMessage httpResponseMessage_0)
	{
		while (httpResponseMessage_0.StatusCode >= HttpStatusCode.MultipleChoices && httpResponseMessage_0.StatusCode <= (HttpStatusCode)399)
		{
			Uri uri = httpResponseMessage_0.Headers.Location;
			if (!uri.IsAbsoluteUri)
			{
				uri = new Uri(new Uri(string_0).GetLeftPart(UriPartial.Authority) + uri);
			}
			TaskAwaiter<HttpResponseMessage> taskAwaiter = this.httpClient_0.GetAsync(uri).GetAwaiter();
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter<HttpResponseMessage> taskAwaiter2;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
			}
			httpResponseMessage_0 = taskAwaiter.GetResult();
		}
		return httpResponseMessage_0;
	}

	// Token: 0x060002C4 RID: 708 RVA: 0x0001737C File Offset: 0x0001557C
	private bool method_3(string string_0, string string_1)
	{
		bool result;
		try
		{
			if (string_0.Contains("jschl-answer"))
			{
				Uri uri = new Uri(string_1);
				string_1 = uri.Scheme + "://" + uri.Authority + "/";
				HtmlDocument htmlDocument = new HtmlDocument();
				htmlDocument.LoadHtml(string_0);
				string innerHtml = htmlDocument.DocumentNode.SelectSingleNode("/html/head/script").InnerHtml;
				string value = htmlDocument.DocumentNode.SelectSingleNode("//input[@name='jschl_vc']").Attributes["value"].Value;
				string value2 = htmlDocument.DocumentNode.SelectSingleNode("//input[@name='pass']").Attributes["value"].Value;
				string_0.Split(new string[]
				{
					"setTimeout(function(){"
				}, StringSplitOptions.None)[1].Split(new string[]
				{
					"t = document"
				}, StringSplitOptions.None)[0] + string_0.Split(new string[]
				{
					"('challenge-form');"
				}, StringSplitOptions.None)[1].Split(new string[]
				{
					"t.length;"
				}, StringSplitOptions.None)[0].Replace("a.value = ", string.Empty) + new Uri(string_1).Host.Length;
				string empty = string.Empty;
				string string_2 = string.Format(string_1 + "cdn-cgi/l/chk_jschl?jschl_vc={0}&pass={1}&jschl_answer={2}", value, value2, empty);
				Thread.Sleep(6000);
				this.method_5(string_2, false);
				result = true;
			}
			else
			{
				result = false;
			}
		}
		catch
		{
			throw new Exception();
		}
		return result;
	}

	// Token: 0x060002C5 RID: 709 RVA: 0x0001750C File Offset: 0x0001570C
	private void method_4(string string_0, string string_1)
	{
		this.httpClient_0.DefaultRequestHeaders.Remove("X-Request-Auth");
		if (string_0.Contains("footpatrol"))
		{
			this.httpClient_0.DefaultRequestHeaders.TryAddWithoutValidation("X-Request-Auth", Class13.smethod_0(string_0, string_1));
			return;
		}
		if (string_0.Contains("thehipstore"))
		{
			this.httpClient_0.DefaultRequestHeaders.TryAddWithoutValidation("X-Request-Auth", Class13.smethod_1(string_0, string_1));
		}
	}

	// Token: 0x060002C6 RID: 710 RVA: 0x00017584 File Offset: 0x00015784
	public HttpResponseMessage method_5(string string_0, bool bool_1)
	{
		HttpResponseMessage result;
		for (;;)
		{
			this.method_4(string_0, "GET");
			result = this.httpClient_0.GetAsync(string_0).Result;
			if (!result.smethod_5())
			{
				break;
			}
			this.method_3(result.smethod_3(), string_0);
		}
		if (!bool_1)
		{
			return result;
		}
		return this.method_1(string_0, result);
	}

	// Token: 0x060002C7 RID: 711 RVA: 0x000175D4 File Offset: 0x000157D4
	public async Task<HttpResponseMessage> method_6(string string_0, bool bool_1)
	{
		this.method_4(string_0, "GET");
		HttpResponseMessage result;
		if (bool_1)
		{
			string string_ = string_0;
			TaskAwaiter<HttpResponseMessage> taskAwaiter = this.httpClient_0.GetAsync(string_0).GetAwaiter();
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter<HttpResponseMessage> taskAwaiter2;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
			}
			result = await this.method_2(string_, taskAwaiter.GetResult());
			string_ = null;
		}
		else
		{
			TaskAwaiter<HttpResponseMessage> taskAwaiter = this.httpClient_0.GetAsync(string_0).GetAwaiter();
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter<HttpResponseMessage> taskAwaiter2;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
			}
			result = taskAwaiter.GetResult();
		}
		return result;
	}

	// Token: 0x060002C8 RID: 712 RVA: 0x0001762C File Offset: 0x0001582C
	public HttpResponseMessage method_7(string string_0, Dictionary<string, string> dictionary_0, bool bool_1)
	{
		HttpResponseMessage result;
		for (;;)
		{
			this.method_4(string_0, "POST");
			result = this.httpClient_0.PostAsync(string_0, Class70.smethod_2(dictionary_0)).Result;
			if (!result.smethod_5())
			{
				break;
			}
			this.method_3(result.smethod_3(), string_0);
		}
		if (!bool_1)
		{
			return result;
		}
		return this.method_1(string_0, result);
	}

	// Token: 0x060002C9 RID: 713 RVA: 0x00017684 File Offset: 0x00015884
	public async Task<HttpResponseMessage> method_8(string string_0, Dictionary<string, string> dictionary_0, bool bool_1)
	{
		this.method_4(string_0, "POST");
		HttpResponseMessage result;
		if (bool_1)
		{
			string string_ = string_0;
			TaskAwaiter<HttpResponseMessage> taskAwaiter = this.httpClient_0.PostAsync(string_0, Class70.smethod_2(dictionary_0)).GetAwaiter();
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter<HttpResponseMessage> taskAwaiter2;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
			}
			result = await this.method_2(string_, taskAwaiter.GetResult());
			string_ = null;
		}
		else
		{
			TaskAwaiter<HttpResponseMessage> taskAwaiter = this.httpClient_0.PostAsync(string_0, Class70.smethod_2(dictionary_0)).GetAwaiter();
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter<HttpResponseMessage> taskAwaiter2;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
			}
			result = taskAwaiter.GetResult();
		}
		return result;
	}

	// Token: 0x060002CA RID: 714 RVA: 0x000176E4 File Offset: 0x000158E4
	public HttpResponseMessage method_9(string string_0, JObject jobject_0, bool bool_1)
	{
		HttpResponseMessage result;
		for (;;)
		{
			this.method_4(string_0, "POST");
			result = this.httpClient_0.PostAsync(string_0, new StringContent(jobject_0.ToString(), Encoding.UTF8, "application/json")).Result;
			if (!result.smethod_5())
			{
				break;
			}
			this.method_3(result.smethod_3(), string_0);
		}
		if (!bool_1)
		{
			return result;
		}
		return this.method_1(string_0, result);
	}

	// Token: 0x060002CB RID: 715 RVA: 0x00004605 File Offset: 0x00002805
	public Task<HttpResponseMessage> method_10(string string_0, JObject jobject_0)
	{
		this.method_4(string_0, "POST");
		return this.httpClient_0.PostAsync(string_0, new StringContent(jobject_0.ToString(), Encoding.UTF8, "application/json"));
	}

	// Token: 0x060002CC RID: 716 RVA: 0x0001774C File Offset: 0x0001594C
	public HttpResponseMessage method_11(string string_0, Dictionary<string, string> dictionary_0, bool bool_1)
	{
		HttpResponseMessage result;
		for (;;)
		{
			this.method_4(string_0, "POST");
			HttpRequestMessage request = new HttpRequestMessage
			{
				Method = new HttpMethod("PATCH"),
				RequestUri = new Uri(string_0),
				Content = Class70.smethod_2(dictionary_0)
			};
			result = this.httpClient_0.SendAsync(request).Result;
			if (!result.smethod_5())
			{
				break;
			}
			this.method_3(result.smethod_3(), string_0);
		}
		if (!bool_1)
		{
			return result;
		}
		return this.method_1(string_0, result);
	}

	// Token: 0x060002CD RID: 717 RVA: 0x000177CC File Offset: 0x000159CC
	public HttpResponseMessage method_12(string string_0, JObject jobject_0, bool bool_1)
	{
		HttpResponseMessage result;
		for (;;)
		{
			this.method_4(string_0, "PATCH");
			HttpRequestMessage request = new HttpRequestMessage
			{
				Method = new HttpMethod("PATCH"),
				RequestUri = new Uri(string_0),
				Content = new StringContent(jobject_0.ToString(), Encoding.UTF8, "application/json")
			};
			result = this.httpClient_0.SendAsync(request).Result;
			if (!result.smethod_5())
			{
				break;
			}
			this.method_3(result.smethod_3(), string_0);
		}
		if (!bool_1)
		{
			return result;
		}
		return this.method_1(string_0, result);
	}

	// Token: 0x060002CE RID: 718 RVA: 0x0001785C File Offset: 0x00015A5C
	public Task<HttpResponseMessage> method_13(string string_0, JObject jobject_0, bool bool_1)
	{
		this.method_4(string_0, "PATCH");
		HttpRequestMessage request = new HttpRequestMessage
		{
			Method = new HttpMethod("PATCH"),
			RequestUri = new Uri(string_0),
			Content = new StringContent(jobject_0.ToString(), Encoding.UTF8, "application/json")
		};
		return this.httpClient_0.SendAsync(request);
	}

	// Token: 0x060002CF RID: 719 RVA: 0x000178C0 File Offset: 0x00015AC0
	public Task<HttpResponseMessage> method_14(string string_0, Dictionary<string, string> dictionary_0, bool bool_1)
	{
		this.method_4(string_0, "PATCH");
		HttpRequestMessage request = new HttpRequestMessage
		{
			Method = new HttpMethod("PATCH"),
			RequestUri = new Uri(string_0),
			Content = Class70.smethod_2(dictionary_0)
		};
		return this.httpClient_0.SendAsync(request);
	}

	// Token: 0x060002D0 RID: 720 RVA: 0x00017914 File Offset: 0x00015B14
	public HttpResponseMessage method_15(string string_0, Dictionary<string, string> dictionary_0, bool bool_1)
	{
		HttpResponseMessage result;
		for (;;)
		{
			this.method_4(string_0, "PUT");
			result = this.httpClient_0.PutAsync(string_0, Class70.smethod_2(dictionary_0)).Result;
			if (!result.smethod_5())
			{
				break;
			}
			this.method_3(result.smethod_3(), string_0);
		}
		if (!bool_1)
		{
			return result;
		}
		return this.method_1(string_0, result);
	}

	// Token: 0x060002D1 RID: 721 RVA: 0x0001796C File Offset: 0x00015B6C
	public HttpResponseMessage method_16(string string_0, JObject jobject_0, bool bool_1)
	{
		HttpResponseMessage result;
		for (;;)
		{
			this.method_4(string_0, "PUT");
			result = this.httpClient_0.PutAsync(string_0, new StringContent(jobject_0.ToString(), Encoding.UTF8, "application/json")).Result;
			if (!result.smethod_5())
			{
				break;
			}
			this.method_3(result.smethod_3(), string_0);
		}
		if (!bool_1)
		{
			return result;
		}
		return this.method_1(string_0, result);
	}

	// Token: 0x060002D2 RID: 722 RVA: 0x00004634 File Offset: 0x00002834
	public Task<HttpResponseMessage> method_17(string string_0, Dictionary<string, string> dictionary_0, bool bool_1)
	{
		this.method_4(string_0, "PUT");
		return this.httpClient_0.PutAsync(string_0, Class70.smethod_2(dictionary_0));
	}

	// Token: 0x060002D3 RID: 723 RVA: 0x00004654 File Offset: 0x00002854
	public Task<HttpResponseMessage> method_18(string string_0, JObject jobject_0, bool bool_1)
	{
		this.method_4(string_0, "PUT");
		return this.httpClient_0.PutAsync(string_0, new StringContent(jobject_0.ToString(), Encoding.UTF8, "application/json"));
	}

	// Token: 0x060002D4 RID: 724 RVA: 0x00004683 File Offset: 0x00002883
	public static Dictionary<string, string> smethod_1()
	{
		return new Dictionary<string, string>();
	}

	// Token: 0x060002D5 RID: 725 RVA: 0x000179D4 File Offset: 0x00015BD4
	public static FormUrlEncodedContent smethod_2(Dictionary<string, string> dictionary_0)
	{
		List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
		foreach (KeyValuePair<string, string> keyValuePair in dictionary_0)
		{
			list.Add(new KeyValuePair<string, string>(keyValuePair.Key, keyValuePair.Value));
		}
		return new FormUrlEncodedContent(list);
	}

	// Token: 0x04000171 RID: 369
	public CookieContainer cookieContainer_0;

	// Token: 0x04000172 RID: 370
	public HttpClient httpClient_0;

	// Token: 0x04000173 RID: 371
	private bool bool_0;

	// Token: 0x0200007C RID: 124
	[StructLayout(LayoutKind.Auto)]
	private struct Struct18 : IAsyncStateMachine
	{
		// Token: 0x060002D6 RID: 726 RVA: 0x00017A44 File Offset: 0x00015C44
		void IAsyncStateMachine.MoveNext()
		{
			int num = this.int_0;
			Class70 @class = this.class70_0;
			HttpResponseMessage result3;
			try
			{
				TaskAwaiter<HttpResponseMessage> awaiter;
				switch (num)
				{
				case 0:
					awaiter = this.taskAwaiter_0;
					this.taskAwaiter_0 = default(TaskAwaiter<HttpResponseMessage>);
					this.int_0 = -1;
					break;
				case 1:
					awaiter = this.taskAwaiter_0;
					this.taskAwaiter_0 = default(TaskAwaiter<HttpResponseMessage>);
					this.int_0 = -1;
					goto IL_152;
				case 2:
					awaiter = this.taskAwaiter_0;
					this.taskAwaiter_0 = default(TaskAwaiter<HttpResponseMessage>);
					this.int_0 = -1;
					goto IL_17F;
				default:
					@class.method_4(this.string_0, "GET");
					if (this.bool_0)
					{
						this.string_1 = this.string_0;
						awaiter = @class.httpClient_0.GetAsync(this.string_0).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							this.int_0 = 0;
							this.taskAwaiter_0 = awaiter;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class70.Struct18>(ref awaiter, ref this);
							return;
						}
					}
					else
					{
						awaiter = @class.httpClient_0.GetAsync(this.string_0).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							this.int_0 = 2;
							this.taskAwaiter_0 = awaiter;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class70.Struct18>(ref awaiter, ref this);
							return;
						}
						goto IL_17F;
					}
					break;
				}
				HttpResponseMessage result = awaiter.GetResult();
				awaiter = @class.method_2(this.string_1, result).GetAwaiter();
				if (!awaiter.IsCompleted)
				{
					this.int_0 = 1;
					this.taskAwaiter_0 = awaiter;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class70.Struct18>(ref awaiter, ref this);
					return;
				}
				IL_152:
				HttpResponseMessage result2 = awaiter.GetResult();
				this.string_1 = null;
				goto IL_187;
				IL_17F:
				result2 = awaiter.GetResult();
				IL_187:
				result3 = result2;
			}
			catch (Exception exception)
			{
				this.int_0 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			this.int_0 = -2;
			this.asyncTaskMethodBuilder_0.SetResult(result3);
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x0000468A File Offset: 0x0000288A
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000174 RID: 372
		public int int_0;

		// Token: 0x04000175 RID: 373
		public AsyncTaskMethodBuilder<HttpResponseMessage> asyncTaskMethodBuilder_0;

		// Token: 0x04000176 RID: 374
		public Class70 class70_0;

		// Token: 0x04000177 RID: 375
		public string string_0;

		// Token: 0x04000178 RID: 376
		public bool bool_0;

		// Token: 0x04000179 RID: 377
		private string string_1;

		// Token: 0x0400017A RID: 378
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;
	}

	// Token: 0x0200007D RID: 125
	[StructLayout(LayoutKind.Auto)]
	private struct Struct19 : IAsyncStateMachine
	{
		// Token: 0x060002D8 RID: 728 RVA: 0x00017C28 File Offset: 0x00015E28
		void IAsyncStateMachine.MoveNext()
		{
			int num = this.int_0;
			Class70 @class = this.class70_0;
			HttpResponseMessage result3;
			try
			{
				TaskAwaiter<HttpResponseMessage> awaiter;
				switch (num)
				{
				case 0:
					awaiter = this.taskAwaiter_0;
					this.taskAwaiter_0 = default(TaskAwaiter<HttpResponseMessage>);
					this.int_0 = -1;
					break;
				case 1:
					awaiter = this.taskAwaiter_0;
					this.taskAwaiter_0 = default(TaskAwaiter<HttpResponseMessage>);
					this.int_0 = -1;
					goto IL_168;
				case 2:
					awaiter = this.taskAwaiter_0;
					this.taskAwaiter_0 = default(TaskAwaiter<HttpResponseMessage>);
					this.int_0 = -1;
					goto IL_195;
				default:
					@class.method_4(this.string_0, "POST");
					if (this.bool_0)
					{
						this.string_1 = this.string_0;
						awaiter = @class.httpClient_0.PostAsync(this.string_0, Class70.smethod_2(this.dictionary_0)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							this.int_0 = 0;
							this.taskAwaiter_0 = awaiter;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class70.Struct19>(ref awaiter, ref this);
							return;
						}
					}
					else
					{
						awaiter = @class.httpClient_0.PostAsync(this.string_0, Class70.smethod_2(this.dictionary_0)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							this.int_0 = 2;
							this.taskAwaiter_0 = awaiter;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class70.Struct19>(ref awaiter, ref this);
							return;
						}
						goto IL_195;
					}
					break;
				}
				HttpResponseMessage result = awaiter.GetResult();
				awaiter = @class.method_2(this.string_1, result).GetAwaiter();
				if (!awaiter.IsCompleted)
				{
					this.int_0 = 1;
					this.taskAwaiter_0 = awaiter;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class70.Struct19>(ref awaiter, ref this);
					return;
				}
				IL_168:
				HttpResponseMessage result2 = awaiter.GetResult();
				this.string_1 = null;
				goto IL_19D;
				IL_195:
				result2 = awaiter.GetResult();
				IL_19D:
				result3 = result2;
			}
			catch (Exception exception)
			{
				this.int_0 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			this.int_0 = -2;
			this.asyncTaskMethodBuilder_0.SetResult(result3);
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x00004698 File Offset: 0x00002898
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400017B RID: 379
		public int int_0;

		// Token: 0x0400017C RID: 380
		public AsyncTaskMethodBuilder<HttpResponseMessage> asyncTaskMethodBuilder_0;

		// Token: 0x0400017D RID: 381
		public Class70 class70_0;

		// Token: 0x0400017E RID: 382
		public string string_0;

		// Token: 0x0400017F RID: 383
		public bool bool_0;

		// Token: 0x04000180 RID: 384
		public Dictionary<string, string> dictionary_0;

		// Token: 0x04000181 RID: 385
		private string string_1;

		// Token: 0x04000182 RID: 386
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;
	}

	// Token: 0x0200007E RID: 126
	[StructLayout(LayoutKind.Auto)]
	private struct Struct20 : IAsyncStateMachine
	{
		// Token: 0x060002DA RID: 730 RVA: 0x00017E24 File Offset: 0x00016024
		void IAsyncStateMachine.MoveNext()
		{
			int num = this.int_0;
			Class70 @class = this.class70_0;
			HttpResponseMessage result;
			try
			{
				TaskAwaiter<HttpResponseMessage> awaiter;
				if (num == 0)
				{
					awaiter = this.taskAwaiter_0;
					this.taskAwaiter_0 = default(TaskAwaiter<HttpResponseMessage>);
					this.int_0 = -1;
					goto IL_AA;
				}
				IL_2F:
				if (this.httpResponseMessage_0.StatusCode < HttpStatusCode.MultipleChoices || this.httpResponseMessage_0.StatusCode > (HttpStatusCode)399)
				{
					result = this.httpResponseMessage_0;
					goto IL_103;
				}
				Uri uri = this.httpResponseMessage_0.Headers.Location;
				if (!uri.IsAbsoluteUri)
				{
					uri = new Uri(new Uri(this.string_0).GetLeftPart(UriPartial.Authority) + uri);
				}
				awaiter = @class.httpClient_0.GetAsync(uri).GetAwaiter();
				if (!awaiter.IsCompleted)
				{
					this.int_0 = 0;
					this.taskAwaiter_0 = awaiter;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class70.Struct20>(ref awaiter, ref this);
					return;
				}
				IL_AA:
				HttpResponseMessage result2 = awaiter.GetResult();
				this.httpResponseMessage_0 = result2;
				goto IL_2F;
			}
			catch (Exception exception)
			{
				this.int_0 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_103:
			this.int_0 = -2;
			this.asyncTaskMethodBuilder_0.SetResult(result);
		}

		// Token: 0x060002DB RID: 731 RVA: 0x000046A6 File Offset: 0x000028A6
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000183 RID: 387
		public int int_0;

		// Token: 0x04000184 RID: 388
		public AsyncTaskMethodBuilder<HttpResponseMessage> asyncTaskMethodBuilder_0;

		// Token: 0x04000185 RID: 389
		public HttpResponseMessage httpResponseMessage_0;

		// Token: 0x04000186 RID: 390
		public string string_0;

		// Token: 0x04000187 RID: 391
		public Class70 class70_0;

		// Token: 0x04000188 RID: 392
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;
	}
}
