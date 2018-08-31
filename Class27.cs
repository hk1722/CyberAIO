﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;

// Token: 0x02000037 RID: 55
internal sealed class Class27
{
	// Token: 0x06000155 RID: 341 RVA: 0x0000E768 File Offset: 0x0000C968
	public Class27(JToken jtoken_2)
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
				this.string_1 = jtoken_2["keywords"].ToString().Split(new char[]
				{
					'#'
				}).First<string>();
				this.string_2 = ((string)jtoken_2["size"]).Replace("UK ", string.Empty);
				if (this.string_2 == "Random" || this.string_2 == "OneSize")
				{
					this.bool_0 = true;
				}
				this.bool_1 = (jtoken_2["bank_transfer"] != null && (bool)jtoken_2["bank_transfer"]);
				this.class70_0 = new Class70(this.class4_0.method_6(), "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.181 Safari/537.36", 60, false, false, null, false);
				this.class70_0.httpClient_0.DefaultRequestHeaders.TryAddWithoutValidation("Referer", this.string_1);
			}
		}
		catch
		{
			this.class4_0.method_0("Task error", "red", true);
		}
	}

	// Token: 0x06000156 RID: 342 RVA: 0x0000E8F4 File Offset: 0x0000CAF4
	public void method_0()
	{
		try
		{
			this.class4_0.method_8();
			this.method_2();
			this.method_3();
			this.method_4();
			this.method_5(false);
			if (this.bool_1)
			{
				this.method_14();
			}
			else
			{
				this.method_9();
				this.method_10();
				this.method_11();
				this.method_12();
				this.method_13();
			}
		}
		catch
		{
		}
		finally
		{
			this.class4_0.method_0("Stopped", "red", true);
		}
	}

	// Token: 0x06000157 RID: 343 RVA: 0x000039D3 File Offset: 0x00001BD3
	public string method_1(string string_13)
	{
		HtmlDocument htmlDocument = new HtmlDocument();
		htmlDocument.LoadHtml(this.string_11);
		return htmlDocument.DocumentNode.SelectSingleNode(string.Format("//option[text() = '{0}']", string_13)).Attributes["value"].Value;
	}

	// Token: 0x06000158 RID: 344 RVA: 0x0000E98C File Offset: 0x0000CB8C
	public void method_2()
	{
		this.class4_0.method_4("Waiting for product", "#c2c2c2", true, false);
		for (;;)
		{
			try
			{
				HttpResponseMessage httpResponseMessage = this.class70_0.method_5(this.string_1 + ".json", true);
				httpResponseMessage.EnsureSuccessStatusCode();
				JObject jobject = httpResponseMessage.smethod_0();
				if (this.bool_0)
				{
					JToken jtoken = jobject["available_sizes"];
					if (!jtoken.Any<JToken>())
					{
						this.class4_0.method_4("Waiting for restock", "#c2c2c2", true, false);
						Thread.Sleep(GClass0.int_0);
						continue;
					}
					JToken jtoken2 = jtoken[MainWindow.random_0.Next(0, jtoken.Count<JToken>() - 1)];
					this.string_0 = jtoken2["id"].ToString();
					this.class4_0.method_5(jtoken2["name"].ToString());
				}
				else
				{
					JToken jtoken3 = jobject["available_sizes"].FirstOrDefault(new Func<JToken, bool>(this.method_15));
					if (jtoken3 == null)
					{
						this.class4_0.method_4("Waiting for restock", "#c2c2c2", true, false);
						Thread.Sleep(GClass0.int_0);
						continue;
					}
					this.string_0 = jtoken3["id"].ToString();
				}
				this.class4_0.method_4("Found variant ID: " + this.string_0, "#c2c2c2", true, false);
				break;
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

	// Token: 0x06000159 RID: 345 RVA: 0x0000EB54 File Offset: 0x0000CD54
	public void method_3()
	{
		for (;;)
		{
			try
			{
				this.class4_0.method_4("Adding to cart", "yellow", true, false);
				JObject jobject = new JObject();
				jobject["variant_id"] = this.string_0;
				jobject["quantity"] = "1";
				HttpResponseMessage httpResponseMessage = this.class70_0.method_9("https://www.antonioli.eu/en/GB/orders/populate.json", jobject, false);
				if (httpResponseMessage.smethod_3().Contains("not available"))
				{
					this.class4_0.method_4("Waiting for restock", "#c2c2c2", true, false);
					Thread.Sleep(GClass0.int_0);
					this.method_2();
					continue;
				}
				httpResponseMessage.EnsureSuccessStatusCode();
				this.class4_0.method_4("Successfully carted", "#c2c2c2", true, false);
			}
			catch (ThreadAbortException)
			{
			}
			catch
			{
				this.class4_0.method_4("Error adding to cart", "#c2c2c2", true, false);
				Thread.Sleep(GClass0.int_0);
				continue;
			}
			break;
		}
	}

	// Token: 0x0600015A RID: 346 RVA: 0x0000EC64 File Offset: 0x0000CE64
	public void method_4()
	{
		for (;;)
		{
			try
			{
				this.class4_0.method_4("Logging in", "#c2c2c2", true, false);
				JObject jobject = new JObject();
				jobject["order"] = new JObject();
				jobject["order"]["email"] = this.jtoken_1["payment"]["email"];
				if (!(bool)this.class70_0.method_12("https://www.antonioli.eu/en/GB/orders/populate.json", jobject, false).smethod_0()["ok"])
				{
					throw new Exception();
				}
				this.class4_0.method_4("Successfully logged in", "#c2c2c2", true, false);
			}
			catch (ThreadAbortException)
			{
			}
			catch
			{
				this.class4_0.method_4("Error logging in", "#c2c2c2", true, false);
				Thread.Sleep(GClass0.int_0);
				continue;
			}
			break;
		}
	}

	// Token: 0x0600015B RID: 347 RVA: 0x0000ED5C File Offset: 0x0000CF5C
	public void method_5(bool bool_2)
	{
		for (;;)
		{
			try
			{
				this.class4_0.method_4("Submitting shipping", "#c2c2c2", true, false);
				JObject jobject = new JObject();
				string propertyName = "order";
				JObject jobject2 = new JObject();
				jobject2["bill_address_attributes"] = new JObject();
				jobject2["ship_address_attributes"] = new JObject();
				jobject2["email"] = this.jtoken_1["payment"]["email"];
				jobject2["state_lock_version"] = "0";
				object key = "firstname";
				jobject2["bill_address_attributes"][key] = this.jtoken_1["billing"]["first_name"];
				object key2 = "lastname";
				jobject2["bill_address_attributes"][key2] = this.jtoken_1["billing"]["last_name"];
				object key3 = "address1";
				jobject2["bill_address_attributes"][key3] = this.jtoken_1["billing"]["addr1"];
				object key4 = "address2";
				jobject2["bill_address_attributes"][key4] = this.jtoken_1["billing"]["addr2"];
				object key5 = "city";
				jobject2["bill_address_attributes"][key5] = this.jtoken_1["billing"]["city"];
				object key6 = "country_id";
				jobject2["bill_address_attributes"][key6] = this.method_1((string)this.jtoken_1["billing"]["country"]);
				object key7 = "zipcode";
				jobject2["bill_address_attributes"][key7] = this.jtoken_1["billing"]["zip"];
				object key8 = "phone";
				jobject2["bill_address_attributes"][key8] = this.jtoken_1["payment"]["phone"];
				object key9 = "state_name";
				jobject2["bill_address_attributes"][key9] = Class167.smethod_1((string)this.jtoken_1["billing"]["country"], (string)this.jtoken_1["billing"]["state"]);
				object key10 = "firstname";
				jobject2["ship_address_attributes"][key10] = this.jtoken_1["delivery"]["first_name"];
				object key11 = "lastname";
				jobject2["ship_address_attributes"][key11] = this.jtoken_1["delivery"]["last_name"];
				object key12 = "address1";
				jobject2["ship_address_attributes"][key12] = this.jtoken_1["delivery"]["addr1"];
				object key13 = "address2";
				jobject2["ship_address_attributes"][key13] = this.jtoken_1["delivery"]["addr2"];
				object key14 = "city";
				jobject2["ship_address_attributes"][key14] = this.jtoken_1["delivery"]["city"];
				object key15 = "country_id";
				jobject2["ship_address_attributes"][key15] = this.method_1((string)this.jtoken_1["delivery"]["country"]);
				object key16 = "state_name";
				jobject2["ship_address_attributes"][key16] = Class167.smethod_1((string)this.jtoken_1["delivery"]["country"], (string)this.jtoken_1["delivery"]["state"]);
				object key17 = "zipcode";
				jobject2["ship_address_attributes"][key17] = this.jtoken_1["delivery"]["zip"];
				object key18 = "phone";
				jobject2["ship_address_attributes"][key18] = this.jtoken_1["payment"]["phone"];
				object key19 = "shipping";
				jobject2["ship_address_attributes"][key19] = "true";
				jobject2["terms_and_conditions"] = "yes";
				jobject[propertyName] = jobject2;
				JObject jobject_ = jobject;
				HttpResponseMessage httpResponseMessage = this.class70_0.method_12("https://www.antonioli.eu/en/GB/checkout/update/address", jobject_, bool_2);
				if (httpResponseMessage.smethod_3().Contains("order_ship_address_attributes_state"))
				{
					this.class4_0.method_0("Invalid shipping", "red", false);
				}
				if (bool_2)
				{
					HtmlDocument htmlDocument = new HtmlDocument();
					htmlDocument.LoadHtml(httpResponseMessage.smethod_3());
					this.string_10 = htmlDocument.DocumentNode.SelectSingleNode("//meta[@name='CART_PATH']").Attributes["content"].Value.Split(new char[]
					{
						'/'
					})[4];
					this.string_7 = httpResponseMessage.smethod_3().Replace(" ", string.Empty).Split(new string[]
					{
						"Spree.current_order_id=\""
					}, StringSplitOptions.None)[1].Split(new char[]
					{
						'"'
					})[0];
					this.string_6 = htmlDocument.DocumentNode.SelectSingleNode("//span[@class='amount']").InnerText.Replace(" ", string.Empty).Replace("€", string.Empty);
				}
				else
				{
					this.string_10 = httpResponseMessage.Headers.Location.ToString().Split(new char[]
					{
						'/'
					})[4];
				}
				this.class4_0.method_4("Detected region: " + this.string_10, "#c2c2c2", true, false);
			}
			catch (ThreadAbortException)
			{
			}
			catch
			{
				this.class4_0.method_4("Error submitting shipping", "#c2c2c2", true, false);
				Thread.Sleep(GClass0.int_0);
				continue;
			}
			break;
		}
	}

	// Token: 0x0600015C RID: 348 RVA: 0x0000F3F0 File Offset: 0x0000D5F0
	public void method_6()
	{
		for (;;)
		{
			try
			{
				this.class4_0.method_4("Getting shipping info", "#c2c2c2", true, false);
				HttpResponseMessage httpResponseMessage_ = this.class70_0.method_5("https://www.antonioli.eu/en/GB/checkout/delivery", false);
				HtmlDocument htmlDocument = new HtmlDocument();
				htmlDocument.LoadHtml(httpResponseMessage_.smethod_3());
				this.string_4 = htmlDocument.DocumentNode.SelectSingleNode("//input[@name='order[shipments_attributes][0][selected_shipping_rate_id]']").Attributes["value"].Value;
				this.string_5 = htmlDocument.DocumentNode.SelectSingleNode("//input[@name='order[shipments_attributes][0][id]']").Attributes["value"].Value;
				this.string_7 = httpResponseMessage_.smethod_3().Replace(" ", string.Empty).Split(new string[]
				{
					"Spree.current_order_id=\""
				}, StringSplitOptions.None)[1].Split(new char[]
				{
					'"'
				})[0];
				this.class4_0.method_4("Detected region: " + this.string_10, "#c2c2c2", true, false);
				this.class4_0.method_7(htmlDocument.DocumentNode.SelectSingleNode("//td[@class='description']//strong").InnerText, "#c2c2c2");
			}
			catch (ThreadAbortException)
			{
			}
			catch
			{
				this.class4_0.method_4("Error getting shipping info", "#c2c2c2", true, false);
				Thread.Sleep(GClass0.int_0);
				continue;
			}
			break;
		}
	}

	// Token: 0x0600015D RID: 349 RVA: 0x0000F578 File Offset: 0x0000D778
	public void method_7()
	{
		for (;;)
		{
			try
			{
				this.class4_0.method_4("Submitting shipping method", "#c2c2c2", true, false);
				Dictionary<string, string> dictionary = Class70.smethod_1();
				dictionary["_method"] = "patch";
				dictionary["order[state_lock_version]"] = "1";
				dictionary["order[shipments_attributes][0][selected_shipping_rate_id]"] = this.string_4;
				dictionary["order[shipments_attributes][0][id]"] = this.string_5;
				this.class70_0.method_7(string.Format("https://www.antonioli.eu/en/{0}/checkout/update/delivery", this.string_10), dictionary, false);
			}
			catch (ThreadAbortException)
			{
			}
			catch
			{
				this.class4_0.method_4("Error submitting shipping method", "#c2c2c2", true, false);
				Thread.Sleep(GClass0.int_0);
				continue;
			}
			break;
		}
	}

	// Token: 0x0600015E RID: 350 RVA: 0x0000F64C File Offset: 0x0000D84C
	public void method_8()
	{
		for (;;)
		{
			try
			{
				this.class4_0.method_4("Submitting shipping method", "#c2c2c2", true, false);
				JObject jobject = new JObject();
				string propertyName = "order";
				JObject jobject2 = new JObject();
				jobject2["state_lock_version"] = "1";
				jobject[propertyName] = jobject2;
				JObject jobject3 = jobject;
				JObject jobject4 = new JObject();
				jobject4["selected_shipping_rate_id"] = this.string_4;
				jobject4["id"] = this.string_5;
				JObject content = jobject4;
				jobject3["order"]["shipments_attributes"] = new JArray(content);
				this.class70_0.method_12("https://www.antonioli.eu/en/GB/orders/populate.json", jobject3, false).EnsureSuccessStatusCode();
			}
			catch (ThreadAbortException)
			{
			}
			catch
			{
				this.class4_0.method_4("Error submitting shipping method", "#c2c2c2", true, false);
				Thread.Sleep(GClass0.int_0);
				continue;
			}
			break;
		}
	}

	// Token: 0x0600015F RID: 351 RVA: 0x0000F74C File Offset: 0x0000D94C
	public void method_9()
	{
		for (;;)
		{
			try
			{
				this.class4_0.method_4("Getting payment token", "#c2c2c2", true, false);
				Dictionary<string, string> dictionary = Class70.smethod_1();
				dictionary["transaction"] = this.string_7;
				dictionary["amount"] = (this.string_6.Contains(".") ? this.string_6.Replace(",", string.Empty) : (this.string_6.Replace(",", string.Empty) + ".0"));
				HttpResponseMessage httpResponseMessage = this.class70_0.method_7(string.Format("https://www.antonioli.eu/en/{0}/checkout/payment/get_token.json", this.string_10), dictionary, false);
				httpResponseMessage.EnsureSuccessStatusCode();
				this.string_8 = httpResponseMessage.smethod_0()["token"].ToString();
			}
			catch (ThreadAbortException)
			{
			}
			catch
			{
				this.class4_0.method_4("Error getting payment token", "#c2c2c2", true, false);
				Thread.Sleep(GClass0.int_0);
				continue;
			}
			break;
		}
	}

	// Token: 0x06000160 RID: 352 RVA: 0x0000F864 File Offset: 0x0000DA64
	public void method_10()
	{
		for (;;)
		{
			try
			{
				this.class4_0.method_4("Getting payment info", "#c2c2c2", true, false);
				HttpResponseMessage httpResponseMessage = this.class70_0.method_5(string.Format("https://ecomm.sella.it/Pagam/hiddenIframe.aspx?a=9091712&b={0}&MerchantUrl=https://www.antonioli.eu/en/GB/checkout/payment", this.string_8), true);
				httpResponseMessage.EnsureSuccessStatusCode();
				HtmlDocument htmlDocument = new HtmlDocument();
				htmlDocument.LoadHtml(httpResponseMessage.smethod_3());
				foreach (HtmlNode htmlNode in ((IEnumerable<HtmlNode>)htmlDocument.DocumentNode.SelectNodes("//form//input[@value][@name]")))
				{
					this.dictionary_0[htmlNode.Attributes["name"].Value] = htmlNode.Attributes["value"].Value;
				}
			}
			catch (ThreadAbortException)
			{
			}
			catch
			{
				this.class4_0.method_4("Error getting payment info", "#c2c2c2", true, false);
				Thread.Sleep(GClass0.int_0);
				continue;
			}
			break;
		}
	}

	// Token: 0x06000161 RID: 353 RVA: 0x0000F97C File Offset: 0x0000DB7C
	public void method_11()
	{
		for (;;)
		{
			try
			{
				this.class4_0.method_4("Submitting payment", "orange", true, false);
				this.dictionary_0["cardnumber"] = this.jtoken_1["payment"]["card"]["number"].ToString().Replace(" ", string.Empty);
				this.dictionary_0["cardExpiryMonth"] = (string)this.jtoken_1["payment"]["card"]["exp_month"];
				this.dictionary_0["cardExpiryYear"] = this.jtoken_1["payment"]["card"]["exp_year"].ToString().Substring(2);
				this.dictionary_0["cvv"] = (string)this.jtoken_1["payment"]["card"]["cvv"];
				this.dictionary_0["inputString"] = this.string_8;
				HttpResponseMessage httpResponseMessage = this.class70_0.method_7(string.Format("https://ecomm.sella.it/Pagam/hiddenIframe.aspx?a=9091712&b={0}&MerchantUrl=https://www.antonioli.eu/en/GB/checkout/payment", this.string_8), this.dictionary_0, false);
				httpResponseMessage.EnsureSuccessStatusCode();
				string text = httpResponseMessage.smethod_3().Split(new string[]
				{
					"//<![CDATA["
				}, StringSplitOptions.None)[1].ToLower();
				if (text.Contains("invalid") || text.Contains("wrong") || text.Contains("expired"))
				{
					this.class4_0.method_0("Invalid card info", "red", false);
				}
				this.string_9 = httpResponseMessage.smethod_3().Split(new string[]
				{
					"delayedSendResult('0','','','','"
				}, StringSplitOptions.None)[1].Split(new string[]
				{
					"')//]"
				}, StringSplitOptions.None)[0];
			}
			catch (ThreadAbortException)
			{
			}
			catch
			{
				this.class4_0.method_4("Error submitting payment", "#c2c2c2", true, false);
				Thread.Sleep(GClass0.int_0);
				continue;
			}
			break;
		}
	}

	// Token: 0x06000162 RID: 354 RVA: 0x0000FBD4 File Offset: 0x0000DDD4
	public void method_12()
	{
		for (;;)
		{
			try
			{
				this.class4_0.method_4("Processing payment", "orange", true, false);
				Dictionary<string, string> dictionary = Class70.smethod_1();
				dictionary["token"] = this.string_9;
				HttpResponseMessage httpResponseMessage_ = this.class70_0.method_7("https://www.antonioli.eu/checkout/payment/process_token.json", dictionary, false);
				JObject jobject = httpResponseMessage_.smethod_0();
				if (jobject.ContainsKey("error"))
				{
					if (jobject["error"].ToString().Contains("Autorizzazione negata"))
					{
						this.class4_0.method_9(true);
						this.class4_0.method_0("Payment Declined", "red", false);
					}
					else
					{
						this.class4_0.method_0("Payment error", "red", false);
						GClass3.smethod_0(httpResponseMessage_.smethod_3(), "error");
					}
				}
				else if (httpResponseMessage_.smethod_3().Contains("gestpay_completion"))
				{
					this.string_12 = (string)jobject["redirect"];
				}
				else
				{
					this.class4_0.method_0("Payment error", "red", false);
					GClass3.smethod_0(httpResponseMessage_.smethod_3(), "error");
				}
			}
			catch (ThreadAbortException)
			{
			}
			catch
			{
				this.class4_0.method_4("Error processing payment", "#c2c2c2", true, false);
				Thread.Sleep(GClass0.int_0);
				continue;
			}
			break;
		}
	}

	// Token: 0x06000163 RID: 355 RVA: 0x0000FD54 File Offset: 0x0000DF54
	public void method_13()
	{
		for (;;)
		{
			try
			{
				this.class4_0.method_4("Submitting order", "orange", true, false);
				HttpResponseMessage httpResponseMessage = this.class70_0.method_5(string.Format("https://www.antonioli.eu/{0}", this.string_12), false);
				if (httpResponseMessage.StatusCode != HttpStatusCode.Found)
				{
					throw new Exception();
				}
				if (httpResponseMessage.smethod_3().Contains("orders"))
				{
					this.class4_0.method_9(false);
					this.class4_0.method_0("Successfully checked out", "green", false);
				}
				else
				{
					this.class4_0.method_9(true);
					this.class4_0.method_0("Payment error", "red", false);
				}
			}
			catch (ThreadAbortException)
			{
			}
			catch
			{
				this.class4_0.method_4("Error submitting order", "#c2c2c2", true, false);
				Thread.Sleep(GClass0.int_0);
				continue;
			}
			break;
		}
	}

	// Token: 0x06000164 RID: 356 RVA: 0x0000FE48 File Offset: 0x0000E048
	public void method_14()
	{
		for (;;)
		{
			try
			{
				this.class4_0.method_4("Submitting order", "orange", true, false);
				Dictionary<string, string> dictionary = Class70.smethod_1();
				dictionary["utf8"] = "✓";
				dictionary["_method"] = "patch";
				dictionary["authenticity_token"] = string.Empty;
				dictionary["order[payments_attributes][][payment_method_id]"] = "10";
				HttpResponseMessage httpResponseMessage = this.class70_0.method_7(string.Format("https://www.antonioli.eu/en/{0}/checkout/update/payment", this.string_10), dictionary, false);
				if (httpResponseMessage.StatusCode != HttpStatusCode.Found)
				{
					throw new Exception();
				}
				if (httpResponseMessage.smethod_3().Contains("orders"))
				{
					this.class4_0.method_9(false);
					this.class4_0.method_0("Successfully checked out", "green", false);
				}
				else
				{
					this.class4_0.method_9(true);
					this.class4_0.method_0("Payment error", "red", false);
				}
			}
			catch (ThreadAbortException)
			{
			}
			catch
			{
				this.class4_0.method_4("Error submitting order", "#c2c2c2", true, false);
				Thread.Sleep(GClass0.int_0);
				continue;
			}
			break;
		}
	}

	// Token: 0x06000165 RID: 357 RVA: 0x00003A0F File Offset: 0x00001C0F
	private bool method_15(JToken jtoken_2)
	{
		return Class167.smethod_2(this.string_2, jtoken_2["name"].ToString());
	}

	// Token: 0x040000AE RID: 174
	private Class70 class70_0;

	// Token: 0x040000AF RID: 175
	private JToken jtoken_0;

	// Token: 0x040000B0 RID: 176
	private JToken jtoken_1;

	// Token: 0x040000B1 RID: 177
	private Class4 class4_0;

	// Token: 0x040000B2 RID: 178
	private bool bool_0;

	// Token: 0x040000B3 RID: 179
	private string string_0;

	// Token: 0x040000B4 RID: 180
	private string string_1;

	// Token: 0x040000B5 RID: 181
	private string string_2;

	// Token: 0x040000B6 RID: 182
	private string string_3;

	// Token: 0x040000B7 RID: 183
	private string string_4;

	// Token: 0x040000B8 RID: 184
	private string string_5;

	// Token: 0x040000B9 RID: 185
	private string string_6;

	// Token: 0x040000BA RID: 186
	private string string_7;

	// Token: 0x040000BB RID: 187
	private string string_8;

	// Token: 0x040000BC RID: 188
	private string string_9;

	// Token: 0x040000BD RID: 189
	private Dictionary<string, string> dictionary_0 = new Dictionary<string, string>();

	// Token: 0x040000BE RID: 190
	private string string_10;

	// Token: 0x040000BF RID: 191
	private bool bool_1 = true;

	// Token: 0x040000C0 RID: 192
	private string string_11 = "<option data-validate-fiscal-code='false' value='178'>Albania</option> <option data-validate-fiscal-code='false' value='179'>Algeria</option> <option data-validate-fiscal-code='false' value='181'>American Samoa</option> <option data-validate-fiscal-code='false' value='184'>Andorra</option> <option data-validate-fiscal-code='false' value='187'>Angola</option> <option data-validate-fiscal-code='false' value='191'>Anguilla</option> <option data-validate-fiscal-code='false' value='197'>Antigua and Barbuda</option> <option data-validate-fiscal-code='false' value='203'>Argentina</option> <option data-validate-fiscal-code='false' value='107'>Armenia</option> <option data-validate-fiscal-code='false' value='108'>Aruba</option> <option data-validate-fiscal-code='false' value='109'>Australia</option> <option data-validate-fiscal-code='false' value='111'>Austria</option> <option data-validate-fiscal-code='false' value='114'>Azerbaijan</option> <option data-validate-fiscal-code='false' value='118'>Bahamas</option> <option data-validate-fiscal-code='false' value='122'>Bahrain</option> <option data-validate-fiscal-code='false' value='126'>Bangladesh</option> <option data-validate-fiscal-code='false' value='132'>Barbados</option> <option data-validate-fiscal-code='false' value='142'>Belarus</option> <option data-validate-fiscal-code='false' value='29'>Belgium</option> <option data-validate-fiscal-code='false' value='30'>Belize</option> <option data-validate-fiscal-code='false' value='33'>Benin</option> <option data-validate-fiscal-code='false' value='36'>Bermuda</option> <option data-validate-fiscal-code='false' value='40'>Bhutan</option> <option data-validate-fiscal-code='false' value='45'>Bolivia, Plurinational State of</option> <option data-validate-fiscal-code='false' value='50'>Bosnia and Herzegovina</option> <option data-validate-fiscal-code='false' value='55'>Botswana</option> <option data-validate-fiscal-code='true' value='61'>Brazil</option> <option data-validate-fiscal-code='false' value='68'>Brunei Darussalam</option> <option data-validate-fiscal-code='false' value='182'>Bulgaria</option> <option data-validate-fiscal-code='false' value='185'>Burkina Faso</option> <option data-validate-fiscal-code='false' value='188'>Burundi</option> <option data-validate-fiscal-code='false' value='192'>Cambodia</option> <option data-validate-fiscal-code='false' value='198'>Cameroon</option> <option data-validate-fiscal-code='false' value='204'>Canada</option> <option data-validate-fiscal-code='false' value='209'>Cape Verde</option> <option data-validate-fiscal-code='false' value='215'>Cayman Islands</option> <option data-validate-fiscal-code='false' value='221'>Central African Republic</option> <option data-validate-fiscal-code='false' value='1'>Chad</option> <option data-validate-fiscal-code='false' value='115'>Chile</option> <option data-validate-fiscal-code='false' value='119'>China</option> <option data-validate-fiscal-code='false' value='123'>Colombia</option> <option data-validate-fiscal-code='false' value='127'>Comoros</option> <option data-validate-fiscal-code='false' value='133'>Congo</option> <option data-validate-fiscal-code='false' value='138'>Congo, The Democratic Republic of the</option> <option data-validate-fiscal-code='false' value='143'>Cook Islands</option> <option data-validate-fiscal-code='false' value='154'>Costa Rica</option> <option data-validate-fiscal-code='false' value='158'>Côte dIvoireIvoire</option> <option data-validate-fiscal-code='false' value='161'>Croatia</option> <option data-validate-fiscal-code='false' value='41'>Cuba</option> <option data-validate-fiscal-code='false' value='46'>Cyprus</option> <option data-validate-fiscal-code='false' value='51'>Czech Republic</option> <option data-validate-fiscal-code='false' value='56'>Denmark</option> <option data-validate-fiscal-code='false' value='62'>Djibouti</option> <option data-validate-fiscal-code='false' value='69'>Dominica</option> <option data-validate-fiscal-code='false' value='74'>Dominican Republic</option> <option data-validate-fiscal-code='false' value='79'>Ecuador</option> <option data-validate-fiscal-code='false' value='85'>Egypt</option> <option data-validate-fiscal-code='false' value='90'>El Salvador</option> <option data-validate-fiscal-code='false' value='193'>Equatorial Guinea</option> <option data-validate-fiscal-code='false' value='205'>Eritrea</option> <option data-validate-fiscal-code='false' value='210'>Estonia</option> <option data-validate-fiscal-code='false' value='216'>Ethiopia</option> <option data-validate-fiscal-code='false' value='222'>Falkland Islands (Malvinas)</option> <option data-validate-fiscal-code='false' value='2'>Faroe Islands</option> <option data-validate-fiscal-code='false' value='6'>Fiji</option> <option data-validate-fiscal-code='false' value='10'>Finland</option> <option data-validate-fiscal-code='false' value='13'>France</option> <option data-validate-fiscal-code='false' value='17'>French Guiana</option> <option data-validate-fiscal-code='false' value='128'>French Polynesia</option> <option data-validate-fiscal-code='false' value='134'>Gabon</option> <option data-validate-fiscal-code='false' value='144'>Gambia</option> <option data-validate-fiscal-code='false' value='149'>Georgia</option> <option data-validate-fiscal-code='false' value='155'>Germany</option> <option data-validate-fiscal-code='false' value='162'>Ghana</option> <option data-validate-fiscal-code='false' value='165'>Gibraltar</option> <option data-validate-fiscal-code='false' value='168'>Greece</option> <option data-validate-fiscal-code='false' value='171'>Greenland</option> <option data-validate-fiscal-code='false' value='173'>Grenada</option> <option data-validate-fiscal-code='false' value='57'>Guadeloupe</option> <option data-validate-fiscal-code='false' value='63'>Guam</option> <option data-validate-fiscal-code='false' value='70'>Guatemala</option> <option data-validate-fiscal-code='false' value='80'>Guinea</option> <option data-validate-fiscal-code='false' value='86'>Guinea-Bissau</option> <option data-validate-fiscal-code='false' value='91'>Guyana</option> <option data-validate-fiscal-code='false' value='93'>Haiti</option> <option data-validate-fiscal-code='false' value='96'>Holy See (Vatican City State)</option> <option data-validate-fiscal-code='false' value='99'>Honduras</option> <option data-validate-fiscal-code='false' value='102'>Hong Kong</option> <option data-validate-fiscal-code='false' value='217'>Hungary</option> <option data-validate-fiscal-code='false' value='223'>Iceland</option> <option data-validate-fiscal-code='false' value='3'>India</option> <option data-validate-fiscal-code='false' value='7'>Indonesia</option> <option data-validate-fiscal-code='false' value='14'>Iran, Islamic Republic of</option> <option data-validate-fiscal-code='false' value='18'>Iraq</option> <option data-validate-fiscal-code='false' value='20'>Ireland</option> <option data-validate-fiscal-code='false' value='22'>Israel</option> <option data-validate-fiscal-code='true' value='24'>Italy</option> <option data-validate-fiscal-code='false' value='26'>Jamaica</option> <option data-validate-fiscal-code='false' value='27'>Japan</option> <option data-validate-fiscal-code='false' value='28'>Jordan</option> <option data-validate-fiscal-code='false' value='31'>Kazakhstan</option> <option data-validate-fiscal-code='false' value='34'>Kenya</option> <option data-validate-fiscal-code='false' value='37'>Kiribati</option> <option data-validate-fiscal-code='false' value='42'>Korea, Democratic Peoples Republic ofs Republic of</option> <option data-validate-fiscal-code='false' value='47'>Korea, Republic of</option> <option data-validate-fiscal-code='false' value='52'>Kuwait</option> <option data-validate-fiscal-code='false' value='58'>Kyrgyzstan</option> <option data-validate-fiscal-code='false' value='64'>Lao Peoples Democratic Republics Democratic Republic</option> <option data-validate-fiscal-code='false' value='180'>Latvia</option> <option data-validate-fiscal-code='false' value='183'>Lebanon</option> <option data-validate-fiscal-code='false' value='186'>Lesotho</option> <option data-validate-fiscal-code='false' value='189'>Liberia</option> <option data-validate-fiscal-code='false' value='194'>Libya</option> <option data-validate-fiscal-code='false' value='199'>Liechtenstein</option> <option data-validate-fiscal-code='false' value='206'>Lithuania</option> <option data-validate-fiscal-code='false' value='211'>Luxembourg</option> <option data-validate-fiscal-code='false' value='218'>Macao</option> <option data-validate-fiscal-code='false' value='224'>Macedonia, Republic of</option> <option data-validate-fiscal-code='false' value='112'>Madagascar</option> <option data-validate-fiscal-code='false' value='116'>Malawi</option> <option data-validate-fiscal-code='false' value='120'>Malaysia</option> <option data-validate-fiscal-code='false' value='124'>Maldives</option> <option data-validate-fiscal-code='false' value='129'>Mali</option> <option data-validate-fiscal-code='false' value='135'>Malta</option> <option data-validate-fiscal-code='false' value='139'>Marshall Islands</option> <option data-validate-fiscal-code='false' value='145'>Martinique</option> <option data-validate-fiscal-code='false' value='150'>Mauritania</option> <option data-validate-fiscal-code='false' value='156'>Mauritius</option> <option data-validate-fiscal-code='false' value='38'>Mexico</option> <option data-validate-fiscal-code='false' value='43'>Micronesia, Federated States of</option> <option data-validate-fiscal-code='false' value='48'>Moldova, Republic of</option> <option data-validate-fiscal-code='false' value='53'>Monaco</option> <option data-validate-fiscal-code='false' value='59'>Mongolia</option> <option data-validate-fiscal-code='false' value='229'>Montenegro</option> <option data-validate-fiscal-code='false' value='65'>Montserrat</option> <option data-validate-fiscal-code='false' value='71'>Morocco</option> <option data-validate-fiscal-code='false' value='75'>Mozambique</option> <option data-validate-fiscal-code='false' value='81'>Myanmar</option> <option data-validate-fiscal-code='false' value='87'>Namibia</option> <option data-validate-fiscal-code='false' value='195'>Nauru</option> <option data-validate-fiscal-code='false' value='200'>Nepal</option> <option data-validate-fiscal-code='false' value='207'>Netherlands</option> <option data-validate-fiscal-code='false' value='212'>Netherlands Antilles</option> <option data-validate-fiscal-code='false' value='219'>New Caledonia</option> <option data-validate-fiscal-code='false' value='225'>New Zealand</option> <option data-validate-fiscal-code='false' value='4'>Nicaragua</option> <option data-validate-fiscal-code='false' value='8'>Niger</option> <option data-validate-fiscal-code='false' value='11'>Nigeria</option> <option data-validate-fiscal-code='false' value='15'>Niue</option> <option data-validate-fiscal-code='false' value='130'>Norfolk Island</option> <option data-validate-fiscal-code='false' value='136'>Northern Mariana Islands</option> <option data-validate-fiscal-code='false' value='140'>Norway</option> <option data-validate-fiscal-code='false' value='146'>Oman</option> <option data-validate-fiscal-code='false' value='151'>Pakistan</option> <option data-validate-fiscal-code='false' value='157'>Palau</option> <option data-validate-fiscal-code='false' value='159'>Panama</option> <option data-validate-fiscal-code='false' value='163'>Papua New Guinea</option> <option data-validate-fiscal-code='false' value='166'>Paraguay</option> <option data-validate-fiscal-code='false' value='169'>Peru</option> <option data-validate-fiscal-code='false' value='60'>Philippines</option> <option data-validate-fiscal-code='false' value='66'>Pitcairn</option> <option data-validate-fiscal-code='false' value='72'>Poland</option> <option data-validate-fiscal-code='false' value='76'>Portugal</option> <option data-validate-fiscal-code='false' value='82'>Puerto Rico</option> <option data-validate-fiscal-code='false' value='88'>Qatar</option> <option data-validate-fiscal-code='false' value='92'>Réunion</option> <option data-validate-fiscal-code='false' value='94'>Romania</option> <option data-validate-fiscal-code='false' value='97'>Russian Federation</option> <option data-validate-fiscal-code='false' value='100'>Rwanda</option> <option data-validate-fiscal-code='false' value='213'>Saint Helena, Ascension and Tristan da Cunha</option> <option data-validate-fiscal-code='false' value='226'>Saint Kitts and Nevis</option> <option data-validate-fiscal-code='false' value='5'>Saint Lucia</option> <option data-validate-fiscal-code='false' value='9'>Saint Pierre and Miquelon</option> <option data-validate-fiscal-code='false' value='12'>Saint Vincent and the Grenadines</option> <option data-validate-fiscal-code='false' value='16'>Samoa</option> <option data-validate-fiscal-code='false' value='19'>San Marino</option> <option data-validate-fiscal-code='false' value='21'>Sao Tome and Principe</option> <option data-validate-fiscal-code='false' value='23'>Saudi Arabia</option> <option data-validate-fiscal-code='false' value='25'>Senegal</option> <option data-validate-fiscal-code='false' value='227'>Serbia</option> <option data-validate-fiscal-code='false' value='147'>Seychelles</option> <option data-validate-fiscal-code='false' value='152'>Sierra Leone</option> <option data-validate-fiscal-code='false' value='160'>Singapore</option> <option data-validate-fiscal-code='false' value='164'>Slovakia</option> <option data-validate-fiscal-code='false' value='167'>Slovenia</option> <option data-validate-fiscal-code='false' value='170'>Solomon Islands</option> <option data-validate-fiscal-code='false' value='172'>Somalia</option> <option data-validate-fiscal-code='false' value='174'>South Africa</option> <option data-validate-fiscal-code='false' value='175'>Spain</option> <option data-validate-fiscal-code='false' value='176'>Sri Lanka</option> <option data-validate-fiscal-code='false' value='77'>Sudan</option> <option data-validate-fiscal-code='false' value='83'>Suriname</option> <option data-validate-fiscal-code='false' value='89'>Svalbard and Jan Mayen</option> <option data-validate-fiscal-code='false' value='95'>Swaziland</option> <option data-validate-fiscal-code='false' value='98'>Sweden</option> <option data-validate-fiscal-code='false' value='101'>Switzerland</option> <option data-validate-fiscal-code='false' value='103'>Syrian Arab Republic</option> <option data-validate-fiscal-code='false' value='104'>Taiwan</option> <option data-validate-fiscal-code='false' value='105'>Tajikistan</option> <option data-validate-fiscal-code='false' value='106'>Tanzania, United Republic of</option> <option data-validate-fiscal-code='false' value='110'>Thailand</option> <option data-validate-fiscal-code='false' value='113'>Togo</option> <option data-validate-fiscal-code='false' value='117'>Tokelau</option> <option data-validate-fiscal-code='false' value='121'>Tonga</option> <option data-validate-fiscal-code='false' value='125'>Trinidad and Tobago</option> <option data-validate-fiscal-code='false' value='131'>Tunisia</option> <option data-validate-fiscal-code='false' value='137'>Turkey</option> <option data-validate-fiscal-code='false' value='141'>Turkmenistan</option> <option data-validate-fiscal-code='false' value='148'>Turks and Caicos Islands</option> <option data-validate-fiscal-code='false' value='153'>Tuvalu</option> <option data-validate-fiscal-code='false' value='32'>Uganda</option> <option data-validate-fiscal-code='false' value='35'>Ukraine</option> <option data-validate-fiscal-code='false' value='39'>United Arab Emirates</option> <option data-validate-fiscal-code='false' value='44'>United Kingdom</option> <option data-validate-fiscal-code='false' selected='selected' value='49'>United States</option> <option data-validate-fiscal-code='false' value='54'>Uruguay</option> <option data-validate-fiscal-code='false' value='67'>Uzbekistan</option> <option data-validate-fiscal-code='false' value='73'>Vanuatu</option> <option data-validate-fiscal-code='false' value='78'>Venezuela, Bolivarian Republic of</option> <option data-validate-fiscal-code='false' value='84'>Viet Nam</option> <option data-validate-fiscal-code='false' value='190'>Virgin Islands, British</option> <option data-validate-fiscal-code='false' value='196'>Virgin Islands, U.S.</option> <option data-validate-fiscal-code='false' value='201'>Wallis and Futuna</option> <option data-validate-fiscal-code='false' value='202'>Western Sahara</option> <option data-validate-fiscal-code='false' value='208'>Yemen</option> <option data-validate-fiscal-code='false' value='214'>Zambia</option> <option data-validate-fiscal-code='false' value='220'>Zimbabwe</option>";

	// Token: 0x040000C1 RID: 193
	private string string_12;
}
