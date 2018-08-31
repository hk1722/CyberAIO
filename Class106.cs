using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;

// Token: 0x020000C6 RID: 198
internal sealed class Class106
{
	// Token: 0x06000527 RID: 1319 RVA: 0x0002D1C8 File Offset: 0x0002B3C8
	public Class106(JToken jtoken_2)
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

	// Token: 0x06000528 RID: 1320 RVA: 0x0002D34C File Offset: 0x0002B54C
	public void method_0()
	{
		try
		{
			this.class4_0.method_8();
			this.method_2();
			this.method_3();
			this.method_4();
			this.method_5();
			if (this.bool_1)
			{
				this.method_7();
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

	// Token: 0x06000529 RID: 1321 RVA: 0x00005666 File Offset: 0x00003866
	public string method_1(string string_13)
	{
		HtmlDocument htmlDocument = new HtmlDocument();
		htmlDocument.LoadHtml(this.string_11);
		return htmlDocument.DocumentNode.SelectSingleNode(string.Format("//option[text() = '{0}']", string_13)).Attributes["value"].Value;
	}

	// Token: 0x0600052A RID: 1322 RVA: 0x0002D3E8 File Offset: 0x0002B5E8
	public void method_2()
	{
		this.class4_0.method_4("Waiting for product", "#c2c2c2", true, false);
		for (;;)
		{
			try
			{
				HttpResponseMessage httpResponseMessage = this.class70_0.method_5(this.string_1 + ".json", true);
				if (httpResponseMessage.StatusCode == HttpStatusCode.Forbidden)
				{
					this.class4_0.method_0("Proxy banned", "red", false);
				}
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

	// Token: 0x0600052B RID: 1323 RVA: 0x0002D5D4 File Offset: 0x0002B7D4
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
				HttpResponseMessage httpResponseMessage = this.class70_0.method_9("https://www.off---white.com/en/GB/orders/populate.json", jobject, false);
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

	// Token: 0x0600052C RID: 1324 RVA: 0x0002D6E4 File Offset: 0x0002B8E4
	public void method_4()
	{
		for (;;)
		{
			try
			{
				this.class4_0.method_4("Logging in", "#c2c2c2", true, false);
				JObject jobject = new JObject();
				string propertyName = "order";
				JObject jobject2 = new JObject();
				jobject2["email"] = this.jtoken_1["payment"]["email"];
				jobject[propertyName] = jobject2;
				JObject jobject_ = jobject;
				if (!(bool)this.class70_0.method_12("https://www.off---white.com/en/GB/orders/populate.json", jobject_, false).smethod_0()["ok"])
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

	// Token: 0x0600052D RID: 1325 RVA: 0x0002D7D4 File Offset: 0x0002B9D4
	public void method_5()
	{
		for (;;)
		{
			try
			{
				this.class4_0.method_4("Submitting shipping", "#c2c2c2", true, false);
				JObject jobject = new JObject();
				jobject["order"] = new JObject();
				jobject["order"]["bill_address_attributes"] = new JObject();
				jobject["order"]["ship_address_attributes"] = new JObject();
				jobject["order"]["email"] = this.jtoken_1["payment"]["email"];
				jobject["order"]["state_lock_version"] = "0";
				jobject["order"]["bill_address_attributes"]["firstname"] = this.jtoken_1["billing"]["first_name"];
				jobject["order"]["bill_address_attributes"]["lastname"] = this.jtoken_1["billing"]["last_name"];
				jobject["order"]["bill_address_attributes"]["address1"] = this.jtoken_1["billing"]["addr1"];
				jobject["order"]["bill_address_attributes"]["address2"] = this.jtoken_1["billing"]["addr2"];
				jobject["order"]["bill_address_attributes"]["city"] = this.jtoken_1["billing"]["city"];
				jobject["order"]["bill_address_attributes"]["country_id"] = this.method_1((string)this.jtoken_1["billing"]["country"]);
				jobject["order"]["bill_address_attributes"]["zipcode"] = this.jtoken_1["billing"]["zip"];
				jobject["order"]["bill_address_attributes"]["phone"] = this.jtoken_1["payment"]["phone"];
				jobject["order"]["bill_address_attributes"]["state_name"] = Class167.smethod_1((string)this.jtoken_1["billing"]["country"], (string)this.jtoken_1["billing"]["state"]);
				jobject["order"]["ship_address_attributes"]["firstname"] = this.jtoken_1["delivery"]["first_name"];
				jobject["order"]["ship_address_attributes"]["lastname"] = this.jtoken_1["delivery"]["last_name"];
				jobject["order"]["ship_address_attributes"]["address1"] = this.jtoken_1["delivery"]["addr1"];
				jobject["order"]["ship_address_attributes"]["address2"] = this.jtoken_1["delivery"]["addr2"];
				jobject["order"]["ship_address_attributes"]["city"] = this.jtoken_1["delivery"]["city"];
				jobject["order"]["ship_address_attributes"]["country_id"] = this.method_1((string)this.jtoken_1["delivery"]["country"]);
				jobject["order"]["ship_address_attributes"]["state_name"] = Class167.smethod_1((string)this.jtoken_1["delivery"]["country"], (string)this.jtoken_1["delivery"]["state"]);
				jobject["order"]["ship_address_attributes"]["zipcode"] = this.jtoken_1["delivery"]["zip"];
				jobject["order"]["ship_address_attributes"]["phone"] = this.jtoken_1["payment"]["phone"];
				jobject["order"]["ship_address_attributes"]["shipping"] = "true";
				jobject["order"]["terms_and_conditions"] = "yes";
				HttpResponseMessage httpResponseMessage = this.class70_0.method_12("https://www.off---white.com/en/GB/checkout/update/address", jobject, true);
				httpResponseMessage.EnsureSuccessStatusCode();
				if (httpResponseMessage.smethod_3().Contains("order_ship_address_attributes_state"))
				{
					this.class4_0.method_0("Invalid shipping", "red", false);
				}
				HtmlDocument htmlDocument = new HtmlDocument();
				htmlDocument.LoadHtml(httpResponseMessage.smethod_3());
				this.string_4 = htmlDocument.DocumentNode.SelectSingleNode("//input[@name='order[shipments_attributes][0][selected_shipping_rate_id]']").Attributes["value"].Value;
				this.string_5 = htmlDocument.DocumentNode.SelectSingleNode("//input[@name='order[shipments_attributes][0][id]']").Attributes["value"].Value;
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
				this.class4_0.method_4("Detected region: " + this.string_10, "#c2c2c2", true, false);
				this.class4_0.method_7(htmlDocument.DocumentNode.SelectSingleNode("//td[@class='description']//strong").InnerText, "#c2c2c2");
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

	// Token: 0x0600052E RID: 1326 RVA: 0x0002DF60 File Offset: 0x0002C160
	public void method_6()
	{
		for (;;)
		{
			try
			{
				this.class4_0.method_4("Getting shipping info", "#c2c2c2", true, false);
				HttpResponseMessage httpResponseMessage_ = this.class70_0.method_5("https://www.off---white.com/en/GB/checkout/delivery", false);
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

	// Token: 0x0600052F RID: 1327 RVA: 0x0002E0E8 File Offset: 0x0002C2E8
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
				this.class70_0.method_7(string.Format("https://www.off---white.com/en/{0}/checkout/update/delivery", this.string_10), dictionary, false);
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

	// Token: 0x06000530 RID: 1328 RVA: 0x0002E1BC File Offset: 0x0002C3BC
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
				this.class70_0.method_12("https://www.off---white.com/en/GB/orders/populate.json", jobject3, false).EnsureSuccessStatusCode();
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

	// Token: 0x06000531 RID: 1329 RVA: 0x0002E2BC File Offset: 0x0002C4BC
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
				HttpResponseMessage httpResponseMessage = this.class70_0.method_7(string.Format("https://www.off---white.com/en/{0}/checkout/payment/get_token.json", this.string_10), dictionary, false);
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

	// Token: 0x06000532 RID: 1330 RVA: 0x0002E3D4 File Offset: 0x0002C5D4
	public void method_10()
	{
		for (;;)
		{
			try
			{
				this.class4_0.method_4("Getting payment info", "#c2c2c2", true, false);
				HttpResponseMessage httpResponseMessage = this.class70_0.method_5(string.Format("https://ecomm.sella.it/Pagam/hiddenIframe.aspx?a=9091712&b={0}&MerchantUrl=https://www.off---white.com/en/GB/checkout/payment", this.string_8), true);
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

	// Token: 0x06000533 RID: 1331 RVA: 0x0002E4EC File Offset: 0x0002C6EC
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
				HttpResponseMessage httpResponseMessage = this.class70_0.method_7(string.Format("https://ecomm.sella.it/Pagam/hiddenIframe.aspx?a=9091712&b={0}&MerchantUrl=https://www.off---white.com/en/GB/checkout/payment", this.string_8), this.dictionary_0, false);
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

	// Token: 0x06000534 RID: 1332 RVA: 0x0002E744 File Offset: 0x0002C944
	public void method_12()
	{
		for (;;)
		{
			try
			{
				this.class4_0.method_4("Processing payment", "orange", true, false);
				Dictionary<string, string> dictionary = Class70.smethod_1();
				dictionary["token"] = this.string_9;
				HttpResponseMessage httpResponseMessage_ = this.class70_0.method_7("https://www.off---white.com/checkout/payment/process_token.json", dictionary, false);
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

	// Token: 0x06000535 RID: 1333 RVA: 0x0002E8C4 File Offset: 0x0002CAC4
	public void method_13()
	{
		for (;;)
		{
			try
			{
				this.class4_0.method_4("Submitting order", "orange", true, false);
				HttpResponseMessage httpResponseMessage = this.class70_0.method_5(string.Format("https://www.off---white.com/{0}", this.string_12), false);
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

	// Token: 0x06000536 RID: 1334 RVA: 0x0002E9B8 File Offset: 0x0002CBB8
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
				HttpResponseMessage httpResponseMessage = this.class70_0.method_7(string.Format("https://www.off---white.com/en/{0}/checkout/update/payment", this.string_10), dictionary, false);
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

	// Token: 0x06000537 RID: 1335 RVA: 0x000056A2 File Offset: 0x000038A2
	private bool method_15(JToken jtoken_2)
	{
		return Class167.smethod_2(this.string_2, jtoken_2["name"].ToString());
	}

	// Token: 0x04000281 RID: 641
	private Class70 class70_0;

	// Token: 0x04000282 RID: 642
	private JToken jtoken_0;

	// Token: 0x04000283 RID: 643
	private JToken jtoken_1;

	// Token: 0x04000284 RID: 644
	private Class4 class4_0;

	// Token: 0x04000285 RID: 645
	private bool bool_0;

	// Token: 0x04000286 RID: 646
	private string string_0;

	// Token: 0x04000287 RID: 647
	private string string_1;

	// Token: 0x04000288 RID: 648
	private string string_2;

	// Token: 0x04000289 RID: 649
	private string string_3;

	// Token: 0x0400028A RID: 650
	private string string_4;

	// Token: 0x0400028B RID: 651
	private string string_5;

	// Token: 0x0400028C RID: 652
	private string string_6;

	// Token: 0x0400028D RID: 653
	private string string_7;

	// Token: 0x0400028E RID: 654
	private string string_8;

	// Token: 0x0400028F RID: 655
	private string string_9;

	// Token: 0x04000290 RID: 656
	private Dictionary<string, string> dictionary_0 = new Dictionary<string, string>();

	// Token: 0x04000291 RID: 657
	private string string_10;

	// Token: 0x04000292 RID: 658
	private bool bool_1;

	// Token: 0x04000293 RID: 659
	private string string_11 = "<option data-validate-fiscal-code='false' value='178'>Albania</option> <option data-validate-fiscal-code='false' value='179'>Algeria</option> <option data-validate-fiscal-code='false' value='181'>American Samoa</option> <option data-validate-fiscal-code='false' value='184'>Andorra</option> <option data-validate-fiscal-code='false' value='187'>Angola</option> <option data-validate-fiscal-code='false' value='191'>Anguilla</option> <option data-validate-fiscal-code='false' value='197'>Antigua and Barbuda</option> <option data-validate-fiscal-code='false' value='203'>Argentina</option> <option data-validate-fiscal-code='false' value='107'>Armenia</option> <option data-validate-fiscal-code='false' value='108'>Aruba</option> <option data-validate-fiscal-code='false' value='109'>Australia</option> <option data-validate-fiscal-code='false' value='111'>Austria</option> <option data-validate-fiscal-code='false' value='114'>Azerbaijan</option> <option data-validate-fiscal-code='false' value='118'>Bahamas</option> <option data-validate-fiscal-code='false' value='122'>Bahrain</option> <option data-validate-fiscal-code='false' value='126'>Bangladesh</option> <option data-validate-fiscal-code='false' value='132'>Barbados</option> <option data-validate-fiscal-code='false' value='142'>Belarus</option> <option data-validate-fiscal-code='false' value='29'>Belgium</option> <option data-validate-fiscal-code='false' value='30'>Belize</option> <option data-validate-fiscal-code='false' value='33'>Benin</option> <option data-validate-fiscal-code='false' value='36'>Bermuda</option> <option data-validate-fiscal-code='false' value='40'>Bhutan</option> <option data-validate-fiscal-code='false' value='45'>Bolivia, Plurinational State of</option> <option data-validate-fiscal-code='false' value='50'>Bosnia and Herzegovina</option> <option data-validate-fiscal-code='false' value='55'>Botswana</option> <option data-validate-fiscal-code='true' value='61'>Brazil</option> <option data-validate-fiscal-code='false' value='68'>Brunei Darussalam</option> <option data-validate-fiscal-code='false' value='182'>Bulgaria</option> <option data-validate-fiscal-code='false' value='185'>Burkina Faso</option> <option data-validate-fiscal-code='false' value='188'>Burundi</option> <option data-validate-fiscal-code='false' value='192'>Cambodia</option> <option data-validate-fiscal-code='false' value='198'>Cameroon</option> <option data-validate-fiscal-code='false' value='204'>Canada</option> <option data-validate-fiscal-code='false' value='209'>Cape Verde</option> <option data-validate-fiscal-code='false' value='215'>Cayman Islands</option> <option data-validate-fiscal-code='false' value='221'>Central African Republic</option> <option data-validate-fiscal-code='false' value='1'>Chad</option> <option data-validate-fiscal-code='false' value='115'>Chile</option> <option data-validate-fiscal-code='false' value='119'>China</option> <option data-validate-fiscal-code='false' value='123'>Colombia</option> <option data-validate-fiscal-code='false' value='127'>Comoros</option> <option data-validate-fiscal-code='false' value='133'>Congo</option> <option data-validate-fiscal-code='false' value='138'>Congo, The Democratic Republic of the</option> <option data-validate-fiscal-code='false' value='143'>Cook Islands</option> <option data-validate-fiscal-code='false' value='154'>Costa Rica</option> <option data-validate-fiscal-code='false' value='158'>Côte dIvoireIvoire</option> <option data-validate-fiscal-code='false' value='161'>Croatia</option> <option data-validate-fiscal-code='false' value='41'>Cuba</option> <option data-validate-fiscal-code='false' value='46'>Cyprus</option> <option data-validate-fiscal-code='false' value='51'>Czech Republic</option> <option data-validate-fiscal-code='false' value='56'>Denmark</option> <option data-validate-fiscal-code='false' value='62'>Djibouti</option> <option data-validate-fiscal-code='false' value='69'>Dominica</option> <option data-validate-fiscal-code='false' value='74'>Dominican Republic</option> <option data-validate-fiscal-code='false' value='79'>Ecuador</option> <option data-validate-fiscal-code='false' value='85'>Egypt</option> <option data-validate-fiscal-code='false' value='90'>El Salvador</option> <option data-validate-fiscal-code='false' value='193'>Equatorial Guinea</option> <option data-validate-fiscal-code='false' value='205'>Eritrea</option> <option data-validate-fiscal-code='false' value='210'>Estonia</option> <option data-validate-fiscal-code='false' value='216'>Ethiopia</option> <option data-validate-fiscal-code='false' value='222'>Falkland Islands (Malvinas)</option> <option data-validate-fiscal-code='false' value='2'>Faroe Islands</option> <option data-validate-fiscal-code='false' value='6'>Fiji</option> <option data-validate-fiscal-code='false' value='10'>Finland</option> <option data-validate-fiscal-code='false' value='13'>France</option> <option data-validate-fiscal-code='false' value='17'>French Guiana</option> <option data-validate-fiscal-code='false' value='128'>French Polynesia</option> <option data-validate-fiscal-code='false' value='134'>Gabon</option> <option data-validate-fiscal-code='false' value='144'>Gambia</option> <option data-validate-fiscal-code='false' value='149'>Georgia</option> <option data-validate-fiscal-code='false' value='155'>Germany</option> <option data-validate-fiscal-code='false' value='162'>Ghana</option> <option data-validate-fiscal-code='false' value='165'>Gibraltar</option> <option data-validate-fiscal-code='false' value='168'>Greece</option> <option data-validate-fiscal-code='false' value='171'>Greenland</option> <option data-validate-fiscal-code='false' value='173'>Grenada</option> <option data-validate-fiscal-code='false' value='57'>Guadeloupe</option> <option data-validate-fiscal-code='false' value='63'>Guam</option> <option data-validate-fiscal-code='false' value='70'>Guatemala</option> <option data-validate-fiscal-code='false' value='80'>Guinea</option> <option data-validate-fiscal-code='false' value='86'>Guinea-Bissau</option> <option data-validate-fiscal-code='false' value='91'>Guyana</option> <option data-validate-fiscal-code='false' value='93'>Haiti</option> <option data-validate-fiscal-code='false' value='96'>Holy See (Vatican City State)</option> <option data-validate-fiscal-code='false' value='99'>Honduras</option> <option data-validate-fiscal-code='false' value='102'>Hong Kong</option> <option data-validate-fiscal-code='false' value='217'>Hungary</option> <option data-validate-fiscal-code='false' value='223'>Iceland</option> <option data-validate-fiscal-code='false' value='3'>India</option> <option data-validate-fiscal-code='false' value='7'>Indonesia</option> <option data-validate-fiscal-code='false' value='14'>Iran, Islamic Republic of</option> <option data-validate-fiscal-code='false' value='18'>Iraq</option> <option data-validate-fiscal-code='false' value='20'>Ireland</option> <option data-validate-fiscal-code='false' value='22'>Israel</option> <option data-validate-fiscal-code='true' value='24'>Italy</option> <option data-validate-fiscal-code='false' value='26'>Jamaica</option> <option data-validate-fiscal-code='false' value='27'>Japan</option> <option data-validate-fiscal-code='false' value='28'>Jordan</option> <option data-validate-fiscal-code='false' value='31'>Kazakhstan</option> <option data-validate-fiscal-code='false' value='34'>Kenya</option> <option data-validate-fiscal-code='false' value='37'>Kiribati</option> <option data-validate-fiscal-code='false' value='42'>Korea, Democratic Peoples Republic ofs Republic of</option> <option data-validate-fiscal-code='false' value='47'>Korea, Republic of</option> <option data-validate-fiscal-code='false' value='52'>Kuwait</option> <option data-validate-fiscal-code='false' value='58'>Kyrgyzstan</option> <option data-validate-fiscal-code='false' value='64'>Lao Peoples Democratic Republics Democratic Republic</option> <option data-validate-fiscal-code='false' value='180'>Latvia</option> <option data-validate-fiscal-code='false' value='183'>Lebanon</option> <option data-validate-fiscal-code='false' value='186'>Lesotho</option> <option data-validate-fiscal-code='false' value='189'>Liberia</option> <option data-validate-fiscal-code='false' value='194'>Libya</option> <option data-validate-fiscal-code='false' value='199'>Liechtenstein</option> <option data-validate-fiscal-code='false' value='206'>Lithuania</option> <option data-validate-fiscal-code='false' value='211'>Luxembourg</option> <option data-validate-fiscal-code='false' value='218'>Macao</option> <option data-validate-fiscal-code='false' value='224'>Macedonia, Republic of</option> <option data-validate-fiscal-code='false' value='112'>Madagascar</option> <option data-validate-fiscal-code='false' value='116'>Malawi</option> <option data-validate-fiscal-code='false' value='120'>Malaysia</option> <option data-validate-fiscal-code='false' value='124'>Maldives</option> <option data-validate-fiscal-code='false' value='129'>Mali</option> <option data-validate-fiscal-code='false' value='135'>Malta</option> <option data-validate-fiscal-code='false' value='139'>Marshall Islands</option> <option data-validate-fiscal-code='false' value='145'>Martinique</option> <option data-validate-fiscal-code='false' value='150'>Mauritania</option> <option data-validate-fiscal-code='false' value='156'>Mauritius</option> <option data-validate-fiscal-code='false' value='38'>Mexico</option> <option data-validate-fiscal-code='false' value='43'>Micronesia, Federated States of</option> <option data-validate-fiscal-code='false' value='48'>Moldova, Republic of</option> <option data-validate-fiscal-code='false' value='53'>Monaco</option> <option data-validate-fiscal-code='false' value='59'>Mongolia</option> <option data-validate-fiscal-code='false' value='229'>Montenegro</option> <option data-validate-fiscal-code='false' value='65'>Montserrat</option> <option data-validate-fiscal-code='false' value='71'>Morocco</option> <option data-validate-fiscal-code='false' value='75'>Mozambique</option> <option data-validate-fiscal-code='false' value='81'>Myanmar</option> <option data-validate-fiscal-code='false' value='87'>Namibia</option> <option data-validate-fiscal-code='false' value='195'>Nauru</option> <option data-validate-fiscal-code='false' value='200'>Nepal</option> <option data-validate-fiscal-code='false' value='207'>Netherlands</option> <option data-validate-fiscal-code='false' value='212'>Netherlands Antilles</option> <option data-validate-fiscal-code='false' value='219'>New Caledonia</option> <option data-validate-fiscal-code='false' value='225'>New Zealand</option> <option data-validate-fiscal-code='false' value='4'>Nicaragua</option> <option data-validate-fiscal-code='false' value='8'>Niger</option> <option data-validate-fiscal-code='false' value='11'>Nigeria</option> <option data-validate-fiscal-code='false' value='15'>Niue</option> <option data-validate-fiscal-code='false' value='130'>Norfolk Island</option> <option data-validate-fiscal-code='false' value='136'>Northern Mariana Islands</option> <option data-validate-fiscal-code='false' value='140'>Norway</option> <option data-validate-fiscal-code='false' value='146'>Oman</option> <option data-validate-fiscal-code='false' value='151'>Pakistan</option> <option data-validate-fiscal-code='false' value='157'>Palau</option> <option data-validate-fiscal-code='false' value='159'>Panama</option> <option data-validate-fiscal-code='false' value='163'>Papua New Guinea</option> <option data-validate-fiscal-code='false' value='166'>Paraguay</option> <option data-validate-fiscal-code='false' value='169'>Peru</option> <option data-validate-fiscal-code='false' value='60'>Philippines</option> <option data-validate-fiscal-code='false' value='66'>Pitcairn</option> <option data-validate-fiscal-code='false' value='72'>Poland</option> <option data-validate-fiscal-code='false' value='76'>Portugal</option> <option data-validate-fiscal-code='false' value='82'>Puerto Rico</option> <option data-validate-fiscal-code='false' value='88'>Qatar</option> <option data-validate-fiscal-code='false' value='92'>Réunion</option> <option data-validate-fiscal-code='false' value='94'>Romania</option> <option data-validate-fiscal-code='false' value='97'>Russian Federation</option> <option data-validate-fiscal-code='false' value='100'>Rwanda</option> <option data-validate-fiscal-code='false' value='213'>Saint Helena, Ascension and Tristan da Cunha</option> <option data-validate-fiscal-code='false' value='226'>Saint Kitts and Nevis</option> <option data-validate-fiscal-code='false' value='5'>Saint Lucia</option> <option data-validate-fiscal-code='false' value='9'>Saint Pierre and Miquelon</option> <option data-validate-fiscal-code='false' value='12'>Saint Vincent and the Grenadines</option> <option data-validate-fiscal-code='false' value='16'>Samoa</option> <option data-validate-fiscal-code='false' value='19'>San Marino</option> <option data-validate-fiscal-code='false' value='21'>Sao Tome and Principe</option> <option data-validate-fiscal-code='false' value='23'>Saudi Arabia</option> <option data-validate-fiscal-code='false' value='25'>Senegal</option> <option data-validate-fiscal-code='false' value='227'>Serbia</option> <option data-validate-fiscal-code='false' value='147'>Seychelles</option> <option data-validate-fiscal-code='false' value='152'>Sierra Leone</option> <option data-validate-fiscal-code='false' value='160'>Singapore</option> <option data-validate-fiscal-code='false' value='164'>Slovakia</option> <option data-validate-fiscal-code='false' value='167'>Slovenia</option> <option data-validate-fiscal-code='false' value='170'>Solomon Islands</option> <option data-validate-fiscal-code='false' value='172'>Somalia</option> <option data-validate-fiscal-code='false' value='174'>South Africa</option> <option data-validate-fiscal-code='false' value='175'>Spain</option> <option data-validate-fiscal-code='false' value='176'>Sri Lanka</option> <option data-validate-fiscal-code='false' value='77'>Sudan</option> <option data-validate-fiscal-code='false' value='83'>Suriname</option> <option data-validate-fiscal-code='false' value='89'>Svalbard and Jan Mayen</option> <option data-validate-fiscal-code='false' value='95'>Swaziland</option> <option data-validate-fiscal-code='false' value='98'>Sweden</option> <option data-validate-fiscal-code='false' value='101'>Switzerland</option> <option data-validate-fiscal-code='false' value='103'>Syrian Arab Republic</option> <option data-validate-fiscal-code='false' value='104'>Taiwan</option> <option data-validate-fiscal-code='false' value='105'>Tajikistan</option> <option data-validate-fiscal-code='false' value='106'>Tanzania, United Republic of</option> <option data-validate-fiscal-code='false' value='110'>Thailand</option> <option data-validate-fiscal-code='false' value='113'>Togo</option> <option data-validate-fiscal-code='false' value='117'>Tokelau</option> <option data-validate-fiscal-code='false' value='121'>Tonga</option> <option data-validate-fiscal-code='false' value='125'>Trinidad and Tobago</option> <option data-validate-fiscal-code='false' value='131'>Tunisia</option> <option data-validate-fiscal-code='false' value='137'>Turkey</option> <option data-validate-fiscal-code='false' value='141'>Turkmenistan</option> <option data-validate-fiscal-code='false' value='148'>Turks and Caicos Islands</option> <option data-validate-fiscal-code='false' value='153'>Tuvalu</option> <option data-validate-fiscal-code='false' value='32'>Uganda</option> <option data-validate-fiscal-code='false' value='35'>Ukraine</option> <option data-validate-fiscal-code='false' value='39'>United Arab Emirates</option> <option data-validate-fiscal-code='false' value='44'>United Kingdom</option> <option data-validate-fiscal-code='false' selected='selected' value='49'>United States</option> <option data-validate-fiscal-code='false' value='54'>Uruguay</option> <option data-validate-fiscal-code='false' value='67'>Uzbekistan</option> <option data-validate-fiscal-code='false' value='73'>Vanuatu</option> <option data-validate-fiscal-code='false' value='78'>Venezuela, Bolivarian Republic of</option> <option data-validate-fiscal-code='false' value='84'>Viet Nam</option> <option data-validate-fiscal-code='false' value='190'>Virgin Islands, British</option> <option data-validate-fiscal-code='false' value='196'>Virgin Islands, U.S.</option> <option data-validate-fiscal-code='false' value='201'>Wallis and Futuna</option> <option data-validate-fiscal-code='false' value='202'>Western Sahara</option> <option data-validate-fiscal-code='false' value='208'>Yemen</option> <option data-validate-fiscal-code='false' value='214'>Zambia</option> <option data-validate-fiscal-code='false' value='220'>Zimbabwe</option>";

	// Token: 0x04000294 RID: 660
	private string string_12;
}
