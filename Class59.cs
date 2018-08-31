using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;

// Token: 0x02000064 RID: 100
internal sealed class Class59
{
	// Token: 0x06000244 RID: 580 RVA: 0x000146DC File Offset: 0x000128DC
	public Class59(JToken jtoken_2)
	{
		try
		{
			this.jtoken_0 = jtoken_2;
			this.class4_0 = new Class4(jtoken_2);
			if (!this.class4_0.method_3(out this.jtoken_1))
			{
				this.class4_0.method_0("Profile error", "red", true);
			}
			else
			{
				this.string_0 = (string)jtoken_2["keywords"];
				this.string_2 = (string)jtoken_2["size"];
				if (this.string_2 == "Random" || this.string_2 == "OneSize")
				{
					this.bool_0 = true;
				}
				this.class70_0 = new Class70(this.class4_0.method_6(), "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.181 Safari/537.36", 10, false, false, null, false);
			}
		}
		catch
		{
			this.class4_0.method_0("Task error", "red", true);
		}
	}

	// Token: 0x06000245 RID: 581 RVA: 0x000147E0 File Offset: 0x000129E0
	public void method_0()
	{
		try
		{
			Task task = this.method_3();
			this.method_1().Wait();
			this.method_2().Wait();
			this.method_4().Wait();
			task.Wait();
			this.method_6().Wait();
			this.method_5().Wait();
			this.method_7().Wait();
			this.method_8().Wait();
		}
		catch
		{
		}
		finally
		{
			this.class4_0.method_0("Stopped", "red", true);
		}
	}

	// Token: 0x06000246 RID: 582 RVA: 0x00014880 File Offset: 0x00012A80
	public async Task method_1()
	{
		for (;;)
		{
			int num = 0;
			TaskAwaiter taskAwaiter2;
			try
			{
				this.class4_0.method_4("Waiting for product", "#c2c2c2", true, false);
				HttpResponseMessage httpResponseMessage = await this.class70_0.method_6(string.Format("https://api.net-a-porter.com/MRP/GB/en/detail/{0}", this.string_0), false);
				httpResponseMessage.EnsureSuccessStatusCode();
				JObject jobject = httpResponseMessage.smethod_0();
				if (jobject.ContainsKey("message"))
				{
					throw new Exception();
				}
				this.class4_0.method_7((string)jobject["name"], "#c2c2c2");
				if (this.bool_0)
				{
					JToken jtoken = jobject["skus"].Where(new Func<JToken, bool>(Class59.Class60.class60_0.method_0)).smethod_2();
					if (jtoken == null)
					{
						this.class4_0.method_4("Waiting for restock", "#c2c2c2", true, false);
						TaskAwaiter taskAwaiter = Task.Delay(GClass0.int_1).GetAwaiter();
						if (!taskAwaiter.IsCompleted)
						{
							await taskAwaiter;
							taskAwaiter = taskAwaiter2;
							taskAwaiter2 = default(TaskAwaiter);
						}
						taskAwaiter.GetResult();
						continue;
					}
					this.class4_0.method_5((string)jtoken["displaySize"]);
					this.string_1 = (string)jtoken["id"];
				}
				else
				{
					JToken jtoken2 = jobject["skus"].FirstOrDefault(new Func<JToken, bool>(this.method_10));
					if (jtoken2 == null)
					{
						this.class4_0.method_4("Waiting for product", "#c2c2c2", true, false);
						TaskAwaiter taskAwaiter = Task.Delay(GClass0.int_1).GetAwaiter();
						if (!taskAwaiter.IsCompleted)
						{
							await taskAwaiter;
							taskAwaiter = taskAwaiter2;
							taskAwaiter2 = default(TaskAwaiter);
						}
						taskAwaiter.GetResult();
						continue;
					}
					this.string_1 = (string)jtoken2["id"];
				}
				this.class4_0.method_4("Found PID: " + this.string_1, "#c2c2c2", true, false);
				break;
			}
			catch (ThreadAbortException)
			{
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				this.class4_0.method_4("Waiting for product", "#c2c2c2", true, false);
				TaskAwaiter taskAwaiter = Task.Delay(GClass0.int_1).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
				}
				taskAwaiter.GetResult();
			}
		}
	}

	// Token: 0x06000247 RID: 583 RVA: 0x000148C8 File Offset: 0x00012AC8
	public async Task method_2()
	{
		for (;;)
		{
			int num = 0;
			try
			{
				this.class4_0.method_4("Adding to cart", "yellow", true, false);
				HttpResponseMessage httpResponseMessage = await this.class70_0.method_6(string.Format("https://www.mrporter.com/intl/api/basket/addsku/{0}.json", this.string_1), false);
				if (httpResponseMessage.StatusCode == HttpStatusCode.Gone)
				{
					this.class4_0.method_0("Product pulled", "red", false);
				}
				JObject jobject = httpResponseMessage.smethod_0();
				string a = (string)jobject["result"];
				if (a == "SIZE_SOLD_OUT")
				{
					this.class4_0.method_4("Waiting for restock", "#c2c2c2", true, false);
					await Task.Delay(GClass0.int_1);
					await this.method_1();
					continue;
				}
				if (!(a == "PRODUCT_ADDED"))
				{
					throw new Exception();
				}
				this.class70_0.cookieContainer_0.Add(new Cookie((string)jobject["cookie"]["name"], (string)jobject["cookie"]["value"], (string)jobject["cookie"]["path"], (string)jobject["cookie"]["domain"]));
				this.class4_0.method_4("Successfully carted", "#c2c2c2", true, false);
				break;
			}
			catch (ThreadAbortException)
			{
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				this.class4_0.method_4("Error adding to cart", "#c2c2c2", true, false);
				TaskAwaiter taskAwaiter = Task.Delay(GClass0.int_1).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
				}
				taskAwaiter.GetResult();
			}
		}
	}

	// Token: 0x06000248 RID: 584 RVA: 0x00014910 File Offset: 0x00012B10
	public async Task method_3()
	{
		for (;;)
		{
			int num = 0;
			try
			{
				this.class4_0.method_4("Getting cookies", "#c2c2c2", true, false);
				TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class70_0.method_6("http://www.mrporter.com/en-gb/mens/gucci/rhyton-printed-leather-sneakers/975128", true).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter<HttpResponseMessage> taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
				}
				taskAwaiter.GetResult().EnsureSuccessStatusCode();
				break;
			}
			catch (ThreadAbortException)
			{
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				this.class4_0.method_4("Error getting cookies", "#c2c2c2", true, false);
				TaskAwaiter taskAwaiter3 = Task.Delay(GClass0.int_1).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter);
				}
				taskAwaiter3.GetResult();
			}
		}
	}

	// Token: 0x06000249 RID: 585 RVA: 0x00014958 File Offset: 0x00012B58
	public async Task method_4()
	{
		for (;;)
		{
			int num = 0;
			try
			{
				this.class4_0.method_4("Verifying cart", "#c2c2c2", true, false);
				TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class70_0.method_6("https://www.mrporter.com/signinpurchasepath.mrp", false).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter<HttpResponseMessage> taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
				}
				taskAwaiter.GetResult().EnsureSuccessStatusCode();
				break;
			}
			catch (ThreadAbortException)
			{
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				this.class4_0.method_4("Error verifying cart", "#c2c2c2", true, false);
				TaskAwaiter taskAwaiter3 = Task.Delay(GClass0.int_1).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter);
				}
				taskAwaiter3.GetResult();
			}
		}
	}

	// Token: 0x0600024A RID: 586 RVA: 0x000149A0 File Offset: 0x00012BA0
	public async Task method_5()
	{
		for (;;)
		{
			int num = 0;
			try
			{
				this.class4_0.method_4("Getting checkout", "#c2c2c2", true, false);
				TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class70_0.method_6("https://www.mrporter.com/purchasepath.mrp", false).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter<HttpResponseMessage> taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
				}
				if (!taskAwaiter.GetResult().Headers.Location.ToString().Contains("purchase"))
				{
					throw new Exception();
				}
				break;
			}
			catch (ThreadAbortException)
			{
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				this.class4_0.method_4("Error verifying cart", "#c2c2c2", true, false);
				TaskAwaiter taskAwaiter3 = Task.Delay(GClass0.int_1).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter);
				}
				taskAwaiter3.GetResult();
			}
		}
	}

	// Token: 0x0600024B RID: 587 RVA: 0x000149E8 File Offset: 0x00012BE8
	public async Task method_6()
	{
		for (;;)
		{
			int num = 0;
			try
			{
				this.class70_0.httpClient_0.DefaultRequestHeaders.Clear();
				this.class4_0.method_4("Logging in", "#c2c2c2", true, false);
				Dictionary<string, string> dictionary = Class70.smethod_1();
				dictionary["j_username"] = (string)this.jtoken_1["payment"]["email"];
				dictionary["didProvideAPassword"] = "no";
				TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class70_0.method_8("https://www.mrporter.com/intl/j_spring_security_check", dictionary, false).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter<HttpResponseMessage> taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
				}
				if (taskAwaiter.GetResult().StatusCode != HttpStatusCode.Found)
				{
					throw new Exception();
				}
				break;
			}
			catch (ThreadAbortException)
			{
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				this.class4_0.method_4("Error logging in", "#c2c2c2", true, false);
				TaskAwaiter taskAwaiter3 = Task.Delay(GClass0.int_1).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter);
				}
				taskAwaiter3.GetResult();
			}
		}
	}

	// Token: 0x0600024C RID: 588 RVA: 0x00014A30 File Offset: 0x00012C30
	public async Task method_7()
	{
		for (;;)
		{
			int num = 0;
			try
			{
				this.class4_0.method_4("Submitting shipping", "#c2c2c2", true, false);
				Dictionary<string, string> dictionary = Class70.smethod_1();
				dictionary["addressType"] = "_SHIPPING";
				dictionary["address.title"] = "Mr";
				dictionary["address.firstName"] = (string)this.jtoken_1["delivery"]["first_name"];
				dictionary["address.lastName"] = (string)this.jtoken_1["delivery"]["last_name"];
				dictionary["address.countryLookup"] = Class167.smethod_0((string)this.jtoken_1["delivery"]["country"], false);
				dictionary["address.address1"] = (string)this.jtoken_1["delivery"]["addr1"];
				dictionary["address.towncity"] = (string)this.jtoken_1["delivery"]["city"];
				dictionary["address.state"] = Class167.smethod_1((string)this.jtoken_1["delivery"]["country"], (string)this.jtoken_1["delivery"]["state"]);
				dictionary["address.postcode"] = (string)this.jtoken_1["delivery"]["zip"];
				dictionary["address.work"] = (string)this.jtoken_1["payment"]["phone"];
				dictionary["deliveryAndBillingSame"] = "true";
				dictionary["_eventId_proceedToPurchase"] = "Proceed to purchase";
				dictionary["_flowExecutionKey"] = "e1s1";
				dictionary["eventId"] = "eventIdNotSet";
				HttpResponseMessage httpResponseMessage = await this.class70_0.method_8("https://www.mrporter.com/intl/purchasepath.mrp?execution=e1s1", dictionary, true);
				httpResponseMessage.EnsureSuccessStatusCode();
				HtmlDocument htmlDocument = new HtmlDocument();
				htmlDocument.LoadHtml(httpResponseMessage.smethod_3());
				string value = htmlDocument.DocumentNode.SelectSingleNode("//input[@name='paymentSessionId']").Attributes["value"].Value;
				string value2 = htmlDocument.DocumentNode.SelectSingleNode("//input[@name='customerId']").Attributes["value"].Value;
				string value3 = htmlDocument.DocumentNode.SelectSingleNode("//input[@name='site']").Attributes["value"].Value;
				string value4 = htmlDocument.DocumentNode.SelectSingleNode("//input[@name='submittedToken']").Attributes["value"].Value;
				Console.WriteLine("here");
				this.dictionary_0["redirectUrl"] = string.Format("https://www.mrporter.com/purchasepath.mrp?execution=e1s2&_eventId=processPayment&submittedToken={0}", value4);
				this.dictionary_0["adminId"] = "0";
				this.dictionary_0["cardType"] = "VISA";
				this.dictionary_0["savedCard"] = "false";
				this.dictionary_0["cardNumber"] = (string)this.jtoken_1["payment"]["card"]["number"];
				this.dictionary_0["cardHoldersName"] = this.jtoken_1["billing"]["first_name"] + " " + this.jtoken_1["billing"]["last_name"];
				this.dictionary_0["cVSNumber"] = (string)this.jtoken_1["payment"]["card"]["cvv"];
				this.dictionary_0["expiryMonth"] = (string)this.jtoken_1["payment"]["card"]["exp_month"];
				this.dictionary_0["expiryYear"] = (string)this.jtoken_1["payment"]["card"]["exp_year"];
				this.dictionary_0["issueNumber"] = string.Empty;
				this.dictionary_0["keepCard"] = "false";
				this.dictionary_0["paymentSessionId"] = value;
				this.dictionary_0["customerId"] = value2;
				this.dictionary_0["site"] = value3;
				break;
			}
			catch (ThreadAbortException)
			{
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				this.class4_0.method_4("Error submitting shipping", "#c2c2c2", true, false);
				TaskAwaiter taskAwaiter = Task.Delay(GClass0.int_1).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
				}
				taskAwaiter.GetResult();
			}
		}
	}

	// Token: 0x0600024D RID: 589 RVA: 0x00014A78 File Offset: 0x00012C78
	public async Task method_8()
	{
		for (;;)
		{
			int num = 0;
			try
			{
				this.class4_0.method_4("Submitting payment", "orange", true, false);
				await this.class70_0.method_8("https://secure.net-a-porter.com/psp/payment", this.dictionary_0, false);
				break;
			}
			catch (ThreadAbortException)
			{
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				this.class4_0.method_4("Error", "#c2c2c2", true, false);
				TaskAwaiter taskAwaiter = Task.Delay(GClass0.int_1).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
				}
				taskAwaiter.GetResult();
			}
		}
	}

	// Token: 0x0600024E RID: 590 RVA: 0x00014AC0 File Offset: 0x00012CC0
	public async Task method_9()
	{
		for (;;)
		{
			int num = 0;
			try
			{
				this.class4_0.method_4("Stuff", "#c2c2c2", true, false);
				goto IL_8D;
			}
			catch (ThreadAbortException)
			{
				break;
			}
			catch
			{
				num = 1;
				goto IL_8D;
			}
			continue;
			IL_8D:
			if (num == 1)
			{
				this.class4_0.method_4("Error", "#c2c2c2", true, false);
				TaskAwaiter taskAwaiter = Task.Delay(GClass0.int_1).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
				}
				taskAwaiter.GetResult();
			}
		}
	}

	// Token: 0x0600024F RID: 591 RVA: 0x0000410C File Offset: 0x0000230C
	private bool method_10(JToken jtoken_2)
	{
		return Class167.smethod_2(this.string_2, (string)jtoken_2["displaySize"]);
	}

	// Token: 0x0400012A RID: 298
	private Class70 class70_0;

	// Token: 0x0400012B RID: 299
	private JToken jtoken_0;

	// Token: 0x0400012C RID: 300
	private JToken jtoken_1;

	// Token: 0x0400012D RID: 301
	private Class4 class4_0;

	// Token: 0x0400012E RID: 302
	private string string_0;

	// Token: 0x0400012F RID: 303
	private string string_1;

	// Token: 0x04000130 RID: 304
	private string string_2;

	// Token: 0x04000131 RID: 305
	private bool bool_0;

	// Token: 0x04000132 RID: 306
	private Dictionary<string, string> dictionary_0 = new Dictionary<string, string>();

	// Token: 0x02000065 RID: 101
	[Serializable]
	private sealed class Class60
	{
		// Token: 0x06000252 RID: 594 RVA: 0x00004135 File Offset: 0x00002335
		internal bool method_0(JToken jtoken_0)
		{
			return (string)jtoken_0["stockLevel"] != "Out_of_Stock";
		}

		// Token: 0x04000133 RID: 307
		public static readonly Class59.Class60 class60_0 = new Class59.Class60();

		// Token: 0x04000134 RID: 308
		public static Func<JToken, bool> func_0;
	}

	// Token: 0x02000066 RID: 102
	[StructLayout(LayoutKind.Auto)]
	private struct Struct9 : IAsyncStateMachine
	{
		// Token: 0x06000253 RID: 595 RVA: 0x00014B08 File Offset: 0x00012D08
		void IAsyncStateMachine.MoveNext()
		{
			int num = this.int_0;
			Class59 @class = this.class59_0;
			try
			{
				if (num == 0)
				{
					goto IL_114;
				}
				if (num != 1)
				{
					goto IL_112;
				}
				TaskAwaiter awaiter = this.taskAwaiter_1;
				this.taskAwaiter_1 = default(TaskAwaiter);
				int num2 = -1;
				num = -1;
				this.int_0 = num2;
				IL_10B:
				awaiter.GetResult();
				IL_112:
				int num3 = 0;
				IL_114:
				try
				{
					TaskAwaiter<HttpResponseMessage> awaiter2;
					if (num != 0)
					{
						@class.class4_0.method_4("Submitting payment", "orange", true, false);
						awaiter2 = @class.class70_0.method_8("https://secure.net-a-porter.com/psp/payment", @class.dictionary_0, false).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							int num4 = 0;
							num = 0;
							this.int_0 = num4;
							this.taskAwaiter_0 = awaiter2;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class59.Struct9>(ref awaiter2, ref this);
							return;
						}
					}
					else
					{
						awaiter2 = this.taskAwaiter_0;
						this.taskAwaiter_0 = default(TaskAwaiter<HttpResponseMessage>);
						int num5 = -1;
						num = -1;
						this.int_0 = num5;
					}
					awaiter2.GetResult();
					goto IL_154;
				}
				catch (ThreadAbortException)
				{
					goto IL_154;
				}
				catch
				{
					num3 = 1;
				}
				if (num3 != 1)
				{
					goto IL_112;
				}
				@class.class4_0.method_4("Error", "#c2c2c2", true, false);
				awaiter = Task.Delay(GClass0.int_1).GetAwaiter();
				if (awaiter.IsCompleted)
				{
					goto IL_10B;
				}
				int num6 = 1;
				num = 1;
				this.int_0 = num6;
				this.taskAwaiter_1 = awaiter;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class59.Struct9>(ref awaiter, ref this);
				return;
			}
			catch (Exception exception)
			{
				this.int_0 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_154:
			this.int_0 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000254 RID: 596 RVA: 0x00004151 File Offset: 0x00002351
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000135 RID: 309
		public int int_0;

		// Token: 0x04000136 RID: 310
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000137 RID: 311
		public Class59 class59_0;

		// Token: 0x04000138 RID: 312
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000139 RID: 313
		private TaskAwaiter taskAwaiter_1;
	}

	// Token: 0x02000067 RID: 103
	[StructLayout(LayoutKind.Auto)]
	private struct Struct10 : IAsyncStateMachine
	{
		// Token: 0x06000255 RID: 597 RVA: 0x00014CC8 File Offset: 0x00012EC8
		void IAsyncStateMachine.MoveNext()
		{
			int num = this.int_0;
			Class59 @class = this.class59_0;
			try
			{
				TaskAwaiter awaiter;
				if (num > 2)
				{
					if (num != 3)
					{
						goto IL_2EE;
					}
					awaiter = this.taskAwaiter_1;
					this.taskAwaiter_1 = default(TaskAwaiter);
					int num2 = -1;
					num = -1;
					this.int_0 = num2;
					goto IL_2E7;
				}
				IL_3C:
				int num9;
				try
				{
					TaskAwaiter<HttpResponseMessage> awaiter2;
					switch (num)
					{
					case 0:
					{
						awaiter2 = this.taskAwaiter_0;
						this.taskAwaiter_0 = default(TaskAwaiter<HttpResponseMessage>);
						int num3 = -1;
						num = -1;
						this.int_0 = num3;
						break;
					}
					case 1:
					{
						awaiter = this.taskAwaiter_1;
						this.taskAwaiter_1 = default(TaskAwaiter);
						int num4 = -1;
						num = -1;
						this.int_0 = num4;
						goto IL_242;
					}
					case 2:
					{
						awaiter = this.taskAwaiter_1;
						this.taskAwaiter_1 = default(TaskAwaiter);
						int num5 = -1;
						num = -1;
						this.int_0 = num5;
						goto IL_29D;
					}
					default:
						@class.class4_0.method_4("Adding to cart", "yellow", true, false);
						awaiter2 = @class.class70_0.method_6(string.Format("https://www.mrporter.com/intl/api/basket/addsku/{0}.json", @class.string_1), false).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							int num6 = 0;
							num = 0;
							this.int_0 = num6;
							this.taskAwaiter_0 = awaiter2;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class59.Struct10>(ref awaiter2, ref this);
							return;
						}
						break;
					}
					HttpResponseMessage result = awaiter2.GetResult();
					if (result.StatusCode == HttpStatusCode.Gone)
					{
						@class.class4_0.method_0("Product pulled", "red", false);
					}
					JObject jobject = result.smethod_0();
					string a = (string)jobject["result"];
					if (!(a == "SIZE_SOLD_OUT"))
					{
						if (!(a == "PRODUCT_ADDED"))
						{
							throw new Exception();
						}
						@class.class70_0.cookieContainer_0.Add(new Cookie((string)jobject["cookie"]["name"], (string)jobject["cookie"]["value"], (string)jobject["cookie"]["path"], (string)jobject["cookie"]["domain"]));
						@class.class4_0.method_4("Successfully carted", "#c2c2c2", true, false);
						goto IL_32F;
					}
					else
					{
						@class.class4_0.method_4("Waiting for restock", "#c2c2c2", true, false);
						awaiter = Task.Delay(GClass0.int_1).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							int num7 = 1;
							num = 1;
							this.int_0 = num7;
							this.taskAwaiter_1 = awaiter;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class59.Struct10>(ref awaiter, ref this);
							return;
						}
					}
					IL_242:
					awaiter.GetResult();
					awaiter = @class.method_1().GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						int num8 = 2;
						num = 2;
						this.int_0 = num8;
						this.taskAwaiter_1 = awaiter;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class59.Struct10>(ref awaiter, ref this);
						return;
					}
					IL_29D:
					awaiter.GetResult();
					goto IL_2EE;
				}
				catch (ThreadAbortException)
				{
					goto IL_32F;
				}
				catch
				{
					num9 = 1;
				}
				if (num9 != 1)
				{
					goto IL_2EE;
				}
				@class.class4_0.method_4("Error adding to cart", "#c2c2c2", true, false);
				awaiter = Task.Delay(GClass0.int_1).GetAwaiter();
				if (!awaiter.IsCompleted)
				{
					int num10 = 3;
					num = 3;
					this.int_0 = num10;
					this.taskAwaiter_1 = awaiter;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class59.Struct10>(ref awaiter, ref this);
					return;
				}
				IL_2E7:
				awaiter.GetResult();
				IL_2EE:
				num9 = 0;
				goto IL_3C;
			}
			catch (Exception exception)
			{
				this.int_0 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_32F:
			this.int_0 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000256 RID: 598 RVA: 0x0000415F File Offset: 0x0000235F
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400013A RID: 314
		public int int_0;

		// Token: 0x0400013B RID: 315
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x0400013C RID: 316
		public Class59 class59_0;

		// Token: 0x0400013D RID: 317
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x0400013E RID: 318
		private TaskAwaiter taskAwaiter_1;
	}

	// Token: 0x02000068 RID: 104
	[StructLayout(LayoutKind.Auto)]
	private struct Struct11 : IAsyncStateMachine
	{
		// Token: 0x06000257 RID: 599 RVA: 0x00015064 File Offset: 0x00013264
		void IAsyncStateMachine.MoveNext()
		{
			int num = this.int_0;
			Class59 @class = this.class59_0;
			try
			{
				if (num == 0)
				{
					goto IL_59E;
				}
				if (num != 1)
				{
					goto IL_59C;
				}
				TaskAwaiter awaiter = this.taskAwaiter_1;
				this.taskAwaiter_1 = default(TaskAwaiter);
				int num2 = -1;
				num = -1;
				this.int_0 = num2;
				IL_595:
				awaiter.GetResult();
				IL_59C:
				int num3 = 0;
				IL_59E:
				try
				{
					TaskAwaiter<HttpResponseMessage> awaiter2;
					if (num != 0)
					{
						@class.class4_0.method_4("Submitting shipping", "#c2c2c2", true, false);
						Dictionary<string, string> dictionary = Class70.smethod_1();
						dictionary["addressType"] = "_SHIPPING";
						dictionary["address.title"] = "Mr";
						dictionary["address.firstName"] = (string)@class.jtoken_1["delivery"]["first_name"];
						dictionary["address.lastName"] = (string)@class.jtoken_1["delivery"]["last_name"];
						dictionary["address.countryLookup"] = Class167.smethod_0((string)@class.jtoken_1["delivery"]["country"], false);
						dictionary["address.address1"] = (string)@class.jtoken_1["delivery"]["addr1"];
						dictionary["address.towncity"] = (string)@class.jtoken_1["delivery"]["city"];
						dictionary["address.state"] = Class167.smethod_1((string)@class.jtoken_1["delivery"]["country"], (string)@class.jtoken_1["delivery"]["state"]);
						dictionary["address.postcode"] = (string)@class.jtoken_1["delivery"]["zip"];
						dictionary["address.work"] = (string)@class.jtoken_1["payment"]["phone"];
						dictionary["deliveryAndBillingSame"] = "true";
						dictionary["_eventId_proceedToPurchase"] = "Proceed to purchase";
						dictionary["_flowExecutionKey"] = "e1s1";
						dictionary["eventId"] = "eventIdNotSet";
						awaiter2 = @class.class70_0.method_8("https://www.mrporter.com/intl/purchasepath.mrp?execution=e1s1", dictionary, true).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							int num4 = 0;
							num = 0;
							this.int_0 = num4;
							this.taskAwaiter_0 = awaiter2;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class59.Struct11>(ref awaiter2, ref this);
							return;
						}
					}
					else
					{
						awaiter2 = this.taskAwaiter_0;
						this.taskAwaiter_0 = default(TaskAwaiter<HttpResponseMessage>);
						int num5 = -1;
						num = -1;
						this.int_0 = num5;
					}
					HttpResponseMessage result = awaiter2.GetResult();
					result.EnsureSuccessStatusCode();
					HtmlDocument htmlDocument = new HtmlDocument();
					htmlDocument.LoadHtml(result.smethod_3());
					string value = htmlDocument.DocumentNode.SelectSingleNode("//input[@name='paymentSessionId']").Attributes["value"].Value;
					string value2 = htmlDocument.DocumentNode.SelectSingleNode("//input[@name='customerId']").Attributes["value"].Value;
					string value3 = htmlDocument.DocumentNode.SelectSingleNode("//input[@name='site']").Attributes["value"].Value;
					string value4 = htmlDocument.DocumentNode.SelectSingleNode("//input[@name='submittedToken']").Attributes["value"].Value;
					Console.WriteLine("here");
					@class.dictionary_0["redirectUrl"] = string.Format("https://www.mrporter.com/purchasepath.mrp?execution=e1s2&_eventId=processPayment&submittedToken={0}", value4);
					@class.dictionary_0["adminId"] = "0";
					@class.dictionary_0["cardType"] = "VISA";
					@class.dictionary_0["savedCard"] = "false";
					@class.dictionary_0["cardNumber"] = (string)@class.jtoken_1["payment"]["card"]["number"];
					@class.dictionary_0["cardHoldersName"] = @class.jtoken_1["billing"]["first_name"] + " " + @class.jtoken_1["billing"]["last_name"];
					@class.dictionary_0["cVSNumber"] = (string)@class.jtoken_1["payment"]["card"]["cvv"];
					@class.dictionary_0["expiryMonth"] = (string)@class.jtoken_1["payment"]["card"]["exp_month"];
					@class.dictionary_0["expiryYear"] = (string)@class.jtoken_1["payment"]["card"]["exp_year"];
					@class.dictionary_0["issueNumber"] = string.Empty;
					@class.dictionary_0["keepCard"] = "false";
					@class.dictionary_0["paymentSessionId"] = value;
					@class.dictionary_0["customerId"] = value2;
					@class.dictionary_0["site"] = value3;
					goto IL_5DE;
				}
				catch (ThreadAbortException)
				{
					goto IL_5DE;
				}
				catch
				{
					num3 = 1;
				}
				if (num3 != 1)
				{
					goto IL_59C;
				}
				@class.class4_0.method_4("Error submitting shipping", "#c2c2c2", true, false);
				awaiter = Task.Delay(GClass0.int_1).GetAwaiter();
				if (awaiter.IsCompleted)
				{
					goto IL_595;
				}
				int num6 = 1;
				num = 1;
				this.int_0 = num6;
				this.taskAwaiter_1 = awaiter;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class59.Struct11>(ref awaiter, ref this);
				return;
			}
			catch (Exception exception)
			{
				this.int_0 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_5DE:
			this.int_0 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000258 RID: 600 RVA: 0x0000416D File Offset: 0x0000236D
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400013F RID: 319
		public int int_0;

		// Token: 0x04000140 RID: 320
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000141 RID: 321
		public Class59 class59_0;

		// Token: 0x04000142 RID: 322
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000143 RID: 323
		private TaskAwaiter taskAwaiter_1;
	}

	// Token: 0x02000069 RID: 105
	[StructLayout(LayoutKind.Auto)]
	private struct Struct12 : IAsyncStateMachine
	{
		// Token: 0x06000259 RID: 601 RVA: 0x000156B0 File Offset: 0x000138B0
		void IAsyncStateMachine.MoveNext()
		{
			int num = this.int_0;
			Class59 @class = this.class59_0;
			try
			{
				TaskAwaiter awaiter;
				if (num > 2)
				{
					if (num != 3)
					{
						goto IL_335;
					}
					awaiter = this.taskAwaiter_1;
					this.taskAwaiter_1 = default(TaskAwaiter);
					int num2 = -1;
					num = -1;
					this.int_0 = num2;
					goto IL_32E;
				}
				IL_3C:
				int num9;
				try
				{
					TaskAwaiter<HttpResponseMessage> awaiter2;
					switch (num)
					{
					case 0:
					{
						awaiter2 = this.taskAwaiter_0;
						this.taskAwaiter_0 = default(TaskAwaiter<HttpResponseMessage>);
						int num3 = -1;
						num = -1;
						this.int_0 = num3;
						break;
					}
					case 1:
					{
						awaiter = this.taskAwaiter_1;
						this.taskAwaiter_1 = default(TaskAwaiter);
						int num4 = -1;
						num = -1;
						this.int_0 = num4;
						goto IL_2BF;
					}
					case 2:
					{
						awaiter = this.taskAwaiter_1;
						this.taskAwaiter_1 = default(TaskAwaiter);
						int num5 = -1;
						num = -1;
						this.int_0 = num5;
						goto IL_2E4;
					}
					default:
						@class.class4_0.method_4("Waiting for product", "#c2c2c2", true, false);
						awaiter2 = @class.class70_0.method_6(string.Format("https://api.net-a-porter.com/MRP/GB/en/detail/{0}", @class.string_0), false).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							int num6 = 0;
							num = 0;
							this.int_0 = num6;
							this.taskAwaiter_0 = awaiter2;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class59.Struct12>(ref awaiter2, ref this);
							return;
						}
						break;
					}
					HttpResponseMessage result = awaiter2.GetResult();
					result.EnsureSuccessStatusCode();
					JObject jobject = result.smethod_0();
					if (jobject.ContainsKey("message"))
					{
						throw new Exception();
					}
					@class.class4_0.method_7((string)jobject["name"], "#c2c2c2");
					if (@class.bool_0)
					{
						JToken jtoken = jobject["skus"].Where(new Func<JToken, bool>(Class59.Class60.class60_0.method_0)).smethod_2();
						if (jtoken == null)
						{
							@class.class4_0.method_4("Waiting for restock", "#c2c2c2", true, false);
							awaiter = Task.Delay(GClass0.int_1).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								int num7 = 1;
								num = 1;
								this.int_0 = num7;
								this.taskAwaiter_1 = awaiter;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class59.Struct12>(ref awaiter, ref this);
								return;
							}
							goto IL_2BF;
						}
						else
						{
							@class.class4_0.method_5((string)jtoken["displaySize"]);
							@class.string_1 = (string)jtoken["id"];
						}
					}
					else
					{
						JToken jtoken2 = jobject["skus"].FirstOrDefault(new Func<JToken, bool>(@class.method_10));
						if (jtoken2 == null)
						{
							@class.class4_0.method_4("Waiting for product", "#c2c2c2", true, false);
							awaiter = Task.Delay(GClass0.int_1).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								int num8 = 2;
								num = 2;
								this.int_0 = num8;
								this.taskAwaiter_1 = awaiter;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class59.Struct12>(ref awaiter, ref this);
								return;
							}
							goto IL_2E4;
						}
						else
						{
							@class.string_1 = (string)jtoken2["id"];
						}
					}
					@class.class4_0.method_4("Found PID: " + @class.string_1, "#c2c2c2", true, false);
					goto IL_376;
					IL_2BF:
					awaiter.GetResult();
					goto IL_335;
					IL_2E4:
					awaiter.GetResult();
					goto IL_335;
				}
				catch (ThreadAbortException)
				{
					goto IL_376;
				}
				catch
				{
					num9 = 1;
				}
				if (num9 != 1)
				{
					goto IL_335;
				}
				@class.class4_0.method_4("Waiting for product", "#c2c2c2", true, false);
				awaiter = Task.Delay(GClass0.int_1).GetAwaiter();
				if (!awaiter.IsCompleted)
				{
					int num10 = 3;
					num = 3;
					this.int_0 = num10;
					this.taskAwaiter_1 = awaiter;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class59.Struct12>(ref awaiter, ref this);
					return;
				}
				IL_32E:
				awaiter.GetResult();
				IL_335:
				num9 = 0;
				goto IL_3C;
			}
			catch (Exception exception)
			{
				this.int_0 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_376:
			this.int_0 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x0600025A RID: 602 RVA: 0x0000417B File Offset: 0x0000237B
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000144 RID: 324
		public int int_0;

		// Token: 0x04000145 RID: 325
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000146 RID: 326
		public Class59 class59_0;

		// Token: 0x04000147 RID: 327
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000148 RID: 328
		private TaskAwaiter taskAwaiter_1;
	}

	// Token: 0x0200006A RID: 106
	[StructLayout(LayoutKind.Auto)]
	private struct Struct13 : IAsyncStateMachine
	{
		// Token: 0x0600025B RID: 603 RVA: 0x00015A94 File Offset: 0x00013C94
		void IAsyncStateMachine.MoveNext()
		{
			int num = this.int_0;
			Class59 @class = this.class59_0;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = this.taskAwaiter_0;
					this.taskAwaiter_0 = default(TaskAwaiter);
					this.int_0 = -1;
					goto IL_2D;
				}
				int num2;
				do
				{
					IL_57:
					num2 = 0;
					try
					{
						@class.class4_0.method_4("Stuff", "#c2c2c2", true, false);
						goto IL_8D;
					}
					catch (ThreadAbortException)
					{
						goto IL_CC;
					}
					catch
					{
						num2 = 1;
						goto IL_8D;
					}
					continue;
					IL_8D:;
				}
				while (num2 != 1);
				@class.class4_0.method_4("Error", "#c2c2c2", true, false);
				awaiter = Task.Delay(GClass0.int_1).GetAwaiter();
				if (!awaiter.IsCompleted)
				{
					this.int_0 = 0;
					this.taskAwaiter_0 = awaiter;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class59.Struct13>(ref awaiter, ref this);
					return;
				}
				IL_2D:
				awaiter.GetResult();
				goto IL_57;
			}
			catch (Exception exception)
			{
				this.int_0 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_CC:
			this.int_0 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x0600025C RID: 604 RVA: 0x00004189 File Offset: 0x00002389
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000149 RID: 329
		public int int_0;

		// Token: 0x0400014A RID: 330
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x0400014B RID: 331
		public Class59 class59_0;

		// Token: 0x0400014C RID: 332
		private TaskAwaiter taskAwaiter_0;
	}

	// Token: 0x0200006B RID: 107
	[StructLayout(LayoutKind.Auto)]
	private struct Struct14 : IAsyncStateMachine
	{
		// Token: 0x0600025D RID: 605 RVA: 0x00015BA8 File Offset: 0x00013DA8
		void IAsyncStateMachine.MoveNext()
		{
			int num = this.int_0;
			Class59 @class = this.class59_0;
			try
			{
				if (num == 0)
				{
					goto IL_12E;
				}
				if (num != 1)
				{
					goto IL_12C;
				}
				TaskAwaiter awaiter = this.taskAwaiter_1;
				this.taskAwaiter_1 = default(TaskAwaiter);
				int num2 = -1;
				num = -1;
				this.int_0 = num2;
				IL_125:
				awaiter.GetResult();
				IL_12C:
				int num3 = 0;
				IL_12E:
				try
				{
					TaskAwaiter<HttpResponseMessage> awaiter2;
					if (num != 0)
					{
						@class.class4_0.method_4("Getting checkout", "#c2c2c2", true, false);
						awaiter2 = @class.class70_0.method_6("https://www.mrporter.com/purchasepath.mrp", false).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							int num4 = 0;
							num = 0;
							this.int_0 = num4;
							this.taskAwaiter_0 = awaiter2;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class59.Struct14>(ref awaiter2, ref this);
							return;
						}
					}
					else
					{
						awaiter2 = this.taskAwaiter_0;
						this.taskAwaiter_0 = default(TaskAwaiter<HttpResponseMessage>);
						int num5 = -1;
						num = -1;
						this.int_0 = num5;
					}
					if (!awaiter2.GetResult().Headers.Location.ToString().Contains("purchase"))
					{
						throw new Exception();
					}
					goto IL_16E;
				}
				catch (ThreadAbortException)
				{
					goto IL_16E;
				}
				catch
				{
					num3 = 1;
				}
				if (num3 != 1)
				{
					goto IL_12C;
				}
				@class.class4_0.method_4("Error verifying cart", "#c2c2c2", true, false);
				awaiter = Task.Delay(GClass0.int_1).GetAwaiter();
				if (awaiter.IsCompleted)
				{
					goto IL_125;
				}
				int num6 = 1;
				num = 1;
				this.int_0 = num6;
				this.taskAwaiter_1 = awaiter;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class59.Struct14>(ref awaiter, ref this);
				return;
			}
			catch (Exception exception)
			{
				this.int_0 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_16E:
			this.int_0 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x0600025E RID: 606 RVA: 0x00004197 File Offset: 0x00002397
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400014D RID: 333
		public int int_0;

		// Token: 0x0400014E RID: 334
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x0400014F RID: 335
		public Class59 class59_0;

		// Token: 0x04000150 RID: 336
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000151 RID: 337
		private TaskAwaiter taskAwaiter_1;
	}

	// Token: 0x0200006C RID: 108
	[StructLayout(LayoutKind.Auto)]
	private struct Struct15 : IAsyncStateMachine
	{
		// Token: 0x0600025F RID: 607 RVA: 0x00015D84 File Offset: 0x00013F84
		void IAsyncStateMachine.MoveNext()
		{
			int num = this.int_0;
			Class59 @class = this.class59_0;
			try
			{
				if (num == 0)
				{
					goto IL_113;
				}
				if (num != 1)
				{
					goto IL_111;
				}
				TaskAwaiter awaiter = this.taskAwaiter_1;
				this.taskAwaiter_1 = default(TaskAwaiter);
				int num2 = -1;
				num = -1;
				this.int_0 = num2;
				IL_10A:
				awaiter.GetResult();
				IL_111:
				int num3 = 0;
				IL_113:
				try
				{
					TaskAwaiter<HttpResponseMessage> awaiter2;
					if (num != 0)
					{
						@class.class4_0.method_4("Verifying cart", "#c2c2c2", true, false);
						awaiter2 = @class.class70_0.method_6("https://www.mrporter.com/signinpurchasepath.mrp", false).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							int num4 = 0;
							num = 0;
							this.int_0 = num4;
							this.taskAwaiter_0 = awaiter2;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class59.Struct15>(ref awaiter2, ref this);
							return;
						}
					}
					else
					{
						awaiter2 = this.taskAwaiter_0;
						this.taskAwaiter_0 = default(TaskAwaiter<HttpResponseMessage>);
						int num5 = -1;
						num = -1;
						this.int_0 = num5;
					}
					awaiter2.GetResult().EnsureSuccessStatusCode();
					goto IL_153;
				}
				catch (ThreadAbortException)
				{
					goto IL_153;
				}
				catch
				{
					num3 = 1;
				}
				if (num3 != 1)
				{
					goto IL_111;
				}
				@class.class4_0.method_4("Error verifying cart", "#c2c2c2", true, false);
				awaiter = Task.Delay(GClass0.int_1).GetAwaiter();
				if (awaiter.IsCompleted)
				{
					goto IL_10A;
				}
				int num6 = 1;
				num = 1;
				this.int_0 = num6;
				this.taskAwaiter_1 = awaiter;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class59.Struct15>(ref awaiter, ref this);
				return;
			}
			catch (Exception exception)
			{
				this.int_0 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_153:
			this.int_0 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000260 RID: 608 RVA: 0x000041A5 File Offset: 0x000023A5
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000152 RID: 338
		public int int_0;

		// Token: 0x04000153 RID: 339
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000154 RID: 340
		public Class59 class59_0;

		// Token: 0x04000155 RID: 341
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000156 RID: 342
		private TaskAwaiter taskAwaiter_1;
	}

	// Token: 0x0200006D RID: 109
	[StructLayout(LayoutKind.Auto)]
	private struct Struct16 : IAsyncStateMachine
	{
		// Token: 0x06000261 RID: 609 RVA: 0x00015F44 File Offset: 0x00014144
		void IAsyncStateMachine.MoveNext()
		{
			int num = this.int_0;
			Class59 @class = this.class59_0;
			try
			{
				if (num == 0)
				{
					goto IL_113;
				}
				if (num != 1)
				{
					goto IL_111;
				}
				TaskAwaiter awaiter = this.taskAwaiter_1;
				this.taskAwaiter_1 = default(TaskAwaiter);
				int num2 = -1;
				num = -1;
				this.int_0 = num2;
				IL_10A:
				awaiter.GetResult();
				IL_111:
				int num3 = 0;
				IL_113:
				try
				{
					TaskAwaiter<HttpResponseMessage> awaiter2;
					if (num != 0)
					{
						@class.class4_0.method_4("Getting cookies", "#c2c2c2", true, false);
						awaiter2 = @class.class70_0.method_6("http://www.mrporter.com/en-gb/mens/gucci/rhyton-printed-leather-sneakers/975128", true).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							int num4 = 0;
							num = 0;
							this.int_0 = num4;
							this.taskAwaiter_0 = awaiter2;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class59.Struct16>(ref awaiter2, ref this);
							return;
						}
					}
					else
					{
						awaiter2 = this.taskAwaiter_0;
						this.taskAwaiter_0 = default(TaskAwaiter<HttpResponseMessage>);
						int num5 = -1;
						num = -1;
						this.int_0 = num5;
					}
					awaiter2.GetResult().EnsureSuccessStatusCode();
					goto IL_153;
				}
				catch (ThreadAbortException)
				{
					goto IL_153;
				}
				catch
				{
					num3 = 1;
				}
				if (num3 != 1)
				{
					goto IL_111;
				}
				@class.class4_0.method_4("Error getting cookies", "#c2c2c2", true, false);
				awaiter = Task.Delay(GClass0.int_1).GetAwaiter();
				if (awaiter.IsCompleted)
				{
					goto IL_10A;
				}
				int num6 = 1;
				num = 1;
				this.int_0 = num6;
				this.taskAwaiter_1 = awaiter;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class59.Struct16>(ref awaiter, ref this);
				return;
			}
			catch (Exception exception)
			{
				this.int_0 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_153:
			this.int_0 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000262 RID: 610 RVA: 0x000041B3 File Offset: 0x000023B3
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000157 RID: 343
		public int int_0;

		// Token: 0x04000158 RID: 344
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000159 RID: 345
		public Class59 class59_0;

		// Token: 0x0400015A RID: 346
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x0400015B RID: 347
		private TaskAwaiter taskAwaiter_1;
	}

	// Token: 0x0200006E RID: 110
	[StructLayout(LayoutKind.Auto)]
	private struct Struct17 : IAsyncStateMachine
	{
		// Token: 0x06000263 RID: 611 RVA: 0x00016104 File Offset: 0x00014304
		void IAsyncStateMachine.MoveNext()
		{
			int num = this.int_0;
			Class59 @class = this.class59_0;
			try
			{
				if (num == 0)
				{
					goto IL_17B;
				}
				if (num != 1)
				{
					goto IL_179;
				}
				TaskAwaiter awaiter = this.taskAwaiter_1;
				this.taskAwaiter_1 = default(TaskAwaiter);
				int num2 = -1;
				num = -1;
				this.int_0 = num2;
				IL_172:
				awaiter.GetResult();
				IL_179:
				int num3 = 0;
				IL_17B:
				try
				{
					TaskAwaiter<HttpResponseMessage> awaiter2;
					if (num != 0)
					{
						@class.class70_0.httpClient_0.DefaultRequestHeaders.Clear();
						@class.class4_0.method_4("Logging in", "#c2c2c2", true, false);
						Dictionary<string, string> dictionary = Class70.smethod_1();
						dictionary["j_username"] = (string)@class.jtoken_1["payment"]["email"];
						dictionary["didProvideAPassword"] = "no";
						awaiter2 = @class.class70_0.method_8("https://www.mrporter.com/intl/j_spring_security_check", dictionary, false).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							int num4 = 0;
							num = 0;
							this.int_0 = num4;
							this.taskAwaiter_0 = awaiter2;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class59.Struct17>(ref awaiter2, ref this);
							return;
						}
					}
					else
					{
						awaiter2 = this.taskAwaiter_0;
						this.taskAwaiter_0 = default(TaskAwaiter<HttpResponseMessage>);
						int num5 = -1;
						num = -1;
						this.int_0 = num5;
					}
					if (awaiter2.GetResult().StatusCode != HttpStatusCode.Found)
					{
						throw new Exception();
					}
					goto IL_1BB;
				}
				catch (ThreadAbortException)
				{
					goto IL_1BB;
				}
				catch
				{
					num3 = 1;
				}
				if (num3 != 1)
				{
					goto IL_179;
				}
				@class.class4_0.method_4("Error logging in", "#c2c2c2", true, false);
				awaiter = Task.Delay(GClass0.int_1).GetAwaiter();
				if (awaiter.IsCompleted)
				{
					goto IL_172;
				}
				int num6 = 1;
				num = 1;
				this.int_0 = num6;
				this.taskAwaiter_1 = awaiter;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class59.Struct17>(ref awaiter, ref this);
				return;
			}
			catch (Exception exception)
			{
				this.int_0 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_1BB:
			this.int_0 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000264 RID: 612 RVA: 0x000041C1 File Offset: 0x000023C1
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400015C RID: 348
		public int int_0;

		// Token: 0x0400015D RID: 349
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x0400015E RID: 350
		public Class59 class59_0;

		// Token: 0x0400015F RID: 351
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000160 RID: 352
		private TaskAwaiter taskAwaiter_1;
	}
}
