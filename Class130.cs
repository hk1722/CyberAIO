using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;

// Token: 0x020000ED RID: 237
internal sealed class Class130
{
	// Token: 0x06000601 RID: 1537 RVA: 0x00032C18 File Offset: 0x00030E18
	public Class130(JToken jtoken_2)
	{
		try
		{
			this.jtoken_1 = jtoken_2;
			this.class4_0 = new Class4(jtoken_2);
			this.string_5 = ((string)jtoken_2["keywords"]).Replace(" ", string.Empty).ToLower().Split(new char[]
			{
				','
			}).Where(new Func<string, bool>(Class130.Class131.class131_0.method_0)).ToArray<string>();
			this.string_4 = ((string)jtoken_2["keywords"]).Replace(" ", string.Empty).ToLower().Split(new char[]
			{
				','
			}).Where(new Func<string, bool>(Class130.Class131.class131_0.method_1)).ToArray<string>().Select(new Func<string, string>(Class130.Class131.class131_0.method_2)).ToArray<string>();
			this.string_2 = ((string)jtoken_2["supreme"]["color"]).Replace(" ", string.Empty).Split(new char[]
			{
				','
			});
			this.bool_1 = ((bool)jtoken_2["supreme"]["random"] || jtoken_2["supreme"]["color"].ToString() == "False");
			this.string_1 = (string)jtoken_2["supreme"]["category"];
			if (!this.class4_0.method_3(out this.jtoken_0))
			{
				this.class4_0.method_0("Profile error", "red", true);
			}
			else
			{
				if (!((string)jtoken_2["size"] == "OneSize") && !((string)jtoken_2["size"] == "Random"))
				{
					this.string_9 = (string)jtoken_2["size"];
				}
				else
				{
					this.bool_2 = true;
				}
				this.string_6 = (((string)this.jtoken_0["billing"]["country"] == "United States" || (string)this.jtoken_0["billing"]["country"] == "Canada") ? "US" : "EU");
				this.class70_0 = new Class70(this.class4_0.method_6(), "Mozilla/5.0 (iPhone; CPU iPhone OS 9_1 like Mac OS X) AppleWebKit/601.1.46 (KHTML, like Gecko) Version/9.0 Mobile/13B143 Safari/601.1", 10, false, true, null, false);
			}
		}
		catch
		{
			this.class4_0.method_0("Task error", "red", true);
		}
	}

	// Token: 0x06000602 RID: 1538 RVA: 0x00032F64 File Offset: 0x00031164
	public void method_0()
	{
		try
		{
			this.class4_0.method_8();
			this.method_4();
			this.method_5();
			this.method_6();
			this.method_8();
			this.method_11();
		}
		catch
		{
		}
		finally
		{
			this.class4_0.method_0("Stopped", "red", true);
		}
	}

	// Token: 0x06000603 RID: 1539 RVA: 0x00005E74 File Offset: 0x00004074
	public void method_1()
	{
		this.bool_0 = false;
		this.class70_0 = new Class70(this.class4_0.method_6(), "Mozilla/5.0 (iPhone; CPU iPhone OS 9_1 like Mac OS X) AppleWebKit/601.1.46 (KHTML, like Gecko) Version/9.0 Mobile/13B143 Safari/601.1", 10, false, false, null, false);
		Thread.Sleep(GClass0.int_1);
		this.method_0();
	}

	// Token: 0x06000604 RID: 1540 RVA: 0x00032FD4 File Offset: 0x000311D4
	public string method_2(string string_13)
	{
		foreach (KeyValuePair<string, JToken> keyValuePair in Class168.jobject_1)
		{
			string_13 = string_13.Replace(keyValuePair.Key, keyValuePair.Value.ToString());
		}
		return string_13;
	}

	// Token: 0x06000605 RID: 1541 RVA: 0x00033038 File Offset: 0x00031238
	public string method_3()
	{
		string result;
		try
		{
			result = Class168.jobject_2["products_and_categories"][this.string_1].Select(new Func<JToken, Class18<JToken, string>>(Class130.Class131.class131_0.method_3)).Where(new Func<Class18<JToken, string>, bool>(this.method_12)).Select(new Func<Class18<JToken, string>, string>(Class130.Class131.class131_0.method_4)).FirstOrDefault<string>();
		}
		catch
		{
			result = null;
		}
		return result;
	}

	// Token: 0x06000606 RID: 1542 RVA: 0x000330D8 File Offset: 0x000312D8
	public void method_4()
	{
		this.class4_0.method_4("Looking for product", "#c2c2c2", true, false);
		for (;;)
		{
			try
			{
				foreach (JToken jtoken in ((IEnumerable<JToken>)JObject.Parse(this.method_2(this.class70_0.method_5("http://www.supremenewyork.com/mobile_stock.json", true).smethod_3()))["products_and_categories"][this.string_1]))
				{
					string @object = jtoken["name"].ToString().ToLower().smethod_3();
					if ((this.string_5.All(new Func<string, bool>(@object.Contains)) && !this.string_4.Any(new Func<string, bool>(@object.Contains))) || jtoken["image_url"].ToString() == this.method_3())
					{
						this.string_3 = "http://www.supremenewyork.com/shop/" + jtoken["id"];
						this.class4_0.method_7(jtoken["name"].ToString(), "#c2c2c2");
						this.class4_0.method_4("Found product: " + jtoken["name"], "#c2c2c2", true, false);
						return;
					}
				}
				Thread.Sleep(GClass0.int_0);
			}
			catch (ThreadAbortException)
			{
				break;
			}
			catch
			{
				Thread.Sleep(GClass0.int_0);
			}
		}
	}

	// Token: 0x06000607 RID: 1543 RVA: 0x00033298 File Offset: 0x00031498
	public void method_5()
	{
		this.class4_0.method_4("Collecting product data", "#c2c2c2", true, false);
		for (;;)
		{
			try
			{
				JToken source = this.class70_0.method_5(this.string_3 + ".json", true).smethod_0()["styles"];
				JToken jtoken;
				if (this.bool_1)
				{
					jtoken = source.Where(new Func<JToken, bool>(Class130.Class131.class131_0.method_5)).smethod_2();
					if (jtoken == null)
					{
						goto IL_226;
					}
					this.class4_0.string_0 = jtoken["name"].ToString();
					this.class4_0.string_1 = jtoken["image_url_hi"].ToString();
				}
				else
				{
					jtoken = source.FirstOrDefault(new Func<JToken, bool>(this.method_13));
					if (jtoken == null)
					{
						this.class4_0.method_0("Color unavailable", "red", false);
					}
					this.class4_0.string_0 = jtoken["name"].ToString();
					this.class4_0.string_1 = jtoken["image_url_hi"].ToString();
				}
				if (this.bool_2)
				{
					JToken jtoken2 = jtoken["sizes"].Where(new Func<JToken, bool>(Class130.Class131.class131_0.method_7)).smethod_2();
					if (jtoken2 != null)
					{
						this.string_10 = jtoken2["id"].ToString();
						this.string_11 = jtoken["id"].ToString();
						this.class4_0.method_5(jtoken2["name"].ToString());
						break;
					}
				}
				else
				{
					JToken jtoken3 = jtoken["sizes"].FirstOrDefault(new Func<JToken, bool>(this.method_14));
					if (jtoken3 == null)
					{
						this.class4_0.method_0("Size unavailable", "red", false);
					}
					else if ((int)jtoken3["stock_level"] > 0)
					{
						this.string_10 = jtoken3["id"].ToString();
						this.string_11 = jtoken["id"].ToString();
						break;
					}
				}
				IL_226:
				this.class4_0.method_4("Waiting for restock", "#c2c2c2", true, false);
				Thread.Sleep(GClass0.int_0);
			}
			catch (ThreadAbortException)
			{
				break;
			}
			catch
			{
				this.class4_0.method_4("Error collecting data", "#c2c2c2", true, false);
				Thread.Sleep(GClass0.int_1);
				this.class4_0.method_4("Collecting product data", "#c2c2c2", true, false);
			}
		}
	}

	// Token: 0x06000608 RID: 1544 RVA: 0x00033568 File Offset: 0x00031768
	public void method_6()
	{
		this.class4_0.method_4("Adding to cart", "#c2c2c2", true, false);
		for (;;)
		{
			try
			{
				Dictionary<string, string> dictionary = Class70.smethod_1();
				dictionary["style"] = this.string_11;
				dictionary["size"] = this.string_10;
				dictionary["st"] = this.string_11;
				dictionary["s"] = this.string_10;
				JArray jarray = this.class70_0.method_7(this.string_3 + "/add.json", dictionary, false).smethod_2();
				if (jarray.Count != 0 && (bool)jarray[0]["in_stock"])
				{
					if ((bool)jarray[0]["in_stock"])
					{
						this.class4_0.method_4("Successfully carted", "#c2c2c2", true, false);
						this.stopwatch_0.Restart();
						break;
					}
					throw new Exception();
				}
				else
				{
					this.class4_0.method_4("Waiting for restock", "#c2c2c2", true, false);
					Thread.Sleep(GClass0.int_0);
				}
			}
			catch (ThreadAbortException)
			{
				break;
			}
			catch
			{
				this.class4_0.method_4("Error adding to cart", "#c2c2c2", true, false);
				Thread.Sleep(GClass0.int_1);
				this.class4_0.method_4("Adding to cart", "#c2c2c2", true, false);
			}
		}
	}

	// Token: 0x06000609 RID: 1545 RVA: 0x000336E4 File Offset: 0x000318E4
	public void method_7()
	{
		Class130.Class133 @class = new Class130.Class133();
		@class.class130_0 = this;
		this.class4_0.method_4("Setting cookies", "#c2c2c2", true, false);
		@class.dictionary_0 = this.class70_0.cookieContainer_0.GetCookies(new Uri("http://www.supremenewyork.com")).Cast<Cookie>().ToDictionary(new Func<Cookie, string>(Class130.Class131.class131_0.method_8), new Func<Cookie, string>(Class130.Class131.class131_0.method_9));
		((this.string_6 == "EU") ? Class168.jarray_0 : Class168.jarray_1).Where(new Func<JToken, bool>(@class.method_0)).ToList<JToken>().ForEach(new Action<JToken>(@class.method_1));
	}

	// Token: 0x0600060A RID: 1546 RVA: 0x000337C4 File Offset: 0x000319C4
	public void method_8()
	{
		this.dictionary_0["order[billing_name]"] = (string)this.jtoken_0["billing"]["first_name"] + " " + (string)this.jtoken_0["billing"]["last_name"];
		this.dictionary_0["order[email]"] = (string)this.jtoken_0["payment"]["email"];
		this.dictionary_0["order[tel]"] = (string)this.jtoken_0["payment"]["phone"];
		this.dictionary_0["order[billing_address]"] = (string)this.jtoken_0["billing"]["addr1"];
		this.dictionary_0["order[billing_address_2]"] = (string)this.jtoken_0["billing"]["addr2"];
		this.dictionary_0["order[billing_city]"] = (string)this.jtoken_0["billing"]["city"];
		this.dictionary_0["order[billing_zip]"] = (string)this.jtoken_0["billing"]["zip"];
		this.dictionary_0["order[billing_country]"] = Class167.smethod_0((string)this.jtoken_0["billing"]["country"], true);
		this.dictionary_0["order[billing_state]"] = Class167.smethod_1((string)this.jtoken_0["billing"]["country"], (string)this.jtoken_0["billing"]["state"]);
		this.dictionary_0["order[terms]"] = "1";
		this.dictionary_0[(this.string_6 == "EU") ? "credit_card[cnb]" : "credit_card[nlb]"] = ((string)this.jtoken_0["payment"]["card"]["number"]).Replace(" ", string.Empty);
		this.dictionary_0["credit_card[month]"] = (string)this.jtoken_0["payment"]["card"]["exp_month"];
		this.dictionary_0["credit_card[year]"] = (string)this.jtoken_0["payment"]["card"]["exp_year"];
		this.dictionary_0[(this.string_6 == "EU") ? "credit_card[vval]" : "credit_card[rvv]"] = (string)this.jtoken_0["payment"]["card"]["cvv"];
	}

	// Token: 0x0600060B RID: 1547 RVA: 0x00033B08 File Offset: 0x00031D08
	public void method_9()
	{
		this.class4_0.method_4("Building checkout form", "#c2c2c2", true, false);
		for (;;)
		{
			try
			{
				HttpResponseMessage httpResponseMessage = this.class70_0.method_5("https://www.supremenewyork.com/checkout", false);
				if (httpResponseMessage.StatusCode == HttpStatusCode.Found)
				{
					this.class4_0.method_4("Waiting for restock", "#c2c2c2", true, false);
					this.method_1();
					break;
				}
				httpResponseMessage.EnsureSuccessStatusCode();
				HtmlDocument htmlDocument = new HtmlDocument();
				htmlDocument.LoadHtml(httpResponseMessage.smethod_3());
				this.dictionary_0 = Class70.smethod_1();
				foreach (HtmlNode htmlNode in ((IEnumerable<HtmlNode>)htmlDocument.DocumentNode.SelectNodes("//form//input")))
				{
					this.dictionary_0[htmlNode.Attributes["name"].Value] = (htmlNode.Attributes.Contains("value") ? htmlNode.Attributes["value"].Value : string.Empty);
				}
				if (this.string_6 == "EU")
				{
					HtmlNodeCollection htmlNodeCollection = htmlDocument.DocumentNode.SelectNodes("//form//input");
					HtmlNodeCollection htmlNodeCollection2 = htmlDocument.DocumentNode.SelectNodes("//form//select");
					this.dictionary_0[htmlNodeCollection[2].Attributes["name"].Value] = (string)this.jtoken_0["billing"]["first_name"] + " " + (string)this.jtoken_0["billing"]["last_name"];
					this.dictionary_0[htmlNodeCollection[3].Attributes["name"].Value] = (string)this.jtoken_0["payment"]["email"];
					this.dictionary_0[htmlNodeCollection[4].Attributes["name"].Value] = (string)this.jtoken_0["payment"]["phone"];
					this.dictionary_0[htmlNodeCollection[5].Attributes["name"].Value] = (string)this.jtoken_0["billing"]["addr1"];
					this.dictionary_0[htmlNodeCollection[6].Attributes["name"].Value] = (string)this.jtoken_0["billing"]["addr2"];
					this.dictionary_0[htmlNodeCollection[8].Attributes["name"].Value] = (string)this.jtoken_0["billing"]["city"];
					this.dictionary_0[htmlNodeCollection[9].Attributes["name"].Value] = (string)this.jtoken_0["billing"]["zip"];
					this.dictionary_0[htmlNodeCollection2[0].Attributes["name"].Value] = Class167.smethod_0((string)this.jtoken_0["billing"]["country"], true);
					this.dictionary_0[htmlNodeCollection[10].Attributes["name"].Value] = htmlNodeCollection[10].Attributes["value"].Value;
					this.dictionary_0[htmlNodeCollection[13].Attributes["name"].Value] = ((string)this.jtoken_0["payment"]["card"]["number"]).Replace(" ", string.Empty);
					this.dictionary_0[htmlNodeCollection2[2].Attributes["name"].Value] = (string)this.jtoken_0["payment"]["card"]["exp_month"];
					this.dictionary_0[htmlNodeCollection2[3].Attributes["name"].Value] = (string)this.jtoken_0["payment"]["card"]["exp_year"];
					this.dictionary_0[htmlNodeCollection[14].Attributes["name"].Value] = (string)this.jtoken_0["payment"]["card"]["cvv"];
					this.dictionary_0[htmlNodeCollection[15].Attributes["name"].Value] = "1";
				}
				else
				{
					this.dictionary_0[htmlDocument.DocumentNode.SelectNodes("//form//input[@type='text']")[0].Attributes["name"].Value] = (string)this.jtoken_0["billing"]["first_name"] + " " + (string)this.jtoken_0["billing"]["last_name"];
					this.dictionary_0[htmlDocument.DocumentNode.SelectNodes("//form//input[@type='email']")[0].Attributes["name"].Value] = (string)this.jtoken_0["payment"]["email"];
					this.dictionary_0[htmlDocument.DocumentNode.SelectNodes("//form//input[@type='text']")[1].Attributes["name"].Value] = (string)this.jtoken_0["payment"]["phone"];
					this.dictionary_0[htmlDocument.DocumentNode.SelectNodes("//form//input[@type='text']")[2].Attributes["name"].Value] = (string)this.jtoken_0["billing"]["addr1"];
					this.dictionary_0[htmlDocument.DocumentNode.SelectNodes("//form//input[@type='text']")[3].Attributes["name"].Value] = (string)this.jtoken_0["billing"]["addr2"];
					this.dictionary_0[htmlDocument.DocumentNode.SelectNodes("//form//input[@type='text']")[5].Attributes["name"].Value] = (string)this.jtoken_0["billing"]["city"];
					this.dictionary_0[htmlDocument.DocumentNode.SelectNodes("//form//input[@type='text']")[4].Attributes["name"].Value] = (string)this.jtoken_0["billing"]["zip"];
					this.dictionary_0[htmlDocument.DocumentNode.SelectNodes("//form//select")[0].Attributes["name"].Value] = Class167.smethod_1((string)this.jtoken_0["billing"]["country"], (string)this.jtoken_0["billing"]["state"]);
					this.dictionary_0[htmlDocument.DocumentNode.SelectNodes("//form//select")[1].Attributes["name"].Value] = Class167.smethod_0((string)this.jtoken_0["billing"]["country"], true);
					this.dictionary_0[htmlDocument.DocumentNode.SelectNodes("//form//input[@type='text']")[6].Attributes["name"].Value] = ((string)this.jtoken_0["payment"]["card"]["number"]).Replace(" ", string.Empty);
					this.dictionary_0[htmlDocument.DocumentNode.SelectNodes("//form//select")[2].Attributes["name"].Value] = (string)this.jtoken_0["payment"]["card"]["exp_month"];
					this.dictionary_0[htmlDocument.DocumentNode.SelectNodes("//form//select")[3].Attributes["name"].Value] = (string)this.jtoken_0["payment"]["card"]["exp_year"];
					this.dictionary_0[htmlDocument.DocumentNode.SelectNodes("//form//input[@type='text']")[7].Attributes["name"].Value] = (string)this.jtoken_0["payment"]["card"]["cvv"];
				}
				this.dictionary_0["order[terms]"] = "1";
				break;
			}
			catch (ThreadAbortException)
			{
				break;
			}
			catch
			{
				this.class4_0.method_4("Error loading checkout", "#c2c2c2", true, false);
				Thread.Sleep(GClass0.int_1);
			}
		}
	}

	// Token: 0x0600060C RID: 1548 RVA: 0x000345D0 File Offset: 0x000327D0
	public bool method_10()
	{
		if (this.stopwatch_0.ElapsedMilliseconds <= 115000L && this.dictionary_0.ContainsKey("g-recaptcha-response") && !this.bool_0)
		{
			return false;
		}
		this.stopwatch_0.Reset();
		this.class4_0.method_4("Waiting for captcha token", "turquoise", true, false);
		this.string_0 = CaptchaQueue_V1.smethod_1(this.string_8, "https://www.supremenewyork.com/checkout", (string)this.jtoken_1["id"]).Result;
		this.stopwatch_0.Start();
		this.dictionary_0["g-recaptcha-response"] = this.string_0;
		return true;
	}

	// Token: 0x0600060D RID: 1549 RVA: 0x00034684 File Offset: 0x00032884
	public void method_11()
	{
		CookieCollection cookies = this.class70_0.cookieContainer_0.GetCookies(new Uri("https://www.supremenewyork.com"));
		for (;;)
		{
			bool flag = false;
			try
			{
				this.method_7();
				if ((this.string_6 == "US" && !Class168.bool_0) || (this.string_6 == "EU" && !Class168.bool_1))
				{
					this.method_10();
				}
				this.class4_0.method_4("Checking out...", "orange", true, false);
				HttpResponseMessage httpResponseMessage = this.class70_0.method_7("https://www.supremenewyork.com/checkout.json", this.dictionary_0, false);
				httpResponseMessage.EnsureSuccessStatusCode();
				JObject jobject = httpResponseMessage.smethod_0();
				if (jobject["status"].ToString() == "queued")
				{
					flag = true;
					this.class4_0.method_4("Processing payment...", "orange", true, false);
					string arg = jobject["slug"].ToString();
					httpResponseMessage = this.class70_0.method_5(string.Format("https://www.supremenewyork.com/checkout/{0}/status.json", arg), true);
					while (httpResponseMessage.smethod_0()["status"].ToString() == "queued")
					{
						Thread.Sleep(300);
						httpResponseMessage = this.class70_0.method_5(string.Format("https://www.supremenewyork.com/checkout/{0}/status.json", arg), true);
					}
					jobject = httpResponseMessage.smethod_0();
				}
				if (jobject["status"].ToString() == "paid")
				{
					this.class4_0.method_9(false);
					this.class4_0.method_0("Successfully checked out", "green", false);
					break;
				}
				if (jobject["status"].ToString() == "dup")
				{
					this.class4_0.method_0("Billing used", "red", false);
				}
				else
				{
					if (jobject["status"].ToString() == "outOfStock")
					{
						this.class4_0.method_4("Waiting for restock", "#c2c2c2", true, false);
						this.method_1();
						break;
					}
					if (jobject["status"].ToString() == "failed" && jobject.ContainsKey("avs"))
					{
						this.class4_0.method_0("Invalid billing", "red", false);
					}
					else if (jobject["status"].ToString() == "failed" && jobject.ContainsKey("cvv"))
					{
						this.class4_0.method_0("Invalid CVV", "red", false);
					}
					else if (!(jobject["status"].ToString() == "blocked_country") && !(jobject["status"].ToString() == "canada") && !jobject.ToString().Contains("country is required"))
					{
						if (flag)
						{
							this.class4_0.method_9(true);
							this.class4_0.method_0("Card declined", "red", false);
						}
						else
						{
							this.class4_0.method_4("Card Declined (Violation), retrying", "red", true, false);
							if (!this.method_10() || this.bool_0)
							{
								Thread.Sleep(GClass0.int_1);
							}
							if (httpResponseMessage.StatusCode != HttpStatusCode.Found)
							{
								this.class70_0.cookieContainer_0.Add(cookies);
							}
							else
							{
								this.method_1();
							}
						}
					}
					else
					{
						this.class4_0.method_0("Unsupported country", "red", false);
					}
				}
			}
			catch (ThreadAbortException)
			{
				break;
			}
			catch
			{
				this.class4_0.method_4("Error checking out", "#c2c2c2", true, false);
				Thread.Sleep(GClass0.int_1);
			}
		}
	}

	// Token: 0x0600060E RID: 1550 RVA: 0x00034A6C File Offset: 0x00032C6C
	private bool method_12(Class18<JToken, string> class18_0)
	{
		return this.string_5.All(new Func<string, bool>(class18_0.method_1().Contains)) && !this.string_4.Any(new Func<string, bool>(class18_0.method_1().Contains));
	}

	// Token: 0x0600060F RID: 1551 RVA: 0x00034AB8 File Offset: 0x00032CB8
	private bool method_13(JToken jtoken_2)
	{
		Class130.Class132 @class = new Class130.Class132();
		@class.jtoken_0 = jtoken_2;
		return this.string_2.Any(new Func<string, bool>(@class.method_0)) || this.string_2.Any(new Func<string, bool>(@class.jtoken_0["image_url"].ToString().Contains));
	}

	// Token: 0x06000610 RID: 1552 RVA: 0x00005EAE File Offset: 0x000040AE
	private bool method_14(JToken jtoken_2)
	{
		return Class167.smethod_2(this.string_9, jtoken_2["name"].ToString().smethod_3().ToLower());
	}

	// Token: 0x0400030B RID: 779
	private readonly Class4 class4_0;

	// Token: 0x0400030C RID: 780
	private readonly Stopwatch stopwatch_0 = new Stopwatch();

	// Token: 0x0400030D RID: 781
	private string string_0;

	// Token: 0x0400030E RID: 782
	private readonly string string_1;

	// Token: 0x0400030F RID: 783
	private Dictionary<string, string> dictionary_0 = new Dictionary<string, string>();

	// Token: 0x04000310 RID: 784
	private Class70 class70_0;

	// Token: 0x04000311 RID: 785
	private readonly string[] string_2;

	// Token: 0x04000312 RID: 786
	private string string_3;

	// Token: 0x04000313 RID: 787
	private readonly string[] string_4;

	// Token: 0x04000314 RID: 788
	private bool bool_0 = Licenser.string_0 == "Sole Solution";

	// Token: 0x04000315 RID: 789
	private readonly string[] string_5;

	// Token: 0x04000316 RID: 790
	private readonly JToken jtoken_0;

	// Token: 0x04000317 RID: 791
	private readonly bool bool_1;

	// Token: 0x04000318 RID: 792
	private readonly bool bool_2;

	// Token: 0x04000319 RID: 793
	private readonly string string_6 = "EU";

	// Token: 0x0400031A RID: 794
	private string string_7;

	// Token: 0x0400031B RID: 795
	private readonly string string_8 = "6LeWwRkUAAAAAOBsau7KpuC9AV-6J8mhw4AjC3Xz";

	// Token: 0x0400031C RID: 796
	private readonly string string_9;

	// Token: 0x0400031D RID: 797
	private string string_10;

	// Token: 0x0400031E RID: 798
	private string string_11;

	// Token: 0x0400031F RID: 799
	private readonly JToken jtoken_1;

	// Token: 0x04000320 RID: 800
	private string string_12;

	// Token: 0x020000EE RID: 238
	[Serializable]
	private sealed class Class131
	{
		// Token: 0x06000613 RID: 1555 RVA: 0x00005EE1 File Offset: 0x000040E1
		internal bool method_0(string string_0)
		{
			return string_0[0] != '-';
		}

		// Token: 0x06000614 RID: 1556 RVA: 0x00005EF1 File Offset: 0x000040F1
		internal bool method_1(string string_0)
		{
			return string_0[0] == '-';
		}

		// Token: 0x06000615 RID: 1557 RVA: 0x00005EFE File Offset: 0x000040FE
		internal string method_2(string string_0)
		{
			return string_0.Replace("-", string.Empty);
		}

		// Token: 0x06000616 RID: 1558 RVA: 0x00005F10 File Offset: 0x00004110
		internal Class18<JToken, string> method_3(JToken jtoken_0)
		{
			return new Class18<JToken, string>(jtoken_0, Regex.Replace(jtoken_0["name"].ToString().ToLower(), "[^\\u0000-\\u007F]+", string.Empty));
		}

		// Token: 0x06000617 RID: 1559 RVA: 0x00005F3C File Offset: 0x0000413C
		internal string method_4(Class18<JToken, string> class18_0)
		{
			return class18_0.method_0()["image_url"].ToString();
		}

		// Token: 0x06000618 RID: 1560 RVA: 0x00005F53 File Offset: 0x00004153
		internal bool method_5(JToken jtoken_0)
		{
			return jtoken_0["sizes"].Where(new Func<JToken, bool>(Class130.Class131.class131_0.method_6)).ToArray<JToken>().Length != 0;
		}

		// Token: 0x06000619 RID: 1561 RVA: 0x00005F8D File Offset: 0x0000418D
		internal bool method_6(JToken jtoken_0)
		{
			return (int)jtoken_0["stock_level"] > 0;
		}

		// Token: 0x0600061A RID: 1562 RVA: 0x00005F8D File Offset: 0x0000418D
		internal bool method_7(JToken jtoken_0)
		{
			return (int)jtoken_0["stock_level"] > 0;
		}

		// Token: 0x0600061B RID: 1563 RVA: 0x00005FA2 File Offset: 0x000041A2
		internal string method_8(Cookie cookie_0)
		{
			return cookie_0.Name;
		}

		// Token: 0x0600061C RID: 1564 RVA: 0x00005FAA File Offset: 0x000041AA
		internal string method_9(Cookie cookie_0)
		{
			return cookie_0.Value;
		}

		// Token: 0x04000321 RID: 801
		public static readonly Class130.Class131 class131_0 = new Class130.Class131();

		// Token: 0x04000322 RID: 802
		public static Func<string, bool> func_0;

		// Token: 0x04000323 RID: 803
		public static Func<string, bool> func_1;

		// Token: 0x04000324 RID: 804
		public static Func<string, string> func_2;

		// Token: 0x04000325 RID: 805
		public static Func<JToken, Class18<JToken, string>> func_3;

		// Token: 0x04000326 RID: 806
		public static Func<Class18<JToken, string>, string> func_4;

		// Token: 0x04000327 RID: 807
		public static Func<JToken, bool> func_5;

		// Token: 0x04000328 RID: 808
		public static Func<JToken, bool> func_6;

		// Token: 0x04000329 RID: 809
		public static Func<JToken, bool> func_7;

		// Token: 0x0400032A RID: 810
		public static Func<Cookie, string> func_8;

		// Token: 0x0400032B RID: 811
		public static Func<Cookie, string> func_9;
	}

	// Token: 0x020000EF RID: 239
	private sealed class Class132
	{
		// Token: 0x0600061E RID: 1566 RVA: 0x00034B18 File Offset: 0x00032D18
		internal bool method_0(string string_0)
		{
			return string_0.ToLower().Split(new char[]
			{
				'+'
			}).All(new Func<string, bool>(this.jtoken_0["name"].ToString().ToLower().smethod_3().Contains));
		}

		// Token: 0x0400032C RID: 812
		public JToken jtoken_0;
	}

	// Token: 0x020000F0 RID: 240
	private sealed class Class133
	{
		// Token: 0x06000620 RID: 1568 RVA: 0x00005FB2 File Offset: 0x000041B2
		internal bool method_0(JToken jtoken_0)
		{
			return !this.dictionary_0.ContainsKey(jtoken_0["name"].ToString()) || jtoken_0["name"].ToString().Contains("pooky");
		}

		// Token: 0x06000621 RID: 1569 RVA: 0x00034B6C File Offset: 0x00032D6C
		internal void method_1(JToken jtoken_0)
		{
			this.class130_0.class70_0.cookieContainer_0.Add(new Uri("https://www.supremenewyork.com/"), new Cookie((string)jtoken_0["name"], (string)jtoken_0["value"], "/"));
		}

		// Token: 0x0400032D RID: 813
		public Dictionary<string, string> dictionary_0;

		// Token: 0x0400032E RID: 814
		public Class130 class130_0;
	}
}
