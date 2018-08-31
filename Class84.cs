using System;
using System.Linq;
using System.Threading;
using Newtonsoft.Json.Linq;

// Token: 0x020000A0 RID: 160
internal sealed class Class84
{
	// Token: 0x06000339 RID: 825 RVA: 0x0001BAA4 File Offset: 0x00019CA4
	public Class84(string string_5, Class4 class4_1, JToken jtoken_1)
	{
		this.class4_0 = class4_1;
		this.jtoken_0 = jtoken_1;
		this.string_3 = GClass2.smethod_2(32);
		this.string_1 = new Uri(string_5).Query.Split(new char[]
		{
			'&'
		}).Where(new Func<string, bool>(Class84.Class85.class85_0.method_0)).First<string>().Split(new char[]
		{
			'='
		})[1];
		this.string_0 = string.Format("https://www.paypal.com/webapps/xoonboarding?token={0}&useraction=commit&country.x=US&locale.x=en_US&country.x=US&locale.x=en_US#", this.string_1);
	}

	// Token: 0x0600033A RID: 826 RVA: 0x00004930 File Offset: 0x00002B30
	public void method_0()
	{
		this.method_1();
		this.method_2();
	}

	// Token: 0x0600033B RID: 827 RVA: 0x0001BB5C File Offset: 0x00019D5C
	public void method_1()
	{
		for (;;)
		{
			try
			{
				this.class4_0.method_4("Getting PayPal data", "#c2c2c2", true, false);
				JObject jobject = JObject.Parse(this.class70_0.method_5(this.string_0, true).smethod_3().Split(new string[]
				{
					"/payee\", "
				}, StringSplitOptions.None)[1].Split(new string[]
				{
					", \"payee"
				}, StringSplitOptions.None)[0]);
				this.string_4 = (string)jobject["data"]["merchant"]["id"];
				this.string_2 = (string)jobject["meta"]["calc"];
				GClass3.smethod_0("Got merchant ID: " + this.string_4, "PayPal");
				GClass3.smethod_0("Got calc: " + this.string_2, "PayPal");
			}
			catch (ThreadAbortException)
			{
			}
			catch
			{
				this.class4_0.method_4("Error getting PayPal data", "#c2c2c2", true, false);
				Thread.Sleep(GClass0.int_1);
				continue;
			}
			break;
		}
	}

	// Token: 0x0600033C RID: 828 RVA: 0x0001BC94 File Offset: 0x00019E94
	public void method_2()
	{
		for (;;)
		{
			try
			{
				this.class4_0.method_4("Submitting payment", "orange", true, false);
				JObject jobject = JObject.Parse("{ \"data\": { \"user\": { \"first_name\": \"\", \"last_name\": \"\", \"email\": \"\", \"countryOfResidence\": \"GB\", \"country\": \"GB\", \"nationality\": \"GB\" }, \"billing_address\": { \"line1\": \"\", \"city\": \"\", \"state\": \"\", \"postal_code\": \"\", \"country\": \"GB\" }, \"shipping_address\": { \"first_name\": \"\", \"last_name\": \"\", \"line1\": \"\", \"country\": \"\" }, \"phone\": { \"type\": \"Mobile\", \"number\": \"\", \"countryCode\": \"44\" }, \"marketing_optin\": true, \"shipping_address_validation\": false, \"prox_flow\": false, \"testParams\": {}, \"content_identifier\": \"GB:en:3.0.16:undefined\", \"frs_optin_flow_applicable\": false, \"frs_optin_active_flow\": false, \"flow_eligibility_data\": { \"is_unbranded\": false, \"merchant_preferences\": { \"id\": \"\", \"meta\": { \"populated\": true }, \"auto_return\": { \"enabled\": false }, \"pdt\": { \"enabled\": false }, \"account_optional\": { \"enabled\": true }, \"merchant_blacklist\": { \"enabled\": false }, \"merchant_vertical_high_risk\": { \"enabled\": true }, \"charset\": \"windows-1252\" }, \"merchant_country\": \"US\" }, \"card\": { \"type\": \"\", \"number\": \"\", \"security_code\": \"\", \"expiry_month\": \"\", \"expiry_year\": \"\" }, \"skipInitiateAuth\": true }, \"meta\": { \"token\": \"\", \"calc\": \"\", \"csci\": \"\", \"locale\": { \"country\": \"GB\", \"language\": \"en\" }, \"state\": \"ui_checkout_guest\", \"app_name\": \"xoonboardingnodeweb\" } }");
				jobject["data"]["user"]["first_name"] = this.jtoken_0["billing"]["first_name"];
				jobject["data"]["user"]["last_name"] = this.jtoken_0["billing"]["last_name"];
				jobject["data"]["user"]["email"] = this.jtoken_0["payment"]["email"];
				jobject["data"]["billing_address"]["line1"] = this.jtoken_0["billing"]["addr1"];
				jobject["data"]["billing_address"]["city"] = this.jtoken_0["billing"]["city"];
				jobject["data"]["billing_address"]["state"] = Class167.smethod_1((string)this.jtoken_0["billing"]["country"], (string)this.jtoken_0["billing"]["state"]);
				jobject["data"]["billing_address"]["postal_code"] = this.jtoken_0["billing"]["zip"];
				jobject["data"]["billing_address"]["country"] = Class167.smethod_0((string)this.jtoken_0["billing"]["country"], false);
				jobject["data"]["shipping_address"]["first_name"] = this.jtoken_0["delivery"]["first_name"];
				jobject["data"]["shipping_address"]["last_name"] = this.jtoken_0["delivery"]["last_name"];
				jobject["data"]["shipping_address"]["line1"] = this.jtoken_0["delivery"]["addr1"];
				jobject["data"]["shipping_address"]["city"] = this.jtoken_0["delivery"]["city"];
				jobject["data"]["shipping_address"]["state"] = Class167.smethod_1((string)this.jtoken_0["delivery"]["country"], (string)this.jtoken_0["delivery"]["state"]);
				jobject["data"]["shipping_address"]["postal_code"] = this.jtoken_0["delivery"]["zip"];
				jobject["data"]["shipping_address"]["country"] = Class167.smethod_0((string)this.jtoken_0["delivery"]["country"], false);
				jobject["data"]["phone"]["number"] = this.jtoken_0["payment"]["phone"];
				jobject["data"]["card"]["type"] = "MASTERCARD";
				jobject["data"]["card"]["number"] = this.jtoken_0["payment"]["card"]["number"].ToString().Replace(" ", string.Empty);
				jobject["data"]["card"]["expiry_month"] = this.jtoken_0["payment"]["card"]["exp_month"];
				jobject["data"]["card"]["expiry_year"] = this.jtoken_0["payment"]["card"]["exp_year"];
				jobject["data"]["card"]["security_code"] = this.jtoken_0["payment"]["card"]["cvv"];
				jobject["data"]["flow_eligibility_data"]["merchant_preferences"]["id"] = this.string_4;
				jobject["meta"]["token"] = this.string_1;
				jobject["meta"]["calc"] = this.string_2;
				jobject["meta"]["csci"] = this.string_3;
				this.class70_0.method_9("https://www.paypal.com/webapps/xoonboarding/api/onboard/guest", jobject, false);
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

	// Token: 0x0400020B RID: 523
	private Class70 class70_0 = new Class70(null, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.181 Safari/537.36", 10, false, false, null, false);

	// Token: 0x0400020C RID: 524
	private JToken jtoken_0;

	// Token: 0x0400020D RID: 525
	private Class4 class4_0;

	// Token: 0x0400020E RID: 526
	private string string_0;

	// Token: 0x0400020F RID: 527
	private string string_1;

	// Token: 0x04000210 RID: 528
	private string string_2;

	// Token: 0x04000211 RID: 529
	private string string_3;

	// Token: 0x04000212 RID: 530
	private string string_4;

	// Token: 0x020000A1 RID: 161
	[Serializable]
	private sealed class Class85
	{
		// Token: 0x0600033F RID: 831 RVA: 0x0000494A File Offset: 0x00002B4A
		internal bool method_0(string string_0)
		{
			return string_0.Contains("token");
		}

		// Token: 0x04000213 RID: 531
		public static readonly Class84.Class85 class85_0 = new Class84.Class85();

		// Token: 0x04000214 RID: 532
		public static Func<string, bool> func_0;
	}
}
