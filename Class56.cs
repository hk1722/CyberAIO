using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CyberAIO.Properties;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;

// Token: 0x02000060 RID: 96
internal sealed class Class56
{
	// Token: 0x06000222 RID: 546 RVA: 0x00012EE8 File Offset: 0x000110E8
	public Class56(JToken jtoken_2)
	{
		try
		{
			this.jtoken_1 = jtoken_2;
			this.class4_0 = new Class4(jtoken_2);
			this.string_1 = (string)jtoken_2["keywords"];
			if (!((string)jtoken_2["size"] == "Random") && !((string)jtoken_2["size"] == "OneSize"))
			{
				this.string_2 = (string)jtoken_2["size"];
				this.string_2.Replace('.', ',');
			}
			else
			{
				this.bool_0 = true;
			}
			if (!this.class4_0.method_3(out this.jtoken_0))
			{
				this.class4_0.method_0("Profile error", "red", false);
			}
			else
			{
				this.class70_0 = new Class70(this.class4_0.method_6(), "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.181 Safari/537.36", 10, false, false, null, false);
				this.class70_0.httpClient_0.DefaultRequestHeaders.ExpectContinue = new bool?(false);
			}
		}
		catch
		{
			this.class4_0.method_0("Task error", "red", false);
		}
	}

	// Token: 0x06000223 RID: 547 RVA: 0x00013040 File Offset: 0x00011240
	public void method_0()
	{
		try
		{
			this.class4_0.method_8();
			Task task = this.method_1();
			this.method_2();
			Class30.smethod_1((int)this.jtoken_1["id"], string.Format("https://www.footlocker.eu/INTERSHOP/web/WFS/Footlocker-Footlocker_GB-Site/en_GB/-/GBP/ViewProduct-ProductVariationSelect?BaseSKU={0}&InventoryServerity=ProductDetail", this.string_1));
			task.Wait();
			this.method_3();
			this.method_4();
			this.method_5();
			this.method_6();
		}
		catch
		{
		}
		finally
		{
			this.class4_0.method_0("Stopped", "red", true);
		}
	}

	// Token: 0x06000224 RID: 548 RVA: 0x00003F62 File Offset: 0x00002162
	public Task method_1()
	{
		Task task = new Task(new Action(this.method_7));
		task.Start();
		return task;
	}

	// Token: 0x06000225 RID: 549 RVA: 0x000130E4 File Offset: 0x000112E4
	public void method_2()
	{
		for (;;)
		{
			try
			{
				this.class4_0.method_4("Waiting for product", "#c2c2c2", true, false);
				HttpResponseMessage httpResponseMessage = this.class4_0.method_1(string.Format("https://www.footlocker.eu/INTERSHOP/web/WFS/Footlocker-Footlocker_GB-Site/en_GB/-/GBP/ViewProduct-ProductVariationSelect?BaseSKU={0}&InventoryServerity=ProductDetail", this.string_1), true, null);
				if (httpResponseMessage.StatusCode == HttpStatusCode.NotFound)
				{
					this.class4_0.method_0("Invalid URL (404)", "red", false);
				}
				httpResponseMessage.EnsureSuccessStatusCode();
				HtmlDocument htmlDocument = new HtmlDocument();
				htmlDocument.LoadHtml(httpResponseMessage.smethod_0()["content"].ToString());
				if (htmlDocument.DocumentNode.SelectNodes("//*[@id='add-to-cart-form-sku']") != null)
				{
					if (this.bool_0)
					{
						HtmlNodeCollection htmlNodeCollection = htmlDocument.DocumentNode.SelectNodes("//*[@class='fl-product-size--item']");
						if (htmlNodeCollection == null)
						{
							this.class4_0.method_0("Size unavailable", "red", false);
						}
						this.string_0 = htmlNodeCollection[MainWindow.random_0.Next(0, htmlNodeCollection.Count)].Attributes["data-form-field-value"].Value;
					}
					else
					{
						HtmlNode htmlNode = htmlDocument.DocumentNode.SelectSingleNode(string.Format("//span[contains(text(),'{0}')]", this.string_2));
						if (htmlNode != null)
						{
							this.string_0 = htmlNode.ParentNode.Attributes["data-form-field-value"].Value;
						}
						else
						{
							this.class4_0.method_0("Size unavailable", "red", false);
						}
					}
					using (IEnumerator<HtmlNode> enumerator = ((IEnumerable<HtmlNode>)htmlDocument.DocumentNode.SelectNodes("//input")).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							HtmlNode htmlNode2 = enumerator.Current;
							if (htmlNode2.Attributes.Contains("value") && htmlNode2.Attributes.Contains("name"))
							{
								if (htmlNode2.Attributes["name"].Value.ToLower().Contains("quantity"))
								{
									this.dictionary_0[htmlNode2.Attributes["name"].Value] = "1";
								}
								else
								{
									this.dictionary_0[htmlNode2.Attributes["name"].Value] = htmlNode2.Attributes["value"].Value;
								}
							}
						}
						goto IL_245;
					}
					goto IL_23F;
					IL_245:
					this.dictionary_0["SKU"] = this.string_0;
					break;
				}
				IL_23F:
				throw new Exception();
			}
			catch (ThreadAbortException)
			{
			}
			catch
			{
				Thread.Sleep(Settings.Default.monitor_delay);
				continue;
			}
			break;
		}
	}

	// Token: 0x06000226 RID: 550 RVA: 0x000133B4 File Offset: 0x000115B4
	public void method_3()
	{
		for (;;)
		{
			try
			{
				this.class4_0.method_4("Adding to cart", "#c2c2c2", true, false);
				this.dictionary_0["SynchronizerToken"] = this.string_3;
				HttpResponseMessage httpResponseMessage = this.class70_0.method_7(string.Format("https://{0}/en/addtocart", this.string_4), this.dictionary_0, false);
				while (httpResponseMessage.smethod_3().Contains("Product can not be added before launch date"))
				{
					this.class4_0.method_4("Waiting for release", "#c2c2c2", true, false);
					Thread.Sleep(Settings.Default.retry_delay);
					httpResponseMessage = this.class70_0.method_7(string.Format("https://{0}/en/addtocart", this.string_4), this.dictionary_0, false);
				}
				HtmlDocument htmlDocument = new HtmlDocument();
				htmlDocument.LoadHtml(httpResponseMessage.smethod_3());
				this.class4_0.method_7(htmlDocument.DocumentNode.SelectSingleNode("//span[@itemprop='name']").InnerText, "#c2c2c2");
				httpResponseMessage.EnsureSuccessStatusCode();
			}
			catch (ThreadAbortException)
			{
			}
			catch
			{
				this.class4_0.method_4("Error adding to cart", "#c2c2c2", true, false);
				Thread.Sleep(Settings.Default.retry_delay);
				continue;
			}
			break;
		}
	}

	// Token: 0x06000227 RID: 551 RVA: 0x000134FC File Offset: 0x000116FC
	public void method_4()
	{
		for (;;)
		{
			try
			{
				this.class4_0.method_4("Submitting shipping", "#c2c2c2", true, false);
				Dictionary<string, string> dictionary = Class70.smethod_1();
				dictionary["SynchronizerToken"] = this.string_3;
				dictionary["billing_Address3"] = string.Empty;
				dictionary["isshippingaddress"] = string.Empty;
				dictionary["billing_Title"] = "common.account.salutation.mr.text";
				dictionary["billing_FirstName"] = (string)this.jtoken_0["billing"]["first_name"];
				dictionary["billing_LastName"] = (string)this.jtoken_0["billing"]["last_name"];
				dictionary["billing_Address1"] = (string)this.jtoken_0["billing"]["addr1"];
				dictionary["billing_Address2"] = (this.jtoken_0["billing"]["addr1"].ToString().Split(new char[]
				{
					' '
				})[0].smethod_0() ? this.jtoken_0["billing"]["addr1"].ToString().Split(new char[]
				{
					' '
				})[0] : "0");
				dictionary["billing_Address3"] = (string)this.jtoken_0["billing"]["addr2"];
				dictionary["billing_City"] = (string)this.jtoken_0["billing"]["city"];
				dictionary["billing_PostalCode"] = (string)this.jtoken_0["billing"]["zip"];
				dictionary["billing_CountryCode"] = Class167.smethod_0((string)this.jtoken_0["billing"]["country"], false);
				dictionary["billing_PhoneHome"] = (string)this.jtoken_0["payment"]["phone"];
				dictionary["billing_BirthdayRequired"] = "true";
				dictionary["billing_Birthday_Day"] = "01";
				dictionary["billing_Birthday_Month"] = "01";
				dictionary["billing_Birthday_Year"] = "1990";
				dictionary["email_Email"] = (string)this.jtoken_0["payment"]["email"];
				dictionary["billing_ShippingAddressSameAsBilling"] = string.Empty;
				dictionary["isshippingaddress"] = string.Empty;
				dictionary["shipping_Title"] = "common.account.salutation.mr.text";
				dictionary["shipping_FirstName"] = (string)this.jtoken_0["delivery"]["first_name"];
				dictionary["shipping_LastName"] = (string)this.jtoken_0["delivery"]["last_name"];
				dictionary["shipping_Address1"] = (string)this.jtoken_0["delivery"]["addr1"];
				dictionary["shipping_Address2"] = (this.jtoken_0["delivery"]["addr1"].ToString().Split(new char[]
				{
					' '
				})[0].smethod_0() ? this.jtoken_0["delivery"]["addr1"].ToString().Split(new char[]
				{
					' '
				})[0] : "0");
				dictionary["shipping_Address3"] = (string)this.jtoken_0["delivery"]["addr2"];
				dictionary["shipping_City"] = (string)this.jtoken_0["delivery"]["city"];
				dictionary["shipping_PostalCode"] = (string)this.jtoken_0["delivery"]["zip"];
				dictionary["shipping_CountryCode"] = Class167.smethod_0((string)this.jtoken_0["delivery"]["country"], false);
				dictionary["shipping_PhoneHome"] = (string)this.jtoken_0["payment"]["phone"];
				dictionary["promotionCode"] = string.Empty;
				dictionary["PaymentServiceSelection"] = "dMKsFf0SbRcAAAFNHN88qNaq";
				dictionary["UserDeviceTypeForPaymentRedirect"] = "Desktop";
				dictionary["UserDeviceFingerprintForPaymentRedirect"] = "0400bpNfiPCR/AUNf94lis1zttlRfx+VM0Kfnrp/XmcfWoVVgr+Rt2dAZDYKGojTbbj7Ay36XoqtPmZFXM8jbbY2/zc5J3xnltE7Kq6IhM8HltvDlnXzDbRRZMFlj8uo417+TgsSA5y2mIsp2U5yrYp+5igWriMua6v6UX8EvCKxLeADvSEJLLdt5Y3XI2c5FEWnEFb7LoXxcUNydzLtG4iIzgeXlR0StWcKxwwBzmqrQiWxH1ZPRIwM6njw/ujAyYdbGKZt5JLThTvosS1xgSAgNfLEMokGoGJxgu1y04HLnOzU8XBpd1sDgWA73rYZtIsVyoA80pXCaXawrwf88vayC9C1UJgA1BQZQ4JudHOlf1KSnrbJSNyIsWB9R+WFa6fdxifyrThRovESnjwNVGXSgGQ8InPsuf6/kpMgG84gzO5PMQF00uJew9XqxzJ4y+q4+f7ypk+EO6/K3oOxQXYZs5cTbAHNea+iljAlWwXHcT+hgN6tJA4p1nA+k9XRlIy/cY2AmTS50PVkkRWvZSWgvJFEYUMEnFwrc5V3eY0fJJ82UD3fyk93hC6Bo0qhcOVgxA9x3qRKbjM42PnqoOsl8d3pZ/WuuaUQfveZj4MPqv5NOao4N+06jVc4K6FMki+uv9eOvsyvTBVVGK66EXEuaD0YLXuOWeFzAIsjF5E9P9gJB/s4Mwp5boWRHa+7AHqtF/5t+EKgbjXypamhTYJ5p2IPArjDreTC6uFgohzG6thap+9nixWCRWREjH59g5/QSzKz6zFbyZbyxPMQMv7YZ9mxtLKX2QfncSs2NHNZzALZjVp/OGcTE5Ppv736RSsQQEdu2XYvr46icoEUIBl9dJXAAYR3cfgvWnUHhXIkRJtofM5fO4/4C0OCbnRzpX9Skp62yUjciLFgfUflhWun3cYn8q04UaLxEp48DVRl0oBkPCJz7Ln+v5KTIBvOIMzuTzEBdNLiXsPV6scyeMvquPn+8qZPhDuvyt6DsUF2GbOXE2wBzXmvopYwJVsFx3E/58zGq/hZ0ZoyseD0G1/ThxEIvsJRqGfF9spFd7LTpxjhrt64WqIxSK+Vx63F6egN3u5bh8qtOMZhKoST0dhOCOCSU0oZPWNEfF9hXdZ4DRRkrbXWcoCj3I1znntcmg8XIiroNPn6uMT9rxZ7qeEFWXvYjosNCV2dXBYj5IxcLNnvxD/oqMJgm1d3aCEiD23NlOpKlXmV+KS2uervLu8rEx2v132icTYH9sO5D0viD2MsPiZXdNCqfEJwopp3NVIs753xO5Dlr7rXIj00GhUM5orPJVs30sKGZpQRyqKemuLh5VgYvHz52A5oR/IjU+bZjD2O3xUgB+ZtAeHicfLGEKOaSzC6VU9YFFAN6Q1x80WrOPxkUl4i0OeEAjcm7IafMZnevnJtZXgW8Ti68OEwdR5bFcY0rffe2F6NwUwl9obF7jnnc2OUoJ66f15nH1qFVYK/kbdnQGQ2ChqI0224+wMt+l6KrT5mRVzPI222Nv83OSd8Z5bROyquiITPB5bbw5Z18w20UWTBZY/LqONe/k4LEgOctpiLm7rt2eh0RPb1qSJ4QkEi4ePC0vr6rGjmiuv6Xcf4KsKcyM+vwDgHEslOao6gdlb4DUQ/VC4QLgeTp/wvJgFL36CNErrskd0rffV0eXh8dt4Fc+Wqw46CU3fMAd2G/BPPj9Gxv852VX+8flCx6w8epyEV4N7/nQa6Bmocq+j+UE+Ck+l6uGF9YNpL0WZ9Juyy";
				dictionary["ShippingMethodUUID"] = "nS2sFf0L12MAAAFZ6j3hqc5n";
				dictionary["termsAndConditions"] = "on";
				dictionary["email_Newsletter"] = "true";
				dictionary["GDPRDataComplianceRequired"] = "true";
				dictionary["sendOrder"] = string.Empty;
				HttpResponseMessage httpResponseMessage_ = this.class70_0.method_7(string.Format("https://{0}/INTERSHOP/web/WFS/Footlocker-Footlocker_GB-Site/en_GB/-/GBP/ViewCheckoutOverview-Dispatch", this.string_4), dictionary, true);
				if (httpResponseMessage_.smethod_3().Contains("Checkout is currently not possible"))
				{
					throw new Exception();
				}
				HtmlDocument htmlDocument = new HtmlDocument();
				htmlDocument.LoadHtml(httpResponseMessage_.smethod_3());
				foreach (HtmlNode htmlNode in ((IEnumerable<HtmlNode>)htmlDocument.DocumentNode.SelectNodes("//form//input")))
				{
					if (htmlNode.Attributes.Contains("value") && htmlNode.Attributes.Contains("name"))
					{
						this.dictionary_1[htmlNode.Attributes["name"].Value] = htmlNode.Attributes["value"].Value;
					}
				}
			}
			catch (ThreadAbortException)
			{
			}
			catch
			{
				this.class4_0.method_4("Error submitting shipping", "#c2c2c2", true, false);
				Thread.Sleep(Settings.Default.retry_delay);
				continue;
			}
			break;
		}
	}

	// Token: 0x06000228 RID: 552 RVA: 0x00013B84 File Offset: 0x00011D84
	public void method_5()
	{
		for (;;)
		{
			try
			{
				this.class4_0.method_4("Going to payment", "#c2c2c2", true, false);
				HttpResponseMessage httpResponseMessage = this.class70_0.method_7("https://live.barclaycardsmartpay.com/hpp/pay.shtml", this.dictionary_1, false);
				httpResponseMessage.EnsureSuccessStatusCode();
				if (httpResponseMessage.smethod_3().Contains("Unfortunately we were unable to process this request"))
				{
					this.class4_0.method_0("Payment error", "red", false);
				}
				HtmlDocument htmlDocument = new HtmlDocument();
				htmlDocument.LoadHtml(httpResponseMessage.smethod_3());
				foreach (HtmlNode htmlNode in ((IEnumerable<HtmlNode>)htmlDocument.DocumentNode.SelectNodes("//form//input")))
				{
					if (htmlNode.Attributes.Contains("value") && htmlNode.Attributes.Contains("name"))
					{
						this.dictionary_2[htmlNode.Attributes["name"].Value] = htmlNode.Attributes["value"].Value;
					}
				}
				this.dictionary_2["displayGroup"] = "card";
				this.dictionary_2["card.cardNumber"] = (string)this.jtoken_0["payment"]["card"]["number"];
				this.dictionary_2["card.cardHolderName"] = this.jtoken_0["billing"]["first_name"] + " " + this.jtoken_0["billing"]["last_name"];
				this.dictionary_2["card.expiryMonth"] = (string)this.jtoken_0["payment"]["card"]["exp_month"];
				this.dictionary_2["card.expiryYear"] = (string)this.jtoken_0["payment"]["card"]["exp_year"];
				this.dictionary_2["card.cvcCode"] = (string)this.jtoken_0["payment"]["card"]["cvv"];
				this.dictionary_2.Remove("back");
			}
			catch
			{
				this.class4_0.method_4("Error going to payment", "#c2c2c2", true, false);
				Thread.Sleep(Settings.Default.retry_delay);
				continue;
			}
			break;
		}
	}

	// Token: 0x06000229 RID: 553 RVA: 0x00013E48 File Offset: 0x00012048
	public void method_6()
	{
		for (;;)
		{
			try
			{
				this.class4_0.method_4("Submitting payment", "orange", true, false);
				HttpResponseMessage httpResponseMessage = this.class70_0.method_7("https://live.barclaycardsmartpay.com/hpp/completeCard.shtml", this.dictionary_2, false);
				string text = httpResponseMessage.Headers.Location.ToString();
				if (text.Contains("3d-redirect"))
				{
					this.class4_0.method_4("Processing payment", "orange", true, false);
					httpResponseMessage = this.class70_0.method_5("https://live.barclaycardsmartpay.com" + text, true);
					HtmlDocument htmlDocument = new HtmlDocument();
					htmlDocument.LoadHtml(httpResponseMessage.smethod_3());
					Dictionary<string, string> dictionary = Class70.smethod_1();
					foreach (HtmlNode htmlNode in ((IEnumerable<HtmlNode>)htmlDocument.DocumentNode.SelectNodes("//form[@id='pageform']//input[@name][@value]")))
					{
						dictionary[htmlNode.Attributes["name"].Value] = htmlNode.Attributes["value"].Value;
					}
					httpResponseMessage = this.class70_0.method_7(htmlDocument.DocumentNode.SelectSingleNode("//form[@id='pageform']").Attributes["action"].Value, dictionary, false);
					if (!httpResponseMessage.smethod_3().Contains("downloadForm"))
					{
						this.class4_0.method_0("Unsupported card (3D Secure)", "red", false);
					}
					htmlDocument.LoadHtml(httpResponseMessage.smethod_3());
					dictionary = Class70.smethod_1();
					foreach (HtmlNode htmlNode2 in ((IEnumerable<HtmlNode>)htmlDocument.DocumentNode.SelectNodes("//form[@name='downloadForm']//input[@name][@value]")))
					{
						dictionary[htmlNode2.Attributes["name"].Value] = htmlNode2.Attributes["value"].Value;
					}
					httpResponseMessage = this.class70_0.method_7(htmlDocument.DocumentNode.SelectSingleNode("//form[@name='downloadForm']").Attributes["action"].Value, dictionary, false);
					text = httpResponseMessage.Headers.Location.ToString();
				}
				if (!text.Contains("authResult=REFUSED") && !text.Contains("authResult=CANCELLED"))
				{
					if (text.Contains("authResult=AUTHORISED"))
					{
						this.class4_0.method_4("Submitting order", "orange", true, false);
						this.class70_0.method_5(text, true);
						this.class4_0.method_9(false);
						this.class4_0.method_0("Successfully checked out", "green", false);
					}
					else
					{
						this.class4_0.method_0("Payment error", "red", false);
					}
				}
				else
				{
					this.class4_0.method_9(true);
					this.class4_0.method_0("Payment Declined", "red", false);
				}
			}
			catch
			{
				this.class4_0.method_4("Error submitting payment", "#c2c2c2", true, false);
				Thread.Sleep(Settings.Default.retry_delay);
				continue;
			}
			break;
		}
	}

	// Token: 0x0600022A RID: 554 RVA: 0x00014194 File Offset: 0x00012394
	private void method_7()
	{
		for (;;)
		{
			try
			{
				this.class4_0.method_4("Getting token", "#c2c2c2", true, false);
				HttpResponseMessage httpResponseMessage_ = this.class70_0.method_5("https://www.footlocker.eu/en/homepage", true);
				HtmlDocument htmlDocument = new HtmlDocument();
				htmlDocument.LoadHtml(httpResponseMessage_.smethod_3());
				this.string_4 = new Uri(htmlDocument.DocumentNode.SelectSingleNode("//a[@class='fl-header--logo']").Attributes["href"].Value).Host;
				this.string_3 = htmlDocument.DocumentNode.SelectSingleNode("//input[@name='SynchronizerToken']").Attributes["value"].Value;
			}
			catch
			{
				this.class4_0.method_4("Error getting token", "#c2c2c2", true, false);
				Thread.Sleep(Settings.Default.retry_delay);
				continue;
			}
			break;
		}
	}

	// Token: 0x04000114 RID: 276
	private Class70 class70_0;

	// Token: 0x04000115 RID: 277
	private Class4 class4_0;

	// Token: 0x04000116 RID: 278
	private JToken jtoken_0;

	// Token: 0x04000117 RID: 279
	private JToken jtoken_1;

	// Token: 0x04000118 RID: 280
	private string string_0;

	// Token: 0x04000119 RID: 281
	private string string_1;

	// Token: 0x0400011A RID: 282
	private string string_2;

	// Token: 0x0400011B RID: 283
	private string string_3;

	// Token: 0x0400011C RID: 284
	private bool bool_0;

	// Token: 0x0400011D RID: 285
	private Dictionary<string, string> dictionary_0 = new Dictionary<string, string>();

	// Token: 0x0400011E RID: 286
	private Dictionary<string, string> dictionary_1 = new Dictionary<string, string>();

	// Token: 0x0400011F RID: 287
	private Dictionary<string, string> dictionary_2 = new Dictionary<string, string>();

	// Token: 0x04000120 RID: 288
	private string string_4;
}
