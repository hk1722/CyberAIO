using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

// Token: 0x02000092 RID: 146
internal sealed class Class80
{
	// Token: 0x0600030C RID: 780 RVA: 0x00018AD8 File Offset: 0x00016CD8
	public Class80(JToken jtoken_2, string string_9)
	{
		try
		{
			this.jtoken_1 = jtoken_2;
			this.class4_0 = new Class4(jtoken_2);
			this.string_1 = (string)jtoken_2["keywords"];
			this.string_3 = string_9;
			if (!((string)jtoken_2["size"] == "Random") && !((string)jtoken_2["size"] == "OneSize"))
			{
				this.string_4 = (string)jtoken_2["size"];
				if (!this.string_4.Contains(".5") && this.string_4.Replace(".", string.Empty).smethod_0())
				{
					this.string_4 += ".0";
				}
				if (this.string_4.Length == 3)
				{
					this.string_4 = "0" + this.string_4;
				}
			}
			else
			{
				this.bool_0 = true;
			}
			this.string_4 = Class167.smethod_4(this.string_4);
			if (!this.class4_0.method_3(out this.jtoken_0))
			{
				this.class4_0.method_0("Profile error", "red", true);
			}
			else
			{
				this.class70_0 = new Class70(this.class4_0.method_6(), "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.181 Safari/537.36", 10, false, false, null, false);
				this.class70_0.httpClient_0.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
				this.class70_0.httpClient_0.DefaultRequestHeaders.ExpectContinue = new bool?(false);
			}
		}
		catch
		{
			this.class4_0.method_0("Task error", "red", true);
		}
	}

	// Token: 0x0600030D RID: 781 RVA: 0x00018CBC File Offset: 0x00016EBC
	public async void method_0()
	{
		try
		{
			await this.method_2();
			this.task_1 = this.method_4();
			this.task_2 = this.method_7();
			this.task_4 = this.method_5();
			this.task_5 = this.method_6();
			this.task_3 = this.method_8();
			this.class4_0.method_8();
			await this.method_1();
			await this.method_3();
			await this.task_4;
			await this.task_5;
			await this.task_3;
			await this.method_9();
		}
		catch
		{
		}
		finally
		{
			this.class4_0.method_0("Stopped", "red", true);
		}
	}

	// Token: 0x0600030E RID: 782 RVA: 0x00018CF8 File Offset: 0x00016EF8
	public async Task method_1()
	{
		this.class4_0.method_4("Waiting for product", "#c2c2c2", true, false);
		for (;;)
		{
			int num = 0;
			TaskAwaiter taskAwaiter2;
			try
			{
				HttpResponseMessage httpResponseMessage = await this.class70_0.method_6(string.Format("https://www.{0}/api/products/pdp/{1}", this.string_3, this.string_1), false);
				httpResponseMessage.EnsureSuccessStatusCode();
				JObject jobject = await httpResponseMessage.smethod_1();
				this.class4_0.method_7(jobject["name"].ToString(), "#c2c2c2");
				JToken jtoken = jobject["variantAttributes"].FirstOrDefault(new Func<JToken, bool>(this.method_10));
				if (jtoken != null)
				{
					this.bool_1 = (bool)jtoken["recaptchaOn"];
					this.int_0 = (((bool)jtoken["displayCountDownTimer"]) ? Convert.ToInt32(Convert.ToDateTime(jtoken["skuLaunchDate"].ToString().Replace(" GMT+0000", string.Empty)).Subtract(DateTime.UtcNow).TotalSeconds) : 0);
					this.class4_0.method_13(this.int_0, "Waiting ", 0);
					this.string_2 = (string)jtoken["code"];
					if (this.bool_0)
					{
						JToken jtoken2 = jobject["sellableUnits"].Where(new Func<JToken, bool>(this.method_11)).smethod_2();
						if (jtoken2 != null && !(jtoken2["stockLevelStatus"].ToString() != "inStock"))
						{
							this.class4_0.method_5(jtoken2["attributes"].First(new Func<JToken, bool>(Class80.Class81.class81_0.method_1))["value"].ToString());
							this.string_0 = jtoken2["code"].ToString();
							this.class4_0.method_4("Found size code: " + this.string_0, "#c2c2c2", true, false);
							break;
						}
						this.class4_0.method_4("Waiting for restock", "#c2c2c2", true, false);
						TaskAwaiter taskAwaiter = Task.Delay(GClass0.int_0).GetAwaiter();
						if (!taskAwaiter.IsCompleted)
						{
							await taskAwaiter;
							taskAwaiter = taskAwaiter2;
							taskAwaiter2 = default(TaskAwaiter);
						}
						taskAwaiter.GetResult();
						continue;
					}
					else
					{
						JToken jtoken3 = jobject["sellableUnits"].FirstOrDefault(new Func<JToken, bool>(this.method_12));
						if (jtoken3 == null)
						{
							TaskAwaiter taskAwaiter = Task.Delay(GClass0.int_0).GetAwaiter();
							if (!taskAwaiter.IsCompleted)
							{
								await taskAwaiter;
								taskAwaiter = taskAwaiter2;
								taskAwaiter2 = default(TaskAwaiter);
							}
							taskAwaiter.GetResult();
							continue;
						}
						if (jtoken3["stockLevelStatus"].ToString() != "inStock")
						{
							this.class4_0.method_4("Waiting for restock", "#c2c2c2", true, false);
							TaskAwaiter taskAwaiter = Task.Delay(GClass0.int_0).GetAwaiter();
							if (!taskAwaiter.IsCompleted)
							{
								await taskAwaiter;
								taskAwaiter = taskAwaiter2;
								taskAwaiter2 = default(TaskAwaiter);
							}
							taskAwaiter.GetResult();
							continue;
						}
						this.string_0 = jtoken3["code"].ToString();
						this.class4_0.method_4("Found size code: " + this.string_0, "#c2c2c2", true, false);
						break;
					}
				}
				else
				{
					this.class4_0.method_0("Product pulled", "red", false);
				}
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
				TaskAwaiter taskAwaiter = Task.Delay(GClass0.int_0).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
				}
				taskAwaiter.GetResult();
				this.class4_0.method_4("Waiting for product", "#c2c2c2", false, false);
			}
		}
	}

	// Token: 0x0600030F RID: 783 RVA: 0x00018D40 File Offset: 0x00016F40
	public async Task method_2()
	{
		for (;;)
		{
			int num = 0;
			try
			{
				this.class4_0.method_4("Getting session", "#c2c2c2", true, false);
				TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class70_0.method_6(string.Format("https://www.{0}/api/session", this.string_3), false).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter<HttpResponseMessage> taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
				}
				HttpResponseMessage result = taskAwaiter.GetResult();
				if (result.StatusCode == HttpStatusCode.Found && result.Headers.Location.ToString() == "https://www.footlocker.eu/")
				{
					this.class4_0.method_0("US proxy required", "red", false);
				}
				result.EnsureSuccessStatusCode();
				HttpRequestHeaders httpRequestHeaders = this.class70_0.httpClient_0.DefaultRequestHeaders;
				TaskAwaiter<JObject> taskAwaiter3 = result.smethod_1().GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter<JObject> taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter<JObject>);
				}
				httpRequestHeaders.TryAddWithoutValidation("x-csrf-token", taskAwaiter3.GetResult()["data"]["csrfToken"].ToString());
				httpRequestHeaders = null;
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
				this.class4_0.method_4("Error getting session", "#c2c2c2", true, false);
				TaskAwaiter taskAwaiter5 = Task.Delay(GClass0.int_1).GetAwaiter();
				if (!taskAwaiter5.IsCompleted)
				{
					await taskAwaiter5;
					TaskAwaiter taskAwaiter6;
					taskAwaiter5 = taskAwaiter6;
					taskAwaiter6 = default(TaskAwaiter);
				}
				taskAwaiter5.GetResult();
			}
		}
	}

	// Token: 0x06000310 RID: 784 RVA: 0x00018D88 File Offset: 0x00016F88
	public async Task method_3()
	{
		JObject jobject = new JObject();
		jobject["productId"] = this.string_0;
		jobject["productQuantity"] = "1";
		JObject jobject2 = jobject;
		if (this.bool_1)
		{
			this.class4_0.method_4("Waiting for captcha", "turquoise", true, false);
			jobject2["g-recaptcha-response"] = "03AJpayVHiEb9A_5g6z1Dfc_lPxQN7tRhAYf9bxCEQtwx7yRDuCNefGi1RpoQ5fmb7hVx0GVp5Xd5S-O0K3_DzVlKYNKZgNvsGr9VoFcwOCArpECry3oSTAsIa4zoa2d9ojkQVvczakU__iBsKzQntJa6gsyV15juQkkhPGAFiyJrEIxBdiBTdvdgVgiO2whkba3d9FvOpnQSLXht0EoUgUb4pD0oFexemT0BrWlQjqXUOv7LVd0vDtjsOWdqeNJd_nXcHW2NwOMPs-XPsPI9v5VkYipiilieQvuccjSPwicRmXZEBXMHyhfgj5J_G37ezer0bj9sWpI4Spzf6zsPFUcejACU2MgFPdPE-B3jB_RtNwuNwoyM6Q5MNY3TE2_9JO7NDQus3cdZkrrtaTeL7HyrBYNYqBNBrlFHIKi0Wfko5ZyJuDBfkV1JoShSYsWCG-0CPOjAksr1kA_XyV_LTbgSs6s1br3y2UA";
			this.class4_0.method_4("Adding to cart", "yellow", true, false);
		}
		for (;;)
		{
			int num = 0;
			try
			{
				this.class4_0.method_4("Adding to cart", "yellow", true, false);
				HttpResponseMessage httpResponseMessage = await this.class70_0.method_10(string.Format("https://www.{0}/api/users/carts/current/entries", this.string_3), jobject2);
				string text = await httpResponseMessage.smethod_4();
				if (!text.Contains("maximum quantity limit") && !text.Contains("ProductLowStockException"))
				{
					httpResponseMessage.EnsureSuccessStatusCode();
					this.string_7 = httpResponseMessage.smethod_0()["guid"].ToString();
					this.class70_0.httpClient_0.DefaultRequestHeaders.TryAddWithoutValidation("x-csrf-token", httpResponseMessage.Headers.GetValues("x-csrf-token").First<string>());
					break;
				}
				this.class4_0.method_4("Waiting for restock", "#c2c2c2", true, false);
				await Task.Delay(GClass0.int_0);
				await this.method_1();
				continue;
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

	// Token: 0x06000311 RID: 785 RVA: 0x00018DD0 File Offset: 0x00016FD0
	public async Task method_4()
	{
		for (;;)
		{
			int num = 0;
			try
			{
				this.class4_0.method_4("Setting email", "#c2c2c2", true, false);
				TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class70_0.httpClient_0.PutAsync(string.Format("https://www.{0}/api/users/carts/current/email/{1}", this.string_3, this.jtoken_0["payment"]["email"]), new StringContent("{}", Encoding.UTF8, "application/json")).GetAwaiter();
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
				this.class4_0.method_4("Error setting email", "#c2c2c2", true, false);
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

	// Token: 0x06000312 RID: 786 RVA: 0x00018E18 File Offset: 0x00017018
	public async Task method_5()
	{
		await this.task_1;
		JObject jobject = new JObject(new JProperty("shippingAddress", new JObject()));
		jobject["shippingAddress"]["country"] = new JObject();
		jobject["shippingAddress"]["country"]["isocode"] = Class167.smethod_0(this.jtoken_0["delivery"]["country"].ToString(), false);
		jobject["shippingAddress"]["country"]["name"] = this.jtoken_0["delivery"]["country"];
		jobject["shippingAddress"]["region"] = new JObject();
		jobject["shippingAddress"]["region"]["isocode"] = Class167.smethod_0(this.jtoken_0["delivery"]["country"].ToString(), false) + "-" + Class167.smethod_1(this.jtoken_0["delivery"]["country"].ToString(), this.jtoken_0["delivery"]["state"].ToString());
		jobject["shippingAddress"]["type"] = "Home/Business Address";
		jobject["shippingAddress"]["setAsBilling"] = true;
		jobject["shippingAddress"]["firstName"] = this.jtoken_0["delivery"]["first_name"];
		jobject["shippingAddress"]["lastName"] = this.jtoken_0["delivery"]["last_name"];
		jobject["shippingAddress"]["line1"] = this.jtoken_0["delivery"]["addr1"];
		jobject["shippingAddress"]["line2"] = this.jtoken_0["delivery"]["addr2"];
		jobject["shippingAddress"]["postalCode"] = this.jtoken_0["delivery"]["zip"];
		jobject["shippingAddress"]["phone"] = this.jtoken_0["payment"]["phone"];
		jobject["shippingAddress"]["email"] = this.jtoken_0["payment"]["email"];
		jobject["shippingAddress"]["town"] = this.jtoken_0["delivery"]["city"];
		jobject["shippingAddress"]["isFPO"] = false;
		jobject["shippingAddress"]["shippingAddress"] = true;
		for (;;)
		{
			int num = 0;
			try
			{
				this.class4_0.method_4("Submitting shipping", "#c2c2c2", true, false);
				TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class70_0.method_10(string.Format("https://www.{0}/api/users/carts/current/addresses/shipping", this.string_3), jobject).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter<HttpResponseMessage> taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
				}
				HttpResponseMessage result = taskAwaiter.GetResult();
				result.EnsureSuccessStatusCode();
				TaskAwaiter<JObject> taskAwaiter3 = result.smethod_1().GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter<JObject> taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter<JObject>);
				}
				this.string_6 = taskAwaiter3.GetResult()["id"].ToString();
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
				TaskAwaiter taskAwaiter5 = Task.Delay(GClass0.int_1).GetAwaiter();
				if (!taskAwaiter5.IsCompleted)
				{
					await taskAwaiter5;
					TaskAwaiter taskAwaiter6;
					taskAwaiter5 = taskAwaiter6;
					taskAwaiter6 = default(TaskAwaiter);
				}
				taskAwaiter5.GetResult();
			}
		}
	}

	// Token: 0x06000313 RID: 787 RVA: 0x00018E60 File Offset: 0x00017060
	public async Task method_6()
	{
		await this.task_1;
		JObject jobject = new JObject(new JProperty("shippingAddress", new JObject()));
		jobject["country"] = new JObject();
		jobject["country"]["isocode"] = Class167.smethod_0(this.jtoken_0["billing"]["country"].ToString(), false);
		jobject["country"]["name"] = this.jtoken_0["billing"]["country"];
		jobject["region"] = new JObject();
		jobject["region"]["isocode"] = Class167.smethod_0(this.jtoken_0["billing"]["country"].ToString(), false) + "-" + Class167.smethod_1(this.jtoken_0["billing"]["country"].ToString(), this.jtoken_0["delivery"]["state"].ToString());
		jobject["type"] = "Home/Business Address";
		jobject["setAsBilling"] = true;
		jobject["firstName"] = this.jtoken_0["billing"]["first_name"];
		jobject["lastName"] = this.jtoken_0["billing"]["last_name"];
		jobject["line1"] = this.jtoken_0["billing"]["addr1"];
		jobject["line2"] = this.jtoken_0["billing"]["addr2"];
		jobject["postalCode"] = this.jtoken_0["billing"]["zip"];
		jobject["phone"] = this.jtoken_0["payment"]["phone"];
		jobject["email"] = this.jtoken_0["payment"]["email"];
		jobject["town"] = this.jtoken_0["billing"]["city"];
		jobject["isFPO"] = false;
		jobject["shippingAddress"] = false;
		for (;;)
		{
			int num = 0;
			try
			{
				this.class4_0.method_4("Submitting billing", "#c2c2c2", true, false);
				TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class70_0.method_10(string.Format("https://www.{0}/api/users/carts/current/set-billing", this.string_3), jobject).GetAwaiter();
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
				this.class4_0.method_4("Error submitting billing", "#c2c2c2", true, false);
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

	// Token: 0x06000314 RID: 788 RVA: 0x00018EA8 File Offset: 0x000170A8
	public async Task method_7()
	{
		Dictionary<string, string> dictionary = Class70.smethod_1();
		dictionary["action"] = "authorize";
		dictionary["companyNumber"] = "1";
		dictionary["customerNumber"] = "1";
		dictionary["cardNumber"] = this.jtoken_0["payment"]["card"]["number"].ToString().Replace(" ", string.Empty);
		for (;;)
		{
			int num = 0;
			try
			{
				this.class4_0.method_4("Getting payment token", "#c2c2c2", true, false);
				TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class70_0.method_8(string.Format("https://www.{0}/paygate/ccn", this.string_3), dictionary, false).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter<HttpResponseMessage> taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
				}
				HttpResponseMessage result = taskAwaiter.GetResult();
				result.EnsureSuccessStatusCode();
				TaskAwaiter<string> taskAwaiter3 = result.smethod_4().GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter<string> taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter<string>);
				}
				this.string_5 = taskAwaiter3.GetResult().Replace(" ", string.Empty).Split(new string[]
				{
					"token:'"
				}, StringSplitOptions.None)[1].Split(new char[]
				{
					'\''
				})[0];
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
				this.class4_0.method_4("Error getting payment token", "#c2c2c2", true, false);
				TaskAwaiter taskAwaiter5 = Task.Delay(GClass0.int_1).GetAwaiter();
				if (!taskAwaiter5.IsCompleted)
				{
					await taskAwaiter5;
					TaskAwaiter taskAwaiter6;
					taskAwaiter5 = taskAwaiter6;
					taskAwaiter6 = default(TaskAwaiter);
				}
				taskAwaiter5.GetResult();
			}
		}
	}

	// Token: 0x06000315 RID: 789 RVA: 0x00018EF0 File Offset: 0x000170F0
	public async Task method_8()
	{
		await this.task_4;
		await this.task_5;
		JObject jobject = new JObject();
		jobject["cardType"] = new JObject();
		jobject["cardType"]["code"] = "master";
		jobject["billingAddress"] = new JObject();
		jobject["billingAddress"]["id"] = this.string_6;
		jobject["flApiCCNumber"] = this.string_5;
		jobject["expiryMonth"] = this.jtoken_0["payment"]["card"]["exp_month"];
		jobject["expiryYear"] = this.jtoken_0["payment"]["card"]["exp_year"];
		for (;;)
		{
			int num = 0;
			try
			{
				this.class4_0.method_4("Submitting payment", "#c2c2c2", true, false);
				TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class70_0.method_10(string.Format("https://www.{0}/api/users/carts/current/payment-detail", this.string_3), jobject).GetAwaiter();
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
				this.class4_0.method_4("Error submitting payment", "#c2c2c2", true, false);
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

	// Token: 0x06000316 RID: 790 RVA: 0x00018F38 File Offset: 0x00017138
	public async Task method_9()
	{
		for (;;)
		{
			int num = 0;
			try
			{
				this.class4_0.method_4("Submitting order", "orange", true, false);
				JObject jobject = new JObject();
				jobject["cartId"] = this.string_7;
				jobject["securityCode"] = this.jtoken_0["payment"]["card"]["cvv"];
				jobject["deviceId"] = GClass2.smethod_2(50);
				HttpResponseMessage httpResponseMessage = await this.class70_0.method_10(string.Format("https://www.{0}/api/users/orders", this.string_3), jobject);
				HttpResponseMessage httpResponseMessage_ = httpResponseMessage;
				JObject jobject2 = await httpResponseMessage_.smethod_1();
				string text = await httpResponseMessage_.smethod_4();
				if (text.Contains("we are unable to process your credit card"))
				{
					this.class4_0.method_9(true);
					this.class4_0.method_0("Payment Declined", "red", false);
				}
				else if (jobject2["calculated"] != null)
				{
					this.class4_0.method_12();
					this.class4_0.method_9(false);
					this.class4_0.method_0("Successfully checked out", "green", false);
				}
				else if (text.Contains("shipping is restricted"))
				{
					this.class4_0.method_0("Shipping restricted", "red", false);
				}
				else
				{
					this.class4_0.method_0("Payment error", "red", false);
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
				this.class4_0.method_4("Error submitting order", "#c2c2c2", true, false);
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

	// Token: 0x06000317 RID: 791 RVA: 0x0000480E File Offset: 0x00002A0E
	private bool method_10(JToken jtoken_2)
	{
		return jtoken_2["sku"].ToString() == this.string_1;
	}

	// Token: 0x06000318 RID: 792 RVA: 0x00018F80 File Offset: 0x00017180
	private bool method_11(JToken jtoken_2)
	{
		return jtoken_2["attributes"].First(new Func<JToken, bool>(Class80.Class81.class81_0.method_0))["id"].ToString() == this.string_2 && jtoken_2["stockLevelStatus"].ToString() == "inStock";
	}

	// Token: 0x06000319 RID: 793 RVA: 0x00018FF4 File Offset: 0x000171F4
	private bool method_12(JToken jtoken_2)
	{
		if (jtoken_2["attributes"].First(new Func<JToken, bool>(Class80.Class81.class81_0.method_2))["id"].ToString() == this.string_2)
		{
			return Class167.smethod_2(this.string_4, jtoken_2["attributes"].First(new Func<JToken, bool>(Class80.Class81.class81_0.method_3))["value"].ToString());
		}
		return false;
	}

	// Token: 0x040001AA RID: 426
	private Class70 class70_0;

	// Token: 0x040001AB RID: 427
	private Class4 class4_0;

	// Token: 0x040001AC RID: 428
	private JToken jtoken_0;

	// Token: 0x040001AD RID: 429
	private int int_0;

	// Token: 0x040001AE RID: 430
	private JToken jtoken_1;

	// Token: 0x040001AF RID: 431
	private string string_0;

	// Token: 0x040001B0 RID: 432
	private string string_1;

	// Token: 0x040001B1 RID: 433
	private string string_2;

	// Token: 0x040001B2 RID: 434
	private string string_3;

	// Token: 0x040001B3 RID: 435
	private string string_4;

	// Token: 0x040001B4 RID: 436
	private bool bool_0;

	// Token: 0x040001B5 RID: 437
	private string string_5;

	// Token: 0x040001B6 RID: 438
	private string string_6;

	// Token: 0x040001B7 RID: 439
	private string string_7;

	// Token: 0x040001B8 RID: 440
	private bool bool_1;

	// Token: 0x040001B9 RID: 441
	private string string_8 = "6Lf9IxgUAAAAAHHz804d0SNSePsBEY7ZYsBALSHT";

	// Token: 0x040001BA RID: 442
	private Task task_0;

	// Token: 0x040001BB RID: 443
	private Task task_1;

	// Token: 0x040001BC RID: 444
	private Task task_2;

	// Token: 0x040001BD RID: 445
	private Task task_3;

	// Token: 0x040001BE RID: 446
	private Task task_4;

	// Token: 0x040001BF RID: 447
	private Task task_5;

	// Token: 0x02000093 RID: 147
	[Serializable]
	private sealed class Class81
	{
		// Token: 0x0600031C RID: 796 RVA: 0x00004837 File Offset: 0x00002A37
		internal bool method_0(JToken jtoken_0)
		{
			return jtoken_0["type"].ToString() == "style";
		}

		// Token: 0x0600031D RID: 797 RVA: 0x00004853 File Offset: 0x00002A53
		internal bool method_1(JToken jtoken_0)
		{
			return jtoken_0["type"].ToString() == "size";
		}

		// Token: 0x0600031E RID: 798 RVA: 0x00004837 File Offset: 0x00002A37
		internal bool method_2(JToken jtoken_0)
		{
			return jtoken_0["type"].ToString() == "style";
		}

		// Token: 0x0600031F RID: 799 RVA: 0x00004853 File Offset: 0x00002A53
		internal bool method_3(JToken jtoken_0)
		{
			return jtoken_0["type"].ToString() == "size";
		}

		// Token: 0x040001C0 RID: 448
		public static readonly Class80.Class81 class81_0 = new Class80.Class81();

		// Token: 0x040001C1 RID: 449
		public static Func<JToken, bool> func_0;

		// Token: 0x040001C2 RID: 450
		public static Func<JToken, bool> func_1;

		// Token: 0x040001C3 RID: 451
		public static Func<JToken, bool> func_2;

		// Token: 0x040001C4 RID: 452
		public static Func<JToken, bool> func_3;
	}

	// Token: 0x02000094 RID: 148
	[StructLayout(LayoutKind.Auto)]
	private struct Struct27 : IAsyncStateMachine
	{
		// Token: 0x06000320 RID: 800 RVA: 0x00019098 File Offset: 0x00017298
		void IAsyncStateMachine.MoveNext()
		{
			int num = this.int_0;
			Class80 @class = this.class80_0;
			try
			{
				TaskAwaiter awaiter;
				int num5;
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
					IL_39A:
					try
					{
						TaskAwaiter<HttpResponseMessage> awaiter2;
						if (num != 1)
						{
							@class.class4_0.method_4("Submitting billing", "#c2c2c2", true, false);
							awaiter2 = @class.class70_0.method_10(string.Format("https://www.{0}/api/users/carts/current/set-billing", @class.string_3), this.jobject_0).GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								int num3 = 1;
								num = 1;
								this.int_0 = num3;
								this.taskAwaiter_1 = awaiter2;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class80.Struct27>(ref awaiter2, ref this);
								return;
							}
						}
						else
						{
							awaiter2 = this.taskAwaiter_1;
							this.taskAwaiter_1 = default(TaskAwaiter<HttpResponseMessage>);
							int num4 = -1;
							num = -1;
							this.int_0 = num4;
						}
						awaiter2.GetResult().EnsureSuccessStatusCode();
						goto IL_4C4;
					}
					catch (ThreadAbortException)
					{
						goto IL_4C4;
					}
					catch
					{
						num5 = 1;
					}
					if (num5 != 1)
					{
						goto IL_44B;
					}
					@class.class4_0.method_4("Error submitting billing", "#c2c2c2", true, false);
					awaiter = Task.Delay(GClass0.int_1).GetAwaiter();
					if (awaiter.IsCompleted)
					{
						goto IL_482;
					}
					int num6 = 2;
					num = 2;
					this.int_0 = num6;
					this.taskAwaiter_0 = awaiter;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class80.Struct27>(ref awaiter, ref this);
					return;
				}
				case 2:
				{
					awaiter = this.taskAwaiter_0;
					this.taskAwaiter_0 = default(TaskAwaiter);
					int num7 = -1;
					num = -1;
					this.int_0 = num7;
					goto IL_482;
				}
				default:
					awaiter = @class.task_1.GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						int num8 = 0;
						num = 0;
						this.int_0 = num8;
						this.taskAwaiter_0 = awaiter;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class80.Struct27>(ref awaiter, ref this);
						return;
					}
					break;
				}
				awaiter.GetResult();
				this.jobject_0 = new JObject(new JProperty("shippingAddress", new JObject()));
				this.jobject_0["country"] = new JObject();
				this.jobject_0["country"]["isocode"] = Class167.smethod_0(@class.jtoken_0["billing"]["country"].ToString(), false);
				this.jobject_0["country"]["name"] = @class.jtoken_0["billing"]["country"];
				this.jobject_0["region"] = new JObject();
				this.jobject_0["region"]["isocode"] = Class167.smethod_0(@class.jtoken_0["billing"]["country"].ToString(), false) + "-" + Class167.smethod_1(@class.jtoken_0["billing"]["country"].ToString(), @class.jtoken_0["delivery"]["state"].ToString());
				this.jobject_0["type"] = "Home/Business Address";
				this.jobject_0["setAsBilling"] = true;
				this.jobject_0["firstName"] = @class.jtoken_0["billing"]["first_name"];
				this.jobject_0["lastName"] = @class.jtoken_0["billing"]["last_name"];
				this.jobject_0["line1"] = @class.jtoken_0["billing"]["addr1"];
				this.jobject_0["line2"] = @class.jtoken_0["billing"]["addr2"];
				this.jobject_0["postalCode"] = @class.jtoken_0["billing"]["zip"];
				this.jobject_0["phone"] = @class.jtoken_0["payment"]["phone"];
				this.jobject_0["email"] = @class.jtoken_0["payment"]["email"];
				this.jobject_0["town"] = @class.jtoken_0["billing"]["city"];
				this.jobject_0["isFPO"] = false;
				this.jobject_0["shippingAddress"] = false;
				IL_44B:
				num5 = 0;
				goto IL_39A;
				IL_482:
				awaiter.GetResult();
				goto IL_44B;
			}
			catch (Exception exception)
			{
				this.int_0 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_4C4:
			this.int_0 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000321 RID: 801 RVA: 0x0000486F File Offset: 0x00002A6F
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040001C5 RID: 453
		public int int_0;

		// Token: 0x040001C6 RID: 454
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040001C7 RID: 455
		public Class80 class80_0;

		// Token: 0x040001C8 RID: 456
		private JObject jobject_0;

		// Token: 0x040001C9 RID: 457
		private TaskAwaiter taskAwaiter_0;

		// Token: 0x040001CA RID: 458
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_1;
	}

	// Token: 0x02000095 RID: 149
	[StructLayout(LayoutKind.Auto)]
	private struct Struct28 : IAsyncStateMachine
	{
		// Token: 0x06000322 RID: 802 RVA: 0x000195C8 File Offset: 0x000177C8
		void IAsyncStateMachine.MoveNext()
		{
			int num = this.int_0;
			Class80 @class = this.class80_0;
			try
			{
				TaskAwaiter awaiter;
				if (num > 3)
				{
					if (num == 4)
					{
						awaiter = this.taskAwaiter_2;
						this.taskAwaiter_2 = default(TaskAwaiter);
						int num2 = -1;
						num = -1;
						this.int_0 = num2;
						goto IL_375;
					}
					JObject jobject = new JObject();
					jobject["productId"] = @class.string_0;
					jobject["productQuantity"] = "1";
					this.jobject_0 = jobject;
					if (@class.bool_1)
					{
						@class.class4_0.method_4("Waiting for captcha", "turquoise", true, false);
						this.jobject_0["g-recaptcha-response"] = "03AJpayVHiEb9A_5g6z1Dfc_lPxQN7tRhAYf9bxCEQtwx7yRDuCNefGi1RpoQ5fmb7hVx0GVp5Xd5S-O0K3_DzVlKYNKZgNvsGr9VoFcwOCArpECry3oSTAsIa4zoa2d9ojkQVvczakU__iBsKzQntJa6gsyV15juQkkhPGAFiyJrEIxBdiBTdvdgVgiO2whkba3d9FvOpnQSLXht0EoUgUb4pD0oFexemT0BrWlQjqXUOv7LVd0vDtjsOWdqeNJd_nXcHW2NwOMPs-XPsPI9v5VkYipiilieQvuccjSPwicRmXZEBXMHyhfgj5J_G37ezer0bj9sWpI4Spzf6zsPFUcejACU2MgFPdPE-B3jB_RtNwuNwoyM6Q5MNY3TE2_9JO7NDQus3cdZkrrtaTeL7HyrBYNYqBNBrlFHIKi0Wfko5ZyJuDBfkV1JoShSYsWCG-0CPOjAksr1kA_XyV_LTbgSs6s1br3y2UA";
						@class.class4_0.method_4("Adding to cart", "yellow", true, false);
						goto IL_37C;
					}
					goto IL_37C;
				}
				IL_CB:
				int num11;
				try
				{
					TaskAwaiter<HttpResponseMessage> awaiter2;
					TaskAwaiter<string> awaiter3;
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
						awaiter3 = this.taskAwaiter_1;
						this.taskAwaiter_1 = default(TaskAwaiter<string>);
						int num4 = -1;
						num = -1;
						this.int_0 = num4;
						goto IL_1D8;
					}
					case 2:
					{
						awaiter = this.taskAwaiter_2;
						this.taskAwaiter_2 = default(TaskAwaiter);
						int num5 = -1;
						num = -1;
						this.int_0 = num5;
						goto IL_2D2;
					}
					case 3:
					{
						awaiter = this.taskAwaiter_2;
						this.taskAwaiter_2 = default(TaskAwaiter);
						int num6 = -1;
						num = -1;
						this.int_0 = num6;
						goto IL_32D;
					}
					default:
						@class.class4_0.method_4("Adding to cart", "yellow", true, false);
						awaiter2 = @class.class70_0.method_10(string.Format("https://www.{0}/api/users/carts/current/entries", @class.string_3), this.jobject_0).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							int num7 = 0;
							num = 0;
							this.int_0 = num7;
							this.taskAwaiter_0 = awaiter2;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class80.Struct28>(ref awaiter2, ref this);
							return;
						}
						break;
					}
					HttpResponseMessage result = awaiter2.GetResult();
					this.httpResponseMessage_0 = result;
					awaiter3 = this.httpResponseMessage_0.smethod_4().GetAwaiter();
					if (!awaiter3.IsCompleted)
					{
						int num8 = 1;
						num = 1;
						this.int_0 = num8;
						this.taskAwaiter_1 = awaiter3;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class80.Struct28>(ref awaiter3, ref this);
						return;
					}
					IL_1D8:
					string result2 = awaiter3.GetResult();
					if (!result2.Contains("maximum quantity limit") && !result2.Contains("ProductLowStockException"))
					{
						this.httpResponseMessage_0.EnsureSuccessStatusCode();
						@class.string_7 = this.httpResponseMessage_0.smethod_0()["guid"].ToString();
						@class.class70_0.httpClient_0.DefaultRequestHeaders.TryAddWithoutValidation("x-csrf-token", this.httpResponseMessage_0.Headers.GetValues("x-csrf-token").First<string>());
						goto IL_3BC;
					}
					@class.class4_0.method_4("Waiting for restock", "#c2c2c2", true, false);
					awaiter = Task.Delay(GClass0.int_0).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						int num9 = 2;
						num = 2;
						this.int_0 = num9;
						this.taskAwaiter_2 = awaiter;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class80.Struct28>(ref awaiter, ref this);
						return;
					}
					IL_2D2:
					awaiter.GetResult();
					awaiter = @class.method_1().GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						int num10 = 3;
						num = 3;
						this.int_0 = num10;
						this.taskAwaiter_2 = awaiter;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class80.Struct28>(ref awaiter, ref this);
						return;
					}
					IL_32D:
					awaiter.GetResult();
					goto IL_37C;
				}
				catch (ThreadAbortException)
				{
					goto IL_3BC;
				}
				catch
				{
					num11 = 1;
				}
				if (num11 != 1)
				{
					goto IL_37C;
				}
				@class.class4_0.method_4("Error adding to cart", "#c2c2c2", true, false);
				awaiter = Task.Delay(GClass0.int_1).GetAwaiter();
				if (!awaiter.IsCompleted)
				{
					int num12 = 4;
					num = 4;
					this.int_0 = num12;
					this.taskAwaiter_2 = awaiter;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class80.Struct28>(ref awaiter, ref this);
					return;
				}
				IL_375:
				awaiter.GetResult();
				IL_37C:
				num11 = 0;
				goto IL_CB;
			}
			catch (Exception exception)
			{
				this.int_0 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_3BC:
			this.int_0 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000323 RID: 803 RVA: 0x0000487D File Offset: 0x00002A7D
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040001CB RID: 459
		public int int_0;

		// Token: 0x040001CC RID: 460
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040001CD RID: 461
		public Class80 class80_0;

		// Token: 0x040001CE RID: 462
		private JObject jobject_0;

		// Token: 0x040001CF RID: 463
		private HttpResponseMessage httpResponseMessage_0;

		// Token: 0x040001D0 RID: 464
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x040001D1 RID: 465
		private TaskAwaiter<string> taskAwaiter_1;

		// Token: 0x040001D2 RID: 466
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x02000096 RID: 150
	[StructLayout(LayoutKind.Auto)]
	private struct Struct29 : IAsyncStateMachine
	{
		// Token: 0x06000324 RID: 804 RVA: 0x000199F0 File Offset: 0x00017BF0
		void IAsyncStateMachine.MoveNext()
		{
			int num = this.int_0;
			Class80 @class = this.class80_0;
			try
			{
				if (num <= 2)
				{
					goto IL_318;
				}
				if (num != 3)
				{
					goto IL_316;
				}
				TaskAwaiter awaiter = this.taskAwaiter_3;
				this.taskAwaiter_3 = default(TaskAwaiter);
				int num2 = -1;
				num = -1;
				this.int_0 = num2;
				IL_30F:
				awaiter.GetResult();
				IL_316:
				int num3 = 0;
				IL_318:
				try
				{
					TaskAwaiter<HttpResponseMessage> awaiter2;
					TaskAwaiter<JObject> awaiter3;
					TaskAwaiter<string> awaiter4;
					switch (num)
					{
					case 0:
					{
						awaiter2 = this.taskAwaiter_0;
						this.taskAwaiter_0 = default(TaskAwaiter<HttpResponseMessage>);
						int num4 = -1;
						num = -1;
						this.int_0 = num4;
						break;
					}
					case 1:
					{
						awaiter3 = this.taskAwaiter_1;
						this.taskAwaiter_1 = default(TaskAwaiter<JObject>);
						int num5 = -1;
						num = -1;
						this.int_0 = num5;
						goto IL_1A5;
					}
					case 2:
					{
						awaiter4 = this.taskAwaiter_2;
						this.taskAwaiter_2 = default(TaskAwaiter<string>);
						int num6 = -1;
						num = -1;
						this.int_0 = num6;
						goto IL_212;
					}
					default:
					{
						@class.class4_0.method_4("Submitting order", "orange", true, false);
						JObject jobject = new JObject();
						jobject["cartId"] = @class.string_7;
						jobject["securityCode"] = @class.jtoken_0["payment"]["card"]["cvv"];
						jobject["deviceId"] = GClass2.smethod_2(50);
						awaiter2 = @class.class70_0.method_10(string.Format("https://www.{0}/api/users/orders", @class.string_3), jobject).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							int num7 = 0;
							num = 0;
							this.int_0 = num7;
							this.taskAwaiter_0 = awaiter2;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class80.Struct29>(ref awaiter2, ref this);
							return;
						}
						break;
					}
					}
					HttpResponseMessage result = awaiter2.GetResult();
					this.httpResponseMessage_0 = result;
					awaiter3 = this.httpResponseMessage_0.smethod_1().GetAwaiter();
					if (!awaiter3.IsCompleted)
					{
						int num8 = 1;
						num = 1;
						this.int_0 = num8;
						this.taskAwaiter_1 = awaiter3;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class80.Struct29>(ref awaiter3, ref this);
						return;
					}
					IL_1A5:
					JObject result2 = awaiter3.GetResult();
					this.jobject_0 = result2;
					awaiter4 = this.httpResponseMessage_0.smethod_4().GetAwaiter();
					if (!awaiter4.IsCompleted)
					{
						int num9 = 2;
						num = 2;
						this.int_0 = num9;
						this.taskAwaiter_2 = awaiter4;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class80.Struct29>(ref awaiter4, ref this);
						return;
					}
					IL_212:
					string result3 = awaiter4.GetResult();
					if (result3.Contains("we are unable to process your credit card"))
					{
						@class.class4_0.method_9(true);
						@class.class4_0.method_0("Payment Declined", "red", false);
					}
					else if (this.jobject_0["calculated"] != null)
					{
						@class.class4_0.method_12();
						@class.class4_0.method_9(false);
						@class.class4_0.method_0("Successfully checked out", "green", false);
					}
					else if (result3.Contains("shipping is restricted"))
					{
						@class.class4_0.method_0("Shipping restricted", "red", false);
					}
					else
					{
						@class.class4_0.method_0("Payment error", "red", false);
					}
					goto IL_358;
				}
				catch (ThreadAbortException)
				{
					goto IL_358;
				}
				catch
				{
					num3 = 1;
				}
				if (num3 != 1)
				{
					goto IL_316;
				}
				@class.class4_0.method_4("Error submitting order", "#c2c2c2", true, false);
				awaiter = Task.Delay(GClass0.int_1).GetAwaiter();
				if (awaiter.IsCompleted)
				{
					goto IL_30F;
				}
				int num10 = 3;
				num = 3;
				this.int_0 = num10;
				this.taskAwaiter_3 = awaiter;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class80.Struct29>(ref awaiter, ref this);
				return;
			}
			catch (Exception exception)
			{
				this.int_0 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_358:
			this.int_0 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000325 RID: 805 RVA: 0x0000488B File Offset: 0x00002A8B
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040001D3 RID: 467
		public int int_0;

		// Token: 0x040001D4 RID: 468
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040001D5 RID: 469
		public Class80 class80_0;

		// Token: 0x040001D6 RID: 470
		private HttpResponseMessage httpResponseMessage_0;

		// Token: 0x040001D7 RID: 471
		private JObject jobject_0;

		// Token: 0x040001D8 RID: 472
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x040001D9 RID: 473
		private TaskAwaiter<JObject> taskAwaiter_1;

		// Token: 0x040001DA RID: 474
		private TaskAwaiter<string> taskAwaiter_2;

		// Token: 0x040001DB RID: 475
		private TaskAwaiter taskAwaiter_3;
	}

	// Token: 0x02000097 RID: 151
	[StructLayout(LayoutKind.Auto)]
	private struct Struct30 : IAsyncStateMachine
	{
		// Token: 0x06000326 RID: 806 RVA: 0x00019DB4 File Offset: 0x00017FB4
		void IAsyncStateMachine.MoveNext()
		{
			int num = this.int_0;
			Class80 @class = this.class80_0;
			try
			{
				TaskAwaiter awaiter;
				if (num > 4)
				{
					if (num != 5)
					{
						@class.class4_0.method_4("Waiting for product", "#c2c2c2", true, false);
						goto IL_559;
					}
					awaiter = this.taskAwaiter_2;
					this.taskAwaiter_2 = default(TaskAwaiter);
					int num2 = -1;
					num = -1;
					this.int_0 = num2;
					goto IL_53B;
				}
				IL_53:
				try
				{
					TaskAwaiter<HttpResponseMessage> awaiter2;
					TaskAwaiter<JObject> awaiter3;
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
						awaiter3 = this.taskAwaiter_1;
						this.taskAwaiter_1 = default(TaskAwaiter<JObject>);
						int num4 = -1;
						num = -1;
						this.int_0 = num4;
						goto IL_145;
					}
					case 2:
					{
						awaiter = this.taskAwaiter_2;
						this.taskAwaiter_2 = default(TaskAwaiter);
						int num5 = -1;
						num = -1;
						this.int_0 = num5;
						goto IL_4AF;
					}
					case 3:
					{
						awaiter = this.taskAwaiter_2;
						this.taskAwaiter_2 = default(TaskAwaiter);
						int num6 = -1;
						num = -1;
						this.int_0 = num6;
						goto IL_4D7;
					}
					case 4:
					{
						awaiter = this.taskAwaiter_2;
						this.taskAwaiter_2 = default(TaskAwaiter);
						int num7 = -1;
						num = -1;
						this.int_0 = num7;
						goto IL_4FC;
					}
					default:
						awaiter2 = @class.class70_0.method_6(string.Format("https://www.{0}/api/products/pdp/{1}", @class.string_3, @class.string_1), false).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							int num8 = 0;
							num = 0;
							this.int_0 = num8;
							this.taskAwaiter_0 = awaiter2;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class80.Struct30>(ref awaiter2, ref this);
							return;
						}
						break;
					}
					HttpResponseMessage result = awaiter2.GetResult();
					result.EnsureSuccessStatusCode();
					awaiter3 = result.smethod_1().GetAwaiter();
					if (!awaiter3.IsCompleted)
					{
						int num9 = 1;
						num = 1;
						this.int_0 = num9;
						this.taskAwaiter_1 = awaiter3;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class80.Struct30>(ref awaiter3, ref this);
						return;
					}
					IL_145:
					JObject result2 = awaiter3.GetResult();
					@class.class4_0.method_7(result2["name"].ToString(), "#c2c2c2");
					JToken jtoken = result2["variantAttributes"].FirstOrDefault(new Func<JToken, bool>(@class.method_10));
					if (jtoken == null)
					{
						@class.class4_0.method_0("Product pulled", "red", false);
						goto IL_515;
					}
					@class.bool_1 = (bool)jtoken["recaptchaOn"];
					@class.int_0 = (((bool)jtoken["displayCountDownTimer"]) ? Convert.ToInt32(Convert.ToDateTime(jtoken["skuLaunchDate"].ToString().Replace(" GMT+0000", string.Empty)).Subtract(DateTime.UtcNow).TotalSeconds) : 0);
					@class.class4_0.method_13(@class.int_0, "Waiting ", 0);
					@class.string_2 = (string)jtoken["code"];
					if (@class.bool_0)
					{
						JToken jtoken2 = result2["sellableUnits"].Where(new Func<JToken, bool>(@class.method_11)).smethod_2();
						if (jtoken2 != null && !(jtoken2["stockLevelStatus"].ToString() != "inStock"))
						{
							@class.class4_0.method_5(jtoken2["attributes"].First(new Func<JToken, bool>(Class80.Class81.class81_0.method_1))["value"].ToString());
							@class.string_0 = jtoken2["code"].ToString();
							@class.class4_0.method_4("Found size code: " + @class.string_0, "#c2c2c2", true, false);
							goto IL_59E;
						}
						@class.class4_0.method_4("Waiting for restock", "#c2c2c2", true, false);
						awaiter = Task.Delay(GClass0.int_0).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							int num10 = 2;
							num = 2;
							this.int_0 = num10;
							this.taskAwaiter_2 = awaiter;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class80.Struct30>(ref awaiter, ref this);
							return;
						}
					}
					else
					{
						JToken jtoken3 = result2["sellableUnits"].FirstOrDefault(new Func<JToken, bool>(@class.method_12));
						if (jtoken3 == null)
						{
							awaiter = Task.Delay(GClass0.int_0).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								int num11 = 3;
								num = 3;
								this.int_0 = num11;
								this.taskAwaiter_2 = awaiter;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class80.Struct30>(ref awaiter, ref this);
								return;
							}
							goto IL_4D7;
						}
						else
						{
							if (!(jtoken3["stockLevelStatus"].ToString() != "inStock"))
							{
								@class.string_0 = jtoken3["code"].ToString();
								@class.class4_0.method_4("Found size code: " + @class.string_0, "#c2c2c2", true, false);
								goto IL_59E;
							}
							@class.class4_0.method_4("Waiting for restock", "#c2c2c2", true, false);
							awaiter = Task.Delay(GClass0.int_0).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								int num12 = 4;
								num = 4;
								this.int_0 = num12;
								this.taskAwaiter_2 = awaiter;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class80.Struct30>(ref awaiter, ref this);
								return;
							}
							goto IL_4FC;
						}
					}
					IL_4AF:
					awaiter.GetResult();
					goto IL_559;
					IL_4D7:
					awaiter.GetResult();
					goto IL_559;
					IL_4FC:
					awaiter.GetResult();
					goto IL_559;
				}
				catch (ThreadAbortException)
				{
					goto IL_59E;
				}
				catch
				{
					this.int_1 = 1;
				}
				IL_515:
				int num13 = this.int_1;
				if (num13 != 1)
				{
					goto IL_559;
				}
				awaiter = Task.Delay(GClass0.int_0).GetAwaiter();
				if (!awaiter.IsCompleted)
				{
					int num14 = 5;
					num = 5;
					this.int_0 = num14;
					this.taskAwaiter_2 = awaiter;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class80.Struct30>(ref awaiter, ref this);
					return;
				}
				IL_53B:
				awaiter.GetResult();
				@class.class4_0.method_4("Waiting for product", "#c2c2c2", false, false);
				IL_559:
				this.int_1 = 0;
				goto IL_53;
			}
			catch (Exception exception)
			{
				this.int_0 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_59E:
			this.int_0 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000327 RID: 807 RVA: 0x00004899 File Offset: 0x00002A99
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040001DC RID: 476
		public int int_0;

		// Token: 0x040001DD RID: 477
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040001DE RID: 478
		public Class80 class80_0;

		// Token: 0x040001DF RID: 479
		private int int_1;

		// Token: 0x040001E0 RID: 480
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x040001E1 RID: 481
		private TaskAwaiter<JObject> taskAwaiter_1;

		// Token: 0x040001E2 RID: 482
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x02000098 RID: 152
	[StructLayout(LayoutKind.Auto)]
	private struct Struct31 : IAsyncStateMachine
	{
		// Token: 0x06000328 RID: 808 RVA: 0x0001A3C0 File Offset: 0x000185C0
		void IAsyncStateMachine.MoveNext()
		{
			int num = this.int_0;
			Class80 @class = this.class80_0;
			try
			{
				TaskAwaiter awaiter;
				int num6;
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
					awaiter = this.taskAwaiter_0;
					this.taskAwaiter_0 = default(TaskAwaiter);
					int num3 = -1;
					num = -1;
					this.int_0 = num3;
					goto IL_D3;
				}
				case 2:
				{
					IL_201:
					try
					{
						TaskAwaiter<HttpResponseMessage> awaiter2;
						if (num != 2)
						{
							@class.class4_0.method_4("Submitting payment", "#c2c2c2", true, false);
							awaiter2 = @class.class70_0.method_10(string.Format("https://www.{0}/api/users/carts/current/payment-detail", @class.string_3), this.jobject_0).GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								int num4 = 2;
								num = 2;
								this.int_0 = num4;
								this.taskAwaiter_1 = awaiter2;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class80.Struct31>(ref awaiter2, ref this);
								return;
							}
						}
						else
						{
							awaiter2 = this.taskAwaiter_1;
							this.taskAwaiter_1 = default(TaskAwaiter<HttpResponseMessage>);
							int num5 = -1;
							num = -1;
							this.int_0 = num5;
						}
						awaiter2.GetResult().EnsureSuccessStatusCode();
						goto IL_32B;
					}
					catch (ThreadAbortException)
					{
						goto IL_32B;
					}
					catch
					{
						num6 = 1;
					}
					if (num6 != 1)
					{
						goto IL_2B2;
					}
					@class.class4_0.method_4("Error submitting payment", "#c2c2c2", true, false);
					awaiter = Task.Delay(GClass0.int_1).GetAwaiter();
					if (awaiter.IsCompleted)
					{
						goto IL_2E9;
					}
					int num7 = 3;
					num = 3;
					this.int_0 = num7;
					this.taskAwaiter_0 = awaiter;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class80.Struct31>(ref awaiter, ref this);
					return;
				}
				case 3:
				{
					awaiter = this.taskAwaiter_0;
					this.taskAwaiter_0 = default(TaskAwaiter);
					int num8 = -1;
					num = -1;
					this.int_0 = num8;
					goto IL_2E9;
				}
				default:
					awaiter = @class.task_4.GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						int num9 = 0;
						num = 0;
						this.int_0 = num9;
						this.taskAwaiter_0 = awaiter;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class80.Struct31>(ref awaiter, ref this);
						return;
					}
					break;
				}
				awaiter.GetResult();
				awaiter = @class.task_5.GetAwaiter();
				if (!awaiter.IsCompleted)
				{
					int num10 = 1;
					num = 1;
					this.int_0 = num10;
					this.taskAwaiter_0 = awaiter;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class80.Struct31>(ref awaiter, ref this);
					return;
				}
				IL_D3:
				awaiter.GetResult();
				this.jobject_0 = new JObject();
				this.jobject_0["cardType"] = new JObject();
				this.jobject_0["cardType"]["code"] = "master";
				this.jobject_0["billingAddress"] = new JObject();
				this.jobject_0["billingAddress"]["id"] = @class.string_6;
				this.jobject_0["flApiCCNumber"] = @class.string_5;
				this.jobject_0["expiryMonth"] = @class.jtoken_0["payment"]["card"]["exp_month"];
				this.jobject_0["expiryYear"] = @class.jtoken_0["payment"]["card"]["exp_year"];
				IL_2B2:
				num6 = 0;
				goto IL_201;
				IL_2E9:
				awaiter.GetResult();
				goto IL_2B2;
			}
			catch (Exception exception)
			{
				this.int_0 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_32B:
			this.int_0 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000329 RID: 809 RVA: 0x000048A7 File Offset: 0x00002AA7
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040001E3 RID: 483
		public int int_0;

		// Token: 0x040001E4 RID: 484
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040001E5 RID: 485
		public Class80 class80_0;

		// Token: 0x040001E6 RID: 486
		private JObject jobject_0;

		// Token: 0x040001E7 RID: 487
		private TaskAwaiter taskAwaiter_0;

		// Token: 0x040001E8 RID: 488
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_1;
	}

	// Token: 0x02000099 RID: 153
	[StructLayout(LayoutKind.Auto)]
	private struct Struct32 : IAsyncStateMachine
	{
		// Token: 0x0600032A RID: 810 RVA: 0x0001A758 File Offset: 0x00018958
		void IAsyncStateMachine.MoveNext()
		{
			int num = this.int_0;
			Class80 @class = this.class80_0;
			try
			{
				if (num <= 1)
				{
					goto IL_218;
				}
				if (num != 2)
				{
					goto IL_216;
				}
				TaskAwaiter awaiter = this.taskAwaiter_2;
				this.taskAwaiter_2 = default(TaskAwaiter);
				int num2 = -1;
				num = -1;
				this.int_0 = num2;
				IL_20F:
				awaiter.GetResult();
				IL_216:
				int num3 = 0;
				IL_218:
				try
				{
					TaskAwaiter<JObject> awaiter2;
					TaskAwaiter<HttpResponseMessage> awaiter3;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter2 = this.taskAwaiter_1;
							this.taskAwaiter_1 = default(TaskAwaiter<JObject>);
							int num4 = -1;
							num = -1;
							this.int_0 = num4;
							goto IL_18E;
						}
						@class.class4_0.method_4("Getting session", "#c2c2c2", true, false);
						awaiter3 = @class.class70_0.method_6(string.Format("https://www.{0}/api/session", @class.string_3), false).GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							int num5 = 0;
							num = 0;
							this.int_0 = num5;
							this.taskAwaiter_0 = awaiter3;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class80.Struct32>(ref awaiter3, ref this);
							return;
						}
					}
					else
					{
						awaiter3 = this.taskAwaiter_0;
						this.taskAwaiter_0 = default(TaskAwaiter<HttpResponseMessage>);
						int num6 = -1;
						num = -1;
						this.int_0 = num6;
					}
					HttpResponseMessage result = awaiter3.GetResult();
					if (result.StatusCode == HttpStatusCode.Found && result.Headers.Location.ToString() == "https://www.footlocker.eu/")
					{
						@class.class4_0.method_0("US proxy required", "red", false);
					}
					result.EnsureSuccessStatusCode();
					this.httpRequestHeaders_0 = @class.class70_0.httpClient_0.DefaultRequestHeaders;
					awaiter2 = result.smethod_1().GetAwaiter();
					if (!awaiter2.IsCompleted)
					{
						int num7 = 1;
						num = 1;
						this.int_0 = num7;
						this.taskAwaiter_1 = awaiter2;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class80.Struct32>(ref awaiter2, ref this);
						return;
					}
					IL_18E:
					JObject result2 = awaiter2.GetResult();
					this.httpRequestHeaders_0.TryAddWithoutValidation("x-csrf-token", result2["data"]["csrfToken"].ToString());
					this.httpRequestHeaders_0 = null;
					goto IL_258;
				}
				catch (ThreadAbortException)
				{
					goto IL_258;
				}
				catch
				{
					num3 = 1;
				}
				if (num3 != 1)
				{
					goto IL_216;
				}
				@class.class4_0.method_4("Error getting session", "#c2c2c2", true, false);
				awaiter = Task.Delay(GClass0.int_1).GetAwaiter();
				if (awaiter.IsCompleted)
				{
					goto IL_20F;
				}
				int num8 = 2;
				num = 2;
				this.int_0 = num8;
				this.taskAwaiter_2 = awaiter;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class80.Struct32>(ref awaiter, ref this);
				return;
			}
			catch (Exception exception)
			{
				this.int_0 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_258:
			this.int_0 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x0600032B RID: 811 RVA: 0x000048B5 File Offset: 0x00002AB5
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040001E9 RID: 489
		public int int_0;

		// Token: 0x040001EA RID: 490
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040001EB RID: 491
		public Class80 class80_0;

		// Token: 0x040001EC RID: 492
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x040001ED RID: 493
		private HttpRequestHeaders httpRequestHeaders_0;

		// Token: 0x040001EE RID: 494
		private TaskAwaiter<JObject> taskAwaiter_1;

		// Token: 0x040001EF RID: 495
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x0200009A RID: 154
	[StructLayout(LayoutKind.Auto)]
	private struct Struct33 : IAsyncStateMachine
	{
		// Token: 0x0600032C RID: 812 RVA: 0x0001AA1C File Offset: 0x00018C1C
		void IAsyncStateMachine.MoveNext()
		{
			int num = this.int_0;
			Class80 @class = this.class80_0;
			try
			{
				if (num <= 1)
				{
					goto IL_262;
				}
				if (num != 2)
				{
					this.dictionary_0 = Class70.smethod_1();
					this.dictionary_0["action"] = "authorize";
					this.dictionary_0["companyNumber"] = "1";
					this.dictionary_0["customerNumber"] = "1";
					this.dictionary_0["cardNumber"] = @class.jtoken_0["payment"]["card"]["number"].ToString().Replace(" ", string.Empty);
					goto IL_260;
				}
				TaskAwaiter awaiter = this.taskAwaiter_2;
				this.taskAwaiter_2 = default(TaskAwaiter);
				int num2 = -1;
				num = -1;
				this.int_0 = num2;
				IL_259:
				awaiter.GetResult();
				IL_260:
				int num3 = 0;
				IL_262:
				try
				{
					TaskAwaiter<string> awaiter2;
					TaskAwaiter<HttpResponseMessage> awaiter3;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter2 = this.taskAwaiter_1;
							this.taskAwaiter_1 = default(TaskAwaiter<string>);
							int num4 = -1;
							num = -1;
							this.int_0 = num4;
							goto IL_1CC;
						}
						@class.class4_0.method_4("Getting payment token", "#c2c2c2", true, false);
						awaiter3 = @class.class70_0.method_8(string.Format("https://www.{0}/paygate/ccn", @class.string_3), this.dictionary_0, false).GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							int num5 = 0;
							num = 0;
							this.int_0 = num5;
							this.taskAwaiter_0 = awaiter3;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class80.Struct33>(ref awaiter3, ref this);
							return;
						}
					}
					else
					{
						awaiter3 = this.taskAwaiter_0;
						this.taskAwaiter_0 = default(TaskAwaiter<HttpResponseMessage>);
						int num6 = -1;
						num = -1;
						this.int_0 = num6;
					}
					HttpResponseMessage result = awaiter3.GetResult();
					result.EnsureSuccessStatusCode();
					awaiter2 = result.smethod_4().GetAwaiter();
					if (!awaiter2.IsCompleted)
					{
						int num7 = 1;
						num = 1;
						this.int_0 = num7;
						this.taskAwaiter_1 = awaiter2;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class80.Struct33>(ref awaiter2, ref this);
						return;
					}
					IL_1CC:
					string result2 = awaiter2.GetResult();
					@class.string_5 = result2.Replace(" ", string.Empty).Split(new string[]
					{
						"token:'"
					}, StringSplitOptions.None)[1].Split(new char[]
					{
						'\''
					})[0];
					goto IL_2A2;
				}
				catch (ThreadAbortException)
				{
					goto IL_2A2;
				}
				catch
				{
					num3 = 1;
				}
				if (num3 != 1)
				{
					goto IL_260;
				}
				@class.class4_0.method_4("Error getting payment token", "#c2c2c2", true, false);
				awaiter = Task.Delay(GClass0.int_1).GetAwaiter();
				if (awaiter.IsCompleted)
				{
					goto IL_259;
				}
				int num8 = 2;
				num = 2;
				this.int_0 = num8;
				this.taskAwaiter_2 = awaiter;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class80.Struct33>(ref awaiter, ref this);
				return;
			}
			catch (Exception exception)
			{
				this.int_0 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_2A2:
			this.int_0 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x0600032D RID: 813 RVA: 0x000048C3 File Offset: 0x00002AC3
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040001F0 RID: 496
		public int int_0;

		// Token: 0x040001F1 RID: 497
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040001F2 RID: 498
		public Class80 class80_0;

		// Token: 0x040001F3 RID: 499
		private Dictionary<string, string> dictionary_0;

		// Token: 0x040001F4 RID: 500
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x040001F5 RID: 501
		private TaskAwaiter<string> taskAwaiter_1;

		// Token: 0x040001F6 RID: 502
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x0200009B RID: 155
	[StructLayout(LayoutKind.Auto)]
	private struct Struct34 : IAsyncStateMachine
	{
		// Token: 0x0600032E RID: 814 RVA: 0x0001AD2C File Offset: 0x00018F2C
		void IAsyncStateMachine.MoveNext()
		{
			int num = this.int_0;
			Class80 @class = this.class80_0;
			try
			{
				TaskAwaiter awaiter;
				int num7;
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
				case 2:
					IL_5B8:
					try
					{
						TaskAwaiter<JObject> awaiter2;
						TaskAwaiter<HttpResponseMessage> awaiter3;
						if (num != 1)
						{
							if (num == 2)
							{
								awaiter2 = this.taskAwaiter_2;
								this.taskAwaiter_2 = default(TaskAwaiter<JObject>);
								int num3 = -1;
								num = -1;
								this.int_0 = num3;
								goto IL_549;
							}
							@class.class4_0.method_4("Submitting shipping", "#c2c2c2", true, false);
							awaiter3 = @class.class70_0.method_10(string.Format("https://www.{0}/api/users/carts/current/addresses/shipping", @class.string_3), this.jobject_0).GetAwaiter();
							if (!awaiter3.IsCompleted)
							{
								int num4 = 1;
								num = 1;
								this.int_0 = num4;
								this.taskAwaiter_1 = awaiter3;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class80.Struct34>(ref awaiter3, ref this);
								return;
							}
						}
						else
						{
							awaiter3 = this.taskAwaiter_1;
							this.taskAwaiter_1 = default(TaskAwaiter<HttpResponseMessage>);
							int num5 = -1;
							num = -1;
							this.int_0 = num5;
						}
						HttpResponseMessage result = awaiter3.GetResult();
						result.EnsureSuccessStatusCode();
						awaiter2 = result.smethod_1().GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							int num6 = 2;
							num = 2;
							this.int_0 = num6;
							this.taskAwaiter_2 = awaiter2;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class80.Struct34>(ref awaiter2, ref this);
							return;
						}
						IL_549:
						JObject result2 = awaiter2.GetResult();
						@class.string_6 = result2["id"].ToString();
						goto IL_5F7;
					}
					catch (ThreadAbortException)
					{
						goto IL_5F7;
					}
					catch
					{
						num7 = 1;
					}
					if (num7 != 1)
					{
						goto IL_57F;
					}
					@class.class4_0.method_4("Error submitting shipping", "#c2c2c2", true, false);
					awaiter = Task.Delay(GClass0.int_1).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						int num8 = 3;
						num = 3;
						this.int_0 = num8;
						this.taskAwaiter_0 = awaiter;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class80.Struct34>(ref awaiter, ref this);
						return;
					}
					goto IL_443;
				case 3:
				{
					awaiter = this.taskAwaiter_0;
					this.taskAwaiter_0 = default(TaskAwaiter);
					int num9 = -1;
					num = -1;
					this.int_0 = num9;
					goto IL_443;
				}
				default:
					awaiter = @class.task_1.GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						int num10 = 0;
						num = 0;
						this.int_0 = num10;
						this.taskAwaiter_0 = awaiter;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class80.Struct34>(ref awaiter, ref this);
						return;
					}
					break;
				}
				awaiter.GetResult();
				this.jobject_0 = new JObject(new JProperty("shippingAddress", new JObject()));
				this.jobject_0["shippingAddress"]["country"] = new JObject();
				this.jobject_0["shippingAddress"]["country"]["isocode"] = Class167.smethod_0(@class.jtoken_0["delivery"]["country"].ToString(), false);
				this.jobject_0["shippingAddress"]["country"]["name"] = @class.jtoken_0["delivery"]["country"];
				this.jobject_0["shippingAddress"]["region"] = new JObject();
				this.jobject_0["shippingAddress"]["region"]["isocode"] = Class167.smethod_0(@class.jtoken_0["delivery"]["country"].ToString(), false) + "-" + Class167.smethod_1(@class.jtoken_0["delivery"]["country"].ToString(), @class.jtoken_0["delivery"]["state"].ToString());
				this.jobject_0["shippingAddress"]["type"] = "Home/Business Address";
				this.jobject_0["shippingAddress"]["setAsBilling"] = true;
				this.jobject_0["shippingAddress"]["firstName"] = @class.jtoken_0["delivery"]["first_name"];
				this.jobject_0["shippingAddress"]["lastName"] = @class.jtoken_0["delivery"]["last_name"];
				this.jobject_0["shippingAddress"]["line1"] = @class.jtoken_0["delivery"]["addr1"];
				this.jobject_0["shippingAddress"]["line2"] = @class.jtoken_0["delivery"]["addr2"];
				this.jobject_0["shippingAddress"]["postalCode"] = @class.jtoken_0["delivery"]["zip"];
				this.jobject_0["shippingAddress"]["phone"] = @class.jtoken_0["payment"]["phone"];
				this.jobject_0["shippingAddress"]["email"] = @class.jtoken_0["payment"]["email"];
				this.jobject_0["shippingAddress"]["town"] = @class.jtoken_0["delivery"]["city"];
				this.jobject_0["shippingAddress"]["isFPO"] = false;
				this.jobject_0["shippingAddress"]["shippingAddress"] = true;
				goto IL_57F;
				IL_443:
				awaiter.GetResult();
				IL_57F:
				num7 = 0;
				goto IL_5B8;
			}
			catch (Exception exception)
			{
				this.int_0 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_5F7:
			this.int_0 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x0600032F RID: 815 RVA: 0x000048D1 File Offset: 0x00002AD1
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040001F7 RID: 503
		public int int_0;

		// Token: 0x040001F8 RID: 504
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040001F9 RID: 505
		public Class80 class80_0;

		// Token: 0x040001FA RID: 506
		private JObject jobject_0;

		// Token: 0x040001FB RID: 507
		private TaskAwaiter taskAwaiter_0;

		// Token: 0x040001FC RID: 508
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_1;

		// Token: 0x040001FD RID: 509
		private TaskAwaiter<JObject> taskAwaiter_2;
	}

	// Token: 0x0200009C RID: 156
	[StructLayout(LayoutKind.Auto)]
	private struct Struct35 : IAsyncStateMachine
	{
		// Token: 0x06000330 RID: 816 RVA: 0x0001B390 File Offset: 0x00019590
		void IAsyncStateMachine.MoveNext()
		{
			int num = this.int_0;
			Class80 @class = this.class80_0;
			try
			{
				if (num == 0)
				{
					goto IL_153;
				}
				if (num != 1)
				{
					goto IL_151;
				}
				TaskAwaiter awaiter = this.taskAwaiter_1;
				this.taskAwaiter_1 = default(TaskAwaiter);
				int num2 = -1;
				num = -1;
				this.int_0 = num2;
				IL_14A:
				awaiter.GetResult();
				IL_151:
				int num3 = 0;
				IL_153:
				try
				{
					TaskAwaiter<HttpResponseMessage> awaiter2;
					if (num != 0)
					{
						@class.class4_0.method_4("Setting email", "#c2c2c2", true, false);
						awaiter2 = @class.class70_0.httpClient_0.PutAsync(string.Format("https://www.{0}/api/users/carts/current/email/{1}", @class.string_3, @class.jtoken_0["payment"]["email"]), new StringContent("{}", Encoding.UTF8, "application/json")).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							int num4 = 0;
							num = 0;
							this.int_0 = num4;
							this.taskAwaiter_0 = awaiter2;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class80.Struct35>(ref awaiter2, ref this);
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
					goto IL_193;
				}
				catch (ThreadAbortException)
				{
					goto IL_193;
				}
				catch
				{
					num3 = 1;
				}
				if (num3 != 1)
				{
					goto IL_151;
				}
				@class.class4_0.method_4("Error setting email", "#c2c2c2", true, false);
				awaiter = Task.Delay(GClass0.int_1).GetAwaiter();
				if (awaiter.IsCompleted)
				{
					goto IL_14A;
				}
				int num6 = 1;
				num = 1;
				this.int_0 = num6;
				this.taskAwaiter_1 = awaiter;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class80.Struct35>(ref awaiter, ref this);
				return;
			}
			catch (Exception exception)
			{
				this.int_0 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_193:
			this.int_0 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000331 RID: 817 RVA: 0x000048DF File Offset: 0x00002ADF
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040001FE RID: 510
		public int int_0;

		// Token: 0x040001FF RID: 511
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000200 RID: 512
		public Class80 class80_0;

		// Token: 0x04000201 RID: 513
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000202 RID: 514
		private TaskAwaiter taskAwaiter_1;
	}

	// Token: 0x0200009D RID: 157
	[StructLayout(LayoutKind.Auto)]
	private struct Struct36 : IAsyncStateMachine
	{
		// Token: 0x06000332 RID: 818 RVA: 0x0001B590 File Offset: 0x00019790
		void IAsyncStateMachine.MoveNext()
		{
			int num = this.int_0;
			Class80 @class = this.class80_0;
			try
			{
				try
				{
					TaskAwaiter awaiter;
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
						awaiter = this.taskAwaiter_0;
						this.taskAwaiter_0 = default(TaskAwaiter);
						int num3 = -1;
						num = -1;
						this.int_0 = num3;
						goto IL_126;
					}
					case 2:
					{
						awaiter = this.taskAwaiter_0;
						this.taskAwaiter_0 = default(TaskAwaiter);
						int num4 = -1;
						num = -1;
						this.int_0 = num4;
						goto IL_181;
					}
					case 3:
					{
						awaiter = this.taskAwaiter_0;
						this.taskAwaiter_0 = default(TaskAwaiter);
						int num5 = -1;
						num = -1;
						this.int_0 = num5;
						goto IL_1DC;
					}
					case 4:
					{
						awaiter = this.taskAwaiter_0;
						this.taskAwaiter_0 = default(TaskAwaiter);
						int num6 = -1;
						num = -1;
						this.int_0 = num6;
						goto IL_237;
					}
					case 5:
					{
						awaiter = this.taskAwaiter_0;
						this.taskAwaiter_0 = default(TaskAwaiter);
						int num7 = -1;
						num = -1;
						this.int_0 = num7;
						goto IL_292;
					}
					case 6:
					{
						awaiter = this.taskAwaiter_0;
						this.taskAwaiter_0 = default(TaskAwaiter);
						int num8 = -1;
						num = -1;
						this.int_0 = num8;
						goto IL_2EA;
					}
					default:
						awaiter = @class.method_2().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							int num9 = 0;
							num = 0;
							this.int_0 = num9;
							this.taskAwaiter_0 = awaiter;
							this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class80.Struct36>(ref awaiter, ref this);
							return;
						}
						break;
					}
					awaiter.GetResult();
					@class.task_1 = @class.method_4();
					@class.task_2 = @class.method_7();
					@class.task_4 = @class.method_5();
					@class.task_5 = @class.method_6();
					@class.task_3 = @class.method_8();
					@class.class4_0.method_8();
					awaiter = @class.method_1().GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						int num10 = 1;
						num = 1;
						this.int_0 = num10;
						this.taskAwaiter_0 = awaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class80.Struct36>(ref awaiter, ref this);
						return;
					}
					IL_126:
					awaiter.GetResult();
					awaiter = @class.method_3().GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						int num11 = 2;
						num = 2;
						this.int_0 = num11;
						this.taskAwaiter_0 = awaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class80.Struct36>(ref awaiter, ref this);
						return;
					}
					IL_181:
					awaiter.GetResult();
					awaiter = @class.task_4.GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						int num12 = 3;
						num = 3;
						this.int_0 = num12;
						this.taskAwaiter_0 = awaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class80.Struct36>(ref awaiter, ref this);
						return;
					}
					IL_1DC:
					awaiter.GetResult();
					awaiter = @class.task_5.GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						int num13 = 4;
						num = 4;
						this.int_0 = num13;
						this.taskAwaiter_0 = awaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class80.Struct36>(ref awaiter, ref this);
						return;
					}
					IL_237:
					awaiter.GetResult();
					awaiter = @class.task_3.GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						int num14 = 5;
						num = 5;
						this.int_0 = num14;
						this.taskAwaiter_0 = awaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class80.Struct36>(ref awaiter, ref this);
						return;
					}
					IL_292:
					awaiter.GetResult();
					awaiter = @class.method_9().GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						int num15 = 6;
						num = 6;
						this.int_0 = num15;
						this.taskAwaiter_0 = awaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class80.Struct36>(ref awaiter, ref this);
						return;
					}
					IL_2EA:
					awaiter.GetResult();
				}
				catch
				{
				}
				finally
				{
					if (num < 0)
					{
						@class.class4_0.method_0("Stopped", "red", true);
					}
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

		// Token: 0x06000333 RID: 819 RVA: 0x000048ED File Offset: 0x00002AED
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncVoidMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000203 RID: 515
		public int int_0;

		// Token: 0x04000204 RID: 516
		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		// Token: 0x04000205 RID: 517
		public Class80 class80_0;

		// Token: 0x04000206 RID: 518
		private TaskAwaiter taskAwaiter_0;
	}
}
