using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

// Token: 0x0200001B RID: 27
internal sealed class Class13
{
	// Token: 0x060000A6 RID: 166 RVA: 0x0000AD54 File Offset: 0x00008F54
	public Class13(JToken jtoken_2, string string_11, string string_12)
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
				this.string_0 = string_11;
				this.string_1 = string_12;
				this.string_3 = (string)jtoken_2["keywords"];
				this.string_4 = ((string)jtoken_2["size"]).Replace("UK ", string.Empty);
				if (this.string_4 == "Random" || this.string_4 == "OneSize")
				{
					this.bool_0 = true;
				}
				this.jobject_0 = new JObject();
				this.jobject_0["User-Agent"] = "Dalvik/2.1.0 (Linux; U; Android 7.0; SM-G950F Build/NRD90M)";
				this.jobject_0["x-api-key"] = string_12;
				this.class70_0 = new Class70(this.class4_0.method_6(), "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.181 Safari/537.36", 10, false, false, this.jobject_0, false);
			}
		}
		catch
		{
			this.class4_0.method_0("Task error", "red", true);
		}
	}

	// Token: 0x060000A7 RID: 167 RVA: 0x0000AEB4 File Offset: 0x000090B4
	public void method_0()
	{
		try
		{
			Task task = this.method_5();
			this.class4_0.method_8();
			this.method_1();
			this.class4_0.method_4("Registering customer", "#c2c2c2", true, false);
			task.Wait();
			this.method_2();
			this.method_7();
			this.method_8();
		}
		catch
		{
		}
		finally
		{
			this.class4_0.method_0("Stopped", "red", true);
		}
	}

	// Token: 0x060000A8 RID: 168 RVA: 0x0000323A File Offset: 0x0000143A
	public static string smethod_0(string string_11, string string_12)
	{
		return Class13.smethod_2("e705e8f04c662635f34962dfcac2af75", "1c88f5f855", new Uri(string_11), string_12);
	}

	// Token: 0x060000A9 RID: 169 RVA: 0x00003252 File Offset: 0x00001452
	public static string smethod_1(string string_11, string string_12)
	{
		return Class13.smethod_2("87576edd5a373b323271ad0e367ba452", "7c480586f6", new Uri(string_11), string_12);
	}

	// Token: 0x060000AA RID: 170 RVA: 0x0000AF40 File Offset: 0x00009140
	public static string smethod_2(string string_11, string string_12, Uri uri_0, string string_13)
	{
		int num = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
		string text = Guid.NewGuid().ToString().Substring(0, 6);
		string s = string.Format("hawk.1.header\n{0}\n{1}\n{2}\n{3}\n{4}\n80\n\n\n", new object[]
		{
			num,
			text,
			string_13,
			uri_0.PathAndQuery,
			uri_0.Host
		});
		string text2 = Convert.ToBase64String(new HMACSHA256(Encoding.ASCII.GetBytes(string_11)).ComputeHash(Encoding.ASCII.GetBytes(s)));
		return string.Format("Hawk id={0}, mac={1}, ts={2}, nonce={3}, ext=", new object[]
		{
			string_12,
			text2,
			num,
			text
		});
	}

	// Token: 0x060000AB RID: 171 RVA: 0x0000B010 File Offset: 0x00009210
	public void method_1()
	{
		this.class4_0.method_4("Waiting for product", "#c2c2c2", true, false);
		for (;;)
		{
			try
			{
				HttpResponseMessage httpResponseMessage = this.class4_0.method_1(string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/products/{1}", this.string_0, this.string_3), true, this.jobject_0);
				if (!httpResponseMessage.smethod_3().Contains("Product could not be found"))
				{
					httpResponseMessage.EnsureSuccessStatusCode();
					JObject jobject = httpResponseMessage.smethod_0();
					this.class4_0.method_7(jobject["name"].ToString(), "#c2c2c2");
					if (this.bool_0)
					{
						JToken[] array = jobject["sortedOptions"].Where(new Func<JToken, bool>(Class13.Class14.class14_0.method_0)).ToArray<JToken>();
						if (array.Length == 0)
						{
							this.class4_0.method_4("Waiting for restock", "#c2c2c2", true, false);
							Thread.Sleep(GClass0.int_0);
							continue;
						}
						JToken jtoken = array[MainWindow.random_0.Next(0, array.Length)];
						this.class4_0.method_5(jtoken["name"].ToString());
						this.string_2 = jtoken["product"]["SKU"].ToString();
					}
					else
					{
						JToken jtoken2 = jobject["sortedOptions"].FirstOrDefault(new Func<JToken, bool>(this.method_10));
						if (jtoken2 == null)
						{
							throw new Exception();
						}
						if (jtoken2["product"]["stockStatus"].ToString() != "IN STOCK")
						{
							this.class4_0.method_4("Waiting for restock", "#c2c2c2", true, false);
							Thread.Sleep(GClass0.int_0);
							continue;
						}
						this.class4_0.method_5(jtoken2["name"].ToString());
						this.string_2 = jtoken2["product"]["SKU"].ToString();
					}
					Class30.smethod_1((int)this.jtoken_0["id"], string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/products/{1}", this.string_0, this.string_3));
					break;
				}
				Thread.Sleep(GClass0.int_0);
				this.class4_0.method_4("Waiting for product", "#c2c2c2", true, false);
			}
			catch (ThreadAbortException)
			{
				break;
			}
			catch
			{
				Thread.Sleep(GClass0.int_0);
				this.class4_0.method_4("Waiting for product", "#c2c2c2", true, false);
			}
		}
	}

	// Token: 0x060000AC RID: 172 RVA: 0x0000B2C8 File Offset: 0x000094C8
	public void method_2()
	{
		for (;;)
		{
			try
			{
				this.class4_0.method_4("Adding to cart", "#c2c2c2", true, false);
				JObject jobject = new JObject();
				jobject["SKU"] = this.string_2;
				jobject["quantity"] = 1;
				jobject["type"] = "cartproduct";
				JObject jobject2 = new JObject();
				jobject2["contents"] = new JArray(jobject);
				jobject2["customer"] = new JObject();
				jobject2["customer"]["id"] = string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/customers/{1}", this.string_0, this.string_6);
				jobject2["billingAddress"] = new JObject();
				jobject2["billingAddress"]["id"] = string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/customers/{1}/addresses/{2}", this.string_0, this.string_6, this.string_7);
				jobject2["deliveryAddress"] = new JObject();
				jobject2["deliveryAddress"]["id"] = string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/customers/{1}/addresses/{2}", this.string_0, this.string_6, this.string_7);
				jobject2["terminals"] = new JObject();
				jobject2["terminals"]["successURL"] = "http://ok";
				jobject2["terminals"]["failureURL"] = "http://fail";
				jobject2["terminals"]["timeoutURL"] = "http://timeout";
				HttpResponseMessage httpResponseMessage = this.class70_0.method_9(string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/carts", this.string_0, this.string_1), jobject2, true);
				while (httpResponseMessage.smethod_3().Contains("There is no stock available"))
				{
					this.class4_0.method_4("Waiting for restock", "#c2c2c2", true, false);
					httpResponseMessage = this.class70_0.method_9(string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/carts", this.string_0, this.string_1), jobject2, true);
					Thread.Sleep(GClass0.int_0);
				}
				httpResponseMessage.EnsureSuccessStatusCode();
				this.string_5 = httpResponseMessage.smethod_0()["ID"].ToString();
				this.string_8 = httpResponseMessage.smethod_0()["delivery"]["deliveryMethodID"].ToString();
			}
			catch (ThreadAbortException)
			{
			}
			catch
			{
				this.class4_0.method_4("Error adding to cart", "#c2c2c2", true, false);
				Thread.Sleep(GClass0.int_1);
				continue;
			}
			break;
		}
	}

	// Token: 0x060000AD RID: 173 RVA: 0x0000B5A4 File Offset: 0x000097A4
	public void method_3()
	{
		for (;;)
		{
			try
			{
				this.class4_0.method_4("Getting delivery method ID", "#c2c2c2", true, false);
				HttpResponseMessage httpResponseMessage = this.class70_0.method_5(string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/carts/{1}/deliveryOptionsForProposedAddress?deliverylocale={2}&q={3}", new object[]
				{
					this.string_0,
					this.string_5,
					Class167.smethod_0((string)this.jtoken_1["delivery"]["country"], false),
					(string)this.jtoken_1["delivery"]["zip"]
				}), true);
				httpResponseMessage.EnsureSuccessStatusCode();
				this.string_8 = httpResponseMessage.smethod_0()["deliveryMethods"][0]["ID"].ToString();
			}
			catch (ThreadAbortException)
			{
			}
			catch
			{
				this.class4_0.method_4("Error getting delivery method", "#c2c2c2", true, false);
				Thread.Sleep(GClass0.int_1);
				continue;
			}
			break;
		}
	}

	// Token: 0x060000AE RID: 174 RVA: 0x0000B6C4 File Offset: 0x000098C4
	public void method_4()
	{
		for (;;)
		{
			try
			{
				this.class4_0.method_4("Setting delivery method", "#c2c2c2", true, false);
				JObject jobject = new JObject();
				jobject["delivery"] = new JObject();
				jobject["delivery"]["deliveryMethodID"] = this.string_8;
				this.class70_0.method_16(string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/carts/{1}", this.string_0, this.string_5), jobject, false).EnsureSuccessStatusCode();
			}
			catch (ThreadAbortException)
			{
			}
			catch
			{
				this.class4_0.method_4("Error setting delivery method", "#c2c2c2", true, false);
				Thread.Sleep(GClass0.int_1);
				continue;
			}
			break;
		}
	}

	// Token: 0x060000AF RID: 175 RVA: 0x0000326A File Offset: 0x0000146A
	public Task method_5()
	{
		Task task = new Task(new Action(this.method_11));
		task.Start();
		return task;
	}

	// Token: 0x060000B0 RID: 176 RVA: 0x0000B790 File Offset: 0x00009990
	public void method_6()
	{
		for (;;)
		{
			try
			{
				this.class4_0.method_4("Setting delivery data", "#c2c2c2", true, false);
				JObject jobject = new JObject();
				string propertyName = "customer";
				JObject jobject2 = new JObject();
				jobject2["id"] = string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/customers/{1}", this.string_0, this.string_6);
				jobject[propertyName] = jobject2;
				string propertyName2 = "billingAddress";
				JObject jobject3 = new JObject();
				jobject3["id"] = string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/customers/{1}/addresses/{2}", this.string_0, this.string_6, this.string_7);
				jobject[propertyName2] = jobject3;
				string propertyName3 = "deliveryAddress";
				JObject jobject4 = new JObject();
				jobject4["id"] = string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/customers/{1}/addresses/{2}", this.string_0, this.string_6, this.string_7);
				jobject[propertyName3] = jobject4;
				JObject jobject5 = jobject;
				HttpResponseMessage httpResponseMessage = this.class70_0.method_16(string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/carts/{1}", this.string_0, this.string_5), jobject5, false);
				httpResponseMessage.EnsureSuccessStatusCode();
				this.string_8 = httpResponseMessage.smethod_0()["delivery"]["deliveryMethodID"].ToString();
			}
			catch (ThreadAbortException)
			{
			}
			catch
			{
				this.class4_0.method_4("Error setting delivery data", "#c2c2c2", true, false);
				Thread.Sleep(GClass0.int_1);
				continue;
			}
			break;
		}
	}

	// Token: 0x060000B1 RID: 177 RVA: 0x0000B91C File Offset: 0x00009B1C
	public void method_7()
	{
		for (;;)
		{
			try
			{
				this.class4_0.method_4("Initialising payment", "#c2c2c2", true, false);
				JObject jobject = new JObject();
				string propertyName = "terminals";
				JObject jobject2 = new JObject();
				jobject2["successURL"] = "http://ok";
				jobject2["failureURL"] = "http://fail";
				jobject2["timeoutURL"] = "http://timeout";
				jobject[propertyName] = jobject2;
				object key = "successURL";
				jobject["terminals"][key] = "http://ok";
				object key2 = "failureURL";
				jobject["terminals"][key2] = "http://fail";
				object key3 = "timeoutURL";
				jobject["terminals"][key3] = "http://timeout";
				JObject jobject3 = jobject;
				HttpResponseMessage httpResponseMessage = this.class70_0.method_9(string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/carts/{1}/hostedPayment", this.string_0, this.string_5), jobject3, true);
				while (httpResponseMessage.smethod_3().Contains("one or more products is unavailable"))
				{
					this.class4_0.method_4("Waiting for restock", "#c2c2c2", true, false);
					httpResponseMessage = this.class70_0.method_9(string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/carts/{1}/hostedPayment", this.string_0, this.string_5), jobject3, true);
					Thread.Sleep(GClass0.int_0);
				}
				httpResponseMessage.EnsureSuccessStatusCode();
				JObject jobject4 = httpResponseMessage.smethod_0();
				this.string_9 = jobject4["ID"].ToString();
				this.string_10 = jobject4["terminalEndPoints"]["cardEntryURL"].ToString().Split(new char[]
				{
					'='
				})[1].Split(new char[]
				{
					'"'
				})[0];
			}
			catch (ThreadAbortException)
			{
			}
			catch
			{
				this.class4_0.method_4("Error initialising payment", "#c2c2c2", true, false);
				Thread.Sleep(GClass0.int_1);
				continue;
			}
			break;
		}
	}

	// Token: 0x060000B2 RID: 178 RVA: 0x0000BB44 File Offset: 0x00009D44
	public void method_8()
	{
		for (;;)
		{
			try
			{
				this.class4_0.method_4("Submitting payment", "orange", true, false);
				Dictionary<string, string> dictionary = Class70.smethod_1();
				dictionary["card_number"] = ((string)this.jtoken_1["payment"]["card"]["number"]).Replace(" ", string.Empty);
				dictionary["exp_month"] = (string)this.jtoken_1["payment"]["card"]["exp_month"];
				dictionary["exp_year"] = (string)this.jtoken_1["payment"]["card"]["exp_year"];
				dictionary["cv2_number"] = (string)this.jtoken_1["payment"]["card"]["cvv"];
				dictionary["HPS_SessionID"] = this.string_10;
				dictionary["action"] = "confirm";
				HttpResponseMessage httpResponseMessage = this.class70_0.method_7("https://hps.datacash.com/hps/?", dictionary, false);
				if (httpResponseMessage.smethod_3().Contains("Please enter a valid card number"))
				{
					this.class4_0.method_0("Invalid card details", "red", false);
				}
				string string_ = httpResponseMessage.Headers.GetValues("Location").First<string>().ToString();
				this.method_9(string_);
			}
			catch (ThreadAbortException)
			{
			}
			catch
			{
				this.class4_0.method_4("Error submitting payment", "#c2c2c2", true, false);
				Thread.Sleep(GClass0.int_1);
				continue;
			}
			break;
		}
	}

	// Token: 0x060000B3 RID: 179 RVA: 0x0000BD2C File Offset: 0x00009F2C
	public void method_9(string string_11)
	{
		for (;;)
		{
			try
			{
				this.class4_0.method_4("Submitting order", "orange", true, false);
				HttpResponseMessage httpResponseMessage_ = this.class70_0.method_9(string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/payments/{1}/hostedpaymentresult", this.string_0, this.string_9), JObject.Parse(string.Format("{{'HostedPaymentPageResult':'{0}'}}", string_11)), true);
				while (httpResponseMessage_.smethod_0().ToString().Contains("speed limit"))
				{
					Thread.Sleep(1000);
					httpResponseMessage_ = this.class70_0.method_9(string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/payments/{1}/hostedpaymentresult", this.string_0, this.string_9), JObject.Parse(string.Format("{{'HostedPaymentPageResult':'{0}'}}", string_11)), true);
				}
				while (httpResponseMessage_.smethod_0().ToString().Contains("Payment in progress"))
				{
					Thread.Sleep(1000);
					httpResponseMessage_ = this.class70_0.method_9(string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/payments/{1}/hostedpaymentresult", this.string_0, this.string_9), JObject.Parse(string.Format("{{'HostedPaymentPageResult':'{0}'}}", string_11)), true);
				}
				if (httpResponseMessage_.smethod_0()["status"].ToString() == "DECLINED")
				{
					this.class4_0.method_9(true);
					this.class4_0.method_0("Payment Declined", "red", false);
				}
				else if (httpResponseMessage_.smethod_0()["status"].ToString() == "ERROR")
				{
					this.class4_0.method_0("Payment error", "red", false);
				}
				else
				{
					this.class4_0.method_12();
					this.class4_0.method_9(false);
					this.class4_0.method_0("Successfully checked out", "green", false);
				}
			}
			catch (ThreadAbortException)
			{
			}
			catch
			{
				this.class4_0.method_4("Error submitting order", "#c2c2c2", true, false);
				Thread.Sleep(GClass0.int_1);
				continue;
			}
			break;
		}
	}

	// Token: 0x060000B4 RID: 180 RVA: 0x00003283 File Offset: 0x00001483
	private bool method_10(JToken jtoken_2)
	{
		return Class167.smethod_2(this.string_4, jtoken_2["name"].ToString());
	}

	// Token: 0x060000B5 RID: 181 RVA: 0x0000BF3C File Offset: 0x0000A13C
	private void method_11()
	{
		for (;;)
		{
			try
			{
				this.class4_0.method_4("Collecting delivery data", "#c2c2c2", true, false);
				JObject jobject = new JObject();
				jobject["firstName"] = this.jtoken_1["delivery"]["first_name"];
				jobject["lastName"] = this.jtoken_1["delivery"]["last_name"];
				jobject["email"] = this.jtoken_1["payment"]["email"];
				jobject["phone"] = this.jtoken_1["payment"]["phone"];
				jobject["enrolledForEmailMarketing"] = false;
				jobject["isGuest"] = true;
				JObject jobject2 = jobject;
				JObject jobject3 = new JObject();
				jobject3["firstName"] = this.jtoken_1["delivery"]["first_name"];
				jobject3["lastName"] = this.jtoken_1["delivery"]["last_name"];
				jobject3["address1"] = this.jtoken_1["delivery"]["addr1"];
				jobject3["address2"] = this.jtoken_1["delivery"]["addr2"];
				jobject3["country"] = this.jtoken_1["delivery"]["country"];
				jobject3["locale"] = Class167.smethod_0((string)this.jtoken_1["delivery"]["country"], false);
				jobject3["state"] = Class167.smethod_1((string)this.jtoken_1["delivery"]["country"], (string)this.jtoken_1["delivery"]["state"]);
				jobject3["postcode"] = this.jtoken_1["delivery"]["zip"];
				jobject3["town"] = this.jtoken_1["delivery"]["city"];
				jobject3["isPrimaryBillingAddress"] = false;
				jobject3["isPrimaryAddress"] = true;
				JObject jobject4 = jobject3;
				JObject jobject5 = new JObject();
				jobject5["firstName"] = this.jtoken_1["billing"]["first_name"];
				jobject5["lastName"] = this.jtoken_1["billing"]["last_name"];
				jobject5["address1"] = this.jtoken_1["billing"]["addr1"];
				jobject5["address2"] = this.jtoken_1["billing"]["addr2"];
				jobject5["country"] = this.jtoken_1["billing"]["first_ncountryame"];
				jobject5["locale"] = Class167.smethod_0((string)this.jtoken_1["billing"]["country"], false);
				jobject5["state"] = Class167.smethod_1((string)this.jtoken_1["billing"]["country"], (string)this.jtoken_1["billing"]["state"]);
				jobject5["postcode"] = this.jtoken_1["billing"]["zip"];
				jobject5["town"] = this.jtoken_1["billing"]["city"];
				jobject5["isPrimaryBillingAddress"] = true;
				jobject5["isPrimaryAddress"] = false;
				JObject jobject6 = jobject5;
				jobject2["addresses"] = new JArray(new object[]
				{
					jobject4,
					jobject6
				});
				HttpResponseMessage httpResponseMessage = this.class70_0.method_9(string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/customers", this.string_0), jobject2, true);
				if (httpResponseMessage.StatusCode == HttpStatusCode.Conflict)
				{
					this.class4_0.method_0("Invalid info", "red", false);
				}
				httpResponseMessage.EnsureSuccessStatusCode();
				this.string_6 = httpResponseMessage.smethod_0()["ID"].ToString();
				this.string_7 = httpResponseMessage.smethod_0()["addresses"][0]["ID"].ToString();
			}
			catch (ThreadAbortException)
			{
			}
			catch
			{
				this.class4_0.method_4("Error collecting delivery data", "#c2c2c2", true, false);
				Thread.Sleep(GClass0.int_1);
				continue;
			}
			break;
		}
	}

	// Token: 0x0400006E RID: 110
	private Class70 class70_0;

	// Token: 0x0400006F RID: 111
	private JToken jtoken_0;

	// Token: 0x04000070 RID: 112
	private JToken jtoken_1;

	// Token: 0x04000071 RID: 113
	private Class4 class4_0;

	// Token: 0x04000072 RID: 114
	private string string_0;

	// Token: 0x04000073 RID: 115
	private string string_1;

	// Token: 0x04000074 RID: 116
	private string string_2;

	// Token: 0x04000075 RID: 117
	private string string_3;

	// Token: 0x04000076 RID: 118
	private string string_4;

	// Token: 0x04000077 RID: 119
	private string string_5;

	// Token: 0x04000078 RID: 120
	private string string_6;

	// Token: 0x04000079 RID: 121
	private string string_7;

	// Token: 0x0400007A RID: 122
	private string string_8;

	// Token: 0x0400007B RID: 123
	private string string_9;

	// Token: 0x0400007C RID: 124
	private string string_10;

	// Token: 0x0400007D RID: 125
	private bool bool_0;

	// Token: 0x0400007E RID: 126
	private JObject jobject_0;

	// Token: 0x0200001C RID: 28
	[Serializable]
	private sealed class Class14
	{
		// Token: 0x060000B8 RID: 184 RVA: 0x000032AC File Offset: 0x000014AC
		internal bool method_0(JToken jtoken_0)
		{
			return jtoken_0["product"]["stockStatus"].ToString() == "IN STOCK";
		}

		// Token: 0x0400007F RID: 127
		public static readonly Class13.Class14 class14_0 = new Class13.Class14();

		// Token: 0x04000080 RID: 128
		public static Func<JToken, bool> func_0;
	}
}
