using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

// Token: 0x020000E0 RID: 224
internal sealed class Class121
{
	// Token: 0x060005D8 RID: 1496 RVA: 0x000304B4 File Offset: 0x0002E6B4
	public Class121(JToken jtoken_2, string string_9)
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

	// Token: 0x060005D9 RID: 1497 RVA: 0x00030698 File Offset: 0x0002E898
	public void method_0()
	{
		try
		{
			this.method_2().Wait();
			this.task_1 = this.method_4();
			this.task_2 = this.method_7();
			this.task_4 = this.method_5();
			this.task_5 = this.method_6();
			this.task_3 = this.method_8();
			this.class4_0.method_8();
			this.method_1().Wait();
			this.method_3().Wait();
			this.task_4.Wait();
			this.task_5.Wait();
			this.task_3.Wait();
			this.method_9().Wait();
		}
		catch
		{
		}
		finally
		{
			this.class4_0.method_0("Stopped", "red", true);
		}
	}

	// Token: 0x060005DA RID: 1498 RVA: 0x00030774 File Offset: 0x0002E974
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
				JObject jobject = httpResponseMessage.smethod_0();
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
							this.class4_0.method_5(jtoken2["attributes"].First(new Func<JToken, bool>(Class121.Class122.class122_0.method_1))["value"].ToString());
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

	// Token: 0x060005DB RID: 1499 RVA: 0x000307BC File Offset: 0x0002E9BC
	public async Task method_2()
	{
		for (;;)
		{
			int num = 0;
			try
			{
				this.class4_0.method_4("Getting session", "#c2c2c2", true, false);
				HttpResponseMessage httpResponseMessage = await this.class70_0.method_6(string.Format("https://www.{0}/api/session", this.string_3), false);
				if (httpResponseMessage.StatusCode == HttpStatusCode.Found && httpResponseMessage.Headers.Location.ToString().Contains("https://www.footlocker.eu"))
				{
					this.class4_0.method_0("US proxy required", "red", false);
				}
				httpResponseMessage.EnsureSuccessStatusCode();
				this.class70_0.httpClient_0.DefaultRequestHeaders.TryAddWithoutValidation("x-csrf-token", httpResponseMessage.smethod_0()["data"]["csrfToken"].ToString());
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

	// Token: 0x060005DC RID: 1500 RVA: 0x00030804 File Offset: 0x0002EA04
	public async Task method_3()
	{
		for (;;)
		{
			int num = 0;
			try
			{
				this.class4_0.method_4("Adding to cart", "yellow", true, false);
				JObject jobject = new JObject();
				jobject["productId"] = this.string_0;
				jobject["productQuantity"] = "1";
				if (this.bool_1)
				{
					this.class4_0.method_4("Waiting for captcha", "turquoise", true, false);
					jobject["g-recaptcha-response"] = "03AJpayVHiEb9A_5g6z1Dfc_lPxQN7tRhAYf9bxCEQtwx7yRDuCNefGi1RpoQ5fmb7hVx0GVp5Xd5S-O0K3_DzVlKYNKZgNvsGr9VoFcwOCArpECry3oSTAsIa4zoa2d9ojkQVvczakU__iBsKzQntJa6gsyV15juQkkhPGAFiyJrEIxBdiBTdvdgVgiO2whkba3d9FvOpnQSLXht0EoUgUb4pD0oFexemT0BrWlQjqXUOv7LVd0vDtjsOWdqeNJd_nXcHW2NwOMPs-XPsPI9v5VkYipiilieQvuccjSPwicRmXZEBXMHyhfgj5J_G37ezer0bj9sWpI4Spzf6zsPFUcejACU2MgFPdPE-B3jB_RtNwuNwoyM6Q5MNY3TE2_9JO7NDQus3cdZkrrtaTeL7HyrBYNYqBNBrlFHIKi0Wfko5ZyJuDBfkV1JoShSYsWCG-0CPOjAksr1kA_XyV_LTbgSs6s1br3y2UA";
					this.class4_0.method_4("Adding to cart", "yellow", true, false);
				}
				HttpResponseMessage httpResponseMessage = await this.class70_0.method_10(string.Format("https://www.{0}/api/users/carts/current/entries", this.string_3), jobject);
				if (!httpResponseMessage.smethod_3().Contains("maximum quantity limit") && !httpResponseMessage.smethod_3().Contains("ProductLowStockException"))
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

	// Token: 0x060005DD RID: 1501 RVA: 0x0003084C File Offset: 0x0002EA4C
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

	// Token: 0x060005DE RID: 1502 RVA: 0x00030894 File Offset: 0x0002EA94
	public async Task method_5()
	{
		await this.task_1;
		for (;;)
		{
			int num = 0;
			try
			{
				this.class4_0.method_4("Submitting shipping", "#c2c2c2", true, false);
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
				HttpResponseMessage httpResponseMessage = await this.class70_0.method_10(string.Format("https://www.{0}/api/users/carts/current/addresses/shipping", this.string_3), jobject);
				httpResponseMessage.EnsureSuccessStatusCode();
				this.string_6 = httpResponseMessage.smethod_0()["id"].ToString();
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

	// Token: 0x060005DF RID: 1503 RVA: 0x000308DC File Offset: 0x0002EADC
	public async Task method_6()
	{
		await this.task_1;
		for (;;)
		{
			int num = 0;
			try
			{
				this.class4_0.method_4("Submitting billing", "#c2c2c2", true, false);
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

	// Token: 0x060005E0 RID: 1504 RVA: 0x00030924 File Offset: 0x0002EB24
	public async Task method_7()
	{
		for (;;)
		{
			int num = 0;
			try
			{
				this.class4_0.method_4("Getting payment token", "#c2c2c2", true, false);
				Dictionary<string, string> dictionary = Class70.smethod_1();
				dictionary["action"] = "authorize";
				dictionary["companyNumber"] = "1";
				dictionary["customerNumber"] = "1";
				dictionary["cardNumber"] = this.jtoken_0["payment"]["card"]["number"].ToString().Replace(" ", string.Empty);
				HttpResponseMessage httpResponseMessage = await this.class70_0.method_8(string.Format("https://www.{0}/paygate/ccn", this.string_3), dictionary, false);
				httpResponseMessage.EnsureSuccessStatusCode();
				this.string_5 = httpResponseMessage.smethod_3().Replace(" ", string.Empty).Split(new string[]
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

	// Token: 0x060005E1 RID: 1505 RVA: 0x0003096C File Offset: 0x0002EB6C
	public async Task method_8()
	{
		await this.task_4;
		await this.task_5;
		for (;;)
		{
			int num = 0;
			try
			{
				this.class4_0.method_4("Submitting payment", "#c2c2c2", true, false);
				JObject jobject = new JObject();
				jobject["cardType"] = new JObject();
				jobject["cardType"]["code"] = "master";
				jobject["billingAddress"] = new JObject();
				jobject["billingAddress"]["id"] = this.string_6;
				jobject["flApiCCNumber"] = this.string_5;
				jobject["expiryMonth"] = this.jtoken_0["payment"]["card"]["exp_month"];
				jobject["expiryYear"] = this.jtoken_0["payment"]["card"]["exp_year"];
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

	// Token: 0x060005E2 RID: 1506 RVA: 0x000309B4 File Offset: 0x0002EBB4
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
				HttpResponseMessage httpResponseMessage_ = await this.class70_0.method_10(string.Format("https://www.{0}/api/users/orders", this.string_3), jobject);
				JObject jobject2 = httpResponseMessage_.smethod_0();
				if (httpResponseMessage_.smethod_3().Contains("we are unable to process your credit card"))
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
				else if (httpResponseMessage_.smethod_3().Contains("shipping is restricted"))
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

	// Token: 0x060005E3 RID: 1507 RVA: 0x00005DC1 File Offset: 0x00003FC1
	private bool method_10(JToken jtoken_2)
	{
		return jtoken_2["sku"].ToString() == this.string_1;
	}

	// Token: 0x060005E4 RID: 1508 RVA: 0x000309FC File Offset: 0x0002EBFC
	private bool method_11(JToken jtoken_2)
	{
		return jtoken_2["attributes"].First(new Func<JToken, bool>(Class121.Class122.class122_0.method_0))["id"].ToString() == this.string_2 && jtoken_2["stockLevelStatus"].ToString() == "inStock";
	}

	// Token: 0x060005E5 RID: 1509 RVA: 0x00030A70 File Offset: 0x0002EC70
	private bool method_12(JToken jtoken_2)
	{
		if (jtoken_2["attributes"].First(new Func<JToken, bool>(Class121.Class122.class122_0.method_2))["id"].ToString() == this.string_2)
		{
			return Class167.smethod_2(this.string_4, jtoken_2["attributes"].First(new Func<JToken, bool>(Class121.Class122.class122_0.method_3))["value"].ToString());
		}
		return false;
	}

	// Token: 0x040002C1 RID: 705
	private Class70 class70_0;

	// Token: 0x040002C2 RID: 706
	private Class4 class4_0;

	// Token: 0x040002C3 RID: 707
	private JToken jtoken_0;

	// Token: 0x040002C4 RID: 708
	private int int_0;

	// Token: 0x040002C5 RID: 709
	private JToken jtoken_1;

	// Token: 0x040002C6 RID: 710
	private string string_0;

	// Token: 0x040002C7 RID: 711
	private string string_1;

	// Token: 0x040002C8 RID: 712
	private string string_2;

	// Token: 0x040002C9 RID: 713
	private string string_3;

	// Token: 0x040002CA RID: 714
	private string string_4;

	// Token: 0x040002CB RID: 715
	private bool bool_0;

	// Token: 0x040002CC RID: 716
	private string string_5;

	// Token: 0x040002CD RID: 717
	private string string_6;

	// Token: 0x040002CE RID: 718
	private string string_7;

	// Token: 0x040002CF RID: 719
	private bool bool_1;

	// Token: 0x040002D0 RID: 720
	private string string_8 = "6Lf9IxgUAAAAAHHz804d0SNSePsBEY7ZYsBALSHT";

	// Token: 0x040002D1 RID: 721
	private Task task_0;

	// Token: 0x040002D2 RID: 722
	private Task task_1;

	// Token: 0x040002D3 RID: 723
	private Task task_2;

	// Token: 0x040002D4 RID: 724
	private Task task_3;

	// Token: 0x040002D5 RID: 725
	private Task task_4;

	// Token: 0x040002D6 RID: 726
	private Task task_5;

	// Token: 0x020000E1 RID: 225
	[Serializable]
	private sealed class Class122
	{
		// Token: 0x060005E8 RID: 1512 RVA: 0x00004837 File Offset: 0x00002A37
		internal bool method_0(JToken jtoken_0)
		{
			return jtoken_0["type"].ToString() == "style";
		}

		// Token: 0x060005E9 RID: 1513 RVA: 0x00004853 File Offset: 0x00002A53
		internal bool method_1(JToken jtoken_0)
		{
			return jtoken_0["type"].ToString() == "size";
		}

		// Token: 0x060005EA RID: 1514 RVA: 0x00004837 File Offset: 0x00002A37
		internal bool method_2(JToken jtoken_0)
		{
			return jtoken_0["type"].ToString() == "style";
		}

		// Token: 0x060005EB RID: 1515 RVA: 0x00004853 File Offset: 0x00002A53
		internal bool method_3(JToken jtoken_0)
		{
			return jtoken_0["type"].ToString() == "size";
		}

		// Token: 0x040002D7 RID: 727
		public static readonly Class121.Class122 class122_0 = new Class121.Class122();

		// Token: 0x040002D8 RID: 728
		public static Func<JToken, bool> func_0;

		// Token: 0x040002D9 RID: 729
		public static Func<JToken, bool> func_1;

		// Token: 0x040002DA RID: 730
		public static Func<JToken, bool> func_2;

		// Token: 0x040002DB RID: 731
		public static Func<JToken, bool> func_3;
	}

	// Token: 0x020000E2 RID: 226
	[StructLayout(LayoutKind.Auto)]
	private struct Struct46 : IAsyncStateMachine
	{
		// Token: 0x060005EC RID: 1516 RVA: 0x00030B14 File Offset: 0x0002ED14
		void IAsyncStateMachine.MoveNext()
		{
			int num = this.int_0;
			Class121 @class = this.class121_0;
			try
			{
				if (num == 0)
				{
					goto IL_23F;
				}
				if (num != 1)
				{
					goto IL_23C;
				}
				TaskAwaiter awaiter = this.taskAwaiter_1;
				this.taskAwaiter_1 = default(TaskAwaiter);
				int num2 = -1;
				num = -1;
				this.int_0 = num2;
				IL_235:
				awaiter.GetResult();
				IL_23C:
				int num3 = 0;
				IL_23F:
				try
				{
					TaskAwaiter<HttpResponseMessage> awaiter2;
					if (num != 0)
					{
						@class.class4_0.method_4("Submitting order", "orange", true, false);
						JObject jobject = new JObject();
						jobject["cartId"] = @class.string_7;
						jobject["securityCode"] = @class.jtoken_0["payment"]["card"]["cvv"];
						jobject["deviceId"] = GClass2.smethod_2(50);
						awaiter2 = @class.class70_0.method_10(string.Format("https://www.{0}/api/users/orders", @class.string_3), jobject).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							int num4 = 0;
							num = 0;
							this.int_0 = num4;
							this.taskAwaiter_0 = awaiter2;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class121.Struct46>(ref awaiter2, ref this);
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
					JObject jobject2 = result.smethod_0();
					if (result.smethod_3().Contains("we are unable to process your credit card"))
					{
						@class.class4_0.method_9(true);
						@class.class4_0.method_0("Payment Declined", "red", false);
					}
					else if (jobject2["calculated"] != null)
					{
						@class.class4_0.method_12();
						@class.class4_0.method_9(false);
						@class.class4_0.method_0("Successfully checked out", "green", false);
					}
					else if (result.smethod_3().Contains("shipping is restricted"))
					{
						@class.class4_0.method_0("Shipping restricted", "red", false);
					}
					else
					{
						@class.class4_0.method_0("Payment error", "red", false);
					}
					goto IL_27F;
				}
				catch (ThreadAbortException)
				{
					goto IL_27F;
				}
				catch
				{
					num3 = 1;
				}
				if (num3 != 1)
				{
					goto IL_23C;
				}
				@class.class4_0.method_4("Error submitting order", "#c2c2c2", true, false);
				awaiter = Task.Delay(GClass0.int_1).GetAwaiter();
				if (awaiter.IsCompleted)
				{
					goto IL_235;
				}
				int num6 = 1;
				num = 1;
				this.int_0 = num6;
				this.taskAwaiter_1 = awaiter;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class121.Struct46>(ref awaiter, ref this);
				return;
			}
			catch (Exception exception)
			{
				this.int_0 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_27F:
			this.int_0 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x060005ED RID: 1517 RVA: 0x00005DEA File Offset: 0x00003FEA
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040002DC RID: 732
		public int int_0;

		// Token: 0x040002DD RID: 733
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040002DE RID: 734
		public Class121 class121_0;

		// Token: 0x040002DF RID: 735
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x040002E0 RID: 736
		private TaskAwaiter taskAwaiter_1;
	}

	// Token: 0x020000E3 RID: 227
	[StructLayout(LayoutKind.Auto)]
	private struct Struct47 : IAsyncStateMachine
	{
		// Token: 0x060005EE RID: 1518 RVA: 0x00030E00 File Offset: 0x0002F000
		void IAsyncStateMachine.MoveNext()
		{
			int num = this.int_0;
			Class121 @class = this.class121_0;
			try
			{
				TaskAwaiter awaiter;
				if (num > 2)
				{
					if (num != 3)
					{
						goto IL_2F0;
					}
					awaiter = this.taskAwaiter_1;
					this.taskAwaiter_1 = default(TaskAwaiter);
					int num2 = -1;
					num = -1;
					this.int_0 = num2;
					goto IL_2E9;
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
						goto IL_244;
					}
					case 2:
					{
						awaiter = this.taskAwaiter_1;
						this.taskAwaiter_1 = default(TaskAwaiter);
						int num5 = -1;
						num = -1;
						this.int_0 = num5;
						goto IL_29F;
					}
					default:
					{
						@class.class4_0.method_4("Adding to cart", "yellow", true, false);
						JObject jobject = new JObject();
						jobject["productId"] = @class.string_0;
						jobject["productQuantity"] = "1";
						JObject jobject2 = jobject;
						if (@class.bool_1)
						{
							@class.class4_0.method_4("Waiting for captcha", "turquoise", true, false);
							jobject2["g-recaptcha-response"] = "03AJpayVHiEb9A_5g6z1Dfc_lPxQN7tRhAYf9bxCEQtwx7yRDuCNefGi1RpoQ5fmb7hVx0GVp5Xd5S-O0K3_DzVlKYNKZgNvsGr9VoFcwOCArpECry3oSTAsIa4zoa2d9ojkQVvczakU__iBsKzQntJa6gsyV15juQkkhPGAFiyJrEIxBdiBTdvdgVgiO2whkba3d9FvOpnQSLXht0EoUgUb4pD0oFexemT0BrWlQjqXUOv7LVd0vDtjsOWdqeNJd_nXcHW2NwOMPs-XPsPI9v5VkYipiilieQvuccjSPwicRmXZEBXMHyhfgj5J_G37ezer0bj9sWpI4Spzf6zsPFUcejACU2MgFPdPE-B3jB_RtNwuNwoyM6Q5MNY3TE2_9JO7NDQus3cdZkrrtaTeL7HyrBYNYqBNBrlFHIKi0Wfko5ZyJuDBfkV1JoShSYsWCG-0CPOjAksr1kA_XyV_LTbgSs6s1br3y2UA";
							@class.class4_0.method_4("Adding to cart", "yellow", true, false);
						}
						awaiter2 = @class.class70_0.method_10(string.Format("https://www.{0}/api/users/carts/current/entries", @class.string_3), jobject2).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							int num6 = 0;
							num = 0;
							this.int_0 = num6;
							this.taskAwaiter_0 = awaiter2;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class121.Struct47>(ref awaiter2, ref this);
							return;
						}
						break;
					}
					}
					HttpResponseMessage result = awaiter2.GetResult();
					if (!result.smethod_3().Contains("maximum quantity limit") && !result.smethod_3().Contains("ProductLowStockException"))
					{
						result.EnsureSuccessStatusCode();
						@class.string_7 = result.smethod_0()["guid"].ToString();
						@class.class70_0.httpClient_0.DefaultRequestHeaders.TryAddWithoutValidation("x-csrf-token", result.Headers.GetValues("x-csrf-token").First<string>());
						goto IL_331;
					}
					@class.class4_0.method_4("Waiting for restock", "#c2c2c2", true, false);
					awaiter = Task.Delay(GClass0.int_0).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						int num7 = 1;
						num = 1;
						this.int_0 = num7;
						this.taskAwaiter_1 = awaiter;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class121.Struct47>(ref awaiter, ref this);
						return;
					}
					IL_244:
					awaiter.GetResult();
					awaiter = @class.method_1().GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						int num8 = 2;
						num = 2;
						this.int_0 = num8;
						this.taskAwaiter_1 = awaiter;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class121.Struct47>(ref awaiter, ref this);
						return;
					}
					IL_29F:
					awaiter.GetResult();
					goto IL_2F0;
				}
				catch (ThreadAbortException)
				{
					goto IL_331;
				}
				catch
				{
					num9 = 1;
				}
				if (num9 != 1)
				{
					goto IL_2F0;
				}
				@class.class4_0.method_4("Error adding to cart", "#c2c2c2", true, false);
				awaiter = Task.Delay(GClass0.int_1).GetAwaiter();
				if (!awaiter.IsCompleted)
				{
					int num10 = 3;
					num = 3;
					this.int_0 = num10;
					this.taskAwaiter_1 = awaiter;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class121.Struct47>(ref awaiter, ref this);
					return;
				}
				IL_2E9:
				awaiter.GetResult();
				IL_2F0:
				num9 = 0;
				goto IL_3C;
			}
			catch (Exception exception)
			{
				this.int_0 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_331:
			this.int_0 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x060005EF RID: 1519 RVA: 0x00005DF8 File Offset: 0x00003FF8
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040002E1 RID: 737
		public int int_0;

		// Token: 0x040002E2 RID: 738
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040002E3 RID: 739
		public Class121 class121_0;

		// Token: 0x040002E4 RID: 740
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x040002E5 RID: 741
		private TaskAwaiter taskAwaiter_1;
	}

	// Token: 0x020000E4 RID: 228
	[StructLayout(LayoutKind.Auto)]
	private struct Struct48 : IAsyncStateMachine
	{
		// Token: 0x060005F0 RID: 1520 RVA: 0x000311A0 File Offset: 0x0002F3A0
		void IAsyncStateMachine.MoveNext()
		{
			int num = this.int_0;
			Class121 @class = this.class121_0;
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
					IL_100:
					try
					{
						TaskAwaiter<HttpResponseMessage> awaiter2;
						if (num != 2)
						{
							@class.class4_0.method_4("Submitting payment", "#c2c2c2", true, false);
							JObject jobject = new JObject();
							jobject["cardType"] = new JObject();
							jobject["cardType"]["code"] = "master";
							jobject["billingAddress"] = new JObject();
							jobject["billingAddress"]["id"] = @class.string_6;
							jobject["flApiCCNumber"] = @class.string_5;
							jobject["expiryMonth"] = @class.jtoken_0["payment"]["card"]["exp_month"];
							jobject["expiryYear"] = @class.jtoken_0["payment"]["card"]["exp_year"];
							awaiter2 = @class.class70_0.method_10(string.Format("https://www.{0}/api/users/carts/current/payment-detail", @class.string_3), jobject).GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								int num4 = 2;
								num = 2;
								this.int_0 = num4;
								this.taskAwaiter_1 = awaiter2;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class121.Struct48>(ref awaiter2, ref this);
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
						goto IL_304;
					}
					catch (ThreadAbortException)
					{
						goto IL_304;
					}
					catch
					{
						num6 = 1;
					}
					if (num6 != 1)
					{
						goto IL_28A;
					}
					@class.class4_0.method_4("Error submitting payment", "#c2c2c2", true, false);
					awaiter = Task.Delay(GClass0.int_1).GetAwaiter();
					if (awaiter.IsCompleted)
					{
						goto IL_2C2;
					}
					int num7 = 3;
					num = 3;
					this.int_0 = num7;
					this.taskAwaiter_0 = awaiter;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class121.Struct48>(ref awaiter, ref this);
					return;
				}
				case 3:
				{
					awaiter = this.taskAwaiter_0;
					this.taskAwaiter_0 = default(TaskAwaiter);
					int num8 = -1;
					num = -1;
					this.int_0 = num8;
					goto IL_2C2;
				}
				default:
					awaiter = @class.task_4.GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						int num9 = 0;
						num = 0;
						this.int_0 = num9;
						this.taskAwaiter_0 = awaiter;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class121.Struct48>(ref awaiter, ref this);
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
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class121.Struct48>(ref awaiter, ref this);
					return;
				}
				IL_D3:
				awaiter.GetResult();
				IL_28A:
				num6 = 0;
				goto IL_100;
				IL_2C2:
				awaiter.GetResult();
				goto IL_28A;
			}
			catch (Exception exception)
			{
				this.int_0 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_304:
			this.int_0 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x060005F1 RID: 1521 RVA: 0x00005E06 File Offset: 0x00004006
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040002E6 RID: 742
		public int int_0;

		// Token: 0x040002E7 RID: 743
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040002E8 RID: 744
		public Class121 class121_0;

		// Token: 0x040002E9 RID: 745
		private TaskAwaiter taskAwaiter_0;

		// Token: 0x040002EA RID: 746
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_1;
	}

	// Token: 0x020000E5 RID: 229
	[StructLayout(LayoutKind.Auto)]
	private struct Struct49 : IAsyncStateMachine
	{
		// Token: 0x060005F2 RID: 1522 RVA: 0x00031510 File Offset: 0x0002F710
		void IAsyncStateMachine.MoveNext()
		{
			int num = this.int_0;
			Class121 @class = this.class121_0;
			try
			{
				TaskAwaiter awaiter;
				if (num > 3)
				{
					if (num != 4)
					{
						@class.class4_0.method_4("Waiting for product", "#c2c2c2", true, false);
						goto IL_4FD;
					}
					awaiter = this.taskAwaiter_1;
					this.taskAwaiter_1 = default(TaskAwaiter);
					int num2 = -1;
					num = -1;
					this.int_0 = num2;
					goto IL_4DF;
				}
				IL_53:
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
						goto IL_453;
					}
					case 2:
					{
						awaiter = this.taskAwaiter_1;
						this.taskAwaiter_1 = default(TaskAwaiter);
						int num5 = -1;
						num = -1;
						this.int_0 = num5;
						goto IL_47B;
					}
					case 3:
					{
						awaiter = this.taskAwaiter_1;
						this.taskAwaiter_1 = default(TaskAwaiter);
						int num6 = -1;
						num = -1;
						this.int_0 = num6;
						goto IL_4A0;
					}
					default:
						awaiter2 = @class.class70_0.method_6(string.Format("https://www.{0}/api/products/pdp/{1}", @class.string_3, @class.string_1), false).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							int num7 = 0;
							num = 0;
							this.int_0 = num7;
							this.taskAwaiter_0 = awaiter2;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class121.Struct49>(ref awaiter2, ref this);
							return;
						}
						break;
					}
					HttpResponseMessage result = awaiter2.GetResult();
					result.EnsureSuccessStatusCode();
					JObject jobject = result.smethod_0();
					@class.class4_0.method_7(jobject["name"].ToString(), "#c2c2c2");
					JToken jtoken = jobject["variantAttributes"].FirstOrDefault(new Func<JToken, bool>(@class.method_10));
					if (jtoken == null)
					{
						@class.class4_0.method_0("Product pulled", "red", false);
						goto IL_4B9;
					}
					@class.bool_1 = (bool)jtoken["recaptchaOn"];
					@class.int_0 = (((bool)jtoken["displayCountDownTimer"]) ? Convert.ToInt32(Convert.ToDateTime(jtoken["skuLaunchDate"].ToString().Replace(" GMT+0000", string.Empty)).Subtract(DateTime.UtcNow).TotalSeconds) : 0);
					@class.class4_0.method_13(@class.int_0, "Waiting ", 0);
					@class.string_2 = (string)jtoken["code"];
					if (@class.bool_0)
					{
						JToken jtoken2 = jobject["sellableUnits"].Where(new Func<JToken, bool>(@class.method_11)).smethod_2();
						if (jtoken2 != null && !(jtoken2["stockLevelStatus"].ToString() != "inStock"))
						{
							@class.class4_0.method_5(jtoken2["attributes"].First(new Func<JToken, bool>(Class121.Class122.class122_0.method_1))["value"].ToString());
							@class.string_0 = jtoken2["code"].ToString();
							@class.class4_0.method_4("Found size code: " + @class.string_0, "#c2c2c2", true, false);
							goto IL_542;
						}
						@class.class4_0.method_4("Waiting for restock", "#c2c2c2", true, false);
						awaiter = Task.Delay(GClass0.int_0).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							int num8 = 1;
							num = 1;
							this.int_0 = num8;
							this.taskAwaiter_1 = awaiter;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class121.Struct49>(ref awaiter, ref this);
							return;
						}
					}
					else
					{
						JToken jtoken3 = jobject["sellableUnits"].FirstOrDefault(new Func<JToken, bool>(@class.method_12));
						if (jtoken3 == null)
						{
							awaiter = Task.Delay(GClass0.int_0).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								int num9 = 2;
								num = 2;
								this.int_0 = num9;
								this.taskAwaiter_1 = awaiter;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class121.Struct49>(ref awaiter, ref this);
								return;
							}
							goto IL_47B;
						}
						else
						{
							if (!(jtoken3["stockLevelStatus"].ToString() != "inStock"))
							{
								@class.string_0 = jtoken3["code"].ToString();
								@class.class4_0.method_4("Found size code: " + @class.string_0, "#c2c2c2", true, false);
								goto IL_542;
							}
							@class.class4_0.method_4("Waiting for restock", "#c2c2c2", true, false);
							awaiter = Task.Delay(GClass0.int_0).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								int num10 = 3;
								num = 3;
								this.int_0 = num10;
								this.taskAwaiter_1 = awaiter;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class121.Struct49>(ref awaiter, ref this);
								return;
							}
							goto IL_4A0;
						}
					}
					IL_453:
					awaiter.GetResult();
					goto IL_4FD;
					IL_47B:
					awaiter.GetResult();
					goto IL_4FD;
					IL_4A0:
					awaiter.GetResult();
					goto IL_4FD;
				}
				catch (ThreadAbortException)
				{
					goto IL_542;
				}
				catch
				{
					this.int_1 = 1;
				}
				IL_4B9:
				int num11 = this.int_1;
				if (num11 != 1)
				{
					goto IL_4FD;
				}
				awaiter = Task.Delay(GClass0.int_0).GetAwaiter();
				if (!awaiter.IsCompleted)
				{
					int num12 = 4;
					num = 4;
					this.int_0 = num12;
					this.taskAwaiter_1 = awaiter;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class121.Struct49>(ref awaiter, ref this);
					return;
				}
				IL_4DF:
				awaiter.GetResult();
				@class.class4_0.method_4("Waiting for product", "#c2c2c2", false, false);
				IL_4FD:
				this.int_1 = 0;
				goto IL_53;
			}
			catch (Exception exception)
			{
				this.int_0 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_542:
			this.int_0 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x060005F3 RID: 1523 RVA: 0x00005E14 File Offset: 0x00004014
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040002EB RID: 747
		public int int_0;

		// Token: 0x040002EC RID: 748
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040002ED RID: 749
		public Class121 class121_0;

		// Token: 0x040002EE RID: 750
		private int int_1;

		// Token: 0x040002EF RID: 751
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x040002F0 RID: 752
		private TaskAwaiter taskAwaiter_1;
	}

	// Token: 0x020000E6 RID: 230
	[StructLayout(LayoutKind.Auto)]
	private struct Struct50 : IAsyncStateMachine
	{
		// Token: 0x060005F4 RID: 1524 RVA: 0x00031AC0 File Offset: 0x0002FCC0
		void IAsyncStateMachine.MoveNext()
		{
			int num = this.int_0;
			Class121 @class = this.class121_0;
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
					IL_A1:
					try
					{
						TaskAwaiter<HttpResponseMessage> awaiter2;
						if (num != 1)
						{
							@class.class4_0.method_4("Submitting shipping", "#c2c2c2", true, false);
							JObject jobject = new JObject(new JProperty("shippingAddress", new JObject()));
							jobject["shippingAddress"]["country"] = new JObject();
							jobject["shippingAddress"]["country"]["isocode"] = Class167.smethod_0(@class.jtoken_0["delivery"]["country"].ToString(), false);
							jobject["shippingAddress"]["country"]["name"] = @class.jtoken_0["delivery"]["country"];
							jobject["shippingAddress"]["region"] = new JObject();
							jobject["shippingAddress"]["region"]["isocode"] = Class167.smethod_0(@class.jtoken_0["delivery"]["country"].ToString(), false) + "-" + Class167.smethod_1(@class.jtoken_0["delivery"]["country"].ToString(), @class.jtoken_0["delivery"]["state"].ToString());
							jobject["shippingAddress"]["type"] = "Home/Business Address";
							jobject["shippingAddress"]["setAsBilling"] = true;
							jobject["shippingAddress"]["firstName"] = @class.jtoken_0["delivery"]["first_name"];
							jobject["shippingAddress"]["lastName"] = @class.jtoken_0["delivery"]["last_name"];
							jobject["shippingAddress"]["line1"] = @class.jtoken_0["delivery"]["addr1"];
							jobject["shippingAddress"]["line2"] = @class.jtoken_0["delivery"]["addr2"];
							jobject["shippingAddress"]["postalCode"] = @class.jtoken_0["delivery"]["zip"];
							jobject["shippingAddress"]["phone"] = @class.jtoken_0["payment"]["phone"];
							jobject["shippingAddress"]["email"] = @class.jtoken_0["payment"]["email"];
							jobject["shippingAddress"]["town"] = @class.jtoken_0["delivery"]["city"];
							jobject["shippingAddress"]["isFPO"] = false;
							jobject["shippingAddress"]["shippingAddress"] = true;
							awaiter2 = @class.class70_0.method_10(string.Format("https://www.{0}/api/users/carts/current/addresses/shipping", @class.string_3), jobject).GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								int num3 = 1;
								num = 1;
								this.int_0 = num3;
								this.taskAwaiter_1 = awaiter2;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class121.Struct50>(ref awaiter2, ref this);
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
						HttpResponseMessage result = awaiter2.GetResult();
						result.EnsureSuccessStatusCode();
						@class.string_6 = result.smethod_0()["id"].ToString();
						goto IL_535;
					}
					catch (ThreadAbortException)
					{
						goto IL_535;
					}
					catch
					{
						num5 = 1;
					}
					if (num5 != 1)
					{
						goto IL_4BB;
					}
					@class.class4_0.method_4("Error submitting shipping", "#c2c2c2", true, false);
					awaiter = Task.Delay(GClass0.int_1).GetAwaiter();
					if (awaiter.IsCompleted)
					{
						goto IL_4F3;
					}
					int num6 = 2;
					num = 2;
					this.int_0 = num6;
					this.taskAwaiter_0 = awaiter;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class121.Struct50>(ref awaiter, ref this);
					return;
				}
				case 2:
				{
					awaiter = this.taskAwaiter_0;
					this.taskAwaiter_0 = default(TaskAwaiter);
					int num7 = -1;
					num = -1;
					this.int_0 = num7;
					goto IL_4F3;
				}
				default:
					awaiter = @class.task_1.GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						int num8 = 0;
						num = 0;
						this.int_0 = num8;
						this.taskAwaiter_0 = awaiter;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class121.Struct50>(ref awaiter, ref this);
						return;
					}
					break;
				}
				awaiter.GetResult();
				IL_4BB:
				num5 = 0;
				goto IL_A1;
				IL_4F3:
				awaiter.GetResult();
				goto IL_4BB;
			}
			catch (Exception exception)
			{
				this.int_0 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_535:
			this.int_0 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x060005F5 RID: 1525 RVA: 0x00005E22 File Offset: 0x00004022
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040002F1 RID: 753
		public int int_0;

		// Token: 0x040002F2 RID: 754
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040002F3 RID: 755
		public Class121 class121_0;

		// Token: 0x040002F4 RID: 756
		private TaskAwaiter taskAwaiter_0;

		// Token: 0x040002F5 RID: 757
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_1;
	}

	// Token: 0x020000E7 RID: 231
	[StructLayout(LayoutKind.Auto)]
	private struct Struct51 : IAsyncStateMachine
	{
		// Token: 0x060005F6 RID: 1526 RVA: 0x00032064 File Offset: 0x00030264
		void IAsyncStateMachine.MoveNext()
		{
			int num = this.int_0;
			Class121 @class = this.class121_0;
			try
			{
				if (num == 0)
				{
					goto IL_19C;
				}
				if (num != 1)
				{
					goto IL_19A;
				}
				TaskAwaiter awaiter = this.taskAwaiter_1;
				this.taskAwaiter_1 = default(TaskAwaiter);
				int num2 = -1;
				num = -1;
				this.int_0 = num2;
				IL_193:
				awaiter.GetResult();
				IL_19A:
				int num3 = 0;
				IL_19C:
				try
				{
					TaskAwaiter<HttpResponseMessage> awaiter2;
					if (num != 0)
					{
						@class.class4_0.method_4("Getting session", "#c2c2c2", true, false);
						awaiter2 = @class.class70_0.method_6(string.Format("https://www.{0}/api/session", @class.string_3), false).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							int num4 = 0;
							num = 0;
							this.int_0 = num4;
							this.taskAwaiter_0 = awaiter2;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class121.Struct51>(ref awaiter2, ref this);
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
					if (result.StatusCode == HttpStatusCode.Found && result.Headers.Location.ToString().Contains("https://www.footlocker.eu"))
					{
						@class.class4_0.method_0("US proxy required", "red", false);
					}
					result.EnsureSuccessStatusCode();
					@class.class70_0.httpClient_0.DefaultRequestHeaders.TryAddWithoutValidation("x-csrf-token", result.smethod_0()["data"]["csrfToken"].ToString());
					goto IL_1DC;
				}
				catch (ThreadAbortException)
				{
					goto IL_1DC;
				}
				catch
				{
					num3 = 1;
				}
				if (num3 != 1)
				{
					goto IL_19A;
				}
				@class.class4_0.method_4("Error getting session", "#c2c2c2", true, false);
				awaiter = Task.Delay(GClass0.int_1).GetAwaiter();
				if (awaiter.IsCompleted)
				{
					goto IL_193;
				}
				int num6 = 1;
				num = 1;
				this.int_0 = num6;
				this.taskAwaiter_1 = awaiter;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class121.Struct51>(ref awaiter, ref this);
				return;
			}
			catch (Exception exception)
			{
				this.int_0 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_1DC:
			this.int_0 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x060005F7 RID: 1527 RVA: 0x00005E30 File Offset: 0x00004030
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040002F6 RID: 758
		public int int_0;

		// Token: 0x040002F7 RID: 759
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040002F8 RID: 760
		public Class121 class121_0;

		// Token: 0x040002F9 RID: 761
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x040002FA RID: 762
		private TaskAwaiter taskAwaiter_1;
	}

	// Token: 0x020000E8 RID: 232
	[StructLayout(LayoutKind.Auto)]
	private struct Struct52 : IAsyncStateMachine
	{
		// Token: 0x060005F8 RID: 1528 RVA: 0x000322AC File Offset: 0x000304AC
		void IAsyncStateMachine.MoveNext()
		{
			int num = this.int_0;
			Class121 @class = this.class121_0;
			try
			{
				if (num == 0)
				{
					goto IL_1E6;
				}
				if (num != 1)
				{
					goto IL_1E4;
				}
				TaskAwaiter awaiter = this.taskAwaiter_1;
				this.taskAwaiter_1 = default(TaskAwaiter);
				int num2 = -1;
				num = -1;
				this.int_0 = num2;
				IL_1DD:
				awaiter.GetResult();
				IL_1E4:
				int num3 = 0;
				IL_1E6:
				try
				{
					TaskAwaiter<HttpResponseMessage> awaiter2;
					if (num != 0)
					{
						@class.class4_0.method_4("Getting payment token", "#c2c2c2", true, false);
						Dictionary<string, string> dictionary = Class70.smethod_1();
						dictionary["action"] = "authorize";
						dictionary["companyNumber"] = "1";
						dictionary["customerNumber"] = "1";
						dictionary["cardNumber"] = @class.jtoken_0["payment"]["card"]["number"].ToString().Replace(" ", string.Empty);
						awaiter2 = @class.class70_0.method_8(string.Format("https://www.{0}/paygate/ccn", @class.string_3), dictionary, false).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							int num4 = 0;
							num = 0;
							this.int_0 = num4;
							this.taskAwaiter_0 = awaiter2;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class121.Struct52>(ref awaiter2, ref this);
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
					@class.string_5 = result.smethod_3().Replace(" ", string.Empty).Split(new string[]
					{
						"token:'"
					}, StringSplitOptions.None)[1].Split(new char[]
					{
						'\''
					})[0];
					goto IL_226;
				}
				catch (ThreadAbortException)
				{
					goto IL_226;
				}
				catch
				{
					num3 = 1;
				}
				if (num3 != 1)
				{
					goto IL_1E4;
				}
				@class.class4_0.method_4("Error getting payment token", "#c2c2c2", true, false);
				awaiter = Task.Delay(GClass0.int_1).GetAwaiter();
				if (awaiter.IsCompleted)
				{
					goto IL_1DD;
				}
				int num6 = 1;
				num = 1;
				this.int_0 = num6;
				this.taskAwaiter_1 = awaiter;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class121.Struct52>(ref awaiter, ref this);
				return;
			}
			catch (Exception exception)
			{
				this.int_0 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_226:
			this.int_0 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x060005F9 RID: 1529 RVA: 0x00005E3E File Offset: 0x0000403E
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040002FB RID: 763
		public int int_0;

		// Token: 0x040002FC RID: 764
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040002FD RID: 765
		public Class121 class121_0;

		// Token: 0x040002FE RID: 766
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x040002FF RID: 767
		private TaskAwaiter taskAwaiter_1;
	}

	// Token: 0x020000E9 RID: 233
	[StructLayout(LayoutKind.Auto)]
	private struct Struct53 : IAsyncStateMachine
	{
		// Token: 0x060005FA RID: 1530 RVA: 0x00032540 File Offset: 0x00030740
		void IAsyncStateMachine.MoveNext()
		{
			int num = this.int_0;
			Class121 @class = this.class121_0;
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
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class121.Struct53>(ref awaiter2, ref this);
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
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class121.Struct53>(ref awaiter, ref this);
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

		// Token: 0x060005FB RID: 1531 RVA: 0x00005E4C File Offset: 0x0000404C
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000300 RID: 768
		public int int_0;

		// Token: 0x04000301 RID: 769
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000302 RID: 770
		public Class121 class121_0;

		// Token: 0x04000303 RID: 771
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000304 RID: 772
		private TaskAwaiter taskAwaiter_1;
	}

	// Token: 0x020000EA RID: 234
	[StructLayout(LayoutKind.Auto)]
	private struct Struct54 : IAsyncStateMachine
	{
		// Token: 0x060005FC RID: 1532 RVA: 0x00032740 File Offset: 0x00030940
		void IAsyncStateMachine.MoveNext()
		{
			int num = this.int_0;
			Class121 @class = this.class121_0;
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
					IL_A1:
					try
					{
						TaskAwaiter<HttpResponseMessage> awaiter2;
						if (num != 1)
						{
							@class.class4_0.method_4("Submitting billing", "#c2c2c2", true, false);
							JObject jobject = new JObject(new JProperty("shippingAddress", new JObject()));
							jobject["country"] = new JObject();
							jobject["country"]["isocode"] = Class167.smethod_0(@class.jtoken_0["billing"]["country"].ToString(), false);
							jobject["country"]["name"] = @class.jtoken_0["billing"]["country"];
							jobject["region"] = new JObject();
							jobject["region"]["isocode"] = Class167.smethod_0(@class.jtoken_0["billing"]["country"].ToString(), false) + "-" + Class167.smethod_1(@class.jtoken_0["billing"]["country"].ToString(), @class.jtoken_0["delivery"]["state"].ToString());
							jobject["type"] = "Home/Business Address";
							jobject["setAsBilling"] = true;
							jobject["firstName"] = @class.jtoken_0["billing"]["first_name"];
							jobject["lastName"] = @class.jtoken_0["billing"]["last_name"];
							jobject["line1"] = @class.jtoken_0["billing"]["addr1"];
							jobject["line2"] = @class.jtoken_0["billing"]["addr2"];
							jobject["postalCode"] = @class.jtoken_0["billing"]["zip"];
							jobject["phone"] = @class.jtoken_0["payment"]["phone"];
							jobject["email"] = @class.jtoken_0["payment"]["email"];
							jobject["town"] = @class.jtoken_0["billing"]["city"];
							jobject["isFPO"] = false;
							jobject["shippingAddress"] = false;
							awaiter2 = @class.class70_0.method_10(string.Format("https://www.{0}/api/users/carts/current/set-billing", @class.string_3), jobject).GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								int num3 = 1;
								num = 1;
								this.int_0 = num3;
								this.taskAwaiter_1 = awaiter2;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class121.Struct54>(ref awaiter2, ref this);
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
						goto IL_46B;
					}
					catch (ThreadAbortException)
					{
						goto IL_46B;
					}
					catch
					{
						num5 = 1;
					}
					if (num5 != 1)
					{
						goto IL_3F1;
					}
					@class.class4_0.method_4("Error submitting billing", "#c2c2c2", true, false);
					awaiter = Task.Delay(GClass0.int_1).GetAwaiter();
					if (awaiter.IsCompleted)
					{
						goto IL_429;
					}
					int num6 = 2;
					num = 2;
					this.int_0 = num6;
					this.taskAwaiter_0 = awaiter;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class121.Struct54>(ref awaiter, ref this);
					return;
				}
				case 2:
				{
					awaiter = this.taskAwaiter_0;
					this.taskAwaiter_0 = default(TaskAwaiter);
					int num7 = -1;
					num = -1;
					this.int_0 = num7;
					goto IL_429;
				}
				default:
					awaiter = @class.task_1.GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						int num8 = 0;
						num = 0;
						this.int_0 = num8;
						this.taskAwaiter_0 = awaiter;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class121.Struct54>(ref awaiter, ref this);
						return;
					}
					break;
				}
				awaiter.GetResult();
				IL_3F1:
				num5 = 0;
				goto IL_A1;
				IL_429:
				awaiter.GetResult();
				goto IL_3F1;
			}
			catch (Exception exception)
			{
				this.int_0 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_46B:
			this.int_0 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x060005FD RID: 1533 RVA: 0x00005E5A File Offset: 0x0000405A
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000305 RID: 773
		public int int_0;

		// Token: 0x04000306 RID: 774
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000307 RID: 775
		public Class121 class121_0;

		// Token: 0x04000308 RID: 776
		private TaskAwaiter taskAwaiter_0;

		// Token: 0x04000309 RID: 777
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_1;
	}
}
