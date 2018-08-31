using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;

// Token: 0x020000C2 RID: 194
internal sealed class Class103
{
	// Token: 0x06000510 RID: 1296 RVA: 0x00028F80 File Offset: 0x00027180
	public Class103(JToken jtoken_2, string string_12)
	{
		try
		{
			this.jtoken_1 = jtoken_2;
			this.class4_0 = new Class4(jtoken_2);
			this.string_0 = (string)jtoken_2["keywords"];
			this.string_2 = string_12;
			if (!((string)jtoken_2["size"] == "Random") && !((string)jtoken_2["size"] == "OneSize"))
			{
				this.string_3 = (string)jtoken_2["size"];
			}
			else
			{
				this.string_3 = GClass2.smethod_1();
				this.class4_0.method_5(this.string_3);
			}
			this.string_3 = Class167.smethod_4(this.string_3);
			if (!this.string_3.Contains(".5") && this.string_3.Replace(".", string.Empty).smethod_0())
			{
				this.string_3 += ".0";
			}
			if (this.string_3.Length == 3)
			{
				this.string_3 = "0" + this.string_3;
			}
			if (!this.class4_0.method_3(out this.jtoken_0))
			{
				this.class4_0.method_0("Profile error", "red", true);
			}
			else
			{
				this.string_10 = this.class4_0.method_6();
				this.class70_0 = new Class70(this.string_10, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.181 Safari/537.36", 10, false, false, null, false);
				this.class70_0.httpClient_0.DefaultRequestHeaders.TryAddWithoutValidation("Origin", string.Format("https://www.{0}", string_12));
				this.class70_0.httpClient_0.DefaultRequestHeaders.TryAddWithoutValidation("Referer", string.Format("https://www.{0}", string_12));
				this.class70_0.httpClient_0.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "*/*");
				this.class70_0.httpClient_0.DefaultRequestHeaders.TryAddWithoutValidation("Connection", "keep-alive");
				this.class70_0.httpClient_0.DefaultRequestHeaders.ExpectContinue = new bool?(false);
				this.string_11 = Class103.smethod_0(32);
			}
		}
		catch
		{
			this.class4_0.method_0("Task error", "red", true);
		}
	}

	// Token: 0x06000511 RID: 1297 RVA: 0x000291F0 File Offset: 0x000273F0
	public void method_0()
	{
		try
		{
			this.class4_0.method_8();
			this.method_8();
			this.class4_0.method_13(this.int_0, "Waiting ", 0);
			this.method_9();
			this.method_10();
			this.method_11();
			this.method_12();
			this.method_13();
			this.method_15();
		}
		catch
		{
		}
		finally
		{
			this.class4_0.method_0("Stopped", "red", true);
		}
	}

	// Token: 0x06000512 RID: 1298 RVA: 0x000055F3 File Offset: 0x000037F3
	public void method_1()
	{
		this.method_9();
		this.method_10();
		this.method_11();
		this.method_12();
		this.method_13();
		this.method_14();
		this.method_15();
	}

	// Token: 0x06000513 RID: 1299 RVA: 0x0000561F File Offset: 0x0000381F
	public static string smethod_0(int int_1)
	{
		return new string(Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", int_1).Select(new Func<string, char>(Class103.Class104.class104_0.method_0)).ToArray<char>());
	}

	// Token: 0x06000514 RID: 1300 RVA: 0x00029284 File Offset: 0x00027484
	public string method_2(string string_12)
	{
		switch (string_12[0])
		{
		case '3':
			return "amex";
		case '4':
			return "visa";
		case '5':
			return "mc";
		default:
			return "mc";
		}
	}

	// Token: 0x06000515 RID: 1301 RVA: 0x000292C8 File Offset: 0x000274C8
	public bool method_3(HttpResponseMessage httpResponseMessage_0)
	{
		if (httpResponseMessage_0.smethod_3().Contains("CART_WAIT"))
		{
			this.method_10();
			return true;
		}
		if (httpResponseMessage_0.StatusCode == HttpStatusCode.Found && httpResponseMessage_0.Headers.Location.ToString() == "https://www.footlocker.eu/")
		{
			this.class4_0.method_0("US proxy required", "red", false);
			return false;
		}
		if (httpResponseMessage_0.smethod_3().Contains("SESSION_EXPIRED"))
		{
			Thread.Sleep(1000);
			if (this.cookieCollection_0 != null)
			{
				this.class70_0.cookieContainer_0.Add(this.cookieCollection_0);
			}
			return true;
		}
		if (httpResponseMessage_0.smethod_3().Contains("CART_EMPTY"))
		{
			this.method_1();
			return true;
		}
		if (httpResponseMessage_0.StatusCode == HttpStatusCode.Forbidden)
		{
			this.class4_0.method_4("Banned, retrying", "red", true, false);
			Thread.Sleep(GClass0.int_1);
			return true;
		}
		return false;
	}

	// Token: 0x06000516 RID: 1302 RVA: 0x000293B8 File Offset: 0x000275B8
	public void method_4()
	{
		this.class4_0.method_4("Getting request key", "#c2c2c2", true, false);
		Cookie cookie = new Cookie("requestKey", string.Empty);
		cookie.Expired = true;
		this.class70_0.cookieContainer_0.Add(new Uri(string.Format("https://www.{0}/", this.string_2)), cookie);
		for (;;)
		{
			try
			{
				this.class4_0.method_4("Getting request key", "#c2c2c2", true, false);
				this.string_4 = this.class70_0.method_5(string.Format("https://www.{0}/session/", this.string_2), true).smethod_0()["data"]["RequestKey"].ToString();
				break;
			}
			catch (ThreadAbortException)
			{
				break;
			}
			catch
			{
				this.class4_0.method_4("Error getting request key", "#c2c2c2", true, false);
				Thread.Sleep(GClass0.int_1);
			}
		}
	}

	// Token: 0x06000517 RID: 1303 RVA: 0x000294C0 File Offset: 0x000276C0
	public void method_5()
	{
		for (;;)
		{
			try
			{
				this.class4_0.method_4("Getting request key", "#c2c2c2", true, false);
				HttpResponseMessage httpResponseMessage_ = new Class70(null, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.181 Safari/537.36", 10, false, false, null, false).method_5(this.string_0, true);
				HtmlDocument htmlDocument = new HtmlDocument();
				htmlDocument.LoadHtml(httpResponseMessage_.smethod_3());
				if (htmlDocument.DocumentNode.SelectSingleNode("//input[@id='requestKey']") != null)
				{
					this.string_4 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='requestKey']").Attributes["value"].Value;
				}
				Console.WriteLine(this.string_4);
			}
			catch (ThreadAbortException)
			{
			}
			catch
			{
				this.class4_0.method_4("Error getting request key", "#c2c2c2", true, false);
				Thread.Sleep(GClass0.int_1);
				continue;
			}
			break;
		}
	}

	// Token: 0x06000518 RID: 1304 RVA: 0x000295A4 File Offset: 0x000277A4
	public void method_6()
	{
		for (;;)
		{
			try
			{
			}
			catch (ThreadAbortException)
			{
			}
			catch
			{
				this.class4_0.method_4("Error getting cookies", "#c2c2c2", true, false);
				Thread.Sleep(GClass0.int_1);
				continue;
			}
			break;
		}
	}

	// Token: 0x06000519 RID: 1305 RVA: 0x000295F8 File Offset: 0x000277F8
	public void method_7()
	{
		if ((string)this.jtoken_1["size"] == "Random")
		{
			this.string_3 = GClass2.smethod_1();
			this.class4_0.method_5(this.string_3);
			if (!this.string_3.Contains(".5"))
			{
				this.string_3 += ".0";
			}
			if (this.string_3.Length == 3)
			{
				this.string_3 = "0" + this.string_3;
			}
		}
	}

	// Token: 0x0600051A RID: 1306 RVA: 0x00029690 File Offset: 0x00027890
	public void method_8()
	{
		HtmlDocument htmlDocument = new HtmlDocument();
		for (;;)
		{
			try
			{
				this.class4_0.method_4("Collecting data", "#c2c2c2", true, false);
				HttpResponseMessage httpResponseMessage = this.class70_0.method_5(this.string_0, false);
				if (!this.method_3(httpResponseMessage))
				{
					httpResponseMessage.EnsureSuccessStatusCode();
					htmlDocument.LoadHtml(httpResponseMessage.smethod_3());
					this.string_4 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='requestKey']").Attributes["value"].Value;
					this.string_1 = htmlDocument.DocumentNode.SelectSingleNode("//input[@name='sku']").Attributes["value"].Value;
					if (!this.string_0.Contains(this.string_1))
					{
						this.class4_0.method_0("Product pulled", "red", false);
					}
					if (httpResponseMessage.smethod_3().Contains("var cm_isLaunchSku = 'Y';") && this.string_2 != "footaction.com")
					{
						this.int_0 = Convert.ToInt32(httpResponseMessage.smethod_3().Split(new string[]
						{
							"var productLaunchTimeUntil = "
						}, StringSplitOptions.None)[1].Split(new char[]
						{
							';'
						})[0]) - 1;
					}
					else if (this.string_2 == "footaction.com" && !httpResponseMessage.smethod_3().Contains("id=\"addToWishlist\""))
					{
						this.int_0 = Convert.ToInt32(httpResponseMessage.smethod_3().Split(new string[]
						{
							"var timeToHL = "
						}, StringSplitOptions.None)[1].Split(new char[]
						{
							';'
						})[0]) - 1;
					}
					break;
				}
			}
			catch (ThreadAbortException)
			{
				return;
			}
			catch
			{
				this.class4_0.method_4("Error collecting data", "#c2c2c2", true, false);
				Thread.Sleep(GClass0.int_1);
			}
		}
		try
		{
			if (!(this.string_2 == "champssports.com") && !(this.string_2 == "footlocker.ca"))
			{
				this.class4_0.method_7(htmlDocument.DocumentNode.SelectSingleNode("//input[@id='model_name']").Attributes["value"].Value, "#c2c2c2");
			}
			else
			{
				this.class4_0.method_7(htmlDocument.DocumentNode.SelectSingleNode("//*[@id='model_name']").InnerText, "#c2c2c2");
			}
			return;
		}
		catch (ThreadAbortException)
		{
		}
		catch
		{
			return;
		}
	}

	// Token: 0x0600051B RID: 1307 RVA: 0x00029950 File Offset: 0x00027B50
	public void method_9()
	{
		int num = 1;
		this.class4_0.method_4("Adding to cart", "#c2c2c2", true, false);
		Dictionary<string, string> dictionary = Class70.smethod_1();
		dictionary["storeCostOfGoods"] = "0.00";
		dictionary["requestKey"] = this.string_4;
		dictionary["sku"] = this.string_1;
		dictionary["qty"] = "1";
		dictionary["size"] = this.string_3;
		dictionary["quantity"] = "1";
		dictionary["inlineAddToCart"] = "1";
		for (;;)
		{
			try
			{
				if (num == 1)
				{
					HttpResponseMessage httpResponseMessage = this.class70_0.method_7(string.Format("https://www.{0}/index.cfm?uri=add2cart&fragment=true", this.string_2), dictionary, false);
					if (this.method_3(httpResponseMessage))
					{
						continue;
					}
					httpResponseMessage.EnsureSuccessStatusCode();
					if (httpResponseMessage.smethod_3().ToLower().Contains("out of stock") || httpResponseMessage.smethod_3().Contains("Due to high demand"))
					{
						this.class4_0.method_4("Waiting for restock", "#c2c2c2", true, false);
						Thread.Sleep(GClass0.int_0);
						this.method_7();
						num++;
						continue;
					}
					if ((bool)httpResponseMessage.smethod_0()["success"])
					{
						this.string_4 = httpResponseMessage.smethod_0()["nextRequestKey"].ToString();
						this.class4_0.method_4("Successfully carted", "#c2c2c2", true, false);
						break;
					}
				}
				else if (num == 2)
				{
					HttpResponseMessage httpResponseMessage = this.class70_0.method_5(string.Format("https://www.{0}/pdp/gateway?requestKey={1}&action=add&qty=1&quantity=1&sku={2}&size={3}&fulfillmentType=SHIP_TO_HOME&storeNumber=0&_=1509399855629", new object[]
					{
						this.string_2,
						this.string_4,
						this.string_1,
						this.string_3
					}), true);
					if (this.method_3(httpResponseMessage))
					{
						continue;
					}
					httpResponseMessage.EnsureSuccessStatusCode();
					if (httpResponseMessage.smethod_3().Contains("Item Out Of Stock") || httpResponseMessage.smethod_3().Contains("Due to high demand"))
					{
						this.class4_0.method_4("Waiting for restock", "#c2c2c2", true, false);
						Thread.Sleep(GClass0.int_0);
						this.method_7();
						num++;
						continue;
					}
					if ((bool)httpResponseMessage.smethod_0()["success"])
					{
						this.string_4 = httpResponseMessage.smethod_0()["data"]["RequestKey"].ToString();
						this.class4_0.method_4("Successfully carted", "#c2c2c2", true, false);
						break;
					}
				}
				else
				{
					if (num != 3)
					{
						num = 1;
						continue;
					}
					HttpResponseMessage httpResponseMessage = this.class70_0.method_7(string.Format("https://www.{0}/catalog/miniAddToCart.cfm", this.string_2), dictionary, false);
					if (this.method_3(httpResponseMessage))
					{
						continue;
					}
					httpResponseMessage.EnsureSuccessStatusCode();
					if (httpResponseMessage.smethod_3().ToLower().Contains("out of stock") || httpResponseMessage.smethod_3().Contains("Due to high demand"))
					{
						this.class4_0.method_4("Waiting for restock", "#c2c2c2", true, false);
						Thread.Sleep(GClass0.int_0);
						this.method_7();
						num++;
						continue;
					}
					if (httpResponseMessage.smethod_3().Contains("1 item in cart"))
					{
						this.string_4 = httpResponseMessage.smethod_3().Split(new string[]
						{
							"var requestKey =\""
						}, StringSplitOptions.None)[1].Split(new char[]
						{
							'"'
						})[0];
						this.class4_0.method_4("Successfully carted", "#c2c2c2", true, false);
						break;
					}
				}
				throw new Exception();
			}
			catch (ThreadAbortException)
			{
				break;
			}
			catch
			{
				this.class4_0.method_4("Error adding to cart", "#c2c2c2", true, false);
				Thread.Sleep(GClass0.int_1);
				this.method_7();
				num++;
				this.class4_0.method_4("Adding to cart", "#c2c2c2", true, false);
			}
		}
	}

	// Token: 0x0600051C RID: 1308 RVA: 0x00029D64 File Offset: 0x00027F64
	public void method_10()
	{
		for (;;)
		{
			try
			{
				this.class4_0.method_4("Checking inventory", "#c2c2c2", true, false);
				HttpResponseMessage httpResponseMessage_ = this.class70_0.method_5(string.Format("https://www.{0}/pdp/gateway?requestKey={1}&action=checkout&_=1521900315214", this.string_2, this.string_4), true);
				while (Convert.ToInt16(httpResponseMessage_.smethod_0()["data"]["queue"]["checkoutTimeSecondsUntil"].ToString()) > 0)
				{
					this.class4_0.method_4("In checkout queue", "#c2c2c2", true, false);
					Thread.Sleep((int)(Convert.ToInt16(httpResponseMessage_.smethod_0()["data"]["checkoutTimeSecondsUntil"].ToString()) * 1000));
				}
				if (httpResponseMessage_.smethod_0()["data"]["inventory"]["outOfStockLines"].Any<JToken>())
				{
					this.class4_0.method_4("Out of stock, restarting", "#c2c2c2", true, false);
					Thread.Sleep(GClass0.int_1);
					this.method_1();
				}
				else if (!object.Equals(false, (bool)httpResponseMessage_.smethod_0()["data"]["state"]["inventoryCheckFail"]))
				{
					throw new Exception();
				}
			}
			catch (ThreadAbortException)
			{
			}
			catch (ArgumentException)
			{
			}
			catch (FormatException)
			{
			}
			catch
			{
				this.class4_0.method_4("Error checking inventory", "#c2c2c2", true, false);
				Thread.Sleep(GClass0.int_1);
				continue;
			}
			break;
		}
	}

	// Token: 0x0600051D RID: 1309 RVA: 0x00029F50 File Offset: 0x00028150
	public void method_11()
	{
		for (;;)
		{
			try
			{
				this.class4_0.method_4("Collecting checkout data", "#c2c2c2", true, false);
				HttpResponseMessage httpResponseMessage = this.class70_0.method_5(string.Format("https://www.{0}/checkout/?uri=checkout/", this.string_2), true);
				if (this.method_3(httpResponseMessage))
				{
					continue;
				}
				httpResponseMessage.EnsureSuccessStatusCode();
				HtmlDocument htmlDocument = new HtmlDocument();
				htmlDocument.LoadHtml(httpResponseMessage.smethod_3());
				this.string_5 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='hbg']").Attributes["value"].Value;
				this.string_4 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='requestKey']").Attributes["value"].Value;
			}
			catch (ThreadAbortException)
			{
			}
			catch
			{
				this.class4_0.method_4("Error collecting checkout data", "#c2c2c2", true, false);
				Thread.Sleep(GClass0.int_1);
				continue;
			}
			break;
		}
	}

	// Token: 0x0600051E RID: 1310 RVA: 0x0002A054 File Offset: 0x00028254
	public void method_12()
	{
		this.cookieCollection_0 = this.class70_0.cookieContainer_0.GetCookies(new Uri(string.Format("https://www.{0}", this.string_2)));
		for (;;)
		{
			try
			{
				this.class4_0.method_4("Submitting shipping data", "#c2c2c2", true, false);
				Dictionary<string, string> dictionary = Class70.smethod_1();
				string value = "{\"maxVisitedPane\":\"billAddressPane\",\"billMyAddressBookIndex\":\"-1\",\"addressNeedsVerification\":true,\"billFirstName\":\"\",\"billLastName\":\"\",\"billAddress1\":\"\",\"billAddress2\":\"\",\"billCity\":\"\",\"billState\":\"\",\"billProvince\":\"\",\"billPostalCode\":\"\",\"billHomePhone\":\"\",\"billMobilePhone\":\"\",\"billCountry\":\"US\",\"billEmailAddress\":\"\",\"billConfirmEmail\":\"\",\"billAddrIsPhysical\":true,\"billSubscribePhone\":false,\"billAbbreviatedAddress\":false,\"shipUpdateDefaultAddress\":false,\"VIPNumber\":\"\",\"accountBillAddress\":{\"billMyAddressBookIndex\":-1},\"selectedBillAddress\":{},\"billMyAddressBook\":[],\"updateBillingForBML\":false}";
				dictionary["requestKey"] = this.string_4;
				dictionary["hbg"] = this.string_5;
				dictionary["addressBookEnabled"] = "true";
				dictionary["billAddressType"] = "new";
				dictionary["billAddressInputType"] = "single";
				dictionary["billCountry"] = Class167.smethod_0((string)this.jtoken_0["billing"]["country"], false);
				dictionary["billMyAddressBookIndex"] = "-1";
				dictionary["billFirstName"] = (string)this.jtoken_0["billing"]["first_name"];
				dictionary["billLastName"] = (string)this.jtoken_0["billing"]["last_name"];
				dictionary["billAddress1"] = (string)this.jtoken_0["billing"]["addr1"];
				dictionary["billAddress2"] = (string)this.jtoken_0["billing"]["addr2"];
				dictionary["billPostalCode"] = (string)this.jtoken_0["billing"]["zip"];
				dictionary["billCity"] = (string)this.jtoken_0["billing"]["city"];
				dictionary["billState"] = Class167.smethod_1((string)this.jtoken_0["billing"]["country"], (string)this.jtoken_0["billing"]["state"]);
				dictionary["billProvince"] = Class167.smethod_1((string)this.jtoken_0["billing"]["country"], (string)this.jtoken_0["billing"]["state"]);
				dictionary["billHomePhone"] = (string)this.jtoken_0["payment"]["phone"];
				dictionary["billEmailAddress"] = (string)this.jtoken_0["payment"]["email"];
				dictionary["billConfirmEmail"] = (string)this.jtoken_0["payment"]["email"];
				dictionary["shipAddressType"] = "different";
				dictionary["shipAddressInputType"] = "single";
				dictionary["shipCountry"] = Class167.smethod_0((string)this.jtoken_0["delivery"]["country"], false);
				dictionary["shipMyAddressBookIndex"] = "-2";
				dictionary["shipToStore"] = "false";
				dictionary["shipFirstName"] = (string)this.jtoken_0["delivery"]["first_name"];
				dictionary["shipLastName"] = (string)this.jtoken_0["delivery"]["last_name"];
				dictionary["shipAddress1"] = (string)this.jtoken_0["delivery"]["addr1"];
				dictionary["shipAddress2"] = (string)this.jtoken_0["delivery"]["addr2"];
				dictionary["shipPostalCode"] = (string)this.jtoken_0["delivery"]["zip"];
				dictionary["shipCity"] = (string)this.jtoken_0["delivery"]["city"];
				dictionary["shipState"] = Class167.smethod_1((string)this.jtoken_0["delivery"]["country"], (string)this.jtoken_0["delivery"]["state"]);
				dictionary["shipProvince"] = Class167.smethod_1((string)this.jtoken_0["delivery"]["country"], (string)this.jtoken_0["delivery"]["state"]);
				dictionary["shipHomePhone"] = (string)this.jtoken_0["payment"]["phone"];
				dictionary["verifiedCheckoutData"] = value;
				HttpResponseMessage httpResponseMessage = this.class70_0.method_7(string.Format("https://www.{0}/checkout/eventGateway?method=validateShipPane", this.string_2), dictionary, false);
				if (!this.method_3(httpResponseMessage))
				{
					httpResponseMessage.EnsureSuccessStatusCode();
					JObject jobject = JObject.Parse(httpResponseMessage.smethod_3().Substring(2, httpResponseMessage.smethod_3().Length - 2));
					if (jobject["RESPONSEERROR"].ToString() != "False")
					{
						throw new Exception();
					}
					if (httpResponseMessage.smethod_3().Contains("One or more items cannot be shipped to the destination"))
					{
						this.class4_0.method_0("Shipping restriction", "red", false);
					}
					this.string_4 = jobject["REQUESTKEY"].ToString();
					this.string_5 = jobject["hbg"].ToString();
					if (this.string_2 == "footlocker.ca")
					{
						this.string_8 = jobject["SHIPMETHODPANE"]["SELECTEDMETHODNAMESFS"].ToString();
						this.string_9 = jobject["SHIPMETHODPANE"]["SELECTEDMETHODCODESFS"].ToString();
					}
					else if (jobject["SHIPMETHODPANE"]["VALIDMETHODS"].Any<JToken>())
					{
						this.string_8 = jobject["SHIPMETHODPANE"]["VALIDMETHODS"][0]["SHIPPINGMETHODNAME"].ToString();
						this.string_9 = jobject["SHIPMETHODPANE"]["VALIDMETHODS"][0]["SHIPMETHODCODE"].ToString();
					}
					else
					{
						this.string_8 = jobject["SHIPMETHODPANE"]["SELECTEDMETHODCODESFS"].ToString();
						this.string_9 = jobject["SHIPMETHODPANE"]["SELECTEDMETHODNAMESFS"].ToString();
					}
					this.string_7 = jobject["SHIPPANE"]["SHIPHASH"].ToString();
					break;
				}
			}
			catch (ThreadAbortException)
			{
				break;
			}
			catch
			{
				this.class4_0.method_4("Error submitting shipping data", "#c2c2c2", true, false);
				Thread.Sleep(GClass0.int_1);
			}
		}
	}

	// Token: 0x0600051F RID: 1311 RVA: 0x0002A804 File Offset: 0x00028A04
	public void method_13()
	{
		this.cookieCollection_0 = this.class70_0.cookieContainer_0.GetCookies(new Uri(string.Format("https://www.{0}", this.string_2)));
		for (;;)
		{
			try
			{
				this.class4_0.method_4("Submitting shipping method", "#c2c2c2", true, false);
				Dictionary<string, string> dictionary = Class70.smethod_1();
				dictionary["verifiedCheckoutData"] = string.Format("{{\"maxVisitedPane\":\"shipMethodPane\",\"billMyAddressBookIndex\":\"-1\",\"addressNeedsVerification\":false,\"billFirstName\":\"{0}\",\"billLastName\":\"{1}\",\"billAddress1\":\"{2}\",\"billAddress2\":\"{3}\",\"billCity\":\"{4}\",\"billState\":\"{5}\",\"billProvince\":\"{6}\",\"billPostalCode\":\"{7}\",\"billHomePhone\":\"{8}\",\"billMobilePhone\":\"\",\"billCountry\":\"{9}\",\"billEmailAddress\":\"{10}\",\"billConfirmEmail\":\"{11}\",\"billAddrIsPhysical\":true,\"billSubscribePhone\":false,\"billAbbreviatedAddress\":false,\"shipUpdateDefaultAddress\":false,\"VIPNumber\":\"\",\"accountBillAddress\":{{\"billMyAddressBookIndex\":-1}},\"selectedBillAddress\":{{}},\"billMyAddressBook\":[],\"updateBillingForBML\":false,\"shipMyAddressBookIndex\":-1,\"useBillingAsShipping\":false,\"shipFirstName\":\"{12}\",\"shipLastName\":\"{13}\",\"shipAddress1\":\"{14}\",\"shipAddress2\":\"{15}\",\"shipCity\":\"{16}\",\"shipState\":\"{17}\",\"shipProvince\":\"{18}\",\"shipPostalCode\":\"{19}\",\"shipHomePhone\":\"{20}\",\"shipMobilePhone\":\"\",\"shipCountry\":\"{21}\",\"shipHash\":\"{22}\",\"shipMultiple\":false,\"isShipToStoreEligibleCheckout\":false,\"shipToStore\":false,\"isMultipleAddressEligible\":false,\"shipAbbreviatedAddress\":false,\"selectedStore\":{{}},\"accountShipAddress\":{{\"shipMyAddressBookIndex\":-1}},\"selectedShipAddress\":{{}},\"shipMyAddressBook\":[],\"shipMethodCode\":\"{23}\",\"shipMethodName\":\"{24}\",\"shipMethodPrice\":\"$42.00\",\"shipDeliveryEstimate\":\"\",\"shipMethodCodeSDD\":\"\",\"shipMethodNameSDD\":\"\",\"shipMethodPriceSDD\":\"$0.00\",\"shipDeliveryEstimateSDD\":\"\",\"shipMethodCodeS2S\":\"\",\"shipMethodNameS2S\":\"\",\"shipMethodPriceS2S\":\"$0.00\",\"shipDeliveryEstimateS2S\":\"\",\"shipMethodCodeSFS\":\"\",\"shipMethodNameSFS\":\"\",\"shipMethodPriceSFS\":\"$0.00\",\"shipDeliveryEstimateSFS\":\"\",\"homeDeliveryPrice\":\"$42.00\",\"overallHomeDeliveryPrice\":\"$42.00\",\"aggregatedDeliveryPrice\":\"$42.00\",\"aggregatedDeliveryLabel\":\"\",\"showGiftBoxOption\":false,\"addGiftBox\":false,\"giftBoxPrice\":\"$3.99\",\"useGiftReceipt\":false,\"showGiftOptions\":false,\"loyaltyMessageText\":false,\"showLoyaltyRenewalMessage\":false,\"pickupPersonFirstName\":\"\",\"pickupPersonLastName\":\"\"}}", new object[]
				{
					(string)this.jtoken_0["billing"]["first_name"],
					(string)this.jtoken_0["billing"]["last_name"],
					(string)this.jtoken_0["billing"]["addr1"],
					(string)this.jtoken_0["billing"]["addr2"],
					(string)this.jtoken_0["billing"]["city"],
					Class167.smethod_1((string)this.jtoken_0["billing"]["country"], (string)this.jtoken_0["billing"]["state"]),
					Class167.smethod_1((string)this.jtoken_0["billing"]["country"], (string)this.jtoken_0["billing"]["state"]),
					(string)this.jtoken_0["billing"]["zip"],
					(string)this.jtoken_0["payment"]["phone"],
					Class167.smethod_0((string)this.jtoken_0["billing"]["country"], false),
					(string)this.jtoken_0["payment"]["email"],
					(string)this.jtoken_0["payment"]["email"],
					(string)this.jtoken_0["delivery"]["first_name"],
					(string)this.jtoken_0["delivery"]["last_name"],
					(string)this.jtoken_0["delivery"]["addr1"],
					(string)this.jtoken_0["delivery"]["addr2"],
					(string)this.jtoken_0["delivery"]["city"],
					Class167.smethod_1((string)this.jtoken_0["delivery"]["country"], (string)this.jtoken_0["delivery"]["state"]),
					Class167.smethod_1((string)this.jtoken_0["delivery"]["country"], (string)this.jtoken_0["delivery"]["state"]),
					(string)this.jtoken_0["delivery"]["zip"],
					(string)this.jtoken_0["payment"]["phone"],
					Class167.smethod_0((string)this.jtoken_0["delivery"]["country"], false),
					this.string_7,
					this.string_9,
					this.string_8
				});
				dictionary["requestKey"] = this.string_4;
				dictionary["hbg"] = this.string_5;
				dictionary["addressBookEnabled"] = "true";
				dictionary["billAddressType"] = "new";
				dictionary["billAddressInputType"] = "single";
				dictionary["billCountry"] = Class167.smethod_0((string)this.jtoken_0["billing"]["country"], false);
				dictionary["billMyAddressBookIndex"] = "-1";
				dictionary["billFirstName"] = (string)this.jtoken_0["billing"]["first_name"];
				dictionary["billLastName"] = (string)this.jtoken_0["billing"]["last_name"];
				dictionary["billAddress1"] = (string)this.jtoken_0["billing"]["addr1"];
				dictionary["billAddress2"] = (string)this.jtoken_0["billing"]["addr2"];
				dictionary["billPostalCode"] = (string)this.jtoken_0["billing"]["zip"];
				dictionary["billCity"] = (string)this.jtoken_0["billing"]["city"];
				dictionary["billState"] = Class167.smethod_1((string)this.jtoken_0["billing"]["country"], (string)this.jtoken_0["billing"]["state"]);
				dictionary["billProvince"] = Class167.smethod_1((string)this.jtoken_0["billing"]["country"], (string)this.jtoken_0["billing"]["state"]);
				dictionary["billHomePhone"] = (string)this.jtoken_0["payment"]["phone"];
				dictionary["billEmailAddress"] = (string)this.jtoken_0["payment"]["email"];
				dictionary["billConfirmEmail"] = (string)this.jtoken_0["payment"]["email"];
				dictionary["shipAddressType"] = "different";
				dictionary["shipAddressInputType"] = "single";
				dictionary["shipCountry"] = Class167.smethod_0((string)this.jtoken_0["delivery"]["country"], false);
				dictionary["shipMyAddressBookIndex"] = "-2";
				dictionary["shipToStore"] = "false";
				dictionary["shipFirstName"] = (string)this.jtoken_0["delivery"]["first_name"];
				dictionary["shipLastName"] = (string)this.jtoken_0["delivery"]["last_name"];
				dictionary["shipAddress1"] = (string)this.jtoken_0["delivery"]["addr1"];
				dictionary["shipAddress2"] = (string)this.jtoken_0["delivery"]["addr2"];
				dictionary["shipPostalCode"] = (string)this.jtoken_0["delivery"]["zip"];
				dictionary["shipCity"] = (string)this.jtoken_0["delivery"]["city"];
				dictionary["shipState"] = Class167.smethod_1((string)this.jtoken_0["delivery"]["country"], (string)this.jtoken_0["delivery"]["state"]);
				dictionary["shipProvince"] = Class167.smethod_1((string)this.jtoken_0["delivery"]["country"], (string)this.jtoken_0["delivery"]["state"]);
				dictionary["shipHomePhone"] = (string)this.jtoken_0["payment"]["phone"];
				dictionary["shipMethodCode"] = this.string_9;
				HttpResponseMessage httpResponseMessage = this.class70_0.method_7(string.Format("https://www.{0}/checkout/eventGateway?method=validateShipMethodPane", this.string_2), dictionary, false);
				if (!this.method_3(httpResponseMessage))
				{
					httpResponseMessage.EnsureSuccessStatusCode();
					JObject jobject = JObject.Parse(httpResponseMessage.smethod_3().Substring(2, httpResponseMessage.smethod_3().Length - 2));
					if (jobject["RESPONSEERROR"].ToString() != "False")
					{
						throw new Exception();
					}
					this.string_4 = jobject["REQUESTKEY"].ToString();
					this.string_5 = jobject["hbg"].ToString();
					this.string_6 = jobject["PAYMENTMETHODPANE"]["LGR"].ToString();
					break;
				}
			}
			catch (ThreadAbortException)
			{
				break;
			}
			catch
			{
				this.class4_0.method_4("Error submitting delivery", "#c2c2c2", true, false);
				Thread.Sleep(GClass0.int_1);
			}
		}
	}

	// Token: 0x06000520 RID: 1312 RVA: 0x0002B23C File Offset: 0x0002943C
	public void method_14()
	{
		this.cookieCollection_0 = this.class70_0.cookieContainer_0.GetCookies(new Uri(string.Format("https://www.{0}", this.string_2)));
		for (;;)
		{
			try
			{
				this.class4_0.method_4("Submitting payment", "#c2c2c2", true, false);
				Dictionary<string, string> dictionary = Class70.smethod_1();
				dictionary["verifiedCheckoutData"] = string.Concat(new string[]
				{
					string.Format("{{\"maxVisitedPane\":\"promoCodePane\",\"updateBillingForBML\":false,\"billMyAddressBookIndex\":\"-1\",\"addressNeedsVerification\":false,\"billFirstName\":\"{0}\",\"billLastName\":\"{1}\",", (string)this.jtoken_0["billing"]["first_name"], (string)this.jtoken_0["billing"]["last_name"]),
					string.Format("\"billAddress1\":\"{0}\",\"billAddress2\":\"{1}\",\"billCity\":\"{2}\",\"billState\":\"{3}\",\"billProvince\":\"{4}\",\"billPostalCode\":\"{5}\",\"billHomePhone\":\"{6}\",\"billMobilePhone\":\"\",\"billCountry\":\"{7}\",", new object[]
					{
						(string)this.jtoken_0["billing"]["addr1"],
						(string)this.jtoken_0["billing"]["addr2"],
						(string)this.jtoken_0["billing"]["city"],
						Class167.smethod_1((string)this.jtoken_0["billing"]["country"], (string)this.jtoken_0["billing"]["state"]),
						Class167.smethod_1((string)this.jtoken_0["billing"]["country"], (string)this.jtoken_0["billing"]["state"]),
						(string)this.jtoken_0["billing"]["zip"],
						(string)this.jtoken_0["payment"]["phone"],
						Class167.smethod_0((string)this.jtoken_0["billing"]["country"], false)
					}),
					string.Format("\"billEmailAddress\":\"{0}\",\"billConfirmEmail\":\"{1}\",\"billAddrIsPhysical\":true,\"billSubscribePhone\":false,\"billAbbreviatedAddress\":false,\"shipUpdateDefaultAddress\":false,\"VIPNumber\":\"\",", (string)this.jtoken_0["payment"]["email"], (string)this.jtoken_0["payment"]["email"]),
					string.Format("\"accountBillAddress\":{{\"billMyAddressBookIndex\":-1}},\"selectedBillAddress\":{{}},\"billMyAddressBook\":[],\"shipMyAddressBookIndex\":-2,\"shipContactID\":\"\",\"shipFirstName\":\"{0}\",\"shipLastName\":\"{1}\",\"shipAddress1\":\"{2}\",", (string)this.jtoken_0["delivery"]["first_name"], (string)this.jtoken_0["delivery"]["last_name"], (string)this.jtoken_0["delivery"]["addr1"]),
					string.Format("\"shipAddress2\":\"{0}\",\"shipCity\":\"{1}\",\"shipState\":\"{2}\",\"shipProvince\":\"{3}\",\"shipPostalCode\":\"{4}\",\"shipHomePhone\":\"{5}\",\"shipMobilePhone\":\"\",\"shipCountry\":\"{6}\",\"shipToStore\":false,", new object[]
					{
						(string)this.jtoken_0["delivery"]["addr2"],
						(string)this.jtoken_0["delivery"]["city"],
						Class167.smethod_1((string)this.jtoken_0["delivery"]["country"], (string)this.jtoken_0["delivery"]["state"]),
						Class167.smethod_1((string)this.jtoken_0["delivery"]["country"], (string)this.jtoken_0["delivery"]["state"]),
						(string)this.jtoken_0["delivery"]["zip"],
						(string)this.jtoken_0["payment"]["phone"],
						Class167.smethod_0((string)this.jtoken_0["delivery"]["country"], false)
					}),
					string.Format("\"shipHash\":\"{0}\",\"shipMultiple\":false,\"isShipToStoreEligibleCheckout\":true,\"isMultipleAddressEligible\":false,\"shipAbbreviatedAddress\":false,\"selectedStore\":{{}},", this.string_7),
					string.Format("\"accountShipAddress\":{{\"shipMyAddressBookIndex\":-1}},\"selectedShipAddress\":{{}},\"shipMyAddressBook\":[],\"shipMethodCode\":\"{0}\",\"shipMethodName\":\"{1}\",\"shipMethodPrice\":\"$0.00\",", this.string_9, this.string_8),
					"\"shipDeliveryEstimate\":\"\",\"shipMethodCodeSDD\":\"\",\"shipMethodNameSDD\":\"\",\"shipMethodPriceSDD\":\"$0.00\",\"shipDeliveryEstimateSDD\":\"\",\"shipMethodCodeS2S\":\"\",\"shipMethodNameS2S\":\"\",\"shipMethodPriceS2S\":\"$0.00\",\"shipDeliveryEstimateS2S\":\"\",\"shipMethodCodeSFS\":\"\",\"shipMethodNameSFS\":\"\",\"shipMethodPriceSFS\":\"$0.00\",\"shipDeliveryEstimateSFS\":\"\",\"homeDeliveryPrice\":\"$0.00\",\"overallHomeDeliveryPrice\":\"$0.00\",\"aggregatedDeliveryPrice\":\"FREE\",\"aggregatedDeliveryLabel\":\"\",\"showGiftBoxOption\":true,\"addGiftBox\":false,\"giftBoxPrice\":\"$3.99\",\"useGiftReceipt\":false,\"showGiftOptions\":true,\"loyaltyMessageText\":false,\"showLoyaltyRenewalMessage\":false,\"pickupPersonFirstName\":\"\",\"pickupPersonLastName\":\"\",\"preferredLanguage\":\"\",\"advanceToConfirm\":false,\"payType\":\"NO_PAYMENT_METHOD\",\"payPalToken\":\"\",\"payPalInContext\":true,\"payPalMerchantId\":\"\",\"payPalStage\":\"\",\"payPalPaymentAllowed\":true,\"payMethodPaneExpireMonth\":\"\",\"payMethodPaneExpireYear\":\"\",\"payMethodPaneCardNumber\":\"\",\"payMethodPaneCardType\":\"\",\"payMethodPaneLastFour\":\"\",\"payMethodPanePurchaseOrder\":\"\",\"payMethodPanePurchaseOrderNewCustomer\":\"\",\"payMethodPaneCVV\":\"\",\"creditcardPaymentAllowed\":true,\"billMeLaterStage\":\"\",\"BMLPaymentAllowed\":true,\"displayBMLPromotion\":false,\"POPaymentAllowed\":false,\"promoType\":\"\",\"promoCode\":\"\",\"sourceCode\":\"INETSRC\",\"sourceCodeDescription\":\"\",\"sourceCodeCartDisplayText\":\"\",\"GIFTCARDCODE1\":\"\",\"GIFTCARDPIN1\":\"\",\"GIFTCARDUSED1\":\"\",\"GIFTCARDCODE2\":\"\",\"GIFTCARDPIN2\":\"\",\"GIFTCARDUSED2\":\"\",\"GIFTCARDCODE3\":\"\",\"GIFTCARDPIN3\":\"\",\"GIFTCARDUSED3\":\"\",\"GIFTCARDCODE4\":\"\",\"GIFTCARDPIN4\":\"\",",
					string.Format("\"GIFTCARDUSED4\":\"\",\"GIFTCARDCODE5\":\"\",\"GIFTCARDPIN5\":\"\",\"GIFTCARDUSED5\":\"\",\"rewardBarCode\":\"\",\"giftCardsEmpty\":true,\"sourceCodesEmpty\":true,\"ContingencyQueue\":\"\",\"lgr\":\"{0}\",\"displayEmailOptIn\":false,", this.string_6),
					"\"billSubscribeEmail\":false,\"billReceiveNewsletter\":false,\"billFavoriteTeams\":false,\"paypalEmailAddress\":\"\",\"displaySheerIdIframe\":true,\"displayCmsEntry\":\"\",\"payMethodPaneUserGotStoredCC\":false,\"payMethodPaneHasStoredCC\":false,\"payMethodPaneUsedStoredCC\":false,\"payMethodPaneSavedNewCC\":false,\"selectedCreditCard\":{\"payMethodPaneHasCVV\":true},\"payMethodPaneHasCVV\":true}"
				});
				dictionary["requestKey"] = this.string_4;
				dictionary["hbg"] = this.string_5;
				dictionary["bb_device_id"] = this.string_11;
				dictionary["addressBookEnabled"] = "true";
				dictionary["loginHeaderEmailAddress"] = string.Empty;
				dictionary["loginHeaderPassword"] = string.Empty;
				dictionary["loginPaneNewEmailAddress"] = string.Empty;
				dictionary["loginPaneConfirmNewEmailAddress"] = string.Empty;
				dictionary["loginPaneEmailAddress"] = string.Empty;
				dictionary["loginPanePassword"] = string.Empty;
				dictionary["billAddressType"] = "new";
				dictionary["billAddressInputType"] = "single";
				dictionary["billAPOFPOCountry"] = Class167.smethod_0((string)this.jtoken_0["billing"]["country"], false);
				dictionary["billCountry"] = Class167.smethod_0((string)this.jtoken_0["billing"]["country"], false);
				dictionary["billMyAddressBookIndex"] = "-1";
				dictionary["billFirstName"] = (string)this.jtoken_0["billing"]["first_name"];
				dictionary["billLastName"] = (string)this.jtoken_0["billing"]["last_name"];
				dictionary["billAddress1"] = (string)this.jtoken_0["billing"]["addr1"];
				dictionary["billAddress2"] = (string)this.jtoken_0["billing"]["addr2"];
				dictionary["billPostalCode"] = (string)this.jtoken_0["billing"]["zip"];
				dictionary["billCity"] = (string)this.jtoken_0["billing"]["city"];
				dictionary["billAPOFPORegion"] = string.Empty;
				dictionary["billState"] = Class167.smethod_1((string)this.jtoken_0["billing"]["country"], (string)this.jtoken_0["billing"]["state"]);
				dictionary["billProvince"] = string.Empty;
				dictionary["billAPOFPOState"] = string.Empty;
				dictionary["billAPOFPOPostalCode"] = string.Empty;
				dictionary["billHomePhone"] = (string)this.jtoken_0["payment"]["phone"];
				dictionary["billEmailAddress"] = (string)this.jtoken_0["payment"]["email"];
				dictionary["billConfirmEmail"] = (string)this.jtoken_0["payment"]["email"];
				dictionary["shipAddressType"] = "new";
				dictionary["shipAddressInputType"] = "single";
				dictionary["shipAPOFPOCountry"] = Class167.smethod_0((string)this.jtoken_0["delivery"]["country"], false);
				dictionary["shipCountry"] = Class167.smethod_0((string)this.jtoken_0["delivery"]["country"], false);
				dictionary["shipMyAddressBookIndex"] = "-1";
				dictionary["shipToStore"] = "false";
				dictionary["shipFirstName"] = (string)this.jtoken_0["delivery"]["first_name"];
				dictionary["shipLastName"] = (string)this.jtoken_0["delivery"]["last_name"];
				dictionary["shipAddress1"] = (string)this.jtoken_0["delivery"]["addr1"];
				dictionary["shipAddress2"] = (string)this.jtoken_0["delivery"]["addr2"];
				dictionary["shipPostalCode"] = (string)this.jtoken_0["delivery"]["zip"];
				dictionary["shipCity"] = (string)this.jtoken_0["delivery"]["city"];
				dictionary["shipAPOFPORegion"] = string.Empty;
				dictionary["shipState"] = Class167.smethod_1((string)this.jtoken_0["delivery"]["country"], (string)this.jtoken_0["delivery"]["state"]);
				dictionary["shipProvince"] = string.Empty;
				dictionary["shipAPOFPOState"] = string.Empty;
				dictionary["shipAPOFPOPostalCode"] = string.Empty;
				dictionary["shipHomePhone"] = (string)this.jtoken_0["payment"]["phone"];
				dictionary["shipMethodCodeS2S"] = string.Empty;
				dictionary["shipMethodCode"] = this.string_9;
				dictionary["storePickupInputPostalCode"] = string.Empty;
				dictionary["promoType"] = string.Empty;
				dictionary["CPCOrSourceCode"] = string.Empty;
				dictionary["payMethodPanePayType"] = "CC";
				dictionary["payMethodPanestoredCCCardNumber"] = "CC";
				dictionary["CardNumber"] = ((string)this.jtoken_0["payment"]["card"]["number"]).Replace(" ", string.Empty);
				dictionary["CardExpireDateMM"] = (string)this.jtoken_0["payment"]["card"]["exp_month"];
				dictionary["CardExpireDateYY"] = (string)this.jtoken_0["payment"]["card"]["exp_year"];
				dictionary["CardCCV"] = (string)this.jtoken_0["payment"]["card"]["cvv"];
				dictionary["payMethodPaneStoredType"] = string.Empty;
				dictionary["payMethodPaneConfirmCardNumber"] = string.Empty;
				dictionary["payMethodPaneStoredCCExpireMonth"] = string.Empty;
				dictionary["payMethodPaneStoredCCExpireYear"] = string.Empty;
				dictionary["payMethodPaneCardType"] = this.method_2(((string)this.jtoken_0["payment"]["card"]["number"]).Replace(" ", string.Empty));
				dictionary["payMethodPaneCardNumber"] = ((string)this.jtoken_0["payment"]["card"]["number"]).Replace(" ", string.Empty);
				dictionary["payMethodPaneExpireMonth"] = (string)this.jtoken_0["payment"]["card"]["exp_month"];
				dictionary["payMethodPaneExpireYear"] = this.jtoken_0["payment"]["card"]["exp_year"].ToString()[2].ToString() + this.jtoken_0["payment"]["card"]["exp_year"].ToString()[3].ToString();
				dictionary["payMethodPaneCVV"] = (string)this.jtoken_0["payment"]["card"]["cvv"];
				dictionary["payMethodPaneStoredCCCVV"] = string.Empty;
				dictionary["shipProvince"] = Class167.smethod_1((string)this.jtoken_0["delivery"]["country"], (string)this.jtoken_0["delivery"]["state"]);
				dictionary["billProvince"] = Class167.smethod_1((string)this.jtoken_0["billing"]["country"], (string)this.jtoken_0["billing"]["state"]);
				HttpResponseMessage httpResponseMessage = this.class70_0.method_7(string.Format("https://www.{0}/checkout/eventGateway?method=validatePaymentMethodPane", this.string_2), dictionary, false);
				if (!this.method_3(httpResponseMessage))
				{
					httpResponseMessage.EnsureSuccessStatusCode();
					JObject jobject = JObject.Parse(httpResponseMessage.smethod_3().Substring(2, httpResponseMessage.smethod_3().Length - 2));
					if (jobject["RESPONSEERROR"].ToString() != "False")
					{
						throw new Exception();
					}
					this.string_4 = jobject["REQUESTKEY"].ToString();
					this.string_5 = jobject["hbg"].ToString();
					break;
				}
			}
			catch (ThreadAbortException)
			{
				break;
			}
			catch
			{
				this.class4_0.method_4("Error submitting payment, retrying", "#c2c2c2", true, false);
				Thread.Sleep(GClass0.int_1);
			}
		}
	}

	// Token: 0x06000521 RID: 1313 RVA: 0x0002C100 File Offset: 0x0002A300
	public void method_15()
	{
		this.cookieCollection_0 = this.class70_0.cookieContainer_0.GetCookies(new Uri(string.Format("https://www.{0}", this.string_2)));
		for (;;)
		{
			try
			{
				this.class4_0.method_4("Submitting order", "orange", true, false);
				Dictionary<string, string> dictionary = Class70.smethod_1();
				dictionary["verifiedCheckoutData"] = string.Concat(new string[]
				{
					string.Format("{{\"maxVisitedPane\":\"orderReviewPane\",\"updateBillingForBML\":false,\"billMyAddressBookIndex\":\"-1\",\"addressNeedsVerification\":false,\"billFirstName\":\"{0}\",\"billLastName\":\"{1}\",", (string)this.jtoken_0["billing"]["first_name"], (string)this.jtoken_0["billing"]["last_name"]),
					string.Format("\"billAddress1\":\"{0}\",\"billAddress2\":\"{1}\",\"billCity\":\"{2}\",\"billState\":\"{3}\",\"billProvince\":\"{4}\",\"billPostalCode\":\"{5}\",\"billHomePhone\":\"{6}\",\"billMobilePhone\":\"\",\"billCountry\":\"{7}\",", new object[]
					{
						(string)this.jtoken_0["billing"]["addr1"],
						(string)this.jtoken_0["billing"]["addr2"],
						(string)this.jtoken_0["billing"]["city"],
						Class167.smethod_1((string)this.jtoken_0["billing"]["country"], (string)this.jtoken_0["billing"]["state"]),
						Class167.smethod_1((string)this.jtoken_0["billing"]["country"], (string)this.jtoken_0["billing"]["state"]),
						(string)this.jtoken_0["billing"]["zip"],
						(string)this.jtoken_0["payment"]["phone"],
						Class167.smethod_0((string)this.jtoken_0["billing"]["country"], false)
					}),
					string.Format("\"billEmailAddress\":\"{0}\",\"billConfirmEmail\":\"{1}\",\"billAddrIsPhysical\":true,\"billSubscribePhone\":false,\"billAbbreviatedAddress\":false,\"shipUpdateDefaultAddress\":false,\"VIPNumber\":\"\",", (string)this.jtoken_0["payment"]["email"], (string)this.jtoken_0["payment"]["email"]),
					string.Format("\"accountBillAddress\":{{\"billMyAddressBookIndex\":-1}},\"selectedBillAddress\":{{}},\"billMyAddressBook\":[],\"shipMyAddressBookIndex\":-2,\"shipContactID\":\"\",\"shipFirstName\":\"{0}\",\"shipLastName\":\"{1}\",\"shipAddress1\":\"{2}\",", (string)this.jtoken_0["delivery"]["first_name"], (string)this.jtoken_0["delivery"]["last_name"], (string)this.jtoken_0["delivery"]["addr1"]),
					string.Format("\"shipAddress2\":\"{0}\",\"shipCity\":\"{1}\",\"shipState\":\"{2}\",\"shipProvince\":\"{3}\",\"shipPostalCode\":\"{4}\",\"shipHomePhone\":\"{5}\",\"shipMobilePhone\":\"\",\"shipCountry\":\"{6}\",\"shipToStore\":false,", new object[]
					{
						(string)this.jtoken_0["delivery"]["addr2"],
						(string)this.jtoken_0["delivery"]["city"],
						Class167.smethod_1((string)this.jtoken_0["delivery"]["country"], (string)this.jtoken_0["delivery"]["state"]),
						Class167.smethod_1((string)this.jtoken_0["delivery"]["country"], (string)this.jtoken_0["delivery"]["state"]),
						(string)this.jtoken_0["delivery"]["zip"],
						(string)this.jtoken_0["payment"]["phone"],
						Class167.smethod_0((string)this.jtoken_0["delivery"]["country"], false)
					}),
					string.Format("\"shipHash\":\"{0}\",\"shipMultiple\":false,\"isShipToStoreEligibleCheckout\":true,\"isMultipleAddressEligible\":false,\"shipAbbreviatedAddress\":false,\"selectedStore\":{{}},", this.string_7),
					string.Format("\"accountShipAddress\":{{\"shipMyAddressBookIndex\":-1}},\"selectedShipAddress\":{{}},\"shipMyAddressBook\":[],\"shipMethodCode\":\"{0}\",\"shipMethodName\":\"{1}\",\"shipMethodPrice\":\"$0.00\",\"shipDeliveryEstimate\":\"\",", this.string_9, this.string_8),
					"\"shipMethodCodeSDD\":\"\",\"shipMethodNameSDD\":\"\",\"shipMethodPriceSDD\":\"$0.00\",\"shipDeliveryEstimateSDD\":\"\",\"shipMethodCodeS2S\":\"\",\"shipMethodNameS2S\":\"\",\"shipMethodPriceS2S\":\"$0.00\",\"shipDeliveryEstimateS2S\":\"\",\"shipMethodCodeSFS\":\"\",\"shipMethodNameSFS\":\"\",\"shipMethodPriceSFS\":\"$0.00\",\"shipDeliveryEstimateSFS\":\"\",\"homeDeliveryPrice\":\"$0.00\",\"overallHomeDeliveryPrice\":\"$0.00\",\"aggregatedDeliveryPrice\":\"FREE\",\"aggregatedDeliveryLabel\":\"\",\"showGiftBoxOption\":true,\"addGiftBox\":false,\"giftBoxPrice\":\"$3.99\",\"useGiftReceipt\":false,\"showGiftOptions\":true,\"loyaltyMessageText\":false,\"showLoyaltyRenewalMessage\":false,\"pickupPersonFirstName\":\"\",\"pickupPersonLastName\":\"\",\"preferredLanguage\":\"\",\"advanceToConfirm\":false,\"payType\":\"CREDIT_CARD\",\"payPalToken\":\"\",\"payPalInContext\":true,\"payPalMerchantId\":\"\",",
					string.Format("\"payPalStage\":\"\",\"payPalPaymentAllowed\":true,\"payMethodPaneExpireMonth\":{0},\"payMethodPaneExpireYear\":{1},\"payMethodPaneCardNumber\":\"{2}\",\"payMethodPaneCardType\":\"{3}\",\"payMethodPaneLastFour\":\"1111\",", new object[]
					{
						(string)this.jtoken_0["payment"]["card"]["exp_month"],
						this.jtoken_0["payment"]["card"]["exp_year"].ToString()[2].ToString() + this.jtoken_0["payment"]["card"]["exp_year"].ToString()[3].ToString(),
						((string)this.jtoken_0["payment"]["card"]["number"]).Replace(" ", string.Empty),
						this.method_2(((string)this.jtoken_0["payment"]["card"]["number"]).Replace(" ", string.Empty))
					}),
					string.Format("\"payMethodPanePayMethodName\":\"Visa\",\"payMethodPanePurchaseOrder\":\"\",\"payMethodPanePurchaseOrderNewCustomer\":\"\",\"payMethodPaneCVV\":\"{0}\",\"creditcardPaymentAllowed\":true,\"billMeLaterStage\":\"\",", (string)this.jtoken_0["payment"]["card"]["cvv"]),
					"\"BMLPaymentAllowed\":true,\"displayBMLPromotion\":false,\"POPaymentAllowed\":false,\"promoType\":\"\",\"promoCode\":\"\",\"sourceCode\":\"INETSRC\",\"sourceCodeDescription\":\"\",\"sourceCodeCartDisplayText\":\"\",\"GIFTCARDCODE1\":\"\",\"GIFTCARDPIN1\":\"\",\"GIFTCARDUSED1\":\"\",\"GIFTCARDCODE2\":\"\",\"GIFTCARDPIN2\":\"\",\"GIFTCARDUSED2\":\"\",\"GIFTCARDCODE3\":\"\",\"GIFTCARDPIN3\":\"\",\"GIFTCARDUSED3\":\"\",\"GIFTCARDCODE4\":\"\",\"GIFTCARDPIN4\":\"\",\"GIFTCARDUSED4\":\"\",\"GIFTCARDCODE5\":\"\",\"GIFTCARDPIN5\":\"\",\"GIFTCARDUSED5\":\"\",\"rewardBarCode\":\"\",\"giftCardsEmpty\":true,\"sourceCodesEmpty\":true,\"emptyCart\":false,\"ContingencyQueue\":\"\",",
					string.Format("\"lgr\":\"{0}\",\"displayEmailOptIn\":false,\"billSubscribeEmail\":false,\"billReceiveNewsletter\":false,\"billFavoriteTeams\":false,\"paypalEmailAddress\":\"\",\"displaySheerIdIframe\":true,\"displayCmsEntry\":\"\",", this.string_6),
					"\"payMethodPaneUserGotStoredCC\":false,\"payMethodPaneHasStoredCC\":false,\"payMethodPaneUsedStoredCC\":false,\"payMethodPaneSavedNewCC\":false,\"selectedCreditCard\":{},\"payMethodPaneHasCVV\":true,\"payMethodPaneCVVAF\":\"0\"}"
				});
				dictionary["requestKey"] = this.string_4;
				dictionary["hbg"] = this.string_5;
				dictionary["bb_device_id"] = Class103.smethod_0(16);
				dictionary["requestKey"] = this.string_4;
				dictionary["hbg"] = this.string_5;
				dictionary["bb_device_id"] = this.string_11;
				dictionary["addressBookEnabled"] = "true";
				dictionary["loginHeaderEmailAddress"] = string.Empty;
				dictionary["loginHeaderPassword"] = string.Empty;
				dictionary["loginPaneNewEmailAddress"] = string.Empty;
				dictionary["loginPaneConfirmNewEmailAddress"] = string.Empty;
				dictionary["loginPaneEmailAddress"] = string.Empty;
				dictionary["loginPanePassword"] = string.Empty;
				dictionary["billAddressType"] = "new";
				dictionary["billAddressInputType"] = "single";
				dictionary["billAPOFPOCountry"] = Class167.smethod_0((string)this.jtoken_0["billing"]["country"], false);
				dictionary["billCountry"] = Class167.smethod_0((string)this.jtoken_0["billing"]["country"], false);
				dictionary["billMyAddressBookIndex"] = "-1";
				dictionary["billFirstName"] = (string)this.jtoken_0["billing"]["first_name"];
				dictionary["billLastName"] = (string)this.jtoken_0["billing"]["last_name"];
				dictionary["billAddress1"] = (string)this.jtoken_0["billing"]["addr1"];
				dictionary["billAddress2"] = (string)this.jtoken_0["billing"]["addr2"];
				dictionary["billPostalCode"] = (string)this.jtoken_0["billing"]["zip"];
				dictionary["billCity"] = (string)this.jtoken_0["billing"]["city"];
				dictionary["billAPOFPORegion"] = string.Empty;
				dictionary["billState"] = Class167.smethod_1((string)this.jtoken_0["billing"]["country"], (string)this.jtoken_0["billing"]["state"]);
				dictionary["billProvince"] = string.Empty;
				dictionary["billAPOFPOState"] = string.Empty;
				dictionary["billAPOFPOPostalCode"] = string.Empty;
				dictionary["billHomePhone"] = (string)this.jtoken_0["payment"]["phone"];
				dictionary["billEmailAddress"] = (string)this.jtoken_0["payment"]["email"];
				dictionary["billConfirmEmail"] = (string)this.jtoken_0["payment"]["email"];
				dictionary["shipAddressType"] = "new";
				dictionary["shipAddressInputType"] = "single";
				dictionary["shipAPOFPOCountry"] = Class167.smethod_0((string)this.jtoken_0["delivery"]["country"], false);
				dictionary["shipCountry"] = Class167.smethod_0((string)this.jtoken_0["delivery"]["country"], false);
				dictionary["shipMyAddressBookIndex"] = "-1";
				dictionary["shipToStore"] = "false";
				dictionary["shipFirstName"] = (string)this.jtoken_0["delivery"]["first_name"];
				dictionary["shipLastName"] = (string)this.jtoken_0["delivery"]["last_name"];
				dictionary["shipAddress1"] = (string)this.jtoken_0["delivery"]["addr1"];
				dictionary["shipAddress2"] = (string)this.jtoken_0["delivery"]["addr2"];
				dictionary["shipPostalCode"] = (string)this.jtoken_0["delivery"]["zip"];
				dictionary["shipCity"] = (string)this.jtoken_0["delivery"]["city"];
				dictionary["shipAPOFPORegion"] = string.Empty;
				dictionary["shipState"] = Class167.smethod_1((string)this.jtoken_0["delivery"]["country"], (string)this.jtoken_0["delivery"]["state"]);
				dictionary["shipProvince"] = string.Empty;
				dictionary["shipAPOFPOState"] = string.Empty;
				dictionary["shipAPOFPOPostalCode"] = string.Empty;
				dictionary["shipHomePhone"] = (string)this.jtoken_0["payment"]["phone"];
				dictionary["shipMethodCodeS2S"] = string.Empty;
				dictionary["shipMethodCode"] = this.string_9;
				dictionary["storePickupInputPostalCode"] = string.Empty;
				dictionary["promoType"] = string.Empty;
				dictionary["CPCOrSourceCode"] = string.Empty;
				dictionary["payMethodPanePayType"] = "CC";
				dictionary["payMethodPanestoredCCCardNumber"] = "CC";
				dictionary["CardNumber"] = ((string)this.jtoken_0["payment"]["card"]["number"]).Replace(" ", string.Empty);
				dictionary["CardExpireDateMM"] = (string)this.jtoken_0["payment"]["card"]["exp_month"];
				dictionary["CardExpireDateYY"] = (string)this.jtoken_0["payment"]["card"]["exp_year"];
				dictionary["CardCCV"] = (string)this.jtoken_0["payment"]["card"]["cvv"];
				dictionary["payMethodPaneStoredType"] = string.Empty;
				dictionary["payMethodPaneConfirmCardNumber"] = string.Empty;
				dictionary["payMethodPaneStoredCCExpireMonth"] = string.Empty;
				dictionary["payMethodPaneStoredCCExpireYear"] = string.Empty;
				dictionary["payMethodPaneCardType"] = this.method_2(((string)this.jtoken_0["payment"]["card"]["number"]).Replace(" ", string.Empty));
				dictionary["payMethodPaneCardNumber"] = ((string)this.jtoken_0["payment"]["card"]["number"]).Replace(" ", string.Empty);
				dictionary["payMethodPaneExpireMonth"] = (string)this.jtoken_0["payment"]["card"]["exp_month"];
				dictionary["payMethodPaneExpireYear"] = this.jtoken_0["payment"]["card"]["exp_year"].ToString()[2].ToString() + this.jtoken_0["payment"]["card"]["exp_year"].ToString()[3].ToString();
				dictionary["payMethodPaneCVV"] = (string)this.jtoken_0["payment"]["card"]["cvv"];
				dictionary["payMethodPaneStoredCCCVV"] = string.Empty;
				dictionary["shipProvince"] = Class167.smethod_1((string)this.jtoken_0["delivery"]["country"], (string)this.jtoken_0["delivery"]["state"]);
				dictionary["billProvince"] = Class167.smethod_1((string)this.jtoken_0["billing"]["country"], (string)this.jtoken_0["billing"]["state"]);
				HttpResponseMessage httpResponseMessage = this.class70_0.method_7(string.Format("https://www.{0}/checkout/eventGateway?method=validateReviewPane", this.string_2), dictionary, false);
				if (!this.method_3(httpResponseMessage))
				{
					httpResponseMessage.EnsureSuccessStatusCode();
					JObject jobject = JObject.Parse(httpResponseMessage.smethod_3().Substring(2, httpResponseMessage.smethod_3().Length - 2));
					if (!httpResponseMessage.smethod_3().Contains("order.credit.auth.error"))
					{
						if (httpResponseMessage.smethod_3().Contains("order.ledger.synchronization.error"))
						{
							this.class4_0.method_0("Payment error", "red", false);
						}
						else if ((bool)jobject["ORDERREVIEWPANE"]["ORDERSUBMITTED"])
						{
							this.class4_0.method_12();
							this.class4_0.method_9(false);
							this.class4_0.method_0("Successfully checked out", "green", false);
						}
						throw new Exception();
					}
					this.class4_0.method_9(true);
					this.class4_0.method_0("Card Declined", "red", false);
					break;
				}
			}
			catch (ThreadAbortException)
			{
				break;
			}
			catch
			{
				this.class4_0.method_4("Error submitting order", "#c2c2c2", true, false);
				Thread.Sleep(GClass0.int_1);
			}
		}
	}

	// Token: 0x04000269 RID: 617
	private Class70 class70_0;

	// Token: 0x0400026A RID: 618
	private Class4 class4_0;

	// Token: 0x0400026B RID: 619
	private JToken jtoken_0;

	// Token: 0x0400026C RID: 620
	private int int_0;

	// Token: 0x0400026D RID: 621
	private JToken jtoken_1;

	// Token: 0x0400026E RID: 622
	private string string_0;

	// Token: 0x0400026F RID: 623
	private string string_1;

	// Token: 0x04000270 RID: 624
	private string string_2;

	// Token: 0x04000271 RID: 625
	private string string_3;

	// Token: 0x04000272 RID: 626
	private string string_4;

	// Token: 0x04000273 RID: 627
	private string string_5;

	// Token: 0x04000274 RID: 628
	private string string_6;

	// Token: 0x04000275 RID: 629
	private string string_7;

	// Token: 0x04000276 RID: 630
	private string string_8;

	// Token: 0x04000277 RID: 631
	private string string_9;

	// Token: 0x04000278 RID: 632
	private string string_10;

	// Token: 0x04000279 RID: 633
	private string string_11;

	// Token: 0x0400027A RID: 634
	private CookieCollection cookieCollection_0;

	// Token: 0x020000C3 RID: 195
	[Serializable]
	private sealed class Class104
	{
		// Token: 0x06000524 RID: 1316 RVA: 0x00003C7C File Offset: 0x00001E7C
		internal char method_0(string string_0)
		{
			return string_0[MainWindow.random_0.Next(string_0.Length)];
		}

		// Token: 0x0400027B RID: 635
		public static readonly Class103.Class104 class104_0 = new Class103.Class104();

		// Token: 0x0400027C RID: 636
		public static Func<string, char> func_0;
	}
}
